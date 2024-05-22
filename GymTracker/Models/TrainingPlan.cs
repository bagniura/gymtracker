namespace GymTracker.Models
{
    public class TrainingPlan
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PlanName { get; set; }
        public string Description { get; set; }
    }
}
