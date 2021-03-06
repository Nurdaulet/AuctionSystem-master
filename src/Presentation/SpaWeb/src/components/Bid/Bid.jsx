import React, { Fragment } from "react";
import { useState, useEffect } from "react";
import { Chat } from "./Chat/Chat";
import {
  Card,
  Col,
  Spinner,
  Button,
  InputGroup,
  FormControl,
} from "react-bootstrap";
import { HubConnectionBuilder } from "@aspnet/signalr";
import api from "../../utils/helpers/api";
import { BidHigherButton } from "./BidHigherButton";
import { toast } from "react-toastify";
import bidService from "../../services/bidService";
import { useCallback } from "react";
import { useBalance } from "../../utils/hooks/balance_context";
import { useAuth } from "../../utils/hooks/authHook";
export const Bid = ({
  itemId,
  startingPrice,
  minPriceIncrease,
  CounterContainer,
}) => {
  const balanceData = useBalance();
  const auth = useAuth();
  const [isLoading, setIsLoading] = useState(false);
  const [connection] = useState(() =>
    new HubConnectionBuilder().withUrl("https://localhost:5001/bidHub").build()
  );
  const [highestBid, setHighestBid] = useState(0);
  const [nextBidMinimumAmount, setNextBidMinimumAmount] = useState();
  const [winnerUserId, setWinnerUserId] = useState();
  const [biddingAmount, setBiddingAmount] = useState(0);
  const [messages, setMessages] = useState([]);

  const renewJwtAuthTokens = useCallback(async () => {
    await connection.stop();
    await api.post("/identity/refresh", {});
    await connection.start();
    try {
      await connection.invoke("Setup", itemId);
    } catch (error) {
      toast.warning(
        "Bidding is available only for signed in users. Please sign in!"
      );
    }
  }, [connection, itemId]);

  const handleOnClick = (amount) => {
    // console.log(balanceData.balance);
    // if (parseFloat(amount) > balanceData.balance) {
    //   toast.error(
    //     `Your balance is low`
    //   );
    //   return;
    // }


    if (parseFloat(amount) < nextBidMinimumAmount) {
      toast.error(
        `The minimum bidding amount is ${process.env.REACT_APP_CURRENCY_SIGN}${nextBidMinimumAmount}`
      );
      return;
    }

    setIsLoading(true);
    connection
      .invoke("CreateBidAsync", parseFloat(amount), itemId).then((response) => {
        balanceData.changeBalance(amount);
      })
      .catch(() => {
        toast.error(
          "Oops. Something went wrong while creating bid, please try again later"
        );
      });
    setIsLoading(false);
  };


  const fetchHighestBid = useCallback(() => {
    setIsLoading(true);
    bidService.getHighestBid(itemId).then((response) => {
      const amount = response.data.data?.amount;
      const winUserId = response.data.data?.userId;
      let highestBid;
      if (!amount) {
        highestBid = startingPrice;
      } else {
        highestBid = response.data.data.amount;
      }

      if (winUserId) {
        setWinnerUserId(winUserId);
      }

      const nextBiddingAmount = parseFloat(
        highestBid + minPriceIncrease
      ).toFixed(2);
      setHighestBid(highestBid);
      setNextBidMinimumAmount(nextBiddingAmount);
    });
    setIsLoading(false);

  }, [itemId, startingPrice, minPriceIncrease]);


  useEffect(() => {
    async function connectToSignalR() {
      setIsLoading(true);
      await connection.start();
      try {
        await connection.invoke("Setup", itemId);
      } catch (error) {
        await renewJwtAuthTokens();
      }

      fetchHighestBid();
      setIsLoading(false);

      connection.on("handleException", function (error) {
        toast.error(error);
      });

      connection.on("ReceiveMessage", function (bidAmount, userId) {
        setMessages((prev) => [
          ...prev,
          { bidAmount: parseFloat(bidAmount).toFixed(2), userId },
        ]);
        const nextBiddingAmount = parseFloat(
          bidAmount + minPriceIncrease
        ).toFixed(2);

        setWinnerUserId(userId);
        setHighestBid(bidAmount);
        setNextBidMinimumAmount(nextBiddingAmount);
      });
    }

    connectToSignalR();
  }, [
    itemId,
    connection,
    minPriceIncrease,
    fetchHighestBid,
    renewJwtAuthTokens,
  ]);

  return (
    <Fragment>
      <Col md={4}>
        <CounterContainer />
        <h4>
          Highest bid - {process.env.REACT_APP_CURRENCY_SIGN}
          {highestBid.toFixed(2)}
        </h4>
        <p>
          Min bid amount - {process.env.REACT_APP_CURRENCY_SIGN}
          {nextBidMinimumAmount}
        </p>
        <Card className="mt-3">
          <Card.Body>
            <InputGroup className="mb-3">
              <InputGroup.Prepend>
                <InputGroup.Text>
                  {process.env.REACT_APP_CURRENCY_SIGN}
                </InputGroup.Text>
              </InputGroup.Prepend>
              <FormControl
                placeholder="Amount to bid"
                type="number"
                onChange={(e) => setBiddingAmount(e.target.value)}
                min={nextBidMinimumAmount}
              />
              <Button
                className="mt-1"
                block
                variant="danger"
                size="lg"
                onClick={() => handleOnClick(biddingAmount)}
              >
                {isLoading ? (
                  <Fragment>
                    <Spinner
                      as="span"
                      animation="grow"
                      size="sm"
                      role="status"
                      aria-hidden="true"
                    />
                    Loading...
                  </Fragment>
                ) : (
                    "Bid"
                  )}
              </Button>
            </InputGroup>
            <div className="text-center mb-2">
              <div>
                {!isLoading ? auth.user.id == winnerUserId ? (<Button
      block
      variant="secondary"
      size="lg"
      active="false"
    >
      You are winning!
    </Button>) :  (
                  <BidHigherButton
                    isLoading = {isLoading}
                    handleOnClick={handleOnClick}
                    amount={nextBidMinimumAmount}
                  />
                ) : (
                    ""
                  )}
              </div>
            </div>
          </Card.Body>
        </Card>
        <Chat messages={messages} />
      </Col>
    </Fragment>
  );
};
