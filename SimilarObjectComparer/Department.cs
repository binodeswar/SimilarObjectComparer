using System.Collections.Generic;

namespace SimilarObjectComparer
{
    public class Department
    {
        public int DeptId
        {
            get;
            set;
        }
        public string DeptName
        {
            get;
            set;
        }
        public List<SubDept> SubDept
        {
            get;
            set;
        }
    }
    public class SubDept
    {
        public int SubDeptId
        {
            get;
            set;
        }
        public string SubDeptName
        {
            get;
            set;
        }
    }
}
