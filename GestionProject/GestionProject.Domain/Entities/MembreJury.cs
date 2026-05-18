public class MembreJury
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Email { get; set; }
    public ICollection<Soutenance> Soutenances { get; set; }
}