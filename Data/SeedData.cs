using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Data
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Crear ROLES
            List<IdentityRole> roles = new List<IdentityRole>() {
                new IdentityRole { Name = RolesList.Admin},
                new IdentityRole { Name = RolesList.Moderator},
                new IdentityRole { Name = RolesList.User}
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);

            // Crear USERS
            List<AppUser> users = new List<AppUser>() {
                new AppUser {
                    Name = "Admin",
                    UserName = "admin@blogproject.com",
                    NormalizedUserName = "ADMIN@BLOGPROJECT.COM",
                    Email = "admin@blogproject.com",
                    NormalizedEmail = "ADMIN@BLOGPROJECT.COM"
                },
                new AppUser
                {
                    Name = "Moderator",
                    UserName = "moderator@blogproject.com",
                    NormalizedUserName = "MODERATOR@BLOGPROJECT.COM",
                    Email = "moderator@blogproject.com",
                    NormalizedEmail = "MODERATOR@BLOGPROJECT.COM"
                    
                }
            };
            modelBuilder.Entity<AppUser>().HasData(users);

            // Agregar contraseña a los usuarios
            var passwordHasher = new PasswordHasher<AppUser>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "HelloWorld@0");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "HelloWorld@0");
           

            // Agregar roles a usuario
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == RolesList.Admin).Id
            });
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[1].Id,
                RoleId = roles.First(q => q.Name == RolesList.Moderator).Id
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);

        }
    }
}
