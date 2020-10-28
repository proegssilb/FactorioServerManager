import React, { Component } from 'react';
import { Switch, Link, Route, useRouteMatch, useParams } from "react-router-dom";
import { EventList } from '../calendar/eventList';

export function GameDetails(props) {
    return (
        <div>
            <h1>All Aboard</h1>
            <p>Game Status: Not Running</p>
            <button>Start Game</button>
            <h2>Owners</h2>
            <ul>
                <li>chemicalivory</li>
            </ul>
            <h2>Players</h2>
            <ul>
                <li>plasmataki</li>
            </ul>
            <h2>Schedule</h2>
            <Link to="/c/42">chemicalivory - Factorio</Link>
            <EventList id="42" />
        </div>
    );
}