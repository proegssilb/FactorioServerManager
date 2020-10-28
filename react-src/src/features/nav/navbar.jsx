import React, { Component } from 'react';
import { Link } from "react-router-dom";

export function Navbar(props) {
    return <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><Link to="/">Home</Link></li>
            <li class="breadcrumb-item"><Link to="/g">Game List</Link></li>
            <li class="breadcrumb-item"><Link to="/g/all-aboard">All Aboard</Link></li>
            <li class="breadcrumb-item active" aria-current="page">user-01801283</li>
        </ol>
    </nav>;
}
