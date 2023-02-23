import React from 'react'

const ClaimInputField = (props) => {
    const{register, name, label, placeholder, type, ...rest} = props;
  return (
    <>
    <div className={`relative `}>
    <label
          className={`text-xs text-[#8D9D91] mb-1 `}
        >
          {label}
        </label>
        <input
          {...rest}
          className={` text-base text-white border-t-0 border-r-0 border-l-0 border-b-[1px] border-[#A4B1A7]/25  w-full py-3  font-medium focus-visible:outline-0 bg-transparent focus:border-[#A4B1A7]/50  placeholder:text-white focus:ring-transparent`}
          type={type}
          placeholder={placeholder}
          {...register(name)}
        />

     
      </div>
    </>
  )
}

export default ClaimInputField