using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShillohHillsCollege.Core.DTO
{
    public class AddAcademicFeesDto
    {
        public string session { get; set; }
        public string term { get; set; }
        public string studentClass { get; set; }
        public string description { get; set; }
        public decimal amount { get; set; }
        public decimal deduction { get; set; }
        public string createdBy { get; set; }
    }

    public class AcademicFeesDto
    {
        public Int64 Id { get; set; }
        public string session { get; set; }
        public string term { get; set; }
        public string studentClass { get; set; }
        public string FeeDescription { get; set; }
        public decimal amount { get; set; }
        public decimal deduction { get; set; }
        public bool IsDeleted { get; set; }
        public string createdBy { get; set; }
        public DateTime createdOn { get; set; }
    }

    public class AddStudentPaymentInfoDto
    {
        public string session { get; set; }
        public string term { get; set; }
        public string currentClass { get; set; }
        public string description { get; set; }
        public decimal totalAmt { get; set; }
        public decimal amtPaid { get; set; }
        public string studentId { get; set; }
        public decimal balance { get; set; }
        public string paymentId { get; set; }
    }

    public class FeesPaymentDto
    {
        public Int64 Id { get; set; }
        public string session { get; set; }
        public string term { get; set; }
        public string currentClass { get; set; }
        public string description { get; set; }
        public decimal totalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal outstandingAmount { get; set; }
        public string studentId { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class PaymentHistoryDto
    {
        public string session { get; set; }
        public string term { get; set; }
        public string studentClass { get; set; }
        public decimal amountPaid { get; set; }
        public string studentId { get; set; }
        public DateTime createdOn { get; set; }
        public string dateCreated { get; set; }
        public string description { get; set; }
    }


    public class StudentPaymentInfoDto
    {
        public Int64 Id { get; set; }
        public string session { get; set; }
        public string term { get; set; }
        public string currentClass { get; set; }
        public string description { get; set; }
        public decimal amount { get; set; }
        public decimal outstandingAmount { get; set; }
        public string studentId { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }

}
