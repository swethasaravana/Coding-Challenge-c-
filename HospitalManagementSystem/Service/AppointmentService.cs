using HospitalManagementSystem.Model;
using HospitalManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HospitalManagementSystem.Service
{

    public class AppointmentService : IAppointmentService
    {
        private readonly AppointmentRepository _appointmentRepository;

        public AppointmentService()
        {
            _appointmentRepository = new AppointmentRepository();
        }

        //method to get Apoointment by ID
        public Appointment GetAppointmentById(int appointmentId)
        {
            var appointment = _appointmentRepository.GetAppointmentById(appointmentId);
            if (appointment == null)
            {
                Console.WriteLine($"No appointment found with ID {appointmentId}.");
            }
            return appointment;
        }

        //method to list all appointments for a patient
        public List<Appointment> GetAppointmentsForPatient(int patientId)
        {
            var appointments = _appointmentRepository.GetAppointmentsForPatient(patientId);
            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments found for the patient.");
            }
            return appointments;

        }

        //method to get appointment of a doctor
        public List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            var appointments = _appointmentRepository.GetAppointmentsForDoctor(doctorId);
            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments found for the doctor.");
            }
            else
            {
                foreach (var appointment in appointments)
                {
                    Console.WriteLine($"Appointment ID: {appointment.AppointmentId}, Patient ID: {appointment.PatientId}, " +
                                       $"Date: {appointment.AppointmentDate.ToShortDateString()}, Description: {appointment.Description}");
                }
            }
            return appointments;
        }

        //method to schedule an appointment
        public bool ScheduleAppointment(Appointment appointment)
        {
            bool isScheduled = _appointmentRepository.ScheduleAppointment(appointment);
            if (isScheduled)
            {
                Console.WriteLine("Appointment scheduled successfully.");
                return true;
            }
            else
            {
                Console.WriteLine("Failed to schedule appointment.");
                return false;
            }
        }

        //method to cancel an appointment
        public void CancelAppointment(int appointmentId)
        {
            bool isCancelled = _appointmentRepository.CancelAppointment(appointmentId);
            if (isCancelled)
            {
                Console.WriteLine("Appointment cancelled successfully.");
            }
            else
            {
                Console.WriteLine("Failed to cancel appointment.");
            }
        }

        //method to update an appointment
        public bool UpdateAppointment(Appointment appointment)
        {
            bool isUpdated = _appointmentRepository.UpdateAppointment(appointment);
            if (isUpdated)
            {
                Console.WriteLine("Appointment updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update appointment.");
            }
            return isUpdated;
        }
    }
    
}
