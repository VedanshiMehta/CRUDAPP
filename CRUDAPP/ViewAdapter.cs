using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using CRUDAPP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUDAPP 
{
    class ViewAdapter : RecyclerView.Adapter
    {
        private List<EmployeeData> employeedetails;
        private MainActivity mainActivity;                                                                                                                                                                                                                    
        private EmployeeDatabase eDB;
        private EmployeeData employeedata;

        public ViewAdapter(List<EmployeeData> employeedetails, MainActivity mainActivity)
        {
            this.employeedetails = employeedetails;
            this.mainActivity = mainActivity;
        }

        public override int ItemCount => employeedetails.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyViewHolder myViewHolder = holder as MyViewHolder;
            myViewHolder.BindData(employeedetails[position]);

            myViewHolder.editB.Click += (s, e) =>
            {

                Intent j = new Intent(mainActivity, typeof(UpdateActivity));
                j.PutExtra("EmployeeId", employeedetails[position].e_id);
                mainActivity.StartActivity(j);


            };

            myViewHolder.deleteB.Click += (s, e) =>
            {
                eDB = new EmployeeDatabase();
                employeedata = eDB.GetByUserId(employeedetails[position].e_id);

                if (employeedata != null)
                {

                    var datadeleted = eDB.DeleteEmployee(employeedata);
                    if (datadeleted == true)
                    {



                        Toast.MakeText(mainActivity, "Data Deleted Succesfully", ToastLength.Short).Show();
                    }

                    else
                    {

                        Toast.MakeText(mainActivity, "No action performed", ToastLength.Short).Show();

                    }
                }
                Intent k = new Intent(mainActivity, typeof(MainActivity));
                mainActivity.StartActivity(k); ;
            };
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View v = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.detailslist, parent, false);
            return new MyViewHolder(v);
        }
    }

    class MyViewHolder : RecyclerView.ViewHolder
    {
        public TextView eName;
        public TextView eSurname;
        public TextView eDepartment;
        public TextView eSalary;
        public TextView eDatetime;
        public Button editB;
        public Button deleteB;
       
        public MyViewHolder(View itemView) : base(itemView)
        {

            eName = itemView.FindViewById<TextView>(Resource.Id.name);
            eSurname = itemView.FindViewById<TextView>(Resource.Id.surname);
            eDepartment = itemView.FindViewById<TextView>(Resource.Id.department);
            eSalary = itemView.FindViewById<TextView>(Resource.Id.salary);
            editB = itemView.FindViewById<Button>(Resource.Id.editButton);
            deleteB = itemView.FindViewById<Button>(Resource.Id.deleteButton);
            eDatetime = itemView.FindViewById<TextView>(Resource.Id.datetime);

        }

        internal void BindData(EmployeeData employeeData)
        {
            eName.Text = employeeData.e_name;
            eSurname.Text = employeeData.e_surname;
            eDepartment.Text = employeeData.e_department;
            eSalary.Text = employeeData.e_salary.ToString();
            eDatetime.Text = employeeData.edateTime;

        }
    }
}