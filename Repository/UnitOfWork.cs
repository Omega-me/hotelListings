﻿using System;
using System.Threading.Tasks;
using HotelListing.Domain;
using HotelListing.IRepository;

namespace HotelListing.Repository {
    public class UnitOfWork:IUnitOfWork {
        
        private readonly DatabaseContext _context;
        
        private IGenericRepository<Country> _countries;
        private IGenericRepository<Hotel> _hotels;
        private IGenericRepository<ApiUser> _users;

        public UnitOfWork(DatabaseContext context) {
            _context = context;
        }
        public IGenericRepository<Country> Countries => _countries ??= new GenericRepository<Country>(_context);
        public IGenericRepository<Hotel> Hotels => _hotels ??= new GenericRepository<Hotel>(_context);
        public IGenericRepository<ApiUser> Users => _users ??= new GenericRepository<ApiUser>(_context);


        public void Dispose() {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }


        public async Task Save() {
            await _context.SaveChangesAsync();
        }
    }
}