using ProgrammingClubM.Models;
using ProgrammingClubM.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammingClubM.Repository
{
    public class CodeSnippetRepository
    {
        private ClubMembershipModelsDataContext dbContext;

        public CodeSnippetRepository()
        {
            this.dbContext = new ClubMembershipModelsDataContext();
        }

        public CodeSnippetRepository(ClubMembershipModelsDataContext dataContext)
        {
            this.dbContext = dbContext;
        }

        private CodeSnippetModel MapObjectToModel(CodeSnippet dbCodeSnippet)
        {
            CodeSnippetModel codeSnippetModel = new CodeSnippetModel();
            if(dbCodeSnippet != null)
            {
                codeSnippetModel.ContentCode = dbCodeSnippet.ContentCode;
                codeSnippetModel.IDCodeSnippet = dbCodeSnippet.IDCodeSnippet;
                codeSnippetModel.IDMember = dbCodeSnippet.IDMember;
                codeSnippetModel.Title = dbCodeSnippet.Title;
                codeSnippetModel.Revision = dbCodeSnippet.Revision;

                return codeSnippetModel;
            }
            return null;
        }

        private CodeSnippet MapModelToDbObject(CodeSnippetModel codeSnippetModel)
        {
            CodeSnippet codeSnippet = new CodeSnippet();
            if(codeSnippetModel != null)
            {
                codeSnippet.ContentCode = codeSnippetModel.ContentCode;
                codeSnippet.IDCodeSnippet = codeSnippetModel.IDCodeSnippet;
                codeSnippet.IDMember = codeSnippetModel.IDMember;
                codeSnippet.Title = codeSnippetModel.Title;
                codeSnippet.Revision = codeSnippetModel.Revision;

                return codeSnippet;
            }
            return null;
        }

        public List<CodeSnippetModel> GetAll()
        {
            List<CodeSnippetModel> codeSnippets = new List<CodeSnippetModel>();
            foreach(CodeSnippet codeSnippet in dbContext.CodeSnippets)
            {
                codeSnippets.Add(MapObjectToModel(codeSnippet));
            }
            return codeSnippets;
        }
       
        public CodeSnippetModel GetById(Guid ID)
        {
            return MapObjectToModel(dbContext.CodeSnippets.FirstOrDefault(c => c.IDCodeSnippet == ID));

        }

        public void InsertCodeSnippet(CodeSnippetModel codeSnippetModel)
        {
            codeSnippetModel.IDCodeSnippet = Guid.NewGuid();
            dbContext.CodeSnippets.InsertOnSubmit(MapModelToDbObject(codeSnippetModel));
            dbContext.SubmitChanges();

        }

        public void UpdateCodeSnippet(CodeSnippetModel codeSnippetModel)
        {
            CodeSnippet codeSnippet = dbContext.CodeSnippets.FirstOrDefault(c => c.IDCodeSnippet == codeSnippetModel.IDCodeSnippet);
            if (codeSnippet !=null)
            {
                codeSnippet.ContentCode = codeSnippetModel.ContentCode;
                codeSnippet.IDCodeSnippet = codeSnippetModel.IDCodeSnippet;
                codeSnippet.IDMember = codeSnippetModel.IDMember;
                codeSnippet.Title = codeSnippetModel.Title;
                codeSnippet.Revision = codeSnippetModel.Revision;
                dbContext.SubmitChanges();
            }
        }

        public void Delete(Guid ID)
        {
            CodeSnippet codeSnippet = dbContext.CodeSnippets.FirstOrDefault(c => c.IDCodeSnippet == ID);
            if(codeSnippet != null)
            {
                dbContext.CodeSnippets.DeleteOnSubmit(codeSnippet);
                dbContext.SubmitChanges();
            }
        }
    }
}