namespace FileUpload_API
{
    using System;
    using System.Data.Entity;
    using FileUpload_API.Models;
    using System.Linq;

    public class Upload_EDMX : DbContext
    {
        // Your context has been configured to use a 'Upload_EDMX' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FileUpload_API.Upload_EDMX' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Upload_EDMX' 
        // connection string in the application configuration file.
        public Upload_EDMX()
            : base("name=Upload-EDMX")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<ProfileImage> ProfileImages { get; set; }

        public virtual DbSet<Resume> Resumes { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}