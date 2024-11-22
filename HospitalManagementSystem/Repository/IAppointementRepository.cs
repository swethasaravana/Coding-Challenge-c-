using HospitalManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Repository
{
    public interface IAppointementRepository
    {
        Appointment GetAppointmentById(int appointmentId);
        List<Appointment> GetAppointmentsForPatient(int patientId);
        bool ScheduleAppointment(Appointment appointment);
        bool CancelAppointment(int appointmentId);
        bool UpdateAppointment(Appointment appointment);
        List<Appointment> GetAppointmentsForDoctor(int doctorId);

    }
}
