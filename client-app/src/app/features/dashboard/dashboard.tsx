import { Grid } from "semantic-ui-react";
import { GetVehicle } from "../../models/getvehicle";
import VehicleList from "./vehiclelist";

interface Props{
    vehicles: GetVehicle[];
}

export default function Dashboard({vehicles}: Props){
    return (
        <Grid>
            <Grid.Column width='10'>
               <VehicleList vehicles={vehicles}/>
            </Grid.Column>
        </Grid>
    )
}