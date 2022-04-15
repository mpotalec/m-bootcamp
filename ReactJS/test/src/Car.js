import './App.css';
import {useState} from 'react';

function Car(){
const[brand, setBrand] = useState("Ford")
const[model, setModel] = useState("Mustang")
const[year, setYear] = useState("1964")

return (
    <div>
        <p>I have a {brand}{model} from the year{year}!</p>
    </div>
)    
}

export default Car;