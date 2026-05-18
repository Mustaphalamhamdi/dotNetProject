namespace GestionProject.Application.DTOs
{
    public class ProjetDto
    {
        public int Id { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Statut { get; set; } = string.Empty;
        public int EtudiantId { get; set; }
        public string? EtudiantNom { get; set; }
        public int EncadrantAcademiqueId { get; set; }
        public string? EncadrantAcademiqueNom { get; set; }
        public int? EncadrantProfessionnelId { get; set; }
        public string? EncadrantProfessionnelNom { get; set; }
    }

    public class CreateProjetDto
    {
        public string Titre { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int EtudiantId { get; set; }
        public int EncadrantAcademiqueId { get; set; }
        public int? EncadrantProfessionnelId { get; set; }
    }

    public class UpdateProjetDto
    {
        public int Id { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Statut { get; set; } = string.Empty;
        public int EtudiantId { get; set; }
        public int EncadrantAcademiqueId { get; set; }
        public int? EncadrantProfessionnelId { get; set; }
    }
}
