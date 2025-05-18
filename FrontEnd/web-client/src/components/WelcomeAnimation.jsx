import { useEffect } from "react";
import { useLocation, useNavigate } from "react-router-dom"
import '../style-sheets/WelcomeAnimation.css'

function WelcomeAnimation() {
    const navigate = useNavigate();
    const location = useLocation();
    const username = location.state?.username.toUpperCase() || "USUARIO";
    
    

    useEffect(() => {
        const timer = setTimeout(() => {
            navigate('/Home');
        }, 3000)

        return () => clearTimeout(timer)
    }, [navigate]);

    return (
        <div className="welcome-screen">
            <h1 className="slide-in">¡Bienvenido, {username}!</h1>
        </div>
    );
}

export default WelcomeAnimation;