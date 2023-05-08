import { css } from "styled-components";
import { FontInterSBold, device } from "./styling-partial";

export const headerLink = "#3B4856";
export const mainColor = "#005683";
export const lightMainColor = "#3F6098";
export const langColor = "#00A2A7";
export const lightGray = "#D9D9D9";
export const footerColor = "#4E87B8";
export const footerItem = "#B9DDFF";
export const grayFooter = "#E6F4F1";
export const colorHoverHeader = css`
  background: radial-gradient(
        circle,
        ${mainColor} 28%,
        ${mainColor} 53%,
        ${mainColor} 100%
      )
      var(--c, 0%) / 200% 100%,
    radial-gradient(
        circle,
        ${mainColor} 28%,
        ${mainColor} 53%,
        ${mainColor} 100%
      )
      0% 100% / var(--c, 0%) 0.15em no-repeat;
`;
export const headerTextStyle = css`
  ${FontInterSBold};
  font-size: 1em;
  padding: 0.1em;
  color: ${headerLink};
  ${colorHoverHeader};
  -webkit-background-clip: text, padding-box;
  background-clip: text, padding-box;
  transition: 0.5s;

  &:hover {
    color: ${mainColor};
    --c: 100%;
    text-decoration: none;
  }

  @media ${device.mobileS} {
    margin: 0.8em;
  }
`;
export const colorHoverFooter = css`
  background: radial-gradient(
        circle,
        ${footerItem} 28%,
        ${footerItem} 53%,
        ${footerItem} 100%
      )
      var(--c, 0%) / 200% 100%,
    radial-gradient(
        circle,
        ${footerItem} 28%,
        ${footerItem} 53%,
        ${footerItem} 100%
      )
      0% 100% / var(--c, 0%) 0.15em no-repeat;
`;
export const footerTextStyle = css`
  ${FontInterSBold};
  font-size: 1em;
  padding: 0.1em;
  color: ${footerItem};
  ${colorHoverFooter};
  -webkit-background-clip: text, padding-box;
  background-clip: text, padding-box;
  transition: 0.5s;

  &:hover {
    color: ${footerItem};
    --c: 100%;
    text-decoration: none;
  }
`;
export const MarginCenter = css`
  margin: 0 auto;
`;
export const override = css`
  display: block;
  margin: 0 auto;
  border-color: red;
`;