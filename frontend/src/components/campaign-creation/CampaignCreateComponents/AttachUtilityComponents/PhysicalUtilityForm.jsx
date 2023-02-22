import React, { useRef, useState } from "react";
import { useForm, Controller } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import InputField from "../../../common/ui-components/form-ui/InputField";
import Select, { components } from "react-select";
import { customStyles } from "./../../../common/ui-components/react-select-style/customStyle";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import { PhysicalUtilitySchema } from './../../../../utils/validationSchema/PhysicalUtilitySchema';
import fileUploaderS3BucketService from "../../../../services/fileuploaderS3.service";


const PhysicalUtilityForm = (props) => {
  const {
    countryData,
    setOpenUtilityForm,
    setActiveStep,
    steps,
    setSteps,
    setCampaignCreationData,
    campaignCreationData,
    setFile,
    file,
    nextBtnClickHandler
  } = props;
  const { PhysicalUtilityData } = campaignCreationData?.AttachUtility || {};

  const fileInputRef = useRef();

  const [filePath, setFilePath] = useState("");

  const {
    register,
    control,
    handleSubmit,

    // reset,
    formState: { errors },
  } = useForm({
    defaultValues: {

      name: PhysicalUtilityData?.name || "",
      description: PhysicalUtilityData?.description || '',
      category: PhysicalUtilityData?.category?.value ? { value: PhysicalUtilityData?.category?.value, label: PhysicalUtilityData?.category?.value } : {},
      costPerUnit: PhysicalUtilityData?.costPerUnit || "",
      provider: PhysicalUtilityData?.provider || '',
      shippingPartner: PhysicalUtilityData?.shippingPartner || '',
      country: PhysicalUtilityData?.country?.value ? {
        value: PhysicalUtilityData?.country?.value,
        countryImage: PhysicalUtilityData?.country?.countryImage,
        countryCode2: PhysicalUtilityData?.country?.countryCode2,
        countryCode3: PhysicalUtilityData?.country?.countryCode3
      } : {},
      expirydate: PhysicalUtilityData?.expirydate ? new Date(PhysicalUtilityData?.expirydate) : null,
      image: PhysicalUtilityData?.image ??
        ''

    },
    resolver: yupResolver(PhysicalUtilitySchema),
    mode: "all",
  });

  const { SingleValue, Option } = components;
  const SingleOption = (props) => (
    <SingleValue {...props} className="text-capitalize">
      {props.data.value ? (
        <>
          <div className="text-[#12221A] font-medium">{props.data.label}</div>
        </>
      ) : (
        <p className="text-base text-[#12221A] font-medium">Type of NFT</p>
      )}
    </SingleValue>
  );
  const SingleOptionCountry = (props) => (
    <SingleValue {...props}>
      {props.data.value ? (
        <>
          <div className="flex ">
            {props?.data?.flags?.svg && (
              <img
                src={props.data.flags.svg}
                className="w-5 h-5 mr-3 "
                alt={"icon"}
              />
            )}
            <p className="text-black"> {props.data.value}</p>{" "}
          </div>
        </>
      ) : (
        <p className="text-grey">eg. UNITED STATES</p>
      )}
    </SingleValue>
  );
  const IconOption = (props) => (
    <Option {...props}>
      <div className="flex items-center ">
        <img
          src={props?.data?.flags?.svg}
          className="w-6 h-4 mr-3"
          alt={"icon"}
        />
        <p className=""> {props.data.value}</p>
      </div>
    </Option>
  );
  const options = [
    { value: "Merchandise", label: "Merchandise" },
    { value: "Memberships", label: "Memberships" },
    { value: "Tickets", label: "Tickets" },
  ];
  const ShippingOptions=[
    { value: "DHL", label: "DHL" },
    { value: "FedEx", label: "FedEx" },
    { value: "UPS", label: "UPS" },
  ]

  const handleChange = (e) => {
    if (e.target.files[0]?.size > 5000000) {
      return false;
    } else {
      // setFileSize((e.target.files[0]?.size / 1024).toFixed(2));
      setFile(URL.createObjectURL(e.target.files[0]));
      const formData = new FormData();
      formData.append("File", e.target.files[0])
      fileUploaderS3BucketService.uploadImage(formData).then((response) => {
        if (response?.payload?.result) {
          setFilePath(response?.payload?.result)
        }
      }).catch((error) => {

      })
    }
  };

  const handleUtilityData = (values) => {
    let formData = values;

    formData.filePath = filePath;
    setCampaignCreationData({ ...campaignCreationData, AttachUtility: { PhysicalUtilityData: formData } });
    nextBtnClickHandler(3, values);
  };
  return (
    <>
      <form onSubmit={handleSubmit(handleUtilityData)}>
        <div className="p-6 bg-white rounded-3xl">
          <h3 className="text-[#12221A] text-2xl font-extrabold mb-3">
            Physical Utility
          </h3>
          <div className="grid grid-cols-2 gap-4 ">
            <div className="max-w-[526px] ">
              <div className="mb-8">
                <InputField
                  type="text"
                  label="Name"
                  register={register}
                  name="name"
                  placeholder={""}
                />
                <p className="mt-1 text-xs text-red-600">
                  {errors?.name?.message}
                </p>
              </div>
              <div className="mb-8">
                <textarea
                  className="w-full px-3 py-2 text-[#12221A] placeholder-[#12221A] bg-transparent border rounded-lg focus:ring-[#12221A]/70 focus:border-[#12221A]/70 border-[#12221A]/10 focus:outline-none"
                  rows="4"
                  placeholder="Lorem ipsum dolor sit amet consectetur. Accumsan id in tempor interdum. Eget pharetra pretium eget aenean aenean. Aliquet."
                  name="description"
                  maxlength="501"
                  {...register("description")}
                ></textarea>
                <p className="mt-1 text-xs text-red-600">
                  {errors?.description?.message}
                </p>
              </div>
              <div className="grid grid-cols-2 gap-4 mb-8">
                <div>
                  <label className={`text-xs text-[#12221A]/70 mb-1 `}>
                    Item/Category
                  </label>
                  <Controller
                    name="category"
                    control={control}
                    render={({ field }) => (
                      <Select
                        {...field}
                        styles={customStyles}
                        components={{
                          SingleValue: SingleOption,
                        }}
                        onChange={(e) => {
                          field.onChange({ value: e.value, label: e.label });
                        }}
                        options={options}
                      />
                    )}
                  />

                  <p className="mt-2 text-xs text-red-600">
                    {errors?.category?.value?.message}
                  </p>
                </div>
                <div>
                  <InputField
                    type="text"
                    label="Cost per Unit"
                    register={register}
                    name="costPerUnit"
                    placeholder={""}
                  />
                  <p className="mt-1 text-xs text-red-600">
                    {errors?.costPerUnit?.message}
                  </p>
                </div>
              </div>
              <div className="grid grid-cols-2 gap-4 mb-8">
                <div>
                  <InputField
                    type="text"
                    label="Provider"
                    register={register}
                    name="provider"
                    placeholder={""}
                  />
                  <p className="mt-1 text-xs text-red-600">
                    {errors?.provider?.message}
                  </p>
                </div>
                {/* <div>
                  <InputField
                    type="text"
                    label="Courier/Shipping Partner"
                    register={register}
                    name="shippingPartner"
                    placeholder={""}
                  />
                  <p className="mt-1 text-xs text-red-600">
                    {errors?.shippingPartner?.message}
                  </p>
                </div> */}
                  <div>
                  <label className={`text-xs text-[#12221A]/70 mb-1 `}>
                  Courier/Shipping Partner
                  </label>
                  <Controller
                    name="shippingPartner"
                    control={control}
                    render={({ field }) => (
                      <Select
                        {...field}
                        styles={customStyles}
                        components={{
                          SingleValue: SingleOption,
                        }}
                        onChange={(e) => {
                          field.onChange({ value: e.value, label: e.label });
                        }}
                        options={ShippingOptions}
                      />
                    )}
                  />

                  <p className="mt-2 text-xs text-red-600">
                    {errors?.shippingPartner?.value?.message}
                  </p>
                </div>
              </div>
              <div className="grid grid-cols-2 gap-4 mb-10">
                <div>
                  <label className={`text-xs text-[#12221A]/70 mb-1 `}>
                    Location
                  </label>
                  <Controller
                    name="country"
                    control={control}
                    render={({ field }) => (
                      <Select
                        {...field}
                        styles={customStyles}
                        components={{
                          SingleValue: SingleOptionCountry,
                          Option: IconOption,
                        }}
                        onChange={(e) => {
                          field.onChange({
                            value: e.value,
                            countryImage: e?.flags?.svg,
                            countryCode2: e.alpha2Code,
                            countryCode3: e.alpha3Code,
                          });
                        }}
                        options={countryData}
                      />
                    )}
                  />

                  <p className="mt-2 text-xs text-red-600">
                    {errors?.country?.value?.message}
                  </p>
                </div>
                <div>
                  <label className={`text-xs text-[#12221A]/70 mb-1 `}>
                    Expiry Date
                  </label>

                  <Controller
                    control={control}
                    name="expirydate"
                    render={({ field }) => (
                      <DatePicker
                        className="text-base bg-[url('/src/assets/images/calendar-icon.svg')] bg-no-repeat bg-right relative block w-full p-3 pl-0 pr-0 text-[#12221A] bg-transparent border-t-0 border-b-1 border-l-0 border-r-0 border border-[#12221A]/10  rounded-none outline-none placeholder:text-[#12221A] text-md focus:ring-0 focus:border-b-[#12221A]/70 "
                        selected={field.value}
                        placeholderText=" "
                        onChange={(e) => field.onChange(e)}
                        dateFormat={"MMMM dd,YYY"}
                        name="expirydate"
                        showMonthDropdown
                        showYearDropdown
                        autoComplete="off"
                        minDate={new Date(new Date().getFullYear(),new Date().getMonth(),(new Date().getDate()+1))}
                      />
                    )}
                  />
                  <p className="mt-2 text-xs text-red-600">
                    {errors?.expirydate?.message}
                  </p>
                </div>
              </div>
            </div>
            <div>
              {/* File Uploader */}
              <label
                htmlFor="inputFileSelector"
                className="mb-2 cursor-pointer"
              >
                {/* Image Selector */}
                <input
                  hidden={true}
                  id="inputFileSelector"
                  ref={fileInputRef}
                  accept={".gif,.jpg,.jpeg,.png"}
                  type="file"
                  name="image"
                  // className={inputFieldStyle}
                  {...register("image", {
                    onChange: (e) => {
                      handleChange(e);
                    },
                  })}
                />

                <div className="flex flex-col overflow-hidden items-center bg-[#12221A]/[0.02] justify-center max-w-[400px] max-h-[363px]  text-white border-2 p-8 border-[#12221A]/10 border-solid rounded-xl w-full min-h-[96px] h-full">
                  {file ? (
                    <img src={file} alt="icon" className="max-h-[330px]" />
                  ) : (
                    <div className="text-[#12221A] text-center ">
                      <h4 className="text-base font-bold">Upload Media</h4>
                      <p className="mb-2 text-xs">Drag or Browse Files</p>
                      <p className="text-xs ">
                        JPG, GIF, PNG | Max file size: 5 MB
                      </p>
                    </div>
                  )}
                </div>
              </label>
            </div>
          </div>
          <div className="grid grid-cols-2 gap-4 ">
            <div className="max-w-[526px] ">
              <div className="flex ">
                <button
                  className="mr-6 btn-secondary "
                  onClick={() => {
                    setOpenUtilityForm(false);
                  }}
                >
                  Back
                </button>
                <button type="submit" className=" btn-primary">
                  Next
                </button>
              </div>
            </div>
            <div className="flex justify-end">
              <button className="text-[#12221A] text-base font-semibold">
                Cancel
              </button>
            </div>
          </div>
        </div>
      </form>
    </>
  );
};

export default PhysicalUtilityForm;
