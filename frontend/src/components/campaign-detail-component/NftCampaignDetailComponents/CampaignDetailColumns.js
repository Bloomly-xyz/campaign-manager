import DateFormat from "../../../helpers/DateFormat";

export const COLUMNS = [
    {
      Header: "Wallet Address",
      Footer: "Wallet Address",
      accessor: "walletAddress",
    },
    {
      Header: "Name",
      Footer: "Name",
      accessor: "name",
      
    },
    {
      Header: "Email address",
      Footer: "Email address",
      accessor: "emailAddress",
    },
    {
      Header: "Shipping address",
      Footer: "Shipping address",
      accessor: "shippingAddress",
    },
    {
      Header: "Phone number",
      Footer: "Phone number",
      accessor: "phoneNumber",
    },
    {
        Header: "Others",
        Footer: "Others",
        accessor: "other",  
    },
    {
        Header: "Claimed Date",
        Footer: "Claimed Date",
        accessor: "campaignClaimDate", 
          Cell: ({ row }) => <>{row?.values?.campaignClaimDate ? DateFormat(row?.values?.campaignClaimDate) :'-'}</>,
    }
  
  ];