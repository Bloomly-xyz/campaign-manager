import * as fcl from "@onflow/fcl";
import * as t from "@onflow/types";
import BlockChainScripts from "./BlockChainScripts";
import { serverAuthorization } from "./MultiSignature";
let transactionStatus = {
    error: false,
    message: "",
};
const transactionError = (ex) => {
    transactionStatus.error = true;
    transactionStatus.message = ex ?? "BlockChain Execution failed";
    return transactionStatus;
}
const execute_BlockChain_Scripts = async (response) => {
    try {
        const resp = await fcl.decode(response);
        transactionStatus.error = false;
        transactionStatus.message = resp;
        return transactionStatus;
    } catch (ex) {
        return transactionError(ex);
    }
};
const execTransactionMethod = async (transactionId) => {
    try {
        const transaction = await fcl.tx(transactionId).onceSealed();
        if (
            (transaction?.status === 4 || transaction?.status === 3) &&
            transaction?.errorMessage
        ) {
            transactionStatus.error = true;
            transactionStatus.message = transaction?.errorMessage;
            return transactionStatus;
        }
        if (
            (transaction?.status === 4 || transaction?.status === 3) &&
            transaction?.events[0]?.data
        ) {
            transactionStatus.error = false;
            let resp = { txId: transactionId, data: transaction?.events[0]?.data }
            transactionStatus.message = resp;
            return transactionStatus;
        }
    } catch (error) {
        return transactionError(error);
    }
};
const getAccount = async (address) => {
    try {
        const account = await fcl.send([fcl.getAccount(address)]).then(fcl.decode);
        transactionStatus.error = false;
        transactionStatus.message = account;
        return transactionStatus;
    }
    catch (e) {
        return transactionError(e);
    }
};
const createUtilityTx =async (utilityObj) => {
    try {
        const tx = await fcl.send([
            fcl.transaction(BlockChainScripts.CreateUtility),
            fcl.args([
              fcl.arg(utilityObj?.campaignName, t.String),
              fcl.arg(utilityObj?.campaignDescription, t.String),
            
              fcl.arg([{key:"",value:""}],
                t.Dictionary({ key: t.String, value: t.String })),
                fcl.arg(utilityObj?.startDateUnix,t.UFix64),
                fcl.arg(utilityObj?.endDateUnix,t.UFix64),

                fcl.arg(utilityObj?.contractName, t.String),
              fcl.arg(utilityObj?.contractAddress, t.Address),
              fcl.arg(1, t.UInt64),
              fcl.arg([],t.Array(t.UInt64)),
              fcl.arg([],t.Array(t.Address)),
              fcl.arg([], t.Array(t.Address)),
              fcl.arg([{key:"",value:""}],
                t.Dictionary({ key: t.String, value: t.String })),
                fcl.arg([{key:"",value:""}],
                    t.Dictionary({ key: t.String, value: t.String })),
            ]),
            fcl.proposer(fcl.currentUser().authorization),
            fcl.payer(fcl.currentUser().authorization),
            //fcl.ref(block.id),
            fcl.limit(9999),
            fcl.authorizations([
                serverAuthorization,
              fcl.currentUser().authorization
            ])
          ]);
          const { transactionId } = tx;
          const result = await execTransactionMethod(transactionId);
          return result;
    }
    catch (e) {
    debugger;
        return transactionError(e);
    }
}
const mintNFTTx = async(address) => {
    try {
        const tx = await fcl.send([
            fcl.transaction(BlockChainScripts.MintDemo),
            fcl.args([
              fcl.arg(address, t.Address),
            ]),
            fcl.proposer(fcl.currentUser().authorization),
            fcl.payer(fcl.currentUser().authorization),
            fcl.limit(9999),
            fcl.authorizations([
                serverAuthorization,
              fcl.currentUser().authorization
            ])
          ]);
          const { transactionId } = tx;
          const result = await execTransactionMethod(transactionId);
          return result;
    }
    catch (e) {
        return transactionError(e);
    }
}
const claimUtilityTx = () => {
    try {

    }
    catch (e) {
        return transactionError(e);
    }
}
const claimUtilityDemoTx = () => {
    try {

    }
    catch (e) {
        return transactionError(e);
    }
}
const BlockChainTx = {
    execTransactionMethod,
    getAccount,
    createUtilityTx,
    mintNFTTx,
    claimUtilityTx,
    claimUtilityDemoTx
}

export default BlockChainTx