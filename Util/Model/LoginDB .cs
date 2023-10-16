using Légende_Obscure.Model;
using Légende_Obscure.Util;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Légende_Obscure.Util.ModelDB
{
    public class LoginDB
    {
        private readonly ApplicationDbContext _dbContext;

        public LoginDB(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> BuscarPorNome(string nome)
        {
            return _dbContext.User
                .Where(p => EF.Functions.Like(p.Email, $"%{nome}%"))
                .ToList();
        }

        public List<User> BuscarTodos()
        {
            return _dbContext.User.ToList();
        }
    }
}