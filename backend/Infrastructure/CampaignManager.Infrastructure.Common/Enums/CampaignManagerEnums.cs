using System.ComponentModel;

namespace CampaignManager.Infrastructure.Common.Enums
{
    public class CampaignManagerEnums
    {
        public enum APIStatusCodes
        {
            InternalServerError = 1,
            ClientRegistedSuccess,
            ClientRegistedFailure,
            ClientRegistedError,
            ClientNotGound,
            S3BucketAlreadyExist,
            S3BucketNotExist,
            EmailSubscriptionFailed,
            EmailAlreadyRegistered,
            Logoutsuccessfully,
            ImageUploadFailed,
            NoDataFound,
            UserAlreadyExist,
            UserAlreadyClaimed
        }
        public enum EnumPaymentSource
        {
            Stripe = 1,
            Blocto,
            Crypto,
            Circle,
            MoonPay
        }
        public enum SocialMediaType
        {
            Google = 1,
            Twitter,
            Facebook,
            Discord,
            Instagram
        }
        public enum Reason
        {
            [Description("duplicate")]
            duplicate,
            [Description("fraudulent")]
            fraudulent,
            [Description("requested_by_customer")]
            requested_by_customer,
            [Description("bank_transaction_error")]
            bank_transaction_error,
            [Description("invalid_account_number")]
            invalid_account_number,
            [Description("insufficient_funds")]
            insufficient_funds,
            [Description("payment_stopped_by_issuer")]
            payment_stopped_by_issuer,
            [Description("payment_returned")]
            payment_returned,
            [Description("bank_account_ineligible")]
            bank_account_ineligible,
            [Description("invalid_ach_rtn")]
            invalid_ach_rtn,
            [Description("unauthorized_transaction")]
            unauthorized_transaction,
            [Description("payment_failed")]
            payment_failed
        }
        public enum ClientType
        {
            CircleHttpClient = 1,
            LicenceNodeAPI,
            DapperAPI,
            AuthServer
        }
        public enum CirclePyamentSourceType
        {
            card,
            ach
        }
        public enum CirclePyamentVerificationType
        {
            cvv,
            three_d_secure
        }
        public enum PaymentType
        {
            USDC,
            CreditCard
        }
        public enum BlockChainScriptEnum
        {
            CreateAsset = 1,
            CreateBrand = 2,
            GetBrandById = 3,
            BrandMultiSign = 4,
            BrandCapabilityCheck = 5,
            BrandDetailsList = 6,
            GetAssets = 7,
            CreateDrop = 8,
            DeleteAsset = 9,
            DeleteDrop = 10,
            UpdateDrop = 11,
            UpdateAsset = 12,
            UserFlowBalance = 13,
            UserCapabilityCheck = 14,
            UserCapabilityCreation = 15,
            BloctoPurchaseScript = 16,
            MintAndTransferScript = 17,
            GetAssetSupply = 18,
            GetUserCollection = 19
        }

        public enum EmailTemplates
        {
            ForgotEmailTemplate,
            VerfiyEmailTemplate,
            ResetPasswordTemplate,
            StoreFrontApprovalEmailTemplate,
            KYBCompletedEmailTemplate,
            ArweaveTokenRunningOutTemplate,
            CongragulationTemplate,
            SucessfullOrderEmailTemplate,
            UnSucessfullOrderEmailTemplate,
            SetPasswordTemplate,
            OrderConfirmationEmailTemplate,
            OrderSuccessFullEmailTemplate,
            StoreFrontDeclineEmailTemplate,
        }

        public enum CampaignStepsEnum
        {
            SelectContract = 1,
            ComunityTargeting = 2,
            AttachUtility = 3,
            Confirmation = 4
        }
        public enum DatabaseOptions
        {
            Default = 1
        }

        public enum ClientThemeStepsEnum
        {
            HomePage = 1,
            AboutUs = 2,
            TermsAndConditions = 3,
            PrivacyPolicy = 4
        }
        public enum AssetState
        {
            SoldOut = 1,
            UpComing = 2,
            Current = 3,
            Past = 4
        }
        public enum StaticContent
        {
            AboutUs = 1,
            TermsAndConditions = 2,
            Privacypolicy = 3
        }
    }
}
