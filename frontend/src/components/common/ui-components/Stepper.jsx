import React from 'react'

const Stepper = (props) => {
    const { steps, activeStep, } = props;
   
  return (
    <>
    <div className="flex mb-6">
            {steps?.map((step, index) => (
              <div className="inline-flex items-center mr-9 " key={index}>
              
                  <div
                    className={` ${activeStep === step.value  ? `text-[#12221A] font-bold  bg-[#A5F33C] ` :`  ${step?.IsCompleted ? 'bg-[#213E28] text-white': 'bg-[#F3F4F4] text-[#12221A]/70'}  `}  font-semibold w-[32px] h-[32px] flex justify-center px-3 py-1 text-base  border rounded-[50%] border-transparent `}
                  >
                    {step.value}
                  </div>
               
                <div
                  className={`ml-4 text-base   ${
                    activeStep === step.value ||  step?.IsCompleted
                      ? "text-[#12221A] font-bold"
                      : "text-[#12221A]/70 font-semibold"
                  } ${step?.IsCompleted ? 'text-[#12221A] font-  bold' :''} `}
                >
                  {step.title}
                </div>
              </div>
            ))}
          </div>
    </>
  )
}

export default Stepper