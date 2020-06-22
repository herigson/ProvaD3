using System;
using System.Net.WebSockets;
class Questao02
{
    static void Main()
    {
        Banco b1 = new Banco();
        b1.Program();
    }
}

struct Cliente
{
    public string Cpf;
    public string NomeCompleto;
    public string Telefone;
    public string DataDeNascimento;
    public int ContContaC;
    public int ContContaP;


    public void CadastroCliente()
    {


        Console.Write("Informe o CPF do cliente: ");
        this.Cpf = Console.ReadLine();
        Console.Write("Informe o nome completo do cliente: ");
        this.NomeCompleto = Console.ReadLine();
        Console.Write("Informe o telefone do cliente: ");
        this.Telefone = Console.ReadLine();
        Console.Write("Informe a data de nascimento do cliente: ");
        this.DataDeNascimento = Console.ReadLine();

    }

}
struct ContaCorrente
{
    public string Codigo;
    public double Saldo;
    public double Credito;
    public Cliente Cliente;

    public void CadastroContaCorrente(Cliente cliente)
    {
        this.Cliente = cliente;
        Console.Write("Informe o código da conta corrente: ");
        this.Codigo = Console.ReadLine();
        Console.Write("Informe o saldo inicial da conta corrente: ");
        this.Saldo = double.Parse(Console.ReadLine());

    }

    public void Deposito()
    {
        Console.WriteLine("Saldo atual: {0}", this.Saldo);
        Console.WriteLine("Informe a quantia a ser depositada na conta {0}", this.Codigo);
        this.Saldo += double.Parse(Console.ReadLine());
    }

    public void ImprimirSaldoContaCorrente()
    {
        Console.WriteLine("Código: {0}", this.Codigo);
        Console.WriteLine("Saldo: {0:F2}", this.Saldo);
    }

}
struct ContaPoupança
{
    public string Codigo;
    public double Saldo;
    public double TaxaRendimento;
    public Cliente Cliente;

    public void CadastroContaPoupança(Cliente cliente)
    {
        this.Cliente = cliente;
        Console.Write("Informe o código da conta poupança: ");
        this.Codigo = Console.ReadLine();
        Console.Write("Informe o saldo inicial da conta poupança: ");
        this.Saldo = double.Parse(Console.ReadLine());

    }
    public void Deposito()
    {
        Console.WriteLine("Saldo atual: {0}",this.Saldo);
        Console.WriteLine("Informe a quantia a ser depositada na conta {0}", this.Codigo);
        this.Saldo += double.Parse(Console.ReadLine());
    }   

    public void ImprimirSaldoContaPoupança()
    {
        Console.WriteLine("Código: {0}",this.Codigo);
        Console.WriteLine("Saldo: {0:F2}",this.Saldo);
    }
}

struct Agencia
{
    public string Codigo;
    public string Endereço;
    public Cliente[] Clientes;
    public ContaCorrente[] ContaCorrentes;
    public ContaPoupança[] ContaPoupanças;
    public int ClientesCadastrados;
    public int TagAtivo;
    public int ContasCorrentesCadastradas;
    public int ContasPoupançaCadastradas;

