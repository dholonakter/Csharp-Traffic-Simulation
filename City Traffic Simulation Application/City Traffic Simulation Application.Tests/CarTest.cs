using System.Drawing;
// <copyright file="CarTest.cs">Copyright ©  2019</copyright>

using System;
using City_Traffic_Simulation_Application;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace City_Traffic_Simulation_Application.Tests
{
    [TestClass]
    [PexClass(typeof(Car))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class CarTest
    {

        [PexMethod]
        public Car Constructor(
            Point p,
            Waypoint w,
            int width,
            int height
        )
        {
            Car target = new Car(p, w, width, height);
            return target;
            // TODO: add assertions to method CarTest.Constructor(Point, Waypoint, Int32, Int32)
        }
    }
}
