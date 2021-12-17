﻿using Dapper;
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
    public class SettingsQuery
    {
        public static bool IsSessionRecordExists(string sessName)
        {
            bool response = false;

            try
            {
                var sql = "select * from AcademicSessions where Name=@name";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();

                    var resp = connection.QueryFirstOrDefault<SessionDto>(sql,
                        new { name = sessName });

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

        public static bool IsAcademicTermExists(string termName, string sessionName)
        {
            bool response = false;

            try
            {
                var sql = "select * from AcademicTerm where Term=@term and session=@session";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();

                    var resp = connection.QueryFirstOrDefault<AcademicTermDto>(sql,
                        new { term = termName, session = sessionName });

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

        public static bool IsFeesExists(string sessName, string term, string studentklass, string descr)
        {
            bool response = false;

            try
            {
                var sql = "select * from AcademicFees where Session=@session and Term=@term and StudentClass=@klass and FeeDescription=@desc";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();

                    var resp = connection.QueryFirstOrDefault<AcademicFeesDto>(sql,
                        new { session = sessName, term = term, klass = studentklass, desc = descr });

                    if (resp != null)
                    {
                        response = true;
                    }

                }
            }
            catch(Exception ex)
            {
                ex.ToString();
                response = false;
            }

            return response;

        }

        public static Int64 GetNextStudentRegistrationNumber()
        {
            Int64 response = 0;

            try
            {
                var sql = "select * from AutoGeneratedNumbers where Category ='StudentRegistration'";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();

                    var resp = connection.QueryFirstOrDefault<AutoGeneratedRegNumberDto>(sql);

                    if (resp != null)
                    {
                        response = resp.RecId;
                    }

                }
            }
            catch
            {
                response = 0;
            }

            return response;
        }

        public static Int64 GetNextPaymentId()
        {
            Int64 response = 0;

            try
            {
                var sql = "select * from AutoGeneratedNumbers where Category ='Payment'";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();

                    var resp = connection.QueryFirstOrDefault<AutoGeneratedRegNumberDto>(sql);

                    if (resp != null)
                    {
                        response = resp.RecId;
                    }

                }
            }
            catch
            {
                response = 0;
            }

            return response;
        }

        public async static Task<List<string>> GetAcademicSession()
        {
            var result = new List<string>();
            try
            {
                var sql = "select distinct([Session]) from AcademicTerm";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();

                    var resp = await connection.QueryAsync<string>(sql).ConfigureAwait(false);

                    if (resp != null)
                    {
                        foreach(var ses in resp)
                        {
                            result.Add(ses);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }

            return result;
        }

        public static List<AcademicFeesDto> GetAcademicFeesByFilter(string sessName, string term, string studentklass)
        {
            var response = new List<AcademicFeesDto>();

            try
            {
                var sql = "select * from AcademicFees where Session=@session and Term=@term and StudentClass=@klass";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();

                    var resp = connection.Query<AcademicFeesDto>(sql,
                        new { session = sessName, term = term, klass = studentklass});

                    if (resp.Any())
                    {
                        foreach(var r in resp)
                        {
                            response.Add(new AcademicFeesDto
                            {
                                deduction = r.deduction,
                                amount = r.amount,
                                createdBy = r.createdBy,
                                createdOn = r.createdOn,
                                FeeDescription = r.FeeDescription,
                                IsDeleted = r.IsDeleted,
                                session = r.session,
                                Id = r.Id,
                                studentClass = r.studentClass,
                                term = r.term
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

        public static decimal GetAmountPaidPerTerm(string sessName, string term, string studentklass, string studentId)
        {
            decimal result = 0;

            try
            {
                var sql = "select  from FeesPayment where Session=@session and Term=@term and StudentClass=@klass and StudentId=@studId";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();

                    var resp = connection.QueryFirstOrDefault<decimal>(sql,
                        new { session = sessName, term = term, klass = studentklass, studId = studentId });

                    result = resp;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return result;

        }

        public static List<AcademicTermDto> GetAcademicTerms()
        {
            var result = new List<AcademicTermDto>();
            try
            {
                var sql = "select * from AcademicTerm order by StartDate desc";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();

                    var resp = connection.Query<AcademicTermDto>(sql);

                    if (resp != null)
                    {
                        foreach (var ses in resp)
                        {
                            result.Add(new AcademicTermDto
                            {
                                CreatedBy = ses.CreatedBy,
                                CreatedOn = ses.CreatedOn,
                                EndDate = ses.EndDate,
                                Session = ses.Session,
                                StartDate = ses.StartDate,
                                Id = ses.Id,
                                Term = ses.Term,
                                IsActive = ses.IsActive
                            });
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return result;
        }
       
        public static AcademicTermDto GetCurrentAcademicTerm()
        {
            var result = new AcademicTermDto();
            try
            {
                var sql = "select * from AcademicTerm where IsActive = 1 order by StartDate desc";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();
                    var resp = connection.QueryFirstOrDefault<AcademicTermDto>(sql);

                    if (resp != null)
                    {
                        result.CreatedBy = resp.CreatedBy;
                        result.CreatedOn = resp.CreatedOn;
                        result.EndDate = resp.EndDate;
                        result.Session = resp.Session;
                        result.StartDate = resp.StartDate;
                        result.Id = resp.Id;
                        result.Term = resp.Term;
                        result.IsActive = resp.IsActive;
                    }

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return result;
        }


        public static bool HasOneActiveTerm()
        {
            bool result = false;
            try
            {
                var sql = "select * from AcademicTerm where IsActive = 1";
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    connection.Open();
                    var resp = connection.Query<AcademicTermDto>(sql);

                    if (resp.Count() == 1)
                    {
                        result = true;
                    }

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
