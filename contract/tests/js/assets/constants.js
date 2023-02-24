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
  metadataViews: "MetadataViews",
  utilityTracker: "UtilityTracker"
};
const transactionEntities = {
  UtilityTrackerClient: "UtilityTracker/Client",
  UtilityTrackerUser: "UtilityTracker/Dapp",
  UtilityTrackerAdmin: "UtilityTracker/Admin",
  FungibleToken: "FungibleToken"

}
const transactions = {
  setupDappResource: `${transactionEntities.UtilityTrackerAdmin}/setup_dapp_resource`,
  setupClientResource: `${transactionEntities.UtilityTrackerAdmin}/setup_client_resource`,
  createUtility: `${transactionEntities.UtilityTrackerClient}/create_utility`,
  updateUtility: `${transactionEntities.UtilityTrackerClient}/update_utility`,
  removeUtility: `${transactionEntities.UtilityTrackerClient}/remove_utility`,
  claimUtility: `${transactionEntities.UtilityTrackerUser}/claim_utility`,

  mintFT: `${transactionEntities.FungibleToken}/mint_ft`,
  transferFlow: `${transactionEntities.FungibleToken}/transfer_flow`,
};

const scriptEntities = {
  UtilityTracker: "UtilityTracker",
  FungibleToken: "FungibleToken"
}

const scripts = {
  getAllUtilities: `${scriptEntities.UtilityTracker}/get_all_utilities`,
  getUtilityById: `${scriptEntities.UtilityTracker}/get_utility_by_id`,
  getAllClaimedUtilities: `${scriptEntities.UtilityTracker}/get_all_claimed_utilities`,
  isUserCapable: `${scriptEntities.UtilityTracker}/is_user_capable`,
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

const utility_dapp = {
  utilityName: "First Utility",
  utilityDescription: "This is my first utility",
};

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
  utility_dapp,
  error_messages,
  getTestNumber
};
