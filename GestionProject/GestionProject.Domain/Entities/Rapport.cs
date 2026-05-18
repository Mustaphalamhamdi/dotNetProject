public class Rapport
{
    public int Id { get; set; }
    public string Version { get; set; }
    public DateTime DateSoumission { get; set; }
    public string CheminFichier { get; set; }
    public int ProjetId { get; set; }
    public Projet Projet { get; set; }
    public ICollection<Feedback> Feedbacks { get; set; }
}