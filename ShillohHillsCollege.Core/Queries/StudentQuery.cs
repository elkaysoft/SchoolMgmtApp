using ShillohHillsCollege.Core.DAC;
using ShillohHillsCollege.Core.Util;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using ShillohHillsCollege.Core.DTO;
using System.Collections.Generic;
using System.Linq;

namespace ShillohHillsCollege.Core.Queries
{
    public class StudentQuery
    {
        public static bool IsStudentExists(string fullName, string className, string regNumber)
        {
            bool response = false;

            try
            {
                var sql = "select * from StudentInfo where FullName=@fName and CurrentClass=@className";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();

                    var resp = connection.QueryFirstOrDefault<GetStudentDto>(sql,
                        new { fName = fullName, className = className });

                    if (resp != null)
                    {
                        response = true;
                    }

                }
            }
            catch
            {
                response = false;
            }

            return response;

        }

        public static bool IsStudentClassExists(string className)
        {
            bool response = false;

            try
            {
                var sql = "select * from StudentClasses where Name=@name";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();

                    var resp = connection.QueryFirstOrDefault<StudentClassDto>(sql,
                        new { name = className });

                    if (resp != null)
                    {
                        response = true;
                    }

                }
            }
            catch
            {
                response = false;
            }

            return response;
        }

        public async static Task<Responses<List<GetStudentDto>>> GetStudentByKeyword(string keyword)
        {
            var result = new Responses<List<GetStudentDto>>()
            {
                code = ResponseHub.Responsecode97,
                description = ResponseHub.ResponseMessage97
            };

            try
            {
                var sql = $"select * from StudentInfo where FullName like '%{keyword}%' or RegistrationNo like '%{keyword}%'";

                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();

                    var resp = await connection.QueryAsync<GetStudentDto>(sql).ConfigureAwait(false);

                    if (resp.Any())
                    {
                        var rs = new List<GetStudentDto>();

                        foreach(var student in resp)
                        {
                            rs.Add(new GetStudentDto
                            {
                                CreatedBy = student.CreatedBy,
                                CreatedOn = student.CreatedOn,
                                CurrentClass = student.CurrentClass,
                                DoB = student.DoB,
                                FullName = student.FullName,
                                Gender = student.Gender,
                                RegistrationNo = student.RegistrationNo,
                                ParentMobile = student.ParentMobile,
                                ParentName = student.ParentName,
                                RegistrationDate = student.CreatedOn.ToString("dd/MM/yyyy")
                            });
                        }

                        result.data = rs;
                        result.description = ResponseHub.ResponseMessage20;
                        result.code = ResponseHub.Responsecode20;
                    }
                    else
                    {
                        result.description = ResponseHub.ResponseMessage22;
                        result.code = ResponseHub.Responsecode22;
                    }

                }
            }
            catch
            {
                result.description = ResponseHub.ResponseMessage99;
                result.code = ResponseHub.Responsecode99;
            }

            return result;
        }

        public async static Task<Responses<List<GetStudentDto>>> GetStudentByClass(string className)
        {
            var result = new Responses<List<GetStudentDto>>()
            {
                code = ResponseHub.Responsecode97,
                description = ResponseHub.ResponseMessage97
            };

            try
            {
                var sql = $"select * from StudentInfo where CurrentClass = @currentClass";

                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();

                    var resp = await connection.QueryAsync<GetStudentDto>(sql, new { currentClass = className }).ConfigureAwait(false);

                    if (resp.Any())
                    {
                        var rs = new List<GetStudentDto>();

                        foreach (var student in resp)
                        {
                            rs.Add(new GetStudentDto
                            {
                                CreatedBy = student.CreatedBy,
                                CreatedOn = student.CreatedOn,
                                CurrentClass = student.CurrentClass,
                                DoB = student.DoB,
                                FullName = student.FullName,
                                Gender = student.Gender,
                                RegistrationNo = student.RegistrationNo,
                                ParentMobile = student.ParentMobile,
                                ParentName = student.ParentName,
                                RegistrationDate = student.CreatedOn.ToString("dd/MM/yyyy")
                            });
                        }

                        result.data = rs;
                        result.description = ResponseHub.ResponseMessage20;
                        result.code = ResponseHub.Responsecode20;
                    }
                    else
                    {
                        result.description = ResponseHub.ResponseMessage22;
                        result.code = ResponseHub.Responsecode22;
                    }

                }
            }
            catch(Exception ex)
            {
                ex.ToString();
                result.description = ResponseHub.ResponseMessage99;
                result.code = ResponseHub.Responsecode99;
            }

            return result;
        }

        public static bool ValidatedRegistrationNumber(string regNumber)
        {
            bool response = false;

            try
            {
                var sql = "select * from StudentInfo where RegistrationNo=@studentId";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();

                    var resp = connection.QueryFirstOrDefault<GetStudentDto>(sql,
                        new { studentId = regNumber });

                    if (resp != null)
                    {
                        response = true;
                    }

                }
            }
            catch
            {
                response = false;
            }

            return response;
        }

        public static GetStudentDto GetSingleStudentById(string studentId)
        {
            var result = new GetStudentDto();

            try
            {
                var sql = "select * from StudentInfo where RegistrationNo=@studentId";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();

                    var resp = connection.QueryFirstOrDefault<GetStudentDto>(sql,
                        new { studentId = studentId });

                    if (resp != null)
                    {
                        result.CreatedBy = resp.CreatedBy;
                        result.CreatedOn = resp.CreatedOn;
                        result.CurrentClass = resp.CurrentClass;
                        result.DoB = resp.DoB;
                        result.FullName = resp.FullName;
                        result.Gender = resp.Gender;
                        result.Id = resp.Id;
                        result.OutstandingBalance = resp.OutstandingBalance;
                        result.ParentMobile = resp.ParentMobile;
                        result.ParentName = resp.ParentName;
                        result.RegistrationDate = resp.RegistrationDate;
                        result.RegistrationNo = resp.RegistrationNo;
                    }

                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }

            return result;
        }

        public static SessionDto GetCurrentAcademicSession()
        {
            var result = new SessionDto();

            var sql = "select * from AcademicSessions Order by EndDate desc";
            using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
            {
                connection.Open();

                var resp = connection.QueryFirstOrDefault<SessionDto>(sql);

                if (resp != null)
                {
                    result = resp;
                }

            }

            return result;
        }


        public async static Task<Responses<List<StudentClassDto>>> GetCollegeClasses()
        {
            var result = new Responses<List<StudentClassDto>>()
            {
                code = ResponseHub.Responsecode97,
                description = ResponseHub.ResponseMessage97
            };

            try
            {
                var sql = $"select * from StudentClasses order by SubmittedOn desc";

                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();

                    var resp = await connection.QueryAsync<StudentClassDto>(sql).ConfigureAwait(false);

                    if (resp.Any())
                    {
                        var rs = new List<StudentClassDto>();

                        foreach (var studentClass in resp)
                        {
                            rs.Add(new StudentClassDto
                            {
                               Id = studentClass.Id,
                               Name = studentClass.Name,
                               SubmittedBy = studentClass.SubmittedBy,
                                SubmittedOn = studentClass.SubmittedOn
                            });
                        }

                        result.data = rs;
                        result.description = ResponseHub.ResponseMessage20;
                        result.code = ResponseHub.Responsecode20;
                    }
                    else
                    {
                        result.description = ResponseHub.ResponseMessage22;
                        result.code = ResponseHub.Responsecode22;
                    }

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                result.description = ResponseHub.ResponseMessage99;
                result.code = ResponseHub.Responsecode99;
            }

            return result;
        }



    }
}
