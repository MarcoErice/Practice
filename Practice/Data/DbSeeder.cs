using Microsoft.AspNetCore.Identity;
using Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Data
{
    public class DbSeeder
    {
        public static void Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (!context.Roles.Any())
            {
                var admin = new IdentityRole { Name = "Admin" };
                var result = roleManager.CreateAsync(admin);
            }

            if (!context.Users.Any())
            {
                var user = new ApplicationUser { UserName = "student@test.com", Email = "student@test.com" };
                var result = userManager.CreateAsync(user, "Pa$$w0rd").Result;
                var roleResult = userManager.AddToRoleAsync(user, "Admin").Result;
            }
            // Look for any Artist.
            if (context.Artist.Any())
            {
                return;   // DB has been seeded
            }

            var aArtist = new Artist
            {
                Name = "Shakira"                
            };
            var bArtist = new Artist
            {
                Name = "Americo"                
            };
            context.Artist.AddRange(aArtist);
            context.Artist.AddRange(bArtist);
            
            // Look for any Songs.
            if (context.Songs.Any())
            {
                return;   // DB has been seeded
            }
            context.Songs.AddRange(
                new Song
                {
                    Title = "Loca",
                    Artist = aArtist
                },
                new Song
                {
                    Title = "Ojos así",
                    Artist = aArtist
                },
                  new Song
                  {
                      Title = "Traicionera",
                      Artist = bArtist
                  },
                new Song
                {
                    Title = "Te vas",
                    Artist = bArtist
                }
            );
            context.SaveChanges();
        }
    }
}
