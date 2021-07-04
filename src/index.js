import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';

const firebaseConfig = {
  apiKey: "AIzaSyCjUU9pZ7Almv4WyD3tvD6ldrcoj1-eAfk",
  authDomain: "server-manager-3d753.firebaseapp.com",
  databaseURL: "https://server-manager-3d753-default-rtdb.firebaseio.com",
  projectId: "server-manager-3d753",
  storageBucket: "server-manager-3d753.appspot.com",
  messagingSenderId: "321116700883",
  appId: "1:321116700883:web:7d571c5972b575c6451426",
  measurementId: "G-G7LHG1R3BX"
};

ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
