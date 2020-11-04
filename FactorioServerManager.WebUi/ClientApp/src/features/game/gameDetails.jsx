import React from 'react';
import { Link } from "react-router-dom";
import { EventList } from '../calendar/eventList';
import { useParams } from "react-router-dom";

export function GameDetails(props) {
    let { gameId } = useParams();

    const games = props.gameData;
    const game = games.find(g => String(g.id) === gameId);

    console.log("Game details game data: ", games);
    console.log("Game details props:", props);
    if (!game) return <div><p>Could not find game { gameId }</p></div>;

    return (
        <div>
            <h1>{game.name}</h1>
            <p>Game Status: feature not implemented</p>
            <p>{game.description}</p>
            <button>Start Game</button>
            <h2>Owners</h2>
            <ul>
                <li>Feature not implemented</li>
            </ul>
            <h2>Players</h2>
            <ul>
                <li>Feature not implemented</li>
            </ul>
            <h2>Schedule</h2>
            <Link to="/c/42">Feature not implemented</Link>
            <EventList id="42" />
        </div>
    );
}