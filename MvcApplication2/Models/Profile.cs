using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Queste.Models;

namespace Queste.Models
{
    public class Profile
    {
        public int Id { get; set; }

        // Внешний ключ для связи с пользователем
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}