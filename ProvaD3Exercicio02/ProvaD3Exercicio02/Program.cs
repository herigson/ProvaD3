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
    public int TagAtivo;

    public Agencia(string codigo, string endereco, ContaCorrente contac, ContaPoupança contap, Cliente[] cliente, int clientesCadastrados, int tagAtivo)
    {
        this.Codigo = codigo;
        this.Endereço = endereco;
        this.ContaCorrente = contac;
        this.ContaPoupança = contap;
        this.Clientes = cliente;
        this.ClientesCadastrados = clientesCadastrados;
        this.TagAtivo = tagAtivo;
    }

    public void CadastroAgencias()
    {
        Console.Write("Informe o o código da agência: ");
        this.Codigo = Console.ReadLine();
        Console.Write("Informe o endereço da agencia: ");
        this.Endereço = Console.ReadLine();
        this.TagAtivo = 1;

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
            Console.WriteLine("Cadastro Do {0}º Cliente", i + 1);
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
        Console.WriteLine("Código Da Agência: {0}", this.Codigo);
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

    public void Program()
    {
        int opcao, indiceAgencia;
        string codigoAgencia;

        Console.WriteLine("Bem vindo ao programa de administração do seu banco!");
        Console.Write("Informe o nome do banco: ");
        this.Nome = Console.ReadLine();
        Console.Write("Informe o código do banco: ");
        this.Codigo = Console.ReadLine();
        Console.Clear();

        do
        {
            Console.WriteLine("Administração Banco {0}", this.Nome);
            Console.WriteLine("0 - Encerrar o programa de administração");
            Console.WriteLine("1 - Incluir Agências");
            Console.WriteLine("2 - Excluir Agências");
            Console.WriteLine("3 - Cadastrar Clientes");
            Console.Write("Informe a opção desejada :");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 0:
                case 1:
                    Console.Clear();
                    IncluirAgencias();
                    break;
                case 2:
                    Console.Clear();
                    ImprimirDadosTodasAgencias();
                    Console.WriteLine("Informe o código da agência que deseja excluir?");
                    codigoAgencia = Console.ReadLine();
                    indiceAgencia = RetornaIndiceAgencia(this.Agencias, codigoAgencia);
                    ExcluirAgencias(indiceAgencia);
                    break;
                case 3:
                    Console.Clear();
                    
                    
                    ImprimirDadosTodasAgencias();
                    Console.Write("\n\nInforme o código da agência no qual você irá cadastrar um cliente: ");
                    codigoAgencia = Console.ReadLine();
                    indiceAgencia = RetornaIndiceAgencia(this.Agencias, codigoAgencia);
                    this.Agencias[indiceAgencia].CadastroClientes();
                    break;
            }
        } while (opcao != 0);


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


}


