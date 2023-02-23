import moment from "moment";

const DateFormat = (date) => {
  return moment(date).format("MMMM D, YYYY");
};

export default DateFormat;
