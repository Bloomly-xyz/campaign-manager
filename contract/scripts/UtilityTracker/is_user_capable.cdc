import UtilityTracker from "../../contracts/UtilityTracker.cdc"

pub fun main(utilityId:UInt64, address:Address): Bool {

    return UtilityTracker.isCapableToClaim(utilityId: utilityId, address: address)
}
