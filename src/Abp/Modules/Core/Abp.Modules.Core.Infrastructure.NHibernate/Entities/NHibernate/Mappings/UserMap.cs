﻿using Abp.Security.Users;

namespace Abp.Modules.Core.Entities.NHibernate.Mappings
{
    public abstract class UserMap<TUser> : EntityMap<TUser> where TUser : User
    {
        protected UserMap()
            : base("AbpUsers")
        {
            Map(x => x.UserName);
            Map(x => x.Name);
            Map(x => x.Surname);
            Map(x => x.EmailAddress);
            Map(x => x.IsEmailConfirmed);
            Map(x => x.EmailConfirmationCode);
            Map(x => x.Password);
            Map(x => x.PasswordResetCode);
            Map(x => x.ProfileImage);
            Map(x => x.IsTenantOwner);
        }
    }

    public class UserMap : UserMap<User>
    {

    }
}
