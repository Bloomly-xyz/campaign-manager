import React from "react";
import CloseViewIcon from "../common/ui-components/CloseViewIcon";
import { useNavigate } from 'react-router';

const ChooseProjectModal = (props) => {
  const {closeModal} = props;
  const navigate = useNavigate();


  const handleModalClose = () => {
    closeModal(false)
  }
  const handleCreatedCollectionUtility = () => {
    navigate('/create-NFT-campaign')
  }
  return (
    <>
      <div className="relative">
        <CloseViewIcon handleClose={handleModalClose} />
      </div>
      <div>
        <h3 className="text-[#12221A] text-4xl font-extrabold mb-4">
          Choose Project Type
        </h3>
        <div onClick={handleCreatedCollectionUtility} className={`p-6 bg-[#213E28] text-white rounded-xl mb-8 cursor-pointer`}>
          <h4 className="text-base font-extrabold ">
            Do you have your collection?{" "}
          </h4>
          <p className="text-xs text-white/70">
            Use your collection and add utility to the NFTs.
          </p>
        </div>
        <div className={`p-6 bg-white text-[#12221A] border border-[#12221A]/25 rounded-xl mb-8 cursor-pointer`}>
          <h4 className="text-base font-extrabold ">
          Create your own collection{" "}
          </h4>
          <p className="text-xs text-[#12221A]/70">
          Create assets and build a collection to add utility.
          </p>
        </div>
      </div>
    </>
  );
};

export default ChooseProjectModal;
