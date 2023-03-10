import React, { useEffect, useMemo, useState } from "react";
import {
  useGlobalFilter,
  usePagination,
  useSortBy,
  useTable,
} from "react-table";

import images from "../../constants/images-constants/images";
import Modal from "../common/modal-layout/Modal";
import BasicTable from "../common/table-layout/BasicTable";
import Header from "../common/ui-components/Header";
import SearchFilter from "../common/ui-components/SearchFilter";
import ChooseProjectModal from "../modals-components/ChooseProjectModal";
import { COLUMNS } from "./NftCampaignListingComponent/NftCampaignColumns";
import campaignService from "../../services/campaign.service";
import { useDispatch, useSelector } from "react-redux";
import { setLoader } from "../../redux/slices/loading/loaderSlice";
import {  useNavigate } from "react-router-dom";

const NFTCompaignListing = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate()
  const [activeTab, setActiveTab] = useState("all");
  const [openCreateCampaignModal, setOpenCreateCampaignModal] = useState(false);
  const [campaignData, setCampaignData] = useState([]);
  // React table suggests to memoize the columns and data for avoiding the re creation of data on every render
  const columns = useMemo(() => COLUMNS, []);
  const data = useMemo(() => campaignData, [campaignData]);
  const { adminInfo } = useSelector((state) => state.user);
  useEffect(() => {
    getAllCampaign();
    //eslint-disable-next-line
  }, []);

  const getAllCampaign = () => {
    dispatch(setLoader(true));
    campaignService
      .getCampaigns({Id:adminInfo?.id})
      .then((response) => {
        dispatch(setLoader(false));
        if (response?.statusCode === 200) {
          if (response?.payload?.length > 0) {
            setCampaignData(response?.payload?.reverse());
          } else {
            setCampaignData([]);
          }
        }
      })
      .catch((error) => {
        dispatch(setLoader(false));
      });
  };

 

  const tableHooks = (hooks) => {
    hooks.visibleColumns.push((columns) => [
      ...columns,
      {
        Header: () => (
          <div
            style={{
              textAlign: "center",
              flexGrow: 1,
            }}
          >
            {" "}
            Action
          </div>
        ),
        accessor: "Actions",
        disableSortBy: true,
        Cell: ({ row }) => (
          <>
            
             
                <div className="flex justify-center">
                  <img
                   onClick={()=>{navigate(`/campaign-detail/${row.values.campaignUuid}`,{state : row?.values?.campaignName })}}
                    className="cursor-pointer "
                    src={images.ViewIcon}
                    alt="icon"
                  />
                </div>
            
              
            
          </>
        ),
      },
    ]);
  };

  const {
    getTableProps,
    getTableBodyProps,
    headerGroups,
    rows,
    page,
    nextPage,
    canNextPage,
    previousPage,
    canPreviousPage,
    pageOptions,
    prepareRow,
    gotoPage,
    pageCount,
    state, // For filtering
    setGlobalFilter, // For filtering
  } = useTable(
    {
      // ES6 shorthand notation having same key value name
      columns,
      data,
      initialState: {
        hiddenColumns: ["campaignUuid"],
      },
    },
    tableHooks,
    useGlobalFilter,
    useSortBy,
    usePagination
  );

  const handleTabClick = (option) => {
    setActiveTab(option);
    setGlobalFilter("");
    if (option === "all") return;
    if(option ==='physical')
    setGlobalFilter("");
    // setGlobalFilter(option);
  };

  const handleCreateCampaign = () => {
    setOpenCreateCampaignModal(true);
  };

  const { globalFilter, pageIndex } = state;
  return (
    <>
      <Header title="Create your campaign and add your utility" />
      <div className="flex items-center mb-6">
        <button
          onClick={() => handleTabClick("all")}
          className={`text-[#12221A] hover:bg-[#213E28] ${
            activeTab === "all" ? "bg-[#213E28] text-white" : "bg-white "
          } hover:text-white rounded-t font-bold text-base py-2 px-8  mr-3`}
        >
          ALL
        </button>
        <button
          onClick={() => handleTabClick("physical")}
          className={`text-[#12221A] hover:bg-[#213E28] ${
            activeTab === "physical" ? "bg-[#213E28] text-white" : "bg-white"
          } hover:text-white rounded-t font-bold text-base py-2 px-8  mr-3`}
        >
          Physical Utility
        </button>
        <button
          disabled
          // onClick={() => handleTabClick("digital")}
          className={`text-[#12221A] hover:bg-[#213E28] ${
            activeTab === "digital" ? "bg-[#213E28] text-white" : "bg-white"
          }  hover:text-white rounded-t font-bold text-base py-2 px-8 cursor-not-allowed mr-3`}
        >
          Digital Utility
        </button>
        <button
          disabled
          // onClick={() => handleTabClick("experiential")}
          className={`text-[#12221A] hover:bg-[#213E28] ${
            activeTab === "experiential"
              ? "bg-[#213E28] text-white"
              : "bg-white"
          } hover:text-white rounded-t font-bold text-base py-2 px-8 cursor-not-allowed mr-3`}
        >
          Experiential Utility
        </button>
      </div>
      <div className="flex items-center justify-between mb-6">
        <div className="max-w-[714px] grow ">
          <SearchFilter filter={globalFilter} setFilter={setGlobalFilter} />
        </div>
        <button
          className="btn-primary max-w-[200px]"
          onClick={handleCreateCampaign}
        >
          Create Campaign
        </button>
      </div>
      <div>
        <BasicTable
          columns={columns}
          data={data}
          getTableProps={getTableProps}
          getTableBodyProps={getTableBodyProps}
          headerGroups={headerGroups}
          page={page}
          nextPage={nextPage}
          canNextPage={canNextPage}
          previousPage={previousPage}
          canPreviousPage={canPreviousPage}
          prepareRow={prepareRow}
          pageOptions={pageOptions}
          pageIndex={pageIndex}
          gotoPage={gotoPage}
          pageCount={pageCount}
          // getRowDataDetail={getRowDataDetail}
          rows={rows}
        />
      </div>
      {openCreateCampaignModal && (
        <Modal
          openModal={openCreateCampaignModal}
          closeModal={setOpenCreateCampaignModal}
          children={
            <ChooseProjectModal closeModal={setOpenCreateCampaignModal} />
          }
          modal_Id="choose_Campaign_Modal"
          mwidth={"616px"}
        />
      )}
    </>
  );
};

export default NFTCompaignListing;
