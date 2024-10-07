using LogisticaContainers.Managers.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;


namespace LogisticaContainers.Managers.Repos
{
    public interface IUsuarioRepository
    {

    
        int CrearUsuario(Usuario usuario);
        Usuario? GetUsuarioPorGoogleSubject(string googleSubject);
        Usuario? GetUsuarioPorId(int IdUsuario);
        IEnumerable<Usuario> GetUsuarios();
    }

    public class UsuarioRepository : IUsuarioRepository
    {
        private string _connectionString;

        //constructor
        public UsuarioRepository(string connectionStrings)
        {

            //Connection string 
            _connectionString = connectionStrings;



        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                List<Usuario> usuarios = db.Query<Usuario>("SELECT * FROM Usuario").ToList();

                return usuarios;

            }

            //			return PersonasDePrueba;
        }

        public Usuario? GetUsuarioPorId(int IdUsuario)
        {

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Usuario usuarios = db.Query<Usuario>("SELECT * FROM Usuario WHERE IdUsuario = " + IdUsuario.ToString()).FirstOrDefault();

                return usuarios;
            }


        }

        public Usuario? GetUsuarioPorGoogleSubject(string googleSubject)
        {

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Usuario usuarios = db.Query<Usuario>("SELECT * FROM Usuario WHERE GoogleIdentificador = '" + googleSubject.ToString() + "'").FirstOrDefault();

                return usuarios;
            }
        }
        public int CrearUsuario(Usuario usuario)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Usuario (GoogleIdentificador, NombreCompleto, Nombre, Apellido, Email, Borrado, IdUsuarioAlta, FechaAlta, IdUsuarioModificacion, FechaModificacion, IdUsuarioBaja, FechaBaja)  
                         VALUES (@GoogleIdentificador, @NombreCompleto, @Nombre, @Apellido, @Email, @Borrado, @IdUsuarioAlta, @FechaAlta, @IdUsuarioModificacion, @FechaModificacion, @IdUsuarioBaja, @FechaBaja);                    
                         SELECT CAST(SCOPE_IDENTITY() AS INT)";

                usuario.IdUsuario = db.QuerySingle<int>(query, usuario);

                return usuario.IdUsuario;
            }
        }

    }
}
