import thirdPartyService from "../../services/thirdParty.service";


const ThirdPartyHook = () => {
  const getCountriesData = () => {
    return thirdPartyService
      .getCountryList()
      .then((response) => {
      
        return response;
      })
      .catch((error) => {
        return false;
      });
  };

  return {
    getCountriesData
  };
};

export default ThirdPartyHook;
