
// open chrome browser
IWebDriver driver = new ChromeDriver();

// Login page object initialization and definition
LoginPage loginPageObj = new LoginPage();
loginPageObj.LoginActions(driver);

// Home page object initialization and definition
HomePage homePageObj = new HomePage();
homePageObj.GoToTMPage(driver);

// TM page object initialization and definition
TMPage tmPageObj = new TMPage();
tmPageObj.CreateTM(driver);

// Edit TM
tmPageObj.EditTM(driver);

// Delete TM
tmPageObj.DeleteTM(driver);


