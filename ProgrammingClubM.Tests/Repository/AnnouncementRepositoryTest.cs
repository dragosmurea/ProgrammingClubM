using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgrammingClubM.Models;
using ProgrammingClubM.Models.DBObjects;
using ProgrammingClubM.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingClubM.Tests.Repository
{

    [TestClass]
    public class AnnouncementRepositoryTest
    {
        private ClubMembershipModelsDataContext dbContext;
        private string testConnectionString;
        private AnnouncementRepository announcementRepository;

        [TestInitialize]
        public void Initialize()
        {
            testConnectionString = ConfigurationManager.ConnectionStrings["clubmembershipConnectionStringTest"].ConnectionString;
            dbContext = new ClubMembershipModelsDataContext(testConnectionString);
            announcementRepository = new AnnouncementRepository(dbContext);
        }

        [TestMethod]
        public void GetAnnoucementById_AnnouncementExists()
        {
            ///AAA Arrange, Act, Assert. Setup all objects(Arrange). Invoke the method under test. (Act)
            ///Verify the fact the method behaves as expected(Assert)
            ///
            Guid ID = Guid.NewGuid();
            Announcement expectedAnnouncement = new Announcement
            {
                IDAnnouncement = ID,
                ValidFrom = new DateTime(2021, 1, 1),
                ValidTo = new DateTime(2021, 1, 1),
                Tags = "test tag",
                Text = "Announcement",
                Title = "Important"
            };

            dbContext.Announcements.InsertOnSubmit(expectedAnnouncement);
            dbContext.SubmitChanges();

            //Act
            AnnouncementModel result = announcementRepository.GetAnnouncementById(ID);

            //Assert
            Assert.AreEqual(result.IDAnnouncement, expectedAnnouncement.IDAnnouncement);
            Assert.AreEqual(result.Title, expectedAnnouncement.Title);
            Assert.AreEqual(result.Text, expectedAnnouncement.Text);
            Assert.AreEqual(result.Tags, expectedAnnouncement.Tags);
            Assert.AreEqual(result.ValidFrom, expectedAnnouncement.ValidFrom);
            Assert.AreEqual(result.ValidTo, expectedAnnouncement.ValidTo);
        }

        [TestMethod]
        public void GetAnnouncementById_AnnouncementDoesntExist()
        {
            Guid ID = Guid.NewGuid();
            Announcement expectedAnnouncement = new Announcement
            {
                IDAnnouncement = ID,
                ValidFrom = new DateTime(2021, 1, 1),
                ValidTo = new DateTime(2021, 1, 1),
                Tags = "test tag",
                Text = "Announcement",
                Title = "Important"
            };


            dbContext.Announcements.InsertOnSubmit(expectedAnnouncement);
            dbContext.SubmitChanges();

            //Act
            AnnouncementModel result = announcementRepository.GetAnnouncementById(Guid.NewGuid());

            //Assert
            Assert.IsNull(result);

        }

    }
}
