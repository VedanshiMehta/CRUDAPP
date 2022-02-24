using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using CRUDAPP.Model;
using System;
using System.Collections.Generic;

namespace CRUDAPP
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        private Toolbar toolbar;
        private ImageView addData;
        private RecyclerView myreV;
        private List<EmployeeData> employeedetails;
        private EmployeeDatabase eDB;
        private ViewAdapter myadapter;
        private RecyclerView.LayoutManager mypreview;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);


      
            addData = FindViewById<ImageView>(Resource.Id.addB);
            myreV = FindViewById<RecyclerView>(Resource.Id.recyclerView1);

            addData.Click += AddData_Click;

            GetEmployeeData();

            myreV.AddItemDecoration(new DividerItemDecoration(this, DividerItemDecoration.Vertical));
            mypreview = new LinearLayoutManager(this);
            myreV.SetLayoutManager(mypreview);

            myadapter= new ViewAdapter(employeedetails, this);
            myreV.SetAdapter(myadapter);


        }

        private List<EmployeeData> GetEmployeeData()
        {

            eDB = new EmployeeDatabase();
            var employeedata = eDB.ReadEmployee();

            employeedetails = new List<EmployeeData>();
            if (employeedetails != null)
            {
                

                employeedetails.AddRange(employeedata);

                return employeedetails;
            }

            else
            { 
                
                return null; 
            
            
            }
        }

        private void AddData_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(this, typeof(AddActivity));
            StartActivity(i);
          
        }
        


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}