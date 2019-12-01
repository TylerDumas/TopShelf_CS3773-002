using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using TopShelfCustomer.Api.Models;

namespace TopShelfCustomer.Api.Services {
    public class UserDbContext : DbContext {

        public UserDbContext ( DbContextOptions<UserDbContext> options )
        : base( options ) { }

        public DbSet<UserDbModel> Users { get; set; }
    }
}
