using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Data
{
public  class DbApplicationContext:DbContext
{

    public DbApplicationContext(DbContextOptions<DbApplicationContext> options):base(options)
    {
        
    }
    public DbSet<Todo> Todos{get;set;}
}
    
}