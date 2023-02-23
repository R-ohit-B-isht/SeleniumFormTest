using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ConsoleApp1
{
    class SeleniumGetTest
    {
        public static void TestText(IWebDriver driver, string element, string elementType , string testField)
        {
            IWebElement text;
            string textfieldvalue = "";
            bool testPassed = true;
            if (elementType == "Id")
            {
                text = driver.FindElement(By.Id(element));
                textfieldvalue = text.GetAttribute("value");
            }
            

            if (elementType == "Name") 
            {
                text = driver.FindElement(By.Name(element));
                textfieldvalue = text.GetAttribute("value");
            }


            if (textfieldvalue == "")
                testPassed = false;
            
            Console.WriteLine($"{testField} field test result: {(testPassed ? "PASS" : "FAIL")}");
        }
        public static void DropDownTest(IWebDriver driver, string element, string elementType, string testField)
        {
            SelectElement select;
            string selectedfieldvalue = "";
            bool testPassed = true;


            if (elementType == "Id")
            {
               select= new SelectElement(driver.FindElement(By.Id(element)));
                selectedfieldvalue=select.SelectedOption.Text;
            }
            if (elementType == "Name")
            {
                select=new SelectElement(driver.FindElement(By.Name(element)));
                selectedfieldvalue = select.SelectedOption.Text;
            }
            if (selectedfieldvalue == "-- Select Country --")
                testPassed = false;

            Console.WriteLine($"{testField} field test result: {(testPassed ? "PASS" : "FAIL")}");
        }

        public static void RadioBoxTest(IWebDriver driver, string elementType, string testField)
        {
            IWebElement radio;
            bool testPassed = false;

            string[] elements = { "male", "female", "transgender" };

            foreach (string element in elements) {
                if (elementType == "Id")
                {
                    radio = driver.FindElement(By.Id(element));
                    if (radio.Selected)
                        testPassed = true;
                }


                if (elementType == "Name")
                {
                    radio = driver.FindElement(By.Name(element));
                    if (radio.Selected)
                        testPassed = true;
                }


            }



            Console.WriteLine($"{testField} field test result: {(testPassed ? "PASS" : "FAIL")}");
        }
    }
}
