﻿using Abp.Modules.Core.Entities.NHibernate.Mappings;
using Taskever.Users;

namespace Taskever.Entities.NHibernate.Mappings
{
    public class TaskeverUserMap : UserMap<TaskeverUser>
    {
        public TaskeverUserMap()
        {
            Map(x => x.TaskField);
        }
    }
}
