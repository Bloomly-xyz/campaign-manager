import React, { useState } from "react";
import images from '../../../constants/images-constants/images'

const SearchComponent = (props) => {
  const { filterData, setUtilitiesListing } = props;
  const handleChange = (e) => {
    const filtered = filterData.filter((item) => {
      return (
        item.utitilityName
          .toLowerCase()
          .includes(e.target.value.toLowerCase()) ||
        item.utilityDescription
          .toLowerCase()
          .includes(e.target.value.toLowerCase())
      );
    });
    setUtilitiesListing(filtered);
  };
  return (
    <>
     <div className="flex items-center flex-grow py-3 px-4  rounded-full bg-transparent border-2 border-[#12221A]/10 min-w-[80px] ">
            <img className="mr-2" src={images.SearchIcon} alt="search" />
            <input
                className="w-full p-0 focus-visible:outline-0 bg-transparent border-none placeholder:text-[#12221A] focus:ring-transparent"
                placeholder="Search"
                type="text"
                onChange={(e) => handleChange(e)}
            />
        </div>
    </>
  )
}

export default SearchComponent