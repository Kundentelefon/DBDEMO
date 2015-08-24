using System;

using System.Data;
using System.IO;
using SQLite;

namespace DatabaseDemo.ORM
{
    public class DBRepository
    {
        // code to create the database (within android device)
        public string CreateDB()
        {
            var output = "";
            output += "Creating Database if it doesnt exist.";
            // Specify the created Folter path
            string dbPath = Path.Combine(Environment.GetFolderPath
                (Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);
            output += "/nDatabase Created...";
            return output;

        }

        //Code to create the table
        public string CreateTable()
        {
            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath
                (Environment.SpecialFolder.Personal), "ormdemo.db3");
                var db = new SQLiteConnection(dbPath);
                // create table after db established
                // name of table "ToDoTasks
                db.CreateTable<ToDoTasks>();
                string result = "Table Created successfully...";
                return result;
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }

        }


        // Code to insert a record
        public string InsertRecord( string task)
        {
            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath
                (Environment.SpecialFolder.Personal), "ormdemo.db3");
                var db = new SQLiteConnection(dbPath);

                ToDoTasks item = new ToDoTasks();
                item.Task = task;
                db.Insert(item);
                return "Record Added...";
            }
            catch(Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }

        //code to retrieve all the records
        public string GetAllRecords()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath
                (Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);

            string output = "";
            output += "Retrieving the data using ORM...";
            var table = db.Table<ToDoTasks>();
            foreach(var item in table)
            {
                output += "\n" + item.Id + " --- " + item.Task;
            }
            return output;
        }

        // code to retrieve speicif record using ORM
        public string GetTaskById( int id)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath
                (Environment.SpecialFolder.Personal), "ormdemo.db3");
            var db = new SQLiteConnection(dbPath);

            var item = db.Get<ToDoTasks>(id);
            return item.Task;
        }

    }
}


