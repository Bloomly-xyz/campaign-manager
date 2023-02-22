import React from 'react'
import { useSelector } from 'react-redux';
import AppSpinner from '../../components/common/ui-components/loader-components/AppSpinner';



const Loader = () => {

  const { loadingState } = useSelector(state => state.loader);
    
   
    return (
      <>
        <div
          className="sweet-loading"
          style={{
            position: "fixed",
            top: 0,
            left: 0,
            zIndex: 999999,
            width: "100vw",
            height: "100vh",
            backgroundColor: "#000",
            opacity: 0.6,
            display: loadingState ? "flex" : "none",
            alignItems: "center",
            justifyContent: "center"
          }}
        >
          {loadingState && <AppSpinner /> }  
         
        </div>
      </>
    );
}

export default Loader