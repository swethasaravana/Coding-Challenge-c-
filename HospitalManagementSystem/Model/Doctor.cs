using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Model
{
    public class Doctor
    {
        private int _doctorId;
        private string _firstName;
        private string _lastName;
        private string _specialization;
        private string _contactNumber;

        public int DoctorId
        {
            get { return _doctorId; }
            set { _doctorId = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Specialization
        {
            get { return _specialization; }
            set { _specialization = value; }
        }

        public string ContactNumber
        {
            get { return _contactNumber; }
            set { _contactNumber = value; }
        }

        // Default Constructor
        public Doctor() { }

        // Parameterized Constructor
        public Doctor(int doctorId, string firstName, string lastName, string specialization, string contactNumber)
        {
            _doctorId = doctorId;
            _firstName = firstName;
            _lastName = lastName;
            _specialization = specialization;
            _contactNumber = contactNumber;
        }

        public override string ToString()
        {
            return $"Doctor ID: {DoctorId}, Name: {FirstName} {LastName}, Specialization: {Specialization}, Contact: {ContactNumber}";
        }
    }
}
