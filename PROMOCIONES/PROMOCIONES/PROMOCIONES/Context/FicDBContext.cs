using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using PROMOCIONES.Models;
using Microsoft.EntityFrameworkCore;

namespace PROMOCIONES.Context
{
    class FicDBContext : DbContext
    {
        public DbSet<ce_cat_promociones> ce_cat_promociones { get; set; }

        protected async override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                #region promociones
                modelBuilder.Entity<ce_cat_promociones>()
                    .HasKey(c => new { c.IdPromocion });
                #endregion
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA",e.ToString(),"OK");
            }
        }
    }
}
