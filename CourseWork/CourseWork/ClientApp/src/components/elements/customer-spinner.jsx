import { override } from "../utils/colors";
import React from "react";
import { ClipLoader } from "react-spinners";

export default function Spinner(props) {
  return (
    <ClipLoader
      cssOverride={override}
      size={150}
      color={"#123abc"}
      loading={props.loading}
      speedMultiplier={1.5}
      aria-label="Loading Spinner"
      data-testid="loader"
    />
  );
}
