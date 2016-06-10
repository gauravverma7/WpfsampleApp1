using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPFSample;
using WPFSample.Repository;
using WPFSample.User;
using WPFSample.User.ViewModel;
namespace wpfSample_Test
{
    [TestClass]
    public class testView
    {
        userViewModel objViewModel = new userViewModel();    
       [TestMethod]
        public void testRep()
        {
            WebApi owebApiObj = new WebApi();
            owebApiObj.getAllUsers();
        }
       [TestMethod]
       public void testViewModel()
       {                 
           objViewModel.allUsers();
       }
       [TestMethod]
       public void testComboUserId()
       {
           objViewModel.comboUserID();
       }
       [TestMethod]
       public void testComboUserId()
       {
           objViewModel.comboUserID();
       }


    }
}
