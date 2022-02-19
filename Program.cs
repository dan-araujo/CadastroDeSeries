using CadastroDeSeries.Classes;
using System;

namespace CadastroDeSeries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        System.Console.Clear();
                        break;
                    default:
                        /* Exceção que é gerada se for digitado um valor diferente, do intervalo de
                           valores definidos pelo método ObterOpcaoUsuario() */
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            System.Console.WriteLine("Obrigado por testar esse aplicativo.");
            System.Console.WriteLine();
        }

        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir nova série");
            /* GetValues - Vai retornar a listagem de todos os gêneros com seus indices (que estão em formato enum) */
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                /* Apresenta na tela toda a listagem dos gêneros através do valor i no foreach
                   GetName - Praticamente retorna o nome da constante do enum especificado pelo seu valor */
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = System.Console.ReadLine();

            System.Console.WriteLine("Digite o Ano em que a série começou: ");
            int entradaAno = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Digite a descrição da Série: ");
            string entradaDescricao = System.Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }

        private static void ListarSeries()
        {
            System.Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if (lista.Count() == 0)
            {
                System.Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                System.Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static void AtualizarSerie()
        {
            System.Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(System.Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = System.Console.ReadLine();

            System.Console.WriteLine("Digite o Ano em que a série começou: ");
            int entradaAno = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Digite a descrição da Série: ");
            string entradaDescricao = System.Console.ReadLine();

            Serie atualizarSerie = new Serie(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizarSerie);
        }

        private static void VisualizarSerie()
        {
            System.Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(System.Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            System.Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            System.Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(System.Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Cadastro de Séries");
            System.Console.WriteLine("Informe a opção desejada:");
            System.Console.WriteLine("1 - Listar séries");
            System.Console.WriteLine("2 - Inserir nova série");
            System.Console.WriteLine("3 - Atualizar série");
            System.Console.WriteLine("4 - Excluir série");
            System.Console.WriteLine("5 - Visualizar série");
            System.Console.WriteLine("C - Limpar Tela");
            System.Console.WriteLine("X - Sair");
            System.Console.WriteLine();

            string opcaoUsuario = System.Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
