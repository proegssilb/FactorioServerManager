import React, { Component } from 'react';
import { Switch, Link, Route, useRouteMatch, useParams } from "react-router-dom";

export function EventList(props) {
    return (
        <ul>
            <li><Link to="/c/42/1">Saturday 1/1/2020, 9am</Link></li>
            <li><Link to="/c/42/2">Saturday 2/2/2020, 9am</Link></li>
        </ul>
        );
}