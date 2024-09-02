using API___Tarefa1.Dtos;
using API___Tarefa1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ClienteAPI___01.Salvar
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController 
    {
        private const string FilePath = @"C:\Users\Desktop\TarefaTxt\Fornecedor.txt";

  
        public static bool ValidaCNPJ(string cnpj)
        {
            cnpj = cnpj.Replace(".", "").Replace("/", "").Replace("-", ""); // tira os caracteres especiais

            if (cnpj.Length != 14 || cnpj.All(c => c == cnpj[0]))
            {
                return false;
            }

             int[] multiplicadores1 =  { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
             int[]  multiplicadores2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            var calcularDigito = (string cnpjBase, int[] multiplicadores) =>
            {
                int soma = 0;
                for (var i = 0; i < multiplicadores.Length; i++)
                {
                    soma += (cnpjBase[i] - '0') * multiplicadores[i];
                }

                int resto = soma % 11;
                int digito;
                if (resto < 2)
                {
                    digito = 0;
                }
                else
                {
                    digito = 11 - resto;
                }
                return digito;
            };

            int digito1 = calcularDigito(cnpj.Substring(0, 12), multiplicadores1);
            int digito2 = calcularDigito(cnpj.Substring(0, 12) + digito1, multiplicadores2);

            return cnpj.EndsWith(digito1.ToString() + digito2.ToString());
        }
    }
}
