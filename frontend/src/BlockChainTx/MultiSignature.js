import * as fcl from "@onflow/fcl";

const API = process.env.REACT_APP_MULTISIGN_URL;//multisign url 
const getSignature = async (signable) => {
    const response = await fetch(`${API}MultiSig`, {
      method: "POST",
      headers: { "Content-Type": "application/json" ,
      "Access-Control-Allow-Origin": "*",
      "Access-Control-Allow-Credentials": true
    },
      body: JSON.stringify({ signable })
    });
  
    const signed = await response.json();
    return signed.signature;
  };
  
  export const serverAuthorization = async (account) => {
    // address for the emulator address
    const addr =process.env.REACT_APP_UTILITYTRACKER;
    const keyId = 0;
     console.log("signing addr",addr);
    return {
      ...account,
      tempId: `${addr}-${keyId}`,
      addr: fcl.sansPrefix(addr),
      keyId: Number(keyId),
      signingFunction: async (signable) => {
        const signature = await getSignature(signable);
  
        return {
          addr: fcl.withPrefix(addr),
          keyId: Number(keyId),
          signature
        };
      }
    };
  };