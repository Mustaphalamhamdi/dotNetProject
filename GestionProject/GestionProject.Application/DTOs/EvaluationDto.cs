namespace GestionProject.Application.DTOs
{
    public class EvaluationDto
    {
        public int Id { get; set; }
        public double Note { get; set; }
        public string? Commentaire { get; set; }
        public int SoutenanceId { get; set; }
        public int MembreJuryId { get; set; }
        public string? MembreJuryNom { get; set; }
    }

    public class CreateEvaluationDto
    {
        public double Note { get; set; }
        public string? Commentaire { get; set; }
        public int SoutenanceId { get; set; }
        public int MembreJuryId { get; set; }
    }

    public class UpdateEvaluationDto
    {
        public int Id { get; set; }
        public double Note { get; set; }
        public string? Commentaire { get; set; }
        public int SoutenanceId { get; set; }
        public int MembreJuryId { get; set; }
    }
}
