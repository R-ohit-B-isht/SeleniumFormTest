using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ConsoleApp1
{
	class Program
	{
		//create reference to web browser
		IWebDriver driver = new ChromeDriver("C:/Users/rbtun/Downloads/ch");

		//static void Main(string[] args)
		//{
			//Console.WriteLine("start!");
			
		//}

		[SetUp]
		public void Initialize()
		{
			//navigate to web page
			driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

		}
		
		
		[TearDown]
		public void CleanUp()
		{
			//driver.Close();
		}
		//html id/name dependent test cases
		[Test]
		public void FillForm()
		{
			//first name
			seleniumTest.EnterText(driver, "fname", "Rohit", "Id");
			SeleniumGetTest.TestText(driver, "fname", "Id","First Name");
			//Last name
			seleniumTest.EnterText(driver, "lname", "Bisht", "Id");
			SeleniumGetTest.TestText(driver, "lname",  "Id","Last Name");
			//DOB
			seleniumTest.EnterText(driver, "dob", "1997-11-02", "Id");
			SeleniumGetTest.TestText(driver, "dob", "Id","D-O-B");

			//gender
			seleniumTest.Click(driver, "male", "Id");
			SeleniumGetTest.RadioBoxTest(driver, "Id", "Gender");

			//mobile number
			seleniumTest.EnterText(driver, "mobile", "9027652516", "Id");
			SeleniumGetTest.TestText(driver, "mobile", "Id", "Moblie Number");

			//email
			seleniumTest.EnterText(driver, "email", "rbtunes02@gmail.com", "Id");
			SeleniumGetTest.TestText(driver, "email", "Id", "Email Address");

			//state
			seleniumTest.DropDown(driver, "state", "India", "Id");
			SeleniumGetTest.DropDownTest(driver, "state", "Id", "State");

		}
		//html id/name independent test cases
		[Test]
		public void SelectorTest() 
		{


			string[] selectors = { "input[name='First Name']", "textarea[name='About']", "select[name='State']" };
			string[] values = { "Rohit", "Sunny", "India" };
			int i = 0;
			foreach (string selector in selectors)
			{
				IWebElement element = driver.FindElement(By.CssSelector(selector));

				element.SendKeys(values[i]);
				

				string actualValue = element.GetAttribute("value");
				if (actualValue == values[i])
				{
					Console.WriteLine("Test passed for element with selector: " + selector);
				}
				else
				{
					Console.WriteLine("Test failed for element with selector: " + selector);
				}
				i++;
			}
		}

		[Test]
		public void FirstNameTest()
		{
			//put a vlaue in First Name
			seleniumTest.EnterText(driver, "fname", "Rohit", "Id");

			IWebElement firstNameField = driver.FindElement(By.CssSelector("label[for='fname'] + input[type='text']"));

			// Define the expected value for the field
			string expectedValue = "Rohit";

			// Retrieve the actual value of the field
			string actualValue = firstNameField.GetAttribute("value");

			// Compare actual and expected values
			bool testPassed = actualValue == expectedValue;

			// Report test result
			Console.WriteLine($"First Name field test result: {(testPassed ? "PASS" : "FAIL")}");

		}
		[Test]
		public void LastNameTest()
		{

			seleniumTest.EnterText(driver, "lname", "Bisht", "Id");
			// Find the "First Name" field using a selector based on the label text
			IWebElement lastNameLabel = driver.FindElement(By.XPath("//label[text()='Last Name']"));
			IWebElement lastNameField = lastNameLabel.FindElement(By.XPath("./following-sibling::input"));

			// Define the expected value for the field
			string expectedValue = "Bisht";

			// Retrieve the actual value of the field
			string actualValue = lastNameField.GetAttribute("value");

			// Compare actual and expected values
			bool testPassed = actualValue == expectedValue;

			// Report test result
			Console.WriteLine($"Last Name field test result: {(testPassed ? "PASS" : "FAIL")}");

		}
		[Test]
		public void TestGender()
		{  
			// Find the male radio button element
			IWebElement maleRadioButton = driver.FindElement(By.XPath("//input[@type='radio' and @name='gender' and @value='Male']"));

			// Select the male radio button if it is not already selected
			if (!maleRadioButton.Selected)
			{
				maleRadioButton.Click();
			}

			Console.WriteLine($"Gender field test result: {(maleRadioButton.Selected ? "PASS" : "FAIL")}");
		}
		[Test]
		public void TestState() 
		{
			IWebElement dropDownMenu = driver.FindElement(By.CssSelector("select[name='State']"));
			SelectElement select = new SelectElement(dropDownMenu);
			select.SelectByText("India");

			// Verify that "green" is selected in the drop-down menu
			IWebElement selectedOption = select.SelectedOption;

			bool testPassed = "India" == selectedOption.Text;
			Console.WriteLine($"State field test result: {(testPassed ? "PASS" : "FAIL")}");

		}


	}


}
