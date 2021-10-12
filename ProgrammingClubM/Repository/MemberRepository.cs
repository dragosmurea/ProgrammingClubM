using ProgrammingClubM.Models;
using ProgrammingClubM.Models.DBObjects;
using ProgrammingClubM.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammingClubM.Repository
{
    public class MemberRepository
    {
        private ClubMembershipModelsDataContext dbContext;

        public MemberRepository()
        {
            this.dbContext = new ClubMembershipModelsDataContext();

        }

        public MemberRepository(ClubMembershipModelsDataContext dataContext)
        {
            this.dbContext = dataContext;
        }

        public MemberCodeSnippetsViewModel GetMemberCodeSnippets(Guid memberID)
        {
            MemberCodeSnippetsViewModel memberCodeSnippetsViewModel = new MemberCodeSnippetsViewModel();
            Member member = dbContext.Members.FirstOrDefault(m => m.IDMember == memberID);

            if(member != null)
            {
                memberCodeSnippetsViewModel.Name = member.Name;
                memberCodeSnippetsViewModel.Position = member.Position;
                memberCodeSnippetsViewModel.Title = member.Title;

                IQueryable<CodeSnippet> memberCodeSnippets = dbContext.CodeSnippets.Where(c => c.IDMember == memberID);
                foreach(CodeSnippet code in memberCodeSnippets)
                {
                    CodeSnippetModel codeSnippetModel = new CodeSnippetModel();
                    codeSnippetModel.Title = code.Title;
                    codeSnippetModel.ContentCode = code.ContentCode;
                    codeSnippetModel.Revision = code.Revision;
                    memberCodeSnippetsViewModel.CodeSnippets.Add(codeSnippetModel);
                }
            }

            return memberCodeSnippetsViewModel;
        }

        private MemberModel MapDbOjectToModel (Member dbMember)
        {
            MemberModel memberModel = new MemberModel();
            if(dbMember != null)
            {
                memberModel.Description = dbMember.Description;
                memberModel.IDMember = dbMember.IDMember;
                memberModel.Name = dbMember.Name;
                memberModel.Position = dbMember.Position;
                memberModel.Resume = dbMember.Resume;
                memberModel.Title = dbMember.Title;

                return memberModel;
            }

            return null;
        }

        private Member MapModelToDbObject(MemberModel memberModel)
        {
            Member member = new Member();

            if(memberModel != null)
            {
                member.Description = memberModel.Description;
                member.IDMember = memberModel.IDMember;
                member.Name = memberModel.Name;
                member.Position = memberModel.Position;
                member.Resume = memberModel.Resume;
                member.Title = memberModel.Title;

                return member;
            }

            return null;
        }

        public List<MemberModel> GetAll()
        {
            List<MemberModel> members = new List<MemberModel>();
            foreach(Member member in dbContext.Members)
            {
                members.Add(MapDbOjectToModel(member));
            }

            return members;
        }

        public MemberModel GetById(Guid ID)
        {
            return MapDbOjectToModel(dbContext.Members.FirstOrDefault(m => m.IDMember == ID));

        }

        public void InsertMember(MemberModel memberModel)
        {
            memberModel.IDMember = Guid.NewGuid();
            dbContext.Members.InsertOnSubmit(MapModelToDbObject(memberModel));
            dbContext.SubmitChanges();
        }

        public void UpdateMember(MemberModel memberModel)
        {
            Member member = dbContext.Members.FirstOrDefault(m => m.IDMember == memberModel.IDMember);
            if(member != null)
            {
                member.Description = memberModel.Description;
                member.IDMember = memberModel.IDMember;
                member.Name = memberModel.Name;
                member.Position = memberModel.Position;
                member.Resume = memberModel.Resume;
                member.Title = memberModel.Title;
                dbContext.SubmitChanges();
            }
        }

        public void Delete(Guid ID)
        {
            Member member = dbContext.Members.FirstOrDefault(m => m.IDMember == ID);
            if(member != null)
            {
                dbContext.Members.DeleteOnSubmit(member);
                dbContext.SubmitChanges();
            }
        }
    }

}