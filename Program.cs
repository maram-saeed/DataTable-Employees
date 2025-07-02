using System;
using System.Data;
using System.Linq;


namespace DataTable_Training_Employees
{
    internal class Program
    {
        static DataTable dtEmployees = new DataTable();
        static void Main(string[] args)
        {
            InitializeDataTable();

            AddEmployee("Mohammed Abu-Hadoud", 5000, true);
            AddEmployee("Ahmed Ali", 233, false);
            AddEmployee("Noora Saleh", 700, true);
            AddEmployee("Safwan Emad", 1200, true);
            AddEmployee("Eyman Khalid", 2000, true);

            DisplayEmployees();

            UpdateEmployee(2, "Hassan Saleh", 3400, true);

            Console.WriteLine("\n\t\t\t\tEmployee With ID 2 After Update\n");
            DisplayEmployees();

            DeleteEmployee(2);

            Console.WriteLine("\n\t\t\t\tEmployee With ID 2 After Delete\n");
            DisplayEmployees();

        }


        static void InitializeDataTable()
        {
            DataColumn dataColumn;

            dataColumn = new DataColumn();
            dataColumn.ColumnName = "ID";
            dataColumn.DataType = typeof(int);
            dataColumn.AutoIncrement = true;
            dataColumn.AutoIncrementSeed = 1;
            dataColumn.AutoIncrementStep = 1;
            dataColumn.ReadOnly = true;
            dataColumn.Unique = true;
            dtEmployees.Columns.Add(dataColumn);

            dtEmployees.Columns.Add("Name", typeof(string));
            dtEmployees.Columns.Add("Salary", typeof(double));
            dtEmployees.Columns.Add("IsActive", typeof(bool));
        }

        static void AddEmployee(string Name, double Salary, bool IsActive)
        {
            dtEmployees.Rows.Add(null,Name, Salary, IsActive);

            //DataRow dataRow = dtEmployees.NewRow();
            //dataRow["ID"] = DBNull.Value;
            //dataRow["Name"] = Name;
            //dataRow["Salary"] = Salary;
            //dataRow["IsActive"] = IsActive;
            //dtEmployees.Rows.Add(dataRow);
        }

        static void DisplayEmployees()
        {
            Console.WriteLine("\n\n\tEmployees List\n");
            Console.WriteLine("\t _________________________________________________________________________________________");
            Console.WriteLine("\t|{0,-4}|{1,-25}|{2,-10}|{3,-20}", "ID", "Name", "Salary", "IsActive");

            foreach (DataRow row in dtEmployees.Rows)
            {
                Console.WriteLine("\t|-----------------------------------------------------------------------------------------|");
                Console.WriteLine("\t|{0,-4}|{1,-25}|{2,-10}|{3,-20}", row["ID"], row["Name"], row["Salary"], row["IsActive"]);
            
            }
            Console.WriteLine("\t|_________________________________________________________________________________________|");
        }

        static void UpdateEmployee(int ID, string newName, double newSalary, bool newIsActive)
        {
            DataRow[] Results = dtEmployees.Select($"ID = {ID}");

            if (Results.Length > 0)
            {
                foreach (DataRow Row in Results)
                {
                    Row["Name"] = newName;
                    Row["Salary"] = newSalary;
                    Row["IsActive"] = newIsActive;
                }
                Console.WriteLine("\n\t\t\t----------------------------------------------");
                Console.WriteLine("\n\t\t\t\tEmployee updated successfully.");
            }
            else
            {
                Console.WriteLine("\n\t\t\t\t----------------------------------------------");
                Console.WriteLine("\n\t\t\t\tEmployee not found.");
            }

        }

        static void DeleteEmployee(int ID)
        {
            DataRow[] Results = dtEmployees.Select($"ID = {ID}");

            if (Results.Length > 0)
            {
                foreach (DataRow Row in Results)
                {
                    Row.Delete();
                }
                Console.WriteLine("\n\t\t\t----------------------------------------------");
                Console.WriteLine("\n\t\t\t\tEmployee deleted successfully.");
            }
            else
            {
                Console.WriteLine("\n\t\t\t----------------------------------------------");
                Console.WriteLine("\n\t\t\t\tEmployee not found.");
            }
        }

    }

}

