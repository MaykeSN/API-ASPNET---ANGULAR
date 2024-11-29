namespace ApiAngular.Models;

public class Pessoa
{
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public Pessoa(string nome)
    {
        Id = Guid.NewGuid();
        Nome = nome;
    }
}