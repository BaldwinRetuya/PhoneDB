using System.Data.SqlClient;
using PhonesModel;

namespace PhonesDL

{
    public class sqlDBData
    {
        string connectionString
        = "Data Source =ELIJAH\\SQLEXPRESS; Initial Catalog = PhoneManagement; Integrated Security = True;";

        SqlConnection sqlConnection;

        public sqlDBData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<Phones> GetPhones()
        {
            string selectStatement = "SELECT Brand, Model, Price FROM Phones";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            List<Phones> phones = new List<Phones>();

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string Brand = reader["Brand"].ToString();
                string Model = reader["Model"].ToString();
                string Price = reader["Price"].ToString();

                Phones readPhones = new Phones();
                readPhones.Brand = Brand;
                readPhones.Model = Model;
                readPhones.Price = Price;

                phones.Add(readPhones);
            }

            sqlConnection.Close();

            return phones;

        }
        public int AddPhones(string Brand, string Model, string Price)
        {
            int success;

            string insertStatement = "INSERT INTO cars VALUES (@Brand, @Model, @YearModel)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@Brand", Brand);
            insertCommand.Parameters.AddWithValue("@Model", Model);
            insertCommand.Parameters.AddWithValue("@YearModel", Price);
            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int UpdatePhones(string Brand, string Model, string Price)
        {
            int success;

            string updateStatement = $"UPDATE phones SET Model = @Model WHERE Brand = @Brand";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            sqlConnection.Open();

            updateCommand.Parameters.AddWithValue("@Model", Model);
            updateCommand.Parameters.AddWithValue("@Brand", Brand);

            success = updateCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;

        }

        public int DeletePhones(string Brand, string Model, string Price)
        {
            int success;

            string deleteStatement = $"UPDATE FROM cars WHERE Brand = @Brand, Model = @Model, Price = @Price";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            sqlConnection.Open();

            deleteCommand.Parameters.AddWithValue("@Brand", Brand);
            deleteCommand.Parameters.AddWithValue("@Model", Model);
            deleteCommand.Parameters.AddWithValue("@Price", Price);

            success = deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

    }
}