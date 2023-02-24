import UtilityTracker from "../../contracts/UtilityTracker.cdc"

pub fun main(): {UInt64: {Address: UInt64}} {


    let allUtilities =  UtilityTracker.getAllClaimedUtilities()

    return allUtilities

}