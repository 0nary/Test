using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Attributes;
using TestProject.DataBases;
using Xunit;


namespace TestProject.Tests
{
    [TestCaseOrderer("TestProject.Orderers.PriorityOrderer", "TestProject")]
    public class Test_TestOrders
    {
        public static bool Test1Called = false;
        public static bool Test2Called = false;
        public static bool Test3Called = false;
        public static bool Test4Called = false;
        public static bool Test5Called = false;

        [Fact, TestPriority(1)]
        public void Test1()
        {
            Test1Called = true;

            Assert.False(Test5Called, "5");
            Assert.False(Test4Called, "4");
            Assert.False(Test3Called, "3");
            Assert.False(Test2Called, "2");
            Assert.True(Test1Called, "1");
        }

        [Fact, TestPriority(3)]
        public void Test3()
        {
            Test3Called = true;

            Assert.False(Test5Called, "5");
            Assert.False(Test4Called, "4");
            Assert.True(Test3Called, "3");
            Assert.True(Test2Called, "2");
            Assert.True(Test1Called, "1");
        }

        [Fact, TestPriority(5)]
        public void Test5()
        {
            Test5Called = true;

            Assert.True(Test5Called, "5");
            Assert.True(Test4Called, "4");
            Assert.True(Test3Called, "3");
            Assert.True(Test2Called, "2");
            Assert.True(Test1Called, "1");
        }

        [Fact, TestPriority(4)]
        public void Test4()
        {
            Test4Called = true;

            Assert.False(Test5Called, "5");
            Assert.True(Test4Called, "4");
            Assert.True(Test3Called, "3");
            Assert.True(Test2Called, "2");
            Assert.True(Test1Called, "1");
        }

        [Fact, TestPriority(2)]
        public void Test2()
        {
            Test2Called = true;

            Assert.False(Test5Called, "5");
            Assert.False(Test4Called, "4");
            Assert.False(Test3Called, "3");
            Assert.True(Test2Called, "2");
            Assert.True(Test1Called, "1");
        }

        [Fact, TestPriority(6)]
        public async void TestDB()
        {
            TestDbContext testDbContext = new TestDbContext();

            await testDbContext.Database.OpenConnectionAsync();

            Assert.True( await testDbContext.Database.CanConnectAsync());
        }
    }
}
