/*
Licensed to the Software Freedom Conservancy (SFC) under one
or more contributor license agreements. See the NOTICE file
distributed with this work for additional information
regarding copyright ownership. The SFC licenses this file
to you under the Apache License, Version 2.0 (the
"License"); you may not use this file except in compliance
with the License. You may obtain a copy of the License at

 http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing,
software distributed under the License is distributed on an
"AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
KIND, either express or implied. See the License for the
specific language governing permissions and limitations
under the License.
Author Name : Rajkiran
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShuttleInterfaces;
using MyShuttleWebdriverAdapter;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace MyShuttleTestt
{
    /// <summary>
    /// Test suite for validating the functionality and presence of elements on the Dashboard page.
    /// </summary>
    [TestFixture]
    public class DashboardTest
    {
        private IWebDriver driver;
        private IDashboard dashboardPage;

        /// <summary>
        /// Initializes the WebDriver and logs into the application before tests run.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            // Initialize ChromeDriver
            driver = new ChromeDriver();

            // Maximize browser window
            driver.Manage().Window.Maximize();

            // Navigate to the login page
            driver.Navigate().GoToUrl("http://192.168.0.102:8080/myshuttledev/");

            // Perform login and initialize the DashboardPage
            PerformLogin("fred", "fredpassword");

            // Initialize DashboardPage
            dashboardPage = new DashboardPage(driver);
        }

        /// <summary>
        /// Performs login to access the Dashboard page.
        /// </summary>
        /// <param name="email">Valid user email</param>
        /// <param name="password">Valid user password</param>
        private void PerformLogin(string email, string password)
        {
            // Locators for login fields
            By emailField = By.Name("email");
            By passwordField = By.Name("password");
            By loginButton = By.XPath("/html/body/div/section/div/div/div[2]/form/div[2]/input");

            // Enter email
            driver.FindElement(emailField).Clear();
            driver.FindElement(emailField).SendKeys(email);

            // Enter password
            driver.FindElement(passwordField).Clear();
            driver.FindElement(passwordField).SendKeys(password);

            // Click login button
            driver.FindElement(loginButton).Click();

        }

        /// <summary>
        /// Test to verify that the Dashboard page is displayed successfully.
        /// </summary>
        [Test]
        public void VerifyDashboardIsDisplayed()
        {
            // Act
            bool isDisplayed = dashboardPage.IsDashboardDisplayed();

            // Assert
            Assert.That(isDisplayed, Is.True, "The Dashboard page should be displayed after login.");
        }

        /// <summary>
        /// Test to verify that clicking "Access Your Fare History" navigates to the correct page.
        /// </summary>
        [Test]
        public void VerifyAccessFareHistory()
        {
            // Act
            dashboardPage.ClickAccessFareHistory();

            // Assert: Verify URL or Page Title
            string expectedUrl = "http://192.168.0.102:8080/myshuttledev/home.jsp";
            Assert.That(driver.Url, Is.EqualTo(expectedUrl), "Clicking 'Access Your Fare History' should navigate to the fare history page.");
        }

        /// <summary>
        /// Test to verify that clicking "Sign Out" logs out the user and navigates back to the login page.
        /// </summary>
        [Test]
        public void VerifySignOut()
        {
            // Act
            dashboardPage.ClickSignOut();

            // Assert: Verify redirection to login page
            string expectedUrlPart = "/login";
            bool isRedirectedToLoginPage = driver.Url.Contains(expectedUrlPart);

            // Assert with more descriptive message in case of failure
            Assert.That(isRedirectedToLoginPage, Is.True, "Logout is not implemented properly. The user was not redirected to the login page after signing out.");
        }

        /// <summary>
        /// Cleans up resources by quitting the WebDriver after each test.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
