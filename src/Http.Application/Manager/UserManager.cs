namespace Http.Application.Manager
{
    public class UserManager : DomainManagerBase<User>, IUserManager
    {
        public UserManager(DataStoreContext storeContext) : base(storeContext)
        {

        }
    }
}
