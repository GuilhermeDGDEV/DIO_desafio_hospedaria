
namespace hospedaria.Models;

public class Reserva
{
    public List<Pessoa> Hospedes { get; set; } = [];
    public Suite Suite { get; set; }
    public int DiasReservados { get; set; }

    public void CadastrarHospedes(List<Pessoa> pessoas) {
        if (pessoas.Count <= Suite.Capacidade) Hospedes = pessoas;
    }

    public void CadastrarSuite(Suite suite) => Suite = suite;

    public int ObterQuantidadeHospedes() => Hospedes.Count;

    public decimal CalcularValorDiaria() {
        decimal valorTotal = DiasReservados * Suite.ValorDiaria;
        return valorTotal * (DiasReservados >= 10 ? 0.9M : 1);
    }

    public override string ToString()
    {
        string retorno = $"Dados da reserva:\nSuite: {Suite.TipoSuite}\nHospedes: {string.Join(',', Hospedes.Select(p => p.Nome))}\n";
        retorno += "Valor da diária: " + CalcularValorDiaria();
        return retorno;
    }
}
