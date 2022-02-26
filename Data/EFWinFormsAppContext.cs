using EFWinFormsApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFWinFormsApp.Data
{
    public class EFWinFormsAppContext : DbContext
    {
        public EFWinFormsAppContext() : base()
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
