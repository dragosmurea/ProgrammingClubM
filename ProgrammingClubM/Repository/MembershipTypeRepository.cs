using ProgrammingClubM.Models;
using ProgrammingClubM.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammingClubM.Repository
{
    public class MembershipTypeRepository
    {
        private ClubMembershipModelsDataContext dbContext;

  
        public MembershipTypeRepository()
        {
            this.dbContext = new ClubMembershipModelsDataContext();
        }

        public MembershipTypeRepository(ClubMembershipModelsDataContext dataContext)
        {
            this.dbContext = dataContext;
        }

        private MembershipTypeModel MapDbOjectToModel(MembershipType dbMembershipType)
        {
            MembershipTypeModel membershiptypeModel = new MembershipTypeModel();
            if (dbMembershipType != null)
            {
                membershiptypeModel.Description = dbMembershipType.Description;
                membershiptypeModel.IDMembershipType = dbMembershipType.IDMembershipType;
                membershiptypeModel.Name = dbMembershipType.Name;
                membershiptypeModel.SubscriptionLengthToMonths = dbMembershipType.SubscriptionLengthInMonths;

                return membershiptypeModel;
            }

            return null;
        }

        private MembershipType MapModelToDbObject(MembershipTypeModel membershiptypeModel)
        {
            MembershipType membershiptype = new MembershipType();

            if (membershiptypeModel != null)
            {
                membershiptype.SubscriptionLengthInMonths = membershiptypeModel.SubscriptionLengthToMonths;
                membershiptype.Name = membershiptypeModel.Name;
                membershiptype.Description = membershiptypeModel.Description;
                membershiptype.IDMembershipType = membershiptypeModel.IDMembershipType;

                return membershiptype;
            }

            return null;
        }

        public List<MembershipTypeModel> GetAll()
        {
            List<MembershipTypeModel> membershiptypes = new List<MembershipTypeModel>();
            foreach (MembershipType membershiptype in dbContext.MembershipTypes)
            {
                membershiptypes.Add(MapDbOjectToModel(membershiptype));
            }

            return membershiptypes;
        }

        public MembershipTypeModel GetById(Guid ID)
        {
            return MapDbOjectToModel(dbContext.MembershipTypes.FirstOrDefault(m => m.IDMembershipType == ID));

        }

        public void InsertMembershipType(MembershipTypeModel membershiptypeModel)
        {
            membershiptypeModel.IDMembershipType = Guid.NewGuid();
            dbContext.MembershipTypes.InsertOnSubmit(MapModelToDbObject(membershiptypeModel));
            dbContext.SubmitChanges();
        }

        public void UpdateMembershipType(MembershipTypeModel membershiptypeModel)
        {
            MembershipType membershiptype = dbContext.MembershipTypes.FirstOrDefault(m => m.IDMembershipType == membershiptypeModel.IDMembershipType);
            if (membershiptype != null)
            {
                membershiptype.SubscriptionLengthInMonths = membershiptypeModel.SubscriptionLengthToMonths;
                membershiptype.Name = membershiptypeModel.Name;
                membershiptype.Description = membershiptypeModel.Description;
                membershiptype.IDMembershipType = membershiptypeModel.IDMembershipType;
                dbContext.SubmitChanges();
            }
        }

        public void Delete(Guid ID)
        {

            MembershipType membershiptype = dbContext.MembershipTypes.FirstOrDefault(m => m.IDMembershipType == ID);
            if (membershiptype != null)
            {
                dbContext.MembershipTypes.DeleteOnSubmit(membershiptype);
                dbContext.SubmitChanges();
            }
        }
    }
}