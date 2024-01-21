using hospedaria.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Seja bem vindo ao sistema de hospedaria!");

List<Suite> suites = [];
List<Pessoa> pessoasSemReserva = [];

bool exibirMenu = true;
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar pessoa");
    Console.WriteLine("2 - Cadastrar suite");
    Console.WriteLine("3 - Cadastrar reserva");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            Console.WriteLine("Informe os dados da pessoa.");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine().ToUpper();
            Console.WriteLine("Sobrenome: ");
            string sobrenome = Console.ReadLine().ToUpper();
            pessoasSemReserva.Add(new Pessoa(nome, sobrenome));
            break;
        case "2":
            Console.WriteLine("Informe os dados da suite.");
            Console.WriteLine("Tipo da suite: ");
            string tipoSuite = Console.ReadLine().ToUpper();
            Console.WriteLine("Capacidade: ");
            int capacidade = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Valor da diária: ");
            decimal valorDiaria = Convert.ToDecimal(Console.ReadLine());
            suites.Add(new Suite(tipoSuite, capacidade, valorDiaria));
            break;
        case "3":
            if (suites.Count == 0)
                Console.WriteLine("Nenhuma suite cadastrada.");
            else if (pessoasSemReserva.Count == 0)
                Console.WriteLine("Nenhuma pessoa cadastrada.");
            else
            {
                Console.WriteLine("Informe os dados da reserva.");

                Console.WriteLine("Escolha a suite:");
                Console.WriteLine(string.Join("\n", suites.Select(suite => suite.TipoSuite)));
                string suiteSelecionada = Console.ReadLine().ToUpper();
                var suite = suites.FirstOrDefault(suite => suite.TipoSuite.Contains(suiteSelecionada));
                if (suite == null)
                    Console.WriteLine("Suite não encontrada.");
                else
                {
                    List<Pessoa> pessoasDessaReserva = [];
                    Console.WriteLine("Escolha as pessoas:");
                    for (int i = 1; i <= suite.Capacidade; i++)
                    {
                        Console.WriteLine($"Selecione a pessoa #{i}");
                        Console.WriteLine(string.Join("\n", pessoasSemReserva.Select(p => $"{p.Nome} {p.Sobrenome}")));
                        string pessoaSelecionada = Console.ReadLine().ToUpper();
                        var pessoa = pessoasSemReserva.FirstOrDefault(p => p.ToString().Contains(pessoaSelecionada));
                        if (pessoa == null)
                            Console.WriteLine("Pessoa não encontrada.");
                        else
                        {
                            pessoasDessaReserva.Add(pessoa);
                            pessoasSemReserva.Remove(pessoa);
                        }
                    }
                    Console.WriteLine("Informe os dias da reservas: ");
                    int diasReservados = Convert.ToInt32(Console.ReadLine());
                    Reserva reserva = new() { DiasReservados = diasReservados };
                    reserva.CadastrarSuite(suite);
                    reserva.CadastrarHospedes(pessoasDessaReserva);
                    if (reserva.ObterQuantidadeHospedes() < reserva.Suite.Capacidade)
                        Console.WriteLine("Aviso! Essa reserva possui uma quantidade menor de pessoas do que a capacidade permitida da suite.");
                    Console.WriteLine(reserva);
                }
            }
            break;
        case "4":
            exibirMenu = false;
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");