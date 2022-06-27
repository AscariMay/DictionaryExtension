using System;
using System.Collections.Generic;
using System.IO;

namespace DirectoryExtension
{
    class ArquivoFuncionario : IArquivoFuncionario
    {
        public string CaminhoArquivo { get; set; }
        public List<Funcionario> Funcionarios = new List<Funcionario>();
        public Dictionary<int, string> NameDictionary = new Dictionary<int, string>();
        public Dictionary<int, string> DateDictionary = new Dictionary<int, string>();
        public Dictionary<int, string> ResultDictionary = new Dictionary<int, string>();

        public ArquivoFuncionario()
        {
        }

        public ArquivoFuncionario(string caminhoArquivo)
        {
            CaminhoArquivo = caminhoArquivo;
            Funcionarios = new List<Funcionario>();
            NameDictionary = new Dictionary<int, string>();
            DateDictionary = new Dictionary<int, string>();
            ResultDictionary = new Dictionary<int, string>();
        }

        public List<Funcionario> ListaFuncionarios()
        {
            try
            {
                using (StreamReader novoFuncionario = File.OpenText(CaminhoArquivo))
                {
                    novoFuncionario.ReadLine();
                    while (!novoFuncionario.EndOfStream)
                    {
                        string[] novoRegistroFuncionario = novoFuncionario.ReadLine().Split(";");
                        Funcionario funcionario = NovoRegistroFuncionario(novoRegistroFuncionario);
                        Funcionarios.Add(funcionario);

                        Console.Clear();
                        Impressao(funcionario);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occured" + e.Message);
            }
            return Funcionarios;
        }

        private Funcionario NovoRegistroFuncionario(string[] novoRegistroFuncionario)
        {
            int id = int.Parse(novoRegistroFuncionario[0]);
            string nomeCompleto = novoRegistroFuncionario[1];
            DateTime dataNascimento = DateTime.Parse(novoRegistroFuncionario[2]);
            decimal salario = decimal.Parse(novoRegistroFuncionario[3]);

            return new Funcionario(id, nomeCompleto, dataNascimento, salario);
        }
        public void Impressao(Funcionario funcionario)
        {
                Console.WriteLine("Id".PadRight(10) + "NomeCompleto".PadRight(20) + "Data de Nascimento".PadRight(35) + "Salario");
        
            foreach (Funcionario funcionarios in Funcionarios)
            {
                Console.WriteLine(funcionarios);
            }
        }

        public Dictionary<int, string> NameDictionaryList()
        {
            using (StreamReader novoFuncionario = File.OpenText(CaminhoArquivo))
            {
                try
                {
                    novoFuncionario.ReadLine();
                    while (!novoFuncionario.EndOfStream)
                    {
                        var novoRegistroFuncionario = novoFuncionario.ReadLine().Split(";");
                        NameDictionary[int.Parse(novoRegistroFuncionario[0])] = novoRegistroFuncionario[1];
                    }
                    Console.WriteLine($"\n\nId\t\tNome");
                    foreach (var item in NameDictionary)
                    {
                        Console.WriteLine(item.Key.ToString() + "\t\t" + item.Value);
                    }
                    Console.WriteLine();
                }
                catch (IOException e)
                {
                    Console.WriteLine("An error occured" + e.Message);
                }
                return NameDictionary;
            }
        }

        public Dictionary<int, string> DateDictionaryList()
        {
            using (StreamReader novoFuncionario = File.OpenText(CaminhoArquivo))
            {
                try
                {
                    novoFuncionario.ReadLine();
                    while (!novoFuncionario.EndOfStream)
                    {
                        var novoRegistroFuncionario = novoFuncionario.ReadLine().Split(";");
                        DateDictionary[int.Parse(novoRegistroFuncionario[0])] = ExtesionMethod.Extesion(DateTime.Parse(novoRegistroFuncionario[2])); ;
                    }

                    Console.WriteLine($"\n\nId    Data de Nascimento por Extenso");
                    foreach (var item in DateDictionary)
                    {
                        Console.WriteLine(item.Key.ToString().PadRight(10) + item.Value);
                    }
                    Console.WriteLine();
                }

                catch (IOException e)
                {
                    Console.WriteLine("An error occured" + e.Message);
                }
                return DateDictionary;
            }
        }
        public Dictionary<int, string> ResultDictionaryList()
        {
            using (StreamReader novoFuncionario = File.OpenText(CaminhoArquivo))
            {
                try
                {
                    novoFuncionario.ReadLine();
                    while (!novoFuncionario.EndOfStream)
                    {
                        var novoRegistroFuncionario = novoFuncionario.ReadLine().Split(";");
                        ResultDictionary[int.Parse(novoRegistroFuncionario[0])] = novoRegistroFuncionario[1]; ExtesionMethod.Extesion(DateTime.Parse(novoRegistroFuncionario[2])); ;
                    }
                    Console.WriteLine("\nId \t Nome \t\tData de Nascimento por Extenso");

                    foreach (KeyValuePair<int, string> item in ResultDictionary)
                    {
                        Console.WriteLine($"{item.Key,-8} {item.Value,-20} {DateDictionary[item.Key]}");
                    }
                    Console.WriteLine();
                }
                catch (IOException e)
                {
                    Console.WriteLine("An error occured" + e.Message);
                }
                return ResultDictionary;
            }
        }
    }
}