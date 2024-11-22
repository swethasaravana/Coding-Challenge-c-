using HospitalManagementSystem.Model;
using HospitalManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Main
{
    public class Hospital
    {
        static void Main(string[] args)
        {
            // Initialize repositories and services
            IAppointmentService appointmentService = new AppointmentService();

            while (true)
            {
                Console.WriteLine("\n=== Hospital Management System ===");
                Console.WriteLine("1. Get Appointment by ID");
                Console.WriteLine("2. View Appointments for a Patient");
                Console.WriteLine("3. View Appointments for a Doctor");
                Console.WriteLine("4. Schedule Appointment");
                Console.WriteLine("5. Update Appointment");
                Console.WriteLine("6. Cancel Appointment");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1: // Get Appointment by ID
                        Console.Write("Enter Appointment ID: ");
                        int appointmentId = int.Parse(Console.ReadLine());
                        Appointment appointment = appointmentService.GetAppointmentById(appointmentId);
                        if (appointment != null)
                        {
                            Console.WriteLine(appointment);
                        }
                        break;

                    case 2: // Get Appointments for a Patient
                        Console.Write("Enter Patient ID: ");
                        int patientIdForAppointments = int.Parse(Console.ReadLine());
                        List<Appointment> appointmentsForPatient = appointmentService.GetAppointmentsForPatient(patientIdForAppointments);
                        foreach (var appointments in appointmentsForPatient)
                        {
                            Console.WriteLine(appointments);
                        }
                        break;

                    case 3: // Get Appointments for a Doctor
                        Console.Write("Enter Doctor ID: ");
                        int doctorIdForAppointments = int.Parse(Console.ReadLine());
                        appointmentService.GetAppointmentsForDoctor(doctorIdForAppointments); // Service will handle printing
                        break;


                    case 4: // Schedule Appointment
                        Console.Write("Enter Appointment ID: ");
                        int appointment_Id = int.Parse(Console.ReadLine());

                        Console.Write("Enter Patient ID: ");
                        int patientId = int.Parse(Console.ReadLine());

                        Console.Write("Enter Doctor ID: ");
                        int doctorId = int.Parse(Console.ReadLine());

                        Console.Write("Enter Appointment Date (yyyy-mm-dd): ");
                        DateTime appointmentDate = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter Description: ");
                        string description = Console.ReadLine();

                        var newAppointment = new Appointment(appointment_Id, patientId, doctorId, appointmentDate, description);
                        appointmentService.ScheduleAppointment(newAppointment);
                        break;

                    case 5: // Update Appointment
                        Console.Write("Enter Appointment ID to Update: ");
                        int updateAppointmentId = int.Parse(Console.ReadLine());

                        var appointmentToUpdate = new Appointment();
                        appointmentToUpdate.AppointmentId = updateAppointmentId;

                        Console.Write("Enter Updated Appointment Date (yyyy-mm-dd): ");
                        appointmentToUpdate.AppointmentDate = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter Updated Description: ");
                        appointmentToUpdate.Description = Console.ReadLine();

                        appointmentService.UpdateAppointment(appointmentToUpdate);
                        break;

                    case 6://cancel an appointment
                        Console.Write("Enter Appointment ID to Cancel: ");
                        int cancelAppointmentId = int.Parse(Console.ReadLine());

                        appointmentService.CancelAppointment(cancelAppointmentId);
                        break;

                    case 7: // Exit
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;

                }
            }
        }
    }
}
