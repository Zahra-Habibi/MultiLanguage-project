using MultiLanguage.Core.PublicClasses.Repository.Services;
using Multipisus.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLanguage.Core.PublicClasses.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        GenericClass<ApplicationUser> UsermanagerUW { get; }
        Task saveAsync();
        void Dispose();
    }
}
