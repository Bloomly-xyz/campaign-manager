using Amazon.Runtime; 
using Amazon.SecretsManager;
using CampaignManager.Data.Context;
using CampaignManager.Infrastructure.Common.Utils;
using CampaignManager.Infrastructure.Models.ConfigModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models; 
using Amazon.Extensions.NETCore.Setup;
using Amazon;
using Amazon.S3;
using System.Reflection;
using CampaignManager.Infrastructure.Common.Operation;
using CampaignManager.Infrastructure.Common.Cache;
using CampaignManager.Data.Core;
using CampaignManager.Business.Services.Interfaces;
using CampaignManager.Business.Services.Services;
using CampaignManager.Data.IRepository;
using CampaignManager.Data.Repository;
using CampaignManager.Infrastructure.Communication.AWS.S3Services.Bucket;
using CampaignManager.Infrastructure.Communication.AWS.S3Services.File;

namespace CampaignManager.Api.Extensions
{
    public static class RegisterDISerices
    {
        public async static Task RegisterAllDIServices(this WebApplicationBuilder builder)
        {

            #region Identity 
            builder.Configuration.AddEnvironmentVariables();
            DotNetEnv.Env.TraversePath().Load(".env");
            string ConnectionStr = String.Empty;
            string PrivateKey = String.Empty;
            string NftContractAddress = String.Empty;
            string DropContractAddress = String.Empty;
            
            var environment = Environment.GetEnvironmentVariable("ENVIRONMENT");
            
            if (environment == "DEVELOPMENT")
            {
                PrivateKey = Environment.GetEnvironmentVariable("DEVPRIVATEKEY");
                NftContractAddress = Environment.GetEnvironmentVariable("DEVNFTCONTRACTADDRESS");
                DropContractAddress = Environment.GetEnvironmentVariable("DEVDROPCONTRACTADDRESS");
                ConnectionStr = Environment.GetEnvironmentVariable("DEFAULTCONNECTION");
            }
            else if (environment == "LOCALHOST")
            {
                PrivateKey = Environment.GetEnvironmentVariable("DEVPRIVATEKEY");
                NftContractAddress = Environment.GetEnvironmentVariable("DEVNFTCONTRACTADDRESS");
                DropContractAddress = Environment.GetEnvironmentVariable("DEVDROPCONTRACTADDRESS");
                ConnectionStr = Environment.GetEnvironmentVariable("DEFAULTCONNECTION");
            }
            else if (environment == "STAGING")
            {
                PrivateKey = Environment.GetEnvironmentVariable("STAGINGPRIVATEKEY");
                NftContractAddress = Environment.GetEnvironmentVariable("STAGINGNFTCONTRACTADDRESS");
                DropContractAddress = Environment.GetEnvironmentVariable("STAGINGDROPCONTRACTADDRESS");
                ConnectionStr = Environment.GetEnvironmentVariable("STAGINGCONNECTION");
            }
            else if (environment == "PROD")
            {
                PrivateKey = Environment.GetEnvironmentVariable("PRODPRIVATEKEY");
                NftContractAddress = Environment.GetEnvironmentVariable("PRODNFTCONTRACTADDRESS");
                DropContractAddress = Environment.GetEnvironmentVariable("PRODDROPCONTRACTADDRESS");
                ConnectionStr = Environment.GetEnvironmentVariable("PRODUCTIONCONNECTION");
            }
            var connectionStrings = new ConnectionStrings
            {
                DefaultConnection = ConnectionStr
            };
            builder.Services.AddSingleton(connectionStrings);
            var ApiKey = new ApiKey
            {
                XApiKey = Environment.GetEnvironmentVariable("XApiKey")
            };
            builder.Services.AddSingleton(ApiKey);
            var _blockChainConstant = new BlockChianConfig
            {
                PRIVATEKEY = PrivateKey,
                DROPCONTRACTADDRESS = DropContractAddress,
                NFTCONTRACTADDRESS = NftContractAddress,
                NFTCONTRACTNAME = Environment.GetEnvironmentVariable("NFTCONTRACTNAME"),
                DROPCONCTRACTNAME = Environment.GetEnvironmentVariable("DROPCONCTRACTNAME"),
                TEMPLATECREATEDEVENT = Environment.GetEnvironmentVariable("TEMPLATECREATEDEVENT"),
                NONFUNGIBLETOKEN = Environment.GetEnvironmentVariable("NONFUNGIBLETOKEN"),
                FLOWNETWORKURL = Environment.GetEnvironmentVariable("FLOWNETWORKURL"),
                NFTCAPABILITYPATH = Environment.GetEnvironmentVariable("NFTCAPABILITYPATH"),
            };
            builder.Services.AddSingleton(_blockChainConstant);
            var awsConfig = new AWSecretManagerConfig()
            {
                AccessKey = Environment.GetEnvironmentVariable("AccessKey"),
                SecretAccessKey = Environment.GetEnvironmentVariable("SecretAccessKey"),
            };
            builder.Services.AddSingleton(awsConfig);
          
            builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(ConnectionStr));
            #endregion Identity

