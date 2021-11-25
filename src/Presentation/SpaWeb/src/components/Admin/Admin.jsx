import React, { useState, useEffect, Fragment } from "react";
import adminService from "../../services/adminService";
import { Spinner, Table, Form, Button, Modal, InputGroup } from "react-bootstrap";
import ReactPaginate from "react-paginate";
import { toast } from "react-toastify";
import { Link } from "react-router-dom";
import { useForm } from "react-hook-form";
import { history } from "../..";
export const Admin = () => {
  const { register, handleSubmit, errors } = useForm();
  const [isLoading, setIsLoading] = useState(true);
  const [paginationQuery, setPaginationQuery] = useState({
    pageNumber: 1,
    pageSize: 7,
  });
  const [users, setUsers] = useState([]);
  const [totalPages, setTotalPages] = useState();
  const [selectedUserEmail, setSelectedUserEmail] = useState();
  const [selectedUserId, setSelectedUserId] = useState();
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = (userEmail, userId) => { setSelectedUserEmail(userEmail); setSelectedUserId(userId); setShow(true); }

  useEffect(() => {
    adminService.getUsers(paginationQuery).then((response) => {
      setUsers(response.data.data);
      setTotalPages(response.data.totalPages);
      setIsLoading(false);
    });
  }, [paginationQuery]);


  const onSubmit = (data, e) => {
    setIsLoading(true);
    console.log(selectedUserId);
    console.log(data.startingPrice);
    adminService.makeTopUp(selectedUserId, data.startingPrice).then((response) => {
      setShow(false);
      adminService.getUsers(paginationQuery).then((response) => {
        setUsers(response.data.data);
        setTotalPages(response.data.totalPages);
        setIsLoading(false);
      });
    });
  };

  const handlePageClick = (data) => {
    let pageNumber = data.selected + 1;
    setPaginationQuery((prev) => ({ ...prev, pageNumber }));
  };

  const handleAddUserToRole = (event, index) => {
    const role = event.target.value;
    const email = users[index].email;

    adminService.addToRole(email, role).then(() => {
      setUsers((prev) => [
        ...prev.map((user, currentIndex) => {
          if (currentIndex === index) {
            return {
              ...user,
              currentRoles: [...user.currentRoles, role],
              nonCurrentRoles: user.nonCurrentRoles.filter(
                (nonCurrentRole) => nonCurrentRole !== role
              ),
            };
          }

          return user;
        }),
      ]);
      toast.success(`${email} has been successfully promoted to ${role}`);
    });
  };

  const handleRemoveUserFromRole = (event, index) => {
    const role = event.target.value;
    const email = users[index].email;

    adminService.removeFromRole(email, role).then(() => {
      setUsers((prev) => [
        ...prev.map((user, currentIndex) => {
          if (currentIndex === index) {
            return {
              ...user,
              currentRoles: user.currentRoles.filter(
                (currentRole) => currentRole !== role
              ),

              nonCurrentRoles: [...user.nonCurrentRoles, role],
            };
          }

          return user;
        }),
      ]);

      toast.success(`${email} has been successfully demoted from ${role}`);
    });
  };

  return isLoading ? (
    <Spinner animation="border" />
  ) : (
    <Fragment>
      <Table responsive striped bordered hover size="sm">
        <thead>
          <tr>
            <th>Email</th>
            <th>Roles</th>
            <th>Add to role</th>
            <th>Remove from role</th>
            <th>Balance</th>
            <th>Control</th>
          </tr>
        </thead>
        <tbody>
          {users.map((user, index) => {
            return (
              <tr key={index}>
                <td>{user.email}</td>
                <td>
                  {user.currentRoles.length !== 0 ? user.currentRoles : "User"}
                </td>
                <td>
                  <Form.Group>
                    <Form.Control
                      as="select"
                      custom
                      value="Select role"
                      onChange={(e) => handleAddUserToRole(e, index)}
                    >
                      <option disabled>Select role</option>
                      {user.nonCurrentRoles.map((role, index) => {
                        return <option key={index}>{role}</option>;
                      })}
                    </Form.Control>
                  </Form.Group>
                </td>
                <td>
                  <Form.Group>
                    <Form.Control
                      as="select"
                      custom
                      value="Select role"
                      onChange={(e) => handleRemoveUserFromRole(e, index)}
                    >
                      <option disabled>Select role</option>
                      {user.currentRoles.map((role, index) => {
                        return <option key={index}>{role}</option>;
                      })}
                    </Form.Control>
                  </Form.Group>
                </td>
                <td>
                  {user.balance}
                </td>
                <td>
                  {
                    user.currentRoles.length !== 0 ? "" :
                      <Fragment>
                        <>
                          <Button variant="secondary" onClick={() => history.replace(`/topUpHistory/${user.id}`)}>
                            TopUp History
                          </Button>
                        </>
                        <br /> <br />
                        <>
                          <Button variant="primary" onClick={() => handleShow(user.email, user.id)}>
                            New TopUp
                          </Button>
                          <Modal show={show} onHide={handleClose}>
                            <Modal.Header closeButton>
                              <Modal.Title>Top Up for {selectedUserEmail}</Modal.Title>
                            </Modal.Header>
                            <Form
                              onSubmit={handleSubmit(onSubmit)}
                              style={{
                                border: "1px solid #e3e6ef",
                                background: "#fff",
                                padding: "2rem",
                              }}
                            >
                              <Modal.Body>
                                <Form.Group controlId="startingPrice">
                                  <Form.Label>Top Up Amount</Form.Label>
                                  <InputGroup>
                                    <InputGroup.Prepend>
                                      <InputGroup.Text id="starting-price">
                                        {process.env.REACT_APP_CURRENCY_SIGN}
                                      </InputGroup.Text>
                                    </InputGroup.Prepend>
                                    <Form.Control
                                      name="startingPrice"
                                      type="number"
                                      placeholder="100"
                                      aria-describedby="starting-price"
                                      ref={register({
                                        required: "Amount field is required",
                                        min: 0.01,
                                        max: 1000000000,
                                      })}
                                    />
                                  </InputGroup>
                                  {errors.startingPrice && (
                                    <Form.Control.Feedback type="invalid">
                                      {errors.startingPrice.message}
                                    </Form.Control.Feedback>
                                  )}
                                </Form.Group>
                              </Modal.Body>
                              <Modal.Footer>
                                <Button variant="secondary" onClick={handleClose}>
                                  Close
                                </Button>
                                <Button variant="primary" type="submit">
                                  Save Changes
                                </Button>
                              </Modal.Footer>
                            </Form>
                          </Modal>
                        </>
                      </Fragment>
                  }
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
