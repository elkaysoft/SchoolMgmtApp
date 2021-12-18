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

namespace ShillohHillsCollege.Core.Commands
{
    public class AccountCommand
    {
        public static Responses UploadUser(LoginDto request)
        {
            var result = new Responses()
            {
                code = ResponseHub.Responsecode97,
                description = ResponseHub.ResponseMessage97
            };

            try
            {
                var sql = "INSERT INTO UserLogin(Username,Password,FullName,Gender,PhoneNumber,IsDeleted,DateCreated,CreatedBy,UserType) VALUES(@username,@password,@fullName,@gender,@phone,@isDeleted,@dateCreated,@createdBy,@uType)";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();
                    var resp = connection.Execute(sql, new
                    {
                        username = request.Username,
                        password = request.Password,
                        fullName = request.FullName,
                        gender = request.Gender,
                        phone = request.PhoneNumber,
                        isDeleted = 0,
                        createdBy = "admin",
                        uType = request.UserType,
                        dateCreated = helper.FormatDateV2(DateTime.Now)
                    });

                    if (resp > 0)
                    {
                        result.code = ResponseHub.Responsecode20;
                        result.description = ResponseHub.ResponseMessage20;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                result.code = ResponseHub.Responsecode99;
                result.description = ResponseHub.ResponseMessage99;
            }

            return result;
        }

        public static int UpdateUserPassword(string username, string newPassword)
        {
            int result = 0;
            try
            {
                var sql = "UPDATE UserLogin SET Password = @password where Username=@uName";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();
                    var resp = connection.Execute(sql, new
                    {
                        password = newPassword,
                        uName = username
                    });

                    result = resp;

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return result;
        }

    }
}
