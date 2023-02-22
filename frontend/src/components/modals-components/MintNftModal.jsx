import React from 'react'
import CloseViewIcon from '../common/ui-components/CloseViewIcon'

const MintNftModal = (props) => {
    const {setOpenModal,mintCollectionHandler} = props;
    const handleCloseModal = () => {
        setOpenModal(false)
    }
  return (
    <>
    <div className='relative'>
        <CloseViewIcon  handleClose={handleCloseModal} />
       <h2 className='font-extrabold text-[#12221A] text-[32px] mb-3'>Let’s mint your NFT</h2>
       <p className='text-[#12221A]/70 text-xs mb-4'>
        Since you've chosen the NBA contract for the hackathon demo in step 1, we can now mint an NFT in your Blocto wallet.This will enable you to claim the utility once the claim page is created as you will have the respective NFT in your wallet. To proceed, please click on the "Mint Now" button below. You may also skip the minting process.
       </p>
       <div>
        <button className='mb-6 btn-primary' onClick={mintCollectionHandler}>Mint Now</button>
        <button className=' btn-secondary' onClick={handleCloseModal}>Skip</button>
       </div>
    </div>
    <div>
        
    </div>
    </>
  )
}

export default MintNftModal