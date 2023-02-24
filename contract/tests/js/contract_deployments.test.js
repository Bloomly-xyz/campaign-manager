import path from "path";
import {
  init,
  emulator,
  getAccountAddress,
  deployContractByName,
  getContractAddress,
} from "flow-js-testing";
import { expect } from "@jest/globals";

import {
  accountNames,
  contractNames,
  flowConfig,
  timeoutLimit,
  getTestNumber
} from "./assets/constants";

jest.setTimeout(timeoutLimit);

beforeAll(async () => {
  const port = flowConfig.emulatorPort;
  //  await emulator.start(port);
});

afterAll(async () => {
  const port = flowConfig.emulatorPort;
  //  await emulator.stop(port);
});

beforeEach(async () => {
  const basePath = path.resolve(__dirname, flowConfig.basePathContract);
  const port = flowConfig.emulatorPort;
  await init(basePath, { port });
});

let testNumber = 1;

describe("Contract deployments", () => {
  test(`T#${getTestNumber()}: Non-Fungible-Token-Contract Deployment`, async () => {
    const contractName = contractNames.nonFungibleToken;
    const Alice = await getAccountAddress(accountNames.alice);
    let update = true;

    //deploying contract to Alice accouont
    let result = await deployContractByName({
      name: contractName,
      to: Alice,
      update,
    });

    //check if result instance is not null & expception is null
    expect(result[0]).not.toBeNull();
    expect(result[1]).toBeNull();

    //fetch contract address
    let contractAddress = await getContractAddress(contractName);

    expect(contractAddress).toEqual(Alice);

    testNumber++

  });

  test(`T#${getTestNumber()}: MetadataViews-Contract Deployment`, async () => {
    const contractName = contractNames.metadataViews;
    const Alice = await getAccountAddress(accountNames.alice);
    let update = true;

    //fetching all dependent contract address
    const NonFungibleToken = await getContractAddress(
      contractNames.nonFungibleToken
    );

    const FungibleToken = await getContractAddress(
      contractNames.fungibleToken
    );

    const addressMap = {
      NonFungibleToken,
      FungibleToken
    };

    //deploying contract to Alice accouont
    let result = await deployContractByName({
      name: contractName,
      to: Alice,
      update,
      addressMap
    });

    //check if result instance is not null & expception is null
    expect(result[0]).not.toBeNull();
    expect(result[1]).toBeNull();

    //fetch contract address
    let contractAddress = await getContractAddress(contractName);

    expect(contractAddress).toEqual(Alice);
  });

  test(`T#${getTestNumber()}: UtilityTracker Contract Deployment`, async () => {
    const contractName = contractNames.utilityTracker;
    const Bob = await getAccountAddress(accountNames.bob);
    let update = true;

    const NonFungibleToken = await getContractAddress(
      contractNames.nonFungibleToken
    );

    const MetadataViews = await getContractAddress(
      contractNames.metadataViews
    );

    const addressMap = {
      NonFungibleToken,
      MetadataViews
    };

    //deploying contract to Bob accouont
    let result = await deployContractByName({
      name: contractName,
      to: Bob,
      update,
      addressMap,
    });

    //check if result instance is not null & expception is null
    expect(result[0]).not.toBeNull();
    expect(result[1]).toBeNull();

    //fetch contract address
    let contractAddress = await getContractAddress(contractName);

    expect(contractAddress).toEqual(Bob);
  });


});
