import React from 'react'

const Modal = (props) => {
    const {openModal  ,modal_Id  ,children ,mwidth} = props;
  return (
    <>
      <div
            id={modal_Id}
            tabIndex="-1"
            aria-hidden="true"
            className={`${
                openModal ? "backdrop-blur-[14px]" : "hidden"
            } max-lg:h-full flex justify-center max-lg:items-end max-lg:p-0  items-center overflow-y-auto overflow-x-hidden fixed top-0 z-50 right-0 left-0 p-4 w-full max-md:inset-0 max-lg:inset-0 h-modal md:h-full max-lg:bottom-0`}
          >
            <div className="relative w-full m-auto max-lg:m-0 max-lg:h-auto max-lg:min-w-full" style={{maxWidth: `${mwidth}`}}>
              {/* Modal content  */}
              {/*Wrapping div for border gradient */}
              <div className="rounded-3xl max-lg:rounded-b-none background-linear-gradient-border p-[1px] ">
                {/* Actual Modal Content */}
                <div className="relative bg-white shadow rounded-3xl max-lg:rounded-b-none">
                  
                  <div className="p-14 max-lg:p-10 max-lg:max-h-[800px] max-lg:overflow-auto">{children}</div>
                </div>
              </div>
            </div>
          </div>
          <div
            className={`${
                openModal ? "" : "hidden"
            } opacity-50 fixed inset-0 z-40 bg-black`}
          ></div>
    </>
  )
}

export default Modal