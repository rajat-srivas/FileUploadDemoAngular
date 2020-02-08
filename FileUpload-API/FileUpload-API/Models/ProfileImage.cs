using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FileUpload_API.Models
{
    public class ProfileImage
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string ImageFileName { get; set; }

        public string StorageName { get; set; }
    }
}