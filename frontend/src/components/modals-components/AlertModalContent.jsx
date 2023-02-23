import React from "react";
import images from "../../constants/images-constants/images";
import CloseViewIcon from "../common/ui-components/CloseViewIcon";

const AlertModalContent = (props) => {
  const { handleClose, alertMessageContent } = props;
  return (
    <>
      <div className="relative">
        <CloseViewIcon claim={true} handleClose={handleClose  } />
        <div>
          <img
            className="mb-2"
            src={
              alertMessageContent?.status === "success"
                ? images.SuccessIcon
                : ""
            }
            alt="icon"
          />
          <h2 className="mb-2 text-2xl font-bold text-white">{alertMessageContent?.message}</h2>
          <p className="mb-6 text-xs text-white/70 ">
            {alertMessageContent?.description}
          </p>
          {alertMessageContent.closeBtnText && (
            <button className="btn-primary" onClick={handleClose}>
              {alertMessageContent.closeBtnText}
            </button>
          )}
        </div>
      </div>
    </>
  );
};

export default AlertModalContent;
