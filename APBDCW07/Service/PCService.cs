using APBDCW07.DTOs;
using APBDCW07.Exceptions;
using APBDCW07.Infrastrucutre;
using APBDCW07.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace APBDCW07.Service;

public class PCService(DatabaseContext ctx) : IPCService
{
    public async Task<IEnumerable<PCResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await ctx.PCs.Select(st => new PCResponse(
            st.Id,
            st.Name,
            st.Weight,
            st.Warranty,
            st.CreatedAt,
            st.Stock
        )).ToListAsync(cancellationToken);
    }

    public async Task<PCDetailsResponse> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await ctx.PCs
            .Where(e => e.Id == id)
            .Select(st => new PCDetailsResponse(
                st.Id,
                st.Name,
                st.Weight,
                st.Warranty,
                st.CreatedAt,
                st.Stock,
                st.PCComponents.Select(sc => new PCComponentsResponse(
                    sc.Amount,
                    new ComponentResponse(
                        sc.Component.Code,
                        sc.Component.Name,
                        sc.Component.Description,
                        new ManufacturerResponse(
                            sc.Component.ComponentManufacturersId,
                            sc.Component.ComponentManufacturer.Abbreviation,
                            sc.Component.ComponentManufacturer.FullName,
                            sc.Component.ComponentManufacturer.FoundationDate
                        ),
                        new ComponentTypeResponse(
                            sc.Component.ComponentTypesId,
                            sc.Component.ComponentType.Abbreviation,
                            sc.Component.ComponentType.FullName
                        )
                    )
                )).ToList()
            ))
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new NotFoundException($"PC with ID {id} does not exist");
    }

    public async Task<PCResponse> AddAsync(CreatePCRequest request, CancellationToken cancellationToken)
    {
        var pc = new PCs
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock
        };
        
        ctx.Add(pc);
        await ctx.SaveChangesAsync(cancellationToken);
        
        return new PCResponse(pc.Id ,pc.Name, pc.Weight, pc.Warranty, pc.CreatedAt, pc.Stock);
    }

    public async Task UpdateAsync(int id, UpdatePCRequest request, CancellationToken cancellationToken)
    {
        var pc = await ctx.PCs.FirstOrDefaultAsync(pc => pc.Id == id, cancellationToken);
        if (pc is null)
        {
            throw new NotFoundException($"PC with ID {id} does not exist");
        }

        pc.Name = request.Name;
        pc.Weight = request.Weight;
        pc.Warranty = request.Warranty;
        pc.CreatedAt = request.CreatedAt;
        pc.Stock = request.Stock;
        await ctx.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var pc = await ctx.PCs.FirstOrDefaultAsync(pc => pc.Id == id, cancellationToken);
        if (pc is null)
        {
            throw new NotFoundException($"PC with ID {id} does not exist");
        }
        
        ctx.PCs.Remove(pc);
        await ctx.SaveChangesAsync(cancellationToken);
    }
}
