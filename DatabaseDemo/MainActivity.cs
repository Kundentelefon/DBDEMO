using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using DatabaseDemo.ORM;

namespace DatabaseDemo
{
    [Activity(Label = "DatabaseDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Home);

            //Create the database...
            //reference the particle button
            Button btnCreateDB = FindViewById<Button>(Resource.Id.btnCreateDB);
            //action doing when this happen ...
            btnCreateDB.Click += btnCreateDB_Click;

            //To Create the Table
            Button btnCreateTable = FindViewById<Button>(Resource.Id.btnCreateTable);
            btnCreateTable.Click += btnCreateTable_Click;

            //To Insert the record
            Button btnAddrecord = FindViewById<Button>(Resource.Id.btnInsert);
            btnAddrecord.Click += btnAddrecord_Click;

            //To Retrievbe the Data
            Button btnGetAll = FindViewById<Button>(Resource.Id.btnGetData);
            btnGetAll.Click += btnGetAll_Click;

            //To Retrieve Specific Record
            Button btnGetById = FindViewById<Button>(Resource.Id.btnGetDataByid);
            btnGetById.Click += btnGetById_Click;

        }

        void btnGetById_Click(object sender, EventArgs e)
        {
            StartActivty(typeof(SearchActivity));
        }

        private void StartActivty(Type type)
        {
            throw new NotImplementedException();
        }

        void btnGetAll_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            var result = dbr.GetAllRecords();
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }

        void btnAddrecord_Click(object sender, EventArgs e)
        {
            //if user click on it, start activity
            StartActivity(typeof(InsertTaskActivity));
        }

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            var result = dbr.CreateTable();
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }

        private void btnCreateDB_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            var result = dbr.CreateDB();
            // show message as alert
            Toast.MakeText(this, result, ToastLength.Short).Show();

        }

    }
}

