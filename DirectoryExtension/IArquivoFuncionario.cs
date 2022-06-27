using System;
using System.Collections.Generic;
using System.IO;

namespace DirectoryExtension
{
    interface IArquivoFuncionario
    {
        List<Funcionario> ListaFuncionarios();
        Dictionary<int, string> NameDictionaryList();
        Dictionary<int, string> DateDictionaryList();
        Dictionary<int, string> ResultDictionaryList();
    }
}