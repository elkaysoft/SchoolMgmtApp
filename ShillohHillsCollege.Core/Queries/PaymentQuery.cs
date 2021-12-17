using Dapper;
using ShillohHillsCollege.Core.DAC;
using ShillohHillsCollege.Core.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShillohHillsCollege.Core.Queries
{
    public class PaymentQuery
    {
        public static bool IsTermPaymentExist(string studentId, string session, string term, string studentClass)
        {
            bool response = false;

            try
            {
                var sql = "select * from FeesPayment where StudentId=@studentId and Session=@session and Term=@term and CurrentClass=@currentClass and IsDeleted=0";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();

                    var resp = connection.QueryFirstOrDefault<StudentPaymentInfoDto>(sql,
                        new { studentId = studentId, session = session, term = term, currentClass = studentClass });

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

        public static decimal GetStudentCurrentBalance(string studentId)
        {
            decimal response = 0;
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
                        response = resp.OutstandingBalance;
                    }

                }
            }
            catch(Exception ex)
            {
                ex.ToString();
                response = 0;
            }

            return response;
        }

        public static List<PaymentHistoryDto> GetPaymentHistoryByStudent(string studentId)
        {
            var response = new List<PaymentHistoryDto>();

            try
            {
                var sql = "select * from PaymentHistory where StudentId=@studentId";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();

                    var resp = connection.Query<PaymentHistoryDto>(sql,
                        new { studentId = studentId });

                    if (resp.Any())
                    {
                        foreach (var r in resp)
                        {
                            response.Add(new PaymentHistoryDto
                            {
                                studentId = r.studentId,
                                amountPaid = r.amountPaid,
                                outstandingAmount = r.outstandingAmount,
                                createdOn = r.createdOn,
                                createdBy = r.createdBy,
                                paymentId = r.paymentId,
                                dateCreated = r.createdOn.ToString("dd-MM-yyyy"),
                                description = r.description
                            });
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return response;
        }

        public static List<FeesPaymentDto> GetFeesStatisticsByStudent(string studentId)
        {
            var response = new List<FeesPaymentDto>();

            try
            {
                var sql = "select * from FeesPayment where StudentId=@studentId";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();

                    var resp = connection.Query<FeesPaymentDto>(sql,
                        new { studentId = studentId });

                    if (resp.Any())
                    {
                        foreach (var r in resp)
                        {
                            response.Add(new FeesPaymentDto
                            {
                                Id = r.Id,
                                AmountPaid = r.AmountPaid,
                                outstandingAmount = r.outstandingAmount,
                                totalAmount = r.totalAmount,
                                currentClass = r.currentClass,
                                description = r.description,
                                session = r.session,
                                studentId = r.studentId,
                                term = r.term,
                                CreatedOn = r.CreatedOn
                            });
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return response;
        }


        public static List<FeesPaymentDto> GetOustandingDebtById(string studentId)
        {
            var response = new List<FeesPaymentDto>();

            try
            {
                var sql = "select * from FeesPayment where StudentId=@studentId and OutstandingAmount <> 0";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();

                    var resp = connection.Query<FeesPaymentDto>(sql,
                        new { studentId = studentId });

                    if (resp.Any())
                    {
                        foreach (var r in resp)
                        {
                            response.Add(new FeesPaymentDto
                            {
                                Id = r.Id,
                                AmountPaid = r.AmountPaid,
                                outstandingAmount = r.outstandingAmount,
                                totalAmount = r.totalAmount,
                                currentClass = r.currentClass,
                                description = r.description,
                                session = r.session,
                                studentId = r.studentId,
                                term = r.term,
                                CreatedOn = r.CreatedOn
                            });
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return response;
        }


    }
}
