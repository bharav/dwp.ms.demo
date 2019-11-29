using Microsoft.Data.SqlClient;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dwp.ms.demo.registration.Queries
{
    public class RegistrationQueries : IRegistrationQueries
    {
        private string _connectionString = string.Empty;

        public RegistrationQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<Registration> GetRegistrationAsync(int regId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<dynamic>(
                   @"select o.Id as Id, o.[RegNo] as RegNo,o.Name as Name, o.Address as Address,
                        o.Phone as Phone, o.EngineNo as EngineNo, o.ChesisNo as ChesisNo
                        FROM Registration o
                        WHERE o.Id=@regId", new { regId}
                       );

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

                return MapRegistration(result.FirstOrDefault());
            }
        }

        private Registration MapRegistration(dynamic result)
        {
            var registration = new Registration
            {
                Id = result.Id,
                RegNo = result.RegNo,
                Name = result.Name,
                Address = result.Address,
                Phone = result.Phone,
                EngineNo = result.EngineNo,
                ChesisNo = result.ChesisNo
            };

            return registration;
        }   
    }
}
