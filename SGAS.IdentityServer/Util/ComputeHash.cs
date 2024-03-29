using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SGAS.IdentityServer.Interfaces;
using SGAS.IdentityServer.Interfaces.Util;
using System;
using System.Security.Cryptography;
using System.Text;

namespace SGAS.IdentityServer.Util
{
    public class ComputeHash : IComputeHash
    {
        private readonly IConfigRepository _configRepository;

        public ComputeHash(IConfigRepository configRepository)
        {
            _configRepository = configRepository;
        }

        public string CreatePasswordHash(string password)
        {
            UnicodeEncoding unicode = new UnicodeEncoding();
            var campoValor = _configRepository.ObterPorParametros(x => x.Projeto == "IdentityServer" 
                                                                    && x.Chave == "KeyPassword").Valor;
            string retorno = string.Empty;

            //byte[] salt = Convert.FromBase64String(campoValor);
            byte[] salt = Encoding.Unicode.GetBytes(campoValor);

            using (var hmac = new HMACSHA512(salt))
            {
               
                var passwordHash = hmac.ComputeHash(unicode.GetBytes(password));

                retorno = unicode.GetString(passwordHash);

                retorno = "";

               
                foreach (var b in passwordHash)
                {
                    retorno += string.Format("{0:x2}", b);
                }
                    
              
                return retorno;

            }
        }
    }
}
