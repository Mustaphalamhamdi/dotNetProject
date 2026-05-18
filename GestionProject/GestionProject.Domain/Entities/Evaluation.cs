public class Evaluation
{
    public int Id { get; set; }
    public double Note { get; set; }
    public string Commentaire { get; set; }
    public int SoutenanceId { get; set; }
    public Soutenance Soutenance { get; set; }
    public int MembreJuryId { get; set; }
    public MembreJury MembreJury { get; set; }
}