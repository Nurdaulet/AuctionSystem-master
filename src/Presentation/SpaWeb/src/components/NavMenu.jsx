import React, { Fragment, useEffect } from "react";
import { Nav, Navbar, Container, NavDropdown, Button } from "react-bootstrap";
import { history } from "..";
import { useAuth } from "../utils/hooks/authHook";
import { useBalance } from "../utils/hooks/balance_context";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faUser } from "@fortawesome/free-solid-svg-icons";


export const NavMenu = () => {
  const balance = useBalance();
  const auth = useAuth();
  // useEffect(() => {
  //   balance.changeBalance();
  // }, []); 
  return (
    <header>
      <Navbar bg="dark" variant="dark" expand="lg">
        <Container>
          <Navbar.Brand href="/">AuctionSystem</Navbar.Brand>
          <Navbar.Toggle />
          <Navbar.Collapse>
            <Nav className="mr-auto">
              <Nav.Link onClick={() => history.push("/items")}>Items</Nav.Link>
              <Nav.Link onClick={() => history.push("/contact")}>
                Contact us
              </Nav.Link>\
              {auth.user ? (<Button variant="primary" onClick={() => history.push("/items/create")}>Create New</Button>):(<Fragment></Fragment>)}
            </Nav>
            {auth.user ? (
              <Nav>
                <Nav.Link onClick={() => balance.changeBalance()}>
                  Balance: {balance.balance}
                </Nav.Link>
                <NavDropdown
                  title={<FontAwesomeIcon icon={faUser} />}
                  style={{ textColor: "white" }}
                >
                  {auth.user.isAdmin ? (
                    <NavDropdown.Item
                      onClick={() => {
                        history.push("/administration");
                      }}
                    >
                      Administration
                    </NavDropdown.Item>
                  ) : (
                      ""
                    )}
                  {/* <NavDropdown.Item
                    onClick={() => {
                      history.push("/items/create");
                    }}
                  >
                    Create Item
                  </NavDropdown.Item> 
                  <NavDropdown.Divider />*/}
                  <NavDropdown.Item
                    onClick={() => {
                      auth.signOut();
                      history.push("/");
                    }}
                  >
                    Logout
                  </NavDropdown.Item>
                </NavDropdown>
              </Nav>
            ) : (
                <Fragment>
                  <Nav>
                    <Nav.Link onClick={() => history.push("/sign-up")}>
                      Sign up
                  </Nav.Link>
                    <Nav.Link onClick={() => history.push("/sign-in")}>
                      Login
                  </Nav.Link>
                  </Nav>
                </Fragment>
              )}
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </header>
  );
};
