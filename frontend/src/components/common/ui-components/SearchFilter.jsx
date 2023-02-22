import React from 'react';
import images from '../../../constants/images-constants/images';



const SearchFilter = ({ filter, setFilter }) => {
    return (
        <div className="flex items-center flex-grow py-3 px-4  rounded-full bg-transparent border-2 border-[#12221A]/30 min-w-[80px] ml-4">
            <img className="mr-2" src={images.SearchIcon} alt="search" />
            <input
                className="w-full p-0 focus-visible:outline-0 bg-transparent border-none placeholder:text-[#12221A] focus:ring-transparent"
                placeholder="Search"
                type="text"
                value={filter || ''}
                onChange={(e) => setFilter(e.target.value)}
            />
        </div>
    )
}

export default SearchFilter