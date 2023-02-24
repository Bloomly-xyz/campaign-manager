import UtilityTracker from "../../../contracts/UtilityTracker.cdc"

transaction {

    prepare(admin: AuthAccount, client: AuthAccount){
        
        let adminResource = admin.borrow<& UtilityTracker.Admin>(from: UtilityTracker.AdminStoragePath) 
                            ?? panic("could not borrow Admin resource")

        let cleintResource <- adminResource.createClientResource()

        client.save(<- cleintResource, to: UtilityTracker.ClientStoragePath)   
    }

}