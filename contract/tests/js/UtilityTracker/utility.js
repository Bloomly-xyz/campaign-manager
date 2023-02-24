import path from "path";
import {
    init,
    getContractAddress,
    getTransactionCode,
    sendTransaction,
    getScriptCode,
    executeScript,
} from "flow-js-testing";
import { expect } from "@jest/globals";

import {
    contractNames,
    transactions,
    scripts,
    flowConfig,
    timeoutLimit,
} from "../assets/constants";

jest.setTimeout(timeoutLimit);

beforeEach(async () => {
    const basePath = path.resolve(__dirname, flowConfig.basePath);
    const port = flowConfig.emulatorPort;
    await init(basePath, { port });
});

const setupDappReource = async(admin, dapp, expectedErrorMessage) => {

    const setupDappResourceTrxName = transactions.setupDappResource;

    // Set transaction signers
    const signers = [admin, dapp];

    //generate addressMap from import statements
    const UtilityTracker = await getContractAddress(
        contractNames.utilityTracker,
        true
    );

    const addressMap = {
        UtilityTracker
    };

    const setupDappResourceTrx = await getTransactionCode({
        name: setupDappResourceTrxName,
        addressMap,
    });

    //Is code fetched
    expect(setupDappResourceTrx).not.toBeNull();


    //var args = [];

    const txResult = await sendTransaction({
        code: setupDappResourceTrx,
        signers,
       // args,
    });

    if (expectedErrorMessage) {
        //check if result instance is not null & expception is null
        expect(txResult[1]).not.toBeNull();
        expect(txResult[0]).toBeNull();

        expect(txResult[1].indexOf(expectedErrorMessage)).toBeGreaterThan(-1)

    } else {
        //check if result instance is not null & expception is null
        expect(txResult[0]).not.toBeNull();
        expect(txResult[1]).toBeNull();

        return;
    }

}

const setupClientReource = async(admin, client, expectedErrorMessage) => {

    const setupClientResourceTrxName = transactions.setupClientResource;

    // Set transaction signers
    const signers = [admin, client];

    //generate addressMap from import statements
    const UtilityTracker = await getContractAddress(
        contractNames.utilityTracker,
        true
    );

    const addressMap = {
        UtilityTracker
    };

    const setupClientResourceTrx = await getTransactionCode({
        name: setupClientResourceTrxName,
        addressMap,
    });

    //Is code fetched
    expect(setupClientResourceTrx).not.toBeNull();


    //var args = [];

    const txResult = await sendTransaction({
        code: setupClientResourceTrx,
        signers,
       // args,
    });

    if (expectedErrorMessage) {
        //check if result instance is not null & expception is null
        expect(txResult[1]).not.toBeNull();
        expect(txResult[0]).toBeNull();

        expect(txResult[1].indexOf(expectedErrorMessage)).toBeGreaterThan(-1)

    } else {
        //check if result instance is not null & expception is null
        expect(txResult[0]).not.toBeNull();
        expect(txResult[1]).toBeNull();

        return;
    }

}

const creataeUtility = async(
    utilityName, description, metaData, startTime, endTime, contractName, contractAddress, storagePath, publicPath, 
    userLimit, nftIds, allowList, denylist, properties, other, client, expectedErrorMessage) => {

    const createUtilityName = transactions.createUtility;

    // Set transaction signers
    const signers = [client];

    //generate addressMap from import statements
    const UtilityTracker = await getContractAddress(
        contractNames.utilityTracker,
        true
    );

    const addressMap = {
        UtilityTracker
    };

    const createUtilityTrx = await getTransactionCode({
        name: createUtilityName,
        addressMap,
    });

    //Is code fetched
    expect(createUtilityTrx).not.toBeNull();


    var args = [utilityName, description, metaData, startTime, endTime, contractName, contractAddress,
        //storagePath, publicPath, 
        userLimit, nftIds, allowList, denylist, properties, other];

    const txResult = await sendTransaction({
        code: createUtilityTrx,
        signers,
        args,
    });

    if (expectedErrorMessage) {
        //check if result instance is not null & expception is null
        expect(txResult[1]).not.toBeNull();
        expect(txResult[0]).toBeNull();

        expect(txResult[1].indexOf(expectedErrorMessage)).toBeGreaterThan(-1)

    } else {
        //check if result instance is not null & expception is null
        expect(txResult[0]).not.toBeNull();
        expect(txResult[1]).toBeNull();

        return;
    }

}

