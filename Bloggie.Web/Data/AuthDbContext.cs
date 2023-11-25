using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Seed Roles(User,Admin,SuperAdmin)

            var adminRoleId = "5811453b-6a15-4bd0-82ca-fc98643dfb3b";
            var superAdminRoleId = "8518f0ce-cf65-4517-a2b9-2d8f50f1d5cd";
            var userRoleId = "1a98fd2f-687a-4c4e-93da-b787a8c0ff05";


            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name="Admin",
                    NormalizedName="Admin",
                    Id=adminRoleId,
                    ConcurrencyStamp= adminRoleId
                },
                new IdentityRole
                {
                    Name="SuperAdmin",
                    NormalizedName="SuperAdmin",
                    Id=superAdminRoleId,
                    ConcurrencyStamp=superAdminRoleId
                },
                new IdentityRole
                {
                    Name= "User",
                    NormalizedName = "User",
                    Id=userRoleId,
                    ConcurrencyStamp=userRoleId

                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
            //Seed SuperAdminUser

            var superAdminId = "823ff811-fe7b-4b83-84e2-330ba8905a23";
            var superAdminUser = new IdentityUser
            {
                UserName = "superadmin@bloggie.com",
                Email = "superadmin@bloggie.com",
                NormalizedEmail = "superadmin@bloggie.com".ToUpper(),
                NormalizedUserName = "superadmin@bloggie.com".ToUpper(),
                Id = superAdminId
            };
            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(superAdminUser, "Superadmin@123");

            builder.Entity<IdentityUser>().HasData(superAdminUser);

            //Add All roles to SuperAdminUser
            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId =userRoleId,
                    UserId = superAdminId
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }

    }
}


    