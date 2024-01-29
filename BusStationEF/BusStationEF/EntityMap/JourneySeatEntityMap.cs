using BusStationEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStationEF.EntityMap
{
    public class JourneySeatEntityMap : IEntityTypeConfiguration<JourneySeat>
    {
        public void Configure(EntityTypeBuilder<JourneySeat> builder)
        {
            builder.HasMany(_ => _.Seats)
              .WithOne(_ => _.JourneySeat)
              .HasForeignKey(_ => _.JourneySeatId)
              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
