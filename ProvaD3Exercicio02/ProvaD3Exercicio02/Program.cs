using System;
using System.Net.WebSockets;
/*2) Escreva o algoritmo de controle das contas de um banco. Considere que o banco possui
nome, um código e apenas 5 agências. Considere também que cada agência possui um
código, endereço, telefone e apenas 3 clientes. Ao abrirem conta em uma das agências do
banco, os clientes devem informar: CPF, nome completo, telefone e data de nascimento.
Os clientes podem abrir conta corrente, conta poupança ou ambas. Tanto a conta corrente
e a conta poupança possuem um código e um saldo. A conta corrente possui um limite de
R$ 1.000,00 que pode ser usado pelo cliente quando o saldo ficar negativo. Caso o cliente
use o limite, o banco cobra uma taxa de 8% sobre o valor usado. A conta poupança possui
uma taxa de rendimento de 4% que é aplicada sobre o valor depositado. O algoritmo deve
permitir:*/
class Questao02
{
    static void Main()
    {
        Agencia a1 = new Agencia();

        a1.CadastroClientes();
        a1.ImprimirDadosAgencia();
    }
}

struct Cliente
{
    public string Cpf;
    public string NomeCompleto;
    public string Telefone;
    public string DataDeNascimento;

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
}

struct Agencia
{
    public string Codigo;
    public string Endereço;
    public ContaCorrente ContaCorrente;
    public ContaPoupança ContaPoupança;
    public Cliente[] Clientes;
    public int ClientesCadastrados;

    public Agencia(string codigo, string endereco, ContaCorrente contac, ContaPoupança contap, Cliente[] cliente, int clientesCadastrados)
    {
        this.Codigo = codigo;
        this.Endereço = endereco;
        this.ContaCorrente = contac;
        this.ContaPoupança = contap;
        this.Clientes = cliente;
        this.ClientesCadastrados = clientesCadastrados;
    }

    public void CadastroAgencias()
    {
        Console.WriteLine("Informe o o código da agência: ");
        this.Codigo = Console.ReadLine();
        Console.WriteLine("Informe o endereço da agencia: ");
        this.Endereço = Console.ReadLine();

    }

    public void CadastroClientes()
    {
        int numClientes;
        int opcao;
        do
        {
            Console.WriteLine("Deseja incluir quantos clientes? ");
            numClientes = int.Parse(Console.ReadLine());

            if (numClientes > 3)
                Console.WriteLine("Você pode cadastrar no máximo 3 clientes nesta agência!");

        } while ((numClientes < 1) || (numClientes > 3));

        Clientes = new Cliente[numClientes];
        this.ClientesCadastrados = numClientes;

        for (int i = 0; i < this.Clientes.Length; i++)
        {
            Console.WriteLine("Cadastro Do {0}º Cliente",i+1);
            this.Clientes[i].CadastroCliente();
            Console.Write("Deseja criar uma conta corrente para este cliente? 1 - Sim... 2 - Não... : ");
            opcao = int.Parse(Console.ReadLine());
            if (opcao == 1)
                this.ContaCorrente.CadastroContaCorrente(Clientes[i]);
            Console.Write("Deseja criar uma conta poupança para este cliente?1 - Sim... 2 - Não... : ");
            opcao = int.Parse(Console.ReadLine());
            if (opcao == 1)
                this.ContaPoupança.CadastroContaPoupança(Clientes[i]);
            Console.Clear();
        }
    }

    public void ImprimirDadosAgencia()
    {
        Console.WriteLine("Código Da Agência: {0}",this.Codigo);
        Console.WriteLine("Endereço Da Agência: {0}", this.Endereço);
        Console.WriteLine("Total de Clientes: {0}", this.ClientesCadastrados);
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

    public void IncluirAgencias()
    {
        int numAgencias;

        do
        {
            Console.WriteLine("Deseja incluir quantas agências? ");
            numAgencias = int.Parse(Console.ReadLine());

            if (numAgencias > 5)
                Console.WriteLine("Você pode cadastrar no máximo 5 agências!");

        } while (numAgencias < 1 && numAgencias > 5);

        this.NumAagenciasCadastradas = numAgencias;
        this.Agencias = new Agencia[numAgencias];

        for (int i = 0; i < this.Agencias.Length; i++)
        {
            Console.WriteLine("Cadastro Da {0}ª Agência ", i + 1);
            Agencias[i].CadastroAgencias();
            Console.Clear();
        }
    }
    public void ExcluirAgencias()
    {

    }
}


