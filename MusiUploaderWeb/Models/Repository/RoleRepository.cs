using MusiUploaderWeb.Interfaces;
using MusiUploaderWeb.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusiUploaderWeb.Models.Repository
{
    public class RoleRepository : IRoleRepository, IDisposable
    {
        private MusicEntities context;

        public RoleRepository(MusicEntities context)
        {
            this.context = context;
        }

        public IEnumerable<LookupRole> GetAllRoles()
        {
            var roles = context.LookupRoles.ToList();
            return roles;
        }

        public LookupRole GetRoleByName(string roleName)
        {
            var role = context.LookupRoles.Where(r => r.RoleName == roleName).FirstOrDefault();
            return role;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}