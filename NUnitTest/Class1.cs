using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidley.DAL;
using Vidley.Models;

namespace NUnitTest
{
    [TestFixture]
    public class CheckDepartmentTest
    {
        [Test]
        public void CheckEmployeeExist()

        {
            using (var unitOfWork = new UnitOfWork(new ApplicationDbContext()))
            {
                var employee = unitOfWork.employeeGenericRepository.GetModelById(5);
                Assert.IsNotNull(employee.Id, "not found");
            }


        }
    }
}
