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
    public class PaymentCommand
    {
        public static Responses AddAcademicFees(AddAcademicFeesDto request)
        {
            var result = new Responses()
            {
                code = ResponseHub.Responsecode97,
                description = ResponseHub.ResponseMessage97
            };

            try
            {
                var sql = "INSERT INTO AcademicFees VALUES(@name,@term,@klass,@description,@amount,@deduction,@isDeleted,@createdBy,@createdOn)";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();
                    var resp = connection.Execute(sql, new
                    {
                        name = request.session,
                        term = request.term,
                        klass = request.studentClass,
                        description = request.description,
                        amount = request.amount,
                        deduction = request.deduction,
                        isDeleted = false,
                        createdBy = request.createdBy,
                        createdOn = DateTime.Now
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

        public static Responses AddStudentPaymentInfo(AddStudentPaymentInfoDto request)
        {
            var result = new Responses()
            {
                code = ResponseHub.Responsecode97,
                description = ResponseHub.ResponseMessage97
            };

            try
            {
                var sql = "INSERT INTO FeesPayment(Session,Term,CurrentClass,Description,TotalAmount,AmountPaid,OutstandingAmount,IsDeleted,StudentId,CreatedBy, PaymentId) VALUES(@sessionName,@term,@klass,@description,@TotalAmount,@amtPaid,@outstanding,@isDeleted,@studentId,@createdBy, @paymentid)";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();
                    var resp = connection.Execute(sql, new
                    {
                        sessionName = request.session,
                        term = request.term,
                        klass = request.currentClass,
                        description = request.description,
                        TotalAmount = request.totalAmt,
                        amtPaid = request.amtPaid,
                        outstanding = request.balance,
                        isDeleted = false,
                        studentId = request.studentId,
                        createdBy = "admin",
                        paymentid = request.paymentId
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

        public static void UpdateStudentOutstandingBalance(string studentId, decimal amount)
        {
            try
            {
                var sql = "UPDATE StudentInfo SET OutstandingBalance = @balance where RegistrationNo=@studentId";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();
                    var resp = connection.Execute(sql, new
                    {
                        balance = amount,
                        studentId = studentId
                    });

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public static void AddPaymentHistory(string studentId, string session, string terms, string klass, decimal amount, string description, string paymentId)
        {
            try
            {
                var sql = "INSERT INTO PaymentHistory(StudentId,Session,Term,StudentClass,AmountPaid, description, paymentId, CreatedOn) VALUES(@studentId,@sessionName,@term,@klass,@amtPaid,@desc, @payId, @createdOn)";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();
                    var resp = connection.Execute(sql, new
                    {
                        sessionName = session,
                        term = terms,
                        klass = klass,
                        amtPaid = amount,
                        studentId = studentId,
                        desc = description,
                        payId = paymentId,
                        createdOn = helper.FormatDateV2(DateTime.Now)
                    });

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public static void UpdateAmountPaidAfterDebt(string paymentId, decimal amount)
        {
            try
            {
                var sql = "UPDATE FeesPayment SET AmountPaid = AmountPaid + @amt, OutstandingAmount = OutstandingAmount - @amt where Id=@id";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();
                    var resp = connection.Execute(sql, new
                    {
                        id = paymentId,
                        amt = amount,
                    });

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }



    }
}
