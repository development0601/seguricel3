using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguricel3
{
    public class DataContext : DbContext
    {

        public DataContext()
            : base("SeguricellEntities")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<tblUsuario>()
            //.HasMany(u => u.tblUsuarioUnidadOrganizativa)
            ////.Map(m =>
            //{
            //    m.ToTable("UserRoles");
            //    m.MapLeftKey("UserId");
            //    m.MapRightKey("RoleId");
            //});
        }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
    }
}
