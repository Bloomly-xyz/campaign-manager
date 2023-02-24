import UtilityTracker from "../../../contracts/UtilityTracker.cdc"

transaction(utilityId:UInt64) {

    prepare(client:AuthAccount){
    
        let clientResource = client.borrow<& UtilityTracker.Client>(from: UtilityTracker.ClientStoragePath)
                                ?? panic("could not borrow Client resource")
        
        clientResource.removeUtility(utilityId: utilityId)
    }
}