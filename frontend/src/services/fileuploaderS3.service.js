import { postRequest } from "../axios/axiosHttpMethods";

const uploadImage = (formDataModel) => {
    return postRequest("S3Bucket/upload_image", formDataModel).then((response) => {
        return response?.data;
    });
}
const fileUploaderS3BucketService = {
    uploadImage
}
export default fileUploaderS3BucketService;