# Campaign Manager - [Swagger](https://campaignmanager-api.bloomly.xyz/swagger/index.html)

**The problem it solves:** The aim and objectives of our project, and why should people use it?

**Up until now**, there are thousands of NFT projects in the market, some successful and some rug pulls. The missing piece is the value or utility it provides. The successful drops share their utility in discord or twitter posts. If you’re not waking up and tweeting #wagmi you’re missing out. This is where our campaign manager comes in. It attaches utility to your nft collection and presents it to your community who can then claim it. Once claimed, the creator can provide further value to the community based on their engagement and the community stays up to date by receiving notifications thus no longer having to scroll thru feeds & tons of messages



## Main System Components:
* **Cloud Flare**: Cloud flare may be used to have easy access to HTTPS and a certificate, and also to prevent DDOS.
* **Web Servers**: Are the list of web servers that run the Bloomly web application and serve user HTTP requests.
* **Cache**: A cache is used to store frequently requested data. All data that is changed has to have its corresponding cached data invalidated.
* **Relational Database**: Stores all data that is non-critical, and also serves as a persistent “second layer” caching mechanism for data stored inside the blockchain.  All data changed in the blockchain has to have its corresponding copy in the database updated.
* **Blocto Cloud Wallet**: Stores user data and user private keys.
* **Blockchain Nodes**: Store the flow blockchain and execute smart contracts code.
* **CDN**: Stores images for quicker retrieval. 
* **Cloud S3 Bucket**: Stores images and data with redundancy. 

