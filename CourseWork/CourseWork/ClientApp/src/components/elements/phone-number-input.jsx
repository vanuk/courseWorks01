import React, { useRef, useState } from "react"
import styled from "styled-components";
import { FormStyling } from "../utils/styling-partial";

export default function PhoneNumberInput({ getPhone }) {
    const [inputValue, setInputValue] = useState('');
    const handleInput = e => {
        const formattedPhoneNumber = formatPhoneNumber(e.target.value);
        setInputValue(formattedPhoneNumber);
    };

    function formatPhoneNumber(value) {
        if (!value) return value;
        const phoneNumber = value.replace(/[^\d]/g, "");
        const phoneNumberLength = phoneNumber.length;
        if (phoneNumberLength < 4) return phoneNumber;
        if (phoneNumberLength < 7) {
            return `(${phoneNumber.slice(0, 3)}) ${phoneNumber.slice(3)}`;
        }
        if (phoneNumberLength < 10) {
            return `(${phoneNumber.slice(0, 3)}) ${phoneNumber.slice(3, 6)}–${phoneNumber.slice(6, 10)}`;
        }
        const phone = `+38 (${phoneNumber.slice(0, 3)}) ${phoneNumber.slice(3, 6)}–${phoneNumber.slice(6, 10)}`;
        getPhone(phone);
        return phone;
    }

    return (<Input maxLength={18} onChange={e => handleInput(e)} placeholder="+38 (XXX) XXX–XXXX" value={inputValue} />)
}

const Input = styled.input`
    ${FormStyling};
`;