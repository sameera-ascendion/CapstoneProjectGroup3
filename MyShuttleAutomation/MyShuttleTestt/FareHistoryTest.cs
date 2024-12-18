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
Author Name : Linesh
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using MyShuttleWebdriverAdapter;
using OpenQA.Selenium.Support.UI;

namespace MyShuttleTestt
{
    /// <summary>
    /// Test suite for validating the functionality and presence of elements on the Fare History page.
    /// </summary>
    [TestFixture]
    public class FareHistoryTest
    {
        private IWebDriver driver;
        private FareHistoryPage fareHistoryPage;
        private WebDriverWait wait;

        // The URL of the Fare History page
        private const string FareHistoryPageUrl = "http://192.168.0.102:8080/myshuttledev/home.jsp";

        /// <summary>
        /// Setup method that runs before each test to initialize the WebDriver, navigate to the Fare History page, and instantiate the page object.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Initialize ChromeDriver
            driver = new ChromeDriver();

            // Maximize the browser window
            driver.Manage().Window.Maximize();

            // Navigate to the Fare History page
            driver.Navigate().GoToUrl(FareHistoryPageUrl);

            // Initialize the FareHistoryPage object
            fareHistoryPage = new FareHistoryPage(driver);
        }

        /// <summary>
        /// Test to verify if the title logo is displayed on the Fare History page.
        /// </summary>
        [Test]
        public void Test_TitleLogoPresence()
        {
            // Assert: Verify if the title logo is displayed
            Assert.IsTrue(fareHistoryPage.IsTitleLogoDisplayed(), "Title logo is not displayed.");
        }

        /// <summary>
        /// Test to verify if the subtitle is displayed on the Fare History page.
        /// </summary>
        [Test]
        public void Test_SubtitlePresence()
        {
            // Assert: Verify if the subtitle is displayed
            Assert.IsTrue(fareHistoryPage.IsSubtitleDisplayed(), "Subtitle is not displayed.");
        }

        /// <summary>
        /// Test to verify if the table of fares is displayed on the Fare History page.
        /// </summary>
        [Test]
        public void Test_TableOfFaresPresence()
        {
            // Assert: Verify if the table of fares is displayed
            Assert.IsTrue(fareHistoryPage.IsTableOfFaresDisplayed(), "Table of fares is not displayed.");
        }

        /// <summary>
        /// Cleanup method that runs after each test to close the browser and release resources.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            // Close the browser after each test
            driver.Quit();
            driver.Dispose();
        }
    }
}
