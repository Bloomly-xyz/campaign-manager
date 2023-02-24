import { useEffect } from "react";
import { useNavigate } from "react-router";
import images from "../../constants/images-constants/images";
import useBloctoAuthHook from "../../cutome-Hooks/useBloctoAuthHook";
import { useDispatch, useSelector } from "react-redux";
import { login } from "../../redux/slices/user/userSlice";
import userService from "../../services/user.service";
import Toast from "../../helpers/toast-component/Toast";
import { setLoader } from "../../redux/slices/loading/loaderSlice";
const BloctoAuth = () => {
  /** Custom React Hook */
  const { loginBlocto } = useBloctoAuthHook();
  /** React Js Hook */
  const navigate = useNavigate();
  const dispatch = useDispatch();
  /** Read login status From redux */
  const { isLoggedIn } = useSelector(
    (state) => state.user
  );
  /** React Hook to check if user is loggedIn then navigate to compaigns else back to login screen */
  useEffect(() => {
    if (isLoggedIn) {
      navigate("/nft-campaigns");
    }
    else {
      navigate("/login")
    }
    //eslint-disable-next-line
  }, []);

  /** Custom Handlers  */
  const loginHandler = async () => {
    dispatch(setLoader(true))
    const authResp = await loginBlocto(); // authenticate
    if (authResp?.addr) {
      const requestModel = {
        EmailAddress: authResp?.services?.[0]?.scoped?.email,
        WalletAddress: authResp?.addr
      }
      userService.create_user(requestModel).then((result) => {
        dispatch(setLoader(false))
       
        if (result?.statusCode===200 && result?.payload) {
          navigate("/nft-campaigns");
          dispatch(login(result?.payload));
        }
        else{
          Toast(result?.message ?? 'Something went wrong' ,'error')
          //show login failure message here
        }
      }).catch((error) => {
        dispatch(setLoader(false))
        Toast(error?.response?.message ?? 'Something went wrong' ,'error')

      })

    }else {
      dispatch(setLoader(false))
    }
  };
  return (
    <>
      <div className="flex justify-center h-full">
        <div className="bg-[url('/src/assets/images/auth-right-bg.png')] bg-no-repeat bg-cover bg-center rounded-3xl pt-24 pb-10 px-14 max-w-[532px] 3xl:max-w-[80%] flex  items-center flex-col">
          <div className="mb-3 grow">
            <div className="text-center">
            <img className="inline"  src={images.NexusLogo} alt="logo" />
            <p className="mt-4 text-[#12221A]/70 text-xs max-w-[292px]">Empowering the relationship between creator and their communities</p>

            </div>
           
          </div>
          <div>
            <div className="mb-8 text-center ">
              <img
                className="inline-block text-center"
                src={images.AuthBloctoLogo}
                alt="icon"
              />
            </div>
            <p className="text-[#12221A]/70 text-xs mb-10 text-center">
              Blocto is an integrated cross-chain wallet service, which enables
              users and developers to interact with their cryptocurrencies,
              dApps, and NFTs frictionlessly.
            </p>
            <button className="btn-primary" onClick={loginHandler}>
              Connect Wallet
            </button>
          </div>
        </div>
      </div>
    </>
  );
};

export default BloctoAuth;
