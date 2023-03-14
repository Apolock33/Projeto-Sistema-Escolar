import { Icon } from '@ailibs/feather-react-ts';
import * as React from 'react';
import { Card, Col, Row } from 'react-bootstrap';
import { Link } from 'react-router-dom';

const ButtonsItemsRoute = () => {

    interface buttonGoToRouteInfoAll {
        id: number;
        title: string;
        icon: string;
        route: string;
    }

    const buttonGoToRouteInfo: Array<buttonGoToRouteInfoAll> = [
        {
            id: 1,
            title: "Instituições",
            icon: "user",
            route: "/instituicoes"
        },
        {
            id: 2,
            title: "Alunos",
            icon: "credit-card",
            route: "/alunos"
        },
        {
            id: 3,
            title: "Turmas",
            icon: "phone-forwarded",
            route: "/turmas"
        },
        {
            id: 4,
            title: "Materias",
            icon: "tag",
            route: "/materias"
        }
    ];

    return (
        <React.Fragment>

        </React.Fragment>
    );
}

export default ButtonsItemsRoute;