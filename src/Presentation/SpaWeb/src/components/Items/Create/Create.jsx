import React, { useState, useEffect } from "react";
import { useForm } from "react-hook-form";
import {
  Container,
  Form,
  InputGroup,
  Button,
  Spinner,
  Row,
} from "react-bootstrap";
import categoriesService from "../../../services/categoriesService";
import moment from "moment";
import "./Create.css";
import {
  StartTimeDatePicker,
  EndTimeDatePicker,
} from "../../DateTimePicker/DateTimePicker";
import itemsService from "../../../services/itemsService";
import { ImageUploader } from "../../ImageUploader/ImageUploader";
import { history } from "../../..";
import { useTime } from "../../../utils/hooks/useTime";

export const Create = () => {
  const { register, handleSubmit, errors } = useForm();
  const [isLoading, setIsLoading] = useState(false);
  const [categories, setCategories] = useState([]);
  const [bodyTypes, setBodyTypes] = useState([]);
  const [sellerTypes, setSellerTypes] = useState([]);
  const [colors, setColors] = useState([]);
  const [extras, setExtras] = useState([]);
  const [regionalSpecs, setRegionalSpecs] = useState([]);
  const [fuelTypes, setFuelTypes] = useState([]);
  const [badges, setBadges] = useState([]);
  const [pictures, setPictures] = useState([]);
  const { currentTime } = useTime();
  const [startTime, setStartTime] = useState();
  const [endTime, setEndTime] = useState();
  const [selectedView, setSelectedView] = useState('6968329f-6e27-ec11-9a36-e4b97af0664c');
  useEffect(() => {
    setStartTime(moment(currentTime).add(2, "minutes").toDate());
    setEndTime(moment(currentTime).add(1, "week").add(10, "m").toDate());
  }, [currentTime]);

  useEffect(() => {
    categoriesService.getAllWithMakes().then((response) => {
      setCategories(response.data.data);
    });
    categoriesService.getAllOptions().then((response) => {
      setBodyTypes(response.data.data.bodyTypes);
      setSellerTypes(response.data.data.sellerTypes ?? []);
      setColors(response.data.data.colors ?? []);
      setExtras(response.data.data.extras ?? []);
      setRegionalSpecs(response.data.data.regionalSpecs ?? []);
      setFuelTypes(response.data.data.fuelTypes ?? []);
      setBadges(response.data.data.badges ?? []);
    });
  }, []);

  const onSubmit = (data, e) => {
    setIsLoading(true);
    var formData = new FormData(e.target);
    pictures.forEach((file) => {
      formData.append("pictures", file, file.name);
    });
    formData.append("startTime", startTime.toISOString("dd/mm/yyyy HH:mm"));
    formData.append("endTime", endTime.toISOString("dd/mm/yyyy HH:mm"));

    itemsService
      .createItem(formData)
      .then((response) => {
        history.push(`/items/details/${response.data.data.id}`);
      })
      .catch(() => setIsLoading(false));
  };

  const onDrop = (picture) => {
    setPictures(picture);
  };

  return (
    <Container>
      <div className="text-center w-md-75 w-lg-50 mx-auto my-4">
        <Form
          onSubmit={handleSubmit(onSubmit)}
          style={{
            border: "1px solid #e3e6ef",
            background: "#fff",
            padding: "2rem",
          }}
        >
          <h1>Create item</h1>
          <Form.Group controlId="title">
            <Form.Label>Title</Form.Label>
            <Form.Control
              name="title"
              placeholder="Some really cool item"
              ref={register({
                required: "Title field is required",
                maxLength: 120,
              })}
            />
            {errors.title && (
              <Form.Control.Feedback type="invalid">
                {errors.title.message}
              </Form.Control.Feedback>
            )}
          </Form.Group>
          <Form.Group controlId="Make">
            <Form.Label>Make</Form.Label>
            <Form.Control
              custom
              name="categoryId"
              ref={register({ required: "Make is required" })}
              onChange={(e) => setSelectedView(e.target.value)}
              as="select"
            >
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
          </Form.Group>
          <Form.Group controlId="Model">
            <Form.Label>Model</Form.Label>
            <Form.Control
              custom
              name="subCategoryId"
              ref={register({ required: "Model is required" })}
              as="select"
            >
              {categories.filter(({ id }) => id === selectedView).map((category) => {
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
          </Form.Group>
          <Form.Group controlId="description">
            <Form.Label>Description</Form.Label>
            <Form.Control
              name="description"
              as="textarea"
              placeholder="This item was owned by Hitler!!! WOW!"
              ref={register({
                required: "Description field is required",
                maxLength: 500,
              })}
            />
            {errors.description && (
              <Form.Control.Feedback type="invalid">
                {errors.description.message}
              </Form.Control.Feedback>
            )}
          </Form.Group>
          <Row>
            <Form.Group className="col" controlId="StartTime">
              <Form.Label>Start time</Form.Label>
              <StartTimeDatePicker
                startTime={startTime}
                setStartTime={setStartTime}
                endTime={endTime}
              />
            </Form.Group>
            <Form.Group className="col" controlId="EndTime">
              <Form.Label>End time</Form.Label>
              <EndTimeDatePicker
                endTime={endTime}
                setEndTime={setEndTime}
                startTime={startTime}
              />
            </Form.Group>
          </Row>
          <Row>
            <Form.Group className="col" controlId="CreatedYear">
              <Form.Label>Created Year</Form.Label>
              <StartTimeDatePicker
                startTime={startTime}
                setStartTime={setStartTime}
                endTime={endTime}
              />
            </Form.Group>
            <Form.Group className="col" controlId="odometer">
              <Form.Label>Odometer</Form.Label>
              <InputGroup>
                <Form.Control
                  name="odometer"
                  type="number"
                  placeholder="100"
                  aria-describedby="odometer"
                />
              </InputGroup>
              {/* {errors.startingPrice && (
                <Form.Control.Feedback type="invalid">
                  {errors.startingPrice.message}
                </Form.Control.Feedback>
              )} */}
            </Form.Group>
            <Form.Group className="col" controlId="horsePower">
              <Form.Label>Horse Power</Form.Label>
              <InputGroup>
                <Form.Control
                  name="horsePower"
                  type="number"
                  placeholder="100"
                  aria-describedby="horsePower"
                />
              </InputGroup>
              {/* {errors.startingPrice && (
                <Form.Control.Feedback type="invalid">
                  {errors.startingPrice.message}
                </Form.Control.Feedback>
              )} */}
            </Form.Group>
            <Form.Group className="col" controlId="doors">
              <Form.Label>Doors</Form.Label>
              <InputGroup>
                <Form.Control
                  name="doors"
                  type="number"
                  placeholder="2"
                  aria-describedby="doors"
                />
              </InputGroup>
              {/* {errors.startingPrice && (
                <Form.Control.Feedback type="invalid">
                  {errors.startingPrice.message}
                </Form.Control.Feedback>
              )} */}
            </Form.Group>
            <Form.Group className="col" controlId="cylinders">
              <Form.Label>Cylinders</Form.Label>
              <InputGroup>
                <Form.Control
                  name="cylinders"
                  type="number"
                  placeholder="4"
                  aria-describedby="cylinders"
                />
              </InputGroup>
              {/* {errors.startingPrice && (
                <Form.Control.Feedback type="invalid">
                  {errors.startingPrice.message}
                </Form.Control.Feedback>
              )} */}
            </Form.Group>
          </Row>
          <Row>
            <Form.Group className="col" controlId="steeringSide">
              <Form.Label>Steering Side</Form.Label>
              <Form.Control
                custom
                name="steeringSide"
                ref={register({ required: "SteeringSide is required" })}
                as="select"
              >
                <option
                  key={0}
                  value="Left"
                >
                  Left
                </option>
                <option
                  key={1}
                  value="Right"
                >
                  Right
                </option>
              </Form.Control>
            </Form.Group>
            <Form.Group className="col" controlId="bodyType">
              <Form.Label>BodyType</Form.Label>
              <Form.Control
                custom
                name="bodyTypeId"
                ref={register({ required: "BodyType is required" })}
                as="select"
              >
                {bodyTypes.map((bodyType, index) => {
                  return (
                    <option
                      key={index}
                      value={bodyType.id}
                    >
                      {bodyType.name}
                    </option>
                  );
                })}
              </Form.Control>
            </Form.Group>
            <Form.Group className="col" controlId="sellerType">
              <Form.Label>SellerType</Form.Label>
              <Form.Control
                custom
                name="sellerTypeId"
                ref={register({ required: "SellerType is required" })}
                as="select"
              >
                {sellerTypes.map((sellerType, index) => {
                  return (
                    <option
                      key={index}
                      value={sellerType.id}
                    >
                      {sellerType.name}
                    </option>
                  );
                })}
              </Form.Control>
            </Form.Group>
            <Form.Group className="col" controlId="color">
              <Form.Label>Color</Form.Label>
              <Form.Control
                custom
                name="colorId"
                ref={register({ required: "Color is required" })}
                as="select"
              >
                {colors.map((color, index) => {
                  return (
                    <option
                      key={index}
                      value={color.id}
                    >
                      {color.name}
                    </option>
                  );
                })}
              </Form.Control>
            </Form.Group>
          </Row>
          <Row>
            <Form.Group className="col" controlId="extra">
              <Form.Label>Extras</Form.Label>
              <Form.Control
                custom
                name="extraId"
                ref={register({ required: "Extra is required" })}
                as="select"
              >
                <option
                  key={0}
                  value="Left"
                >
                  Left
                </option>
                <option
                  key={1}
                  value="Right"
                >
                  Right
                </option>
              </Form.Control>
            </Form.Group>
            <Form.Group className="col" controlId="regionalSpec">
              <Form.Label>RegionalSpec</Form.Label>
              <Form.Control
                custom
                name="regionalSpecId"
                ref={register({ required: "RegionalSpec is required" })}
                as="select"
              >
                {regionalSpecs.map((regionalSpec, index) => {
                  return (
                    <option
                      key={index}
                      value={regionalSpec.id}
                    >
                      {regionalSpec.name}
                    </option>
                  );
                })}
              </Form.Control>
            </Form.Group>
            <Form.Group className="col" controlId="fuelType">
              <Form.Label>FuelType</Form.Label>
              <Form.Control
                custom
                name="fuelTypeId"
                ref={register({ required: "FuelType is required" })}
                as="select"
              >
                {fuelTypes.map((fuelType, index) => {
                  return (
                    <option
                      key={index}
                      value={fuelType.id}
                    >
                      {fuelType.name}
                    </option>
                  );
                })}
              </Form.Control>
            </Form.Group>
            <Form.Group className="col" controlId="Badge">
              <Form.Label>Badge</Form.Label>
              <Form.Control
                custom
                name="BadgeId"
                ref={register({ required: "Badge is required" })}
                as="select"
              >
                {badges.map((badge, index) => {
                  return (
                    <option
                      key={index}
                      value={badge.id}
                    >
                      {badge.name}
                    </option>
                  );
                })}
              </Form.Control>
            </Form.Group>
          </Row>
          <Form.Group controlId="startingPrice">
            <Form.Label>Starting Price</Form.Label>
            <InputGroup className="mb-3">
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
                  required: "Starting Price field is required",
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
          <Form.Group controlId="minIncrease">
            <Form.Label>
              Min price increase (
              {
                <span className="text-muted">
                  We suggest to input the 10% value of the starting price
                </span>
              }
              )
            </Form.Label>
            <InputGroup className="mb-3">
              <InputGroup.Prepend>
                <InputGroup.Text id="min-increase">
                  {process.env.REACT_APP_CURRENCY_SIGN}
                </InputGroup.Text>
              </InputGroup.Prepend>
              <Form.Control
                name="minIncrease"
                type="number"
                aria-describedby="min-increase"
                ref={register({
                  required: "Min price increase field is required",
                  min: 0.01,
                  max: 1000000000,
                })}
              />
            </InputGroup>
            {errors.minIncrease && (
              <Form.Control.Feedback type="invalid">
                {errors.minIncrease.message}
              </Form.Control.Feedback>
            )}
          </Form.Group>
          {/* <Form.Group controlId="category">
            <Form.Label>Category</Form.Label>
            <Form.Control
              custom
              name="subCategoryId"
              ref={register({ required: "Category is required" })}
              as="select"
            >
              <option disabled>Select category</option>
              {categories.map((category) => {
                return category.subCategories.map((subCategory, index) => {
                  return (
                    <option key={index} value={subCategory.id}>
                      {subCategory.name}
                    </option>
                  );
                });
              })}
            </Form.Control>
          </Form.Group> */}
          <Form.Group>
            <ImageUploader onChange={onDrop} />
          </Form.Group>
          {!isLoading ? (
            <Button variant="primary" type="submit">
              Submit
            </Button>
          ) : (
            <Button variant="primary" disabled>
              <Spinner
                as="span"
                animation="grow"
                size="sm"
                role="status"
                aria-hidden="true"
              />
              Creating...
            </Button>
          )}
        </Form>
      </div>
    </Container>
  );
};
