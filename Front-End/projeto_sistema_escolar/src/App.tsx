import React, { useEffect } from "react";
import api from './Services/api';

function App() {

  useEffect(()=>{
    api.get("/WeatherForecast")
    .then(response => console.log(response));
  },[])

  return (
    <React.Fragment>

    </React.Fragment>
  );
}

export default App;