    public void CadastroAgencias()
    {
        Console.Write("Informe o o código da agência: ");
        this.Codigo = Console.ReadLine();
        Console.Write("Informe o endereço da agencia: ");
        this.Endereço = Console.ReadLine();
        this.TagAtivo = 1;

    }
    public void CadastrarConta()
    {
        int opcao;
        this.Clientes = new Cliente[5];
        this.ContaCorrentes = new ContaCorrente[10];
        this.ContaPoupanças = new ContaPoupança[10];
        Console.WriteLine("Abertura de conta");
        if (this.ClientesCadastrados < 3)
        {
            this.Clientes[ClientesCadastrados].CadastroCliente();
            this.ClientesCadastrados++;
            Console.WriteLine("Cadastro Efetuado Com Sucesso! Aperte uma tecla para continuar...");
            Console.ReadKey(true);
        }
        else
            Console.WriteLine("É permitido o cadastro de somente 3 clientes por agência");
        do
        {
            Console.WriteLine("1 - Abrir conta corrente\n2 -  Abrir conta poupança\n3 - Sair");
            opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    if (this.Clientes[this.ClientesCadastrados -1].ContContaC == 0)
                    {
                        this.ContaCorrentes[this.ContasCorrentesCadastradas].CadastroContaCorrente(this.Clientes[this.ClientesCadastrados]);
                        this.Clientes[this.ClientesCadastrados-1].ContContaC++;
                        this.ContasCorrentesCadastradas++;
                        Console.WriteLine("Cadastro Efetuado Com Sucesso! Aperte uma tecla para continuar...");
                        Console.ReadKey(true);
                    }else
                        Console.WriteLine("Este cliente ja possuí uma conta conta corrente!");
                    break;
                case 2:
                    if (this.Clientes[this.ClientesCadastrados - 1].ContContaP == 0)
                    {
                        this.ContaPoupanças[this.ContasPoupançaCadastradas].CadastroContaPoupança(this.Clientes[this.ClientesCadastrados]);
                        this.Clientes[this.ClientesCadastrados - 1].ContContaP++;
                        this.ContasPoupançaCadastradas++;
                        Console.WriteLine("Cadastro Efetuado Com Sucesso! Aperte uma tecla para continuar...");
                        Console.ReadKey(true);
                    }
                    else
                        Console.WriteLine("Este cliente ja possuí uma conta conta poupança!");
                    break;
                case 3:
                    Console.WriteLine("Cadastro finalizado");
                    break;

            }
        } while (opcao != 3);
    }
    public void ImprimirDadosAgencia()
    {
        Console.WriteLine("Código Da Agência: {0}", this.Codigo);
        Console.WriteLine("Endereço Da Agência: {0}", this.Endereço);
        Console.WriteLine("Total de Clientes: {0}", this.ClientesCadastrados);
    }
    public void ImprimirTodasAsContasAgencia()
    {

        for (int i = 0; i < this.Clientes.Length; i++)
        {
            if (this.ContasCorrentesCadastradas > 0)
                for (int j = 0; j < this.ContasCorrentesCadastradas; j++)
                {
                   
                }
        }
    }
    public int RetornaIndiceContaCorrente(ContaCorrente[] contas, string codigo)
    {
        int indiceConta = -1;
        for (int i = 0; i < contas.Length; i++)
        {
            if (contas[i].Codigo == codigo)
                indiceConta = i;
        }
        return indiceConta;
    }
    public int RetornaIndicePoupança(ContaPoupança[] contas, string codigo)
    {
        int indiceConta = -1;
        for (int i = 0; i < contas.Length; i++)
        {
            if (contas[i].Codigo == codigo)
                indiceConta = i;
        }
        return indiceConta;
    }
    public double SaldoTotalContaCorrenteAgencia()
    {
        double saldo = 0;
        for (int i = 0; i < this.ContasCorrentesCadastradas; i++)
        {
            saldo += this.ContaCorrentes[i].Saldo;
        }
        return saldo;
    }
    public double SaldoTotalContaPoupançaAgencia()
    {
        double saldo = 0;
        for (int i = 0; i < this.ContasPoupançaCadastradas; i++)
        {
            saldo += this.ContaPoupanças[i].Saldo;
        }
        return saldo;
    }
    public void ExcluirContaCorrente(int indice)
    {
        if (indice < this.ContasCorrentesCadastradas)
        {
            ContaCorrente aux;
            aux = this.ContaCorrentes[indice];
            this.ContaCorrentes[indice] = this.ContaCorrentes[this.ContasCorrentesCadastradas];
            this.ContaCorrentes[this.ContasCorrentesCadastradas] = aux;
            this.ContasCorrentesCadastradas--;
        }
    }
    public void ExcluirContaPoupança(int indice)
    {
        if (indice < this.ContasCorrentesCadastradas)
        {
            ContaPoupança aux;
            aux = this.ContaPoupanças[indice];
            this.ContaPoupanças[indice] = this.ContaPoupanças[this.ContasPoupançaCadastradas];
            this.ContaPoupanças[this.ContasPoupançaCadastradas] = aux;
            this.ContasPoupançaCadastradas--;
        }
    }


}

struct Banco
{
    public string Nome;
    public string Codigo;
    public Agencia[] Agencias;
    public int NumAagenciasCadastradas;

