using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Crud2
{
    internal class Program
    {
        static void Main(string[] args)

        {
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("What would you like to do?");
           
            Console.WriteLine("\nType 1 to Insert Records.");
            Console.WriteLine("Type 2 to View All Records.");
            Console.WriteLine("Type 3 to Update Records.");
            Console.WriteLine("Type 4 to Delete Records.");
            string commandInput = Console.ReadLine();
            int command = Convert.ToInt32(commandInput);
            SqlConnection sqlConnection = new SqlConnection("Server=COVRIZENUCI3-01;Database=CutomerInfo;User ID=sa;Password=asd@1234;");
           
            switch (command)
            {

                case 1:

                    
                    Console.WriteLine("Lastname");
                    string lastname = Console.ReadLine();
                    Console.WriteLine("FirstName");
                    string firstname = Console.ReadLine();
                    Console.WriteLine("Address");
                    string address = Console.ReadLine();
                    Console.WriteLine("City");
                    string city = Console.ReadLine();

                   
                    sqlConnection.Open();
                    Console.WriteLine("Connection SuccessFull");
                    Console.ReadLine();

                    SqlCommand cmd = new SqlCommand("sp_insert", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
              
                    cmd.Parameters.AddWithValue("@LastName", lastname);
                    cmd.Parameters.AddWithValue("@FirstName", firstname);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@City", city);


                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    Console.WriteLine("Data inserted SuccEssfully");
                    break;

                case 2:

                    sqlConnection.Open();
                    SqlCommand comm = new SqlCommand("sp_select", sqlConnection);
                    comm.CommandType = CommandType.StoredProcedure;
                    using(SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            { 
                                Console.WriteLine(reader.GetValue(i));  
                            }
                            Console.WriteLine();    
                        }
                        Console.ReadLine();
                    
                    }
                    sqlConnection.Close();
                    


                 break;

                case 3:
                    string lname, fname, addr, c1;
                    Console.WriteLine("Update User Info Id");
                    int id = int.Parse(Console.ReadLine());
                    lname = Console.ReadLine();
                    fname = Console.ReadLine();
                    addr = Console.ReadLine();
                    c1 = Console.ReadLine();
                    sqlConnection.Open();
                    SqlCommand comn = new SqlCommand("sp_update", sqlConnection);
                    comn.CommandType = CommandType.StoredProcedure;
                    comn.Parameters.AddWithValue ("@PersonID", id);
                    comn.Parameters.AddWithValue("@LastName", lname);
                    comn.Parameters.AddWithValue("@FirstName", fname);
                    comn.Parameters.AddWithValue("@Address", addr);
                    comn.Parameters.AddWithValue("@City", c1);


                    comn.ExecuteNonQuery();
                    sqlConnection.Close();

                    break;

                case 4:
                    Console.WriteLine("Delete Id");
                    int  id1= int.Parse(Console.ReadLine());
                    
                    sqlConnection.Open();
                    SqlCommand comd = new SqlCommand("sp_delete", sqlConnection);
                    comd.CommandType = CommandType.StoredProcedure;
                    comd.Parameters.AddWithValue("@PersonID", id1);
                    comd.ExecuteReader();
                    sqlConnection.Close();
                    break;



                default:
                    Console.WriteLine("No match found");
                    break;
                    

            }

          
        }
    }
}

