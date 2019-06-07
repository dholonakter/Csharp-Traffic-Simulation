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
        public object DeSerialiseObjects([PexAssumeUnderTest]SerializeData target, string filename)
        {
            object result = target.DeSerialiseObjects(filename);
            return result;
            // TODO: add assertions to method SerializeDataTest.DeSerialiseObjects(SerializeData, String)
        }

        [PexMethod]
        public void SerialiseObjects(
            [PexAssumeUnderTest]SerializeData target,
            string filename,
            object objectToSerialize
        )
        {
            target.SerialiseObjects(filename, objectToSerialize);
            // TODO: add assertions to method SerializeDataTest.SerialiseObjects(SerializeData, String, Object)
        }
    }
}
