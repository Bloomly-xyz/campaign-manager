## Overview

## Utility Tracker Contract

Utility Tracker is a Smart Contract which record or trace NFT utilities created by the multiple clients. It will have multiple entities which can intract with smart-contract e.g: Admin, client and user. It is not NFT based smart-contract but it will be used to attach utility with NFTs. 

### CollectionInfo

It is is structure that will store collection information that will be used by the FE/BE application to verify or check if user hold that specific NFT/s. All information related to NFT collection will be listed here. It has following attributes: 

- `contractName: String`: It will the NFT contract name which is deployed on specific address.

- `contractAddress: Address`: It will be the flow address where smart-contract is deployed.

- `storagePath: StoragePath`: It will the storage path of NFT collection. It will be used in future to withdraw NFT from user collection.

- `publicPath: PublicPath`: It will be the public path of NFT collection. It will be used to check if user hold that specific NFT.


```
    pub struct CollectionInfo {
        pub let contractName: String
        pub let contractAddress: Address
        pub let storagePath: StoragePath
        pub let publicPath: PublicPath

        init(contractName: String, contractAddress:Address, storagePath: StoragePath, publicPath: PublicPath)
            
    }

```

1.  `init(contractName: String, contractAddress:Address, storagePath: StoragePath, publicPath: PublicPath)` <br />
    It is a constructor method, which is called whenever a new collectionInfo object is created. It requires a couple of parameters as an arguments:

    - `contractName: String` : Name of the NFT contract.
    - `contractAddress:Address` : Flow address where the smart-contract is deployed.
    - `storagePath: StoragePath` : Store path of the NFT collection. It will be used in future to withdraw NFT from the collection
    - `publicPath: PublicPath` : Public path of the NFT collection, which will be used to check if user hold that specific NFT.



### Criteria

It is the structure that will store all conditions and critera of the NFT utility which should be valid for the NFT holder. This structure will be used to whenever any user claim the utility. It will be setted by the client. It has following attributes: 

- `userLimit: UInt64`: User limit per Utility in other words how many times user can claim the utility.

- `nftIds:[UInt64]`: It will represent all particular nft-ids on which utility will be attached.

- `allowList:[Address]`: It will represent all the partular address that are only able to claim the utility.

- `denylist:[Address]`: It will represent all the particular address that are not allowed to cliam that utility.

- `properties : {String: AnyStruct}`: It will represent the metadata of that specific NFT on which utility is attached.

- `other : {String: AnyStruct}`: It will represent all other conditions or criteria that are not defiend yet and will be in the future.


```
    pub struct Criteria {
        pub let userLimit: UInt64
        pub let nftIds:[UInt64]
        pub let allowList:[Address]
        pub let denylist:[Address]
        pub let properties : {String: AnyStruct}
        pub let other : {String: AnyStruct}

        init(userLimit: UInt64, nftIds:[UInt64], allowList:[Address], denylist:[Address], properties : {String: AnyStruct}, other : {String: AnyStruct})

    }

```

1.  `init(userLimit: UInt64, nftIds:[UInt64], allowList:[Address], denylist:[Address], properties : {String: AnyStruct}, other : {String: AnyStruct})` <br />
    It is a constructor method, which is called whenever a new criteria object is created. It requires a couple of parameters as an arguments:

    - `userLimit: UInt64`: User limit per Utility in other words how many times user can claim the utility.    
    - `nftIds:[UInt64]`: It will represent all particular nft-ids on which utility will be attached.
    - `allowList:[Address]`: It will represent all the partular address that are only able to claim the utility.
    - `denylist:[Address]`: It will represent all the particular address that are not allowed to cliam that utility.
    - `properties : {String: AnyStruct}`: It will represent the metadata of that specific NFT on which utility is attached.
    - `other : {String: AnyStruct}`: It will represent all other conditions or criteria that are not defiend yet and will be in the future.


### Utility

Utility is the main struct that hold all utility information related to any NFT collection. It has multiple attributes and methods to provide multiple functionalities. It has following attributes: 

- `id: UInt64`: Unique and incremental id for the each utility.

- `creator : Address`: It will represent creator of the utility.

- `name: String`: It will represent the name of the utility.

- `description: String`: It will represent the description of the utility.

- `metaData : {String: AnyStruct}`: It will represent the metadata of the utility.

- `startTime: UFix64`: It will represent the start time of the utility.

- `endTime: UFix64?`: It will represent the end time of the utility. It is an optional value, therefore in case of nil utility will remain for ever.

- `collectionInfo: CollectionInfo`: It will store nft collection information. 

- `criteria : Criteria`: It will represent the criteria of utility that need to be fullfil to claim that utility.

