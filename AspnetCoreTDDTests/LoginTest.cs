using System;
using System.IO;
using System.Reflection;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AspnetCoreTDDTests
{
    public class LoginTest : IDisposable
    {
        private  IWebDriver _webDriver;
        private UserLoginPage _userLogin;
        public LoginTest()
        {
            _webDriver = new ChromeDriver();
            _userLogin = new UserLoginPage(_webDriver);
            _userLogin.Navigate("UserCred/Create");
        }
        [Fact]
        public void Invalid_UserNamePattern_False()
        {
            _userLogin.PopulateUserName("mak123456789");
            _userLogin.PopulatePassword("12345");
            _userLogin.ClickCreate();
             Assert.Contains("Invalid User Name", _userLogin.UserNameErrorMessage);
            
        }
        public void Dispose()
        {
            _webDriver.Quit();
            _webDriver.Dispose();
        }
       
    } 
}

