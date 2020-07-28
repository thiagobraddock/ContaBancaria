using System;
using System.IO;

class MainClass {
  public static void Main (string[] args) {
    
   
   //instanciar a classe Conta
    Conta c1 = new Conta();

    string repete = "";

    //gerar numero aleatorio para Numero da Conta Bancaria
    Random aleatorio = new Random();    
    c1.numero = aleatorio.Next(1,10000);
 
    //Pegar o nome do titular da Conta
    Console.Write("Informe seu nome completo: ");
    Console.ForegroundColor = ConsoleColor.Green;
    c1.nome = Console.ReadLine();
    Console.ForegroundColor = ConsoleColor.White; 

    do
    {
      Console.Clear();
      Console.WriteLine("=============================================");
      Console.Write("BEM VINDO {0} - SALDO -> ",c1.nome); 
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("R{0}", c1.saldo.ToString("c"));
      Console.ForegroundColor = ConsoleColor.White;
      Console.WriteLine("=============================================");
      Console.WriteLine("\n");
      Console.WriteLine("Escolha uma das opções abaixo: ");
      Console.WriteLine("1 - DEPOSITO ");
      Console.WriteLine("2 - SAQUE ");
      Console.WriteLine("3 - EMPRESTAR ");
      Console.WriteLine("4 - SAIR ");
      Console.Write("opção >> ");
      Console.ForegroundColor = ConsoleColor.Green;
      int opcao = int.Parse(Console.ReadLine());

      //Cria o arquivo de texto
      StreamWriter io = new StreamWriter("conta.txt", true);

      double valor_dep = 0;
      double valor_saq = 0;
      DateTime hoje = DateTime.Today;
      
      switch(opcao)
      {
        case 1: 
          Console.Write("Valor a depositar: R$");
          valor_dep = double.Parse(Console.ReadLine());
          c1.depositar(valor_dep);
          //Salvar o log
          io.WriteLine(hoje.ToString("dd/MM/yyyy") + ";" + opcao + ";" + c1.nome + ";" + valor_dep + ";" + c1.saldo);
          io.Close();
          break;
        case 2:
          Console.Write("Valor a sacar: R$");
          valor_saq = double.Parse(Console.ReadLine());
          c1.sacar(valor_saq);
          io.WriteLine(hoje.ToString("dd/MM/yyyy") + ";" + opcao + ";" + c1.nome + ";" + valor_saq + ";" + c1.saldo);
          io.Close();
          break;
        case 3:
          int qtde_parc;
          double v_emp; 

          Console.Write("Digite o valor do Emprestimo R$ ");
          v_emp = double.Parse(Console.ReadLine());
          Console.Write("Informe a quantidade de parcelas 12, 24, 36, 48: ");
          qtde_parc = int.Parse(Console.ReadLine());
            
          c1.emprestar(v_emp, qtde_parc);
          break;
          

        case 4:
          Console.Write("Pressione Enter para Sair");
          Console.ReadKey();
          Environment.Exit(0);
          break;
        default:
          Console.Write("Opção Inválida.");
          break;
      }

      Console.ForegroundColor = ConsoleColor.White;
      Console.Write("Deseja realizar outra operação(s/n): ");
      repete = Console.ReadLine();
    }while(repete == "s");
      Console.WriteLine("ENCERRANDO SISTEMA ...");
    }
}