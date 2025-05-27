
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

public class HomePage
{
    private readonly IWebDriver driver;
     public HomePage(IWebDriver driver)
    {
        this.driver = driver;
    }

    // [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Manger Id')")]
    // private IWebElement managerId;
    private IWebElement managerId => driver.FindElement(By.XPath("//td[contains(text(),'Manger Id')]"));
   

    public bool isSuccessfulLogin()
    {
        return managerId.Displayed;
    }
    

}