
pub contract UtilityTracker {

    pub struct CollectionInfo {
        pub let contractName: String
        pub let contractAddress: Address
        pub let storagePath: StoragePath
        pub let publicPath: PublicPath

        init(contractName: String, contractAddress:Address, storagePath: StoragePath, publicPath: PublicPath){
            pre{
                contractName.length > 0 : "Invalid Contract Name"                
            }

            self.contractName = contractName
            self.contractAddress =  contractAddress
            self.storagePath = storagePath
            self.publicPath = publicPath
        }
            
    }

    pub struct Criteria {
        pub let userLimit: UInt64
        pub let nftIds:[UInt64]
        pub let allowList:[Address]
        pub let denylist:[Address]
        pub let properties : {String: AnyStruct}
        pub let other : {String: AnyStruct}

        init(userLimit: UInt64, nftIds:[UInt64], allowList:[Address], denylist:[Address], properties : {String: AnyStruct}, other : {String: AnyStruct}){
            self.userLimit = userLimit
            self.nftIds = nftIds
            self.allowList = allowList
            self.denylist = denylist
            self.properties = properties
            self.other = other
        }

    }

    pub struct Utility {

        pub let id: UInt64
        pub let creator : Address 
        pub var name: String 
        pub var description: String
        access(contract) var metaData : {String: AnyStruct}

        pub var startTime: UFix64
        pub var endTime: UFix64?
        
        pub var collectionInfo: CollectionInfo
        pub var criteria : Criteria

        pub var isActive : Bool
        pub var totalClaimed: UInt64

        init(id:UInt64, creator:Address,name: String, description: String, metaData: {String: AnyStruct}, startTime: UFix64, endTime: UFix64?, collectionInfo: CollectionInfo, criteria: Criteria) {
            pre{
                name.length > 0 : "Name of utility is required"
                description.length > 0 : "description of utility is required"
                startTime >= getCurrentBlock().timestamp: "Start time should be greater than current time"
                endTime == nil || endTime!  >= startTime : "End time should be greater than start time"                            
            }

            self.id = id
            self.creator =  creator
            self.name = name
            self.description = description
            self.metaData = metaData
            self.startTime = startTime
            self.endTime = endTime
            self.collectionInfo = collectionInfo
            self.criteria = criteria
            self.isActive = true
            self.totalClaimed = 0
        }

        pub fun getMetadata(): {String: AnyStruct} {
            return self.metaData
        }

        access(contract) fun incrementTotalClaimed() {
            self.totalClaimed = self.totalClaimed + 1
        }
                
    }
    
    init(){
    }
}
