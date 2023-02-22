import { getRequest, postRequest } from "../axios/axiosHttpMethods";

const createCampaign = (formDataModel) => {
    return postRequest("Campaign/create_campaign", formDataModel).then((response) => {
        return response?.data;
    });
}
const getCampaigns = (formDataModel) => {
    return postRequest("Campaign/get_campaigns", formDataModel).then((response) => {
        return response?.data;
    });
}
const getCampaignsDetail = (campaignUuid) => {
    return getRequest(`Campaign/get_campaign_claim_details?CampaignUuid=${campaignUuid}`).then((response) => {
        return response?.data;
    });
}

const campaignService = {
createCampaign,
getCampaigns,
getCampaignsDetail

}
export default campaignService;