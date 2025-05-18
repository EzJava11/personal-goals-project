import {Route, Routes } from 'react-router-dom';
import './App.css';
import LogIn from './pages/LogIn';
import WelcomeAnimation from './components/WelcomeAnimation';
import Home from './pages/Home.jsx';

function App() {
  return (
    
    <Routes>
      <Route path='/' element={<LogIn />}/>
      <Route path="/Welcome" element={<WelcomeAnimation />} />
      <Route path='/Home' element={<Home/>}/>
    </Routes>
    
  );
}

export default App;
