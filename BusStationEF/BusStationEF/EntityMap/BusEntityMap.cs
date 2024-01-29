using BusStationEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusStationEF.EntityMap
{
    public class BusEntityMap : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
          builder.HasMany(_ => _.JourneySeats)
            .WithOne(_ => _.Bus)
            .HasForeignKey(_ => _.BusId)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
