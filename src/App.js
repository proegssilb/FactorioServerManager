import Navbar from './components/navbar'
import Home from './pages/home'
import {
  BrowserRouter as Router,
  Switch,
  Route,
} from "react-router-dom";
import { FirebaseAppProvider } from 'reactfire';
import { useEffect, useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';

const configUrl = '/__/firebase/init.json';

function loadConfig() {
    return fetch(configUrl).then(data => data.json());
}

function App() {
    const {firebaseConfig, setConfig} = useState({});
    
    useEffect(() => {
        let mounted = true;
        loadConfig().then(config => {
            if(mounted) {
                setConfig(config);
            }
        });
        return () => mounted = false;
    }, [setConfig]);
    if (!firebaseConfig) {
        // TODO: Some kind of loading indicator...
        return <div />
    }
    return (
        <FirebaseAppProvider firebaseConfig={firebaseConfig}>
            <Router>
            <div>
                <Navbar></Navbar>

                {/* A <Switch> looks through its children <Route>s and
                    renders the first one that matches the current URL. */}
                <Switch>
                <Route path="/g">
                    { /* TODO - game list and specific game*/ }
                </Route>
                <Route path="/c">
                    { /* TODO - do I even want this?*/ }
                </Route>
                <Route path="/">
                    <Home> </Home>
                </Route>
                </Switch>
            </div>
            </Router>
        </FirebaseAppProvider>
    );
}

export default App;
