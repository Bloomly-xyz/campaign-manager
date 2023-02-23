import { yupResolver } from "@hookform/resolvers/yup";
import React from "react";
import { useForm } from "react-hook-form";
import { claimUtilitySchema } from "../../utils/validationSchema/ClaimUtilitySchema";
import CloseViewIcon from "../common/ui-components/CloseViewIcon";
import ClaimInputField from "./../common/ui-components/form-ui/ClaimInputField";
import ClaimUtilityService from './../../services/claimUtility.service';
import { useDispatch } from 'react-redux';
import { setLoader } from "../../redux/slices/loading/loaderSlice";
import Toast from "../../helpers/toast-component/Toast";
import BlockChainTx from "../../BlockChainTx/BlockChainTx";

const ClaimUtilityModal = (props) => {
  const dispatch = useDispatch();
  const { setOpenClaimModal, setOpenAlertModal, setAlertMessageContent ,campaignUuid ,userId,campaignData } =
    props;
    
  const {
    register,
    handleSubmit,

    // reset,
    formState: { errors, isDirty, isValid },
  } = useForm({
    resolver: yupResolver(claimUtilitySchema),
    mode: "all",
  });
  const handleCloseModal = () => {
    setOpenClaimModal(false);
  };
  const handleClaimUtility =async (values) => {
    dispatch(setLoader(true));
    const claimResp=await BlockChainTx?.claimUtilityTx(campaignData);
    if(!claimResp?.error){
    ClaimUtilityService.CreateClaimUtility(values ,campaignUuid ,userId?.id ,claimResp?.message?.txId)
    .then(response => {
      dispatch(setLoader(false))
      if(response?.statusCode === 200){
        setOpenClaimModal(false);
        setOpenAlertModal(true);
        setAlertMessageContent({
          status: "success",
          message: "Thank you for claiming",
          closeBtnText:'Back to Asset',
          description:
            "Lorem ipsum dolor sit amet consectetur. Nec arcu molestie elit dignissim proin mattis pellentesque. Sed enim ullamcorper ut ut.",
        });

      }
    })
    .catch(error => {
      dispatch(setLoader(false))
      Toast(error?.response?.data?.message ?? 'something went wrong',"error")
    })
  }
  else{
    dispatch(setLoader(false));
    setOpenClaimModal(false);
      Toast('Error while claiming.Please contact support.',"error")
  }

    
    
   
  };
  return (
    <>
      <div className="relative">
        <CloseViewIcon claim={true} handleClose={handleCloseModal} />
        <div>
          <h2 className="mb-4 text-2xl font-bold text-white">Claim Utility </h2>
          <form onSubmit={handleSubmit(handleClaimUtility)}>
            <div className="mb-6">
              <ClaimInputField
                type="text"
                label="Name*"
                register={register}
                name="name"
                placeholder={""}
              />
              <p className="mt-1 text-xs text-red-600">
                {errors?.name?.message}
              </p>
            </div>
            <div className="mb-6">
              <ClaimInputField
                type="text"
                label="Email Address*"
                register={register}
                name="emailAddress"
                placeholder={""}
              />
              <p className="mt-1 text-xs text-red-600">
                {errors?.emailAddress?.message}
              </p>
            </div>
            <div className="mb-6">
              <ClaimInputField
                type="text"
                label="Shipping Address*"
                register={register}
                name="shippingAddress"
                placeholder={""}
              />
              <p className="mt-1 text-xs text-red-600">
                {errors?.shippingAddress?.message}
              </p>
            </div>
            <div className="mb-6">
              <ClaimInputField
                type="text"
                label="Phone Number*"
                register={register}
                name="phoneNumber"
                placeholder={""}
              />
              <p className="mt-1 text-xs text-red-600">
                {errors?.phoneNumber?.message}
              </p>
            </div>
            <div className="mb-10">
              <ClaimInputField
                type="text"
                label="other*"
                register={register}
                name="other"
                placeholder={""}
              />
              <p className="mt-1 text-xs text-red-600">
                {errors?.other?.message}
              </p>
            </div>
            <button disabled={!isDirty || !isValid} className="btn-primary">
              Submit
            </button>
          </form>
        </div>
      </div>
    </>
  );
};

export default ClaimUtilityModal;
