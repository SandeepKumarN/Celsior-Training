using DocApp.Context;
using DocApp.Models;

namespace DocApp
{
    internal class Program
    {
        AppointmentContext context = new AppointmentContext();

        void ListDoctors()
        {
            var doctors = context.Doctors.ToList();
            foreach (var doctor in doctors)
            {
                Console.WriteLine($"Doctor ID: {doctor.DoctorId}, Name: {doctor.DoctorName}");
            }
        }

        void ListPatients()
        {
            var patients = context.Patients.ToList();
            foreach (var patient in patients)
            {
                Console.WriteLine($"Patient Id: {patient.PatientId}, Name: {patient.PatientName}");
            }
        }

        void BookAppointment()
        {
            try
            {
                Console.WriteLine("Enter Doctor Id: ");
                int doctorId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Patient Id: ");
                int PatientId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Appointment Time (YYYY-MM-DD HH:MM): ");
                DateTime appointmentTime = DateTime.Parse(Console.ReadLine());

                bool isDoctorBusy = context.Appointments.Any(a => a.DoctorID == doctorId && a.AppointmentTime == appointmentTime);
                if (isDoctorBusy)
                {
                    Console.WriteLine("Doctor already has an appointment at this time. ");
                    //return;
                }

                var appointment = new Appointment
                {
                    DoctorID = doctorId,
                    PatientID = PatientId,
                    AppointmentTime = appointmentTime
                };

                context.Appointments.Add(appointment);
                context.SaveChanges();
                Console.WriteLine("Appointment booked sucessfully");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured: {e.Message}");
            }

        }

        void CreatingRecords()
        {
            Doctor doctor = new Doctor
            {
                DoctorName = "Pavan"
            };
            context.Doctors.Add(doctor);
            context.SaveChanges();
            
            
            Patient patient = new Patient
            {
                PatientName = "Ajith",
                
            };

            context.Patients.Add(patient);
            context.SaveChanges();
            
            Appointment appointment = new Appointment
            {
                AppointmentTime = DateTime.Now,
                DoctorID = doctor.DoctorId,
                PatientID = patient.PatientId,

            };
            context.Appointments.Add(appointment);
            context.SaveChanges();

        }

        void Display()
        {
            var appointments = context.Appointments.ToList();
            foreach (var appointment in appointments)
            {
                Console.WriteLine($"Appointment Id: {appointment.AppointmentID}, Patient Id: {appointment.PatientID}, Doctor Id: {appointment.DoctorID}");
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            //program.CreatingRecords();


                while (true)
                {
                    Console.WriteLine("1. List Doctors");
                    Console.WriteLine("2. List Patients");
                    Console.WriteLine("3. Book Appointment");
                Console.WriteLine("4. Display Appointment");
                Console.WriteLine("5. Exit");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            program.ListDoctors();
                            break;
                        case "2":
                            program.ListPatients();
                            break;
                        case "3":
                            program.BookAppointment();
                            break;
                    case "4":
                        program.Display();
                        break;
                    case "5":
                            return;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
            

        }
        
    }
}





