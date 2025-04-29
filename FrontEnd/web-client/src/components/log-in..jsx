import '../style-sheets/log-in.css'

function LogIn(){
    return(
        <div className="container">
            <div className="form-container">
                
                <input
                    className="input"
                    id='username'
                    type="text"
                    placeholder="Username"
                    autoComplete='off'
                />
                <input
                    className="input"
                    type="text"
                    placeholder="Password"
                    autoComplete='off'
                />
                <button 
                    className='signIn-button'
                    type='submit'>
                    Iniciar Sesión
                </button>
            </div>
            <div className="links-container">

            </div>
        </div>
    );
}

export default LogIn;