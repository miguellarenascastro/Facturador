using AgricolaData.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgricolaData.StoreProcedures
{
  public  class SpUsuarioDomus
    {
        ApoloData.Context _context = new ApoloData.Context();
        public SpUsuarioDomus()
        {
          
                  _context = new ApoloData.Context();
        }


        public UsuarioDomusSpModel SP_CARGAR_USUARIO(string Usuario, string Clave)
        {
            try
            {
                return _context.Database.SqlQuery<UsuarioDomusSpModel>("EXEC sp_domususuarios @Usuario, @Clave",
                           new SqlParameter("Usuario", Usuario),
                           new SqlParameter("Clave", Clave)
                           ).FirstOrDefault();
            }
            catch (Exception e)
            {
                return null;
                throw;
            }

        }



    }
}
