using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersManagement.API.Fake;
using UsersManagement.API.Models;

namespace UsersManagement.API.Controllers
{
    [Route("api/[controller]")] //url de hangi controllar yazarsa onla eşleşir
    public class UsersController:ControllerBase 
    {
        private List<User> _users = FakeData.GetUsers(200);

        [HttpGet]
        public List<User> Get()
        {
            return _users;
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = _users.FirstOrDefault(x => x.ID == id);
            return user;
        }

        [HttpPost]
        public User Post([FromBody]User user) 
        {
            _users.Add(user);
            return user;
        }

        [HttpPut] //GÜNCELLEME
        public User Put([FromBody] User user)  
        {
            var editedUser = _users.FirstOrDefault(x => x.ID == user.ID);  
            editedUser.FirstName = user.FirstName;
            editedUser.LastName = user.LastName;
            editedUser.Adress = user.Adress;

            return user;
        }

        [HttpDelete("{id}")]

        public void Delete(int id)
        {
            var deletedUser = _users.FirstOrDefault(x => x.ID==id);
            _users.Remove(deletedUser);
        }
    }
}
