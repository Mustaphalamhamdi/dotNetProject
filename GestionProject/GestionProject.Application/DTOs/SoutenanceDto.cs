namespace GestionProject.Application.DTOs
{
    public class SoutenanceDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Lieu { get; set; } = string.Empty;
        public double NoteFinale { get; set; }
        public int ProjetId { get; set; }
        public string? ProjetTitre { get; set; }
        public List<MembreJuryDto> MembresJury { get; set; } = new();
    }

    public class CreateSoutenanceDto
    {
        public DateTime Date { get; set; }
        public string Lieu { get; set; } = string.Empty;
        public int ProjetId { get; set; }
        public List<int> MembresJuryIds { get; set; } = new();
    }

    public class UpdateSoutenanceDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Lieu { get; set; } = string.Empty;
        public double NoteFinale { get; set; }
        public int ProjetId { get; set; }
        public List<int> MembresJuryIds { get; set; } = new();
    }
}
