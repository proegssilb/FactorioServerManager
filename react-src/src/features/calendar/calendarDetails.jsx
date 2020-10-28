import React, { Component } from 'react';
import { Switch, Link, Route, useRouteMatch, useParams } from "react-router-dom";
import { EventList } from './eventList';
import { EventDetails } from './eventDetails';

export function CalendarDetails(props) {
    let { url } = useRouteMatch();
    let { calendarId, eventId } = useParams();

    return (
        <Switch>
            <Route path={url + "/:eventId"}>
                <EventDetails id={eventId} />
            </Route>
            <Route path={url}>
                <h1>Factorio</h1>
                <p>Owned by: minifig404</p>
                <p>Upcoming events:</p>
                <EventList />
            </Route>
        </Switch>
    );
}