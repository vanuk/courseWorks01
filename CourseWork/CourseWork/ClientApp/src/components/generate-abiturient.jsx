import React from "react";
import styled from "styled-components";
import { FontInterSBold, FormStyling } from "./utils/styling-partial";
import { colorHoverHeader, headerLink } from "./utils/colors";
import { institutes } from "./elements/json/institutes";
import { useRef } from "react";
import { useState } from "react";
import axios from "axios";
import PhoneInput from "react-phone-input-2";
import PhoneNumberInput from "./elements/phone-number-input";
import { Button, Modal } from "react-bootstrap";

export function GenerateAbiturient() {
  const lastName = useRef("");
  const firstName = useRef("");
  const fatherName = useRef("");
  const [institute, setInstitute] = useState("");
  const [phone, setPhone] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [show, setShow] = useState(false);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  const handleChange = (e) => {
    setInstitute(e.target.value);
  };

  const getPhone = (value) => {
    setPhone(value);
  };

  function formSubmit(state) {
    axios
      .get(
        `https://localhost:44308/api/Abiturient/generate?lastName=${lastName.current.value}&firstName=${firstName.current.value}&fatherName=${fatherName.current.value}&institute=${institute}&phone=${phone}`
      )
      .then((response) => {
        if (response.status === 200) {
          setEmail(response.data.email);
          setPassword(response.data.password);
        }
      });
    handleShow();
  }

  return (
    <div className="d-flex flex-column align-items-center w-100">
      <Title>Створити нового студента</Title>
      <div className="d-flex flex-column align-items-center w-75">
        <Input placeholder="Прізвище" type="text" ref={lastName} />
        <Input placeholder="Ім'я" type="text" ref={firstName} />
        <Input placeholder="По-батькові" type="text" ref={fatherName} />
        <PhoneNumberInput getPhone={getPhone} />
        <Select value={institute} onChange={handleChange}>
          <option defaultChecked>Вибрати інститут</option>
          {institutes.map((item) => {
            return (
              <option key={item.id} value={item.value}>
                {item.name}
              </option>
            );
          })}
        </Select>
        <button
          className="btn btn-outline-dark"
          onClick={() => formSubmit(true)}
        >
          Зберегти
        </button>
        <Modal
          show={show}
          onHide={handleClose}
          backdrop="static"
          keyboard={false}
        >
          <Modal.Header closeButton className="align-items-center">
            <Modal.Title>Інформація про студента</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <h5>Прізвище: </h5>
            <p>{lastName.current.value}</p>
            <h5>Ім'я: </h5>
            <p>{firstName.current.value}</p>
            <h5>По-батькові: </h5>
            <p>{fatherName.current.value}</p>
            <h5>Телефон: </h5>
            <p>{phone}</p>
            <h5>Інститут: </h5>
            <p>{institute}</p>
            <h5>Електронна адреса: </h5>
            <p>{email}</p>
            <h5>Пароль: </h5>
            <p>{password}</p>
          </Modal.Body>
          <Button variant="secondary" onClick={handleClose}>
            Закрити
          </Button>
        </Modal>
      </div>
    </div>
  );
}

const Title = styled.p`
  ${FontInterSBold};
  font-size: 1.5em;
  padding: 1em;
  color: ${headerLink};
`;
export const Input = styled.input`
  ${FormStyling};
`;
export const Select = styled.select`
  ${FormStyling};
`;
