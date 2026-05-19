using APBDCW07.Models;
using Microsoft.EntityFrameworkCore;

namespace APBDCW07.Infrastrucutre;

public class DatabaseContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<ComponentManufacturers> ComponentManufacturers { get; set; }
    public DbSet<Components> Components { get; set; }
    public DbSet<ComponentTypes> ComponentTypes { get; set; }
    public DbSet<PCComponents> PCComponents { get; set; }
    public DbSet<PCs> PCs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<PCs>().HasData([
            new PCs
            {
                Id = 1,
                Name = "Biurowy Standard",
                Weight = 7.5f,
                Warranty = 24,
                CreatedAt = new DateTime(2026, 1, 15, 10, 0, 0),
                Stock = 15
            },
            new PCs
            {
                Id = 2,
                Name = "Bestia Gamingowa X",
                Weight = 12.3f,
                Warranty = 36,
                CreatedAt = new DateTime(2026, 3, 22, 14, 30, 0),
                Stock = 5
            },
            new PCs
            {
                Id = 3,
                Name = "Mini PC Home",
                Weight = 1.8f,
                Warranty = 12,
                CreatedAt = new DateTime(2026, 5, 19, 18, 0, 0),
                Stock = 50
            }
        ]);

        modelBuilder.Entity<ComponentTypes>().HasData([
            new ComponentTypes
            {
                Id = 1,
                Abbreviation = "CPU",
                FullName = "Central Processing Unit"
            },
            new ComponentTypes
            {
                Id = 2,
                Abbreviation = "GPU",
                FullName = "Graphics Processing Unit"
            },
            new ComponentTypes
            {
                Id = 3,
                Abbreviation = "RAM",
                FullName = "Random Access Memory"
            }
        ]);

        modelBuilder.Entity<ComponentManufacturers>().HasData([
            new ComponentManufacturers
            {
                Id = 1,
                Abbreviation = "INTC",
                FullName = "Intel Corporation",
                FoundationDate = new DateOnly(1968, 7, 18)
            },
            new ComponentManufacturers
            {
                Id = 2,
                Abbreviation = "NVDA",
                FullName = "NVIDIA Corporation",
                FoundationDate = new DateOnly(1993, 4, 5)
            },
            new ComponentManufacturers
            {
                Id = 3,
                Abbreviation = "AMD",
                FullName = "Advanced Micro Devices",
                FoundationDate = new DateOnly(1969, 5, 1)
            }
        ]);

        modelBuilder.Entity<Components>().HasData([
            new Components
            {
                Code = "CPU-INT-01",
                Name = "Intel Core i7-14700K",
                Description = "Procesor 20-rdzeniowy, taktowanie do 5.6 GHz.",
                ComponentManufacturersId = 1,
                ComponentTypesId = 1
            },
            new Components
            {
                Code = "GPU-NVD-02",
                Name = "NVIDIA GeForce RTX 4070 Ti",
                Description = "Karta graficzna z 12GB pamięci GDDR6X.",
                ComponentManufacturersId = 2,
                ComponentTypesId = 2
            },
            new Components
            {
                Code = "RAM-AMD-03",
                Name = "AMD Expo DDR5 32GB",
                Description = "Pamięć RAM zoptymalizowana pod procesory AMD.",
                ComponentManufacturersId = 3,
                ComponentTypesId = 3
            }
        ]);

        modelBuilder.Entity<PCComponents>().HasData([
            new PCComponents
            {
                PCId = 1,
                ComponentCode = "CPU-INT-01",
                Amount = 1
            },
            new PCComponents
            {
                PCId = 2,
                ComponentCode = "GPU-NVD-02",
                Amount = 1
            },
            new PCComponents
            {
                PCId = 2,
                ComponentCode = "RAM-AMD-03",
                Amount = 2
            }
        ]);
    }
}