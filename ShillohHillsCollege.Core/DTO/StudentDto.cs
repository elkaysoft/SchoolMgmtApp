using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShillohHillsCollege.Core.DTO
{
    public class GetStudentDto
    {
        public Int64 Id { get; set; }
        public string RegistrationNo { get; set; }
        public string FullName { get; set; }
        public string DoB { get; set; }
        public string Gender { get; set; }
        public string CurrentClass { get; set; }
        public string ParentName { get; set; }
        public string ParentMobile { get; set; }
        public decimal OutstandingBalance { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string RegistrationDate { get; set; }

    }

    public class AddStudentDto
    {
        public Int64 Id { get; set; }
        public string RegistrationNo { get; set; }
        public string FullName { get; set; }
        public string DoB { get; set; }
        public string Gender { get; set; }
        public string CurrentClass { get; set; }
        public string ParentName { get; set; }
        public string ParentMobile { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }

    }

    public class StudentClassDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SubmittedBy { get; set; }
        public DateTime SubmittedOn { get; set; }
    }

    public class AddStudentClassDto
    {
        public string Name { get; set; }
        public string SubmittedBy { get; set; }
    }



}
