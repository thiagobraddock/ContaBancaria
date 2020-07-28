using System;


class Conta{
  //Atributos
  public int numero;
  public string nome;
  public double saldo;
  
  

  //Método para realizar Depósitos
  //@param double valor
  public void depositar(double valor){
    this.saldo += valor;
    Console.WriteLine("Saldo atual: R" + saldo.ToString("c"));
  }

  //Método para realizar Emprestimo//
  public void emprestar( double v_emp, int qtde_parc)
  {
    double total_financiado = 0;
    double v_parc = 0;
    double juros = 0.0255;

    total_financiado = (qtde_parc* juros*v_emp);
    v_parc = (total_financiado+v_emp)/qtde_parc;

    // Acrescenta o Emprestimo ao Saldo//
    this.saldo += v_emp;
     Console.WriteLine($"Valor do Empréstimo -> {v_emp.ToString("c")}");
     Console.WriteLine($"Valor da Parcela -> {v_parc.ToString("c")}");
     Console.WriteLine($"Valor total do Empréstimo -> {total_financiado.ToString("c")}");

     //Salvartxt("Emprestimo", v_emp);

  }


  // Método para realizar Saque
  //@param double valor
   public void sacar(double valor){
    Console.WriteLine("Saque de R" + valor.ToString("c"));
    //se houver saldo disponivel, realiza o saque
    if(this.saldo >= valor)
    {
      this.saldo -= valor;
      Console.WriteLine("Saldo Atual R" + this.saldo.ToString("c") + "\n");
    }
    else
    {
      Console.WriteLine("Saldo Insuficiente: R" + this.saldo.ToString("c") + "\n");
    }
  }
}
