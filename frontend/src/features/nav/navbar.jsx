import React from 'react';
import { Link } from "react-router-dom";
import { LoginPip } from '../login/login';

export function Navbar(props) {
    return <nav aria-label="breadcrumb">
        <ol className="breadcrumb">
            <li className="breadcrumb-item"><Link to="/">Home</Link></li>
            <li className="breadcrumb-item"><Link to="/g">Game List</Link></li>
            <li className="breadcrumb-item"><Link to="/g/all-aboard">All Aboard</Link></li>
            <li className="breadcrumb-item active" aria-current="page">user-01801283</li>
        </ol>
        <LoginPip />
    </nav>;
}
