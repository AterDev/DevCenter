using Http.Application.Implement;
using Share.Models.ConfigOptionDtos;
namespace Http.Application.DataStore;
public class ConfigOptionDataStore : DataStoreBase<ContextBase, ConfigOption, ConfigOptionUpdateDto, ConfigOptionFilterDto, ConfigOptionItemDto>
{
    public ConfigOptionDataStore(ContextBase context, IUserContext userContext, ILogger<ConfigOptionDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override async Task<List<ConfigOptionItemDto>> FindAsync(ConfigOptionFilterDto filter, bool noTracking = true)
    {
        return await base.FindAsync(filter, noTracking);
    }

    public override async Task<PageList<ConfigOptionItemDto>> FindWithPageAsync(ConfigOptionFilterDto filter)
    {
        return await base.FindWithPageAsync(filter);
    }
    public override async Task<ConfigOption> AddAsync(ConfigOption data)
    {
        return await base.AddAsync(data);
    }

    public override async Task<ConfigOption?> UpdateAsync(Guid id, ConfigOptionUpdateDto dto)
    {
        return await base.UpdateAsync(id, dto);
    }

    public override async Task<bool> DeleteAsync(Guid id)
    {
        return await base.DeleteAsync(id);
    }
}
