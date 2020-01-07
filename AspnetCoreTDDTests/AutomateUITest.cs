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
            // chromeOptions.AddArguments("--whitelist-ip *");
            // chromeOptions.AddArguments("--proxy-server='direct://'");
            // chromeOptions.AddArguments("--proxy-bypass-list=*");
            chromeOptions.AddArguments("--no-sandbox");
            // options.addArgument("--no-sandbox");
            // options.addArgument("--disable-dev-shm-usage");
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
