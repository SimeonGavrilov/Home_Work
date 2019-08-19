using System;
using System.Collections.Generic;
using System.Text;
using Users.DAL;
using Users.Entities;

namespace Users.Common
{
    public static class Dependensies
    {
        public static IUsersStorage UserStorage { get; } = new MemoryStorage();
    }
}
