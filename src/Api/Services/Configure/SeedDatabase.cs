using Api.Models.Options;
using Database;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Models;
using RTUITLab.AspNetCore.Configure.Configure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Services.Configure
{
    public class SeedDatabase : IConfigureWork
    {
        private readonly SberDbContext dbContext;
        private readonly IOptions<SeedDataOptions> optinos;

        public SeedDatabase(SberDbContext dbContext, IOptions<SeedDataOptions> optinos)
        {
            this.dbContext = dbContext;
            this.optinos = optinos;
        }
        public async Task Configure(CancellationToken cancellationToken)
        {
            foreach (var lang in optinos.Value.Langs)
            {
                if (await dbContext.Courses.AnyAsync(c => c.Title == lang))
                {
                    continue;
                }
                dbContext.Courses.Add(new Course { Title = lang });
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
