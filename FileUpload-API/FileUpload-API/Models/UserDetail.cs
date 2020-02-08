using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileUpload_API.Models
{
    public class UserDetail
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long Phone { get; set; }

        public string Email { get; set; }

        [NotMapped]
        public string Image { get; set; }

        [NotMapped]
        public string Resume { get; set; }

        [NotMapped]
        public string ResumeStorage { get; set; }
    }
}