using MultiLanguage.Core.PublicClasses.Repository.Interfaces;
using MultiLanguage.DataLayer.Context;
using Multipisus.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLanguage.Core.PublicClasses.Repository.Services
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        private GenericClass<ApplicationUser> _usermanager;

        //for user
        public GenericClass<ApplicationUser> UsermanagerUW
        {
            get
            {
                if (_usermanager == null)
                {
                    _usermanager = new GenericClass<ApplicationUser>(_context);
                }
                return _usermanager;
            }
        }
        public async Task saveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
