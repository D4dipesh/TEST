using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Doctor
    {
        #region member variables

        protected string name;
        protected string speciality;
        protected DateTime birthDate;
        protected double fee;
        protected string hospital;
        public string userName { get; set; }
        public string password { get; set; }
        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Speciality
        {
            get { return speciality; }
            set { speciality = value; }
        }


        public DateTime BirthDate
        {
            set { birthDate = value; }
            get { return birthDate; }
        }
        public double Fee
        {
            get { return fee; }
            set { fee = value; }
        }
        public string Hospital
        {
            get { return hospital; }
            set { hospital = value; }
        }
        #endregion

        #region constructors
        public Doctor() { }
        public Doctor(string Name, string sp,double fee,string hosp,string username,string password)
        {
            name = Name;
            speciality = sp;
           this.fee = fee;
            hospital = hosp;
            userName = username;
            this.password = password;
            
        }

        
        #endregion

        #region overridable functions
        public override string ToString()
        {
            return name + " " + speciality+" "+fee+" "+hospital;
        }

        #endregion
        ~Doctor()
        {

        }
    }
}
