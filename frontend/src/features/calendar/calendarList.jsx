import React from 'react';
import { Switch, Link, Route, useRouteMatch, useParams } from "react-router-dom";
import { CalendarDetails } from './calendarDetails';

export function CalendarList(props) {
    let { url } = useRouteMatch();
    let { calendarId } = useParams();

    return (
        <Switch>
            <Route path={url + "/:calendarId"}>
                <CalendarDetails id={calendarId} />
            </Route>
            <Route path={url}>
                <ul>
                    <li><Link to="/c/42">proegssilb - Factorio</Link></li>
                    <li><Link to="/c/4">phoenyx - Factorio</Link></li>
                    <li><Link to="/c/78">RavenBrighd - Why do I have to fill this out?!</Link></li>
                </ul>
            </Route>
        </Switch>
    );
}