import './App.css'


function AppFunction() {
    
  const element = (
  <div>
      <h1>It is {new Date().toLocaleTimeString()}.</h1>
  </div>
  );
 return(element);
  }

  setInterval(AppFunction, 1000)

export default AppFunction;