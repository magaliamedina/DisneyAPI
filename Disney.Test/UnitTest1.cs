using DisneyData.Models;
using DisneyData.Repositories;
using DisneyDomain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Disney.Test
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IMovieRepository> _mockRepository;
        private MovieService movieService;
        public const int movieIDNegative = -1;
        public const int movieID0 = 0;
        public const int movieIDNotFound = 20;

        //Cada vez que se ejecuten los metodos de la clase se va a llamar a este metodo
        [TestInitialize]
        public void Initialize()
        {
            //ARRANGE: definir todas las variables
            //Se mockea el repo. Para ello se instala un framework de mockeo: MOQ
            _mockRepository = new Mock<IMovieRepository>();
            _mockRepository.Setup(x => x.DeleteMovie(movieIDNegative)).Returns(true);
            _mockRepository.Setup(x => x.DeleteMovie(movieID0)).Returns(true);
            _mockRepository.Setup(x => x.GetById(movieIDNotFound)).Returns((Movie)null);
            movieService = new MovieService(_mockRepository.Object);
        }

        [TestMethod]
        public void DeleteMovie_When_ID_Is_Negative()
        {
            //ACT: invocar al metodo a testear
            var result = movieService.DeleteMovie(movieIDNegative);

            //ASSERT
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeleteMovie_When_ID_Is_0()
        {
            //ACT: invocar al metodo a testear
            var result = movieService.DeleteMovie(movieID0);

            //ASSERT
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeleteMovie_When_ID_Is_Positive()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        //el texto es descriptivo, sale en la consola unicamente.
        [ExpectedException(typeof(ApplicationException), "Movie not found")]
        public void DeletePet_Throw_Exception_When_Not_Found()
        {
            //ACT: invocar al metodo a testear
            var result = movieService.DeleteMovie(movieIDNotFound);

            //ASSERT esta echo mediante el ExceptedException
        }

    }
}