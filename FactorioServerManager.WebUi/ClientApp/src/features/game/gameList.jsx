import React, { Component } from 'react';
import { Switch, Link, Route, useRouteMatch, useParams } from "react-router-dom";
import { GameDetails } from './gameDetails';
import { useQuery, gql } from '@apollo/client';

const GAME_LIST = gql`
    query GetGameList {
        games { id, name, description }
    }
`

function component(props, url, data) {
    if (!data) return <div></div>;

    const listItems = data.games.map(i => (<li><Link to={"/g/" + i.id}>{ i.name }</Link></li>));
    return (<ol className="game-list"> {listItems} </ol>)
}

export function GameList(props) {
    let { url } = useRouteMatch();
    let { gameId } = useParams();
    let { loading, error, data } = useQuery(GAME_LIST);

    if (loading) return <div><p>Loading...</p></div>;
    if (error) return <div><p>Error loading games.</p></div>

    return (

        <div>
            <Switch>
                <Route path={url + "/:gameId"} >
                    <GameDetails id={gameId} gameData={ data.games }/>
                </Route>
                <Route path={url}>
                    {component(props, url, loading, error, data)}
                </Route>
            </Switch>
        </div >
    );
}
