using Dapper;
using LogisticaContainers.Managers.Entidades;
using LogisticaContainers.ModelFactories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticaContainers.Repos
{
    public interface IContainerRepository
    {
        IEnumerable<Container> GetContainers();
        IEnumerable<ContainerVM> GetContainersVM();
        int CrearContainer(Container container);
    }

    public class ContainerRepository : IContainerRepository
    {
        private string _connectionString;

        public ContainerRepository(string connectionString)
        {
            _connectionString = connectionString;

        }

        public IEnumerable<Container> GetContainers()
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                IEnumerable<Container> results = conn.Query<Container>("Select * from Container ");

                return results;

            }
        }
        public IEnumerable<ContainerVM> GetContainersVM()
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                IEnumerable<ContainerVM> results =
                        conn.Query<ContainerVM>(@"select Container.*, EstadosContainer.Descripcion Estado 
                                                    from container 
                                                    left join EstadosContainer on Container.IdEstadoContainer = EstadosContainer.IdEstadoContainer");

                return results;

            }
        }

        public int CrearContainer(Container container)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Container (DescripcionContainer, IdEstadoContainer, IdUsuarioAlta, FechaAlta, IdUsuarioModificacion, FechaModificacion, IdUsuarioBaja, FechaBaja)  
                                VALUES ( @DescripcionContainer, @IdEstadoContainer, @IdUsuarioAlta, @FechaAlta, @IdUsuarioModificacion, @FechaModificacion, @IdUsuarioBaja, @FechaBaja);                    
                                SELECT CAST(SCOPE_IDENTITY() AS INT) ";


                container.IdContainer = db.QuerySingle<int>(query, container);


                return container.IdContainer;
            }
        }


    }
}
