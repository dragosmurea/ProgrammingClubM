using ProgrammingClubM.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgrammingClubM.Models.ViewModels
{
    public class MemberCodeSnippetsViewModel
    {
        public string Name { get; set; }


        public string Title { get; set; }

        public string Position { get; set; }

        public List<CodeSnippetModel> CodeSnippets = new List<CodeSnippetModel>();

    }
}