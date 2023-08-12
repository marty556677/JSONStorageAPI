using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JSONStorageAPI.Models;

namespace JSONStorageAPI.Data
{
    public class JSONStorageAPIContext : DbContext
    {
        public JSONStorageAPIContext (DbContextOptions<JSONStorageAPIContext> options)
            : base(options)
        {
        }

        public DbSet<JSONStorageAPI.Models.JSONFile> JSONFiles { get; set; } = default!;
    }
}
