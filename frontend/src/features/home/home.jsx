import React from 'react';
import { GameList } from '../game/gameList';
import { EventList } from '../calendar/eventList';

export function Home(props) {
    return (
        <div>
            <p>Add Game</p>
            <GameList />
            <EventList />
        </div>
    );
}