using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace ITDocumentation.Classes
{
    public class SearchResult
    {
        public int ID {get;set;}
        public string Type { get; set; }
        public string Name { get; set; }
       
    }
}
