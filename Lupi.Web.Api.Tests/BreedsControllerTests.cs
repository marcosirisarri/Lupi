using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Lupi.BusinessLogic;
using Lupi.Web.Api.Controllers;
using System.Collections.Generic;
using Lupi.Data.Entities;
using System.Web.Http;
using System.Web.Http.Results;

namespace Lupi.Web.Api.Tests
{
    [TestClass]
    public class BreedsControllerTests
    {
        [TestMethod]
        public void GetAllBreedsOkTest()
        {
            //Arrange
            var expectedBreeds = GetFakeBreeds();

            var mockBreedsBusinessLogic = new Mock<IBreedsBusinessLogic>();
            mockBreedsBusinessLogic
                .Setup(bl => bl.GetAllBreeds())
                .Returns(expectedBreeds);

            var controller = new BreedsController(mockBreedsBusinessLogic.Object);
            
            //Act
            IHttpActionResult obtainedResult = controller.Get();
            // Casteo el resultado HTTP a un resultado OK
            var contentResult = obtainedResult as OkNegotiatedContentResult<IEnumerable<Breed>>;

            //Assert
            mockBreedsBusinessLogic.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(expectedBreeds, contentResult.Content);
        }

        //Función auxiliar
        private IEnumerable<Breed> GetFakeBreeds()
        {
            return new List<Breed>
            {
                new Breed
                {
                    Id = new Guid("e5020d0b-6fce-4b9f-a492-746c6c8a1bfa"),
                    Name = "Pug",
                    HairType  = "short fur",
                    HairColors = new List<string>
                    {
                        "blonde"
                    }
                },
                new Breed
                {
                    Id = new Guid("6b718186-fa8c-4e14-9af8-2601e153db71"),
                    Name = "Golden Retriever",
                    HairType  = "hairy fur",
                    HairColors = new List<string>
                    {
                        "blonde"
                    }
                }
            };
        }
    }
}
