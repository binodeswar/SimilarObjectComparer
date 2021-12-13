
using SimilarObjectComparer;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestProject
{
    public class UnitTest
    {
      
        //Different Id
        [Fact]
        public void Test2()
        {
            var student1 = new Student { Name = "John", Id = 100, Marks = new[] { 80, 90, 100 } };
            var student2 = new Student { Name = "John", Id = 101, Marks = new[] { 80, 90, 100 } };
            var result = ObjectComparer.Compare(student1, student2);
            Assert.True(!result);
        }

        //Different Id
        [Fact]
        public void Test90()
        {
            var student1 = new Student { Name = "John", Id = 100, Marks = new[] { 80, 90, 100 } };
            var student2 = new Student { Name = "John", Id = 101, Marks = new[] { 80, 90, 100 } };
            var result = ObjectComparer.Compare(student1, student2);
            Assert.True(!result);
        }
        // order of Marks is different
        [Fact]
        public void Test3()
        {
            var student1 = new Student { Name = "John", Id = 100, Marks = new[] { 80, 90, 100 } };
            var student2 = new Student { Name = "John", Id = 100, Marks = new[] { 100, 90, 80 } };
            var result = ObjectComparer.Compare(student1, student2);
            Assert.True(result);
        }

        [Fact]
        public void Test4()
        {
            var student1 = new Student { Name = "John", Id = 100, Marks = new[] { 90, 100, 80 } };
            var student2 = new Student { Name = "John", Id = 100, Marks = new[] { 100, 90, 80 } };
            var result = ObjectComparer.Compare(student1, student2);
            Assert.True(result);
        }

        // property null check
        [Fact]
        public void Test5()
        {
            var student1 = new Student { Name = "John", Id = 100, Marks = new[] { 90, 100, 80 } };
            var student2 = new Student { Name = null, Id = 100, Marks = new[] { 80, 90, 100 } };
            var result = ObjectComparer.Compare(student1, student2);
            Assert.True(!result);
        }

        //logic test when elements are repeated
        [Fact]
        public void Test6()
        {
            var student1 = new Student { Name = "John", Id = 100, Marks = new[] { 10, 10, 10, 20 } };
            var student2 = new Student { Name = "John", Id = 100, Marks = new[] { 10, 20, 20, 20 } };
            var result = ObjectComparer.Compare(student1, student2);
            Assert.True(!result);
        }


        [Fact]
        public void Test7()
        {
            var student1 = new Student { Name = "John", Id = 100, Marks = new[] { 10, 10, 10, 20 } };
            var student2 = new Student { Name = "John", Id = 100, Marks = new[] { 10, 10, 10, 20 } };
            var result = ObjectComparer.Compare(student1, student2);
            Assert.True(result);
        }

        //object null check
        [Fact]
        public void Test8()
        {
            var student1 = new Student { Name = "John", Id = 100, Marks = new[] { 10, 10, 10, 20 } };
            var result = ObjectComparer.Compare(student1, null);
            Assert.True(!result);
        }

        [Fact]
        public void Test9()
        {
            Employee emp1 = new Employee
            {
                EmployeeId = 1,
                Age = 28,
                Name = "Binod",
                Department = new List<Department> {
            new Department() {
                DeptId = 1, DeptName = "IT", SubDept = new List < SubDept > {
                    new SubDept() {
                        SubDeptId = 1, SubDeptName = "DotNet"
                    },
                    new SubDept() {
                        SubDeptId = 2, SubDeptName = "WebAPI"
                    }
                }
            },
            new Department() {
                DeptId = 2, DeptName = "HR", SubDept = new List < SubDept > {
                    new SubDept() {
                        SubDeptId = 3, SubDeptName = "Marketing"
                    },
                    new SubDept() {
                        SubDeptId = 4, SubDeptName = "Sales"
                    }
                }
            }
        }
            };
            Employee emp2 = new Employee
            {
                EmployeeId = 2,
                Age = 26,
                Name = "Rahul",
                Department = new List<Department> {
            new Department() {
                DeptId = 3, DeptName = "Admin", SubDept = new List < SubDept > {
                    new SubDept() {
                        SubDeptId = 1, SubDeptName = "A"
                    },
                    new SubDept() {
                        SubDeptId = 2, SubDeptName = "B"
                    }
                }
            },
            new Department {
                DeptId = 4, DeptName = "IT", SubDept = new List < SubDept > {
                    new SubDept() {
                        SubDeptId = 1, SubDeptName = "A"
                    },
                    new SubDept() {
                        SubDeptId = 2, SubDeptName = "B"
                    }
                }
            }
        }
            };

            var result = ObjectComparer.Compare(emp1, emp2);
            Assert.True(!result);
        }



        [Fact]
        public void Test10()
        {
            var datetime = DateTime.Now;
            Employee emp1 = new Employee
            {
                EmployeeId = 1,
                Age = 28,
                Name = "Binod",
                Department = new List<Department> {
            new Department() {
                DeptId = 1, DeptName = "IT", SubDept = new List < SubDept > {
                    new SubDept() {
                        SubDeptId = 1, SubDeptName = "DotNet"
                    },
                    new SubDept() {
                        SubDeptId = 2, SubDeptName = "WebAPI"
                    }
                }
            },
            new Department() {
                DeptId = 2, DeptName = "HR", SubDept = new List < SubDept > {
                    new SubDept() {
                        SubDeptId = 3, SubDeptName = "Marketing"
                    },
                    new SubDept() {
                        SubDeptId = 4, SubDeptName = "Sales"
                    }
                }
            }
        }
            };
            Employee emp4 = new Employee
            {
                EmployeeId = 1,
                Age = 28,
                Name = "Binod",
                Department = new List<Department> {
            new Department() {
                DeptId = 1, DeptName = "IT", SubDept = new List < SubDept > {
                    new SubDept() {
                        SubDeptId = 1, SubDeptName = "DotNet"
                    },
                    new SubDept() {
                        SubDeptId = 2, SubDeptName = "WebAPI"
                    }
                }
            },
            new Department() {
                DeptId = 2, DeptName = "HR", SubDept = new List < SubDept > {
                    new SubDept() {
                        SubDeptId = 3, SubDeptName = "Marketing"
                    },
                    new SubDept() {
                        SubDeptId = 4, SubDeptName = "Sales"
                    }
                }
            }
        }
            };

            var result = ObjectComparer.Compare(emp1, emp4);
            Assert.True(result);
        }



    }
}
