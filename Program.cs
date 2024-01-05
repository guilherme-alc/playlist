using System.Runtime.Intrinsics.X86;

string mensagemDeBoasVindas = "\nMinha playlist de músicas românticas\n";

Dictionary<string, List<double>> musicasRegistradas = new Dictionary<string, List<double>>();
musicasRegistradas.Add("Esperando Você - Terno Rei", new List<double> { 10, 9.5, 7 });
musicasRegistradas.Add("Balada do Amor Inabalável - Skank", new List<double>());
musicasRegistradas.Add("Amor Meu Grande Amor - Barão Vermelho", new List<double>());
musicasRegistradas.Add("Você E Linda - Caetano Veloso", new List<double>());
musicasRegistradas.Add("Eu Amo Você - Terno Rei", new List<double>());
musicasRegistradas.Add("Crush - The Smashing Pumpkins", new List<double>());
musicasRegistradas.Add("Everything Reminds Me Of Her - Elliot Smith", new List<double>());
musicasRegistradas.Add("My Kind of Woman - Mac DeMarco", new List<double>());

void ExibeBoasVindas()
{
    Console.Clear();
    Console.WriteLine(@"
█░░ █▀█ █░█ █▀▀   █▀ █▀█ █▄░█ █▀▀   █▀▄▀█ █░█ █▀ █ █▀▀ █▀
█▄▄ █▄█ ▀▄▀ ██▄   ▄█ █▄█ █░▀█ █▄█   █░▀░█ █▄█ ▄█ █ █▄▄ ▄█");
    Console.WriteLine(mensagemDeBoasVindas);
}

void MostraMusicasRegistradas()
{
    ExibirTitulo("Músicas Registradas");

    for (int i = 0; i < musicasRegistradas.Count; i++)
    {
        string musica = musicasRegistradas.ElementAt(i).Key;
        Console.WriteLine($"{i + 1} {musica}");
    }

    Thread.Sleep(1000);
    Console.WriteLine("\nPressione enter para voltar ao menu");

    while (true)
    {
        ConsoleKeyInfo tecla = Console.ReadKey();
        if (tecla.Key == ConsoleKey.Enter)
        {
            break;
        }
        else
        {
            Console.WriteLine("\nPressione enter para voltar ao menu");
        }
    }

    ExibeOpcoesMenu();
}

void RegistrarMusica()
{
    bool continuaExec = true;
    do
    {
        Console.Clear();
        ExibirTitulo("Registro de músicas");

        Console.Write("Digite o nome da música que deseja adicionar: ");
        string nomeDaMusica = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(nomeDaMusica) && !musicasRegistradas.ContainsKey(nomeDaMusica))
        {
            musicasRegistradas.Add(nomeDaMusica, new List<double>());
            Console.WriteLine($"\nA música {nomeDaMusica} foi registrada com sucesso!");

        }
        else
        {
            Console.WriteLine($"\nErro ao adicionar música. Você digitou uma música já existente ou um nome vazio");

        }

        continuaExec = ContinuaExec("\nDigite \"s\" para adicionar mais uma música ou \"n\" para voltar ao menu de opções: ");

    } while (continuaExec);
    ExibeOpcoesMenu();
}

void RemoverMusica()
{
    bool continuaExec = true;
    do
    {
        Console.Clear();
        ExibirTitulo("Remover música");

        foreach (KeyValuePair<string, List<double>> musica in musicasRegistradas)
        {
            Console.Write("Música {0}", musica.Key);
            Console.Write(" | Notas: ");

            foreach (double nota in musica.Value)
            {
                Console.Write($"{nota} ");
            }

            Console.WriteLine();
        }

        Console.Write("\n\nDigite o nome da música que deseja remover: ");
        string nomeMusica = Console.ReadLine();

        if (musicasRegistradas.ContainsKey(nomeMusica))
        {
            musicasRegistradas.Remove(nomeMusica);
            Console.WriteLine("\nA música {0} foi removida com sucesso!", nomeMusica);
        }
        else
        {
            Console.WriteLine("\nMúsica não encontrada");
        }

        continuaExec = ContinuaExec("\nDigite \"s\" para remover mais uma música ou \"n\" para voltar ao menu de opções: ");

    } while (continuaExec);
    ExibeOpcoesMenu();
}

