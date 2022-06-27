using System;
using System.IO;


namespace DirectoryExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            
                Console.WriteLine("Digite o nome do arquivo que gostaria de ler:");
                var caminhoArquivo = Console.ReadLine();

                ArquivoFuncionario imprimir = new ArquivoFuncionario(caminhoArquivo);
            try
            {
                imprimir.ListaFuncionarios();
                imprimir.NameDictionaryList();
                imprimir.DateDictionaryList();
                imprimir.ResultDictionaryList();
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine();
                Console.WriteLine("Diretorio nao localizado!");
            }

        }
    }
}
