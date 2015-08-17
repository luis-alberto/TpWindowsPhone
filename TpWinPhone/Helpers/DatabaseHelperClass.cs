using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TpWinPhone.Entities;
using System.Collections.ObjectModel;

namespace TpWinPhone.Helpers
{
    class DatabaseHelperClass
    {
        SQLiteConnection dbConn;

        //Create Table   
        public async Task<bool> onCreate(string DB_PATH)
        {
            try
            {
                if (!CheckFileExists(DB_PATH).Result)
                {
                    using (dbConn = new SQLiteConnection(DB_PATH))
                    {
                        dbConn.CreateTable<Record>();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private async Task<bool> CheckFileExists(string fileName)
        {
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Retrieve the specific record from the database.   
        public Record getRecordById(int recordId)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                var existingRecord = dbConn.Query<Record>("select * from Record where Id =" + recordId).FirstOrDefault();
                return existingRecord;
            }
        }

        // Retrieve the all records list from the database.   
        public List<Record> getAllRecords()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                List<Record> recordList = dbConn.Table<Record>().ToList<Record>();
                return recordList;
            }
        }

        // Insert the new record in the Record table.   
        public void Insert(Record newRecord)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(newRecord);
                });
            }
        }

        //Delete specific record   
        public void DeleteRecord(Record record)
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                if (record.id != null)
                {
                    dbConn.RunInTransaction(() =>
                    {
                        dbConn.Delete(record);
                    });
                }
            }
        }

        //Delete all records from table   
        public void DeleteAllRecords()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                //dbConn.RunInTransaction(() =>   
                //   {   
                dbConn.DropTable<Record>();
                dbConn.CreateTable<Record>();
                dbConn.Dispose();
                dbConn.Close();
                //});   
            }
        }
    }  
}