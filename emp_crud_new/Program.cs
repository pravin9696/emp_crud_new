using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using emp_crud_new.Model;

namespace emp_crud_new
{
    class operations
    {
        //create
        public void insert()
        { 
            //step1 create of object dbcontext class
             EmpDB_211224Entities dbo= new EmpDB_211224Entities();



            // step2 create tblEmployee class object and store data into it
            tblEmployee emp = new tblEmployee();


            string name;
            int sal;
            Console.WriteLine("enter name and salary of employee");
            name = Console.ReadLine();
            sal = Convert.ToInt32(Console.ReadLine());
            emp.empid = 3;
            emp.empName = name;
            emp.salary = sal;
            dbo.tblEmployees.Add(emp);


            //step3 call savechages() method and collect return number into variable
            int n = dbo.SaveChanges();
            if (n>0)
            {
                Console.WriteLine("record inserted successfully..");
            }
            else
            {
                Console.WriteLine("not inserted!!!");
            }


             
        }
        //Read  or search
        public void select_one()
        {
            //step1 create of object dbcontext class
            EmpDB_211224Entities dbo = new EmpDB_211224Entities();

            //step 2  fetch record from table and store it into respective class object
            string nm;
            Console.WriteLine("enter name of employee to search");
            nm = Console.ReadLine();
            tblEmployee emp = dbo.tblEmployees.FirstOrDefault(x=>x.empName==nm);
            
            
            //step 3 if emp is null means record not found into table otherwise that 
               // record is stored into object of respective class
            if (emp != null) {
                Console.WriteLine("record found");
                Console.WriteLine("emp id:"+emp.empid);
                Console.WriteLine("Name : "+emp.empName);
                Console.WriteLine("salary :"+emp.salary);
            }
            else
            {
                Console.WriteLine("record not found!!");
            }

        }
    }

    
    internal class Program
    {
        static void Main(string[] args)
        {
            operations op = new operations();
            //op.insert();
            op.select_one();

            Console.ReadKey();

        }
    }
}
