import UtilityTracker from "../../../contracts/UtilityTracker.cdc"

transaction(
utilityId:UInt64
name: String, description: String, metaData: {String: AnyStruct}, startTime: UFix64, endTime: UFix64?, 
contractName: String, contractAddress:Address, storagePath: StoragePath, publicPath: PublicPath, 
userLimit: UInt64, nftIds:[UInt64], allowList:[Address], denylist:[Address], properties : {String: AnyStruct}, other : {String: AnyStruct}
) {

    prepare(client: AuthAccount){
        

        let cleintResource = client.borrow<& UtilityTracker.Client>(from: UtilityTracker.ClientStoragePath)
                            ?? panic("Could not borrow Client resource")


        let collectionInfo = UtilityTracker.CollectionInfo(contractName: contractName, contractAddress: contractAddress, storagePath:storagePath, publicPath:publicPath)
        // let collectionInfo = UtilityTracker.CollectionInfo(contractName: "Sham", contractAddress: 0x01, storagePath:/storage/Sham, publicPath:/public/ObjectPlayer)  //Only for testing purpose

        let criteria = UtilityTracker.Criteria(userLimit: userLimit, nftIds:nftIds, allowList:allowList, denylist:denylist, properties : properties, other : other)
        // let criteria = UtilityTracker.Criteria(userLimit: 2, nftIds:[], allowList:[], denylist:[], properties : {}, other : {})  //Only for testing purpose
        
        // let newUtility = UtilityTracker.Utility(id: utilityId, creator: client.address, name: "First Utility", description: "Its my utility", metaData: {}, startTime: 1676655656.0, endTime: 1676656706.0, collectionInfo: collectionInfo, criteria: criteria)  //Only for testing purpose
        let newUtility = UtilityTracker.Utility(id: utilityId, creator: client.address, name: name, description: description, metaData: metaData, startTime: startTime, endTime: endTime, collectionInfo: collectionInfo, criteria: criteria)

        cleintResource.updateUtility(utility: newUtility)
    }

}