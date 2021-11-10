import React, { Fragment, useEffect } from "react";
import { Nav, Navbar, Container, NavDropdown, Button } from "react-bootstrap";
import { history } from "..";
import { useAuth } from "../utils/hooks/authHook";
import { useBalance } from "../utils/hooks/balance_context";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faUser } from "@fortawesome/free-solid-svg-icons";
import { makeStyles } from "@material-ui/core";
import { Autorenew } from "@material-ui/icons";
import clsx from "clsx";

const useStyles = makeStyles((theme) => ({
  refresh: {
    cursor: "pointer",
    margin: "auto",
    "&.spin": {
      animation: "$spin 1s 1",
      pointerEvents: 'none'
    }
  },
  "@keyframes spin": {
    "0%": {
      transform: "rotate(0deg)"
    },
    "100%": {
      transform: "rotate(360deg)"
    }
  }
}));

export const NavMenu = () => {
  const balance = useBalance();
  const auth = useAuth();

  const [spin, setSpin] = React.useState(false);
  const classes = useStyles();

  const refreshCanvas = () => {
    setSpin(true);
    balance.changeBalance();
    setTimeout(() => {
      setSpin(false);
    }, 1000);
  };

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
              <Nav.Link onClick={() => history.push("/items/search")}>Items</Nav.Link>
              <Nav.Link onClick={() => history.push("/contact")}>
                Contact us
              </Nav.Link>\
              {auth.user ? (<Button variant="primary" onClick={() => history.push("/items/create")}>Create New</Button>) : (<Fragment></Fragment>)}
            </Nav>
            {auth.user ? (
              <Nav>
                <Nav.Link>
                  Balance: {balance.balance}
                  <Autorenew
                  className={clsx({
                    [classes.refresh]: true,
                    spin: spin
                  })}
                  onClick={refreshCanvas}
                  spin={360}
                />
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
