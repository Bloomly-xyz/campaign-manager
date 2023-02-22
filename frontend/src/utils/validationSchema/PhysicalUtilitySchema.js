import * as yup from "yup";
import moment from "moment";

export const PhysicalUtilitySchema = yup.object().shape({
  name: yup
    .string()
    .required("Name is required")
    .matches(/^[^\s]+(\s+[^\s]+)*/, "Characters must be alphanumaric")
    .max(20, "Max  length 20 characters"),

  description: yup
    .string()
    .required("Description is required")
    .matches(/^[^\s]+(\s+[^\s]+)*/, "Characters must be alphanumaric")
    .max(500, "Max  length 500 characters"),

  category: yup.object().shape({
    value: yup.string().required("Category is required"),
  }),

  costPerUnit:yup.string()
  .required("Price is required ")
  .test(
    'Price must be greater than 0',
    'Price must be greater than 0',
    (value, context) => {
      return context.originalValue && !context.originalValue.startsWith('0');
    }),

  provider: yup
    .string()
    .required("Provider is required")
    .matches(/^[^\s]+(\s+[^\s]+)*/, "Characters must be alphanumaric")
    .max(20, "Max  length 20 characters"),

  // shippingPartner: yup
  //   .string()
  //   .required("ShippingPartner is required")
  //   .matches(/^[^\s]+(\s+[^\s]+)*/, "Characters must be alphanumaric")
  //   .max(20, "Max  length 20 characters"),
  shippingPartner: yup.object().shape({
    value: yup.string().required("ShippingPartner is required"),
  }),

  country: yup.object().shape({
    value: yup.string().required("Country is required"),
  }),

  expirydate: yup
    .date()
    .transform((value) => {
      return value ? moment(value).toDate() : value;
    })
    .min(new Date(), "Date must be greater than current time")
    .required("Date is required")
    .nullable(),
  image: yup.mixed().test("required", "Media is required", (file) => {
    if (file[0]) return true;
    return false;
  }),
});
