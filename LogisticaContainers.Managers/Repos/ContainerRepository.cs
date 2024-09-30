using Dapper;
using LogisticaContainers.Entidades;
using System.Data;
using System.Data.SqlClient; 

namespace LogisticaContainers.Repositories
{
    public interface IContainerRepository
    {
        IEnumerable<Container> GetContainers();
    }

    public class ContainerRepository : IContainerRepository
    {
        private string _connectionString;

        public ContainerRepository(string connString)
        {
            _connectionString = connString;
        }

        public IEnumerable<Container> GetContainers()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                IEnumerable<Container> containers = db.Query<Container>("SELECT * FROM Container WHERE FechaBaja is null");

                return containers;
            }
        }

        public Container GetContainer(int idContainer)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                Container container= db.QuerySingle<Container>("SELECT * FROM Container WHERE IdContainer = " + idContainer.ToString());

                return container;
            }
        }

        public int CrearContainer (Container container)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Container (DescripcionContainer, IdEstadoContainer, IdUsuarioAlta, FechaAlta, IdUsuarioModificacion, FechaModificacion, IdUsuarioBaja, FechaBaja)  
                                VALUES ( @DescripcionContainer, @IdEstadoContainer, @IdUsuarioAlta, @FechaAlta, @IdUsuarioModificacion, @FechaModificacion, @IdUsuarioBaja, @FechaBaja);                    
                                SELECT CAST(SCOPE_IDENTITY() AS INT) ";


                container.IdContainer= db.QuerySingle<int>(query, container);


                return container.IdContainer;
            }
        }

        public bool ModificarPersona (int IdContainer, Container container)
        {
        
                using (IDbConnection db = new SqlConnection(_connectionString))
                {
                    string query = "UPDATE Container SET DescripcionContainer = @DescripcionContainer, IdEstadoContainer = @IdEstadoContainer, IdUsuarioAlta = @IdUsuarioAlta, FechaAlta = @FechaAlta, IdUsuarioModificacion = @IdUsuarioModificacion, FechaModificacion = @FechaModificacion, IdUsuarioBaja = @IdUsuarioBaja, FechaBaja = @FechaBaja  WHERE IdContainer = " + IdContainer.ToString();
                    db.Execute(query, container);

                    return true;
                }

            

        }

        public bool BorrarContainer(int IdContainer)
        {

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Container SET IdUsuarioBaja = 1, FechaBaja = GETDATE()  WHERE IdContainer = " + IdContainer.ToString();
                db.Execute(query);

                return true;
            }



        }
    }
}
