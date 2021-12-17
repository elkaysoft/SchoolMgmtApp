using Dapper;
using ShillohHillsCollege.Core.DAC;
using ShillohHillsCollege.Core.DTO;
using ShillohHillsCollege.Core.Util;
using System;
using System.Data.SqlClient;

namespace ShillohHillsCollege.Core.Commands
{
    public class SettingsCommand
    {
        public static Responses AddAcademicSession(AddSessionDto request)
        {
            var result = new Responses()
            {
                code = ResponseHub.Responsecode97,
                description = ResponseHub.ResponseMessage97
            };

            try
            {
                var sql = "INSERT INTO AcademicSessions(Name,DateCreated,CreatedBy,StartDate,EndDate,IsActive) VALUES(@name,@createdOn,@createdBy,@beginDate,@finishDate,@activity)";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();
                    var resp = connection.Execute(sql, new
                    {
                        name = request.SessionName,
                        createdOn = DateTime.Now,
                        createdBy = request.SessionName,
                        beginDate = request.startDate,
                        finishDate = request.endDate,
                        activity = false
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


        public static Responses AddAcademicTerm(AddAcademicTermDto request)
        {
            var result = new Responses()
            {
                code = ResponseHub.Responsecode97,
                description = ResponseHub.ResponseMessage97
            };

            try
            {
                DeactivateAllTerm();
                var sql = "INSERT INTO AcademicTerm(Term,Session,IsActive,StartDate,EndDate,CreatedOn,CreatedBy) VALUES(@term,@session,@isActive,@beginDate,@finishDate,@createdOn,@createdBy)";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();
                    var resp = connection.Execute(sql, new
                    {
                        term = request.Term,
                        session = request.Session,
                        isActive = true,
                        createdOn = helper.FormatDateV2(DateTime.Now),
                        createdBy = "admin",
                        beginDate = request.StartDate,
                        finishDate = request.EndDate
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

        public static void DeactivateAllTerm()
        {
            try
            {
                var sql = "UPDATE AcademicTerm SET IsActive = 0";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();
                    connection.Execute(sql);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public static void ToggleAcademicTerm(string sessionName, string term, bool status)
        {
            try
            {
                var sql = "UPDATE AcademicTerm SET IsActive = @isactive where Term=@term, Session=session";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();
                    connection.Execute(sql, new {isactive = status, term = term, session = sessionName });
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
             
        public static void ToggleTermStatus(int Id, bool termstatus)
        {
            try
            {
                var sql = "UPDATE AcademicTerm SET IsActive = @status where Id = @termId";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();
                    connection.Execute(sql, new
                    {
                        status = termstatus,
                        termId = Id
                    });
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public static void UpdateAutoRegistrationNumber()
        {
            try
            {
                var sql = "UPDATE AutoGeneratedNumbers SET RecId = RecId + 1 where Category = 'StudentRegistration'";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();
                    connection.Execute(sql);                    
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public static void UpdateAutoPaymentId()
        {
            try
            {
                var sql = "UPDATE AutoGeneratedNumbers SET RecId = RecId + 1 where Category = 'Payment'";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();
                    connection.Execute(sql);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public static Responses UpdateClass(string oldClass, string className)
        {
            var result = new Responses()
            {
                code = ResponseHub.Responsecode97,
                description = ResponseHub.ResponseMessage97
            };

            try
            {
                var sql = "UPDATE StudentClasses SET Name=@name where Name=@frmClass";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();
                    var resp = connection.Execute(sql, new
                    {
                        name = className,
                        frmClass = oldClass
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

        public static Responses DeleteClass(string className)
        {
            var result = new Responses()
            {
                code = ResponseHub.Responsecode97,
                description = ResponseHub.ResponseMessage97
            };

            try
            {
                var sql = "DELETE StudentClasses where Name=@name";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();
                    var resp = connection.Execute(sql, new
                    {
                        name = className
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


    }
}
