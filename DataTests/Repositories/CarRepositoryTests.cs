using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Tests
{
    [TestClass()]
    public class CarRepositoryTests
    {
        [TestMethod()]
        public void GetAvailableCarsTest()
        {
            CarRepository repos = new CarRepository();

            var cars = repos.GetAvailableCars();

            Assert.IsNotNull(cars);
        }

        [TestMethod()]
        public void MarkCarAsRentedTest()
        {
            CarRepository repos = new CarRepository();

            repos.MarkCarAsRented(1);

            var cars = repos.GetAvailableCars();

            Assert.IsNotNull(cars);
            Assert.IsTrue(cars.Count() == 1);

            repos.MarkCarAsReturned(1);

            cars = repos.GetAvailableCars();

            Assert.IsNotNull(cars);
            Assert.IsTrue(cars.Count() == 2);
        }
    }
}