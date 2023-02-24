import UtilityTracker from "../../contracts/UtilityTracker.cdc"

pub fun main(): {UInt64: UtilityTracker.Utility} {
    return  UtilityTracker.getAllUtilities() 
}