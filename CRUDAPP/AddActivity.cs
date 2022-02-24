using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CRUDAPP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUDAPP
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class AddActivity : Activity
    {
        private EditText me_name;
        private EditText me_surname;
        private EditText me_department;
        private EditText me_salary;
        private Button mye_add;
        private EmployeeDatabase eDB;
        private EmployeeData employeedata;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.adddataLayout);
            eDB = new EmployeeDatabase();
            eDB.EmployeeTable();

            me_name = FindViewById<EditText>(Resource.Id.editText1);
            me_surname = FindViewById<EditText>(Resource.Id.editText2);
            me_department = FindViewById<EditText>(Resource.Id.editText3);
            me_salary = FindViewById<EditText>(Resource.Id.editText4);
            mye_add = FindViewById<Button>(Resource.Id.buttonA);

            mye_add.Click += Mye_add_Click;

        }

       

      

        private void Mye_add_Click(object sender, EventArgs e)
        {
            if(me_name.Text != string.Empty && me_surname.Text != string.Empty && me_department.Text != string.Empty && me_salary.Text != string.Empty)
            {
                employeedata = new EmployeeData();

                employeedata.e_name = me_name.Text;
                employeedata.e_surname = me_surname.Text;
                employeedata.e_department = me_department.Text;
                employeedata.e_salary = double.Parse(me_salary.Text);

                DateTime dateTime = DateTime.Now;
                employeedata.edateTime = dateTime.ToString();

                var isInserted = eDB.InstertEmployee(employeedata);
                if(isInserted == true)
                {

                    Toast.MakeText(this, "Data Inserted Succesfully", ToastLength.Short).Show();

                }
                else 
                
                {

                    Toast.MakeText(this, "No action performed", ToastLength.Short).Show();
                }
                Intent m = new Intent(this, typeof(MainActivity));
                StartActivity(m); ;

            }
            else 
            
            {


                Toast.MakeText(this, "Enter particular details", ToastLength.Short).Show();

            }
            
        }
    }
}