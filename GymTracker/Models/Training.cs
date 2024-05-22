namespace GymTracker.Models
{
    public class Training
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? ExerciseType { get; set; }
        public int Repetitions { get; set; }
        public int Sets { get; set; }
        public double Weight { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime Date { get; set; }
    }
}
