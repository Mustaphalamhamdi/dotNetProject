public class Seance
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Type { get; set; } // Presentielle ou Distancielle
    public string Notes { get; set; }
    public string Commentaires { get; set; }
    public int ProjetId { get; set; }
    public Projet Projet { get; set; }
    public int EncadrantId { get; set; }
    public Encadrant Encadrant { get; set; }
}