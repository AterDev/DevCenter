using Http.Application.Implement;
using Share.Models.EnvironmentDtos;

using Environment = Core.Entities.Environment;

namespace Http.Application.DataStore;
public class EnvironmentDataStore : DataStoreBase<ContextBase, Environment, EnvironmentUpdateDto, EnvironmentFilterDto, EnvironmentItemDto>
{
    public EnvironmentDataStore(ContextBase context, IUserContext userContext, ILogger<EnvironmentDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override async Task<List<EnvironmentItemDto>> FindAsync(EnvironmentFilterDto filter, bool noTracking = true)
    {
        return await base.FindAsync(filter, noTracking);
    }

    public override async Task<PageList<EnvironmentItemDto>> FindWithPageAsync(EnvironmentFilterDto filter)
    {
        return await base.FindWithPageAsync(filter);
    }
    public override async Task<Environment> AddAsync(Environment data)
    {
        return await base.AddAsync(data);
    }

    public override async Task<Environment?> UpdateAsync(Guid id, EnvironmentUpdateDto dto)
    {
        return await base.UpdateAsync(id, dto);
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        return await base.DeleteAsync(id);
    }
}
