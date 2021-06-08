using PersonnelDepartment.Data;

namespace PersonnelDepartment.Entities
{
    public static class Entity
    {
        public static Employee Employee { get; set; }
        public static Applicant Applicant { get; set; }
        public static Department Department { get; set; }
        public static User User { get; set; }
        public static Employee CurrentEmployee { get; set; }
    }
}
