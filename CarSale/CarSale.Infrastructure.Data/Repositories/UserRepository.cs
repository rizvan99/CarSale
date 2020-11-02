using CarSale.Core.Domain_Service.Interface;
using CarSale.Core.Entity.Login;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarSale.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CarSaleContext _ctx;

        public UserRepository(CarSaleContext ctx)
        {
            _ctx = ctx;
        }

        public void AddUser(User entity)
        {
            _ctx.Users.Add(entity);
            _ctx.SaveChanges();
        }

        public void EditUser(User entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            _ctx.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _ctx.Users.ToList();
        }

        public User GetUser(long id)
        {
            return _ctx.Users.FirstOrDefault(u => u.Id == id);
        }

        public void RemoveUser(long id)
        {
            _ctx.Remove(GetUser(id));
            _ctx.SaveChanges();
        }
    }
}
