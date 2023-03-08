import { ChangeEvent, useState } from "react";
import { Button, Container, Form, Menu } from "semantic-ui-react";

interface Props{
    searchVehicles: (input: string) => void;
}

export default function NavBar({searchVehicles}: Props){

    const[searchInput, setInput] = useState<string>();

    function handleSubmit(){
        searchVehicles(searchInput!);
    }

    function handleInputChange(event: ChangeEvent<HTMLInputElement>){
        setInput(event.target.value);
    }

    return (
        <Menu fixed='top' inverted>
            <Container>
                <Menu.Item header>
                    <h2>Parking Lot</h2>
                </Menu.Item>
            
                <Menu.Item>
                    <Form onSubmit={handleSubmit}>
                        <Form.Group>
                            <Form.Input onChange={handleInputChange} style={{width: '20em'}}  fluid floated='left' placeholder='Search'></Form.Input>
                            <Button fluid positive floated='left' type='submit' content='Search' />
                        </Form.Group>
                    </Form>
                </Menu.Item>
            </Container>
        </Menu>
    )
}