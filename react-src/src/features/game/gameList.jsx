import React, { Component } from 'react';
import { Switch, Link, Route, useRouteMatch, useParams } from "react-router-dom";
import { GameDetails } from './gameDetails';

export function GameList(props) {
    let { url } = useRouteMatch();
    let { gameId } = useParams();

    return (

        <div>
            <Switch>
                <Route path={url + "/:gameId"} >
                    <GameDetails id={gameId} />
                </Route>
                <Route path={url}>
                    <ol class="game-list">
                        <li class="game-list-item"><Link to="/g/tinybelts">TinyBelts</Link></li>
                        <li class="game-list-item"><Link to="/g/all-aboard">All Aboard</Link></li>
                        <li class="game-list-item"><Link to="/g/the-long-haul">The Long Haul</Link></li>
                    </ol>
                </Route>
            </Switch>
        </div >
    );
}
