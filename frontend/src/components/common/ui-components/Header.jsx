import React from "react";
import images from "./../../../constants/images-constants/images";

const Header = (props) => {
  const{title ,backIcon ,handleBack} = props;
  return (
    <>
      <div className="flex items-center py-8">
        <div className="grow">
          
          <h2 className="text-[#12221A] text-[32px]  font-extrabold flex items-center">
          {backIcon && <img onClick={handleBack} alt='icon' className="self-center inline-block mr-2 align-middle cursor-pointer" src={images.BackIcon} />}
            {title}
          </h2>
        </div>
        <div className="">
          <img
            className="inline-block mr-6"
            src={images.NotificationIcon}
            alt="icon"
          />
          <img
            className="inline-block"
            src={images.headerAvatarIcon}
            alt="icon"
          />
        </div>
      </div>
    </>
  );
};

export default Header;
