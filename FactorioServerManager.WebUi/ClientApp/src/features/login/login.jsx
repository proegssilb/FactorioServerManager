import React, { Component } from 'react';
import { useQuery, gql } from '@apollo/client';

const LOGIN_STATUS = gql`query Query { auth { whoAmI } }`

export function LoginPip() {
    const { loading, error, data } = useQuery(LOGIN_STATUS);
    if (loading) return <p>Loading...</p>;
    if (error) return <p>Error :(</p>;
    const currentLogin = data.auth.whoAmI;
    if (currentLogin === "") {
        return <p><a href="/Account/Login">Login</a></p>;
    } else {
        return <p>You are logged in as {currentLogin}. <a href="/Account/Logout">Logout</a></p>;
    }
}