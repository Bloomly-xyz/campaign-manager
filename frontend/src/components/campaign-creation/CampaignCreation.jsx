import moment from "moment/moment";
import React, { useEffect, useRef, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate } from "react-router";
import BlockChainTx from "../../BlockChainTx/BlockChainTx";
import ThirdPartyHook from "../../cutome-Hooks/third-party-hook/ThirdPartyHook";
import { setLoader } from "../../redux/slices/loading/loaderSlice";
import campaignService from "../../services/campaign.service";
import utilityService from "../../services/utility.service";

import Header from "../common/ui-components/Header";
import Stepper from "../common/ui-components/Stepper";
import AttachUtility from "./CampaignCreateComponents/AttachUtility";
import PhysicalUtilityForm from "./CampaignCreateComponents/AttachUtilityComponents/PhysicalUtilityForm";
import CommunityTargeting from "./CampaignCreateComponents/CommunityTargeting";
import Confirmation from "./CampaignCreateComponents/Confirmation";
import SelectContract from "./CampaignCreateComponents/SelectContract";
import Toast from "../../helpers/toast-component/Toast"
import PathExtractor from "../../helpers/PathExtractor";
import Modal from "../common/modal-layout/Modal";
import CopylinkModal from "../modals-components/CopylinkModal";
import MintNftModal from "../modals-components/MintNftModal";



