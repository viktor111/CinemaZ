using System;
using System.Collections.Generic;
using System.Linq;
using CinemaZ.Models;
using CinemaZ.Service;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CinemaZ.Test.Services
{
    [TestClass]
    public class SqlPremiereServiceTest : DbContextSqlLite
    {
        private readonly SqlPremiereService _sqlPremiereService;
        
        public SqlPremiereServiceTest()
        {
            _sqlPremiereService = new(_dbContext);
        }

        [TestMethod]
        public void ListPremier_ShouldWork()
        {
            //Arrange
            Premiere premiere1 = new()
            {
                Discount = 20M,
                Movie = new Movie(),
                EndDate = DateTime.Now,
                PremiereDate = DateTime.Now
            };
            
            Premiere premiere2 = new()
            {
                Discount = 20M,
                Movie = new Movie(),
                EndDate = DateTime.Now,
                PremiereDate = DateTime.Now
            };

            //Act
            _dbContext.Premiere.Add(premiere1);
            _dbContext.Premiere.Add(premiere2);
            
            _dbContext.SaveChanges();

            //Assert
            List<Premiere> premieres = _sqlPremiereService.ListPremieres();
            
            Assert.IsNotNull(premieres);
            Assert.AreEqual(2, premieres.Count);
        }

        [TestMethod]
        public void GetPremiere_ShouldWork()
        {
            //Arrange
            Premiere premiere = new()
            {
                Discount = 20M,
                Movie = new Movie(),
                EndDate = DateTime.Now,
                PremiereDate = DateTime.Now
            };

            //Act
            _dbContext.Premiere.Add(premiere);
            
            _dbContext.SaveChanges();

            //Assert
            Premiere premiereDb = _sqlPremiereService.GetPremiere(premiere.Id);
            
            Assert.IsNotNull(premiereDb);
            Assert.AreEqual(premiere.Id, premiereDb.Id);
            Assert.AreEqual(premiere.Discount, premiere.Discount);
        }

        [TestMethod]
        public void EdditPremiere_SouldPersist()
        {
            //Arrange
            Premiere premiere = new()
            {
                Discount = 20M,
                Movie = new Movie(),
                EndDate = DateTime.Now,
                PremiereDate = DateTime.Now
            };

           

            //Act
            _dbContext.Premiere.Add(premiere);
            
            _dbContext.SaveChanges();

            Premiere premiere2 = new()
            {
                Id = premiere.Id,
                Discount = 2023M,
                Movie = new Movie(),
                EndDate = DateTime.Now,
                PremiereDate = DateTime.Now
            };

            _sqlPremiereService.EdditPremiere(premiere2);

            //Assert
            Premiere premiereDb = _dbContext.Premiere.FirstOrDefault(p => p.Id == premiere.Id);
            
            Assert.AreEqual(premiere2.Discount, premiereDb.Discount);
            Assert.AreEqual(premiere2.Id, premiereDb.Id);
        }

        [TestMethod]
        public void DeletePremiere_ShouldDelete()
        {
            //Arrange
            Premiere premiere = new()
            {
                Discount = 20M,
                Movie = new Movie(),
                EndDate = DateTime.Now,
                PremiereDate = DateTime.Now
            };

            //Act
            _dbContext.Premiere.Add(premiere);
            
            _dbContext.SaveChanges();

            _sqlPremiereService.DeletePremiere(premiere);

            //Assert

            Premiere premiereDb = _dbContext.Premiere.FirstOrDefault(p => p.Id == premiere.Id);
            
            Assert.IsNull(premiereDb);
        }

        [TestMethod]
        public void CreatePremiere_ShouldPersist()
        {
            //Arrange
            Premiere premiere = new()
            {
                Discount = 20M,
                Movie = new Movie(),
                EndDate = DateTime.Now,
                PremiereDate = DateTime.Now
            };

            //Act
            _sqlPremiereService.CreatePremiere(premiere);

            //Assert
            List<Premiere> premieres = _dbContext.Premiere.ToList();

            Assert.AreEqual(1, premieres.Count);
            Assert.AreEqual(premiere.Id, premieres[0].Id);
            Assert.AreEqual(premiere.Discount, premieres[0].Discount);
        }
    }
}