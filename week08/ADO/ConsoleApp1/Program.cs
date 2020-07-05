using System;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().CreateTable();
        }
        public void CreateTable()
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection(@"data source=.\SQLEXPRESS; database=student; integrated security=SSPI");
                // writing sql query  
                SqlCommand cm = new SqlCommand(@"CREATE TABLE [dbo].[Book2](
	                [BookId] [int] IDENTITY(1,1) NOT NULL,
	                [Title] [nvarchar](150) NOT NULL,
	                [YearOfPublishing] [int] NULL,
	                [NumberOfPages] [int] NULL,
	                [HardCover] [bit] NULL,
	                [AuthorID] [int] NOT NULL)", con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                cm.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Table created Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }
    }
}
