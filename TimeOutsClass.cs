using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumProject.BaseHelper
{
   public class TimeOutsClass
    {
        private static IWebDriver driver;
        public TimeOutsClass(IWebDriver driver)
        {
            TimeOutsClass.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //Select dropdown by Index
        public static void SelectDropdownByIndex(IWebElement We, int Index)
        {
            SelectElement select = new SelectElement(We);
            select.SelectByIndex(1);
        }

        //Select dropdown by Text
        public static void SelectDropdownByText(IWebElement We, String VisibleText)
        {
            SelectElement select = new SelectElement(We);
            select.SelectByText(VisibleText);
        }

        //Select dropdown by Value
        public static void SelectDropdownByValue(IWebElement We, String Value)
        {
            SelectElement select = new SelectElement(We);
            select.SelectByText(Value);
        }

        //Implicit wait
        public static void ImplicitWait(int time)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);
        }

        public static void ExplicitWait(By Locator, int Time, String ExpectedCondition, IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Time));

            switch (ExpectedCondition)
            {
                case "ElementToBeClickable":
                    wait.Until(ExpectedConditions.ElementToBeClickable(driver.FindElement(Locator)));
                    break;
                case "ElementExists":
                    wait.Until(ExpectedConditions.ElementExists(Locator));
                    break;
                case "ElementToBeSelected":
                    wait.Until(ExpectedConditions.ElementToBeSelected(Locator));
                    break;
                case "InvisibilityOfElementLocated":
                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(Locator));
                    break;
                case "ElementIsVisible":
                    wait.Until(ExpectedConditions.ElementIsVisible(Locator));
                    break;
            }
        }
    }
}
