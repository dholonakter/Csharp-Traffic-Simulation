// <copyright file="WaypointTest.cs">Copyright ©  2019</copyright>

using System;
using City_Traffic_Simulation_Application;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace City_Traffic_Simulation_Application.Tests
{
    [TestClass]
    [PexClass(typeof(Waypoint))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class WaypointTest
    {

        [PexMethod]
        public void RedLightSet([PexAssumeUnderTest]Waypoint target, bool value)
        {
            target.RedLight = value;
            // TODO: add assertions to method WaypointTest.RedLightSet(Waypoint, Boolean)
        }
    }
}
