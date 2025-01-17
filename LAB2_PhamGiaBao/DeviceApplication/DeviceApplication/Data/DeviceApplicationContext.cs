using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DeviceApplication.Models;

namespace DeviceApplication.Data
{
    public class DeviceApplicationContext : DbContext
    {
        public DeviceApplicationContext (DbContextOptions<DeviceApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<DeviceApplication.Models.Category> Category { get; set; } = default!;
        public DbSet<DeviceApplication.Models.Device> Device { get; set; } = default!;
    }
}
