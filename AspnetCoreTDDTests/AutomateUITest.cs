using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AspnetCoreTDDTests
{
    public class AutomateUITest : IDisposable
    {
        private readonly IWebDriver _driver;
         public AutomateUITest()
        {
            _driver = new ChromeDriver();
        }
        [Fact]
       public void Get_WhenExecuted_ReturnsIndexView()
       {
           _driver.Navigate()
        .GoToUrl("https://localhost:5001");
        // Assert.Equal("Home page", _driver.Title);
        Assert.Contains("building Web apps with ASP.NET Core", _driver.PageSource);
       }
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
    
}
