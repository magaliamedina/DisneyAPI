using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace DisneyAPI.Test
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<ICharacterRepository> _mockRepository;
        private CharacterService characterService;
        public const int petIDNegative = -1;
        public const int petID0 = 0;
        public const int petIDNotFound = 20;
        public const int petIDNoOwner = 10;

        //Cada vez que se ejecuten los metodos de la clase se va a llamar a este metodo
        [TestInitialize]
        public void Initialize()
        {
            //ARRANGE: definir todas las variables
            //Se mockea el repo. Para ello se instala un framework de mockeo: MOQ
            _mockRepository = new Mock<ICharacterRepository>();
            _mockRepository.Setup(x => x.DeletePet(petIDNegative)).Returns(true);
            _mockRepository.Setup(x => x.DeletePet(petID0)).Returns(true);
            _mockRepository.Setup(x => x.GetById(petIDNotFound)).Returns((Pet)null);
            _mockRepository.Setup(x => x.GetById(petIDNoOwner)).Returns(new Pet() { Owner = null });
            petService = new PetService(_mockRepository.Object, _mockMapper.Object);
        }

        [TestMethod]
        public void DeletePet_When_ID_Is_Negative()
        {
            //ACT: invocar al metodo a testear
            var result = petService.DeletePet(petIDNegative);

            //ASSERT
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeletePet_When_ID_Is_0()
        {
            //ACT: invocar al metodo a testear
            var result = petService.DeletePet(petID0);

            //ASSERT
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeletePet_When_ID_Is_Positive()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        //el texto es descriptivo, sale en la consola unicamente.
        [ExpectedException(typeof(ApplicationException), "Pet not found")]
        public void DeletePet_Throw_Exception_When_Not_Found()
        {
            //ACT: invocar al metodo a testear
            var result = petService.DeletePet(petIDNotFound);

            //ASSERT esta echo mediante el ExceptedException
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void DeletePet_Throw_Exception_When_Owner_is_Null()
        {
            //ACT: invocar al metodo a testear
            var result = petService.DeletePet(petIDNoOwner);

            //ASSERT esta echo mediante el ExceptedException
        }
    }
}
