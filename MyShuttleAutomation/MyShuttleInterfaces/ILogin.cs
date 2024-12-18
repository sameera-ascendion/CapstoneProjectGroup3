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

namespace MyShuttleInterfaces
{
    /// <summary>
    /// Defines the contract for interacting with the Login page of the MyShuttle application.
    /// This interface ensures consistency for handling login operations.
    /// </summary>
    public interface ILogin
    {
        /// <summary>
        /// Sets the employee email in the email input field.
        /// </summary>
        /// <param name="email">The email to enter.</param>
        void EnterEmployeeEmail(string email);

        /// <summary>
        /// Sets the employee password in the password input field.
        /// </summary>
        /// <param name="password">The password to enter.</param>
        void EnterEmployeePassword(string password);

        /// <summary>
        /// Clicks the "Log In" button to attempt authentication.
        /// </summary>
        void ClickLoginButton();

        /// <summary>
        /// Checks whether an error message is displayed after an unsuccessful login attempt.
        /// </summary>
        /// <returns>True if an error message is displayed, otherwise false.</returns>
        bool IsErrorMessageDisplayed();

        /// <summary>
        /// Verifies if the login was successful by checking for the presence of the dashboard or homepage.
        /// </summary>
        /// <returns>True if the dashboard or homepage is displayed, otherwise false.</returns>
        bool IsLoginSuccessful();
    }
}

