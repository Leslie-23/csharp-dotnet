using System;
using System.Collections.Generic;
using System.IO;

namespace HospitalManagementSystem
{
    public static class PatientManagement
    {
        private static string activePatientsFile = "ActivePatients.txt";
        private static string dischargedPatientsFile = "DischargedPatients.txt";

        public static void AddPatient(string name, int age, string condition)
        {
            using (StreamWriter sw = File.AppendText(activePatientsFile))
            {
                sw.WriteLine($"{name},{age},{condition}");
            }
            Console.WriteLine("Patient added successfully!");
        }

        public static void ViewPatients(bool isAdmin)
        {
            Console.WriteLine("\nActive Patients:");
            if (!File.Exists(activePatientsFile)) Console.WriteLine("No records found.");
            else
            {
                var lines = File.ReadAllLines(activePatientsFile);
                foreach (var line in lines) Console.WriteLine(line);
            }
            if (isAdmin)
            {
                Console.WriteLine("\nDischarged Patients:");
                if (!File.Exists(dischargedPatientsFile)) Console.WriteLine("No records found.");
                else
                {
                    var lines = File.ReadAllLines(dischargedPatientsFile);
                    foreach (var line in lines) Console.WriteLine(line);
                }
            }
        }

        public static void DischargePatient(string name)
        {
            if (!File.Exists(activePatientsFile)) return;

            var lines = new List<string>(File.ReadAllLines(activePatientsFile));
            var removed = lines.RemoveAll(l => l.StartsWith(name + ","));

            if (removed > 0)
            {
                File.WriteAllLines(activePatientsFile, lines);

                using (StreamWriter sw = File.AppendText(dischargedPatientsFile))
                {
                    sw.WriteLine(name);
                }
                Console.WriteLine("Patient discharged successfully!");
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }

        public static void UpdatePatient(string name, string newName, int newAge, string newCondition)
        {
            if (!File.Exists(activePatientsFile)) return;

            var lines = new List<string>(File.ReadAllLines(activePatientsFile));
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].StartsWith(name + ","))
                {
                    lines[i] = $"{newName},{newAge},{newCondition}";
                    File.WriteAllLines(activePatientsFile, lines);
                    Console.WriteLine("Patient updated successfully!");
                    return;
                }
            }
            Console.WriteLine("Patient not found.");
        }
    }
}
 