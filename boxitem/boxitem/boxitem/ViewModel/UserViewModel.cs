using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxitem.ViewModel
{
    class UserViewModel
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        public int Id { get; set; }

        public UserViewModel (string login, string password, string name,string surname, int id)
        {
            this.Login = login;
            this.Password = password;
            this.Name = name;
            this.Surname = surname;
            this.Id = id;
        }
        public UserViewModel(string login, string password, string name, string surname)
        {
            this.Login = login;
            this.Password = password;
            this.Name = name;
            this.Surname = surname;
        }
        public static UserViewModel Create(string login, string password, string name, string surname, int id)
        {
            return new UserViewModel(name, password, name,surname,id);
        }
       
        public static UserViewModel Create(string login, string password,int id)
        {
            return null;// login;
        }
        public static UserViewModel Create(string login, string password, string name, string surname)
        {
            return new UserViewModel(login, password, name, surname);
        }
    }
}
