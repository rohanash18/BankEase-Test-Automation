using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

public class LoginPage
{
    private readonly IWebDriver driver;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
    }
  /*  private readonly IWebDriver driver;
    [FindsBy(How = How.Name, Using = "uid")]
    private IWebElement user_name_field;
    [FindsBy(How = How.Name, Using = "password")]
    private IWebElement password_field;
    [FindsBy(How = How.Name, Using = "btnLogin")]
    private IWebElement login_button;*/
    
        private IWebElement user_name_field => driver.FindElement(By.Name("uid"));
        private IWebElement password_field => driver.FindElement(By.Name("password"));
        private IWebElement login_button => driver.FindElement(By.Name("btnLogin"));

    
    public void EnterUserName(string username)
    {
        user_name_field.Clear();
        user_name_field.SendKeys(username);
    }
    public void EnterPassword(string password)
    {
        password_field.Clear();
        password_field.SendKeys(password);
    }
    public void ClickLogin()
    {
        login_button.Click();
    }
    public void LoginAs(string username, string password)
    {
        EnterUserName(username);
        EnterPassword(password);
        ClickLogin();
    }
}