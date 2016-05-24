using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Metadata;


namespace IrkIdea.Models
{
    public class UserEvent:DbContext
    {
        
        public int Id { get; set; }
        public string What { get; set; }
        public string Where { get; set; }
        public DateTime When { get; set; }
        public DateTime DateOfCreating { get; set; }


    }
}