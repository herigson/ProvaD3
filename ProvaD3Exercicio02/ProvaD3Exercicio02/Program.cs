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
    public bool VerificaContaAtiva()
    {
        bool ativo = false;
        if (this.ContContaC == 00 && this.ContContaP == 00)
            ativo = true;
        return ativo;
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
        Console.Write("Informe o código da conta corrente que será cadastrada: ");
        this.Codigo = Console.ReadLine();
        Console.Write("Informe o saldo inicial da conta corrente: ");
        this.Saldo = double.Parse(Console.ReadLine());
        this.Credito = 1000;

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

    public void CadastroContaPoupanca(Cliente cliente)
    {
        this.Cliente = cliente;
        Console.Write("Informe o código da conta poupança: ");
        this.Codigo = Console.ReadLine();
        Console.Write("Informe o saldo inicial da conta poupança: ");
        this.Saldo = double.Parse(Console.ReadLine());
        this.TaxaRendimento = 1.04;
        this.Saldo *= this.TaxaRendimento;
    }
    public void Deposito()
    {
        double saldo;
        Console.WriteLine("Saldo atual: {0}", this.Saldo);
        Console.WriteLine("Informe a quantia a ser depositada na conta {0}", this.Codigo);
        saldo = double.Parse(Console.ReadLine());
        saldo *= this.TaxaRendimento;
        this.Saldo += saldo;
    }
    public void ImprimirSaldoContaPoupança()
    {
        Console.WriteLine("Código: {0}", this.Codigo);
        Console.WriteLine("Saldo: {0:F2}", this.Saldo);
    }
}

