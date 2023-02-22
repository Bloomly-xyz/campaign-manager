import React, { useState } from "react";
import images from "../../../constants/images-constants/images";

const BasicTable = (props) => {
  const {
    getTableProps,
    getTableBodyProps,
    headerGroups,
    rows,
    page,
    nextPage,
    previousPage,
    canNextPage,
    canPreviousPage,
    pageOptions,
    pageIndex,
    gotoPage,
    pageCount,
    prepareRow,
    hideHeader,
  } = props;

  const [paginationCount, setPaginationCount] = useState(0);

  const StyledArrowDownwardIcon = () => {
    return <img className="ml-2" src={images.DecendingIcon} alt="" />;
  };

  const StyledArrowUpwardIcon = () => {
    return <img className="ml-2" src={images.AscendingIcon} alt="" />;
  };

  return (
    <>
      <div className="relative overflow-x-auto shadow-md sm:rounded-lg">
        <table
          className="w-full text-xs text-left text-white rounded-md border-2 border-[#ffffff1a]"
          {...getTableProps()}
        >
          {hideHeader ? (
            <></>
          ) : (
            <thead className="text-xs font-bold text-[#12221A] capitalize uppercase bg-[#F3F4F4]">
              {headerGroups.map((headerGroup) => (
                <tr {...headerGroup.getHeaderGroupProps()}>
                  {headerGroup.headers.map((column) => (
                    <th
                      scope="col"
                      className={`py-4 px-6 ${
                        column.Header === "Action" && "text-center"
                      }`}
                      {...column.getHeaderProps(column.getSortByToggleProps())}
                    >
                      <div className="flex items-center">
                        {column.render("Header")}
                        {column.isSorted ? (
                          <>
                            {column.isSortedDesc ? (
                              <span>
                                {" "}
                                <StyledArrowDownwardIcon />
                              </span>
                            ) : (
                              <span>
                                {" "}
                                <StyledArrowUpwardIcon />
                              </span>
                            )}
                          </>
                        ) : (
                          ""
                        )}
                      </div>
                    </th>
                  ))}
                </tr>
              ))}
            </thead>
          )}
          {page?.length > 0 ? (
            <>
              <tbody
                className="min-h-[calc(100vh-390px)] bg-white"
                {...getTableBodyProps()}
              >
                {page.map((row) => {
                  prepareRow(row);
                  return (
                    <tr
                      className={"hover:bg-[#A5F33C]/25"}
                      {...row.getRowProps()}
                    >
                      {row.cells.map((cell) => {
                        return (
                          <td
                            className={`py-2 px-6 text-[#12221A] font-medium ${
                              row.values.status === "Deactive" &&
                              "text-zinc-500"
                            } `}
                            {...cell.getCellProps()}
                          >
                            {cell.render("Cell")}
                          </td>
                        );
                      })}
                    </tr>
                  );
                })}
              </tbody>
            </>
          ) : (
            <tbody className="h-[calc(100vh-390px)]">
              <tr className="">
                <td
                  className=""
                  colspan={headerGroups[0]?.headers?.length || "8"}
                >
                  <div className="flex flex-col items-center justify-center my-4 ">
                    <img src={images.NotfoundRecordIcon} alt="icon" />
                    <h6 className="text-base font-semibold text-[#12221A]">
                      Sorry we couldn’t find any matches for that
                    </h6>
                    <p className="text-xs text-[#12221A]/70">
                      Please try searching with another term
                    </p>
                  </div>
                </td>
              </tr>
            </tbody>
          )}
        </table>
        {/* Pagination starts here, need to create separate component */}
      </div>
      <div className="flex items-center justify-between mt-4 mb-8">
        <span className="mr-2 text-xs font-sm">
          Showing {pageIndex + 1} to 10{" "}
          <span className="text-slate-400">of {rows?.length}</span>{" "}
        </span>
        <div>
          {/* <button className="px-3 py-2 bg-black disabled:text-slate-500" disabled={!canPreviousPage} onClick={() => gotoPage(0)}> {'<<'} </button> */}
          <button
            className="w-10 h-10 p-2 px-3 py-2 mr-1 text-center text-[#12221A] bg-[#F3F4F4] rounded-lg hover:bg-bg-[#213E28]/50 disabled:bg-[#A4B1A7]/40 disabled:text-slate-500"
            disabled={!canPreviousPage}
            onClick={() => {
              previousPage();
              if (paginationCount > 0) setPaginationCount(paginationCount - 1);
            }}
          >
            <span className="text-2xl leading-none">{"<"}</span>
          </button>

          {pageOptions
            .slice(paginationCount, paginationCount + 3)
            ?.map((number) => {
              return (
                <button
                  key={number}
                  onClick={() => {
                    setPaginationCount(number);
                    gotoPage(number);
                  }}
                  className={`disabled:text-slate-500
                                 ${
                                   pageIndex + 1 === number + 1 &&
                                   "bg-[#213E28] text-white "
                                 }
                                 mx-[2px] 
                                 text-[#12221A]
                                 text-center w-10 h-10
                                 rounded-lg hover:bg-[#213E28]/50 bg-[#F3F4F4] px-3 py-2`}
                >
                  {number + 1}
                </button>
              );
            })}
          <button className="text-[#12221A] mx-[2px] text-center w-10 h-10 bg-[#F3F4F4] rounded-lg px-3 py-2">
            ...
          </button>
          {pageOptions.slice(pageCount - 1, pageCount)?.map((number) => {
            return (
              <button
                key={number}
                onClick={() => {
                  setPaginationCount(number);
                  gotoPage(number);
                }}
                className={`disabled:text-slate-500
                                 ${
                                   pageIndex + 1 === number + 1 &&
                                   "bg-[#213E28]/50"
                                 }
                                 mx-[2px]
                                 text-[#12221A]
                                 text-center w-10 h-10
                                 rounded-lg hover:bg-[#213E28]/50 bg-[#F3F4F4] px-3 py-2`}
              >
                {number + 1}
              </button>
            );
          })}
          {/* <button className="p-2 mr-2 text-white bg-blue-500 rounded-md hover:bg-blue-600 disabled:bg-slate-700 disabled:text-slate-500"
                            disabled={!canNextPage}
                            onClick={() => nextPage()}>
                            next
                        </button> */}
          <button
            className="w-10 h-10 p-2 rounded-lg px-3 py-2 ml-1 mr-2 text-center text-[#12221A] bg-[#F3F4F4]  hover:bg-[#213E28]/50 disabled:bg-[#A4B1A7]/40 disabled:text-slate-500"
            disabled={!canNextPage}
            onClick={() => {
              nextPage();
              setPaginationCount(paginationCount + 1);
            }}
          >
            <span className="text-2xl leading-none">{">"}</span>
          </button>
        </div>
      </div>
    </>
  );
};

export default BasicTable;