void AvaliarMusica()
{
    bool continuaExec = true;
    do
    {
        Console.Clear();
        ExibirTitulo("Avaliar banda");

        for (int i = 0; i < musicasRegistradas.Count; i++)
        {
            string musica = musicasRegistradas.ElementAt(i).Key;
            Console.WriteLine($"{i + 1} {musica}");
        }

        Console.WriteLine("\nDigite a música que deseja avaliar ");
        string opcaoUsuario = Console.ReadLine();

        if (musicasRegistradas.ContainsKey(opcaoUsuario))
        {
            Console.WriteLine($"\nQual nota você quer dar para a música?");
            int nota = int.Parse(Console.ReadLine()!);

            musicasRegistradas[opcaoUsuario].Add(nota);
            Console.WriteLine("\nNota registrada com sucesso!");
        }
        else
        {
            Console.WriteLine($"\nA música {opcaoUsuario} não foi encontrada");
        }

        continuaExec = ContinuaExec("\nDigite \"s\" para avaliar mais uma música ou \"n\" para voltar ao menu de opções: ");

    } while (continuaExec);
    ExibeOpcoesMenu();
}

void ExibeMediaMusica()
{
    bool continuaExec = true;
    do
    {
        Console.Clear();
        ExibirTitulo("Média de avaliações");

        foreach (KeyValuePair<string, List<double>> musica in musicasRegistradas)
        {
            Console.Write("Música {0}", musica.Key);
            Console.Write(" | Notas: ");

            foreach (double nota in musica.Value)
            {
                Console.Write($"{nota} ");
            }

            Console.WriteLine();
        }

        Console.WriteLine("\nDigite o nome da música para calcular a média de avaliações");
        string nomeDaMusica = Console.ReadLine();

        if (musicasRegistradas.ContainsKey(nomeDaMusica))
        {
            double media = musicasRegistradas[nomeDaMusica].Average();
            Console.WriteLine($"\nA média dé avaliações da música {nomeDaMusica} é {media:F1}");
        }
        else
        {
            Console.WriteLine("\nMúsica não encontrada.");
        }

        continuaExec = ContinuaExec($"\nDeseja calcular mais uma média? Digite \"s\" ou \"n\": ");

    } while (continuaExec);
    ExibeOpcoesMenu();
}

void ExibeOpcoesMenu()
{
    ExibeBoasVindas();
    Console.WriteLine("Digite 1 para mostrar todas as músicas");
    Console.WriteLine("Digite 2 para adicionar uma música");
    Console.WriteLine("Digite 3 para remover uma música");
    Console.WriteLine("Digite 4 para avaliar uma música");
    Console.WriteLine("Digite 5 para exibir a média de uma música");
    Console.WriteLine("Digite 0 para sair");

    Console.Write("Digite sua opção: ");
    int opcaoUsuario = int.Parse(Console.ReadLine());

    Console.Clear();

    switch (opcaoUsuario)
    {
        case 1:
            MostraMusicasRegistradas();
            break;
        case 2:
            RegistrarMusica();
            break;
        case 3:
            RemoverMusica();
            break;
        case 4:
            AvaliarMusica();
            break;
        case 5:
            ExibeMediaMusica();
            break;
        case 0:
            Console.WriteLine("\nTchau tchau :)");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}

void ExibirTitulo(string titulo)
{
    int tamanhoTitulo = titulo.Length;
    string molduraTitulo = string.Empty.PadLeft(tamanhoTitulo, '*');
    Console.WriteLine(molduraTitulo);
    Console.WriteLine(titulo);
    Console.WriteLine(molduraTitulo + "\n");
}

static bool ContinuaExec(string contexto)
{
    bool continuaExec = true;

    Console.Write(contexto);
    char opcao = char.Parse(Console.ReadLine().ToLower());

    if (opcao == 'n')
    {
        continuaExec = false;
    }
    else if (opcao == 's')
    {
        continuaExec = true;
    }
    else
    {
        Console.WriteLine("Opção inválida!");
    }
    return continuaExec;
}

ExibeOpcoesMenu();