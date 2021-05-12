import Navbar from './components/navbar'
import Home from './pages/home'
import {
  BrowserRouter as Router,
  Switch,
  Route,
} from "react-router-dom";
import { preloadUser } from 'reactfire';
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {
    preloadUser({});
    return (
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
    );
}

export default App;