            #region Inject Business Services 
            builder.Services.AddScoped<IS3bucketService, S3bucketService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICampaignService, CampaignService>();
            builder.Services.AddScoped<IUtilityService, UtilityService>();
            #endregion Inject Business Services 

            #region Inject Data Services
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUtilityRepository, UtilityRepository>();
            builder.Services.AddScoped<ICampaignRepository, CampaignRepository>();
            #endregion Inject Data Services

            #region Inject Configurations
            builder.Services.Configure<AWSS3Config>(builder.Configuration.GetSection("AWSS3Config"));
            builder.Services.AddScoped<IBucketService, BucketService>();
            builder.Services.AddScoped<IFileService, FileService>();
            #endregion Inject Configurations

            #region Inject Communication Services
            builder.Services.AddScoped<IUtilService, UtilService>();
            builder.Services.AddScoped<ISafeOperationExecutor, SafeOperationExecutor>();
            builder.Services.AddScoped<IDBOperationExecutor, DBOperationExecutor>();
            builder.Services.AddScoped<ICache, AzureRedisCache>();
            builder.Services.AddScoped<IDBAccess, DBAccess>();
            #endregion Inject Communication Services

            #region Swagger/SEQ Logging/HTTP Client and Others


            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(builder.Configuration.GetValue<string>("Swagger:Version"), new OpenApiInfo
                {
                    Version = builder.Configuration.GetValue<string>("Swagger:Version"),
                    Title = builder.Configuration.GetValue<string>("Swagger:Title"),
                    Description = builder.Configuration.GetValue<string>("Swagger:Description"),
                    TermsOfService = new Uri(builder.Configuration.GetValue<string>("Swagger:TermsOfService")),

                    Contact = new OpenApiContact
                    {
                        Name = builder.Configuration.GetValue<string>("Swagger:ContactName"),
                        Url = new Uri(builder.Configuration.GetValue<string>("Swagger:ContactUrl"))
                    }
                });
                
                c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    Name = "XApiKey",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "ApiKeyScheme",
                    In = ParameterLocation.Header,
                    Description = "ApiKey must appear in header"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "ApiKey"
                                }
                            },
                            new string[] {}
                    }
                });
                // using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
            builder.Services.AddSwaggerGenNewtonsoftSupport();
            builder.Services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSeq(builder.Configuration.GetSection("Seq"));
            });
           
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(1);
            });
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCors();

            AWSOptions awsOptions = new AWSOptions
            {
                Credentials = new BasicAWSCredentials(Environment.GetEnvironmentVariable("AccessKey"), Environment.GetEnvironmentVariable("SecretAccessKey")),
                Region = RegionEndpoint.GetBySystemName(Environment.GetEnvironmentVariable("Region")),
            };
            builder.Services.AddDefaultAWSOptions(awsOptions);
            builder.Services.AddAWSService<IAmazonS3>();
            builder.Services.AddAWSService<IAmazonSecretsManager>();

            #endregion Swagger/SEQ Logging/HTTP Client and Others
        }
    }
}
