﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        public string Logo { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }

        //Relationships
        public  List<Book> Books { get; set; }
    }
}