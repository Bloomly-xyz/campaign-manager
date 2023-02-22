import { axiosInterceptor } from "./Interceptor";

/// all the axios http requests like get/post/put/delete

const getRequest = async (URL) => {
	const response = await axiosInterceptor.get(`/${URL}`, {});
	return response;
};

const postRequest = async (URL, payload) => {
	const response = await axiosInterceptor.post(`/${URL}`, payload);
	return response;
};

const putRequest = async (URL, payload) => {
	const response = await axiosInterceptor.put(`/${URL}`, payload);
	return response;
};

const deleteRequest = async (URL) => {
	const response = await axiosInterceptor.delete(`/${URL}`);
	return response;
};

export { getRequest, postRequest, putRequest, deleteRequest };