- `isActive : Bool`: It will represent if utility is active or not.

- `totalClaimed: UInt64`: It will represent the total number of claimed to that specific utility.


```
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

        init(id:UInt64, creator:Address,name: String, description: String, metaData: {String: AnyStruct}, startTime: UFix64, endTime: UFix64?, collectionInfo: CollectionInfo, criteria: Criteria) 

        pub fun getMetadata(): {String: AnyStruct} 

        access(contract) fun incrementTotalClaimed() 

    }

```

1.  `init(id:UInt64, creator:Address,name: String, description: String, metaData: {String: AnyStruct}, startTime: UFix64, endTime: UFix64?, collectionInfo: CollectionInfo, criteria: Criteria)` <br />
    It is a constructor method, which is called whenever a new utility object is created. It requires a couple of parameters as an arguments:

    - `id: UInt64`: Unique for utility.
    - `creator : Address`: Creator of the utility.
    - `name: String`: Name of the utility.
    - `description: String`: Description of the utility.
    - `metaData : {String: AnyStruct}`: Metadata or further information related to the utility.
    - `startTime: UFix64`: Start time of the utility in other words when should utilty will start.
    - `endTime: UFix64?`: End time of the utility or when should utility will ended. It's an optional value, therefore in case of nil utility will remain for ever.
    - `collectionInfo: CollectionInfo`: Collection information for that NFT collection on which utility is attached. 
    - `criteria : Criteria`: Criteria of utility that need to be fullfil to claim that utility.


2.  `pub fun getMetadata(): {String: AnyStruct}` <br />
    It is used to fetechd metadata of the utility. Metadata will be in the form of key-value pair dictionary where key will be in the `String` and value can be any data type.


3.  `access(contract) fun incrementTotalClaimed()` <br />
    It is used to update the totalClaim veriable of the utility. It is called when ever any user claimed that specific utility. It is a restricted method.


### Client

Client is the main resource which is created by the Admin and stored on Client storage. This resource is needed to perform utility functionality. It has all neccessary methods regarding utility e.g: create, update and remove utility. Client only update and remove his own utility. 

```
    pub resource Client {

        pub fun createUtility(name: String, description: String, metaData: {String: AnyStruct}, startTime: UFix64, endTime: UFix64?, collectionInfo: CollectionInfo, criteria: Criteria)

        pub fun updateUtility(utility: Utility)

        pub fun removeUtility(utilityId: UInt64)

    }

```

Here is the detail about this resource: 

1.  `pub fun createUtility(name: String, description: String, metaData: {String: AnyStruct}, startTime: UFix64?, endTime: UFix64?, collectionInfo: CollectionInfo, criteria: Criteria)` <br />
    It is a method which is called whenever any utility is created by the client. It requires a couple of parameters as an arguments:

    - `name: String`: Name of utility. 
    - `description: String`: Description of the utility.
    - `metaData: {String: AnyStruct}`: Metadata or further details about utility.
    - `startTime: UFix64?`: Start time of the utility or when should utility will start. It's an optional value, therefore in case of `nil` startTime will be set to current block time by the smart-contract.
    - `endTime: UFix64?`: End time of the utility or when should the utility will end.
    - `collectionInfo: CollectionInfo`: It will be the collection information of the NFT contract.
    - `criteria: Criteria`: Criteria to claim that utility, like only specific address can claim that utility etc.


2.  `pub fun updateUtility(utility: Utility)` <br />
    It is a method which is called to update any given utility. Client only update his own created utilities. It require updated utility with given utility-id:

    - `utility: Utility`: Utility with updated values. 


3.  `pub fun removeUtility(utilityId: UInt64)` <br />
    It is a method which is called to remove any given utility. Client only remove his own created utilities. It require utility id that need to be removed:

    - `utilityId: UInt64`: Utility id that need to be removed. 


### Dapp

Dapp is the resource which is created by the Admin and used by the platform to protect the application from misuse from outside. This resource is need to claim utility. It has following methods: 

```
    pub resource Dapp {

        pub fun claimUtility(utilityId: UInt64, address: Address) 
    }

```

1.  `pub fun claimUtility(utilityId: UInt64, address: Address)` <br />
    It is a method which is used to claim the utility. This is a multi-sign method so it need sign from both entities dApp and end user to claim that utility. Only owner of NFT can claim the utility but this check is not availble on contract side as it will be implemented on frontend side. This method requires following parameters as arguments :

    - `utilityId: UInt64`: Utility id that need to be claimed.
    - `address: Address`: Address of the user who want to claim the utility.

    make sure this method must have user-sign as it will be recorded on the Ledger.


### Admin

Admin is the resource which is used by the contract owner or Admin to create dApp and client resources. It has following methods: 

