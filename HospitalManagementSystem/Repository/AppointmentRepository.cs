using HospitalManagementSystem.Model;
using Microsoft.Data.SqlClient;
using ProjectManagementSystem.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Repository
{
    public class AppointmentRepository : IAppointementRepository
    {
        //to get the appointments by ID
        public Appointment GetAppointmentById(int appointmentId)
        {
            using (var connection = DBConnUtil.GetConnection())
            {
                try
                {
                    string query = "SELECT * FROM Appointment WHERE appointmentId = @AppointmentId";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@AppointmentId", appointmentId);

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Appointment
                            {
                                AppointmentId = Convert.ToInt32(reader["appointmentId"]),
                                PatientId = Convert.ToInt32(reader["patientId"]),
                                DoctorId = Convert.ToInt32(reader["doctorId"]),
                                AppointmentDate = Convert.ToDateTime(reader["appointmentDate"]),
                                Description = reader["description"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving appointment by ID: {ex.Message}");
                }
            }

            return null;
        }

        //to list all appointments of a patient
        public List<Appointment> GetAppointmentsForPatient(int patientId)
        {
            var appointments = new List<Appointment>();

            using (var connection = DBConnUtil.GetConnection())
            {
                try
                {
                    string query = "SELECT * FROM Appointment WHERE patientId = @PatientId";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PatientId", patientId);

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            appointments.Add(new Appointment
                            {
                                AppointmentId = Convert.ToInt32(reader["appointmentId"]),
                                PatientId = Convert.ToInt32(reader["patientId"]),
                                DoctorId = Convert.ToInt32(reader["doctorId"]),
                                AppointmentDate = Convert.ToDateTime(reader["appointmentDate"]),
                                Description = reader["description"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving appointments for patient: {ex.Message}");
                }
            }

            return appointments;
        }

        //to scheldule an appointment
        public bool ScheduleAppointment(Appointment appointment)
        {
            using (var connection = DBConnUtil.GetConnection())
            {
                try
                {
                    string query = "INSERT INTO Appointment (appointmentId, patientId, doctorId, appointmentDate, description) " +
                                   "VALUES (@AppointmentId, @PatientId, @DoctorId, @AppointmentDate, @Description)";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@AppointmentId", appointment.AppointmentId);
                    command.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                    command.Parameters.AddWithValue("@DoctorId", appointment.DoctorId);
                    command.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                    command.Parameters.AddWithValue("@Description", appointment.Description);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error scheduling appointment: {ex.Message}");
                    return false;
                }
            }
        }

        //to cancel an appointment
        public bool CancelAppointment(int appointmentId)
        {
            using (var connection = DBConnUtil.GetConnection())
            {
                try
                {
                    string query = "DELETE FROM Appointment WHERE appointmentId = @AppointmentId";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@AppointmentId", appointmentId);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error cancelling appointment: {ex.Message}");
                    return false;
                }
            }
        }

        //to update an an appointment
        public bool UpdateAppointment(Appointment appointment)
        {
            using (var connection = DBConnUtil.GetConnection())
            {
                try
                {
                    string query = "UPDATE Appointment SET appointmentDate = @AppointmentDate, description = @Description " +
                                   "WHERE appointmentId = @AppointmentId";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@AppointmentId", appointment.AppointmentId);
                    command.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                    command.Parameters.AddWithValue("@Description", appointment.Description);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0; 
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating appointment: {ex.Message}");
                    return false;
                }
            }
        }

        //to list the appointments of a doctor
        public List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            var appointments = new List<Appointment>();

            using (var connection = DBConnUtil.GetConnection())
            {
                try
                {
                    string query = "SELECT * FROM Appointment WHERE doctorId = @DoctorId";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DoctorId", doctorId);

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            appointments.Add(new Appointment
                            {
                                AppointmentId = Convert.ToInt32(reader["appointmentId"]),
                                PatientId = Convert.ToInt32(reader["patientId"]),
                                DoctorId = Convert.ToInt32(reader["doctorId"]),
                                AppointmentDate = Convert.ToDateTime(reader["appointmentDate"]),
                                Description = reader["description"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving appointments for doctor: {ex.Message}");
                }
            }

            return appointments;
        }


    }
}
