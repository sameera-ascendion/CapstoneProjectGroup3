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

namespace MyShuttleInterfaces
{
    /// <summary>
    /// Interface representing the actions and checks that can be performed on the Fare History page.
    /// </summary>
    public interface IFareHistory
    {
        /// <summary>
        /// Verifies if the title logo is displayed on the Fare History page.
        /// </summary>
        /// <returns>
        /// True if the title logo is displayed, otherwise false.
        /// </returns>
        bool IsTitleLogoDisplayed();

        /// <summary>
        /// Verifies if the subtitle is displayed on the Fare History page.
        /// </summary>
        /// <returns>
        /// True if the subtitle is displayed, otherwise false.
        /// </returns>
        bool IsSubtitleDisplayed();

        /// <summary>
        /// Verifies if the table of fares is displayed on the Fare History page.
        /// </summary>
        /// <returns>
        /// True if the table of fares is displayed, otherwise false.
        /// </returns>
        bool IsTableOfFaresDisplayed();
    }
}
