public class Encadrant
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Email { get; set; }
    public string Type { get; set; } // Academique ou Professionnel
    public ICollection<Projet> ProjetsEncadres { get; set; }
}