public class Projet
{
    public int Id { get; set; }
    public string Titre { get; set; }
    public string Type { get; set; } // PFE ou PFA
    public string Statut { get; set; } // Proposé, En cours, Soutenu
    public int EtudiantId { get; set; }
    public Etudiant Etudiant { get; set; }
    public int EncadrantAcademiqueId { get; set; }
    public Encadrant EncadrantAcademique { get; set; }
    public int? EncadrantProfessionnelId { get; set; }
    public Encadrant EncadrantProfessionnel { get; set; }
    public ICollection<Rapport> Rapports { get; set; }
    public ICollection<Seance> Seances { get; set; }
    public Soutenance Soutenance { get; set; }
}