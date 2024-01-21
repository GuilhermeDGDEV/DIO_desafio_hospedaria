
namespace hospedaria.Models;

public class Reserva
{
    public List<Pessoa> Hospedes { get; set; } = [];
    Suite Suite { get; set; }
    public int DiasReservados { get; set; }

    public void CadastrarHospedes(List<Pessoa> pessoas) => Hospedes.AddRange(pessoas);

    public void CadastrarSuite(Suite suite) => Suite = suite;

    public int ObterQuantidadeHospedes() => Hospedes.Count;

    public decimal CalcularValorDiaria() => DiasReservados * Suite.ValorDiaria;
}
