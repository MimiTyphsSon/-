using System;
using System.Data;

class Program
{
    static void Main()
    {
        DataTable studentsTable = new DataTable("Students");

        studentsTable.Columns.Add("Id", typeof(int));
        studentsTable.Columns.Add("Name", typeof(string));
        studentsTable.Columns.Add("Age", typeof(int));
        studentsTable.Columns.Add("GroupName", typeof(string));

        studentsTable.Rows.Add(1, "Иван Иванов", 20, "ИС-21");
        studentsTable.Rows.Add(2, "Мария Петрова", 19, "ИС-21");
        studentsTable.Rows.Add(3, "Алексей Смирнов", 22, "ПИ-20");
        studentsTable.Rows.Add(4, "Елена Кузнецова", 21, "ПИ-20");
        studentsTable.Rows.Add(5, "Дмитрий Соколов", 23, "ИС-22");

        Console.WriteLine("--- Список студентов ---");
        Console.WriteLine("{0,-5} {1,-20} {2,-5} {3,-10}", "Id", "Name", "Age", "GroupName");
        Console.WriteLine(new string('-', 45));

        foreach (DataRow row in studentsTable.Rows)
        {
            Console.WriteLine("{0,-5} {1,-20} {2,-5} {3,-10}",
                row["Id"], row["Name"], row["Age"], row["GroupName"]);
        }

        DataRow oldestStudent = null;
        int maxAge = -1;

        foreach (DataRow row in studentsTable.Rows)
        {
            int currentAge = Convert.ToInt32(row["Age"]);
            if (currentAge > maxAge)
            {
                maxAge = currentAge;
                oldestStudent = row;
            }
        }

        Console.WriteLine("\n--- Самый старший студент ---");
        if (oldestStudent != null)
        {
            Console.WriteLine($"Имя: {oldestStudent["Name"]}, Возраст: {oldestStudent["Age"]}, Группа: {oldestStudent["GroupName"]}");
        }
    }
}