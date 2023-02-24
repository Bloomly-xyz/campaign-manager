import NonFungibleToken from "../../contracts/NonFungibleToken.cdc"
import MetadataViews from "../../contracts/MetadataViews.cdc"
import UtilityTracker from "../../contracts/UtilityTracker.cdc"

// This transaction sets up an account to use Top Shot
// by storing an empty moment collection and creating
// a public capability for it
transaction ( name: String, description: String, metaData: {String: String}, startTime: UFix64, 
            endTime: UFix64?, contractName: String, contractAddress:Address, 
            storagePath: StoragePath, publicPath: PublicPath, 
            userLimit: UInt64, nftIds:[UInt64], allowList:[Address], denylist:[Address], 
            properties : {String: String}, other : {String: String} )
{

    prepare(acct: AuthAccount, admin: AuthAccount) {

        // *************** Setup Utility Tracker Client Capability ************* //

        if acct.borrow<&UtilityTracker.Client>(from: UtilityTracker.ClientStoragePath) == nil {
            let adminResource = admin.borrow<& UtilityTracker.Admin>(from: UtilityTracker.AdminStoragePath) 
            ?? panic("could not borrow Admin resource")

            let clientResource <- adminResource.createClientResource()

            acct.save(<- clientResource, to: UtilityTracker.ClientStoragePath)
        }

        // **************** Create Utility *********************************** //

        let clientResource = acct.borrow<& UtilityTracker.Client>(from: UtilityTracker.ClientStoragePath)
                            ?? panic("Could not borrow Client resource")


        let collectionInfo = UtilityTracker.CollectionInfo(contractName: contractName, contractAddress: contractAddress, storagePath:storagePath, publicPath:publicPath)
        //let collectionInfo = UtilityTracker.CollectionInfo(contractName: "Sham", contractAddress: 0x01, storagePath:/storage/Sham, publicPath:/public/ObjectPlayer) //Only for testing purpose

        let criteria = UtilityTracker.Criteria(userLimit: userLimit, nftIds:nftIds, allowList:allowList, denylist:denylist, properties : properties, other : other)
        //let criteria = UtilityTracker.Criteria(userLimit: 2, nftIds:[], allowList:[], denylist:[], properties : {}, other : {})  //Only for testing purpose
        
        clientResource.createUtility(name: name, description: description, metaData: metaData, startTime: startTime, endTime: endTime, collectionInfo: collectionInfo, criteria: criteria)
        //cleintResource.createUtility(name: "First Utility", description: "Its my utility", metaData: {}, startTime: 1676658229.0, endTime: 1677658229.0, collectionInfo: collectionInfo, criteria: criteria)  //Only for testing purpose

    }
}