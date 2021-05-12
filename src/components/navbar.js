import Navbar from 'react-bootstrap/Navbar'
import Nav from 'react-bootstrap/Nav'

export default function AppNav() {
    return (
        <Navbar bg="light" expand="lg">
            <Navbar.Brand className="mx-3" href="/">FSM</Navbar.Brand>
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
            <Navbar.Collapse id="basic-navbar-nav">
            <Nav>
                <Nav.Link href="/">Home</Nav.Link>
                <Nav.Link href="/g/">Game List</Nav.Link>
                <Nav.Link href="/c/">Upcoming Games</Nav.Link>
                <Nav.Link className="mx-2" href="#">Create Game</Nav.Link>
            </Nav>
        </Navbar.Collapse>
        </Navbar>
    );
}
