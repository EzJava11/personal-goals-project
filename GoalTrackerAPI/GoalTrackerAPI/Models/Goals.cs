namespace GoalTrackerAPI.Models
{
    public class Goals
    {
        public int Id { get; set; }  // Identificador único de la meta
        public string Title { get; set; }  // Título de la meta
        public string Description { get; set; }  // Descripción de la meta
        public bool IsCompleted { get; set; }  // Estado de la meta (completada o no)
        public DateTime CreatedAt { get; set; }  // Fecha de creación
        public DateTime TargetDate { get; set; }  // Fecha de meta

        public int UserId { get; set; }
        public User User { get; set; }   
    }
}
