import DateFormat from "../../../helpers/DateFormat";

export const COLUMNS = [
  {
    Header: "Campaign Id",
    Footer: "Campaign Id",
    accessor: "campaignUuid",
  },
  {
    Header: "Campaign Name",
    Footer: "Campaign Name",
    accessor: "campaignName",
  },
  {
    Header: "Utilities",
    Footer: "Utilities",
    accessor: "physical",
    Cell: ({ row }) => (
    
      <>
      
        <>
          <span
            className={`${
              row?.values?.physical
                ? "bg-[#5283F9]"
                : row?.values?.digital
                ? "bg-[#B1E37D]"
                : row?.values?.experencial && "bg-[#F2B64C]"
            }  text-white py-1 text-[10px] rounded-full px-2 ] mr-2`}
          >
            {row?.values?.physical && "Physical"}
            {row?.values?.digital && "Digital"}
            {row?.values?.experencial && "Experiential"}
          </span>
        </>
      </>
    ),
  },
  {
    Header: "Claimed Amount",
    Footer: "Claimed Amount",
    accessor: "noOfClaims",
  },
  {
    Header: "Status",
    Footer: "Status",
    accessor: "isActive",
    Cell: ({ row }) => <>{row?.values?.isActive ? "Active" : "Inactive"} {console.log("aaa",row?.values?.isActive)}</>,
  },
  {
    Header: "Launch Date",
    Footer: "Launch Date",
    accessor: "campaignStartDate",
    Cell: ({ row }) => <>{row?.values?.campaignEndDate ? DateFormat(row?.values?.campaignEndDate): '-'}</>,
  },
  {
    Header: "Expiry Date",
    Footer: "Expiry Date",
    accessor: "campaignEndDate",
    Cell: ({ row }) => <>{row?.values?.campaignEndDate ? DateFormat(row?.values?.campaignEndDate) :'-'}</>,
  },
];
