using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Personal_Info_CRUD.Models
{
    public class PersonalInfoViewModel
    {
        [Key]
        public int SL { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public DateTime DataInsertTime { get; set; }
        
    }
}