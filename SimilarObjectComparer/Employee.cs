using System.Collections.Generic;

namespace SimilarObjectComparer
{
    public class Employee
    {
        public int EmployeeId
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }

        public List<Department> Department
        {
            get;
            set;
        }
    }
}
