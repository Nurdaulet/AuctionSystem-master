import React, { useState } from "react";
import { Form, Button } from "react-bootstrap";
import { useForm } from "react-hook-form";
import { history } from "../..";
import { toast } from "react-toastify";

export const ConfirmAccount = ({ auth, email }) => {
  const { register, handleSubmit } = useForm();
  const [isLoading, setIsLoading] = useState(false);
  const onSubmit = (data) => {
    setIsLoading(true);
    auth.confirmAccount(data).then(() => {
      history.push("/");
      toast.success(
        "Your account has been confirmed successfully. You're now able to sign in."
      );
    });
    setIsLoading(false);
  };

  return (
    <div className="text-center w-md-75 w-lg-50 mx-auto my-4">
      <Form
        style={{
          border: "1px solid #e3e6ef",
          background: "#fff",
          padding: "2rem",
        }}
        onSubmit={handleSubmit(onSubmit)}
      >
        <Form.Control.Feedback type="valid">
          Please check your email and spam for the verification code.
        </Form.Control.Feedback>
        <Form.Group>
          <Form.Label>Verification Code - 4 digits</Form.Label>
          <Form.Control
            type="text"
            name="code"
            ref={register({ required: true, minLength: 4, maxLength: 4 })}
          ></Form.Control>
        </Form.Group>
        <Form.Group hidden>
          <Form.Control
            type="email"
            name="email"
            ref={register()}
            defaultValue={email}
          ></Form.Control>
        </Form.Group>
        <Button variant="outline-primary" type="submit" disabled={isLoading}>
          Submit
        </Button>
      </Form>
    </div>
  );
};
