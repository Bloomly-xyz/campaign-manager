const accountNames = {
  alice: "Alice",
  bob: "Bob",
  charlie: "Charlie",
  donald: "Donald",
  emma: "Emma",
  frank: "Frank",
  george: "George",
  harry: "Harry",
  ian: "Ian",
  john: "John",
  keanu: "Keanu",
  liza: "Liza",
  micheal: "Micheal",
  nicolas: "Nicolas",
  olivia: "Olivia",
  pamela: "Pamela",
  quinton: "Quinton",
  roman: "Roman",
  sam: "Sam",
  tom: "Tom",
  ursula: "Ursula",
  vin: "Vin",
  william: "William",
  xiumin: "Xiumin",
  yang: "Yang",
  zoe: "Zoe",
};


const contractNames = {
  nonFungibleToken: "NonFungibleToken",
  metadataViews: "MetadataViews"
};
const transactionEntities = {
  FungibleToken: "FungibleToken"
}
const transactions = {
  mintFT: `${transactionEntities.FungibleToken}/mint_ft`,
  transferFlow: `${transactionEntities.FungibleToken}/transfer_flow`,
};

const scriptEntities = {
  FungibleToken: "FungibleToken"
}

const scripts = {
  getUserBalance: `${scriptEntities.FungibleToken}/get_user_balance`,
};

const minBalance = 0.0001;
const testingTokenAmount = 100.0;

const flowConfig = {
  emulatorPort: 8080,
  gRPCServerPort: 3569,
  restAPIPort: 8888,
  basePath: "../../..",
  basePathContract: "../../"
};

const timeoutLimit = 100000;

const error_messages = {
  invalid_contract_name: "Invalid Contract Name",

}

let testNumber = 0

const getTestNumber = () => {
  testNumber++

  return testNumber
}


export {
  accountNames,
  contractNames,
  transactions,
  scripts,
  minBalance,
  testingTokenAmount,
  flowConfig,
  timeoutLimit,
  error_messages,
  getTestNumber
};
