import '../style-sheets/log-in.css'
import { useState } from 'react';
import ToDoLogo from '../img/to-do-appLogo.png'
import { useNavigate } from 'react-router-dom';




function LogIn() {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [state, setState] = useState('');
    const navigate = useNavigate();

    const handleLogin = async (event) => {
        event.preventDefault();

        const uri = 'https://localhost:7239/api/users/login'
        const data = { nickname: username, password };
        

        try {
            const response = await fetch(uri, {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(data),
            });
            const responseData = await response.json();

            if (response.ok) {
                setState("Inicio de sesion exitoso")
                console.log("Inicio de sesion exitoso: " + JSON.stringify(responseData))
                navigate('/Welcome', {state: {username}})

            }
            else {
                setState(`Error: ${responseData.message}`)
                console.log("Error:", responseData.message);

            }
        }
        catch (error) {
            setState(`Error: ${error.message}`);
            console.log("Error en la solicitud:", error.message);
        }
    };


    return (
        <>
        <div className="login-app">
            <div className='logo-container'>
                <img
                    className='app-logo'
                    src={ToDoLogo}
                    alt='to-do-app Logo'
                />
            </div>
            <div className='main-container'>
                <div className="container">
                    <form className="form-container"
                        onSubmit={handleLogin}>
                        <input
                            className="input"
                            id='username'
                            type="text"
                            placeholder="Username"
                            autoComplete='off'
                            value={username}
                            onChange={(e) => setUsername(e.target.value)}/>
                        <input
                            className="input"
                            type="password"
                            placeholder="Password"
                            autoComplete='off'
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}/>
                        <button
                            className='signIn-button'
                            type='submit'>
                            Iniciar Sesión
                        </button>
                    </form>
                    
                    <div className="links-container">
                    </div>
                    
                </div>
                
            </div>
            
        </div>
        {state && (
      <div className="login-message">
        {state}
      </div>
    )}
        </>
        
    );
}

export default LogIn;