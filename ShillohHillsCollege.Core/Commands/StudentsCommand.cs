using ShillohHillsCollege.Core.DAC;
using ShillohHillsCollege.Core.DTO;
using ShillohHillsCollege.Core.Util;
using System;
using Dapper;
using System.Data.SqlClient;

namespace ShillohHillsCollege.Core.Commands
{
    public class StudentsCommand
    {
        public static Responses<string> AddSingleStudent(AddStudentDto request)
        {
            var result = new Responses<string>()
            {
                code = ResponseHub.Responsecode97,
                description = ResponseHub.ResponseMessage97
            };

            try
            {
                var sql = "INSERT INTO StudentInfo(RegistrationNo,FullName,Gender,DoB,CurrentClass,ParentName,ParentMobile,OutstandingBalance,IsDeleted,CreatedBy,CreatedOn) VALUES(@regNumber,@FullName,@Gender,@Dob,@CurrentClass,@ParentName,@ParentMobile,@OutstandingBalance,@IsDeleted,@Createdby,@CreatedOn)";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();
                    var resp = connection.Execute(sql, new
                    {
                        regNumber = request.RegistrationNo,
                        FullName = request.FullName,
                        Gender = request.Gender,
                        Dob = request.DoB,
                        CurrentClass = request.CurrentClass,
                        ParentName = request.ParentName,
                        ParentMobile = request.ParentMobile,
                        OutstandingBalance = 0,
                        IsDeleted = false,
                        Createdby = request.CreatedBy,
                        CreatedOn = request.CreatedOn
                    });

                    if (resp > 0)
                    {
                        result.code = ResponseHub.Responsecode20;
                        result.description = ResponseHub.ResponseMessage20;
                        result.data = request.RegistrationNo;
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

        public static Responses AddStudentClass(string className, string submittedBy)
        {
            var result = new Responses()
            {
                code = ResponseHub.Responsecode97,
                description = ResponseHub.ResponseMessage97
            };

            try
            {
                var sql = "INSERT INTO StudentClasses(Name,SubmittedBy,SubmittedOn) VALUES(@name,@submittedBy,@submittedOn)";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();
                    var resp = connection.Execute(sql, new
                    {
                        name = className,
                        submittedBy = submittedBy,
                        submittedOn = DateTime.Now
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

        public static void UpdateStudentInfo(UpdateStudentDto payload)
        {
            try
            {
                var sql = "UPDATE StudentInfo SET FullName = @name, DoB = @dob, Gender = @gender, CurrentClass = @klass" +
                    ", ParentName = @pName, ParentMobile = @pMobile where RegistrationNo = @regNo";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();
                    var resp = connection.Execute(sql, new
                    {
                        name = payload.FullName,
                        dob = payload.DoB,
                        gender = payload.Gender,
                        klass = payload.CurrentClass,
                        pName = payload.ParentName,
                        pMobile = payload.ParentMobile,
                        regNo = payload.studentId
                    });

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public static void DeleteStudent(string studentId)
        {
            try
            {
                var sql = "DELETE FROM StudentInfo WHERE RegistrationNo = @regNumber";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();
                    var resp = connection.Execute(sql, new
                    {
                        regNumber = studentId
                    });
                }
            }
            catch 
            {             
            }
        }


        //Term Migration
        public static void MigratetudentsToAnotherClass(string currentClass, string newClass)
        {
            var sql = "UPDATE StudentInfo SET CurrentClass = '"+ newClass +"' where CurrentClass = '"+ currentClass +"' ";
            using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
            {
                connection.Open();
                var resp = connection.Execute(sql);
            }
        }
    }
}
