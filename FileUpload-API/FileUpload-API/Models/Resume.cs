using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUpload_API.Models
{
    public class Resume
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string ResumeFileName { get; set; }

        public string StorageName { get; set; }
    }
}