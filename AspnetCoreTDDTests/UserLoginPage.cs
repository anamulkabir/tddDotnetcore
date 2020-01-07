using OpenQA.Selenium;
namespace AspnetCoreTDDTests
{
    public class UserLoginPage
    {
        private readonly IWebDriver _driver;
        private const string URI = "http://localhost:5001/";

        private IWebElement UserNameElement => _driver.FindElement(By.Id("UserCred_UserName"));
        private IWebElement PasswordElement => _driver.FindElement(By.Id("UserCred_Password"));
        // private IWebElement AccountNumberElement => _driver.FindElement(By.Id("AccountNumber"));
        private IWebElement CreateElement => _driver.FindElement(By.Name("create"));

        public string Title => _driver.Title;
        public string Source => _driver.PageSource;
        public string UserNameErrorMessage => _driver.FindElement(By.ClassName("text-danger")).Text;

        public UserLoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Navigate(string uri) => _driver.Navigate()
                .GoToUrl(URI + uri);

        public void PopulateUserName(string username) => UserNameElement.SendKeys(username);
        public void PopulatePassword(string password) => PasswordElement.SendKeys(password);
        
        public void ClickCreate() => CreateElement.Click();
    }
}