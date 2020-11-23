import React from 'react';
import {
    BrowserRouter as Router,
    Switch,
    Route
} from "react-router-dom";

import { Navbar } from './features/nav/navbar';
import { Home } from './features/home/home';
import { GameList } from './features/game/gameList';
import { CalendarList } from './features/calendar/calendarList';

import './App.css';

function App() {
    return (
        <Router>
            <Navbar />
            <Switch>
                <Route path="/g">
                    <GameList />
                </Route>
                <Route path="/c">
                    <CalendarList />
                </Route>
                <Route path="/">
                    <Home />
                </Route>
            </Switch>
        </Router>
    );
}

export default App;
