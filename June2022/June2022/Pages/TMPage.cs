

using NUnit.Framework;

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

            // Assertion number 1
            Assert.That(newCode.Text == "June2022", "Actual code and expected code do not match.");

        }

        public void EditTM(IWebDriver driver)
        {
            Thread.Sleep(2000);
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            IWebElement findCodeRecordCreated = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findCodeRecordCreated.Text == "June2022")
            {
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                Thread.Sleep(1000);
                editButton.Click();
            }
            else
            {
                Assert.Fail("Record to be edited hasn't been found. Record not edited");
            }

            //click ,delete existing value and input code
            IWebElement editCodeButton = driver.FindElement(By.Id("Code"));
            
            editCodeButton.Click();
            editCodeButton.Clear();
            editCodeButton.SendKeys("Tango1");
            Thread.Sleep(2000);

            //Edit and input description
            IWebElement editDescriptionButton = driver.FindElement(By.Id("Description"));

            editDescriptionButton.Click();
            editDescriptionButton.Clear();
            editDescriptionButton.SendKeys("Charlie1");
            Thread.Sleep(2000);

            //To make price interactable
            IWebElement PriceNew = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement editPrice = driver.FindElement(By.Id("Price"));

            PriceNew.Click();
            editPrice.Clear();
            PriceNew.Click();
            editPrice.SendKeys("30");
            Thread.Sleep(2000);

            //click on save
            IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();
            Thread.Sleep(1000);

            //go to last page to see changes
            IWebElement gotoLastPageEdit = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            gotoLastPageEdit.Click();
            Thread.Sleep(3000);

            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement editedTypeCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement editedPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            Assert.That(editedCode.Text == "Tango1", "Actual code and expected code do not match.");
            Assert.That(editedTypeCode.Text == "M", "Actual typecode and expected typecode do not match.");
            Assert.That(editedDescription.Text == "Charlie1", "Actual description and expected description do not match");
            Assert.That(editedPrice.Text == "$30.00", "Actual price and expected price do not match");
           
        }

        public void DeleteTM(IWebDriver driver)
        {
            Thread.Sleep(2000);
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            IWebElement DeleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            Thread.Sleep(1500);
            DeleteButton.Click();
            Thread.Sleep(1500);

            //Click on OK
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();

            IWebElement deletedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement deletedTypeCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            IWebElement deletedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement deletedPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            Assert.That(deletedCode.Text != "Tango1", "Code record hasn't been deleted");
            Assert.That(deletedTypeCode.Text != "M", "Typecode record hasn't been deleted");
            Assert.That(deletedDescription.Text != "Charlie1", "Description record hasn't been deleted");
            Assert.That(deletedPrice.Text != "$30.00", "Price record hasn't been deleted");
        }
    }
}
