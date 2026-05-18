namespace GestionProject.Application.DTOs
{
    public class SeanceDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public string? Commentaires { get; set; }
        public int ProjetId { get; set; }
        public string? ProjetTitre { get; set; }
        public int EncadrantId { get; set; }
        public string? EncadrantNom { get; set; }
    }

    public class CreateSeanceDto
    {
        public DateTime Date { get; set; }
        public string Type { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public string? Commentaires { get; set; }
        public int ProjetId { get; set; }
        public int EncadrantId { get; set; }
    }

    public class UpdateSeanceDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public string? Commentaires { get; set; }
        public int ProjetId { get; set; }
        public int EncadrantId { get; set; }
    }
}
