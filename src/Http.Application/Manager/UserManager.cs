namespace Http.Application.Manager
{
    public class UserManager : DomainManagerBase<User>
    {
        public UserManager(DataStoreContext storeContext) : base(storeContext)
        {
        }

    }
}
