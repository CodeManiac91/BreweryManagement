using AutoMapper;
using DataAccess;
using DataAccess.Repository;
using DataTransferObjects;
using Moq;
using Services.Implementation;
using Services.Interfaces;
using Services.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BreweryManagementTests
{
    public class BussinessServiceTest
    {
        private Mock<IBrewerService> _brewerServiceMock;
        private BrewerBussinessService _brewerBussinessService;

        [Test]
        public void GetBrewerById()
        {
            var brewerInMemory = new List<Brewer>() {
                new Brewer(){Id=1, Name = "John Doe", IndentificationNumber = 76102800200, Removed = false }
            };

            _brewerServiceMock = new Mock<IBrewerService>();
            
            _brewerServiceMock.Setup(x => x.GetBrewerById(It.IsAny<int>()))
                  .Returns((int id) => brewerInMemory.Single(brewer => brewer.Id == id));

            var config = new MapperConfiguration(cfg => cfg.AddProfile<BrewerProfile>());
            var mapper = config.CreateMapper();

            _brewerBussinessService = new BrewerBussinessService(_brewerServiceMock.Object, mapper);

            var brewerEntity = _brewerBussinessService.GetBrewerById(1);
            var brewerDto = mapper.Map<BrewerDto>(brewerEntity);

            Assert.IsNotNull(brewerDto);
        }

        [Test]
        public void AddBrewer()
        {
            var brewerInMemory = new List<Brewer>() {
                new Brewer(){Id=1, Name = "John Doe", IndentificationNumber = 76102800200, Removed = false }
            };

            var initialListCount = brewerInMemory.Count();

            var brewerDto = new BrewerDto()
            {
                Name = "Elizabeth Taylor",
                IdentificationNumber = 90081089200,
                Removed = false
            };

            var config = new MapperConfiguration(cfg => cfg.AddProfile<BrewerProfile>());
            var mapper = config.CreateMapper();

            _brewerServiceMock = new Mock<IBrewerService>();

            _brewerServiceMock.Setup(x => x.AddBrewer(It.IsAny<Brewer>()))
                  .Callback((Brewer brewer) => brewerInMemory.Add(brewer));

            _brewerBussinessService = new BrewerBussinessService(_brewerServiceMock.Object, mapper);

            var brewerEntity = mapper.Map<Brewer>(brewerDto);
            brewerEntity.Id = initialListCount++;
            _brewerBussinessService.AddBrewer(brewerDto);

            Assert.That(brewerInMemory.Count(), Is.EqualTo(initialListCount));
        }
    }
}
