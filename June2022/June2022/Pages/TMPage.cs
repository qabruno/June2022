
namespace June2022.Pages
{
    public class TMPage
    {
        public void CreateTM(IWebDriver driver)
        {
            //  click on create new
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNewButton.Click();
            Thread.Sleep(2000);

            // input code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("June2022");

            // input description 
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("June2022");

            // making price tag interactable
            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceTag.Click();

            // input price
            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("12");

            // click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(3000);

            // go to the last page
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            // check if material record has been created successfully
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (newCode.Text == "June2022")
            {
                Console.WriteLine("New material record created successfully.");
            }
            else
            {
                Console.WriteLine("New material record hasn't been created");
            }
        }

        public void EditTM(IWebDriver driver)
        {
            // edit time and material code
        }

        public void DeleteTM(IWebDriver driver)
        {
            // delete time and material code
        }
    }
}
