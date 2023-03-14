import * as React from 'react';
import { Col, Container, Row } from 'react-bootstrap';
import ButtonsRoutes from '../../Components/ButtonsRoutes';

const Home = () => {
    return (
        <React.Fragment>
            <div className='page-content'>
                <Container fluid>
                    <Row>
                        <Col>
                            <ButtonsRoutes />
                        </Col>
                    </Row>
                </Container>
            </div>
        </React.Fragment>
    );
}

export default Home;