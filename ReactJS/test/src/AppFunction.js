import './App.css'
import {useState} from 'react';

const AppFunction = () => {

const [firstName, setFirstName] = useState('');
const [email, setEmail] = useState('');
const [phoneNumber, setPhoneNumber] = useState('');

return (
  <div>
      <form class="form">
        <label>
            First Name <br/>
            <input type="text" required value={firstName} onChange={(e) => setFirstName(e.target.value)}></input>
        </label>
        <br />
        <label>
            Email <br/>
            <input type= "email" required value ={email} onChange={(e) => setEmail(e.target.value)}></input>
        </label>
        <br/>
        <label>
            Phone number <br/>
            <input type= "number" required value ={phoneNumber} onChange={(e) => setPhoneNumber(e.target.value)}></input>
        </label>
        <br/>

        <label>
            <button class="button">Send!</button>
        </label>
      </form>
        <p>
          {firstName}<br/>
          {email}
          {phoneNumber}
        </p>
  </div>
  );
  }


export default AppFunction;