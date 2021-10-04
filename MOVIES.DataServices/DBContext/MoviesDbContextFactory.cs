using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MOVIES.DataServices.DBContext
{
    public class MoviesDbContextFactory
    { 
    }
    //public class MoviesDbContextFactory: IDesignTimeDbContextFactory<MoviesDbContext>
    //{
    //    //public MoviesDbContext CreateDbContext(string[] args)
    //    //{
    //    //    IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../MyCookingMaster.API/appsettings.json").Build();
    //    //    var builder = new DbContextOptionsBuilder<MoviesDbContext>();
    //    //    var connectionString = configuration.GetConnectionString("DatabaseConnection");
    //    //    builder.UseSqlServer(connectionString);
    //    //    return new MoviesDbContext(builder.Options);
    //    //}
    //}
}
