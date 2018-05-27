namespace D2Blog.Migrations
{
    using D2Blog.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<D2Blog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(D2Blog.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var RoleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            var Moderator = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                RoleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                RoleManager.Create(new IdentityRole { Name = "Moderator" });
            }

            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            var userModerator = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "wr1t3him@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "wr1t3him@gmail.com",
                    Email = "wr1t3him@gmail.com",
                    Firstname = "Wilten",
                    Lastname = "Houston",
                    Displayname = "Wilten-Clear-Skies-Houston"
                }, "Byakugan301!");

                var userID = userManager.FindByEmail("wr1t3him@gmail.com").Id;
                userManager.AddToRole(userID, "Admin");
            }
       if (!context.Users.Any(u => u.Email == "ColeTrain@maillinator.com"))
            {
                userModerator.Create(new ApplicationUser
                {
                    UserName = "ColeTrain@maillinator.com",
                    Email = "ColeTrain@maillinator.com",
                    Firstname = "Tyrell",
                    Lastname = "Coleman",
                    Displayname = "Tyrell-CoalTrain-Coleman"
                }, "Neji301!");

                var userID = userManager.FindByEmail("ColeTrain@maillinator.com").Id;
userManager.AddToRole(userID, "Moderator");
            }
        }
    }
}

