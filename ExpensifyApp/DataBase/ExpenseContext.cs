using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpensifyApp.Helpers;

namespace ExpensifyApp.DataBase
{
    public partial class ExpenseContext : DbContext
    {

        public string DbPath { get; }
        public static string ExportFilePath { get; private set; }
        public static string ImportFilePath { get; private set; }

        public static string _DBPath = @"/storage/emulated/0/expensedir";
        private static string dbFileName = "expense.db";

        //public static StockTakeContext Current { get; } = new StockTakeContext();

        public ExpenseContext()
        {
            //var folder = Environment.SpecialFolder.LocalApplicationData;
            //var path = Environment.GetFolderPath(folder);

            //DbPath = System.IO.Path.Join(path, "StockTake.db");
            DbPath = System.IO.Path.Join(_DBPath, dbFileName);


        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");

        public async Task DoInitWork()
        {
            var result = await CheckAndRequestFolderPermission();
            if (result == PermissionStatus.Granted)
            {
                if (!Directory.Exists(_DBPath))
                {
                    Directory.CreateDirectory(_DBPath);
                }

                if (!Directory.Exists(ExportFilePath))
                {
                    Directory.CreateDirectory(ExportFilePath);
                }

                if (!Directory.Exists(ImportFilePath))
                {
                    Directory.CreateDirectory(ImportFilePath);
                }

                base.Database.EnsureCreated();
            }
            else
            {
                //await UIHelper.ShowErrorMessage("File permission denied, without file permission stock count application will not work");
            }
        }


        public async Task<PermissionStatus> CheckAndRequestFolderPermission()
        {
            return await PermissionHelper.CheckAndRequestFileWritePermission();
        }
    }
}
