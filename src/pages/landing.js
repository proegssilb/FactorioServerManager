import Jumbotron from 'react-bootstrap/Jumbotron';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import LoginBox from '../components/login';

function LandingHome() {
    return (
        <Container>
            <Row>
                <Col>
                    <Jumbotron>
                        <h1>Welcome to Factorio Server Manager.</h1>
                        <p>
                            Spin up and down servers automatically. Because cloud servers are cheaper that way.
                        </p>
                        <p>
                            But first, we need you to log in.
                        </p>
                    </Jumbotron>
                </Col>
            </Row>
            <Row>
                <Col>
                    <LoginBox />
                </Col>
            </Row>
        </Container>
    );
}

export default LandingHome;
