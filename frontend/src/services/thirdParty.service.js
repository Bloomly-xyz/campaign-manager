import axios from "axios"
const getCountryList=()=>{
    return axios.get("https://restcountries.com/v2/all?fields=alphaCode,flags,name,alpha2Code,alpha3Code").then((response) => {
       
     const data=  response.data.map(country => (
        { ...country, value: country?.name }
           
        ))
        return data;
       
      })
}
const thirdPartyService={
    getCountryList
}
export default thirdPartyService;