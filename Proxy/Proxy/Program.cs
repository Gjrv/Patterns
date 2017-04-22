using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Simple example of the pattern "Proxy"

namespace Proxy
{
    class Program
    {
        public interface IDateUser
        {
            void Get_info(int id);
        }
        public class User
        {
            public int _id { get; set; }
            public string _name { get; set; }
            public double _money { get; set; }

            public User(int id,string name, double money)
            {
                this._id = id;
                this._name = name;
                this._money = money;
            }

        }
        public class User_datebase : IDateUser
        {
            public List<User> _usersDB = new List<User>();
            public void Get_info(int id)
            {
                User us = _usersDB.Find(u => u._id == id);
                Console.WriteLine("id: {0}\nИмя: {1}\nРазмер счета: ${2}", us._id, us._name, us._money);
            }
        }
        public class User_datebaseProxy : IDateUser
        {
            public User_datebase _db = new User_datebase();

            public void Get_info(int id)
            {
                User us = _db._usersDB.Find(u => u._id == id);
                if (us._money < 0)
                    Console.WriteLine("Пользователь с id: {0} должен ${1}", us._id, Math.Abs(us._money));
                else
                    Console.WriteLine("id: {0}\nИмя: {1}\nРазмер счета: ${2}", us._id, us._name, us._money);
            }
        }
        static void Main(string[] args)
        {
            User a = new User(1, "Vasya", 290.9);
            User b = new User(2, "Petya", 1290.9);
            User_datebaseProxy db = new User_datebaseProxy();
            db._db._usersDB.Add(a);
            db._db._usersDB.Add(b);
            db.Get_info(1);
            db.Get_info(2);

        }
    }
}
