using System;
using System.Collections.Generic;
using System.Text;

namespace DirectoryExtension
{
    public static class ExtesionMethod
    {
        public static string Extesion(this DateTime dataNascimento)
        {
            return $"Nasceu em {dataNascimento:MMMM}";
        }
    }
}
