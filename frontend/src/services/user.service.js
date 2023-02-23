import { postRequest } from "../axios/axiosHttpMethods";

const create_user = (requestModel) => {
    return postRequest("User/create_user", requestModel).then((response) => {
        return response?.data;
    });
}
const userService = {
    create_user
}
export default userService;