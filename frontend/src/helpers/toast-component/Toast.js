import React from "react";
import { toast } from "react-toastify";

const Toast = (message, type) => {
  switch (type) {
    case "success":
      return toast.success(
        <div>
          <p className="text-sm text-[#12221A]">{message}</p>
        </div>
      );
    case "error":
      return toast.error(
        <div>
          <p className="text-sm text-[#12221A]  truncate ">{message}</p>
        </div>
      );
    case "warning":
      return toast.warning(
        <div>
          <p className="text-sm text-[#12221A]">{message}</p>
        </div>
      );
    default:
      return toast.warning(
        <div>
          <p className="text-sm text-[#12221A]">{message ?? 'Something went wrong'} </p>
        </div>
      );
  }
};
export default Toast;
