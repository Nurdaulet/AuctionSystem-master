import React, { useState, useEffect } from "react";
import { Nav, Navbar, NavDropdown, Spinner } from "react-bootstrap";
import categoriesService from "../../../services/categoriesService";
import { history } from "../../..";
import "./Header.css";
import { Link } from "react-router-dom";

export const Header = () => {
  const [categories, setCategories] = useState([]);
  const [hoveredDropdowns, setHoveredDropdowns] = useState({});
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    retrieveCategories();
  }, []);

  const retrieveCategories = () => {
    categoriesService.getAll().then((response) => {
      setCategories(response.data.data);
      setIsLoading(false);
    });
  };

  const handleMouseOver = (e) => {
    setHoveredDropdowns({
      [e.target.id]: true,
    });
  };

  const handleMouseOut = (e) => {
    setHoveredDropdowns({
      [e.target.id]: false,
    });
  };

  return (
    <Navbar className="shadow mt-3" bg="light" expand="lg">
      <Navbar.Brand>Categories</Navbar.Brand>
      <Navbar.Toggle />
      <Navbar.Collapse>
        <Nav className="mx-auto">
          {isLoading ? (
            <div>
              Categories are being loaded... <Spinner animation="grow" />
            </div>
          ) : (
            categories.map((category, index) => {
              return (
                <NavDropdown
                  key={index}
                  id={index}
                  title={category.name}
                  // onClick={(e) => {
                  //   history.push(`/search/${category.id}`);
                  // }}
                  show={hoveredDropdowns[index]}
                  onMouseOver={(e) => handleMouseOver(e)}
                  onMouseOut={(e) => handleMouseOut(e)}
                >
                  {category.subCategories.map((subcategory, index) => {
                    return (
                      <NavDropdown.Item
                        id={subcategory.id}
                        key={index}
                        onClick={(e) => {
                          history.push(`/items/search/${category.id}/${e.target.id}`);
                        }}
                      >
                        {subcategory.name}
                      </NavDropdown.Item>
                    );
                  }
                  )}
                  
                </NavDropdown>
              );
            })
          )}
{isLoading ? null : <NavDropdown id="more_items" title={"More"} onClick={() => history.push("/items/search")}></NavDropdown>}
        </Nav>    
      </Navbar.Collapse>
    </Navbar>
  );
};
