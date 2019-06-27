using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;

using MySql.Data.MySqlClient;

namespace DAL
{
    public class AccountDal
    {
        public static bool Validate(string userName, string password)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            string conString = "server=localhost;uid=root;pwd=root;database=test";
            con.ConnectionString = conString;
            string cmdString = "SELECT * FROM Doctors WHERE userName=@UserName AND password=@Password";

            cmd.CommandText = cmdString;
            cmd.Parameters.Add(new MySqlParameter("@UserName", userName));
            cmd.Parameters.Add(new MySqlParameter("@Password", password));
            cmd.Connection = con;
            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    status = true;
                }
                reader.Close();
            }
            catch (MySqlException exp)
            {
                Console.WriteLine(exp.Message);
            }

            finally
            {
                con.Close();
            }
            return status;
        }
        public static bool Delete(string userName)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            string conString = "server=localhost;uid=root;pwd=root;database=test";
            con.ConnectionString = conString;
            string cmdString = "delete from Doctors WHERE userName=@UserName ";

            cmd.CommandText = cmdString;
            cmd.Parameters.Add(new MySqlParameter("@UserName", userName));
            
            cmd.Connection = con;
            try
            {
                con.Open();
                int reader = cmd.ExecuteNonQuery();
                if (reader==1)
                {
                    status = true;
                }
               
            }
            catch (MySqlException exp)
            {
                Console.WriteLine(exp.Message);
            }

            finally
            {
                con.Close();
            }
            return status;
        }
        public static bool register(string name, string speciality,double fee,DateTime birthDate, string hospital, string username, string password)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            string conString = "server=localhost;uid=root;pwd=root;database=test";
            con.ConnectionString = conString;
            string cmdString = "insert into doctors (name,speciality,hospital,fee,birthdate,username,password) values(@Name,@Speciality,@Hospital,@Fee,@Birth,@Username,@Password)";

            cmd.CommandText = cmdString;
            cmd.Parameters.Add(new MySqlParameter("@Name", name));

            cmd.Parameters.Add(new MySqlParameter("@Speciality", speciality));

            cmd.Parameters.Add(new MySqlParameter("@Hospital", hospital));

            cmd.Parameters.Add(new MySqlParameter("@Birth", birthDate));
            cmd.Parameters.Add(new MySqlParameter("@Fee", fee));
            cmd.Parameters.Add(new MySqlParameter("@Username", username));
            cmd.Parameters.Add(new MySqlParameter("@Password", password));
            cmd.Connection = con;
            try
            {
                con.Open();
                int reader = cmd.ExecuteNonQuery();
                if (reader==1)
                {
                    status = true;
                }
                
            }
            catch (MySqlException exp)
            {
                Console.WriteLine(exp.Message);
            }

            finally
            {
                con.Close();
            }
            return status;
        }
        public static List<Doctor> listDoc()
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            string conString = "server=localhost;uid=root;pwd=root;database=test";
            con.ConnectionString = conString;
            string cmdString = "SELECT * FROM Doctors ";

            cmd.CommandText = cmdString;
            cmd.Connection = con;
            List<Doctor> doclist = new List<Doctor>();
            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    string name = reader["name"].ToString();
                    string speciality = reader["speciality"].ToString();
                    string hospital = reader["hospital"].ToString();
                    int fee = int.Parse(reader["fee"].ToString());
                    string username = reader["userName"].ToString();
                    string pswd = reader["password"].ToString();
                    //DateTime dob = DateTime.Parse(reader["birthDate"]
                     doclist.Add(new Doctor() { Name = name, Hospital = hospital, Speciality = speciality, Fee = fee, userName =username,password =pswd });
                }
                reader.Close();
            }
            catch (MySqlException exp)
            {
                Console.WriteLine(exp.Message);
            }

            finally
            {
                con.Close();
            }
            return doclist;
        }

        public static Doctor getByUserName(string userName)
        {
            MySqlConnection con = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            string conString = "server=localhost;uid=root;pwd=root;database=test";
            con.ConnectionString = conString;
            string cmdString = "SELECT * FROM Doctors where username=@userName";

            cmd.CommandText = cmdString;
            cmd.Connection = con;
            Doctor doc = null;
            try
            {
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {

                    string name = reader["name"].ToString();
                    string speciality = reader["speciality"].ToString();
                    string hospital = reader["hospital"].ToString();
                    int fee = int.Parse(reader["fee"].ToString());
                    string username = reader["userName"].ToString();
                    string pswd = reader["password"].ToString();
                    doc = new Doctor() { Name = name, Speciality = speciality, Hospital = hospital, Fee = fee, userName = userName, password = pswd };
                }
                reader.Close();
            }
            catch (MySqlException exp)
            {
                Console.WriteLine(exp.Message);
            }

            finally
            {
                con.Close();
            }
            return doc;
        }

    }
}