```
    pub resource Admin { 
    
        pub fun createClientResource(): @Client 

        pub fun createDappResource(): @Dapp 

    }

```

1.  `pub fun createClientResource(): @Client` <br />
    This method will be used to create client resource for the client or brand Admin to perform utility functionlity.

2.  `pub fun createDappResource(): @Dapp` <br />
    This method will be used to create Dapp resource for the platfrom to protect applicatioin from the outsider.



### Public methods

All public methods that can be called to fetch data from smart-contract

1.  `pub fun isCapableToClaim(utilityId: UInt64, address: Address): Bool` <br />
    This method is used check if a user is capable to claim the utility. It checks if utility exists and active or not expired yet. Then if given address is fullfil all conditions that are given in utility criteria. It requires following attributes as parameters:

    - `utilityId: UInt64`: Utility id that need to be claimed.
    - `address: Address`: Address of the user who want to claim the utility.

    It will return `true` if user is capable otherwise `false`.

2.  `pub fun getAllUtilities():{UInt64: Utility}` <br />
    This method is used to fetch all utilities that are created within smart-contract. It does not include any utility that is removed by the client. It will return each utility against its id in form of key-pair value dictionary e.g: {utility-id: Utility}

3.  `pub fun getUtilityById(utilityId:UInt64): Utility?` <br />
    This method is used to fetch any specific utility with the help of utility-id. It will return given utility if found otherwise it will return nil.

4.  `pub fun getAllClaimedUtilities():{UInt64: {Address: UInt64}}` <br />
    This method is used to fetch all claimed utilities. It will return all utilities against address and number of claimed in form of key-pair value dictionary e.g: {utility-id: {user-address: count}}

5.  `pub fun getClaimedUtilityById(utilityId:UInt64):{Address: UInt64}?` <br />
    This method is used to fetch claim record of any specific utility with the help of it's utility-id. It will return given claim record utility in form of of key-pair value dictionary e.g: {user-address: count}, if found otherwise it will return nil.

6.  `pub fun getAllUserClaimedUtilities():{Address: {UInt64:UInt64}}` <br />
    This method is used to fetch all used based claimed utilities. It will return all user claimed utilities against utility and number of claimed in form of key-pair value dictionary e.g: {user-address: {utility-id: count}}

7.  `pub fun getUserAllClaimedUtilities(address: Address):{UInt64:UInt64}?` <br />
    This method is used to fetch claim record of any specific user with the help of it's flow address. It will return given claim record in form of of key-pair value dictionary e.g: {utility-id: count}, if found otherwise it will return nil.


### Global state

Global state are the attributes that defined under smart-contract scope and can be used under entire smart-contract. It will be used as smart-contract states. 

1.  `pub var lastIssuedUtilityId: UInt64` <br />
    It will represent last issued Utility id.

2.  `access(contract) var allUtilities : {UInt64: Utility}` <br />
    It will represent all utilities under the contract.

3.  `access(contract) var claimedUtilties : {UInt64: {Address: UInt64}}` <br />
    It will represent all claimed utilities against its utility-id and store user address against number of claimed.

4.  `access(contract) var claimedUtiltiesByAddress : {Address: {UInt64:UInt64}}` <br />
    It will represent all claimed utilities against its user-address and store utility-id against number of claimed. It will be used for user stats on backend/frontend side.     


### Events

The smart contract and its various resources will emit certain events that show when specific actions are taken, like any utility is claimed 

- `pub event ContractInitialized()`

  This event is emitted when `` contract is deployed.


- `pub event UtilityCreated(utilityId: UInt64, name: String, startTime: UFix64, endTime: UFix64?, userLimit: UInt64)`

  This event is emitted when any utility is created.
  `utilityId` is the utility-id which is created.
  `name` will be the name of the Utility.
  `startTime` will be start time of Utility.
  `endTime` will be the end time of Utility.
  `userLimit` will be the user limit of Utility.


- `pub event UtilityUpdated(utilityId: UInt64, name: String, startTime: UFix64, endTime: UFix64?, userLimit: UInt64)`

  This event is emitted when any utility is updated by the client.
  `utilityId` is the utility-id which is updated.
  `name` will be the name of the Utility.
  `startTime` will be start time of Utility.
  `endTime` will be the end time of Utility.
  `userLimit` will be the user limit of Utility.


- `pub event UtilityRemoved(utilityId: UInt64)`

  This event is emitted when any utility is removed by the client.
  `utilityId` is the utility-id which is removed.


- `pub event UitilityClaim (utilityId: UInt64, address: Address)`

  This event is emitted when any utility is claimed by the user.
  `utilityId` is the utility-id which is claimed.
  `address` will be the address of the user.

