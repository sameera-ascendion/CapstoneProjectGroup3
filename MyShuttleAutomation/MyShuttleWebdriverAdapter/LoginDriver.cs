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
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium;
using MyShuttleInterfaces;
using OpenQA.Selenium.Support.UI;

namespace MyShuttleWebdriverAdapter
{
    /// <summary>
    /// Represents a Page Object Model for interacting with the Login Page of the MyShuttle application.
    /// Implements the ILoginPage interface to provide methods for login functionality.
    /// </summary>
    public class LoginPage : ILogin
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        // Locators for the Login Page elements
        private readonly By emailField = By.Name("email");
        private readonly By passwordField = By.Name("password");
        private readonly By loginButton = By.XPath("/html/body/div/section/div/div/div[2]/form/div[2]/input");
        private readonly By errorMessage = By.ClassName("jumbotron");
        private readonly By dashboardElement = By.XPath("/html/body/div/section/div/div[1]/h2");


        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
        /// <param name="driver">The WebDriver instance used to interact with the page.</param>
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Explicit wait for up to 10 seconds
        }

        /// <summary>
        /// Enters the employee email into the email input field.
        /// </summary>
        /// <param name="email">The email to enter.</param>
        public void EnterEmployeeEmail(string email)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(emailField));
            driver.FindElement(emailField).Clear();
            driver.FindElement(emailField).SendKeys(email);
        }

        /// <summary>
        /// Enters the employee password into the password input field.
        /// </summary>
        /// <param name="password">The password to enter.</param>
        public void EnterEmployeePassword(string password)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(passwordField));
            driver.FindElement(passwordField).Clear();
            driver.FindElement(passwordField).SendKeys(password);
        }

        /// <summary>
        /// Clicks on the "Log In" button to submit the login form and waits for navigation.
        /// </summary>
        public void ClickLoginButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(loginButton));
            driver.FindElement(loginButton).Click();

            // Wait for the URL to change and a key element on the redirected page
            wait.Until(ExpectedConditions.UrlContains("/myshuttledev/login"));
        }

        /// <summary>
        /// Verifies if an error message is displayed after a failed login attempt.
        /// </summary>
        /// <returns>True if an error message is displayed, otherwise false.</returns>
        public bool IsErrorMessageDisplayed()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(errorMessage));
                return driver.FindElement(errorMessage).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Verifies if the login was successful by checking for a specific element or URL.
        /// </summary>
        /// <returns>True if the login was successful, otherwise false.</returns>
        public bool IsLoginSuccessful()
        {
            try
            {
                // Wait for a dashboard-specific element to load after successful login
                wait.Until(ExpectedConditions.ElementIsVisible(dashboardElement));
                return driver.FindElement(dashboardElement).Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
