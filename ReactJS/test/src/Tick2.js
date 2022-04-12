import './App.css'
import ReactDOM from 'react-dom';



function AppFunction() {
    
  const element = (
  <div class="secondTimer">
      <h1>It is {new Date().toLocaleTimeString()}.</h1>
  </div>
  );
 return(element);
  }

  setInterval(AppFunction, 1000)

export default AppFunction;