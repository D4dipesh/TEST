using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BOL;
namespace BLL
{
    public class AccountManager
    {
        public static bool Validate(string userName, string password)
        {
            return AccountDal.Validate(userName, password);
        }
       
        public static bool Register(string name, string speciality,double fee,DateTime birthDate ,string hospital, string username, string password)
        {
            return AccountDal.register(name, speciality,fee,birthDate, hospital, username, password);
        }
        public static List<Doctor> listAllDoc()
        {
            return AccountDal.listDoc();
        }
        public static bool delete(string userName)
        {
            return AccountDal.Delete(userName);
        }
        public static Doctor getByusername(string userName)
        {
            return AccountDal.getByUserName(userName);
        }
    }
}
