using June2022.Utilities;
using NUnit.Framework;

namespace June2022.Pages
{
    public class HomePage
    {
        public void GoToTMPage(IWebDriver driver)
        {
            try
            {
                // click on administration tab
                Thread.Sleep(1500);
                IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
                administrationTab.Click();
                WaitHelpers.WaitToBeClickable(driver, 5, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a");
            }
            catch(Exception ex)
            {
                Assert.Fail("TM option not available", ex.Message);
            }


            // select time and material from dropdown list
            IWebElement tmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            tmOption.Click();
            
        }
    }
}
