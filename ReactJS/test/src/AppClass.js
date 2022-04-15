import React from "react";
import './App.css';

class AppClass extends React.Component{
    render(){
        return (
        <div>
            <h1>Orahovica</h1>
            <ul class="navigation">
                <li><a href="#home">Home</a></li>
                <li><a href="https://www.Orahovica.hr" target="_blank">Official website</a></li>
                <li><a href="./About.html" target="_blank">About</a></li>
                <li><a href="#Tick2">Contact</a></li>
            </ul>
            
        </div>
        )
    }
    
}
export default AppClass;