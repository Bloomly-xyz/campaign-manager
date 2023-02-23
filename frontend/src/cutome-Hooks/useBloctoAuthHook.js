import * as fcl from "@onflow/fcl";
const useBloctoAuthHook = () => {
    const loginBlocto=async()=>{
        return await fcl.authenticate();
    }
    const logOutBlocto=async()=>{
        return fcl.unauthenticate();
    }
  return {
    loginBlocto,
    logOutBlocto
  }
}

export default useBloctoAuthHook