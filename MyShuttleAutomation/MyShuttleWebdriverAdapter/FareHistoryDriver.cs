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
Author Name : Samson Karre
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
    /// Represents the Fare History page and provides methods to interact with and validate the elements of the page.
    /// Implements the <see cref="IFareHistory"/> interface to define actions and checks for the Fare History page.
    /// </summary
    public class FareHistoryPage : IFareHistory
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        // Locators for the Fare History Page elements
        private readonly By titleLogo = By.XPath("/html/body/div/section/div/div[1]/div/img");
        private readonly By subtitle = By.XPath("/html/body/div/section/div/div[1]/h2");
        private readonly By tableOfFares = By.XPath("/html/body/div/section/div/div[2]/div/table/tbody");

        /// <summary>
        /// Initializes a new instance of the <see cref="FareHistoryPage"/> class.
        /// </summary>
        /// <param name="driver">The WebDriver instance used to interact with the page.</param>
        public FareHistoryPage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Explicit wait for up to 10 seconds
        }

        /// <summary>
        /// Verifies if the title logo is displayed on the Fare History page.
        /// </summary>
        /// <returns>True if the title logo is displayed, otherwise false.</returns>
        public bool IsTitleLogoDisplayed()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(titleLogo));
                return driver.FindElement(titleLogo).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Verifies if the subtitle is displayed on the Fare History page.
        /// </summary>
        /// <returns>True if the subtitle is displayed, otherwise false.</returns>
        public bool IsSubtitleDisplayed()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(subtitle));
                return driver.FindElement(subtitle).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Verifies if the table of fares is displayed on the Fare History page.
        /// </summary>
        /// <returns>True if the table of fares is displayed, otherwise false.</returns>
        public bool IsTableOfFaresDisplayed()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(tableOfFares));
                return driver.FindElement(tableOfFares).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
