import { getRequest, postRequest } from "../axios/axiosHttpMethods";

const getClaimUtilityData = (campaignId) => {
  return getRequest(
    `Campaign/get_campaign_by_id?CampaignUuid=${campaignId}`
  ).then((response) => {
    return response?.data;
  });
};
const CreateClaimUtility = (claimJson ,campaignUuid , userId,blockChainTransactionId) => {
  const payload = {
    claimJson:claimJson && JSON.stringify(claimJson),
    userId: userId,
    campaignId: campaignUuid,
    blockChainTransactionId: blockChainTransactionId,
  };
 
  return postRequest(`Utility/claim_utility`, payload).then((response) => {
    return response?.data;
  });
};
const getClaimUtility = (payload) => {
  return postRequest(`Utility/get_claimed_utility`, payload).then((response) => {
    return response?.data;
  });
};

const ClaimUtilityService = {
  getClaimUtilityData,
  CreateClaimUtility,
  getClaimUtility
};
export default ClaimUtilityService;
