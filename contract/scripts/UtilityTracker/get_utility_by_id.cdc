import UtilityTracker from "../../contracts/UtilityTracker.cdc"

pub fun main(utilityId: UInt64): UtilityTracker.Utility? {
    return UtilityTracker.getUtilityById(utilityId: utilityId) 
}


