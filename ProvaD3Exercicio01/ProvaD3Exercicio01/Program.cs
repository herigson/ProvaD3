using System;
using System.Linq;
class Program
{

    static void Main()
    {
        Console.Write("Informe a quantidade de alunos: ");
        int qtdAlunos = int.Parse(Console.ReadLine());
        Console.Clear();
        Aluno[] a = new Aluno[qtdAlunos]; //Aqui definimos a quantidade de alunos que o cadastro irá possuir xD.
        Cadastro a1 = new Cadastro(a);
        a1.Cadastrar();
        a1.ImprimirCadastro();
        a1.ImprimirDisciplinasAprovadas();
        a1.ImprimirDisciplinasReprovadas();


    }

}
//Cursos disponíveis para o cadastro
enum n_cursos { Análise_E_Desenvolvimento_De_Sistemas, Biologia, Redes_De_Computadores }
//Disciplinas disponíveis para o cadastro
enum n_DisciplinasCurso { Fundamentos_Programação, Praticas_Programação, Redes_Computadores, Modelagem_Em_Banco_De_Dados, Morfologia_E_Taxonomia, Neurofisiologia, Fisica };


struct Cadastro
{
    public Aluno[] Alunos;

    public Cadastro(Aluno[] alunos)
    {
        this.Alunos = alunos;
    }
    //Método que realiza o cadastro de alunos
    public void Cadastrar()
    {
        for (int i = 0; i < this.Alunos.Length; i++)
        {
            Console.WriteLine("Cadastro de Alunos");
            this.Alunos[i].Ler();
            Console.Clear();
        }
    }
    //Método que realiza a impressão de um cadastro de alunos.
    public void ImprimirCadastro()
    {
        Console.WriteLine("Dados do cadastro");
        for (int i = 0; i < this.Alunos.Length; i++)
        {
            this.Alunos[i].ImprimirDadosAluno();
            Console.WriteLine();
        }
        Console.WriteLine("Pressione qualquer tecla para exibir os alunos aprovados e reprovados...");
        Console.ReadKey(true);
        Console.Clear();
    }
    //Método que realiza a impressão de disciplinas aprovadas dos alunos de um cadastro.
    public void ImprimirDisciplinasAprovadas()
    {
        Console.WriteLine("Disciplinas em que cada aluno foi aprovado");
        for (int i = 0; i < this.Alunos.Length; i++)
        {
            Console.WriteLine($"Aluno: {this.Alunos[i].Nome}");
            for (int j = 0; j < this.Alunos[i].Notas.Length; j++)
                if (this.Alunos[i].VerificaAprovacao(j) == 1)
                    this.Alunos[i].ImprimirDisciplinaENota(j);
        }
    }
    //Método que realiza a impressão de disciplinas reprovadas dos alunos de um cadastro.
    public void ImprimirDisciplinasReprovadas()
    {
        Console.WriteLine("\n\nDisciplinas em que cada aluno foi reprovado");
        for (int i = 0; i < this.Alunos.Length; i++)
        {
            Console.WriteLine($"Aluno: {this.Alunos[i].Nome}");
            for (int j = 0; j < this.Alunos[i].Notas.Length; j++)
                if (this.Alunos[i].VerificaAprovacao(j) == 0)
                    this.Alunos[i].ImprimirDisciplinaENota(j);
        }
    }
}
struct Aluno
{
    public string Matricula;
    public string Nome;
    public int QtdDisciplinaCadastradas;
    public double[] Notas;
    public n_cursos Curso;
    public n_DisciplinasCurso[] DisciplinasCurso;

    //Método que armazena todos os dados de um aluno.
    public void Ler()
    {
        int opcaoCurso, opcaoDisciplina, numMaxDiscPorCurso;
        this.QtdDisciplinaCadastradas = 0;

        Console.Write("Informe a matrícula do aluno: ");
        this.Matricula = Console.ReadLine();
        Console.Write("Informe o nome do aluno: ");
        this.Nome = Console.ReadLine();
        Console.WriteLine("Informe o curso do aluno: ");
        Console.WriteLine("[1] - Análise E Desenvolvimento De Sistemas");
        Console.WriteLine("[2] - Biologia");
        Console.Write("[3] - Rede De Computadores: ");
        opcaoCurso = int.Parse(Console.ReadLine());
        Console.Clear();
        this.Curso = (n_cursos)(opcaoCurso - 1);
        numMaxDiscPorCurso = Enum.GetValues(typeof(n_DisciplinasCurso)).Length;
        this.DisciplinasCurso = new n_DisciplinasCurso[numMaxDiscPorCurso];

        //Como eu não quis limitar o número de disciplinas por aluno e apenas indiquei o máximo, eu preenchi o vetor com todas as matérias possíveis e deixei todaas as notas com -1.
        this.Notas = new double[numMaxDiscPorCurso];
        Array.Fill(this.Notas, -1);
        this.DisciplinasCurso = Enum.GetValues(typeof(n_DisciplinasCurso)).Cast<n_DisciplinasCurso>().ToArray();

        for (int i = 0; i < numMaxDiscPorCurso; i++)
        {
            Console.WriteLine("Informe a disciplina: ");
            Console.WriteLine("[1] Fundamentos De Programação");
            Console.WriteLine("[2] Praticas De Programação");
            Console.WriteLine("[3] Redes De Computadores");
            Console.WriteLine("[4] Modelagem Em Banco De Dados");
            Console.WriteLine("[5] Morfologia E Taxonomia");
            Console.WriteLine("[6] Neurofisiologia");
            Console.Write("[7] Fisica: ");
            opcaoDisciplina = int.Parse(Console.ReadLine());
            this.DisciplinasCurso[i] = (n_DisciplinasCurso)opcaoDisciplina - 1;
            Console.Write($"Informe a nota da disciplina {this.DisciplinasCurso[opcaoDisciplina - 1]}: ");
            this.Notas[i] = double.Parse(Console.ReadLine());
            this.QtdDisciplinaCadastradas++;

            Console.WriteLine("Deseja cadastrar mais uma disciplina?");
            Console.WriteLine("Informe 1 - Sim || 2 - Não");
            opcaoDisciplina = int.Parse(Console.ReadLine());
            Console.Clear();

            if (opcaoDisciplina != 1)
                break;
        }

    }

    //Método que imprime todos os dados de um aluno.
    public void ImprimirDadosAluno()
    {
        Console.WriteLine($"Nome: {this.Nome}");
        Console.WriteLine($"Matricula: {this.Matricula}");
        Console.WriteLine($"Curso: {this.Curso}");
        Console.WriteLine("Disciplinas: ");
        for (int i = 0; i < this.QtdDisciplinaCadastradas; i++)
            ImprimirDisciplinaENota(i);

    }
    //Metodo que imprime uma disciplina e sua nota, aqui eu preferi fazer ele separado dos dados do aluno que posso reaproveitalo na impressão de disciplinas aprovadas e reprovadas.
    public void ImprimirDisciplinaENota(int num)
    {
        Console.Write(this.DisciplinasCurso[num]);
        Console.WriteLine($", Nota: {this.Notas[num]}");
    }

    //Método que verifica aprovação, eu tive que usar o retorno de inteiro pq precisava de 3 estados  -1 Não cursou ,1 Aprovado, 0 Reprovado
    public int VerificaAprovacao(int indiceNota)
    {
        int aprovacao = -1;
        if (this.Notas[indiceNota] >= 0 && this.Notas[indiceNota] < 70)
            aprovacao = 0;
        else if (this.Notas[indiceNota] > 70)
            aprovacao = 1;

        return aprovacao;
    }
}