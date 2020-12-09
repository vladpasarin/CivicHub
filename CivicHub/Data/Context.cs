using CivicHub.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CivicHub.Data
{
    public class Context : DbContext
    {
        //declar tabelele
        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssueState> IssueStates { get; set; }
        public DbSet<IssueStateComment> IssueStateComments { get; set; }
        public DbSet<IssueStateCommentPhoto> IssueStateCommentPhotos { get; set; }
        public DbSet<IssueStatePhoto> IssueStatePhotos { get; set; }
        public DbSet<IssueStateReaction> IssueStateReactions { get; set; }
        public DbSet<IssueStateVideo> IssueStateVideos { get; set; }
        //public DbSet<State> States { get; set; }
        public DbSet<User> Users { get; set; }

        //declar relatiile dintre tabele

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            // user 1 M issue

            builder.Entity<User>()
                .HasMany(x => x.Issues)
                .WithOne(y => y.User)
                .OnDelete(DeleteBehavior.NoAction);

            // issue 1 M issue states

            builder.Entity<Issue>()
                .HasMany<IssueState>(x => x.IssueStates)
                .WithOne(y => y.Issue)
                .OnDelete(DeleteBehavior.Cascade);

            /* 
             builder.Entity<IssueStateComment>()
                 .HasOne<IssueState>(x => x.IssueState)
                 .WithMany(y => y.IssueStateComments)
                 .OnDelete(DeleteBehavior.NoAction)
                 .HasForeignKey(z => z.IssueStateId);

             builder.Entity<IssueStateComment>()
                 .HasOne<User>(x => x.User)
                 .WithMany(y => y.IssueStateComments)
                 .HasForeignKey(z => z.UserId)
                 .OnDelete(DeleteBehavior.NoAction);*/

            // issue state 1 M issue state comments

            builder.Entity<IssueStateComment>()
                .HasOne(x => x.IssueState)
                .WithMany(y => y.IssueStateComments)
                .OnDelete(DeleteBehavior.Cascade);

            // user 1 M issue state comments

            builder.Entity<IssueStateComment>()
                .HasOne(x => x.User)
                .WithMany(y => y.IssueStateComments)
                .OnDelete(DeleteBehavior.NoAction);

            // issue state comment 1 M issue state comment photo
            builder.Entity<IssueStateComment>()
                .HasMany(x => x.IssueStateCommentPhotos)
                .WithOne(y => y.IssueStateComment)
                .OnDelete(DeleteBehavior.Cascade);

            // issue state 1 M issue state photo
            builder.Entity<IssueState>()
                .HasMany(x => x.IssueStatePhotos)
                .WithOne(y => y.IssueState)
                .OnDelete(DeleteBehavior.Cascade);

            // issue state 1 M issue state video
            builder.Entity<IssueState>()
                .HasMany(x => x.IssueStateVideos)
                .WithOne(y => y.IssueState)
                .OnDelete(DeleteBehavior.Cascade);

            // issue state M M user   (reaction)
            builder.Entity<IssueStateReaction>()
               .HasOne<IssueState>(x => x.IssueState)
               .WithMany(y => y.IssueStateReactions)
               .OnDelete(DeleteBehavior.Cascade)
               .HasForeignKey(z => z.IssueStateId);

            builder.Entity<IssueStateReaction>()
               .HasOne<User>(x => x.User)
               .WithMany(y => y.IssueStateReactions)
               .OnDelete(DeleteBehavior.NoAction)
               .HasForeignKey(z => z.UserId);

            //user mail unique
            builder.Entity<User>()
                .HasAlternateKey(x => x.Mail);

            //unique reaction of a user to a issue state
            builder.Entity<IssueStateReaction>()
                .HasAlternateKey(x => new { x.UserId, x.IssueStateId });

            //din proieect DAW laborator
            /*
                        // One to Many

                        builder.Entity<Model1>()
                            .HasMany(x => x.Models2)
                            .WithOne(y => y.Model1);
                        // To prevent optional relation
                        //.IsRequired();

                        // Different way to declare relation
                        //builder.Entity<Model2>()
                        //.HasOne(x => x.Model1)
                        //.WithMany(y => y.Models2);

                        // One to One
                        builder.Entity<Model5>()
                            .HasOne(x => x.Model6)
                            .WithOne(y => y.Model5)
                            .HasForeignKey<Model6>
                            (z => z.Model5Id);

                        // Many to Many
                        builder.Entity<ModelsRelation>()
                            .HasKey(mr =>
                            new { mr.Model3Id, mr.Model4Id });

                        builder.Entity<ModelsRelation>()
                            .HasOne<Model3>(x => x.Model3)
                            .WithMany(y => y.ModelRelations)
                            .HasForeignKey(z => z.Model3Id);

                        builder.Entity<ModelsRelation>()
                            .HasOne<Model4>(x => x.Model4)
                            .WithMany(y => y.ModelRelations)
                            .HasForeignKey(z => z.Model4Id);*/


            base.OnModelCreating(builder);
        }

    }
}
