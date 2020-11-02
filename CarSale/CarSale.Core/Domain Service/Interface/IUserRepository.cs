using CarSale.Core.Entity.Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarSale.Core.Domain_Service.Interface
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAllUsers();

        public User GetUser(long id);

        public void AddUser(User entity);

        public void EditUser(User entity);

        public void RemoveUser(long id);

    }
}
