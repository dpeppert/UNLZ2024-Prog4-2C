using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogisticaContainers.Entidades;
using Dapper;

namespace LogisticaContainers.Repos
{
    public interface IEstadoContainerRepository
    {
        EstadoContainer GetEstadoContainer(int IdEstadoContainer);
        IEnumerable<EstadoContainer> GetEstadosContainer(bool? SoloActivos = true);
    }

    public class EstadoContainerRepository : IEstadoContainerRepository
    {
        private string _connectionString;

        public EstadoContainerRepository(string connectionString)
        {
            _connectionString = connectionString;

        }
        /// <summary>
        /// Consulta a la base de datos por Id
        /// </summary>
        /// <param name="IdContainer"></param>
        /// <returns></returns>
        public EstadoContainer GetEstadoContainer(int IdEstadoContainer)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {
                EstadoContainer result = conn.QuerySingle<EstadoContainer>("Select * from EstadosContainer Where IdEstadoContainer = " + IdEstadoContainer.ToString());

                return result;

            }
        }

        /// <summary>
        /// Consulta a la base de datos por la lista de los containers
        /// </summary>
        /// <param name="SoloActivos">True: Solo trae los activos, False: Trae todos los registros</param>
        /// <returns></returns>
        public IEnumerable<EstadoContainer> GetEstadosContainer(bool? SoloActivos = true)
        {
            using (IDbConnection conn = new SqlConnection(_connectionString))
            {


                string query = "Select * from EstadosContainer ";
                if (SoloActivos == true)
                    query += " where FechaBaja is null";
                IEnumerable<EstadoContainer> results = conn.Query<EstadoContainer>(query);

                return results;

            }
        }

    }
}
