import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import AppFunction from './AppFunction';
import AppClass from './AppClass';
import Tick from './Tick';
import List from './List';
import Tick2 from './Tick2';
import Car from './Car';
import Student from './Student';
import Counter from './Counter';


ReactDOM.render(
  <React.StrictMode>
    <Counter />
    <AppClass />
    <AppFunction />
    <Student />
    <Tick />
    <List/>
    <App />
    <Tick2 />
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
