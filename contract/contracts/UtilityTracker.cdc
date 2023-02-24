
pub contract UtilityTracker {

     // Events
    pub event ContractInitialized()
    pub event UtilityCreated(utilityId: UInt64, name: String, startTime: UFix64, endTime: UFix64?, userLimit: UInt64)
    pub event UtilityUpdated(utilityId: UInt64, name: String, startTime: UFix64, endTime: UFix64?, userLimit: UInt64)
    pub event UtilityRemoved(utilityId: UInt64)
    pub event UitilityClaim (utilityId: UInt64, address: Address)

    // Paths
    pub var ClientStoragePath: StoragePath
    pub var DappStoragePath: StoragePath
    pub var AdminStoragePath: StoragePath

    // Latest utility-id
    pub var lastIssuedUtilityId: UInt64

    // global Utilities
    access(contract) var allUtilities : {UInt64: Utility}
    access(contract) var claimedUtilties : {UInt64: {Address: UInt64}} // {utility-id: {user-address:number-of-claimed}}
    access(contract) var claimedUtiltiesByAddress : {Address: {UInt64:UInt64}}  // {user-address: {utility-id:number-of-claimed}}

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

    pub resource Client {

        pub fun createUtility(name: String, description: String, metaData: {String: AnyStruct}, startTime: UFix64, endTime: UFix64?, collectionInfo: CollectionInfo, criteria: Criteria){
            pre{
                
            }
                
            let utilityId = UtilityTracker.lastIssuedUtilityId + 1
            let utitlityCreator = self.owner!.address
            let utility = UtilityTracker.Utility(id:utilityId, creator:utitlityCreator,name: name, description: description, metaData: metaData, startTime: startTime, endTime: endTime, collectionInfo: collectionInfo, criteria: criteria)
            UtilityTracker.allUtilities.insert(key: utilityId, utility)  
            UtilityTracker.lastIssuedUtilityId =  utilityId

            emit UtilityCreated(utilityId: utilityId, name: utility.name, startTime: utility.startTime, endTime: utility.endTime, userLimit: utility.criteria.userLimit)
        }   


        pub fun updateUtility(utility: Utility){
            pre{
                UtilityTracker.allUtilities.containsKey(utility.id): "Utility does not exists"
                UtilityTracker.allUtilities[utility.id]!.creator == self.owner!.address : "Only creator can update utility"
                utility.creator == self.owner!.address : "Creator should be the same address"
                UtilityTracker.allUtilities[utility.id]!.startTime > getCurrentBlock().timestamp: "Utility is already started"                   
            }

            UtilityTracker.allUtilities.insert(key: utility.id, utility)

            emit UtilityUpdated(utilityId: utility.id, name: utility.name, startTime: utility.startTime, endTime: utility.endTime, userLimit: utility.criteria.userLimit)


        }

        pub fun removeUtility(utilityId: UInt64){
            pre{
                UtilityTracker.allUtilities.containsKey(utilityId): "Utility does not exists"
                UtilityTracker.allUtilities[utilityId]!.creator == self.owner!.address : "Only creator can remove utility"
                UtilityTracker.allUtilities[utilityId]!.startTime > getCurrentBlock().timestamp  : "Utility is already started"
            }

            UtilityTracker.allUtilities.remove(key: utilityId)
            emit UtilityRemoved(utilityId: utilityId)

        }
    }

    pub fun isCapableToClaim(utilityId: UInt64, address: Address): Bool {
        pre {
            UtilityTracker.allUtilities.containsKey(utilityId): "Utility does not exists"
            UtilityTracker.allUtilities[utilityId]!.startTime <= getCurrentBlock().timestamp: "Utility is not started yet"                   
            UtilityTracker.allUtilities[utilityId]!.endTime! > getCurrentBlock().timestamp: "Utility is expired"  
            UtilityTracker.allUtilities[utilityId]!.isActive ==  true : "Utility is not active"  
        }

        var isCapable = true

        var alreadyClaimed:UInt64 = 0

        if(UtilityTracker.claimedUtilties[utilityId]!=nil) {
            alreadyClaimed = UtilityTracker.claimedUtilties[utilityId]![address] ?? 0 
        }
        
        if(alreadyClaimed == UtilityTracker.allUtilities[utilityId]!.criteria.userLimit){
            return false
        }

        if(UtilityTracker.allUtilities[utilityId]!.criteria.allowList.length > 0 && !UtilityTracker.allUtilities[utilityId]!.criteria.allowList.contains(address)){
            return false
        }

        if(UtilityTracker.allUtilities[utilityId]!.criteria.denylist.length > 0 && UtilityTracker.allUtilities[utilityId]!.criteria.denylist.contains(address)){
            return false
        }

        return true
    }

    pub resource Dapp {

        pub fun claimUtility(utilityId: UInt64, address: Address) {
            pre{
                UtilityTracker.allUtilities.containsKey(utilityId): "Utility does not exists"
                UtilityTracker.allUtilities[utilityId]!.startTime <= getCurrentBlock().timestamp: "Utility is not started yet"                   
                UtilityTracker.allUtilities[utilityId]!.endTime! > getCurrentBlock().timestamp: "Utility is expired"  
                UtilityTracker.allUtilities[utilityId]!.isActive ==  true : "Utility is not active"  
            }

            let isCapable =  UtilityTracker.isCapableToClaim(utilityId: utilityId, address: address)

            assert(isCapable, message: "You are not able to claim this utility")

            
            var alreadyClaimed:UInt64 = 0

            if(UtilityTracker.claimedUtilties[utilityId]!=nil) {
                alreadyClaimed = UtilityTracker.claimedUtilties[utilityId]![address] ?? 0 
            }


            var allUsersClaimedUtility = UtilityTracker.claimedUtilties[utilityId]?? {}
            allUsersClaimedUtility[address]  = alreadyClaimed +  1 
            UtilityTracker.claimedUtilties[utilityId] = allUsersClaimedUtility

                
            var allClaimedUtilitiesByUser = UtilityTracker.claimedUtiltiesByAddress[address]?? {}
            allClaimedUtilitiesByUser[utilityId]  = alreadyClaimed + 1
            UtilityTracker.claimedUtiltiesByAddress[address] = allClaimedUtilitiesByUser


            UtilityTracker.allUtilities[utilityId]!.incrementTotalClaimed()
            
            emit UitilityClaim (utilityId: utilityId, address: address)

        }

    }

    pub resource Admin { 
    
        pub fun createClientResource(): @Client {
            return <- create Client()
        }

        pub fun createDappResource(): @Dapp {
            return <- create Dapp()
        }

    }
    
    init(){

        self.lastIssuedUtilityId = 0
        self.allUtilities = {}
        self.claimedUtilties = {}
        self.claimedUtiltiesByAddress = {}
        
        self.ClientStoragePath = /storage/UtilityTrackerClientV1_0
        self.DappStoragePath =  /storage/UtilityTrackerDappV1_0
        self.AdminStoragePath = /storage/UtilityTrackerAdminV1_0

        self.account.save(<- create Admin(), to: self.AdminStoragePath)
        emit ContractInitialized()

    }
}
