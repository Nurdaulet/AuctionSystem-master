import React, { Fragment, useState, useEffect } from "react";
import { Container, Row, Col } from "react-bootstrap";
import "react-input-range/lib/css/index.css";
import useItemsSearch from "../../../utils/hooks/useItemsSearch";
import useDebounce from "../../../utils/hooks/useDebounce";
import { Container as ItemsContainer } from "./Container/Container";
import { Search } from "./Search/Search";
import { useParams } from "react-router-dom";
import { Header } from "./Header/Header";

export const List = () => {

  let { categoryId, subCategoryId } = useParams();
  const [state, setState] = useState({
    title: null,
    getLiveItems: true,
    minPrice: null,
    maxPrice: null,
    startTime: null,
    endTime: null,
    categoryId: categoryId ?? null,
    subCategoryId: subCategoryId ?? null
  });

  const [pageNumber, setPageNumber] = useState(1);
  const query = useDebounce(state, 500);
  const {
    makeRequest,
    items,
    totalItemsCount,
    hasMore,
    loading,
    error,
  } = useItemsSearch(query, pageNumber, setPageNumber);

  useEffect(() => {
    makeRequest(); 
    // eslint-disable-next-line
  }, [query, makeRequest]);

  return (
    <Fragment>
      <Container>
        <Row>
          <Col lg={12}>
            <Header TextShown="All Items" totalItemsCount={totalItemsCount} />
          </Col>
          <Col lg={12}>
            <Row>
              <Search loading={loading} state={state} setState={setState} />
              <Col lg={8}>
                <ItemsContainer
                  items={items}
                  pageSize={state.pageSize}
                  hasMore={hasMore}
                  loading={loading}
                  error={error}
                  setPageNumber={setPageNumber}
                />
              </Col>
            </Row>
          </Col>
        </Row>
      </Container>
    </Fragment>
  );
};
