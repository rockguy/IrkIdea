using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Metadata;
using System.ComponentModel.DataAnnotations;
using Queste.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace Queste.Models
{
 

    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserName{get;set;}
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        
        [ForeignKey("Role")]
        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }

    public class Role
    {
        [Key]      
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}