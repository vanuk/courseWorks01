import React, { Component, useEffect, useRef, useState } from "react";
import axios from "axios";
import photo from "./images/main-photo.png";
import styled from "styled-components";
import { Col, Container, Row } from "react-bootstrap";
import { FontInterSBold } from "./utils/styling-partial";
import { lightMainColor, mainColor } from "./utils/colors";
import { Link } from "react-router-dom";

export function Home() {
  const [currentUser, setCurrentUser] = useState();

  useEffect(() => {
    setCurrentUser(localStorage.getItem("email"));
  }, [currentUser]);

  return (
    <>
      {currentUser == null ? (
        <Row className="w-100">
          <Col xs={12} md={8} className="p-1">
            <MainImg src={photo} alt="img" />
          </Col>
          <MyCol
            xs={12}
            md={4}
            className="d-flex flex-column align-items-center justify-content-center"
          >
            <p>Знаходь тут відповіді на свої питання</p>
            <MyHr />
            <Link to={"/login"}>
              <BeginBtn className="m-3">Розпочати</BeginBtn>
            </Link>
            <Link to={"/generate-abiturient"}>
              <BeginBtn className="m-3">Генерація абітурієнта</BeginBtn>
            </Link>
          </MyCol>
        </Row>
      ) : (
        <Row className="w-100">
          <p className="">User exist</p>
        </Row>
      )}
    </>
  );
}

const MyHr = styled.hr`
  border: none;
  border-top: 2px solid ${mainColor};
  overflow: visible;
  text-align: center;
  height: 5px;
  width: 75%;
`;

const MainImg = styled.img`
  width: 100%;
  padding: 0;
`;

const MyCol = styled(Col)`
  ${FontInterSBold};

  p {
    width: 80%;
    color: ${mainColor};
    font-size: 1.5em;
    text-align: center;
    margin: 0 auto;
  }
`;

const BeginBtn = styled.button`
  border-radius: 1.56em;
  padding: 0.35em 2.2em;
  font-weight: 600;
  border: 2px solid ${lightMainColor};
  background-color: #ffffff;
  box-shadow: 0px 0px 5px rgba(63, 96, 152, 0.2);
  color: ${mainColor};
  font-size: 1em;

  &:hover {
    background-color: ${mainColor};
    color: #ffffff;
  }
`;
