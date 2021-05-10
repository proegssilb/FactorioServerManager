import logo from './logo.svg';
import './App.css';

function App() {
  const res = fetch('http://localhost:5001/server-manager-3d753/us-central1/helloWorld')
      .then(res => console.log(res.text()));
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
