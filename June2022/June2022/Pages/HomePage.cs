namespace June2022.Pages
{
    public class HomePage
    {
        public void GoToTMPage(IWebDriver driver)
        {
            // click on administration tab
            Thread.Sleep(1500);
            IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationTab.Click();

            // select time and material from dropdown list
            IWebElement tmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            tmOption.Click();
            Thread.Sleep(1500);
        }
    }
}
