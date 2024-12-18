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
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace MyShuttleWebdriverAdapter
{
    /// <summary>
    /// Represents the Page Object Model for interacting with the Dashboard page of the MyShuttle application.
    /// Implements the IDashboard interface to provide methods for dashboard-related functionality.
    /// </summary>
    public class DashboardPage : IDashboard
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        // Locators for Dashboard elements
        private readonly By dashboardTitle = By.XPath("/html/body/div/section/div/div[1]/h2");
        private readonly By fareHistoryLink = By.LinkText("Access Your Fare History");
        private readonly By signOutLink = By.LinkText("Sign Out");

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardPage"/> class.
        /// </summary>
        /// <param name="driver">The WebDriver instance used to interact with the page.</param>
        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Wait up to 10 seconds for elements
        }

        /// <summary>
        /// Verifies if the dashboard title is displayed on the page.
        /// </summary>
        /// <returns>True if the dashboard title is displayed, otherwise false.</returns>
        public bool IsDashboardDisplayed()
        {
            try
            {
                // Wait for the dashboard title element to be visible
                wait.Until(ExpectedConditions.ElementIsVisible(dashboardTitle));
                return driver.FindElement(dashboardTitle).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Clicks the link to access the Fare History page.
        /// </summary>
        public void ClickAccessFareHistory()
        {
            // Wait for the Fare History link to be clickable and click it
            wait.Until(ExpectedConditions.ElementToBeClickable(fareHistoryLink));
            driver.FindElement(fareHistoryLink).Click();
        }

        /// <summary>
        /// Clicks the Sign Out link to log out of the application.
        /// </summary>
        public void ClickSignOut()
        {
            // Wait for the Sign Out link to be clickable and click it
            wait.Until(ExpectedConditions.ElementToBeClickable(signOutLink));
            driver.FindElement(signOutLink).Click();
        }
    }
}
