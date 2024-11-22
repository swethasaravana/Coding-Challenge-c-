using System;

namespace HospitalManagementSystem.Model
{
    public class Appointment
    {
        private int _appointmentId;
        private int _patientId;
        private int _doctorId;
        private DateTime _appointmentDate;
        private string _description;

        public int AppointmentId
        {
            get { return _appointmentId; }
            set { _appointmentId = value; }
        }

        public int PatientId
        {
            get { return _patientId; }
            set { _patientId = value; }
        }

        public int DoctorId
        {
            get { return _doctorId; }
            set { _doctorId = value; }
        }

        public DateTime AppointmentDate
        {
            get { return _appointmentDate; }
            set { _appointmentDate = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        // Default Constructor
        public Appointment() { }

        // Parameterized Constructor
        public Appointment(int appointmentId, int patientId, int doctorId, DateTime appointmentDate, string description)
        {
            _appointmentId = appointmentId;
            _patientId = patientId;
            _doctorId = doctorId;
            _appointmentDate = appointmentDate;
            _description = description;
        }

        public override string ToString()
        {
            return $"Appointment ID: {AppointmentId}, Patient ID: {PatientId}, Doctor ID: {DoctorId}, Date: {AppointmentDate.ToShortDateString()}, Description: {Description}";
        }
    }
}

