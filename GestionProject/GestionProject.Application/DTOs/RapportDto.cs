namespace GestionProject.Application.DTOs
{
    public class RapportDto
    {
        public int Id { get; set; }
        public string Version { get; set; } = string.Empty;
        public DateTime DateSoumission { get; set; }
        public string CheminFichier { get; set; } = string.Empty;
        public int ProjetId { get; set; }
        public string? ProjetTitre { get; set; }
    }

    public class CreateRapportDto
    {
        public string Version { get; set; } = string.Empty;
        public string CheminFichier { get; set; } = string.Empty;
        public int ProjetId { get; set; }
    }

    public class UpdateRapportDto
    {
        public int Id { get; set; }
        public string Version { get; set; } = string.Empty;
        public string CheminFichier { get; set; } = string.Empty;
        public int ProjetId { get; set; }
    }
}
