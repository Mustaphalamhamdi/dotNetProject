public class Feedback
{
    public int Id { get; set; }
    public string Contenu { get; set; }
    public DateTime Date { get; set; }
    public int RapportId { get; set; }
    public Rapport Rapport { get; set; }
    public int EncadrantId { get; set; }
    public Encadrant Encadrant { get; set; }
}