import TopShot from "../../../contracts/TopShot.cdc"

// This transaction is how a Top Shot admin adds a created play to a set
// Parameters:
//
// setID: the ID of the set to which a created play is added
// playID: the ID of the play being added
transaction() {

    // Local variable for the topshot Admin object
    let adminRef: &TopShot.Admin
    let setID: UInt32
    let playID: UInt32

    prepare(acct: AuthAccount) {

        // borrow a reference to the Admin resource in storage
        self.adminRef = acct.borrow<&TopShot.Admin>(from: /storage/TopShotAdmin)
            ?? panic("Could not borrow a reference to the Admin resource")
        self.setID = 1
        self.playID = 1
    }

    execute {
        
        // Borrow a reference to the set to be added to
        let setRef = self.adminRef.borrowSet(setID: self.setID)

        // Add the specified play ID
        setRef.addPlay(playID: self.playID)
    }

    post {

        TopShot.getPlaysInSet(setID: self.setID)!.contains(self.playID): 
            "set does not contain playID"
    }
}
