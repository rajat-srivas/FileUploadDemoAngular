using FileUpload_API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FileUpload_API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("Upload")]
    public class UploadController : ApiController
    {
        Upload_EDMX context = new Upload_EDMX();
        [HttpPost]

        public void CreateUserWithAttachment()
        {

            var httpRequest = HttpContext.Current.Request;
            var files = httpRequest.Files;
            var userDetail = JsonConvert.DeserializeObject<UserDetail>(httpRequest.Form["Details"]);
            var image = files[0] != null ? files[0] : null;
            var resume = files[1] != null ? files[1] : null;

            context.UserDetails.Add(userDetail);
            context.SaveChanges();

            if(image != null)
            {
                UploadImage(image,userDetail.Id);
            }

            if(resume != null)
            {
                UploadResume(resume, userDetail.Id);
            }
        }

        [HttpGet]
        public IEnumerable<UserDetail> GetDetails()
        {
            var details =  (from user in context.UserDetails
                           join profile in context.ProfileImages
                           on user.Id equals profile.UserId
                           join resume in context.Resumes
                           on user.Id equals resume.UserId
                           select new
                           {
                               FirstName = user.FirstName,
                               LastName = user.LastName,
                               Email = user.Email,
                               Phone = user.Phone,
                               Image = profile.StorageName,
                               Resume = resume.ResumeFileName,
                               ResumeStorage = resume.StorageName

                           }

                           ).ToList().Select(x=> new UserDetail()
                           {
                               FirstName = x.FirstName,
                               LastName = x.LastName,
                               Email = x.Email,
                               Phone = x.Phone,
                               Image = x.Image,
                               Resume = x.Resume,
                               ResumeStorage = x.ResumeStorage

                           })
                           ;

            return details;
        }

        private void UploadResume(HttpPostedFile resume, int id)
        {
            string resumeName  = GenerateRandomFileName(resume);
            var PathToSave = HttpContext.Current.Server.MapPath("/Attachments/" + resumeName);

            resume.SaveAs(PathToSave);

            Resume obj = new Resume();
            obj.ResumeFileName = resume.FileName;
            obj.StorageName = resumeName;
            obj.UserId = id;

            context.Resumes.Add(obj);
            context.SaveChanges();
        }

        private static string GenerateRandomFileName(HttpPostedFile file)
        {
            Guid guid = Guid.NewGuid();

            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            fileName = fileName + "_" + guid + Path.GetExtension(file.FileName);

            return fileName;
        }

        private void UploadImage(HttpPostedFile image, int id)
        {
            string imageName = GenerateRandomFileName(image);
            var PathToSave = HttpContext.Current.Server.MapPath("/Attachments/" + imageName);

            image.SaveAs(PathToSave);

            ProfileImage obj = new ProfileImage();
            obj.ImageFileName = image.FileName;
            obj.StorageName = imageName;
            obj.UserId = id;

            context.ProfileImages.Add(obj);
            context.SaveChanges();
        }
    }
}