# Tech Stack
Given below is the tech stack we have used in our application. For development on the server side, 
  * We are using [asp.net](http://asp.net) core.
  * On the front end, we have used React js. 
  * For the database, we are using SQL server (Microsoft SQL Server 2022 (RTM) - 16.0.1000.6 (X64)  - Developer Edition (64-bit) on Linux (Ubuntu 20.04.5 LTS) <X64>). 
 
### .NET Implementations:
* [.NET Core](https://github.com/dotnet/core) - Core .NET Framework V - net6.0

### Client Application:
- [React Js](https://reactjs.org/) with redux - React is a free and open-source front-end JavaScript library for building user interfaces based on UI components. It is maintained by Meta and a community of individual developers and companies. 
- [HTML 5](https://www.geeksforgeeks.org/html5-introduction/) - HTML5 is a markup language used for structuring and presenting content on the World Wide Web. It is the fifth and final major HTML version that is a World Wide Web Consortium recommendation. The current specification is known as the HTML Living Standard.  
- [Bootstrap](https://getbootstrap.com/) - Bootstrap is a free and open-source CSS framework directed at responsive, mobile-first front-end web development. It contains HTML, CSS and JavaScript-based design templates for typography, forms, buttons, navigation, and other interface components.

### Cloud Databases:
- [AWS](https://aws.amazon.com/products/?nc2=h_ql_prod&aws-products-all.sort-by=item.additionalFields.productNameLowercase&aws-products-all.sort-order=asc&awsf.re%3AInvent=*all&awsf.Free%20Tier%20Type=*all&awsf.tech-category=*all) Databases for MSSQL Server - Amazon Web Services, Inc. is a subsidiary of Amazon that provides on-demand cloud computing platforms and APIs to individuals, companies, and governments, on a metered pay-as-you-go basis. These cloud computing web services provide distributed computing processing capacity and software tools via AWS server farms.
- Regular backups configured on the cloud

### ORM
* [Entity fram work](https://learn.microsoft.com/en-us/ef/core/) v-6.0.6 - Entity Framework (EF) Core is a lightweight, extensible, open source and cross-platform version of the popular Entity Framework data access technology. 
 
### File Storage: 
- [AWS S3 Bucket](https://aws.amazon.com/s3/) - Amazon Simple Storage Service (Amazon S3) is an object storage service offering industry-leading scalability, data availability, security, and performance. Customers of all sizes and industries can store and protect any amount of data for virtually any use case, such as data lakes, cloud-native applications, and mobile apps. With cost-effective storage classes and easy-to-use management features, you can optimize costs, organize data, and configure fine-tuned access controls to meet specific business, organizational, and compliance requirements.

### Blockchain:
- [Flow](https://flow.com/primer) FCL library - ‍Flow is a fast, decentralized, and developer-friendly blockchain, designed as the foundation for a new generation of games, apps, and the digital assets that power them. It is based on a unique, multi-role architecture, and designed to scale without sharding, allowing for massive improvements in speed and throughput while preserving a developer-friendly, ACID-compliant environment. 
- [Blocto Wallet](https://docs.blocto.app/?_gl=1*re7w1*_ga*OTg1ODMyODU5LjE2NzQ1Njk4MzM.*_ga_7DN84WVTSV*MTY3NDU2OTgzMi4xLjEuMTY3NDU2OTg1Mi40MC4wLjA.) - What is Blocto wallet?
Blocto is a cross-chain smart contract wallet that currently supports Solana, Ethereum, Flow, Binance Smart Chain, and Tron. This wallet allows users to easily log in with their email, store cryptocurrencies, interact with dApps, and buy / sell NFTs in a user-friendly way.


### Security:
* [Dot Net Identity](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-6.0&tabs=visual-studio) - Manages users, passwords, profile data, roles, claims, tokens, email confirmation, and more. 
* [Authenticate using API keys](https://blog.hubspot.com/website/api-keys) An API key is an identifier assigned to an API client, used to authenticate an application calling the API. It is typically a unique alphanumeric string included in the API call, which the API receives and validates. Many APIs use keys to keep track of usage and identify invalid or malicious requests.

### Logging: 
* [Logger](https://learn.microsoft.com/en-us/dotnet/core/extensions/logging?tabs=command-line) - Logger is used for creating customized error log files or an error can be registered as a log entry in the Windows Event Log on the administrator's machine.  
* [SEQ](https://datalust.co/seq) - Seq accepts logs via HTTP, GELF, custom inputs, and the seqcli command-line client, with plug-ins or integrations available for .NET Core, Java, Node.js, Python, Ruby, Go, Docker, message queues, and many other technologies.

### Unit Test:
* [xUnit.net](https://www.nuget.org/packages/xunit.analyzers) is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET and Xamarin. It is part of the .NET Foundation, and operates under their code of conduct. It is licensed under Apache 2 (an OSI approved license).

### Code Analyzer
* [Microsoft.CodeAnalysis.Analyzers](https://www.nuget.org/packages/Microsoft.CodeAnalysis.Analyzers/) Analyzers for consumers of Microsoft.CodeAnalysis NuGet package, i.e. extensions and applications built on top of .NET Compiler Platform (Roslyn). This package is included as a development dependency of Microsoft.CodeAnalysis NuGet package and does not need to be installed separately if you are referencing Microsoft.CodeAnalysis NuGet package.
* [xunit.analyzers](https://www.nuget.org/packages/xunit.analyzers) - xUnit.net is a developer testing framework, built to support Test Driven Development, with a design goal of extreme simplicity and alignment with framework features. Installing this package provides code analyzers to help developers find and fix frequent issues when writing tests and xUnit.net extensibility code.

### Installation

1. Create .Env file in a backedn application
2. Add following keys in the .Env file 
  ```sh
    #Connection String
    ENVIRONMENT="DEVELOPMENT"
    #ENVIRONMENT="QA"
    #ENVIRONMENT="STAGING"
    #ENVIRONMENT="PROD"
    #ENVIRONMENT="LOCALHOST"
    DEFAULTCONNECTION = "DB Connection string"
    
    #AWS S3 and Secret Manager Section
    AccessKey= "Access Key"
    SecretAccessKey= "Secret Access Key"
    Region= "Region"

    #Api Key
    XApiKey= "API security key here"
 ```
 

3. Enter your API in `.Env`
   ```sh
    XApiKey = 'ENTER YOUR API';
   ```
4.  Add Datbase connection string in `.Env`
   ```sh
     DEFAULTCONNECTION = "DB Connection string"
   ```
5.  As we are using an entity framework "code first" approach you to have to run a few migrations.
   ```sh
    a. create-migration CreateNewDatabase
    b. update-database
   ```

 
