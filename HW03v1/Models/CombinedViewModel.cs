using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW03v1.Models
{
    public class CombinedViewModel
    {        
        public IEnumerable<students> studentsList { get; set; }
        public IEnumerable<books> bookList { get; set;}
        public IEnumerable<borrows> borrowsList { get; set; }
        public IEnumerable<authors> authorList { get; set; }
        public IEnumerable<types> typesList { get; set; }
    }
}