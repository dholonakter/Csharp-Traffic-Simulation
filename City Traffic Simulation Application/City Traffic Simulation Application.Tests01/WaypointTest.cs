using System.Drawing;
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

        [PexMethod]
        public Waypoint Constructor(double x, double y)
        {
            Waypoint target = new Waypoint(x, y);
            return target;
            // TODO: add assertions to method WaypointTest.Constructor(Double, Double)
        }

        [PexMethod]
        public Waypoint Constructor01(
            double x,
            double y,
            Waypoint w
        )
        {
            Waypoint target = new Waypoint(x, y, w);
            return target;
            // TODO: add assertions to method WaypointTest.Constructor01(Double, Double, Waypoint)
        }

        [PexMethod]
        public Waypoint Constructor02(Point p, Waypoint w)
        {
            Waypoint target = new Waypoint(p, w);
            return target;
            // TODO: add assertions to method WaypointTest.Constructor02(Point, Waypoint)
        }

        [PexMethod]
        public Waypoint Constructor03(Point p)
        {
            Waypoint target = new Waypoint(p);
            return target;
            // TODO: add assertions to method WaypointTest.Constructor03(Point)
        }

        [PexMethod]
        public void Draw([PexAssumeUnderTest]Waypoint target, ref Graphics gr)
        {
            target.Draw(ref gr);
            // TODO: add assertions to method WaypointTest.Draw(Waypoint, Graphics&)
        }

        [PexMethod]
        public bool RedLightGet([PexAssumeUnderTest]Waypoint target)
        {
            bool result = target.RedLight;
            return result;
            // TODO: add assertions to method WaypointTest.RedLightGet(Waypoint)
        }
    }
}
