import React from 'react'

import AttachUtilityCheckbox from './AttachUtilityCheckbox'

const AllUtility = (props) => {
   const {selectedUtility ,setSelectedUtility ,setOpenUtilityForm ,setActiveStep ,data} =props;

    const handleUtilitySelection = (data) => {
      console.log(data)
      
      setSelectedUtility(data)
    }

    const handleUtilityForm = () => {
        
        setOpenUtilityForm(true)
    }
   
    const handleBack =() => {
     
      setActiveStep(2)
    }
  return (
    <>
    {data?.map((item,index) => (
       <AttachUtilityCheckbox key={index} data={item} selectedUtility={selectedUtility} onChange={handleUtilitySelection} />
    ))}
   <div className="grid grid-cols-2 gap-4 ">
        <div className="max-w-[526px] ">
          <div className="flex ">
            <button className="mr-6 btn-secondary " onClick={handleBack}>Back</button>
            <button className=" btn-primary" onClick={handleUtilityForm} >
            Continue
            </button>
          </div>
        </div>
        <div className="flex justify-end">
          <button className="text-[#12221A] text-base font-semibold">
            Cancel
          </button>
        </div>
      </div>
    
    </>
  )
}

export default AllUtility