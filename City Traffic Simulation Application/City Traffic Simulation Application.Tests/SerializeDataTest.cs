// <copyright file="SerializeDataTest.cs">Copyright ©  2019</copyright>

using System;
using City_Traffic_Simulation_Application;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace City_Traffic_Simulation_Application.Tests
{
    [TestClass]
    [PexClass(typeof(SerializeData))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class SerializeDataTest
    {

        [PexMethod]
        internal SerializeData Constructor(string filename)
        {
            SerializeData target = new SerializeData(filename);
            return target;
            // TODO: add assertions to method SerializeDataTest.Constructor(String)
        }
    }
}
