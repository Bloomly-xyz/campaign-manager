import UtilityTracker from "../../../contracts/UtilityTracker.cdc"

transaction {

    prepare(admin: AuthAccount, dapp; AuthAccount){

        let adminResource = admin.borrow<& UtilityTracker.Admin>(from: UtilityTracker.AdminStoragePath)
                            ?? panic("could not borrow admin resource")
        
        let dAppResource <- adminResource.createDappResource()

        dapp.save(<- dAppResource, to: UtilityTracker.DappStoragePath )


    }

}