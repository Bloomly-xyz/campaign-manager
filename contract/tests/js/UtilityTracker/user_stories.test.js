import path from "path";
import {
    init,
    emulator,
    getAccountAddress,
    mintFlow,
} from "flow-js-testing";
import { expect } from "@jest/globals";

import {
    accountNames,
    flowConfig,
    timeoutLimit,
    bloomly_dapp,
    error_messages,
    getTestNumber,
} from "../assets/constants";

import {
    setupDappReource,
    setupClientReource,
    creataeUtility,
    updateUtility,
    removeUtility,
    claimUtility,
    getAllUtilites,
} from './utility'


jest.setTimeout(timeoutLimit);

beforeAll(async () => {
    const basePath = path.resolve(__dirname, flowConfig.basePath);
    const port = flowConfig.emulatorPort;
    await init(basePath, { port });
    await emulator.start()

});

describe("Admin", () => {
  
    test(`T#${getTestNumber()}: Setup Dapp Resource `, async () => {
        const admin = await getAccountAddress(accountNames.bob);

        const dapp = await getAccountAddress(accountNames.charlie);

        await setupDappReource(admin, dapp);

        //Need to check if resource is created or not

    });

    test(`T#${getTestNumber()}: Setup Client Resource `, async () => {
        const admin = await getAccountAddress(accountNames.bob);

        const client = await getAccountAddress(accountNames.donald);

        await setupClientReource(admin, client);

        //Need to check if resource is created or not

    });

    test(`T#${getTestNumber()}: Create Utility `, async () => {
        const client = await getAccountAddress(accountNames.donald);

        let utilityName = "First Utility"
        let description = "Its my first utility"
        let metaData = { "name": "ObjectPlayer" }
        let startTime = (Date.now() /1000) + 50;
        let endTime =  (Date.now() /1000) +  100000;
        let contractName = "ObjectPlayer"
        let contractAddress = "0x01"
        let storagePath = "/storage/ShamGir"
        let publicPath = "/public/ShamGir"
        let userLimit = 1
        let nftIds = []
        let allowList = []
        let denylist = []
        let properties = {}
        let other = {}
        
        await creataeUtility (utilityName, description, metaData, startTime, endTime, contractName, contractAddress, storagePath, publicPath, 
            userLimit, nftIds, allowList, denylist, properties, other, client );

        //Need to check if utility is created or not

    });


    test(`T#: Claim Utility `, async () => {
        const dapp = await getAccountAddress(accountNames.charlie);
        const user = await getAccountAddress(accountNames.emma);

        let utilityId = 1

        const amount = "10.0";
        const [mintResult, error] = await mintFlow(dapp, amount);

        await claimUtility (utilityId, dapp, user);

        //Need to check if utility is created or not

    });

})