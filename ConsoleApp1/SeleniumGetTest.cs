using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            
            Console.WriteLine($"Non-empty {testField} field test result: {(testPassed ? "PASS" : "FAIL")}");
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

            Console.WriteLine($"Non-empty {testField} field test result: {(testPassed ? "PASS" : "FAIL")}");
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
            Console.WriteLine($"Non-empty {testField} field test result: {(testPassed ? "PASS" : "FAIL")}");
        }

        public static bool IsValidEmail(string email)
        {
            // Use regular expression to validate email address format
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        public static bool IsValidMobileNumber(string mobile)
        {
            // Use regular expression to validate mobile number format
            string pattern = @"^\d{10}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(mobile);
        }
        public static bool ValidateDOB(string dob)
        {
            Regex regex = new Regex(@"^(19|20)\d{2}-(0[1-9]|1[0-2])-([0-2][1-9]|[1-3][0-1])$");
            return regex.IsMatch(dob);
        }

    }
}
