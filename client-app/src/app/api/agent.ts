import axios, { AxiosResponse } from 'axios'
import { GetVehicle } from '../models/getvehicle';

axios.defaults.baseURL = 'http://localhost:5179/'

const responseBody = (response: AxiosResponse) => response.data;

const requests = {
    get:<T> (url: string) => axios.get<T>(url).then(responseBody)
}

const Vehicles = {
    list: () => requests.get<GetVehicle[]>('/getallvehicles')
}

const agent = {
    Vehicles
}

export default agent;