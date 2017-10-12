using System;
using System.Globalization;

namespace Framework.Xamariner
{
    /// <summary>
    /// Implementations of this interface MUST convert iOS and Android
    /// platform-specific locales to a value supported in .NET because
    /// ONLY valid .NET cultures can have their RESX resources loaded and used.
    /// </summary>
    /// <remarks>
    /// Lists of valid .NET cultures can be found here:
    ///   https://github.com/xamarin/xamarin-forms-samples/tree/master/UsingResxLocalization
    ///   http://www.localeplanet.com/dotnet/
    ///   http://www.csharp-examples.net/culture-names/
    /// You should always test all the locales implemented in your application.
    /// Sample apps built using the Xamarin.Forms framework.
    ///
    /// License
    /// The Apache License 2.0 applies to all samples in this repository.
    /// Copyright 2011 Xamarin Inc
    /// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
    /// http://www.apache.org/licenses/LICENSE-2.0
    /// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
    /// </remarks>
    public enum Platforms
    {
        //
        // Summary:
        //     (Unused) Indicates that Forms is running on an undefined platform.
        Other = 0,
        //
        // Summary:
        //     Indicates that Forms is running on an Apple iOS OS.
        iOS = 1,
        //
        // Summary:
        //     Indicates that Forms is running on a Google Android OS.
        Android = 2,
        //
        // Summary:
        //     Indicates that Forms is running on a Microsoft WinPhone OS.
        WinPhone = 3,
        //
        // Summary:
        //     Indicates that forms is running on the Windows platform.
        Windows = 4
    }
}

