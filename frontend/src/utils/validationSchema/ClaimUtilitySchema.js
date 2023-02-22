
import * as yup from "yup";


const phoneRegExp = /^((\\+[1-9]{1,4}[ \\-]*)|(\\([0-9]{2,3}\\)[ \\-]*)|([0-9]{2,4})[ \\-]*)*?[0-9]{3,4}?[ \\-]*[0-9]{3,4}?$/

export const claimUtilitySchema = yup.object().shape({
    name: yup
    .string()
    .required("Name is required")
    .matches(/^[^\s]+(\s+[^\s]+)*/, "Characters must be alphanumaric")
    .max(20, "Max  length 20 characters"),
    emailAddress: yup
    .string()
    .email("Invalid email")
    .required("Email is required")
    .matches(/^[^\s]+(\s+[^\s]+)*/, "Characters must be alphanumaric")
    .max(100, "Max  length 100 characters"),
    shippingAddress:yup
    .string()
    .required("Shipping address is required")
    .matches(/^[^\s]+(\s+[^\s]+)*/, "Characters must be alphanumaric")
    .max(500, "Max  length 500 characters"),
    phoneNumber: yup
    .string()
    .matches(phoneRegExp, 'Phone number is not valid')
    .min(10, " Phone number is too short")
    .max(16, "Phone number is too long"),

    other:yup
    .string()
    .required("Field is required")
    .matches(/^[^\s]+(\s+[^\s]+)*/, "Characters must be alphanumaric")
    .max(500, "Max  length 500 characters"),

 
 

});
