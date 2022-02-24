using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CRUDAPP.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Environment = System.Environment;

namespace CRUDAPP
{
    class EmployeeDatabase
    {

        public static string DBName = "SQLite.db3";
        public static string DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DBName);

        SQLiteConnection sqliteConnection;

        public EmployeeDatabase()
        {
            try
            {
                Console.WriteLine(DBPath);
                sqliteConnection = new SQLiteConnection(DBPath);
                Console.WriteLine("Succefully Database Created!....");



            }
            catch (Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);

            }
        }

        public void EmployeeTable()
        {
            try
            {
                var created = sqliteConnection.CreateTable<EmployeeData>();
                Console.WriteLine("Succefully Table Created!....");

            }

            catch (Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);

            }


        }

        public bool InstertEmployee(EmployeeData employees)
        {


            long result = sqliteConnection.Insert(employees);



            if (result == -1)
            {

                return false;
            }

            else
            {
                Console.WriteLine("Succefully Inserted Data ");
                return true;
            }


        }
        public bool UpdateEmployee(EmployeeData employees)
        {

            long result = sqliteConnection.Update(employees);


            if (result == 1)
            {


                Console.WriteLine("Succefully Updated Data ");
                return true;
            }
            else
            {
                Console.WriteLine("Not any action perform ");
                return false;

            }


        }

        public bool DeleteEmployee(EmployeeData employees)
        {


            long result = sqliteConnection.Delete(employees);
            if (result == -1)
            {

                return false;
            }

            else
            {
                Console.WriteLine("Succefully Deleted Data ");
                return true;
            }


        }

        public List<EmployeeData> ReadEmployee()
        {
            try
            {
                var employeeDetails = sqliteConnection.Table<EmployeeData>().ToList();
                return employeeDetails;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);
                return null;
            }

        }

        public EmployeeData GetByUserId(int employeeId)
        {
            var userId = sqliteConnection.Table<EmployeeData>().Where(u => u.e_id == employeeId).FirstOrDefault();

            return userId;

        }
    }
}

        

        

 
    