const CampaignCreation = () => {
  //Navigation hook
  const navigate = useNavigate();
  // redux adminInfo 
  const { adminInfo } = useSelector((state) => state.user);

  // redux dispatcher
  const dispatch = useDispatch();

  /** Steps State For maintaining journey of steps */
  const [activeStep, setActiveStep] = useState(1);
  const [steps, setSteps] = useState([
    { title: "Select Contract", value: 1, IsCompleted: false },
    { title: "Community Targeting", value: 2, IsCompleted: false },
    { title: "Attach Utility", value: 3, IsCompleted: false },
    { title: "Confirmation", value: 4, IsCompleted: false },
  ]);

  /** Step 1 Hooks Init */
  const [nftContractData, setNFTContractData] = useState({
    contractAddress: "",
    contractName: "",
    contractStoragePath: "",
    collectionPublicPath: "",
    campaignUuid: "",
    userId: "",
    campaignJson: "",
    stepsEnum: "",
    campaignName: "",
    campaignDescription: "",
    campaignStartDate: "",
    campaignEndDate: "",
    campaignUtilities: [{ utilityId: 0, campaignUtilityJson: "" }],
    campaignPublicUrl: "",
    isDemoCollection: false
  });
  const [contractListing, setSelectContractListing] = useState([])
  const [selectContract, setSelectContract] = useState(1);
  const [showErr, setShowErr] = useState(false);
  /** End Step 1 Hooks */

  /// Step 2 state
  const [selectCollection, setSelectCollection] = useState(1);

  //// Step 3,4 State
  const [utilitiesListing, setUtilitiesListing] = useState([]);
  const [filterData, setFilterData] = useState(utilitiesListing);
  const [selectedUtility, setSelectedUtility] = useState();
  const [openUtilityForm, setOpenUtilityForm] = useState(false);

  const [campaignCreationData, setCampaignCreationData] = useState({
    selectContract: {},
    communityTarget: {},
    AttachUtility: {
      PhysicalUtilityData: {},

    },
  });
  ///modal states
  const [openAlertModal, setOpenAlertModal] = useState(false)
  const [openNftMintModal, setOpenNftMintModal] = useState(false)

  const mintStatusRef = useRef()
  const [file, setFile] = useState("");
  //// state to store countries data populated on step 3
  const [countryData, setCountryData] = useState([]);

  /** React useEffect  */
  useEffect(() => {
    populateCountriesData();
    fetchUtilities();
  }, []);


  /** Event Handlers Start*/
  const handleChangeContract = (value) => {
    setNFTContractData(prevState => ({
      ...prevState,
      contractName: value?.contractName,
      contractAddress: value?.NFTAddress,
      contractStoragePath: value?.storagePaths?.[0] ?? "",
      collectionPublicPath: value?.collectionPaths?.[0] ?? ""
    }));
    setSelectContract(value?.contractId);
  };
  const handleChangeCollection = (value) => {
    let obj = {
      CommunityTargeting: "FullCollection"
    }
    setNFTContractData(prevState => ({
      ...prevState,
      campaignJson: JSON.stringify(obj)
    }))
    setSelectCollection(value);
  };
  const NFTAddressSearchHandler = async (e) => {
    const { extractContractPath } = PathExtractor();
    const NFTAddress = e?.target?.value?.trim() ?? e;
    setNFTContractData(prevState => ({
      ...prevState,
      contractAddress: NFTAddress,
    }));
    if ((NFTAddress?.includes("0x") && NFTAddress?.length === 18) || (!NFTAddress?.includes("0x") && NFTAddress?.length === 16)) {
      const accountReslt = await BlockChainTx.getAccount(NFTAddress);
      if (!accountReslt?.error && accountReslt?.message) {
        const contractValues = Object.entries(accountReslt?.message?.contracts);
        let contractPathsTemp = contractValues.map((reslt, i) => {
          if (reslt?.[1].match(/contract.*?(?=NonFungibleToken)/gm)?.length > 0) {
            //find  paths 
            const publicPaths = extractContractPath("public", reslt?.[1]);
            const storagePaths = extractContractPath("storage", reslt?.[1])
            return { contractName: reslt?.[0], NFTAddress: NFTAddress, collectionPaths: publicPaths, storagePaths: storagePaths }
          }
        });
        contractPathsTemp = contractPathsTemp?.filter(item => item);
        contractPathsTemp = contractPathsTemp?.map((data, i) => {
          return { ...data, contractId: i + 1 }
        });
        setNFTContractData(prevState => ({
          ...prevState,
          contractName: contractPathsTemp?.[0]?.contractName,
          contractStoragePath: contractPathsTemp?.[0]?.storagePaths?.[0] ?? "",
          collectionPublicPath: contractPathsTemp?.[0]?.collectionPaths?.[0] ?? ""
        }));
        setSelectContractListing(contractPathsTemp);
      }
    }
    else {
      setNFTContractData(prevState => ({
        ...prevState,
        contractAddress: "",
        contractName: "",
        contractStoragePath: "",
        collectionPublicPath: ""
      }));
      setSelectContractListing([])
    }
  }
  const nextBtnClickHandler = async (stepEnum, formData) => {
    dispatch(setLoader(true));
    let campaignObj = {
      contractAddress: nftContractData?.contractAddress,
      contractName: nftContractData?.contractName,
      contractStoragePath: nftContractData?.contractStoragePath,
      collectionPublicPath: nftContractData?.collectionPublicPath,
      userId: adminInfo?.id,
      stepsEnum: stepEnum,
      campaignUuid: nftContractData?.campaignUuid ?? null,
      campaignJson: nftContractData?.campaignJson,


    }

    if (stepEnum === 2) {
      campaignObj.campaignJson = nftContractData?.campaignJson
    }
    else if (stepEnum === 3) {
      var now = moment();
      let startDate = moment().add(10, "minutes").toISOString();
      let endDate = moment(formData?.expirydate).set({
        'hour': now.hour(),
        'minute': now.minute(),
        'second': now.second()
      }).toISOString()
      setNFTContractData(prevState => ({
        ...prevState,
        campaignName: formData?.name,
        campaignDescription: formData?.description,
        campaignStartDate: startDate,
        campaignEndDate: endDate

      }));
      campaignObj.campaignName = formData?.name;
      campaignObj.campaignDescription = formData?.description;
      campaignObj.CampaignStartDate = startDate;
      campaignObj.CampaignEndDate = endDate;
      campaignObj.campaignUtilities = [{ utilityId: selectedUtility?.value, campaignUtilityJson: JSON.stringify(formData) }]

    }
    else if (stepEnum === 4) {

      campaignObj.CampaignPublicUrl = `${window.location.origin}/claim-utility/${nftContractData?.campaignUuid}`;
      const campaignResp = await createCampaignOnBC(nftContractData);
      campaignObj.blockChainTransactionId = campaignResp?.txId;
      let bc_Jsn = JSON.stringify({ isDemo: nftContractData?.isDemoCollection, utilityTx: campaignResp, mintingTx: mintStatusRef.current })
      campaignObj.blockChainJson = bc_Jsn;
      campaignObj.isActive = campaignResp?.txId ? true : false
      //in future we will give option for retry baced on txid null condition
    }
    campaignService.createCampaign(campaignObj).then((result) => {
      dispatch(setLoader(false))

      if (result?.statusCode === 200 && result?.payload?.campaignUuid) {
        setNFTContractData(prevState => ({
          ...prevState,
          campaignUuid: result?.payload?.campaignUuid,
        }));
        if (stepEnum !== 4) {
          setActiveStep(stepEnum + 1)
          setSteps(steps.map((step, index) =>
            step.value === stepEnum ? { ...step, IsCompleted: true } : step
          ));
        }
        else {
          setOpenAlertModal(true);
          Toast("Campaign Created Successfully", 'success')
          // navigate("/nft-campaigns")
        }
      }
    }).catch((error) => {
      dispatch(setLoader(false))
      Toast("Error While Creating Campaign", 'error')
    })
  }
  const createCampaignOnBC = async (campaignObj) => {
    campaignObj.startDateUnix = moment(campaignObj?.campaignStartDate).unix() + ".0"
    campaignObj.endDateUnix = moment(campaignObj?.campaignEndDate).unix() + ".0"
    const createUtilityOnBC = await BlockChainTx?.createUtilityTx(campaignObj)
    if (!createUtilityOnBC?.error && createUtilityOnBC?.message) {
      return createUtilityOnBC?.message;

    }
    else {
      return null;
    }
  }

  const mintCollectionHandler = async () => {
    dispatch(setLoader(true));
    setOpenNftMintModal(false);
    const mintStatus = await BlockChainTx?.mintNFTTx(adminInfo?.walletAddress);
    dispatch(setLoader(false));
    if (mintStatus?.error) {
      mintStatusRef.current = null;
      setOpenNftMintModal(false);
      Toast("Error While Minting NFT", 'error')
    }
    else {
      mintStatusRef.current = mintStatus?.message?.txId;
      setOpenNftMintModal(false);
      nextBtnClickHandler(1);
    }
  }
  const inputPathHandler = (e, pathName) => {
    let value = e.target.value;
    if (pathName === "storagePath") {
      setNFTContractData(prevState => ({
        ...prevState,
        contractStoragePath: value,
      }));
    }
    if (pathName === "collectionPath") {
      setNFTContractData(prevState => ({
        ...prevState,
        collectionPublicPath: value,
      }));
    }
  }
  /** Event Handlers End*/



  /** Methods to fetch data on load  */
  const populateCountriesData = async () => {
    const { getCountriesData } = ThirdPartyHook();
    const countriesData = await getCountriesData();

    if (countriesData.length > 0) {
      setCountryData(countriesData);
    } else {
      setCountryData([]);
    }
  };
  const fetchUtilities = () => {
    utilityService.get_utilities().then((resp) => {
      if (resp?.payload) {
        setUtilitiesListing(resp?.payload);
        setFilterData(resp?.payload)
      }
    }).catch((error) => {

    })
  }
  /** End for section Onload data fetch. */
  return (
    <>
      <Header title="Campaign Creation" />
      <Stepper steps={steps} activeStep={activeStep} />

      {activeStep === 1 && (
        <SelectContract
          selectContract={selectContract}
          handleChangeContract={handleChangeContract}
          setSteps={setSteps}
          steps={steps}
          setActiveStep={setActiveStep}
          contractListing={contractListing}
          NFTAddressSearchHandler={NFTAddressSearchHandler}
          setShowErr={setShowErr}
          showErr={showErr}
          nftContractData={nftContractData}
          setNFTContractData={setNFTContractData}
          inputPathHandler={inputPathHandler}
          nextBtnClickHandler={nextBtnClickHandler}
          setOpenNftMintModal={setOpenNftMintModal}
        />
      )}
      {activeStep === 2 && (
        <CommunityTargeting
          setSteps={setSteps}
          steps={steps}
          setActiveStep={setActiveStep}
          selectCollection={selectCollection}
          handleChangeCollection={handleChangeCollection}
          nextBtnClickHandler={nextBtnClickHandler}
          setNFTContractData={setNFTContractData}
          isDemo={nftContractData?.isDemoCollection}
        />
      )}
      {activeStep === 3 && (
        <>
          {openUtilityForm ? (
            <PhysicalUtilityForm
              setOpenUtilityForm={setOpenUtilityForm}
              countryData={countryData}
              setActiveStep={setActiveStep}
              setSteps={setSteps}
              steps={steps}
              campaignCreationData={campaignCreationData}
              setCampaignCreationData={setCampaignCreationData}
              setFile={setFile}
              file={file}
              nextBtnClickHandler={nextBtnClickHandler}
              dispatch={dispatch}
            />
          ) : (
            <AttachUtility
              setOpenUtilityForm={setOpenUtilityForm}
              setSelectedUtility={setSelectedUtility}
              selectedUtility={selectedUtility}
              setActiveStep={setActiveStep}
              utilitiesListing={utilitiesListing}
              setUtilitiesListing={setUtilitiesListing}
              filterData={filterData}
            />
          )}
        </>
      )}
      {activeStep === 4 && <Confirmation file={file} setOpenUtilityForm={setOpenUtilityForm} setActiveStep={setActiveStep} campaignCreationData={campaignCreationData} nftContractData={nftContractData} nextBtnClickHandler={nextBtnClickHandler} />}
      {openAlertModal && <Modal
        openModal={openAlertModal}
        closeModal={setOpenAlertModal}
        children={
          <CopylinkModal
            setOpenModal={setOpenAlertModal}
            claimLink={`${window.location.origin}/claim-utility/${nftContractData?.campaignUuid}`}
          />
        }
        modal_Id="claim-utility-modal"
        mwidth={"532px"}
      />}
      {openNftMintModal && (
        <Modal
          openModal={openNftMintModal}
          closeModal={setOpenNftMintModal}
          children={
            <MintNftModal
              setOpenModal={setOpenNftMintModal}
              mintCollectionHandler={mintCollectionHandler}
            />
          }
          modal_Id="claim-utility-modal"
          mwidth={"614px"}

        />
      )}
    </>
  );
};

export default CampaignCreation;
