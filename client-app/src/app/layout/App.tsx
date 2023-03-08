import React, { useEffect, useState } from 'react';
import { Container } from 'semantic-ui-react';
import agent from '../api/agent';
import Dashboard from '../features/dashboard/dashboard';
import { GetVehicle } from '../models/getvehicle';
import './App.css';
import NavBar from './NavBar';

function App() {
  const[vehicles, setVehicles] = useState<GetVehicle[]>([]);
  
  useEffect(() => {
    apiCall();
  }, [])

  function apiCallSingle(regNumber: string){
      agent.Vehicles.getSingle(regNumber).then(response => {
          if(response)
            setVehicles([response])
          else
            setVehicles([]);
      });
  }

  function  apiCall() {
    agent.Vehicles.list().then(response => {
      setVehicles(response);
    })
  }

  function searchVehicles(input: string){
     if(!input){
         apiCall();
     }
     else{
        apiCallSingle(input);
     }
  }

  return (
    <>
        <NavBar searchVehicles={searchVehicles}/>
        <Container style={{marginTop: '10em'}}>
            <Dashboard vehicles={vehicles}/>
        </Container>
    </>
  );
}

export default App;
