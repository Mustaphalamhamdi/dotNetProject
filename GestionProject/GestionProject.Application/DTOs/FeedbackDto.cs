namespace GestionProject.Application.DTOs
{
    public class FeedbackDto
    {
        public int Id { get; set; }
        public string Contenu { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int RapportId { get; set; }
        public int EncadrantId { get; set; }
        public string? EncadrantNom { get; set; }
    }

    public class CreateFeedbackDto
    {
        public string Contenu { get; set; } = string.Empty;
        public int RapportId { get; set; }
        public int EncadrantId { get; set; }
    }

    public class UpdateFeedbackDto
    {
        public int Id { get; set; }
        public string Contenu { get; set; } = string.Empty;
        public int RapportId { get; set; }
        public int EncadrantId { get; set; }
    }
}
