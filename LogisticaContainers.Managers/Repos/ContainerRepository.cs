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
        Container GetContainer(int IdContainer);
        IEnumerable<Container> GetContainers(bool? SoloActivos = true);
        IEnumerable<ContainerCompleto> GetContainersCompleto();
        int CrearContainer(Container container);
        bool ModificarContainer(int IdContainer, Container container);
        bool EliminarContainer(int IdContainer, int IdUsuarioBaja);
    }

    public class ContainerRepository : IContainerRepository
    {
        private string _connectionString;

        public ContainerRepository(string connectionString)
        {
            _connectionString = connectionString;

        }
        /// <summary>
        /// Consulta a la base de datos por Id
        /// </summary>
        /// <param name="IdContainer"></param>
        /// <returns></returns>
        public Container GetContainer(int IdContainer)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                Container result = conn.QuerySingle<Container>("Select * from Container Where IdContainer = " + IdContainer.ToString());

                return result;

            }
        }

        /// <summary>
        /// Consulta a la base de datos por la lista de los containers
        /// </summary>
        /// <param name="SoloActivos">True: Solo trae los activos, False: Trae todos los registros</param>
        /// <returns></returns>
        public IEnumerable<Container> GetContainers(bool? SoloActivos = true)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {


                string query = "Select * from Container ";
                if (SoloActivos == true)
                    query += " where FechaBaja is null"; 
                IEnumerable<Container> results = conn.Query<Container>(query);

                return results;

            }
        }
       
        
        /// <summary>
        /// Obtiene una lista completa de los containers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ContainerCompleto> GetContainersCompleto()
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                IEnumerable<ContainerCompleto> results =
                        conn.Query<ContainerCompleto>(@"select Container.*, EstadosContainer.Descripcion Estado 
                                                    from container 
                                                    left join EstadosContainer on Container.IdEstadoContainer = EstadosContainer.IdEstadoContainer
                                                   where container.fechabaja is null");

                return results;

            }
        }


        /// <summary>
        /// Crear nuevo Container en la base de datos
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Modificar Container en la base de Datos
        /// </summary>
        /// <param name="IdContainer"></param>
        /// <param name="container"></param>
        /// <param name="IdUsuarioModificacion"></param>
        /// <returns></returns>
        public bool ModificarContainer(int IdContainer, Container container)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE 
                                    Container 
                                SET 
                                    DescripcionContainer = @DescripcionContainer, 
                                    IdEstadoContainer = @IdEstadoContainer, 
                                    FechaModificacion = @FechaModificacion, 
                                    IdUsuarioModificacion  = @IdUsuarioModificacion    
                                    WHERE IdContainer = " + IdContainer.ToString();

                //db.execute devuelve un entero que representa la cantidad de filas afectadas. 
                //Se espera que se haya modificado solo un registro, por eso se lo compara con un 1.
                return db.Execute(query, container) == 1;
            }
        }

        /// <summary>
        /// Eliminar de manera lógica un container de la base de datos
        /// </summary>
        /// <param name="IdContainer"></param>
        /// <param name="IdUsuarioBaja"></param>
        /// <returns></returns>
        public bool EliminarContainer(int IdContainer, int IdUsuarioBaja)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE 
                                    Container 
                                SET 
                                    
                                    FechaBaja = '" + DateTime.Now.ToString("yyyyMMdd")+"'," +  
                                    " IdUsuarioBaja  = " + IdUsuarioBaja +
                                "WHERE IdContainer = " + IdContainer.ToString();


                //db.execute devuelve un entero que representa la cantidad de filas afectadas. 
                //Se espera que se haya modificado solo un registro, por eso se lo compara con un 1.
                return db.Execute(query) == 1;
            }
        }


    }
}
