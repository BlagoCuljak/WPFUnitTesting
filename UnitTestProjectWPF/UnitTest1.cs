using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace UnitTestProjectWPF
{
    public class MainDemoSession
    {
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string ApplicationPath = @"C:\Users\blago.culjak\source\repos\WPFUnitTesting\WPFUnitTesting\bin\Debug\WPFUnitTesting.exe";

        protected static WindowsDriver<WindowsElement> desktopSession;

        public static void Setup(TestContext context)
        {
            // Launch a new instance of the tested application
            if (desktopSession == null)
            {
                // Create a new session to launch the tested application

                AppiumOptions options = new AppiumOptions();
                options.AddAdditionalCapability("app", ApplicationPath);
                desktopSession = new WindowsDriver<WindowsElement>(
                    new Uri(WindowsApplicationDriverUrl), options);
                Assert.IsNotNull(desktopSession);
                Assert.IsNotNull(desktopSession.SessionId);

                // Set implicit timeout to 1.5 seconds
                //to make element search to retry every 500 ms
                //for at most three times
                desktopSession.Manage().Timeouts().ImplicitWait =
                    TimeSpan.FromSeconds(1.5);
            }
        }

        public static void TearDown()
        {
            // Close the application and delete the session
            if (desktopSession != null)
            {
                desktopSession.Close();
                desktopSession.Quit();
                desktopSession = null;
            }
        }
    }

    public static class Helper
    {
        public static WindowsElement FindElementByAbsoluteXPath(
            this WindowsDriver<WindowsElement> desktopSession,
            string xPath,
            int nTryCount = 3)
        {
            WindowsElement uiTarget = null;
            while (nTryCount-- > 0)
            {
                try
                {
                    uiTarget = desktopSession.FindElementByXPath(xPath);
                }
                catch
                {
                }
                if (uiTarget != null)
                {
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(400);
                }
            }
            return uiTarget;
        }
    }
    [TestClass]
    public class UnitTest1 : MainDemoSession
    {
        [TestMethod]
        public void TestMethod1()
        {
            //test start
            // LeftClick on Button "OPEN 2nd Window" at (77,73)
            Console.WriteLine("LeftClick on Button \"OPEN 2nd Window\" at (77,73)");
            string xpath_LeftClickButtonOPEN2ndWin_77_73 = "/Window[@ClassName=\"Window\"][@Name=\"MainWindow\"]/Button[@Name=\"OPEN 2nd Window\"][@AutomationId=\"Open\"]";
            var winElem_LeftClickButtonOPEN2ndWin_77_73 = desktopSession.FindElementByAbsoluteXPath(xpath_LeftClickButtonOPEN2ndWin_77_73);
            if (winElem_LeftClickButtonOPEN2ndWin_77_73 != null)
            {
                winElem_LeftClickButtonOPEN2ndWin_77_73.Click();
            }
            else
            {
                Assert.Fail($"Failed to find element using xpath: {xpath_LeftClickButtonOPEN2ndWin_77_73}");
                return;
            }


            // LeftClick on Button "OPEN 3nd Window" at (75,65)
            Console.WriteLine("LeftClick on Button \"OPEN 3nd Window\" at (75,65)");
            string xpath_LeftClickButtonOPEN3ndWin_75_65 = "/Window[@ClassName=\"Window\"]/Custom[@ClassName=\"_2ndWindow\"]/Button[@Name=\"OPEN 3nd Window\"][@AutomationId=\"Open\"]";
            var winElem_LeftClickButtonOPEN3ndWin_75_65 = desktopSession.FindElementByAbsoluteXPath(xpath_LeftClickButtonOPEN3ndWin_75_65);
            if (winElem_LeftClickButtonOPEN3ndWin_75_65 != null)
            {
                winElem_LeftClickButtonOPEN3ndWin_75_65.Click();
            }
            else
            {
                Assert.Fail($"Failed to find element using xpath: {xpath_LeftClickButtonOPEN3ndWin_75_65}");
                return;
            }


            // LeftClick on Edit "" at (92,15)
            Console.WriteLine("LeftClick on Edit \"\" at (92,15)");
            string xpath_LeftClickEdit_92_15 = "/Window[@ClassName=\"Window\"]/Custom[@ClassName=\"_3rdWindow\"]/Edit[@AutomationId=\"MyTextBox\"]";
            var winElem_LeftClickEdit_92_15 = desktopSession.FindElementByAbsoluteXPath(xpath_LeftClickEdit_92_15);
            if (winElem_LeftClickEdit_92_15 != null)
            {
                winElem_LeftClickEdit_92_15.Click();
            }
            else
            {
                Assert.Fail($"Failed to find element using xpath: {xpath_LeftClickEdit_92_15}");
                return;
            }


            // KeyboardInput VirtualKeys=""test"" CapsLock=False NumLock=True ScrollLock=False
            Console.WriteLine("KeyboardInput VirtualKeys=\"\"test\"\" CapsLock=False NumLock=True ScrollLock=False");
            System.Threading.Thread.Sleep(100);
            winElem_LeftClickEdit_92_15.SendKeys("test");




            //test finish
        }
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Setup(context);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TearDown();
        }
    }
}

