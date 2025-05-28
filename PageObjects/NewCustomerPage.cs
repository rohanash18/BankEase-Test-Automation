using OpenQA.Selenium;

public class NewCustomerPage
{
    private readonly IWebDriver driver;

    public NewCustomerPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    // Locators
    private IWebElement newCustomer => driver.FindElement(By.LinkText("New Customer"));
    private IWebElement CustomerName => driver.FindElement(By.Name("name"));
    private IWebElement GenderMale => driver.FindElement(By.XPath("//input[@value='m']"));
    private IWebElement GenderFemale => driver.FindElement(By.XPath("//input[@value='f']"));
    private IWebElement DateOfBirth => driver.FindElement(By.Id("dob"));
    private IWebElement Address => driver.FindElement(By.Name("addr"));
    private IWebElement City => driver.FindElement(By.Name("city"));
    private IWebElement State => driver.FindElement(By.Name("state"));
    private IWebElement Pin => driver.FindElement(By.Name("pinno"));
    private IWebElement MobileNumber => driver.FindElement(By.Name("telephoneno"));
    private IWebElement Email => driver.FindElement(By.Name("emailid"));
    private IWebElement Password => driver.FindElement(By.Name("password"));
    private IWebElement SubmitButton => driver.FindElement(By.Name("sub"));
    private IWebElement successMessage => driver.FindElement(By.XPath("//p[text()='Customer Registered Successfully!!!']"));

    private IWebElement customerID => driver.FindElement(By.XPath("//td[text()='Customer ID']/following-sibling::td"));
    public void NavigateToNewCustomer()
    {
        newCustomer.Click();
    }

    // Fill form
    public void FillCustomerForm(string name, string gender, string dob, string address, string city, string state, string pin, string mobile, string email, string password)
    {
        CustomerName.SendKeys(name);

        if (gender.ToLower() == "male")
            GenderMale.Click();
        else
            GenderFemale.Click();

        DateOfBirth.SendKeys(dob);
        Address.SendKeys(address);
        City.SendKeys(city);
        State.SendKeys(state);
        Pin.SendKeys(pin);
        MobileNumber.SendKeys(mobile);
        Email.SendKeys(email);
        Password.SendKeys(password);
    }

    // Submit form
    public void SubmitForm()
    {
        SubmitButton.Click();
    }

    public Boolean validateSuccessfulRegistration()
    {
        return successMessage.Displayed;
    }
    public string fetchCustomerId()
    {
        return customerID.Text;
    }
}
