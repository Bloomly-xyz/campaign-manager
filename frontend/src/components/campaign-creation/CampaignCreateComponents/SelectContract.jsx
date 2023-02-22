import React, { Fragment } from "react";
import images from "../../../constants/images-constants/images";
import campaignService from "../../../services/campaign.service";
import CustomCheckbox from "../../common/ui-components/form-ui/CustomCheckbox";

const SelectContract = (props) => {
  const { selectContract, handleChangeContract, setSteps, steps, setActiveStep, contractListing,
    NFTAddressSearchHandler, showErr, setShowErr, setNFTContractData, nftContractData, inputPathHandler,
    nextBtnClickHandler,setOpenNftMintModal } = props;
  const handleBack = () => {
    setActiveStep(1)
  }

  const pathClickHandler = (path,pathName) => {
    if(pathName==='storagePath')
    setNFTContractData(prevState => ({
      ...prevState,
      contractStoragePath: path,
      
    }));
    else
    setNFTContractData(prevState => ({
      ...prevState,
      collectionPublicPath: path
    }));
  }
  const demoClickHandler=()=>{
    setNFTContractData(prevState => ({
      ...prevState,
      contractAddress: process.env.REACT_APP_NBATOPSHOT_ADDRESS,
      isDemoCollection:true
    }));
    NFTAddressSearchHandler(process.env.REACT_APP_NBATOPSHOT_ADDRESS)
  }
  const populateStoragePath = (pathName) => {
    return contractListing?.length > 0 && contractListing?.map((data, i) => {
      if (data?.contractName === nftContractData?.contractName) {
        return (
          <Fragment key={`${pathName}_${i}`}>
            {pathName === "storagePath" && data?.storagePaths?.map((reslt,i) => {
              return (<span onClick={() => pathClickHandler(reslt,"storagePath")} className={`px-1 py-[2px] font-extrabold rounded-full mr-2 ${reslt===nftContractData?.contractStoragePath ? "text-white bg-[#213E28]" : "text-[#12221A] bg-[#F3F4F4]"} ${pathName === "storagePath" && data?.storagePaths?.length === 0 ? "hidden" : ""} ${pathName === "collectionPath" && data?.collectionPaths?.length === 0 ? "hidden" : ""} ${nftContractData?.isDemoCollection ? 'pointer-events-none' : ""}`}>
                {reslt}
              </span>
              )
            })}
             {pathName === "collectionPath" && data?.collectionPaths?.map((reslt,i) => {
              return (<span onClick={() => pathClickHandler(reslt,"collectionPath")} className={`px-1 py-[2px] font-extrabold rounded-full mr-2 ${reslt===nftContractData?.collectionPublicPath ? "text-white bg-[#213E28]" : "text-[#12221A] bg-[#F3F4F4]"} ${pathName === "storagePath" && data?.storagePaths?.length === 0 ? "hidden" : ""} ${pathName === "collectionPath" && data?.collectionPaths?.length === 0 ? "hidden" : ""} ${nftContractData?.isDemoCollection ? 'pointer-events-none' : ""}`}>
                {reslt}
              </span>
              )
            })}

          </Fragment>
        )
      }
    })
  }
  return (
    <>
      <div className="p-6 bg-white rounded-3xl">
        <div className="grid grid-cols-2 gap-4 ">
          <div className="max-w-[526px] ">
            <h3 className="text-[#12221A] text-2xl font-extrabold mb-3">
              Select NFT Contract
            </h3>
            <p className="text-[#12221A]/70 text-xs font-medium mb-6">
            This tool will assist you in attaching a utility to your NFT collection. 
            You may add your contract address in the text field. Once the contract address has been added, 
            a list of available NFT contracts will be presented below
              <br />
              <br /> For demo purposes, we have cloned the NBA Topshot contract as you may not have a collection at your end to review the product.
               In order to receive the NFT in your wallet, you may click on <button className="bg-[#213E28] text-white border rounded py-[2px] px-[1px] mx-1" onClick={() => demoClickHandler()}>NBA Top Shot contract</button>   
                  which will autofill the fields accordingly. You may also test this product with your own Flow NFT contract address
            </p>
            <div className="bg-[#F3F4F4] p-4 rounded-xl mb-6">
              <p className="text-[#12221A]/70 text-xs font-medium">
                Enter Address containing your NFT contract
              </p>
              <div className="flex border-t-0 border-r-0 border-l-0 border-b-2 border-zinc-600 border-[#12221A]/10">
                <img className="mr-2" src={images.SearchIcon} alt="search" />
                <input
                  value={nftContractData?.contractAddress}
                  className="w-full py-3 border-none font-medium focus-visible:outline-0 bg-transparent  placeholder:text-[#12221A] focus:ring-transparent "
                  type="text"
                  onChange={NFTAddressSearchHandler}
                />

              </div>
              {showErr && <p className="text-[#b91c1c]">NFT address is required</p>}
            </div>
            <div className={`mb-6 ${contractListing?.length === 0 ? "hidden" : ""}`}>
              <h4 className="text-base text-[#12221A] font-extrabold mb-3">
                Select Contract
              </h4>
              <div>
                {
                  contractListing?.length > 0 && contractListing?.map((data, i) => {
                    return (
                      <div className="flex justify-between mb-3" key={`step1Contract_${i}`}>
                        <CustomCheckbox
                          isChecked={selectContract}
                          value={data?.contractId}
                          onChange={() => {
                            handleChangeContract(data);
                          }}
                          label={data?.contractName}
                        />

                        <a
                          className="text-[#213E28] text-xs font-extrabold underline"
                          href={`${process.env.REACT_APP_FLOW_VIEW_SRC_TESTNET}${data?.NFTAddress}/contract/${data?.contractName}`}
                          target="_blank"
                          rel="noreferrer"
                        >
                          View Contract
                        </a>
                      </div>
                    )
                  })
                }
              </div>
            </div>
            {/** addition contract information section */}
            <div className={`mb-6 ${contractListing?.length === 0 ? "hidden" : ""}`}>
              <h3 className="text-[#12221A] text-2xl font-bold mb-3">
                Additional Contract Information
              </h3>
              <p className="text-[#12221A]/70 text-xs font-medium mb-3">
                We need a bit more information about{" "}
                <span className="text-white  px-1 py-[2px]  bg-[#213E28] font-extrabold rounded-md">
                  {nftContractData?.contractName}{" "}
                </span>
                <p></p>
                <br />
                <p className="text-[#12221A] font-extrabold block">
                  Enter the storage path your NFT collection uses
                </p>
                We found some possible paths from your contract, you may click to
                one autofill
              </p>
              <div className="mb-6 text-xs font-medium">
                {
                  populateStoragePath("storagePath")
                }

              </div>
              <div className="bg-[#F3F4F4] p-4 rounded-xl mb-6">
                <p className="text-[#12221A]/70 text-xs font-medium">
                  Enter Address containing your NFT contract
                </p>
                <div className="flex border-t-0 border-r-0 border-l-0 border-b-2 border-zinc-600 border-[#12221A]/10">
                  <input
                    readOnly={nftContractData?.contractStoragePath ? true:false}
                    value={nftContractData?.contractStoragePath}
                    onChange={(e) => inputPathHandler(e, "storagePath")}
                    placeholder={nftContractData?.contractStoragePath}
                    className="w-full py-3 border-none font-medium focus-visible:outline-0 bg-transparent  placeholder:text-[#12221A] focus:ring-transparent "
                    type="text"
                  />
                </div>
              </div>
            </div>
            {/** collection  public path */}
            <div className={`mb-10 ${contractListing?.length === 0 ? "hidden" : ""}`}>
              <h3 className="text-[#12221A] text-2xl font-bold mb-3">
                Collection Public Path
              </h3>
              <p className="text-[#12221A]/70 text-xs font-medium mb-3">
                <p className="text-[#12221A] font-extrabold block">
                  Enter an public path that holds this NFT
                </p>
                <br />
                We found some possible paths from your contract, you may click to
                one autofill
              </p>
              <div className="mb-6 text-xs font-medium">
                {
                  populateStoragePath("collectionPath")
                }
              </div>
              <div className="bg-[#F3F4F4] p-4 rounded-xl mb-6">
                <p className="text-[#12221A]/70 text-xs font-medium">
                  Collection Public Path
                </p>
                <div className="flex border-t-0 border-r-0 border-l-0 border-b-2 border-zinc-600 border-[#12221A]/10">
                  <input
                  readOnly={nftContractData?.collectionPublicPath ? true:false}
                    value={nftContractData?.collectionPublicPath}
                    onChange={(e) => inputPathHandler(e, "collectionPath")}
                    placeholder={nftContractData?.collectionPublicPath}
                    className="w-full py-3 border-none font-medium focus-visible:outline-0 bg-transparent  placeholder:text-[#12221A] focus:ring-transparent "
                    type="text"
                  />
                </div>
              </div>
            </div>
          </div>
          <div></div>
        </div>
        <div className="flex justify-between">
          <button className="btn-primary max-w-[526px]" onClick={() =>nftContractData?.isDemoCollection ? setOpenNftMintModal(true): nextBtnClickHandler(1)} disabled={contractListing?.length === 0 || !nftContractData?.contractAddress || !nftContractData?.contractStoragePath || !nftContractData?.collectionPublicPath}>Next</button>
          <button className="text-[#12221A] text-base font-semibold" onClick={handleBack} >
            Cancel
          </button>
        </div>
      </div>
    </>
  );
};

export default SelectContract;
