import React from 'react'

import AttachUtilityCheckbox from './AttachUtilityCheckbox'

const AllUtility = (props) => {
   const {selectedUtility ,setSelectedUtility ,setOpenUtilityForm ,setActiveStep ,data,cancelBtnClickHandler} =props;

    const handleUtilitySelection = (data) => {
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
    {data?.length > 0 ? (
        <>
          {data?.map((item, index) => (
            <AttachUtilityCheckbox
              key={index}
              data={item}
              selectedUtility={selectedUtility}
              onChange={handleUtilitySelection}
            />
          ))}
          <div className="grid grid-cols-2 gap-4 ">
            <div className="max-w-[526px] ">
              <div className="flex ">
                <button className="mr-6 btn-secondary " onClick={handleBack}>
                  Back
                </button>
                <button className=" btn-primary" onClick={handleUtilityForm} disabled={!selectedUtility?.value}>
                  Continue
                </button>
              </div>
            </div>
            <div className="flex justify-end">
              <button className="text-[#12221A] text-base font-semibold" onClick={cancelBtnClickHandler}>
                Cancel
              </button>
            </div>
          </div>
        </>
      ) : (
        <>
        <div className="my-6">
          <h4 className="text-center font-bold text-[#12221A] ">Records not found</h4>
        </div>
        </>
      )}
    </>
  )
}

export default AllUtility