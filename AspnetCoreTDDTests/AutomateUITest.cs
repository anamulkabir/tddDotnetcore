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
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--no-sandbox"); 
            chromeOptions.AddArguments("--disable-setuid-sandbox");
            chromeOptions.AddArguments("--remote-debugging-port=9222");
            chromeOptions.AddArguments("--disable-dev-shm-using"); 
            chromeOptions.AddArguments("--disable-extensions"); 
            chromeOptions.AddArguments("--disable-gpu"); 
            chromeOptions.AddArguments("start-maximized"); 
            chromeOptions.AddArguments("disable-infobars"); 
            chromeOptions.AddArguments("--headless") ;
            _driver = new ChromeDriver(chromeOptions);
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
