import TopShot from "../../../contracts/TopShot.cdc"
import MetadataViews from "../../../contracts/MetadataViews"
import NonFungibleToken from "../../../contracts/NonFungibleToken"

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

    prepare(acct: AuthAccount, admin: AuthAccount) {
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