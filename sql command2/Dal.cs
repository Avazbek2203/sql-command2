using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SQL_COMMAND
{
    internal class DAL
    {
        public void CreateProduct(string name, decimal price)
        {
            SqlConnection connection = new SqlConnection(
                "Data Source=AVAZBEK\\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");

            try
            {
                Console.WriteLine("Product created");
                connection.Open();
                Console.WriteLine("Connection was successfull.");

                string command = $"INSERT INTO Product (Name, Price) VALUES ('{name}', {price})";
                SqlCommand sqlCommand = new SqlCommand(command, connection);

                int affectedRows = sqlCommand.ExecuteNonQuery();

                Console.WriteLine($"Number of rows affected: {affectedRows}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"There was an error executing SQL command... {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong. {ex.Message}");
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection closed.");
            }
        }



        public void ReadAllProducts()
        {
            SqlConnection connection = new SqlConnection(
               "Data Source=AVAZBEK\\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");

            try
            {
                Console.WriteLine("Products read");

                connection.Open();

                string command = "SELECT * FROM Product";
                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = command;

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {

                    Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));


                    while (reader.Read())
                    {
                        object id = reader.GetValue(0);
                        object name = reader.GetValue(1);
                        object price = reader.GetValue(2);

                        Console.WriteLine("{0} \t{1} \t{2}", id, name, price);
                    }
                    Console.WriteLine("Reading finished");
                    reader.Close();

                    Console.WriteLine("Reader disposed.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong while reading products. {ex.Message}.");
            }
            finally
            {
                Console.WriteLine("Closing connection...");
                connection.Close();
                Console.WriteLine("Connection closed.");
            }

        }


        public void UpdateProduct(int id, string newName, decimal newPrice)
        {
            SqlConnection connection = new SqlConnection(
               "Data Source=AVAZBEK\\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");

            try
            {
                Console.WriteLine("Products updated");
                connection.Open();

                Console.WriteLine("Connection was successfull.");

                string command = $"UPDATE Product" +
                    $" SET Name = '{newName}', Price = {newPrice}" +
                $" WHERE Id = {id};";
                SqlCommand sqlCommand = new SqlCommand(command, connection);

                int affectedRows = sqlCommand.ExecuteNonQuery();

                Console.WriteLine($"Number of rows affected: {affectedRows}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"There was an error executing SQL command... {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong. {ex.Message}");
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection closed.");
            }
        }





        public void DeleteProduct(int id)
        {
            SqlConnection connection = new SqlConnection(
               "Data Source=AVAZBEK\\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");

            try
            {
                Console.WriteLine("Products deleted");
                connection.Open();

                Console.WriteLine("Connection was successfull.");

                string command = $"DELETE Product WHERE Id = {id}";
                SqlCommand sqlCommand = new SqlCommand(command, connection);

                int affectedRows = sqlCommand.ExecuteNonQuery();

                Console.WriteLine($"Number of rows affected: {affectedRows}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"There was an error executing SQL command... {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong. {ex.Message}");
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection closed.");
            }
        }




        public void GetProductById(int id)
        {

            SqlConnection connection = new SqlConnection(
               "Data Source=AVAZBEK\\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");

            try
            {
                Console.WriteLine("Product picked");
                connection.Open();

                Console.WriteLine("Connection was successfull.");

                string command = $"SELECT * FROM Product WHERE Id = {id}";
                SqlCommand sqlCommand = new SqlCommand(command, connection);

                int affectedRows = sqlCommand.ExecuteNonQuery();

                Console.WriteLine($"Number of rows affected: {affectedRows}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"There was an error executing SQL command... {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong. {ex.Message}");
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection closed.");
            }
        }


        public void GetProductsByCategoryId(int categoryId)
        {
            SqlConnection connection = new SqlConnection(
"Data Source=AVAZBEK\\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");

            try
            {
                Console.WriteLine("Products Catagory");
                connection.Open();

                Console.WriteLine("Connection was successfull.");

                string command = $"SELECT * FROM Product WHERE CategoryId = {categoryId}";

                SqlCommand sqlCommand = new SqlCommand(command, connection);

                int affectedRows = sqlCommand.ExecuteNonQuery();

                Console.WriteLine($"Number of rows affected: {affectedRows}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"There was an error executing SQL command... {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong. {ex.Message}");
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection closed.");
            }

        }


        public void ReadByName(string name)
        {
            SqlConnection connection = new SqlConnection(
"Data Source=AVAZBEK\\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");

            try
            {
                Console.WriteLine("Products named");
                connection.Open();

                Console.WriteLine("Connection was successfull.");

                string command = $"SELECT * FROM Product WHERE Name = '{name}'";
                SqlCommand sqlCommand = new SqlCommand(command, connection);

                int affectedRows = sqlCommand.ExecuteNonQuery();

                Console.WriteLine($"Number of rows affected: {affectedRows}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"There was an error executing SQL command... {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong. {ex.Message}");
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection closed.");
            }

        }


        public void ReadByPrice(decimal price)
        {
            SqlConnection connection = new SqlConnection(
"Data Source=AVAZBEK\\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");

            try
            {
                Console.WriteLine("Products priced");
                connection.Open();

                Console.WriteLine("Connection was successfull.");

                string command = $"SELECT * FROM Product WHERE Price = {price}";
                SqlCommand sqlCommand = new SqlCommand(command, connection);

                int affectedRows = sqlCommand.ExecuteNonQuery();

                Console.WriteLine($"Number of rows affected: {affectedRows}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"There was an error executing SQL command... {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong. {ex.Message}");
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection closed.");
            }

        }

        public void CreateProductCategory(string categoryName)
        {
            SqlConnection connection = new SqlConnection(
                "Data Source=AVAZBEK\\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");

            try
            {
                Console.WriteLine("Category created");
                connection.Open();
                Console.WriteLine("Connection was successful.");

                string command = $"INSERT INTO Category (CatagoryName) VALUES ('{categoryName}')";
                SqlCommand sqlCommand = new SqlCommand(command, connection);

                int affectedRows = sqlCommand.ExecuteNonQuery();

                Console.WriteLine($"Number of rows affected: {affectedRows}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"There was an error executing SQL command... {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong. {ex.Message}");
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection closed.");
            }
        }

        public void UpdateProductCategory(string categoryName, int newCategoryId)
        {
            SqlConnection connection = new SqlConnection(
               "Data Source=AVAZBEK\\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");
            try
            {
                connection.Open();

                string updateQuery = $"UPDATE Product SET CategoryId = {newCategoryId} WHERE CategoryId = (SELECT CategoryId FROM Category WHERE CategoryName = '{categoryName}')";

                SqlCommand cmd = new SqlCommand(updateQuery, connection);

                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Updated successfully!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

    }
}










