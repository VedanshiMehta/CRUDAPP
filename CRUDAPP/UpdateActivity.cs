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
    [Activity(Label = "UpdateActivity")]
    public class UpdateActivity : Activity
    {
        private EditText Ue_id;
        private EditText Ue_name;
        private EditText Ue_surname;
        private EditText Ue_department;
        private EditText Ue_salary;
        private Button mye_update;
        private EmployeeDatabase eDB;
        private EmployeeData employeedata;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.updatedata);
            UIReferences();

            if(Intent.Extras != null)
            {

                int eid = Intent.Extras.GetInt("EmployeeId", 0);

                if (eid != null)
                {

                    Ue_id.Text = eid.ToString();

                    eDB = new EmployeeDatabase();
                    employeedata = eDB.GetByUserId(eid);

                     Ue_name.Text = employeedata.e_name;
                     Ue_surname.Text = employeedata.e_surname;
                     Ue_department.Text = employeedata.e_department;
                     Ue_salary.Text = employeedata.e_salary.ToString();
                 





                }


            }
            UIClick();

        }

        private void UIClick()
        {
            mye_update.Click += Mye_update_Click;
        }

        

        private void Mye_update_Click(object sender, EventArgs e)
        {
            if (employeedata != null)
            {
                if (Ue_id.Text != string.Empty && Ue_name.Text != string.Empty && Ue_surname.Text != string.Empty && Ue_department.Text != string.Empty && Ue_salary.Text != string.Empty)
                {
                    employeedata.e_id = int.Parse(Ue_id.Text);
                    employeedata.e_name = Ue_name.Text;
                    employeedata.e_surname = Ue_surname.Text;
                    employeedata.e_department = Ue_department.Text;
                    employeedata.e_salary = double.Parse(Ue_salary.Text);

                    DateTime dateTime = DateTime.Now;
                    employeedata.edateTime = dateTime.ToString();

                    var isUpdate = eDB.UpdateEmployee(employeedata);
                    if (isUpdate == true)
                    {

                        Toast.MakeText(this, "Data Updated Succesfully", ToastLength.Short).Show();
                    }

                    else
                    {

                        Toast.MakeText(this, "No action performed", ToastLength.Short).Show();

                    }


                }

                else
                {

                    Toast.MakeText(this, "Enter details in feilds", ToastLength.Short).Show();

                }
            }

            Intent n = new Intent(this, typeof(MainActivity));
            StartActivity(n); ;
        }

        private void UIReferences()
        {
            Ue_id = FindViewById<EditText>(Resource.Id.editTextU1);
            Ue_name = FindViewById<EditText>(Resource.Id.editTextU2);
            Ue_surname = FindViewById<EditText>(Resource.Id.editTextU3);
            Ue_department = FindViewById<EditText>(Resource.Id.editTextU4);
            Ue_salary = FindViewById<EditText>(Resource.Id.editTextU5);
            mye_update = FindViewById<Button>(Resource.Id.buttonU);
        }
    }
}