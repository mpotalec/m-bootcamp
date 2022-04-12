import ReactDOM from 'react-dom'
import './App.css'

const root=ReactDOM.createRoot(
    document.getElementById('root')
);

function AppFunction() {
    
  const element = (
  <div>
      <form class="form">
        <label>
            First Name <br/>
            <input type="text"></input>
        </label>
        <br />
        <label>
            Email <br/>
            <input type= "email"></input>
        </label>
        <br/>
        <label>
            <button class="button">Send!</button>
        </label>
      </form>
  </div>
  );
 return(element);
  }

  setInterval(AppFunction, 1000)

export default AppFunction;