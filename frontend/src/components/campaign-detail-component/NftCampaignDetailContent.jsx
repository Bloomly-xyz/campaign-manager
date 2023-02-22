import React, { useEffect, useMemo, useState } from "react";
import {
  useGlobalFilter,
  usePagination,
  useSortBy,
  useTable,
} from "react-table";
import BasicTable from "../common/table-layout/BasicTable";
import Header from "../common/ui-components/Header";
import SearchFilter from "../common/ui-components/SearchFilter";
import { COLUMNS } from "./NftCampaignDetailComponents/CampaignDetailColumns";
import campaignService from "../../services/campaign.service";
import {  useLocation, useNavigate, useParams,  } from "react-router-dom";
import { useDispatch } from 'react-redux';
import { setLoader } from "../../redux/slices/loading/loaderSlice";


const NftCampaignDetailContent = () => {
    const navigate = useNavigate();
    const dispatch = useDispatch();
   const { id } = useParams();
   const location = useLocation();
   const campaignName  =location?.state || null ;
    const [campaignDetailsData, setCampaignDetailsData] = useState([])
 
  // React table suggests to memoize the columns and data for avoiding the re creation of data on every render
  const columns = useMemo(() => COLUMNS, []);
  const data = useMemo(() => campaignDetailsData, [campaignDetailsData]);
 

  useEffect(() => {
    
  getCampaignDetailData()
    return () => {
      
    }
    //eslint-disable-next-line
  }, [id])

  const getCampaignDetailData = () => {
    dispatch(setLoader(true))
    campaignService.getCampaignsDetail(id).then(response => {
     
      dispatch(setLoader(false))
      if(response?.statusCode === 200){
        if(response?.payload?.length > 0){
          const data = JSON.parse(response?.payload);
          setCampaignDetailsData(data)
        }else{
          setCampaignDetailsData([])
        } 
      }
    }).catch(error => {
      dispatch(setLoader(false))
    })
  }
  

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
    },

    useGlobalFilter,
    useSortBy,
    usePagination
  );

  const { globalFilter, pageIndex } = state;
  const handleBack = () => {
    navigate('/nft-campaigns')
  }

  return (
    <>
      <Header title={campaignName ?? ''} backIcon={true} handleBack={handleBack} />
      <div className="flex items-center justify-between mb-6">
        <div className=" grow">
          <SearchFilter filter={globalFilter} setFilter={setGlobalFilter}  />
        </div>
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
    </>
  );
};

export default NftCampaignDetailContent;
