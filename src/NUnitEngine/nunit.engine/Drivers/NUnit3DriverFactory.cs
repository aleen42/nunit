﻿// ***********************************************************************
// Copyright (c) 2014 Charlie Poole
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using NUnit.Engine.Extensibility;

namespace NUnit.Engine.Drivers
{
    public class NUnit3DriverFactory : IDriverFactory
    {
        private const string NUNIT_FRAMEWORK = "nunit.framework";

        /// <summary>
        /// Gets a flag indicating whether a given AssemblyName
        /// represents a test framework supported by this factory.
        /// </summary>
        public bool IsSupportedFramework(AssemblyName reference)
        {
            return reference.Name == NUNIT_FRAMEWORK && reference.Version.Major == 3;
        }

        /// <summary>
        /// Gets a driver for a given test assembly and a framework
        /// which the assembly is already known to reference.
        /// </summary>
        /// <param name="domain">The domain in which the assembly will be loaded</param>
        /// <param name="frameworkAssemblyName">The name of the test framework reference</param>
        /// <param name="assemblyPath">The path to the test assembly</param>
        /// <param name="settings">A dictionary of settings to be used for this assembly</param>
        /// <returns></returns>
        public IFrameworkDriver GetDriver(AppDomain domain, string frameworkAssemblyName, string assemblyPath, IDictionary<string, object> settings)
        {
            Guard.ArgumentValid(frameworkAssemblyName == "nunit.framework", "Invalid framework name", "frameworkAssemblyName");
            
            return new NUnit3FrameworkDriver(domain, assemblyPath, settings);
        }
    }
}