struct Agencia
{
    public string Codigo;
    public string Endereço;
    public Cliente[] Clientes;
    public ContaCorrente[] ContaCorrentes;
    public ContaPoupança[] ContaPoupancas;
    public int ClientesCadastrados;
    public int TagAtivo;
    public int ContasCorrentesCadastradas;
    public int ContasPoupancaCadastradas;

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
        this.ContaPoupancas = new ContaPoupança[10];
        Console.WriteLine("Abertura de conta");
        if (this.ClientesCadastrados < 3)
        {
            this.Clientes[ClientesCadastrados].CadastroCliente();
            this.ClientesCadastrados++;
            Console.WriteLine("Cadastro Do Cliente Efetuado Com Sucesso! Aperte uma tecla para continuar...");
            Console.ReadKey(true);
        }
        else
            Console.WriteLine("É permitido o cadastro de somente 3 clientes por agência");
        do
        {
            Console.WriteLine("Opções para este cliente");
            Console.WriteLine("1 - Abrir conta corrente\n2 - Abrir conta poupança\n3 - Sair");
            opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    if (this.Clientes[this.ClientesCadastrados - 1].ContContaC == 0)
                    {
                        this.ContaCorrentes[this.ContasCorrentesCadastradas].CadastroContaCorrente(this.Clientes[this.ClientesCadastrados - 1]);
                        this.Clientes[this.ClientesCadastrados - 1].ContContaC++;
                        this.ContasCorrentesCadastradas++;
                        Console.WriteLine("Cadastro Efetuado Com Sucesso!");
                        Banco.PauseClean();
                    }
                    else
                        Console.WriteLine("Este cliente ja possuí uma conta conta corrente!");
                    break;
                case 2:
                    if (this.Clientes[this.ClientesCadastrados - 1].ContContaP == 0)
                    {
                        this.ContaPoupancas[this.ContasPoupancaCadastradas].CadastroContaPoupanca(this.Clientes[this.ClientesCadastrados - 1]);
                        this.Clientes[this.ClientesCadastrados - 1].ContContaP++;
                        this.ContasPoupancaCadastradas++;
                        Console.WriteLine("Cadastro Efetuado Com Sucesso!");
                        Banco.PauseClean();
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
    public int RetornaIndiceContaCorrente()
    {
        Console.Write("Informe o código da conta: ");
        string codigoConta = Console.ReadLine();
        int indiceConta = -1;
        for (int i = 0; i < this.ContaCorrentes.Length; i++)
        {
            if (this.ContaCorrentes[i].Codigo == codigoConta)
                indiceConta = i;
        }
        if (indiceConta == -1)
            Console.WriteLine("Conta não cadastrada!");
        Banco.PauseClean();
        return indiceConta;
    }
    public int RetornaIndiceContaPoupanca()
    {
        Console.Write("Informe o código da conta: ");
        string codigoConta = Console.ReadLine();
        int indiceConta = -1;
        for (int i = 0; i < this.ContaPoupancas.Length; i++)
        {
            if (this.ContaPoupancas[i].Codigo == codigoConta)
                indiceConta = i;
        }
        if (indiceConta == -1)
            Console.WriteLine("Conta não cadastrada!");
        Banco.PauseClean();
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
        for (int i = 0; i < this.ContasPoupancaCadastradas; i++)
        {
            saldo += this.ContaPoupancas[i].Saldo;
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
            this.ContaCorrentes[this.ContasCorrentesCadastradas].Cliente.ContContaC--;
            this.ContasCorrentesCadastradas--;
            if (this.ContaCorrentes[this.ContasCorrentesCadastradas].Cliente.VerificaContaAtiva() == true)
                this.ClientesCadastrados--;
        }
        
    }
    public void ExcluirContaPoupança(int indice)
    {
        if (indice < this.ContasCorrentesCadastradas)
        {
            ContaPoupança aux;
            aux = this.ContaPoupancas[indice];
            this.ContaPoupancas[indice] = this.ContaPoupancas[this.ContasPoupancaCadastradas];
            this.ContaPoupancas[this.ContasPoupancaCadastradas] = aux;
            this.ContaPoupancas[this.ContasPoupancaCadastradas].Cliente.ContContaP--;
            this.ContasPoupancaCadastradas--;
            if (this.ContaPoupancas[this.ContasPoupancaCadastradas].Cliente.VerificaContaAtiva() == true)
                this.ClientesCadastrados--;
        }
    }
    public void SaqueContaPoupanca()
    {
        int indiceConta;
        double quantia;
        Console.WriteLine("Saque de conta Poupança");
        indiceConta = RetornaIndiceContaPoupanca();
        if (indiceConta >= 0)
        {
            Console.WriteLine("Saldo Atual: {0}", this.ContaPoupancas[indiceConta].Saldo);
            Console.WriteLine("Informe a quantia a ser sacada: ");
            quantia = double.Parse(Console.ReadLine());
            if (quantia < this.ContaPoupancas[indiceConta].Saldo)
            {
                this.ContaPoupancas[indiceConta].Saldo -= quantia;
                Console.WriteLine("Saque efetuado com sucesso!");
                Console.WriteLine("Saldo após o saque: {0}", this.ContaPoupancas[indiceConta].Saldo);
            }
            else
                Console.WriteLine("Você não pode sacar uma quantia maior do que o seu saldo.");
            Banco.PauseClean();
        }
    }
    public void SaqueContaCorrente()
    {
        int indiceConta, opcao;
        double quantia, valorDesconto;
        Console.WriteLine("Saque de conta Corrente");
        indiceConta = RetornaIndiceContaCorrente();
        if (indiceConta >= 0)
        {
            Console.WriteLine("Saldo Atual: {0}", this.ContaCorrentes[indiceConta].Saldo);
            Console.WriteLine("Informe a quantia a ser sacada: ");
            quantia = double.Parse(Console.ReadLine());
            valorDesconto = (-this.ContaCorrentes[indiceConta].Saldo + quantia) * 1.08;
            if (quantia < this.ContaCorrentes[indiceConta].Saldo)
            {
                this.ContaCorrentes[indiceConta].Saldo -= quantia;
                Console.WriteLine("Saque efetuado com sucesso!");
                Console.WriteLine("Saldo após o saque: ", this.ContaCorrentes[indiceConta].Saldo);
            }
            else if (quantia < (this.ContaCorrentes[indiceConta].Saldo + this.ContaCorrentes[indiceConta].Credito))
            {
                Console.WriteLine("Você não possui saldo suficiente mas pode usar seu crédito");
                Console.WriteLine("Será descontado {0:F2} do seu crédito, deseja continuar?", valorDesconto);
                Console.Write("1 - Sim | 2 - Não...: ");
                opcao = int.Parse(Console.ReadLine());
                if (opcao == 1)
                {
                    this.ContaCorrentes[indiceConta].Credito -= ((-this.ContaCorrentes[indiceConta].Saldo + quantia) * 1.08);
                    this.ContaCorrentes[indiceConta].Saldo = 0;
                    Console.WriteLine("Saque efetuado com sucesso!");
                }
                else
                    Console.WriteLine("Operação Cancelada!");
            }
            else
                Console.WriteLine("Você não possui saldo nem limite disponível para sacar esta quantia");
            Banco.PauseClean();
        }
    }
    public void TransferenciaCorrenteParaPoupanca()
    {
        int indiceConta, opcao;
        double quantia, valorDesconto;
        Console.WriteLine("Transferência de Conta Corrente para Conta Poupança");
        Console.WriteLine("Inserindo dados da conta corrente... ");
        indiceConta = RetornaIndiceContaCorrente();
        if (indiceConta >= 0)
        {
            Console.WriteLine("Saldo Atual: ", this.ContaCorrentes[indiceConta].Saldo);
            Console.WriteLine("Informe a quantia a ser transferência: ");
            quantia = double.Parse(Console.ReadLine());
            valorDesconto = (-this.ContaCorrentes[indiceConta].Saldo + quantia) * 1.08;
            if (quantia < this.ContaCorrentes[indiceConta].Saldo)
            {
                Console.WriteLine("Inserindo os dados da conta poupança... ");
                indiceConta = RetornaIndiceContaPoupanca();
                if (indiceConta >= 0)
                {
                    this.ContaPoupancas[indiceConta].Saldo += quantia;
                    Console.WriteLine("Transferência realizada com sucesso!");
                }
            }
            else if (quantia < (this.ContaCorrentes[indiceConta].Saldo + this.ContaCorrentes[indiceConta].Credito))
            {
                Console.WriteLine("Você não possui saldo suficiente mas pode usar seu crédito");
                Console.WriteLine("Será descontado {0:F2} do seu crédito, deseja continuar?", valorDesconto);
                Console.Write("1 - Sim | 2 - Não...: ");
                opcao = int.Parse(Console.ReadLine());
                if (opcao == 1)
                {
                    this.ContaCorrentes[indiceConta].Credito -= ((-this.ContaCorrentes[indiceConta].Saldo + quantia) * 1.08);
                    this.ContaCorrentes[indiceConta].Saldo = 0;
                    Console.WriteLine("Saque efetuado com sucesso!");
                }
                else
                    Console.WriteLine("Operação Cancelada");
            }
            Banco.PauseClean();
        }
    }
    public void TransferenciaPoupancaParaCorrente()
    {
        int indiceContaC, indiceContaP;
        double quantia;
        Console.WriteLine("Transferência de Conta Poupança para Conta Corrente");
        Console.WriteLine("Inserindo dados da conta poupança... ");
        indiceContaC = RetornaIndiceContaPoupanca();
        if (indiceContaC >= 0)
        {
            Console.WriteLine("Saldo Atual: ", this.ContaPoupancas[indiceContaC].Saldo);
            Console.WriteLine("Informe a quantia a ser transferia: ");
            quantia = double.Parse(Console.ReadLine());
            if (quantia <= this.ContaPoupancas[indiceContaC].Saldo)
            {
                Console.WriteLine("Inserindo os dados da conta corrente... ");
                indiceContaP = RetornaIndiceContaCorrente();
                if (indiceContaP >= 0)
                {
                    if(this.ContaCorrentes[indiceContaP].Credito < 1000)
                    {
                        double dpcredito = 1000 - this.ContaCorrentes[indiceContaP].Credito;
                        if(quantia > dpcredito)
                        {
                            this.ContaCorrentes[indiceContaP].Credito -= dpcredito;
                            this.ContaPoupancas[indiceContaC].Saldo -= quantia;
                            quantia -= dpcredito;
                            this.ContaCorrentes[indiceContaP].Saldo += quantia;
                            Console.WriteLine("Valor Transferido para o crédito: {0:F2}", dpcredito);
                            Console.WriteLine("Valor Transferido para a conta corrente: {0:F2}", quantia);
                        }
                        else
                        {
                            Console.WriteLine("Valor a ser transferido é menor ou igual ao valor do crédito utilizado pelo cliente");
                            this.ContaPoupancas[indiceContaC].Saldo -= quantia;
                            this.ContaCorrentes[indiceContaP].Credito += quantia;
                            Console.WriteLine("Valor transferido para o crédito {0:f2}",quantia);

                        }
                        
                    }
                    this.ContaPoupancas[indiceContaC].Saldo -= quantia;
                    this.ContaCorrentes[indiceContaP].Saldo += quantia;
                    Console.WriteLine("Transferência realizada com sucesso!");
                }
            }
            else
            {
                Console.WriteLine("Você não tem saldo o suficiente para transferir este valor! ");
            }
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
        double saldoConta;

        Console.WriteLine("Bem vindo ao programa de administração do seu banco!");
        Console.Write("Informe o nome do banco: ");
        this.Nome = Console.ReadLine();
        Console.Write("Informe o código do banco: ");
        this.Codigo = Console.ReadLine();
        PauseClean();

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
            Console.WriteLine("9  - Impressão Dos Dados Das Contas De Cada Agência ");
            Console.WriteLine("10 - Impressão Do Saldo Total Depositado Em Cada Agência ");
            Console.WriteLine("11 - Impressão Do Saldo Total Depositado Em Conta Corrente em Cada Agência");
            Console.WriteLine("12 - Impressão Do Saldo Total Depositado Em Conta Poupança em Cada Agência");
            Console.WriteLine("13 - Realizar Depósito em Contas Correntes");
            Console.WriteLine("14 - Realizar Depósito em Contas Poupança");
            Console.WriteLine("15 - Realizar Saque Poupança");
            Console.WriteLine("16 - Realizar Saque Corrente");
            Console.WriteLine("17 - Transferir dinheiro de conta corrente para conta poupança");
            Console.WriteLine("18 - Transferir dinheiro de conta poupanca para conta corrente");
            Console.WriteLine("19 - Verificar o saldo de conta corrente ");
            Console.WriteLine("20 - Verificar o saldo de conta poupança ");
            Console.WriteLine("21 - Verificar o limite da conta corrente usado pelo cliente F");
            Console.WriteLine("0  - Encerrar o programa de administração");
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
                    indiceAgencia = RetornaIndiceAgencia();
                    ExcluirAgencias(indiceAgencia);
                    break;
                case 3:
                    Console.Clear();
                    //ImprimirDadosTodasAgencias();
                    indiceAgencia = RetornaIndiceAgencia();
                    this.Agencias[indiceAgencia].ImprimirDadosAgencia();
                    PauseClean();
                    break;
                case 4:
                    Console.Clear();
                    double saldoTotalBanco = SaldoTotalContaCorrenteBanco() + SaldoTotalContaPoupançaBanco();
                    Console.WriteLine("Saldo Total Depositado No Banco: {0:F2}", saldoTotalBanco);
                    PauseClean();
                    break;
                case 5:
                    Console.Clear();
                    double saltoTotalCcBanco = SaldoTotalContaCorrenteBanco();
                    Console.WriteLine("Saldo Total Depositado No Banco: {0:F2}", saltoTotalCcBanco);
                    PauseClean();
                    break;
                case 6:
                    Console.Clear();
                    double saltoTotalCpBanco = SaldoTotalContaPoupançaBanco();
                    Console.WriteLine("Saldo Total Depositado No Banco: {0:F2}", saltoTotalCpBanco);
                    PauseClean();
                    break;
                case 7:
                    Console.Clear();
                    ImprimirDadosTodasAgencias();
                    indiceAgencia = RetornaIndiceAgencia();
                    if (indiceAgencia >= 0)
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
                            indiceAgencia = RetornaIndiceAgencia();
                            if (indiceAgencia >= 0)
                            {
                                indiceConta = this.Agencias[indiceAgencia].RetornaIndiceContaCorrente();
                                if (indiceConta >= 0)
                                    this.Agencias[indiceAgencia].ExcluirContaCorrente(indiceConta);
                            }
                            break;
                        case 2:
                            Console.Clear();
                            ImprimirDadosTodasAgencias();
                            indiceAgencia = RetornaIndiceAgencia();
                            if (indiceAgencia >= 0)
                            {
                                indiceConta = this.Agencias[indiceAgencia].RetornaIndiceContaPoupanca();
                                if (indiceConta >= 0)
                                    this.Agencias[indiceAgencia].ExcluirContaPoupança(indiceConta);
                            }
                            break;
                    }
                    break;
                case 9:
                    Console.Clear();
                    ImprimirDadosTodasAgencias();
                    indiceAgencia = RetornaIndiceAgencia();
                    if (indiceAgencia >= 0)
                        this.Agencias[indiceAgencia].ImprimirTodasAsContasAgencia();
                    PauseClean();
                    break;
                case 10:
                    Console.Clear();
                    ImprimirDadosTodasAgencias();
                    indiceAgencia = RetornaIndiceAgencia();
                    if (indiceAgencia >= 0)
                    {
                        saldoConta = this.Agencias[indiceAgencia].SaldoTotalContaCorrenteAgencia() + this.Agencias[indiceAgencia].SaldoTotalContaPoupançaAgencia();
                        Console.WriteLine("Saldo total depositado na agencia {0} : {1:F2}", this.Agencias[indiceAgencia].Codigo, saldoConta);
                    }
                    PauseClean();
                    break;
                case 11:
                    Console.Clear();
                    ImprimirDadosTodasAgencias();
                    indiceAgencia = RetornaIndiceAgencia();
                    if (indiceAgencia >= 0)
                    {
                        saldoConta = this.Agencias[indiceAgencia].SaldoTotalContaCorrenteAgencia();
                        Console.WriteLine("Saldo total em conta corrente na agencia {0} : {1:F2}", this.Agencias[indiceAgencia].Codigo, saldoConta);
                    }
                    PauseClean();
                    break;
                case 12:
                    Console.Clear();
                    ImprimirDadosTodasAgencias();
                    indiceAgencia = RetornaIndiceAgencia();
                    if (indiceAgencia >= 0)
                    {
                        saldoConta = this.Agencias[indiceAgencia].SaldoTotalContaPoupançaAgencia();
                        Console.WriteLine("Saldo Total em Conta Poupança na agencia {0} : {1:F2}", this.Agencias[indiceAgencia].Codigo, saldoConta);
                    }
                    PauseClean();
                    break;
                case 13:
                    Console.Clear();
                    ImprimirDadosTodasAgencias();
                    indiceAgencia = RetornaIndiceAgencia();
                    if (indiceAgencia >= 0)
                    {
                        indiceConta = this.Agencias[indiceAgencia].RetornaIndiceContaCorrente();
                        if (indiceConta >= 0)
                            this.Agencias[indiceAgencia].ContaCorrentes[indiceConta].Deposito();
                    }
                    PauseClean();
                    break;
                case 14:
                    Console.Clear();
                    ImprimirDadosTodasAgencias();
                    indiceAgencia = RetornaIndiceAgencia();
                    if (indiceAgencia >= 0)
                    {
                        indiceConta = this.Agencias[indiceAgencia].RetornaIndiceContaPoupanca();
                        if (indiceConta >= 0)
                            this.Agencias[indiceAgencia].ContaPoupancas[indiceConta].Deposito();
                    }
                    PauseClean();
                    break;
                case 15:
                    Console.Clear();
                    ImprimirDadosTodasAgencias();
                    indiceAgencia = RetornaIndiceAgencia();
                    if (indiceAgencia >= 0)
                        this.Agencias[indiceAgencia].SaqueContaPoupanca();
                    PauseClean();
                    break;
                case 16:
                    Console.Clear();
                    ImprimirDadosTodasAgencias();
                    indiceAgencia = RetornaIndiceAgencia();
                    if (indiceAgencia >= 0)
                        this.Agencias[indiceAgencia].SaqueContaCorrente();
                    PauseClean();
                    break;
                case 17:
                    Console.Clear();
                    indiceAgencia = RetornaIndiceAgencia();
                    if (indiceAgencia >= 0)
                        this.Agencias[indiceAgencia].TransferenciaCorrenteParaPoupanca();
                    PauseClean();
                    break;
                case 18:
                    Console.Clear();
                    indiceAgencia = RetornaIndiceAgencia();
                    if (indiceAgencia >= 0)
                        this.Agencias[indiceAgencia].TransferenciaPoupancaParaCorrente();
                    PauseClean();
                    break;
                case 19:
                    indiceAgencia = RetornaIndiceAgencia();
                    if (indiceAgencia >= 0)
                    {
                        indiceConta = this.Agencias[indiceAgencia].RetornaIndiceContaCorrente();
                        if (indiceConta >= 0)
                            Console.WriteLine("Saldo da conta: {0:F2}", this.Agencias[indiceAgencia].ContaCorrentes[indiceConta].Saldo);
                    }
                    PauseClean();
                    break;
                case 20:
                    Console.Clear();
                    indiceAgencia = RetornaIndiceAgencia();
                    if (indiceAgencia >= 0)
                    {
                        indiceConta = this.Agencias[indiceAgencia].RetornaIndiceContaPoupanca();
                        if (indiceConta >= 0)
                            Console.WriteLine("Saldo da conta: {0:F2}", this.Agencias[indiceAgencia].ContaPoupancas[indiceConta].Saldo);
                    }
                    PauseClean();
                    break;
                case 21:
                    Console.Clear();
                    indiceAgencia = RetornaIndiceAgencia();
                    if (indiceAgencia >= 0)
                    {
                        indiceConta = this.Agencias[indiceAgencia].RetornaIndiceContaCorrente();
                        if (indiceConta >= 0)
                            Console.WriteLine("Crédito da conta: {0:F2}", this.Agencias[indiceAgencia].ContaCorrentes[indiceConta].Credito);
                    }
                    PauseClean();
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
            if (this.Agencias[indice].ClientesCadastrados == 0)
            {
                Agencia aux;
                aux = this.Agencias[indice];
                this.Agencias[indice] = this.Agencias[NumAagenciasCadastradas];
                this.Agencias[this.NumAagenciasCadastradas] = aux;
                this.Agencias[this.NumAagenciasCadastradas].TagAtivo = 0;
                this.NumAagenciasCadastradas--;
                Console.WriteLine("Agência excluida com suceso!");
                PauseClean();
            }
            else
            {
                Console.WriteLine("Esta agencia não pode ser excluída pois tem clientes cadastrados.");
                PauseClean();
            }
        }
        else
        {
            Console.WriteLine("Agencia não existente.");
            PauseClean();
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
    public double SaldoTotalContaCorrenteBanco()
    {
        double saldo = 0;
        for (int i = 0; i < this.Agencias.Length; i++)
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
    public int RetornaIndiceAgencia()
    {
        int indiceAgencia = -1;

        Console.Write("\n\nInforme o código da agência: ");
        string codigoAgencia = Console.ReadLine();

        for (int i = 0; i < this.Agencias.Length; i++)
        {
            if (this.Agencias[i].Codigo == codigoAgencia)
                indiceAgencia = i;
        }
        if (indiceAgencia == -1)
        {
            Console.WriteLine("Agencia não cadastrada!");
            Banco.PauseClean();
        }
        return indiceAgencia;
    }
    public static void PauseClean()
    {
        Console.WriteLine("Aperte uma tecla para continuar...");
        Console.ReadKey(true);
        Console.Clear();
    }
}
