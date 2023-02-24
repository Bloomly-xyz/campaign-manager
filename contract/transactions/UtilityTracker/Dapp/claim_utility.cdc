import UtilityTracker from "../../../contracts/UtilityTracker.cdc"
import NonFungibleToken from "../../../contracts/NonFungibleToken.cdc"

transaction(utilityId:UInt64, collectionPublicPath: PublicPath){

    let nfts: [UInt62]
    let userAddress: Address
    let dAppResource: &UtilityTracker.Dapp

    prepare(dapp:AuthAccount, user:AuthAccount){

        self.userAddress = user.address

        let collectionRef = user.getCapability(collectionPublicPath)
                            .borrow<&{NonFungibleToken.CollectionPublic}>()
                            ?? panic("Could not borrow capability from public collection at specified path")

        self.nfts = collectionRef.getIDs()

        self.dAppResource = dapp.borrow<& UtilityTracker.Dapp>(from: UtilityTracker.DappStoragePath)
                            ?? panic("could not borrow Dapp resource")
    }
    pre{
        self.nfts.length > 0 : "User does not own this nft"
    }
    execute {
        self.dAppResource.claimUtility(utilityId: utilityId, address: self.userAddress)
    }
}