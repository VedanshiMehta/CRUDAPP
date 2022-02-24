using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUDAPP.Model
{
    [Table("EMPLOYEETABLE")]
    class EmployeeData
    {
        [PrimaryKey,AutoIncrement]
        [Column("EmployeeId")]
        public int e_id { get; set; }

        
        [Column("EmployeeName")]
        public string e_name { get; set; }

        [Column("EmployeeSurname")]
        public string e_surname { get; set; }

        [Column("EmployeeDepartment")]
        public string e_department { get; set; }


        [Column("EmployeeSalary")]
        public double e_salary { get; set; }

        [Column("DateTime")]
        public string edateTime { get; set; }
    }
}