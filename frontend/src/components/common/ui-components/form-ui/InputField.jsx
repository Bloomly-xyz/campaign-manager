import React from 'react'

const InputField = (props) => {
    const{register, name, label, placeholder, type, ...rest} = props;
  return (
    <>
    <div className={`relative `}>
    <label
          className={`text-xs text-[#12221A]/70 mb-1 `}
        >
          {label}
        </label>
        <input
          {...rest}
          className={` text-base border-t-0 border-r-0 border-l-0 border-b-[1px] border-[#12221A]/10  w-full py-3  font-medium focus-visible:outline-0 bg-transparent focus:border-[#12221A]/70  placeholder:text-[#12221A] focus:ring-transparent`}
          type={type}
          placeholder={placeholder}
          {...register(name)}
        />

     
      </div>
    </>
  )
}

export default InputField