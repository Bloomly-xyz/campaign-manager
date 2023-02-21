import FungibleToken from  "../../contracts/FungibleToken.cdc"
import FlowToken from 0x0ae53cb6e3f42a79    

transaction(recipient: Address, amount:UFix64) {
    // recipient: Address, amount: UFix64
    let tokenAdmin: &FlowToken.Administrator
    let tokenReceiver: &{FungibleToken.Receiver}

    prepare(signer: AuthAccount) {
        self.tokenAdmin = signer
            .borrow<&FlowToken.Administrator>(from: /storage/flowTokenAdmin)
            ?? panic("Signer is not the token admin")

        self.tokenReceiver = getAccount(recipient)
            .getCapability(/public/flowTokenReceiver)
            .borrow<&{FungibleToken.Receiver}>()
            ?? panic("Unable to borrow receiver reference")
    }

    execute {
        let minter <- self.tokenAdmin.createNewMinter(allowedAmount: amount as UFix64)
        let mintedVault <- minter.mintTokens(amount: amount as UFix64)

        self.tokenReceiver.deposit(from: <-mintedVault)

        destroy minter
    }
}
