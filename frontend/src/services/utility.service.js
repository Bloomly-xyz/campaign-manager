import { getRequest } from "../axios/axiosHttpMethods";

const get_shipping_partners=()=>{
    return getRequest("utility/get_shipping_partners").then((response)=>{
        return response?.data;
    })
}
const get_utilities=()=>{
    return getRequest("utility/get_utilities").then((response)=>{
        return response?.data;
    })
}

const utilityService={
get_shipping_partners,
get_utilities
}
export default utilityService;