using Dapper;
using ShillohHillsCollege.Core.DAC;
using ShillohHillsCollege.Core.DTO;
using ShillohHillsCollege.Core.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShillohHillsCollege.Core.Queries
{
    public class AccountQuery
    {
        public static async Task<Responses> CanLogin(string username, string password)
        {
            var response = new Responses<LoginDto> 
            { 
                code = ResponseHub.Responsecode97,
                description = ResponseHub.ResponseMessage97
            };

            try
            {
                var sql = "select * from UserLogin where username=@username and password=@password";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();

                   var resp = await connection.QueryFirstOrDefaultAsync<LoginDto>(sql, 
                       new { Username = username, Password = password })
                        .ConfigureAwait(false);

                    if (resp == null)
                    {
                        response.code = ResponseHub.Responsecode21;
                        response.description = ResponseHub.ResponseMessage21;
                    }
                    else
                    {
                        var userDetails = new LoginDto()
                        {
                            CreatedBy = resp?.CreatedBy,
                            DateCreated = resp.DateCreated,
                            FullName = resp?.FullName,
                            Gender = resp?.Gender,
                            Password = resp?.Password,
                            PhoneNumber = resp?.PhoneNumber,
                            Username = resp.Username,
                            Id = resp.Id
                        };

                        response.data = userDetails;
                        response.code = ResponseHub.Responsecode20;
                        response.description = ResponseHub.ResponseMessage20;
                    }

                    
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
                response.code = ResponseHub.Responsecode99;
                response.description = ResponseHub.ResponseMessage99;
            }

            return response;
        }


        public bool ValidatePassword(string username, string password)
        {
            bool response = false;
            password = helper.EncodeToBase64(password);

            try
            {
                var sql = "select * from UserLogin where username=@username and password=@password";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();

                    var resp = connection.QueryFirst<LoginDto>(sql,
                        new { Username = username, Password = password });

                    if (resp == null)
                    {
                        response = true; //Password valid
                    }


                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return response;
        }


        public static bool IsAccountExists(string username)
        {
            bool result = false;

            var sql = "select * from UserLogin where username=@username";
            using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
            {
                connection.Open();

                var resp = connection.QueryFirstOrDefault<LoginDto>(sql,
                    new { Username = username });

                if (resp != null)
                {
                    result = true;
                }
            }

            return result;
        }


        public static List<LoginDto> GetAllUsers()
        {
            var result = new List<LoginDto>();

            var sql = "select * from UserLogin where UserType <> 'Administrator' order by DateCreated desc";
            using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
            {
                connection.Open();

                var resp = connection.Query<LoginDto>(sql);

                if (resp.Any())
                {
                    foreach(var user in resp)
                    {
                        result.Add(new LoginDto
                        {
                            CreatedBy = user.CreatedBy,
                            DateCreated = user.DateCreated,
                            FullName = user.FullName,
                            Gender = user.Gender,
                            Password = user.Password,
                            PhoneNumber = user.PhoneNumber,
                            Username = user.Username,
                            UserType = user.UserType
                        });
                    }

                }
            }

            return result;
        }


        public static LoginDto GetUserInfoByUsername(string username)
        {
            var result = new LoginDto();

            var sql = "select * from UserLogin where Username = '"+ username +"'";
            using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
            {
                connection.Open();

                var resp = connection.QueryFirstOrDefault<LoginDto>(sql);
                if(resp.Username != null)
                {
                    result.CreatedBy = resp.CreatedBy;
                    result.DateCreated = resp.DateCreated;
                    result.FullName = resp.FullName;
                    result.Gender = resp.Gender;
                    result.Password = resp.Password;
                    result.PhoneNumber = resp.PhoneNumber;
                    result.Username = resp.Username;
                    result.UserType = resp.UserType;                    
                }
            }

            return result;
        }


    }
}
