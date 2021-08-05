﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADOAddressBook
{
    public class AddressBookRepository
    {
        //Connecting to SQL Server
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookSystem;Integrated Security=True;";
        //Passing the connection string as parameter
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        public int RetrieveData()
        {
            //Creating a object for AddressBookModel
            AddressBookModel model = new AddressBookModel();
            //Count the number of data in table
            int count = 0;
            try
            {
                using (sqlConnection)
                {
                    //Retrieve query
                    string query = @"select * from Address_Book_Table";
                    SqlCommand command = new SqlCommand(query, this.sqlConnection);
                    //open sql connection
                    sqlConnection.Open();
                    //sql reader to read data
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            DisplayDetails(sqlDataReader);
                            count++;
                        }

                    }
                    //close reader
                    sqlDataReader.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                this.sqlConnection.Close();
            }
            return count;
        }
        //Display the details
        public void DisplayDetails(SqlDataReader sqlDataReader)
        {

            AddressBookModel addressBook = new AddressBookModel();
            addressBook.firstName = Convert.ToString(sqlDataReader["FirstName"]);
            addressBook.lastName = Convert.ToString(sqlDataReader["LastName"]);
            addressBook.address = Convert.ToString(sqlDataReader["Address"]);
            addressBook.city = Convert.ToString(sqlDataReader["City"]);
            addressBook.stateName = Convert.ToString(sqlDataReader["StateName"]);
            addressBook.zipCode = Convert.ToString(sqlDataReader["ZipCode"]);
            addressBook.phoneNum = Convert.ToDouble(sqlDataReader["Phonenum"]);
            addressBook.emailId = Convert.ToString(sqlDataReader["EmailId"]);
            addressBook.addrBookName = Convert.ToString(sqlDataReader["AddressBookName"]);
            addressBook.relationType = Convert.ToString(sqlDataReader["RelationType"]);
            Console.WriteLine("FirstName :{0} LastName :{1} Address :{2} City :{3} State :{4} ZipCode :{5} PhoneNum :{6} EmailId :{7} AddressBookName :{8} RelationType :{9} ", addressBook.firstName, addressBook.lastName, addressBook.address, addressBook.city, addressBook.stateName, addressBook.zipCode, addressBook.phoneNum, addressBook.emailId, addressBook.addrBookName, addressBook.relationType);
            Console.WriteLine("\n");
        }

        /// <summary>
        /// UC3-Insert the table in Address_Book_Table using,Stored Procedure
        /// </summary>
        /// <param name="addressBook"></param>
        /// <returns></returns>
        public int InsertIntoTable(AddressBookModel addressBook)
        {
            int count = 0;
            try
            {
                using (sqlConnection)
                {
                    //Passing the stored procedure and connection
                    SqlCommand sqlCommand = new SqlCommand("dbo.InsertTable", this.sqlConnection);

                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    //Adding the value
                    sqlCommand.Parameters.AddWithValue("@FirstName", addressBook.firstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", addressBook.lastName);
                    sqlCommand.Parameters.AddWithValue("@Address", addressBook.address);
                    sqlCommand.Parameters.AddWithValue("@City", addressBook.city);
                    sqlCommand.Parameters.AddWithValue("@StateName", addressBook.stateName);
                    sqlCommand.Parameters.AddWithValue("@ZipCode", addressBook.zipCode);
                    sqlCommand.Parameters.AddWithValue("@PhoneNum", addressBook.phoneNum);
                    sqlCommand.Parameters.AddWithValue("@EmailId", addressBook.emailId);
                    sqlCommand.Parameters.AddWithValue("@AddressBookName", addressBook.addrBookName);
                    sqlCommand.Parameters.AddWithValue("@RelationType", addressBook.relationType);
                    //Opening the connection
                    sqlConnection.Open();
                    //returns the number of rows updated
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result != 0)
                    {
                        //Count the insert value
                        count++;
                        Console.WriteLine("Inserted Successfully");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Closing the connection
                sqlConnection.Close();
            }
            return count;
        }

        /// <summary>
        /// UC4-Edit the existing Contact For Address_Book_Table
        /// </summary>
        /// <param name="addressBook"></param>
        /// <returns></returns>
        public int EditExistingContact(AddressBookModel addressBook)
        {
            int count = 0;
            try
            {
                using (sqlConnection)
                {
                    //Query Execution(Update)
                    string query = @"update Address_Book_Table set EmailId='ashok2000@gmail.com' where FirstName='Ashok'";
                    //Passing the query and dbconnection
                    SqlCommand sqlCommand = new SqlCommand(query, this.sqlConnection);
                    //Opening the connection
                    sqlConnection.Open();
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result != 0)
                    {
                        count++;
                        Console.WriteLine("Updated SuccessFully");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //closes the connection
                sqlConnection.Close();
            }
            return count;

        }

        public int DeleteParticularContact(AddressBookModel addressBook)
        {
            int count = 0;
            try
            {
                using (sqlConnection)
                {
                    //Query Execution(Delete)
                    string query = @"delete from Address_Book_Table where FirstName = 'Swetha' and LastName = 'Raju'";
                    //Passing the query and dbconnection
                    SqlCommand sqlCommand = new SqlCommand(query, this.sqlConnection);
                    //Opening the connection
                    sqlConnection.Open();
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result != 0)
                    {
                        count++;
                        Console.WriteLine("Deleted SuccessFully");

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //closes the connection
                sqlConnection.Close();
            }
            return count;

        }

        /// <summary>
        /// UC6-Retrieve Data Based on City and State
        /// </summary>
        /// <param name="addressBook"></param>
        /// <returns></returns>
        public int RetrieveDataBasedOnStateAndCity(AddressBookModel addressBook)
        {
            int count = 0;
            try
            {
                using (sqlConnection)
                {
                    //Query Execution(Delete)
                    //Query Execution
                    string query = @"Select FirstName,LastName from Address_Book_Table where City = 'Chennai' or StateName = 'TamilNadu'";
                    //Passing the query and dbconnection
                    SqlCommand sqlCommand = new SqlCommand(query, this.sqlConnection);
                    //Opening the connection
                    sqlConnection.Open();
                    int result = sqlCommand.ExecuteNonQuery();
                    //SqlDataReader
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            count++;
                            addressBook.firstName = Convert.ToString(sqlDataReader["FirstName"]);
                            addressBook.lastName = Convert.ToString(sqlDataReader["LastName"]);
                            Console.WriteLine("FirstName :{0}\t LastName:{1}\t ", addressBook.firstName, addressBook.lastName);
                        }
                    }
                }

            }
            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //closes the connection
                sqlConnection.Close();
            }
            return count;
        }

        /// <summary>
        /// UC7-Size Of addressBook by City and State
        /// </summary>
        /// <param name="addressBook"></param>
        /// <returns></returns>
        public string RetrieveCountGroupByStateAndCity(AddressBookModel addressBook)
        {
            string list = null;
            try
            {
                using (sqlConnection)
                {
                    //Query Execution
                    string query = @"Select Count(*) As Count, StateName, City from Address_Book_Table group by StateName,City";
                    //Passing the query and dbconnection
                    SqlCommand sqlCommand = new SqlCommand(query, this.sqlConnection);
                    //Opening the connection
                    sqlConnection.Open();
                    int result = sqlCommand.ExecuteNonQuery();
                    //SqlDataReader
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {

                            Console.WriteLine("Count :{0}\t StateName:{1}\t City :{2}\t", sqlDataReader[0], sqlDataReader[1], sqlDataReader[2]);
                            list += sqlDataReader[0] + " " + sqlDataReader[1] + " " + sqlDataReader[2] + " ";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //closes the connection
                sqlConnection.Close();
            }
            return list;
        }
    }
}
