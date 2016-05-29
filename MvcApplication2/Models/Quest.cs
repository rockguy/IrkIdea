using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Metadata;
using System.ComponentModel.DataAnnotations;
using Queste.Models;
using System.Web.Mvc;


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
        public string Question { get; set; }
        public string Answear { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Type { get; set; }
        public TypeOfQuest TypeOfQuest { get; set; }
      
    }

    public class UserQuest 
    {
        [Key]
        public int ID { get; set; }
        public int UserId { get; set; }
        public int QuestId { get; set; }
        public User User { get; set; }
        public Quest Quest { get; set; }
    }

    public class TypeOfQuest 
    {
        [Key]
        public int Id { get; set; }
        public String Title { get; set; }

    }


}