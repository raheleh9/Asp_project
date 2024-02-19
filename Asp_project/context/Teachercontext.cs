using Asp_project.Models;
using Microsoft.EntityFrameworkCore;

namespace Asp_project.context
{
    public class Teachercontext:DbContext
    {

        #region Dbset
        public DbSet<Teacher> Teachers { get; set; }
        #endregion

        #region OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-3OJPR1O;Database=TeacherManagment_DB;Trusted_Connection=true;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        #endregion


    }
}
