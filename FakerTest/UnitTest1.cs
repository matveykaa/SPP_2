using System;
using System.Linq;
using Faker;
using FakerTests.TestClasses;
using NUnit.Framework;

namespace FakerTests
{
    public class UnitTest1
    {
        private Faker.Faker faker = new();
        [Test]
        public void TestMethod1()
        {
            var testClass1 = faker.Create<TestClassPrimitiveTypes>();

            Assert.IsTrue(testClass1.x != 0);
            Assert.IsTrue(testClass1.Y != 0);
            Assert.IsTrue(testClass1.Z != 0);
        }

        [Test]
        public void TestMethod2()
        {
            var testClass1 = faker.Create<TestClassObjects>();

            Assert.IsTrue(testClass1.Code != null);
            Assert.IsTrue(DateTime.Compare(testClass1.Date,new DateTime(1999, 12, 31)) > 0);
        }

        [Test]
        public void TestMethod3()
        {
            Assert.Throws<CycleException>(() => faker.Create<ClassA>());
            Assert.Throws<CycleException>(() => faker.Create<ClassB>());
        }

        [Test]
        public void TestMethod4()
        {
            var outerClass = faker.Create<OuterClass>();

            Assert.IsTrue(DateTime.Compare(outerClass.date, new DateTime(1999, 12, 31)) > 0);
            Assert.IsTrue(outerClass.Inner.Name != null);
        }        

        [Test]
        public void TestMethod5()
        {
            var class1 = faker.Create<ClassConstructedWithParameters>();

            Assert.IsTrue(class1.b != 0);
            Assert.IsTrue(class1.stringValue != null);
        }

        [Test]
        public void TestMethod6()
        {
            var class1 = faker.Create<ClassWithList>();

            var list = class1.InnerClasses;

            Assert.IsTrue(list.Any());

            foreach (var item in list)
            {
                Assert.IsTrue(item.Name != null);
            }            
        }
    }
}