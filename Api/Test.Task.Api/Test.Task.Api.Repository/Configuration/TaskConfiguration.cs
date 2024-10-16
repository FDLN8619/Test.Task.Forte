using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Task.Api.Domain.Entities;

namespace Test.Task.Api.Repository.Configuration
{
    public class TaskConfiguration : IEntityTypeConfiguration<ETask>
    {
        public void Configure(EntityTypeBuilder<ETask> builder)
        {
            throw new NotImplementedException();
        }
    }
}
