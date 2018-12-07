using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLF.Models.Tests
{
  //  a Unit Test tests a class or multiple classes without their external dependencies they test a unit of work.
 //  an integration Test tests a class or multiple classes with their external dependencies.
 //  End-To-End Test that drives an application through its usr interface. 

    [TestClass()]
    public class ReservationTests
    {
        [TestMethod()]
        public void CanBeCancelledByTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void MethodName_Scenario_ExpectedBehavior()
        {
            // Arrange
            var resevation = new Reservation();

            //Act
            var result = resevation.CanBeCancelledBy(new User { IsAdmin = true });
            //Assert
             Assert.IsTrue(result);
        }
        [TestMethod]
        public void CanBeCancelledBy_AdminUserCancelling_ReturnTrue()
        {
            // Arrange
            var resevation = new Reservation();

            //Act
            var result = resevation.CanBeCancelledBy(new User { IsAdmin = true });
            //Assert
             Assert.IsTrue(result);
        }
        [TestMethod]
        public void CanBeCancelledBy_SameUserCancelling_ReturnTrue()
        {
            // Arrange
            var user = new User();
            var reservation = new Reservation { MadeBy = user };

            //Act
            var result = reservation.CanBeCancelledBy(user);
            //Assert
             Assert.IsTrue(result);
        }
        [TestMethod]
        public void CanBeCancelBy_AnotherUserCancelling_ReturnFails()
        {
            var reservation = new Reservation { MadeBy = new User() };
            var result = reservation.CanBeCancelledBy(new User());
            Assert.IsFalse(result);
        }
    }
}