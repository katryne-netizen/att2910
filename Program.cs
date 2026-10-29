using System;

class Material
{
    public int Codigo { get; set; }
    public string Titulo { get; set; }
    public int Ano { get; set; }

    private bool disponivel = true;
    private string usuario = "";
    private DateTime dataDevolucao;

    public Material(int codigo, string titulo, int ano)
    {
        Codigo = codigo;
        Titulo = titulo;
        Ano = ano;
    }

    public virtual int PrazoDevolucao()
    {
        return 7;
    }

    public void Emprestar(string nomeUsuario)
    {
        if (!disponivel)
        {
            Console.WriteLine("Material indisponível!");
            return;
        }

        disponivel = false;
        usuario = nomeUsuario;
        dataDevolucao = DateTime.Today.AddDays(PrazoDevolucao());

        Console.WriteLine("Empréstimo realizado!");
        Console.WriteLine("Usuário: " + usuario);
        Console.WriteLine("Devolução: " + dataDevolucao.ToShortDateString());
    }

    public void Devolver()
    {
        if (disponivel)
        {
            Console.WriteLine("Este material não está emprestado!");
            return;
        }

        if (DateTime.Today > dataDevolucao)
            Console.WriteLine("Devolução atrasada!");
        else
            Console.WriteLine("Devolução no prazo!");

        disponivel = true;
        usuario = "";
    }

    public void Consultar()
    {
        Console.WriteLine(Titulo + " - " +
            (disponivel ? "Disponível" : "Emprestado"));
    }
}

class Livro : Material
{
    public Livro(int codigo, string titulo, int ano)
        : base(codigo, titulo, ano) { }

    public override int PrazoDevolucao()
    {
        return 14;
    }
}

class Revista : Material
{
    public Revista(int codigo, string titulo, int ano)
        : base(codigo, titulo, ano) { }

    public override int PrazoDevolucao()
    {
        return 7;
    }
}

class DVD : Material
{
    public DVD(int codigo, string titulo, int ano)
        : base(codigo, titulo, ano) { }

    public override int PrazoDevolucao()
    {
        return 3;
    }
}

class Program
{
    static void Main()
    {
        Livro livro = new Livro(1, "Dom Casmurro", 1899);
        Revista revista = new Revista(2, "Ciência Hoje", 2025);
        DVD dvd = new DVD(3, "Filme", 2024);

        livro.Consultar();
        livro.Emprestar("Maria");
        livro.Emprestar("João");
        livro.Devolver();

        revista.Consultar();
        dvd.Consultar();
    }
}
