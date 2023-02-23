import axios from "axios";

const axiosInterceptor = axios.create({
    baseURL: process.env.REACT_APP_API_URL,
});
axiosInterceptor.interceptors.request.use(
    function (config) {
        config.headers.XApiKey = process.env.REACT_APP_API_KEY;
        return config;
    },
    (error) => {
        return error;
    }
);
axiosInterceptor.interceptors.response.use(
    (response) => {
        return response;
    },
    async (error) => {
        return Promise.reject(error);
    }
);
export {axiosInterceptor};