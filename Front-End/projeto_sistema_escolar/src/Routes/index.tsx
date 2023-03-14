import React from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Home from '../Pages/Home';

const Rotas = () => {
    return (
        <React.Fragment>
            <BrowserRouter>
                <Routes>
                    <Route path={'/'} element={<Home />} />
                </Routes>
            </BrowserRouter>
        </React.Fragment>
    )
}

export { Rotas };