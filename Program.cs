using System;
using System.Data.SqlClient;


namespace showdatainconsol
{
    class Program
    
    {
        static void Main(string[] args)
        {
            Program.Connection();
            Console.ReadLine();
        }
        static void Connection()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=VMDESKTOP-X6232\\MSSQLSERVER01; database=bookdatabase; integrated security=true");

                SqlCommand cm = new SqlCommand("select *from book_data", con);
                con.Open();
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["bookID"] + " " + sdr["bookName"]+" "+sdr["authorName"]);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();    
            }
        }
    }
}