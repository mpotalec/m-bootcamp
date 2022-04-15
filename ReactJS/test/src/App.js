import logo from './logo.svg';
import ContactForm from "./components/ContactForm";
import ContactList from "./components/ContactInfo";
import './App.css';
import {useState} from 'react';

function App() {
  
  const[contacts, updateContacts] = useState([""]);
  const addContact = (contact) => {
    updateContacts([...contacts, contact]);
    
  };

  return (
    <div className="App">
      <ContactForm addContact = {addContact}/>
      <ContactList contacts = {contacts}/>
      
      <header className="App-header">
      <img src={logo} className="App-logo" alt="logo" />
        
      </header>
    </div>
  );
}


export default App;
