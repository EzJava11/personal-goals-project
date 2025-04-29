import './App.css';
import LogIn from './components/log-in.';
import ToDoLogo from './img/to-do-appLogo.png'

function App() {
  const uri = 'http://localhost:5189/';
  return (
    <div className="login-app">
      <div className='logo-container'>
        <img
          className='app-logo'
          src={ToDoLogo}
          alt='to-do-app Logo'
        />
      </div>
      <div className='main-container'>
      <LogIn></LogIn>
      </div>
     
    </div>
  );
}

export default App;
