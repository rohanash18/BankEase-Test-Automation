
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
public class NewAccountPage
{
    private readonly IWebDriver driver;
    public NewAccountPage(IWebDriver driver)
    {
        this.driver = driver;
    }
    //locators

    private IWebElement NewAccount => driver.FindElement(By.LinkText("New Account"));
    private IWebElement CustomerId => driver.FindElement(By.Name("cusid"));
    private IWebElement DropDownAcc => driver.FindElement(By.Name("selaccount"));
    private IWebElement IniDeposit => driver.FindElement(By.Name("inideposit"));

    private IWebElement SubmitButton => driver.FindElement(By.Name("button2"));
    private IWebElement SuccessMessage => driver.FindElement(By.XPath("//p[@class='heading3']"));
    private IWebElement AccountID => driver.FindElement(By.XPath("//td[text()='Account ID']/following-sibling::td"));
    public void NavigateToNewAccount()
    {
        NewAccount.Click();
    }
    public void FillNewAccForm(string customerId , string AccType , string initialDeposit)
    {
        CustomerId.SendKeys(customerId);
        
        var s = new SelectElement(DropDownAcc);
        s.SelectByValue(AccType);
        IniDeposit.SendKeys(initialDeposit);
        SubmitButton.Click();
    }
    public Boolean ValidateSuccessfulRegistration()
    {
        return SuccessMessage.Displayed;
    }
    public string FetchAccId()
    {
        return AccountID.Text;
    }
}