    public Banco(string nome, string codigo, Agencia[] agencias, int numAgenciasCadastradas)
    {
        this.Nome = nome;
        this.Codigo = codigo;
        this.Agencias = agencias;
        this.NumAagenciasCadastradas = numAgenciasCadastradas;
    }
    public void Program()
    {
        int opcao, indiceAgencia, indiceConta, opcaoConta;
        string codigoAgencia, codigoConta;

        Console.WriteLine("Bem vindo ao programa de administração do seu banco!");
        Console.Write("Informe o nome do banco: ");
        this.Nome = Console.ReadLine();
        Console.Write("Informe o código do banco: ");
        this.Codigo = Console.ReadLine();
        Console.Clear();

        do
        {
            Console.Clear();
            Console.WriteLine("Administração Banco {0}", this.Nome);
            Console.WriteLine("1  - Incluir Agências");
            Console.WriteLine("2  - Excluir Agências");
            Console.WriteLine("3  - Impressão Dos Dados De Cada Agência");
            Console.WriteLine("4  - Saldo Total Depositado No Banco");
            Console.WriteLine("5  - Saldo Total Em Conta Corrente No Banco");
            Console.WriteLine("6  - Saldo Total Em Conta Poupança No Banco");
            Console.WriteLine("7  - Abertura De Conta");
            Console.WriteLine("8  - Encerramento De Conta");
            Console.WriteLine("13 - Realizar Depósito em Contas Correntes");
            Console.WriteLine("14 - Realizar Depósito em Contas Poupança");

            Console.WriteLine("0 - Encerrar o programa de administração");
            Console.Write("Informe a opção desejada : ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 0:
                    Console.WriteLine("Programa Encerrado!");
                    break;
                case 1:
                    Console.Clear();
                    IncluirAgencias();
                    break;
                case 2:
                    Console.Clear();
                    ImprimirDadosTodasAgencias();
                    Console.Write("Informe o código da agência que deseja excluir?: ");
                    codigoAgencia = Console.ReadLine();
                    indiceAgencia = RetornaIndiceAgencia(this.Agencias, codigoAgencia);
                    ExcluirAgencias(indiceAgencia);
                    break;
                case 3:
                    Console.Clear();
                    //ImprimirDadosTodasAgencias();
                    Console.Write("\n\nInforme o código da agência: ");
                    codigoAgencia = Console.ReadLine();
                    indiceAgencia = RetornaIndiceAgencia(this.Agencias, codigoAgencia);
                    this.Agencias[indiceAgencia].ImprimirDadosAgencia();
                    Console.WriteLine("Aperte uma tecla para continuar...");
                    Console.ReadKey(true);
                    break;
                case 4:
                    Console.Clear();
                    double saldoTotalBanco = SaldoTotalContaCorrenteBanco() + SaldoTotalContaPoupançaBanco();
                    Console.WriteLine("Saldo Total Depositado No Banco: {0:F2}", saldoTotalBanco);
                    Console.WriteLine("Aperte uma tecla para continuar...");
                    Console.ReadKey(true);
                    break;
                case 5:
                    Console.Clear();
                    double saltoTotalCcBanco = SaldoTotalContaCorrenteBanco();
                    Console.WriteLine("Saldo Total Depositado No Banco: {0:F2}", saltoTotalCcBanco);
                    Console.WriteLine("Aperte uma tecla para continuar...");
                    Console.ReadKey(true);
                    break;
                case 6:
                    Console.Clear();
                    double saltoTotalCpBanco = SaldoTotalContaPoupançaBanco();
                    Console.WriteLine("Saldo Total Depositado No Banco: {0:F2}", saltoTotalCpBanco);
                    Console.WriteLine("Aperte uma tecla para continuar...");
                    Console.ReadKey(true);
                    break;
                case 7:
                    Console.Clear();
                    ImprimirDadosTodasAgencias();
                    Console.Write("\n\nInforme o código da agência: ");
                    codigoAgencia = Console.ReadLine();
                    indiceAgencia = RetornaIndiceAgencia(this.Agencias, codigoAgencia);
                    this.Agencias[indiceAgencia].CadastrarConta();
                    break;
                case 8:
                    Console.Clear();
                    Console.WriteLine("1 - Encerrar conta corrente\n2 - Encerrar conta poupança\n0 - Sair");
                    opcaoConta = int.Parse(Console.ReadLine());
                    switch (opcaoConta) 
                    {
                        case 0:
                            break;
                        case 1:
                            Console.Clear();
                            ImprimirDadosTodasAgencias();
                            Console.Write("\n\nInforme o código da agência: ");
                            codigoAgencia = Console.ReadLine();
                            indiceAgencia = RetornaIndiceAgencia(this.Agencias, codigoAgencia);
                            Console.Write("Informe o código da conta: ");
                            codigoConta = Console.ReadLine();
                            indiceConta = this.Agencias[indiceAgencia].RetornaIndiceContaCorrente(this.Agencias[indiceAgencia].ContaCorrentes, codigoConta);
                            this.Agencias[indiceAgencia].ExcluirContaCorrente(indiceConta);
                            break;
                        case 2:
                            Console.Clear();
                            ImprimirDadosTodasAgencias();
                            Console.Write("\n\nInforme o código da agência: ");
                            codigoAgencia = Console.ReadLine();
                            indiceAgencia = RetornaIndiceAgencia(this.Agencias, codigoAgencia);
                            Console.Write("Informe o código da conta: ");
                            codigoConta = Console.ReadLine();
                            indiceConta = this.Agencias[indiceAgencia].RetornaIndicePoupança(this.Agencias[indiceAgencia].ContaPoupanças, codigoConta);
                            this.Agencias[indiceAgencia].ExcluirContaPoupança(indiceConta);
                            break;
                    }
                    
                    break;
                case 13:
                    Console.Clear();
                    ImprimirDadosTodasAgencias();
                    Console.Write("\n\nInforme o código da agência: ");
                    codigoAgencia = Console.ReadLine();
                    indiceAgencia = RetornaIndiceAgencia(this.Agencias, codigoAgencia);
                    Console.Write("Informe o código da conta: ");
                    codigoConta = Console.ReadLine();
                    indiceConta = this.Agencias[indiceAgencia].RetornaIndiceContaCorrente(this.Agencias[indiceAgencia].ContaCorrentes, codigoConta);
                    this.Agencias[indiceAgencia].ContaCorrentes[indiceConta].Deposito();
                    break;
                case 14:
                    Console.Clear();
                    ImprimirDadosTodasAgencias();
                    Console.Write("\n\nInforme o código da agência: ");
                    codigoAgencia = Console.ReadLine();
                    indiceAgencia = RetornaIndiceAgencia(this.Agencias, codigoAgencia);
                    Console.Write("Informe o código da conta: ");
                    codigoConta = Console.ReadLine();
                    indiceConta = this.Agencias[indiceAgencia].RetornaIndicePoupança(this.Agencias[indiceAgencia].ContaPoupanças, codigoConta);
                    this.Agencias[indiceAgencia].ContaPoupanças[indiceConta].Deposito();
                    break;
                

            }
        } while (opcao != 0);


    }
    public void IncluirAgencias()
    {
        int numAgencias;

        do
        {
            Console.WriteLine("Deseja incluir quantas agências? ");
            this.NumAagenciasCadastradas = int.Parse(Console.ReadLine());
            numAgencias = this.NumAagenciasCadastradas;

            if (this.NumAagenciasCadastradas > 5)
                Console.WriteLine("Você pode cadastrar no máximo 5 agências!");

        } while (this.NumAagenciasCadastradas < 1 && this.NumAagenciasCadastradas > 5);

        this.Agencias = new Agencia[5];

        for (int i = 0; i < numAgencias; i++)
        {
            Console.WriteLine("Cadastro Da {0}ª Agência ", i + 1);
            Agencias[i].CadastroAgencias();
            Console.Clear();
        }
    }
    public void ExcluirAgencias(int indice)
    {
        if (indice < this.NumAagenciasCadastradas)
        {
            Agencia aux;
            aux = this.Agencias[indice];
            this.Agencias[indice] = this.Agencias[NumAagenciasCadastradas];
            this.Agencias[this.NumAagenciasCadastradas] = aux;
            this.Agencias[this.NumAagenciasCadastradas].TagAtivo = 0;
            this.NumAagenciasCadastradas--;

        }
    }
    public void ImprimirDadosTodasAgencias()
    {
        Console.WriteLine("Agencias Cadastradas");
        for (int i = 0; i < this.NumAagenciasCadastradas; i++)
        {
            this.Agencias[i].ImprimirDadosAgencia();
            Console.WriteLine();
        }
    }
    public int RetornaIndiceAgencia(Agencia[] agencias, string codigo)
    {
        int indiceAgencia = -1;
        for (int i = 0; i < agencias.Length; i++)
        {
            if (agencias[i].Codigo == codigo)
                indiceAgencia = i;
        }

        return indiceAgencia;
    }
    public double SaldoTotalContaCorrenteBanco()
    {
        double saldo = 0;
        for(int i = 0; i < this.Agencias.Length; i++)
        {
            saldo += this.Agencias[i].SaldoTotalContaCorrenteAgencia();
        }
        return saldo;
    }
    public double SaldoTotalContaPoupançaBanco()
    {
        double saldo = 0;
        for (int i = 0; i < this.Agencias.Length; i++)
        {
            saldo += this.Agencias[i].SaldoTotalContaPoupançaAgencia();
        }
        return saldo;
    }
}