const updateUtility = async(
    utilityId, utilityName, description, metaData, startTime, endTime, contractName, contractAddress, storagePath, publicPath, 
    userLimit, nftIds, allowList, denylist, properties, other, client, expectedErrorMessage) => {

    const updateUtilityTrxName = transactions.updateUtility;

    // Set transaction signers
    const signers = [client];

    //generate addressMap from import statements
    const UtilityTracker = await getContractAddress(
        contractNames.utilityTracker,
        true
    );

    const addressMap = {
        UtilityTracker
    };

    const updateUtilityTrx = await getTransactionCode({
        name: updateUtilityTrxName,
        addressMap,
    });

    //Is code fetched
    expect(updateUtilityTrx).not.toBeNull();


    var args = [utilityId, utilityName, description, metaData, startTime, endTime, contractName, contractAddress, storagePath, publicPath, userLimit, nftIds, allowList, denylist, properties, other];

    const txResult = await sendTransaction({
        code: updateUtilityTrx,
        signers,
        args,
    });

    if (expectedErrorMessage) {
        //check if result instance is not null & expception is null
        expect(txResult[1]).not.toBeNull();
        expect(txResult[0]).toBeNull();

        expect(txResult[1].indexOf(expectedErrorMessage)).toBeGreaterThan(-1)

    } else {
        //check if result instance is not null & expception is null
        expect(txResult[0]).not.toBeNull();
        expect(txResult[1]).toBeNull();

        return;
    }

}

const removeUtility = async(utilityId, client, expectedErrorMessage) => {

    const removeUtilityTrxName = transactions.removeUtility;

    // Set transaction signers
    const signers = [client];

    //generate addressMap from import statements
    const UtilityTracker = await getContractAddress(
        contractNames.utilityTracker,
        true
    );

    const addressMap = {
        UtilityTracker
    };

    const removeUtilityTrx = await getTransactionCode({
        name: removeUtilityTrxName,
        addressMap,
    });

    //Is code fetched
    expect(removeUtilityTrx).not.toBeNull();


    var args = [utilityId];

    const txResult = await sendTransaction({
        code: removeUtilityTrx,
        signers,
        args,
    });

    if (expectedErrorMessage) {
        //check if result instance is not null & expception is null
        expect(txResult[1]).not.toBeNull();
        expect(txResult[0]).toBeNull();

        expect(txResult[1].indexOf(expectedErrorMessage)).toBeGreaterThan(-1)

    } else {
        //check if result instance is not null & expception is null
        expect(txResult[0]).not.toBeNull();
        expect(txResult[1]).toBeNull();

        return;
    }

}

const claimUtility = async(utilityId, dapp, user, expectedErrorMessage) => {

    const claimUtilityTrxName = transactions.claimUtility;

    // Set transaction signers
    const signers = [dapp, user];

    //generate addressMap from import statements
    const UtilityTracker = await getContractAddress(
        contractNames.utilityTracker,
        true
    );

    const addressMap = {
        UtilityTracker
    };

    const claimUtilityTrx = await getTransactionCode({
        name: claimUtilityTrxName,
        addressMap,
    });

    //Is code fetched
    expect(claimUtilityTrx).not.toBeNull();


    var args = [utilityId];

    const txResult = await sendTransaction({
        code: claimUtilityTrx,
        signers,
        args,
    });

    if (expectedErrorMessage) {
        //check if result instance is not null & expception is null
        expect(txResult[1]).not.toBeNull();
        expect(txResult[0]).toBeNull();

        expect(txResult[1].indexOf(expectedErrorMessage)).toBeGreaterThan(-1)

    } else {
        //check if result instance is not null & expception is null
        expect(txResult[0]).not.toBeNull();
        expect(txResult[1]).toBeNull();

        return;
    }

}

const getAllUtilites = async (expectedErrorMessage) => {
    const allUtilities = scripts.getAllUtilities;
  
    //generate addressMap from import statements
    const UtilityTracker = await getContractAddress(
        contractNames.utilityTracker,
        true
    );
  
    const addressMap = {
        UtilityTracker
    };
  
    const getAlUtilitiescript = await getScriptCode({
      name: allUtilities,
      addressMap,
    });
  
    const utilities = await executeScript({
      code: getAlUtilitiescript,
    });
  
    if (expectedErrorMessage) {
      //check if result is not null & expception is null
      expect(utilities[1]).not.toBeNull();
      expect(utilities[0]).toBeNull();
  
      expect(utilities[1].message.indexOf(expectedErrorMessage)).toBeGreaterThan(-1)
  
    } else {
      //check if result is not null & expception is null
      expect(utilities[0]).not.toBeNull();
      expect(utilities[1]).toBeNull();
  
      return utilities[0]
    }
  
  
  }
  

export {
    setupDappReource,
    setupClientReource,
    creataeUtility,
    updateUtility,
    removeUtility,
    claimUtility,
    getAllUtilites
  }
  