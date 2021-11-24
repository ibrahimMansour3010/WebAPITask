using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class AddUserModel
    {
        [Required]
        [MinLength(5)]
        public string Username { get; set; }
        [Required]
        [MinLength(3)]
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
    public static class AddUserModelExtensions
    {
        public static User ToUser(this AddUserModel addUserModel)
        {
            return new User()
            {
                Username = addUserModel.Username,
                Password = addUserModel.Password,
                Phone = addUserModel.Phone,
                Addess = addUserModel.Address
            };
        }
    }
}
