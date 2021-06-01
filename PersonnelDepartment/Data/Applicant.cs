//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersonnelDepartment.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Applicant
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int IdAddress { get; set; }
        public string SNILS { get; set; }
        public string INN { get; set; }
        public byte[] Photo { get; set; }
        public string Education { get; set; }
        public bool MilitaryId { get; set; }
        public int IdGender { get; set; }
        public string MedicalСertificate { get; set; }
        public int IdPosition { get; set; }
        public byte[] CertificateOfGoodConduct { get; set; }
        public byte[] NarcologicalCertificate { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
    
        public virtual Address Address { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual Position Position { get; set; }
    }
}
