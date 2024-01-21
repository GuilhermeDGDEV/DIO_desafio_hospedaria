namespace hospedaria.Models;

public class Pessoa(string nome, string sobrenome)
{
    public string Nome { get; set; } = nome;
    public string Sobrenome { get; set; } = sobrenome;
    public override string ToString() => $"{Nome} {Sobrenome}";
}