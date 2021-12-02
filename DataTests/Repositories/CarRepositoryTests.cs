using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

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

        [TestMethod]
        public void ShouldMarkCarAsReturned()
        {
            //CarRepository repos = new CarRepository();

            CarRepository mock = Mock.Of<CarRepository>(r => r.MarkCarAsReturned(2) == true);

            CarController ctrl = new(mock);

            var test = ctrl.ReturnCar(2);

            Assert.IsTrue(test);
        }
    }
}