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
    public class CheckUserActionMessage
    {
        [TestMethod()]
        public void ActionMessageTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void OpenFormActionMessage_AnyUser_ReturnValue_OK()
        {  // Arrange
            var userRole = "Team"; // Principal, Superintendent, Admin
            var action = "OpenForm";
            var expected = "OK";
            //Act
            var result = CheckUserAction.ActionMessage(action, userRole);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void SchoolSignOffActionMessage_PrincipalUser_FormComplete_ReturnValue_OK()
        {  // Arrange
            var userRole = "Principal"; // Principal, Superintendent, Admin
            var action = "SchoolSignOff";
            CheckUserAction.formComplete = "Complete";
            var expected = "OK";
            //Act
            var result = CheckUserAction.ActionMessage(action, userRole);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void SchoolSignOffActionMessage_PrincipalUser_FormInComplete_ReturnValue_Warning()
        {  // Arrange
            var userRole = "Principal"; // Principal, Superintendent, Admin
            var action = "SchoolSignOff";
            var expected = "Please complete the Form, and then sign Off.";
            CheckUserAction.formComplete = "InComplete";

            //Act
            var result = CheckUserAction.ActionMessage(action, userRole);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void SchoolSignOffActionMessage_OtherThanPrincipal_ReturnValue_NoPermission()
        {  // Arrange
           // Arrange
            var userRole = "Superintendent"; // Principal, Superintendent, Admin
            var action = "SchoolSignOff";
            var expected = "Has no permission to sign off the Form!";
            CheckUserAction.formComplete = "InComplete";

            //Act
            var result = CheckUserAction.ActionMessage(action, userRole);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void SOSignOffActionMessage_OtherTehnSuperintendentUser_ReturnValue_NoPermission()
        {  // Arrange
            var userRole = "Principal"; //   Superintendent 
            var action = "SOSignOff";
            var expected = "Has no permission to sign off the Form!";
            CheckUserAction.SchoolSignedOff = "SignedOff"; // Complete
            //Act
            var result = CheckUserAction.ActionMessage(action, userRole);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void SOSignOffActionMessage_SuperintendentUser_SchoolNotSignOffYet_ReturnValue_Warning()
        {  // Arrange
            var userRole = "Superintendent"; //   Principal 
            var action = "SOSignOff";
            var expected = "Please has the school Principal signed off first!";
            CheckUserAction.SchoolSignedOff = "Not"; // Complete
            //Act
            var result = CheckUserAction.ActionMessage(action, userRole);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void SOSignOffActionMessage_SuperintendentUser_SchoolSignedOff_ReturnValue_OK()
        {  // Arrange
            var userRole = "Superintendent"; //   Principal 
            var action = "SOSignOff";
            var expected = "OK";
            CheckUserAction.SchoolSignedOff = "SignedOff"; // Complete
            //Act
            var result = CheckUserAction.ActionMessage(action, userRole);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void PublishActionMessage_PrincipalUser_SOSignedOff_ReturnValue_OK()
        {  // Arrange
            var userRole = "Principal"; //   Principal 
            var action = "Publish";
            var expected = "OK";
            CheckUserAction.SOSignedOff = "SignedOff"; // Complete
            //Act
            var result = CheckUserAction.ActionMessage(action, userRole);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void PublishActionMessage_PrincipalUser_SONotSignedOffYet_ReturnValue_Warning()
        {  // Arrange
            var userRole = "Principal"; //   Principal 
            var action = "Publish";
            var expected = "Please has your school superintendent signe off first!";
            CheckUserAction.SOSignedOff = "Not"; // Complete
            //Act
            var result = CheckUserAction.ActionMessage(action, userRole);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }
        [TestMethod()]
        public void PublishActionMessage_OtherUser_SONotSignedOffYet_ReturnValue_NoPermission()
        {  // Arrange
            var userRole = "SiteTeam"; //   Principal 
            var action = "Publish";
            var expected = "Has no permission to Publish the Form!";
            CheckUserAction.SOSignedOff = "SignedOff"; // Complete
            //Act
            var result = CheckUserAction.ActionMessage(action, userRole);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }
    }
}