

const CreateUtility = () => `\
import NonFungibleToken from ${process.env.REACT_APP_NONFUNGIBLETOKEN}
import MetadataViews from ${process.env.REACT_APP_METADATAVIEWS}
import UtilityTracker from ${process.env.REACT_APP_UTILITYTRACKER}


// This transaction sets up an account to use Top Shot
// by storing an empty moment collection and creating
// a public capability for it
transaction ( name: String, description: String, metaData: {String: String}, startTime: UFix64, 
            endTime: UFix64?, contractName: String, contractAddress:Address, 
            userLimit: UInt64, nftIds:[UInt64], allowList:[Address], denylist:[Address], 
            properties : {String: String}, other : {String: String} )
{

    prepare(admin: AuthAccount,acct: AuthAccount) {

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


        let collectionInfo = UtilityTracker.CollectionInfo(contractName: contractName, contractAddress: contractAddress, storagePath:/storage/Sham, publicPath:/public/Sham)
        //let collectionInfo = UtilityTracker.CollectionInfo(contractName: "Sham", contractAddress: 0x01, storagePath:/storage/Sham, publicPath:/public/Sham)
        let criteria = UtilityTracker.Criteria(userLimit: userLimit, nftIds:nftIds, allowList:allowList, denylist:denylist, properties : properties, other : other)
        //let criteria = UtilityTracker.Criteria(userLimit: 2, nftIds:[], allowList:[], denylist:[], properties : {}, other : {})
        
        clientResource.createUtility(name: name, description: description, metaData: metaData, startTime: startTime, endTime: endTime, collectionInfo: collectionInfo, criteria: criteria)
        //cleintResource.createUtility(name: "First Utility", description: "Its my utility", metaData: {}, startTime: 1676658229.0, endTime: 1677658229.0, collectionInfo: collectionInfo, criteria: criteria)
    }
}`;

const ClaimUtility = () => `\
    `;
const ClaimUtilityDemo = () => `\
    `;
const MintDemo = () => `\
    import TopShot from ${process.env.REACT_APP_TOPSHOT}
    import NonFungibleToken from ${process.env.REACT_APP_NONFUNGIBLETOKEN}
    import MetadataViews from ${process.env.REACT_APP_METADATAVIEWS}
    
    // This transaction is what an admin would use to mint a single new moment
    // and deposit it in a user's collection
    // Parameters:
    //
    // setID: the ID of a set containing the target play
    // playID: the ID of a play from which a new moment is minted
    // recipientAddr: the Flow address of the account receiving the newly minted moment
    transaction(recipientAddr: Address) {
        // local variable for the admin reference
        let adminRef: &TopShot.Admin
        let setID: UInt32
        let playID: UInt32
    
        prepare( admin: AuthAccount,acct: AuthAccount) {
            // borrow a reference to the Admin resource in storage
            self.adminRef = admin.borrow<&TopShot.Admin>(from: /storage/TopShotAdmin)!
            self.setID = 1
            self.playID = 1
    
            // *************** Setup TopShot Collection Capability **************** //
            // First, check to see if a moment collection already exists
            if acct.borrow<&TopShot.Collection>(from: /storage/MomentCollection) == nil {
    
                // create a new TopShot Collection
                let collection <- TopShot.createEmptyCollection() as! @TopShot.Collection
    
                // Put the new Collection in storage
                acct.save(<-collection, to: /storage/MomentCollection)
    
                // create a public capability for the collection
                acct.link<&{NonFungibleToken.CollectionPublic, TopShot.MomentCollectionPublic, MetadataViews.ResolverCollection}>(/public/MomentCollection, target: /storage/MomentCollection)
            }
    
                   // Borrow a reference to the specified set
            let setRef = self.adminRef.borrowSet(setID: self.setID)
    
            // Mint a new NFT
            let moment1 <- setRef.mintMoment(playID: self.playID)
    
            // get the public account object for the recipient
            let recipient = getAccount(recipientAddr)
    
            // get the Collection reference for the receiver
            let receiverRef = recipient.getCapability(/public/MomentCollection).borrow<&{TopShot.MomentCollectionPublic}>()
                ?? panic("Cannot borrow a reference to the recipient's moment collection")
    
            // deposit the NFT in the receivers collection
            receiverRef.deposit(token: <-moment1)
    
        }
    }
    `;
const BlockChainScripts = {
    CreateUtility,
    ClaimUtility,
    ClaimUtilityDemo,
    MintDemo
}


export default BlockChainScripts