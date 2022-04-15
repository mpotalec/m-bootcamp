import './App.css';
import {useState} from 'react';

function Tick2(){
  const [count, setCount] = useState(0)

return(
  <div>
    <p>You have clicked {count} times!</p>
    <button onClick={()=>setCount(count + 1) }>Click</button>
  </div>
)}

export default Tick2;

