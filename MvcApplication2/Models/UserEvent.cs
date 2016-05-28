using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Metadata;
using System.ComponentModel.DataAnnotations;
using Queste.Models;


namespace Queste.Models
{
    public class Quest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Owner { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Answear { get; set; }
        public User User { get; set; }


    }
}