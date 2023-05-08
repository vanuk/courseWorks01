import React from "react";
import { Col, Container, Row } from "react-bootstrap";
import logo from "./images/logo-footer.svg";
import text from "./images/text-footer.svg";
import styled from "styled-components";
import { footerColor, footerItem, footerTextStyle, grayFooter } from "./utils/colors";
import { Link } from "react-router-dom";
import { FontInter, FontInterSBold, device } from "./utils/styling-partial";

import facebook_icon from "./images/footer-icon/facebook.svg";
import telegram_icon from "./images/footer-icon/telegram.svg";
import twitter_icon from "./images/footer-icon/twitter.svg";
import youtube_icon from "./images/footer-icon/youtube.svg";
import insta_icon from "./images/footer-icon/insta.svg";
import tiktok_icon from "./images/footer-icon/tiktok.svg";

export default class Footer extends React.Component {
  render() {
    return (
      <MyFooter className="w-100 m-0">
        <Row>
          <Col xs={12} md={12} lg={4} className="d-flex justify-content-evenly">
            <img src={logo} alt="logo" />
            <img src={text} alt="logo" />
          </Col>
          <Col
            xs={12}
            md={12}
            lg={8}
            className="links d-flex justify-content-end align-items-center"
          >
            <div>
              <SocialLink
                link="https://www.facebook.com/www.nuwm.edu.ua/"
                icon={facebook_icon}
              />
              <SocialLink
                link="https://web.telegram.org/#/im?p=@nuwee_official"
                icon={telegram_icon}
              />
              <SocialLink
                link="https://twitter.com/nuwm_ua?ref_src=twsrc%5Etfw&fbclid=IwAR1mgefBCdlRGzlpIRFsb4x1FKThWhuh0hS36-NwpSqXf9swT7SryDdv5-I"
                icon={twitter_icon}
              />
              <SocialLink
                link="https://www.youtube.com/channel/UCnL7wQSSLO3lBxXC33X37Yg"
                icon={youtube_icon}
              />
              <SocialLink
                link="https://www.instagram.com/nuwee_official/?hl=uk&fbclid=IwAR2jnQOYdGsOXX1S2GuiQTSohx8sWLrAkcQf2QFZxvXEuYWW20zlP7F3vhw"
                icon={insta_icon}
              />
              <SocialLink
                link="https://www.tiktok.com/@nuwee_official?_d=secCgYIASAHKAESMgow6H3nF7xxxMPLROFTUjuzfny%2B0mKzpLR017gjnsfefKarfB72VGz4N2%2BnKsc%2Fb4ReGgA%3D&_r=1&checksum=776a2d5fc1991754ba0dbe54a428d7b0ccbeed93a4d84cb11362638baa5b2b62&language=uk&sec_uid=MS4wLjABAAAA0f4sU1VrUwk4fj_xPHUw2f9iad_6XJ6YOUpBkFJE8mE8-FC9ENajAY8HwPyX5dQF&sec_user_id=MS4wLjABAAAA0f4sU1VrUwk4fj_xPHUw2f9iad_6XJ6YOUpBkFJE8mE8-FC9ENajAY8HwPyX5dQF&share_app_id=1233&share_author_id=6876083307315758085&share_link_id=7510B57F-6D55-4E8C-A39A-D72C553F2F3B&source=h5_m&tt_from=telegram&u_code=dehefe2hcgegm1&user_id=6876083307315758085&utm_campaign=client_share&utm_medium=ios&utm_source=telegram"
                icon={tiktok_icon}
              />
            </div>
            <FooterAddress>mail@nuwm.edu.ua</FooterAddress>
          </Col>
        </Row>
        <Row>
          <Col xs={12} md={12} lg={4}>
            <FooterAddress>
              Україна, 33028, м. Рівне, вул. Соборна 11
            </FooterAddress>
            <FooterText>© 2023. Всі права захищені.</FooterText>
          </Col>
          <Col
            xs={12}
            md={12}
            lg={8}
            className="h-auto items d-flex align-items-center justify-content-evenly"
          >
              <FooterItem to={""}>
                Політика конфіденційності
              </FooterItem>
              <FooterItem to={""}>
                Наші координати
              </FooterItem>
              <FooterItem to={""}>
                Технічна підтримка сайту
              </FooterItem>
              <FooterItem to={""}>
                Контакти
              </FooterItem>
          </Col>
        </Row>
      </MyFooter>
    );
  }
}

const SocialLink = (props) => {
  return (
    <a className="m-1" href={props.link}>
      <img src={props.icon} alt="icon" />
    </a>
  );
};

const MyFooter = styled(Row)`
  ${FontInterSBold};
  background-color: ${footerColor};
  padding: 2em;
`;

const FooterItem = styled(Link)`
    ${footerTextStyle};
`;

const FooterText = styled.p`
  ${FontInter};
  color: #87bcf0;
  margin: 0.5em;
  font-size: 0.8em;
  letter-spacing: 0.2px;
`;
const FooterAddress = styled(FooterText)`
  color: ${grayFooter};
`;
