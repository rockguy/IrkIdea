﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Queste.Models
{
    public class Context:DbContext
    {
        public DbSet<Quest> Quests { get; set; }
    }
}