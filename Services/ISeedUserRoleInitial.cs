using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaMVC_lanches.Services
{
    public interface ISeedUserRoleInitial
    {
        void SeedRoles();
        void SeedUsers();
    }
}