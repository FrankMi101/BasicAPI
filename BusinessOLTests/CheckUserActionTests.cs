using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessOL.Tests
{
    [TestClass()]
    public class CheckUserActionTests
    {
        [TestMethod()]
        public void OpenFormAction_AnyUser_ReturnTrue()
        {  // Arrange
            var userRole = "Team"; // Principal, Superintendent, Admin
            var action = "OpenForm";
            //Act
            var result = CheckUserAction.ActionPermission(action, userRole);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod()]
        public void SchoolSignOffAction_PrincipalUser_FormComplete_ReturnTrue()
        {  // Arrange
            var userRole = "Principal"; // Principal, Superintendent, Admin
            var action = "SchoolSignOff";
            CheckUserAction.formComplete = "Complete";
            //Act
            var result = CheckUserAction.ActionPermission(action, userRole);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod()]
        public void SchoolSignOffAction_PrincipalUser_FormInComplete_ReturnFalse()
        {  // Arrange
            var userRole = "Principal"; // Principal, Superintendent, Admin
            var action = "SchoolSignOff";
            CheckUserAction.formComplete = "InComplete";
            //Act
            var result = CheckUserAction.ActionPermission(action, userRole);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void SchoolSignOffAction_OtherThanPrincipal_ReturnFalse()
        {  // Arrange
            var userRole = "SiteTeam"; //   Superintendent 
            var action = "SchoolSignOff";
            CheckUserAction.formComplete = "Complete"; // Complete
            //Act
            var result = CheckUserAction.ActionPermission(action, userRole);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void SOSignOffAction_OtherTehnSuperintendentUser_ReturnFalse()
        {  // Arrange
            var userRole = "Principal"; //   Superintendent 
            var action = "SOSignOff";
            CheckUserAction.SchoolSignedOff = "SignedOff"; // Complete
            //Act
            var result = CheckUserAction.ActionPermission(action, userRole);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void SOSignOffAction_SuperintendentUser_SchoolNotSignOffYet_ReturnFalse()
        {  // Arrange
            var userRole = "Superintendent"; //   Principal 
            var action = "SOSignOff";
            CheckUserAction.SchoolSignedOff = "Not"; // Complete
            //Act
            var result = CheckUserAction.ActionPermission(action, userRole);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void SOSignOffAction_SuperintendentUser_SchoolSignedOff_ReturnTrue()
        {  // Arrange
            var userRole = "Superintendent"; //   Principal 
            var action = "SOSignOff";
            CheckUserAction.SchoolSignedOff = "SignedOff"; // Complete
            //Act
            var result = CheckUserAction.ActionPermission(action, userRole);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod()]
        public void PublishAction_PrincipalUser_SOSignedOff_ReturnTrue()
        {  // Arrange
            var userRole = "Principal"; //   Principal 
            var action = "Publish";
            CheckUserAction.SOSignedOff = "SignedOff"; // Complete
            //Act
            var result = CheckUserAction.ActionPermission(action, userRole);
            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod()]
        public void PublishAction_PrincipalUser_SONotSignedOffYet_ReturnFalse()
        {  // Arrange
            var userRole = "Principal"; //   Principal 
            var action = "Publish";
            CheckUserAction.SOSignedOff = "Not"; // Complete
            //Act
            var result = CheckUserAction.ActionPermission(action, userRole);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void PublishAction_OtherUser_SONotSignedOffYet_ReturnFalse()
        {  // Arrange
            var userRole = "SiteTeam"; //   Principal 
            var action = "Publish";
            CheckUserAction.SOSignedOff = "SignedOff"; // Complete
            //Act
            var result = CheckUserAction.ActionPermission(action, userRole);
            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void ActionMessageTest()
        {
            Assert.Fail();
        }
    }
}