﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SWE_webapi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Release { get; set; }
        public int AuthorId { get; set; }

    }
}
