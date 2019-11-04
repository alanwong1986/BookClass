using BookClassSimple.Controllers;
using BookClassSimple.Models;
using BookClassSimple.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace NUnitTestBookClass
{
    public class FakeSignInManager : SignInManager<IdentityUser>
    {
        public FakeSignInManager()
                : base(new FakeUserManager(),
                     new Mock<IHttpContextAccessor>().Object,
                     new Mock<IUserClaimsPrincipalFactory<IdentityUser>>().Object,
                     new Mock<IOptions<IdentityOptions>>().Object,
                     new Mock<ILogger<SignInManager<IdentityUser>>>().Object,
                     new Mock<IAuthenticationSchemeProvider>().Object)
        { }

        public override async Task SignOutAsync()
        {
            return;
        }

        public override async Task<Microsoft.AspNetCore.Identity.SignInResult> PasswordSignInAsync(IdentityUser user, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return Microsoft.AspNetCore.Identity.SignInResult.Success;
        }
    }

    public class FakeUserManager : UserManager<IdentityUser>
    {
        public FakeUserManager()
            : base(new Mock<IUserStore<IdentityUser>>().Object,
              new Mock<IOptions<IdentityOptions>>().Object,
              new Mock<IPasswordHasher<IdentityUser>>().Object,
              new IUserValidator<IdentityUser>[0],
              new IPasswordValidator<IdentityUser>[0],
              new Mock<ILookupNormalizer>().Object,
              new Mock<IdentityErrorDescriber>().Object,
              new Mock<IServiceProvider>().Object,
              new Mock<ILogger<UserManager<IdentityUser>>>().Object)
        { }



        public override Task<IdentityResult> CreateAsync(IdentityUser user, string password)
        {
            return Task.FromResult(IdentityResult.Success);
        }


        public override Task<IdentityUser> FindByEmailAsync(string email)
        {
            return Task.FromResult(new IdentityUser());
        }

        public override Task<IList<string>> GetRolesAsync(IdentityUser user)
        {
            return Task.FromResult<IList<string>>(new List<string>());
        }

        public override Task<IdentityUser> GetUserAsync(ClaimsPrincipal principal)
        {
            IdentityUser user = new IdentityUser()
            {
                Id = "1",
                Email = "test@gmail.com",
                UserName = "test@gmail.com",
                PasswordHash = "Test@1234"
            };
            return Task.FromResult(user);
        }
    }

    public class FakebookClassContext : bookclassContext
    {
        public FakebookClassContext()
            : base()
        { }

        public FakebookClassContext(DbContextOptions<bookclassContext> options)
            : base(options)
        { }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return 1;
        }
        public override int SaveChanges()
        {
            return 1;
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return Task.FromResult<int>(1);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult<int>(1);
        }

        public override EntityEntry Remove(object entity)
        {
            return null;
        }

        public override EntityEntry<TEntity> Remove<TEntity>(TEntity entity)
        {
            return null;
        }

        public override void RemoveRange(IEnumerable<object> entities)
        {

        }

        public override void RemoveRange(params object[] entities)
        {

        }
    }

    public class FakeCourseCommentRepository : CourseCommentRepository
    {
        public FakeCourseCommentRepository()
            : base(new FakebookClassContext(new DbContextOptionsBuilder<bookclassContext>()
                .UseSqlServer("Server=AlanWong-PC\\SQLExpress;Database=bookclass;Trusted_Connection=True;User=dbuser;Password=123456").Options), 
                  new Mock<ILogger<CourseCommentRepository>>().Object)
        {
        }
    }

    public class FakeCourseRepository : CourseRepository
    {
        public FakeCourseRepository()
            : base(new FakebookClassContext(new DbContextOptionsBuilder<bookclassContext>()
                .UseSqlServer("Server=AlanWong-PC\\SQLExpress;Database=bookclass;Trusted_Connection=True;User=dbuser;Password=123456").Options), 
                new Mock<ILogger<CourseRepository>>().Object, new Mock<IHostingEnvironment>().Object)
        { }

    }
}
