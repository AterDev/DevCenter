namespace Core.Models
{
    public class NavigationGroup : EntityBase
    {
        [MaxLength(50)]
        public string Name { get; set; } = default!;

        public List<Navigation>? Navigations { get; set; }
    }

}
