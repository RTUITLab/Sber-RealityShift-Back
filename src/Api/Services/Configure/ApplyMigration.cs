using Database;
using Microsoft.EntityFrameworkCore;
using RTUITLab.AspNetCore.Configure.Configure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Services.Configure
{
    public class ApplyMigration : IConfigureWork
    {
        private readonly SberDbContext sberDbContext;

        public ApplyMigration(SberDbContext sberDbContext)
        {
            this.sberDbContext = sberDbContext;
        }
        public Task Configure(CancellationToken cancellationToken)
        {
            return sberDbContext.Database.MigrateAsync();
        }
    }
}
