using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using System.Drawing;
using City_Traffic_Simulation_Application;
// <copyright file="CrossingTest.Constructor01.g.cs">Copyright ©  2019</copyright>
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;

namespace City_Traffic_Simulation_Application.Tests
{
    public partial class CrossingTest
    {

[TestMethod]
[PexGeneratedBy(typeof(CrossingTest))]
public void Constructor01455()
{
    Crossing crossing;
    Crossing[,] crossings = (Crossing[,])null;
    crossing =
      this.Constructor01((Graphics)null, (PictureBox)null, 0, 0, ref crossings);
    Assert.IsNotNull((object)crossing);
    Assert.IsNotNull((object)(crossing.cars));
    Assert.AreEqual<int>(0, crossing.cars.Capacity);
    Assert.AreEqual<int>(0, crossing.cars.Count);
    Assert.IsNull((object)(crossing.box));
    Assert.IsNull((object)(crossing.gr));
    Assert.AreEqual<int>(0, crossing.x);
    Assert.AreEqual<int>(0, crossing.y);
    Assert.IsNull((object)crossings);
}
    }
}
