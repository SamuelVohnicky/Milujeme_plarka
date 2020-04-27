using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milujeme_plarka.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Champion> Champions { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Summoner> Summoners { get; set; }
        public DbSet<Quest> Quests { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Champions
            builder.Entity<Champion>().HasData(new Champion { ChampionId = 1, ChampionName = "Aatrox", Mellee = true });

            //Items
            builder.Entity<Item>().HasData(new Item {ItemId = 1, ItemName = "Rabadon", Mellee = true });

            //Summoners
            builder.Entity<Summoner>().HasData(new Summoner { SummonerId = 1, SummonerName = "Heal" });

            //Quests
            builder.Entity<Quest>().HasData(new Quest { QuestGamePhase = 1, QuestId = 1, QuestQuote = "Chcipni", Role = 1 });

            //
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "Admin", Name = "Admin" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "User", Name = "Uživatel" });

            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "ADMINUSER",
                Email = "admin@admin.admin",
                NormalizedEmail = "ADMIN@ADMIN.ADMIN",
                EmailConfirmed = true,
                LockoutEnabled = false,
                UserName = "admin@admin.admin",
                NormalizedUserName = "ADMIN@ADMIN.ADMIN",
                PasswordHash = hasher.HashPassword(null, "Admin_1234"),
                SecurityStamp = string.Empty
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { RoleId = "Admin", UserId = "ADMINUSER" });
        }
        public ApplicationDbContext(DbContextOptions options) : base(options) { 
        }

    }
}
