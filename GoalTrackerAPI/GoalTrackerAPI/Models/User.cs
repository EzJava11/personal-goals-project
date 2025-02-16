namespace GoalTrackerAPI.Models
{
    public class User
    {

        public int Id { get; set; }  // Identificador único del usuario
        public string Name { get; set; }  // Nombre del usuario
        public string Email { get; set; }  // Correo electrónico del usuario
        public string Password { get; set; }  // Contraseña del usuario (encriptada)
        

    }
}
