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
Author Name : Sameera Mohamed
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
    /// Test suite for validating login functionality using the MyShuttle application.
    /// </summary>
    [TestFixture]
    public class LoginTest
    {
        private IWebDriver driver;
        private ILogin loginPage;

        /// <summary>
        /// Sets up the test environment by initializing the WebDriver 
        /// and navigating to the Login page URL.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://192.168.0.102:8080/myshuttledev/"); 
            loginPage = new LoginPage(driver);
        }

        /// <summary>
        /// Cleans up the test environment by quitting the WebDriver instance.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        /// <summary>
        /// Test to verify successful login with valid credentials.
        /// </summary>
        [Test]
        public void LoginWithValidCredentials()
        {
            // Arrange
            string validEmail = "fred";
            string validPassword = "fredpassword";

            // Act
            loginPage.EnterEmployeeEmail(validEmail);
            loginPage.EnterEmployeePassword(validPassword);
            loginPage.ClickLoginButton();

            // Assert
            Assert.That(loginPage.IsLoginSuccessful(), Is.True, "Login should be successful with valid credentials.");
        }

        /// <summary>
        /// Test to verify unsuccessful login with invalid credentials.
        /// </summary>
        [Test]
        public void LoginWithInvalidCredentials()
        {
            // Arrange
            string invalidEmail = "invalidUser";
            string invalidPassword = "wrongPassword";

            // Act
            loginPage.EnterEmployeeEmail(invalidEmail);
            loginPage.EnterEmployeePassword(invalidPassword);
            loginPage.ClickLoginButton();

            // Assert
            Assert.IsTrue(loginPage.IsErrorMessageDisplayed(), "Error message should be displayed for invalid credentials.");
        }

        /// <summary>
        /// Test to verify login fails with empty email and password fields.
        /// </summary>
        [Test]
        public void LoginWithEmptyFields()
        {
            // Act
            loginPage.EnterEmployeeEmail("");
            loginPage.EnterEmployeePassword("");
            loginPage.ClickLoginButton();

            // Assert
            Assert.IsTrue(loginPage.IsErrorMessageDisplayed(), "Error message should be displayed for empty email and password fields.");
        }

        /// <summary>
        /// Test to verify login fails when only the email is provided.
        /// </summary>
        [Test]
        public void LoginWithOnlyEmail()
        {
            // Arrange
            string validEmail = "fred";

            // Act
            loginPage.EnterEmployeeEmail(validEmail);
            loginPage.EnterEmployeePassword("");
            loginPage.ClickLoginButton();

            // Assert
            Assert.IsTrue(loginPage.IsErrorMessageDisplayed(), "Error message should be displayed when only email is provided.");
        }

        /// <summary>
        /// Test to verify login fails when only the password is provided.
        /// </summary>
        [Test]
        public void LoginWithOnlyPassword()
        {
            // Arrange
            string validPassword = "password123";

            // Act
            loginPage.EnterEmployeeEmail("");
            loginPage.EnterEmployeePassword(validPassword);
            loginPage.ClickLoginButton();

            // Assert
            Assert.IsTrue(loginPage.IsErrorMessageDisplayed(), "Error message should be displayed when only the password is provided.");
        }
    }
}
