using api_dev_boost_auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_dev_boost_auth.Data
{
    public class ClientLoginDAL
    {
        private readonly List<SSOUser> SSOUsers;

        public ClientLoginDAL()
        {
            try
            {
                SSOUsers = new List<SSOUser>();

                SSOUser sSOUser1 = new SSOUser
                {
                    Id = 1,
                    Identifier = "8016789854",
                    Name = "João Silva",
                    Password = "123456",
                    Email = null,
                    JobRole = "Funcionario"
                };

                SSOUsers.Add(sSOUser1);

                SSOUser sSOUser2 = new SSOUser
                {
                    Id = 2,
                    Identifier = "1916789884",
                    Name = "Pedro Paulo",
                    Password = "123457",
                    Email = null,
                    JobRole = "Gerente"
                };

                SSOUsers.Add(sSOUser2);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SSOUser GetSSOUser(string user, string password)
        {
            try
            {
                var buscaLista = SSOUsers.Where(e => e.Identifier == user && e.Password == password);

                if (buscaLista != null)
                    return buscaLista.FirstOrDefault();
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
