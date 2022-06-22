using System;
using System.Threading.Tasks;
using HotelListing.Domain;

namespace HotelListing.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<Hotel> Hotels { get; }
        IGenericRepository<ApiUser> Users { get; }
        Task Save();
    }
}