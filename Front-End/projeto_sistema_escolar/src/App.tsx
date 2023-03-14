import React from "react";
import SideMenu from "./Components/SideMenu";
import { Rotas } from "./Routes";
import './Assets/Css/pagesConfig.css';

function App() {

  return (
    <React.Fragment>
      <SideMenu />
      <Rotas />
    </React.Fragment>
  );
}

export default App;