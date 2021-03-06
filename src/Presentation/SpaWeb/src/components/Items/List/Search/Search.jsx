import React, { useState, useEffect } from "react";
import { Col, Form, Spinner } from "react-bootstrap";
import InputRange from "react-input-range";
import "react-input-range/lib/css/index.css";
import categoriesService from "../../../../services/categoriesService";
import {
  EndTimeDatePicker,
  StartTimeDatePicker,
} from "../../../DateTimePicker/DateTimePicker";
import moment from "moment";
import { history } from "../../../..";
import "./Search.css";

export const Search = ({ loading, state, setState }) => {
  const [price, setPrice] = useState({ min: 0, max: 50000 });
  const [startTime, setStartTime] = useState(
    moment().add(2, "minutes").toDate()
  );

  const [selectedView, setSelectedView] = useState(state.categoryId ?? '');

  const [endTime, setEndTime] = useState(
    moment().add(1, "months").add(10, "m").toDate()
  );
  const [isDateDisabled, setIsDateDisabled] = useState(true);
  const [categories, setCategories] = useState([]);

  //It's better to extract fecth categories logic in store because we're repeating unnecessary requests...
  //but let's leave it as it is now :D

  useEffect(() => {
    retrieveCategories();
  }, []);

  useEffect(() => {
    if (!isDateDisabled) {
      setState((prev) => ({
        ...prev,
        getLiveItems: false,
        startTime: startTime.toISOString("dd/mm/yyyy HH:mm"),
        endTime: endTime.toISOString("dd/mm/yyyy HH:mm"),
      }));
    }
  }, [startTime, endTime, setState, isDateDisabled]);

  const retrieveCategories = () => {
    categoriesService.getAllWithMakes().then((response) => {
      setCategories(response.data.data);
    });
  };

  return (
    <Col className="mt-5 mt-lg-0" lg={4}>
      <div>
        <div className="search-area default-item-search">
          <p>
            <i>Filters</i>
          </p>

          <Form>
            <Form.Group controlId="Title">
              <Form.Label>Title</Form.Label>
              <Form.Control
                onChange={(e) => {
                  let value = e.target.value;
                  setState((prev) => ({ ...prev, title: value }));
                }}
                type="input"
                placeholder="Search for given item by title"
                aria-label="Item search"
                aria-describedby="basic-addon1"
              />
            </Form.Group>
            <Form.Group controlId="Make">
              <Form.Label>Make</Form.Label>
              {!loading ? (
                <Form.Control
                  as="select"
                  value={state.categoryId ?? ""}
                  onChange={(e) => {      
                    if (e.target.value !== "All"){
                      history.replace(`/items/search/${e.target.value}`);
                    } else {
                      history.replace("/items/search");
                    }
                    let value = e.target.value;
                    if(value === "All"){
                      value = null;
                    }
                    setState((prev) => ({ ...prev, categoryId: value, subCategoryId: null }));
                    setSelectedView(e.target.value);        
                  }}
                >
                  <option onClick={() => history.replace("/items/search")}>
                    All
                  </option>
                  {categories.map((category, index) => {
                    return (
                        <option
                          key={index}
                          value={category.id}
                        >
                          {category.name}
                        </option>
                      );                    
                  })}
                </Form.Control>
              ) : (
                <div>
                  <Spinner animation="border" />
                </div>
              )}
            </Form.Group>
            <Form.Group controlId="Model">
              <Form.Label>Model</Form.Label>
              {!loading ? (
                <Form.Control
                  as="select"
                  value={state.subCategoryId ?? ""}
                  onChange={(e) => {    
                    if (e.target.value !== "All"){
                      history.replace(`/items/search/${selectedView}/${e.target.value}`);
                    } else {
                      history.replace(`/items/search/${selectedView}`);
                    }
                    let value = e.target.value;
                    if(value === "All"){
                      value = null;
                    }
                    setState((prev) => ({ ...prev, subCategoryId: value }));    
                  }}
                >
                  <option>
                    All
                  </option>
                  {categories.filter(({id}) => id === selectedView).map((category) => {
                    return category.subCategories.map((subCategory, index) => {
                      return (
                        <option
                          key={index} 
                          value={subCategory.id}
                        >
                          {subCategory.name}
                        </option>
                      );
                    });
                  })}
                </Form.Control>
              ) : (
                <div>
                  <Spinner animation="border" />
                </div>
              )}
            </Form.Group>
            <Form.Group controlId="liveItems">
              <Form.Check
                onChange={() =>
                  setState((prev) => ({
                    ...prev,
                    getLiveItems: !state.getLiveItems,
                  }))
                }
                type="switch"
                label="Live items"
                checked={state.getLiveItems}
              />
            </Form.Group>
            <Form.Group controlId="Price">
              <p className="mb-4">Price</p>
              <InputRange
                formatLabel={(value) =>
                  `${process.env.REACT_APP_CURRENCY_SIGN}${value}`
                }
                step={100}
                value={price}
                maxValue={50000}
                minValue={0}
                onChange={(value) => {
                  setPrice(value);
                  setState((prev) => ({
                    ...prev,
                    minPrice: value.min <= 0 ? null : value.min,
                    maxPrice: price.max,
                  }));
                }}
              />
            </Form.Group>
            <Form.Group className="mt-5" controlId="isDateDisabled">
              <Form.Check
                onChange={() => {
                  setIsDateDisabled(!isDateDisabled);
                  if (!isDateDisabled) {
                    setState((prev) => ({
                      ...prev,
                      startTime: null,
                      endTime: null,
                    }));
                  }
                }}
                type="switch"
                label="Filter by date"
              />
            </Form.Group>
            <Form.Group controlId="StartingTime">
              <p>Starting time</p>
              <StartTimeDatePicker
                disabled={isDateDisabled}
                readOnly={true}
                startTime={startTime}
                setStartTime={setStartTime}
                endTime={endTime}
              />
            </Form.Group>
            <Form.Group controlId="EndTime">
              <p>End time</p>
              <EndTimeDatePicker
                disabled={isDateDisabled}
                readOnly={true}
                endTime={endTime}
                setEndTime={setEndTime}
                startTime={startTime}
              />
            </Form.Group>
          </Form>
        </div>
      </div>
    </Col>
  );
};
