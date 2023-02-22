import { Tooltip } from "@material-tailwind/react";
import React, { useRef } from "react";
import Toast from "../../helpers/toast-component/Toast";
import CloseViewIcon from "../common/ui-components/CloseViewIcon";
import images from "./../../constants/images-constants/images";
import { useNavigate } from "react-router-dom";

const CopylinkModal = (props) => {
  const navigate = useNavigate();
  const { setOpenModal, claimLink } = props;
  const copyAddress = useRef();

  const copyText = async (event) => {
    event.preventDefault();
    await navigator.clipboard
      .writeText(copyAddress.current.getAttribute("value"))
      .then(() => {
        Toast("Text Copied", "success");
      })
      .catch(() => {});
  };
  return (
    <>
      <div className="relative">
        <CloseViewIcon
          handleClose={() => {
            setOpenModal(false);
            navigate("/nft-campaigns");
          }}
        />
      </div>
      <div className="">
        <h2 className="text-2xl text-[#12221A] text-center font-extrabold mb-3">
          Congrats 🎉
        </h2>
        <div className="flex flex-col items-center mb-4 text-center">
          <h4 className=" text-xs font-extrabold text-[#12221A] max-w-[412px] ">
            You have successfully attached the utility
          </h4>
          <p className="text-center text-xs font-bold  text-[#12221A]/70 max-w-[412px] ">
            You may now share this with your community so the eligible members
            can claim this utility.
          </p>
        </div>

        <div className="flex justify-between mb-6 items-center border rounded-full  border-[#F3F4F4]">
          <h6
            className="px-3 py-3 truncate "
            ref={copyAddress}
            value={claimLink}
          >
            {claimLink}
          </h6>
          <img
            src={images.CopyIcon}
            alt="icon"
            className="px-3 cursor-pointer "
            onClick={copyText}
          />
        </div>
        {/* <div className="flex items-center">
          <Tooltip
            className="text-white px-4 py-1 rounded-xl bg-[#12221A]  max-w-[200px] relative z-50"
            offset={10}
            placement={"top-center"}
            content={"coming soon "}
          >
            <img
              className="mr-6 cursor-pointer"
              src={images.TwitterIcon}
              alt="icon"
            />
          </Tooltip>
          <Tooltip
            className="text-white px-4 py-1 rounded-xl bg-[#12221A]  max-w-[200px] relative z-50"
            offset={10}
            placement={"top-center"}
            content={"coming soon "}
          >
            <img
              className="mr-6 cursor-pointer"
              src={images.LinkInIcon}
              alt="icon"
            />
          </Tooltip>
          <Tooltip
            className="text-white px-4 py-1 rounded-xl bg-[#12221A]  max-w-[200px] relative z-50"
            offset={10}
            placement={"top-center"}
            content={"coming soon "}
          >
            <img
              className="cursor-pointer"
              src={images.DiscordIcon}
              alt="icon"
            />
          </Tooltip>
        </div> */}
        <div className="mt-10">
          <a
          href={claimLink}
          target="_blank"
           
            className="btn-primary text-center"
          >
            View your utility page
          </a>
        </div>
      </div>
    </>
  );
};

export default CopylinkModal;
