import React from 'react';
import { Switch, Link, Route, useRouteMatch } from "react-router-dom";
import { GameDetails } from './gameDetails';
import { useQuery, gql } from '@apollo/client';

const GAME_LIST = gql`
    query GetGameList {
        games { id, name, description }
    }
`

function component(props, url, data) {
    if (!data) return <div><p>Game data failed to load.</p></div>;

    const listItems = data.games.map(i => (<li key={i.id}><Link to={"/g/" + i.id}>{ i.name }</Link></li>));
    return (<ol className="game-list"> {listItems} </ol>)
}

export function GameList(props) {
    let { url } = useRouteMatch();
    let { loading, error, data } = useQuery(GAME_LIST);

    if (loading) return <div><p>Loading...</p></div>;
    if (error) return <div><p>Error loading games.</p></div>

    return (

        <div>
            <Switch>
                <Route path="/g/:gameId" >
                    <GameDetails gameData={ data.games }/>
                </Route>
                <Route path={url}>
                    {component(props, url, data)}
                </Route>
            </Switch>
        </div >
    );
}
