import { Item, Segment } from "semantic-ui-react";
import { GetVehicle } from "../../models/getvehicle";

interface Props{
    vehicles: GetVehicle[];
}

export default function VehicleList({vehicles}: Props){
    return (
        
        <Segment>
            <Item.Group divided>
                {vehicles.map(vehicle => (
                    <Item key={vehicle.registrationNumber}>
                        <Item.Content>
                            <Item.Header as='a'>Registration Number: {vehicle.registrationNumber}</Item.Header>
                            <Item.Meta>EntryDate: {vehicle.dateEntry}</Item.Meta>
                            <Item.Meta>Total Charge: {vehicle.totalCharge}</Item.Meta>
                            <Item.Meta>Total Discount: {vehicle.totalDiscount}</Item.Meta>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>
        </Segment>
    )
}