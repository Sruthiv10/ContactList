using Xunit;
using Moq;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using ContactList.Application.ContactList;
using ContactList.Core.Interface;
using ContactList.Application.DTO;
using ContactList.Core.Entities;
using ContactList.Core.Common;
using System.Collections.Generic;
using System.Linq;

namespace ContactList.Test
{
    public class ContactListAppServiceTests
    {
        private readonly Mock<IContactListService> mockContactListService;
        private readonly Mock<IMapper> mockMapper;
        private readonly Mock<ILogger<ContactListAppService>> mockLogger;
        private readonly Mock<IConfiguration> mockConfiguration;
        private readonly ContactListAppService appService;

        public ContactListAppServiceTests()
        {
            mockContactListService = new Mock<IContactListService>();
            mockMapper = new Mock<IMapper>();
            mockLogger = new Mock<ILogger<ContactListAppService>>();
            mockConfiguration = new Mock<IConfiguration>();

            appService = new ContactListAppService(
                mockContactListService.Object,
                mockMapper.Object,
                mockLogger.Object,
                mockConfiguration.Object);
        }

        [Fact]
        public void SaveTest()
        {
            // Arrange
            var contactDto = new ContactListDTO { Name = "John Doe", Email = "john@example.com", PhoneNumber = "994655", Category = "family"};
            var contactEntity = new ContactListEntity { ContactId = 1, Name = "John Doe", Email = "john@example.com", PhoneNumber = "994655", Category = "family" };

            mockMapper.Setup(m => m.Map<ContactListEntity>(contactDto)).Returns(contactEntity);
            mockContactListService.Setup(s => s.Save(It.IsAny<ContactListEntity>()))
                                  .Returns(new ExecuteResult<ContactListEntity> { Success = true, Result = contactEntity });

            // Act
            var result = appService.Save(contactDto);

            // Assert
            Assert.True(result.Success);
            mockContactListService.Verify(s => s.Save(It.IsAny<ContactListEntity>()), Times.Once);
        }

    }
}
