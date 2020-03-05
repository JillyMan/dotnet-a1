using CoreProject.DataAccess.Context;
using CoreProject.DataAccess.Repository;
using CoreProject.Models;
using CoreProject.Settings;
using Di;
using Di.Exceptions;
using DiTest.TestProject.Services;
using FluentAssertions;
using System;
using Xunit;

namespace DiTest.cs
{
    public class DiGetServiceTest
    {
        [Fact]
        public void Add_Singletone_Object_Return_Only_One_Object()
        {
            var container = new DIContainer()
                .AddStatic(sp => new MongoSetting() { DatabaseName = "BERRIES", ConntectionString = "www.google.com" })
                .Build();

            var s1 = container.GetService<MongoSetting>();
            var s2 = container.GetService<MongoSetting>();
            ReferenceEquals(s1, s2).Should().BeTrue();
        }

        [Fact]
        public void Add_Transient_Object_Return_New_Object_Always()
        {
            var container = new DIContainer()
                .AddTransient(sp => new MongoSetting() { DatabaseName = "BERRIES", ConntectionString = "www.google.com" })
                .Build();

            var s1 = container.GetService<MongoSetting>();
            var s2 = container.GetService<MongoSetting>();
            ReferenceEquals(s1, s2).Should().BeFalse();
        }

        [Fact]
        public void Injection_To_Constructor_With_Arguments()
        {
            var container = new DIContainer()
                .AddStatic(sp => new MongoSetting() { DatabaseName = "BERRIES", ConntectionString = "www.google.com" })
                .AddTransient<IContext, MongoContext>()
                .Build();

            var context = container.GetService<IContext>();
            context.Should().NotBeNull();
            context.Should().BeOfType<MongoContext>();
        }

        [Fact]
        public void Injection_Test_With_Implementation_Factory_Return_Object_By_Class_Name()
        {
            var container = new DIContainer()
                .AddTransient(sp => new MongoSetting() { DatabaseName = "BERRIES", ConntectionString = "www.google.com" })
                .Build();

            var setting = container.GetService<MongoSetting>();
            setting.Should().NotBeNull();
            setting.Should().BeOfType<MongoSetting>();

            setting.DatabaseName.Should().BeEquivalentTo("BERRIES");
            setting.ConntectionString.Should().BeEquivalentTo("www.google.com");
        }

        [Fact]
        public void Inject_To_Properties_Return_Object_With_Injected_Properties()
        {
            var container = new DIContainer()
                .AddStatic(sp => new MongoSetting() { DatabaseName = "BERRIES", ConntectionString = "www.google.com" })
                .AddTransient<IContext, MongoContext>()
                .AddTransient<IRepository<User>, UserRepository>()
                .AddTransient<IRepository<Product>, ProductRepository>()
                .AddTransient<ShopService>()
                .Build();

            var shopService = container.GetService<ShopService>();
            shopService.Should().NotBeNull();

            shopService.UserRepository.Should().NotBeNull();
            shopService.ProductRepository.Should().NotBeNull();

            shopService.UserRepository.Should().BeOfType<UserRepository>();
            shopService.ProductRepository.Should().BeOfType<ProductRepository>();
        }

        [Fact]
        public void Return_Object_Witch_Not_Setup_In_Di_Return_Valid_Object()
        {
            var container = new DIContainer();
            var user = container.GetService<User>();
            user.Should().NotBeNull();
        }

        [Fact]
        public void Return_Service_By_Interface_But_Implementation_Does_Not_Contains_In_Cotainer()
        {
            var container = new DIContainer();
            var rep = container.GetService<IRepository<User>>();
            rep.Should().BeOfType<UserRepository>();
            rep.Should().NotBeNull();
        }

        [Fact]
        public void NotFoundImplementation_Becase_Interface_Has_More_Then_One_Child()
        {
            var container = new DIContainer();
            Assert.Throws<MultiplyImplementingException>(() => container.GetService<BaseEntity>());
        }

        [Fact]
        public void Interface_Not_Implemented_Exception()
        {
            var container = new DIContainer();
            Assert.Throws<NotImplementedException>(() => container.GetService<IUserService>());
        }
    }
}
