public class Soutenance
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Lieu { get; set; }
    public double NoteFinale { get; set; }
    public int ProjetId { get; set; }
    public Projet Projet { get; set; }
    public ICollection<MembreJury> MembresJury { get; set; }
}