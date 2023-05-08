import React from "react";
import styled from "styled-components";
import { MarginCenter, grayFooter } from "./utils/colors";

class Profile extends React.Component {
  constructor(props) {
    super(props);
    this.state = { student: [] };
  }

  componentDidMount() {
    fetch(
      `https://localhost:44308/api/User/get-current-student?email=mertsalova_ak21@nuwm.edu.ua`
    )
      .then((response) => response.json())
      .then((data) => {
        this.setState({ student: data });
      });
  }

  render() {
    const { student } = this.state;
    return (
      <CenteredDiv className="w-75 pl-3 d-flex flex-column align-items-center">
        <TextInput tag="Прізвище" value={student.lastName} />
        <TextInput tag="Ім'я" value={student.firstName} />
        <TextInput tag="По-батькові" value={student.middleName} />
        <TextInput tag="Кооперативна пошта" value={student.cooperativeEmail} />
        <TextInput tag="Власна пошта" value={student.ownEmail} />
        <TextInput tag="Група" value={student.groupName} />
      </CenteredDiv>
    );
  }
}

export default Profile;

const CenteredDiv = styled.div`
  ${MarginCenter}
`;

const TextInput = (props) => {
  return (
    <Card className="d-flex justify-content-between align-items-center w-75 ">
      <h4>{props.tag}</h4>
      <p>{props.value}</p>
    </Card>
  );
};

const Card = styled.div`
  h4 {
    font-size: 1.1em;
    margin-left: 1em;
  }
  p {
    font-size: 1em;
    width: 40%;
  }
  border-bottom: 2px solid ${grayFooter};
  margin: 1em;
`;
