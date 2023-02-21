import FungibleToken from  "../../contracts/FungibleToken.cdc"
import FlowToken from 0x0ae53cb6e3f42a79    

pub fun main(account:Address): UFix64 {
    let account = getAccount(account)
    let vaultCap = account.getCapability(/public/flowTokenBalance)
                            .borrow<&FlowToken.Vault{FungibleToken.Balance}>()
                            ??panic("could not borrow receiver reference ")

    return vaultCap.balance

}
 