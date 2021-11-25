import React, { useState, useEffect, Fragment } from "react";
import adminService from "../../services/adminService";
import { Spinner, Table } from "react-bootstrap";
import ReactPaginate from "react-paginate";
import { useParams } from "react-router-dom";
import moment from "moment";

export const TopUpList = () => {
  const [isLoading, setIsLoading] = useState(true);
  const [paginationQuery, setPaginationQuery] = useState({
    pageNumber: 1,
    pageSize: 7,
  });
  let { userId } = useParams();
  const [topUpListData, setTopUpListData] = useState([]);
  const [totalPages, setTotalPages] = useState();

  useEffect(() => {
    console.log(userId);
    adminService.getTopUpList(paginationQuery, userId).then((response) => {
      console.log(response);
      setTopUpListData(response.data.data);
      setTotalPages(response.data.totalPages);
      setIsLoading(false);
    });
  }, [paginationQuery]);

  const handlePageClick = (data) => {
    let pageNumber = data.selected + 1;
    setPaginationQuery((prev) => ({ ...prev, pageNumber }));
  };

  return isLoading ? (
    <Spinner animation="border" />
  ) : (
    <Fragment>
      <Table responsive striped bordered hover size="sm">
        <thead>
          <tr>
            <th>TopUp Date</th>
            <th>Amount</th>
            <th>Balance After TopUp</th>
          </tr>
        </thead>
        <tbody>
          {topUpListData.map((topUp, index) => {
            return (
              <tr key={index}>
                <td>{moment(topUp.created).format("DD/MM/YYYY hh:mm:ss")}</td>
                <td>
                  {topUp.amount}
                </td>
                <td>
                {topUp.saldoAccount}
                </td>
              </tr>
            );
          })}
        </tbody>
      </Table>
      <ReactPaginate
        previousLabel={"previous"}
        nextLabel={"next"}
        breakLabel={"..."}
        pageCount={totalPages}
        marginPagesDisplayed={3}
        pageRangeDisplayed={5}
        onPageChange={handlePageClick}
        breakClassName={"page-item"}
        breakLinkClassName={"page-link"}
        containerClassName={"pagination justify-content-end"}
        pageClassName={"page-item"}
        pageLinkClassName={"page-link"}
        previousClassName={"page-item"}
        previousLinkClassName={"page-link"}
        nextClassName={"page-item"}
        nextLinkClassName={"page-link"}
        activeClassName={"active"}
      />
    </Fragment>
  );
};
