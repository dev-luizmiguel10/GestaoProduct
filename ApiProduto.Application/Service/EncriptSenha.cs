using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ApiProduto.Application.Service
{
    public class EncriptSenha
    {
        public string Password(string senha)
        {
            var pass= Encoding.UTF8.GetBytes(senha);
            var hash_senha= SHA3_512.HashData(pass);
             StringBuilder sb= new StringBuilder();
            foreach (var item in hash_senha)
            {
                item.ToString("x2");
                sb.Append(item);
            }
            return sb.ToString();
        }
    }
}
