using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Ecology.Tests.Radiation
{
    [TestFixture]
    public class BaseTests
    {
        private List<Radiation> _fakeRepo;
        private Radiation _fakeItem;
        private int testId = 1;

        public class Radiation
        {
            public int Id { get; set; }

            public double Dose { get; set; }

            public int Level { get; set; }

            public int IdCity { get; set; }

            public City Cities { get; set; }
        }

        public class City
        {
            public int Id { get; set; }
            public string CityName { get; set; }
        }

        [OneTimeSetUp]
        public void Setup()
        {
            var cities = new List<City>
            {
                new City() { Id = 1, CityName = "Брест"},
                new City() { Id = 2, CityName = "Витебск"},
                new City() { Id = 3, CityName = "Минск"}
            };

             _fakeRepo = new List<Radiation>
            {
                new Radiation() { Id = 1, Dose = 10, Level = 5,
                    Cities = new City() { Id = 3, CityName = "Минск"}
                    },
                new Radiation() { Id = 2, Dose = 20, Level = 5,
                    Cities = new City() { Id = 1, CityName = "Брест"}
                    },

            };
            _fakeItem = new Radiation() {
                Id = 2,
                Dose = 20,
                Level = 5,
                Cities = new City() { Id = 1, CityName = "Брест" }
            };
        }

        [Test]
        public void GetRadiations()
        {
            var radiations = _fakeRepo.ToList();

            Assert.AreEqual(3, radiations.Count);
        }

        //[Test]
        //public void GetRadiationsById()
        //{
        //    var radiations = _fakeRepo.Where(r => r.Id == testId).ToList();

        //    Assert.AreEqual(1, radiations.Count);
        //}

        //[Test]
        //public void AddRadiation()
        //{
        //   var radiation = new Radiation()
        //    {
        //        Id = 3,
        //        Dose = 20,
        //        Level = 5,
        //        Cities = new City() { Id = 1, CityName = "Брест" }
        //    };
        //     _fakeRepo.Add(radiation);

        //    Assert.AreEqual(3, _fakeRepo.Count);
        //}
        //[Test]
        //public void DelRadiation()
        //{
        //    var count = _fakeRepo.Count()-1;
                
        //    var radiation = _fakeRepo.FirstOrDefault(r => r.Id == testId);
        //   _fakeRepo.Remove(radiation);

        //    Assert.AreEqual(count, _fakeRepo.Count);
        //}
    }
}
