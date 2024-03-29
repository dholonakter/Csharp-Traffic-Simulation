using System.Collections.Generic;
// <copyright file="CityTest.cs">Copyright ©  2019</copyright>

using System;
using City_Traffic_Simulation_Application;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace City_Traffic_Simulation_Application.Tests
{
    [TestClass]
    [PexClass(typeof(City))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class CityTest
    {

        [PexMethod]
        public City Constructor(string cityname)
        {
            City target = new City(cityname);
            return target;
            // TODO: add assertions to method CityTest.Constructor(String)
        }

        [PexMethod]
        public List<object> Frame([PexAssumeUnderTest]City target, int crossingId)
        {
            List<object> result = target.Frame(crossingId);
            return result;
            // TODO: add assertions to method CityTest.Frame(City, Int32)
        }
    }
}
