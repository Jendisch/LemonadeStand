using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class DatabaseConnection
    {
        SqlConnection connect;
        public void ConnectToDatabase()
        {
                using (connect = new SqlConnection())
                {
                    connect.ConnectionString = "Server=localhost;Database=LemonadeStand;Trusted_Connection=True";
                    connect.Open();
                }
        }

        public void InsertIntoDatabase(Player playerOne, int dayNumber, int savedLengthOfGame, double totalProfit, string uniquePlayerName)
        {
            using (connect = new SqlConnection())
            {
                connect.ConnectionString = "Server=localhost;Database=LemonadeStand;Trusted_Connection=True";
                connect.Open();
                string query = "INSERT INTO Saved_Games (Player_Name, Current_Wallet, Current_Day, Length_Of_Game, Cup_Inventory, Lemon_Inventory, Sugar_Inventory, Net_Money, Unique_Name) VALUES (@Player_Name, @Current_Wallet, @Current_Day, @Length_Of_Game, @Cup_Inventory, @Lemon_Inventory, @Sugar_Inventory, @Net_Money, @Unique_Name)";
                SqlCommand insertCommand = new SqlCommand(query, connect);
                insertCommand.Parameters.AddWithValue("@Player_Name", playerOne.playerName);
                insertCommand.Parameters.AddWithValue("@Current_Wallet", playerOne.wallet.wallet);
                insertCommand.Parameters.AddWithValue("@Current_Day", dayNumber);
                insertCommand.Parameters.AddWithValue("@Length_Of_Game", savedLengthOfGame);
                insertCommand.Parameters.AddWithValue("@Cup_Inventory", playerOne.inventory.cups.Count);
                insertCommand.Parameters.AddWithValue("@Lemon_Inventory", playerOne.inventory.lemons.Count);
                insertCommand.Parameters.AddWithValue("@Sugar_Inventory", playerOne.inventory.cupsOfSugar.Count);
                insertCommand.Parameters.AddWithValue("@Net_Money", totalProfit);
                insertCommand.Parameters.AddWithValue("@Unique_Name", uniquePlayerName);

                insertCommand.ExecuteNonQuery();
            }
        }

        public bool SearchForUniqueName(string uniquePlayerName)
        {
            using (connect = new SqlConnection())
            {
                connect.ConnectionString = "Server=localhost;Database=LemonadeStand;Trusted_Connection=True";
                connect.Open();
                string query = "SELECT Unique_Name FROM Saved_Games WHERE Unique_Name LIKE @Unique_Name";
                SqlCommand selectCommand = new SqlCommand(query, connect);
                selectCommand.Parameters.AddWithValue("@Unique_Name", uniquePlayerName);
                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string uniqueName = reader.GetString(0);
                        return true;
                    } 
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public void UpdateCurrentDatabaseRecord(Player playerOne, int dayNumber, int savedLengthOfGame, double totalProfit, string uniquePlayerName)
        {
            connect.ConnectionString = "Server=localhost;Database=LemonadeStand;Trusted_Connection=True";
            connect.Open();
            string query = "UPDATE Saved_Games SET Current_Wallet = @Current_Wallet, Current_Day = @Current_Day, Cup_Inventory = @Cup_Inventory, Lemon_Inventory = @Lemon_Inventory, Sugar_Inventory = @Sugar_Inventory, Net_Money = @Net_Money WHERE Unique_Name = @Unique_Name";
            SqlCommand updateCommand = new SqlCommand(query, connect);
            updateCommand.Parameters.AddWithValue("@Current_Wallet", playerOne.wallet.wallet);
            updateCommand.Parameters.AddWithValue("@Current_Day", dayNumber);
            updateCommand.Parameters.AddWithValue("@Cup_Inventory", playerOne.inventory.cups.Count);
            updateCommand.Parameters.AddWithValue("@Lemon_Inventory", playerOne.inventory.lemons.Count);
            updateCommand.Parameters.AddWithValue("@Sugar_Inventory", playerOne.inventory.cupsOfSugar.Count);
            updateCommand.Parameters.AddWithValue("@Net_Money", totalProfit);
            updateCommand.Parameters.AddWithValue("@Unique_Name", uniquePlayerName);

            updateCommand.ExecuteNonQuery();
        }

        public VariableObjects LoadPreviousDatabaseRecord(string uniquePlayerName)
        {
            using (connect = new SqlConnection())
            {
                connect.ConnectionString = "Server=localhost;Database=LemonadeStand;Trusted_Connection=True";
                connect.Open();
                SqlCommand loadCommand = new SqlCommand("SELECT * FROM Saved_Games WHERE Unique_Name = @Unique_Name", connect);
                loadCommand.Parameters.AddWithValue("@Unique_Name", uniquePlayerName);
                using (SqlDataReader reader = loadCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VariableObjects objects = new VariableObjects();
                        StringBuilder builder = new StringBuilder();
                        objects.playerNameFromLoad = reader.GetString(1);
                        objects.walletFromLoad = reader.GetDecimal(2);
                        objects.dayNumberFromLoad = reader.GetInt32(3);
                        objects.gameLengthFromLoad = reader.GetInt32(4);
                        objects.cupsFromLoad = reader.GetInt32(5);
                        objects.lemonsFromLoad = reader.GetInt32(6);
                        objects.sugarFromLoad = reader.GetInt32(7);
                        objects.totalProfitFromLoad = reader.GetDecimal(8);
                        uniquePlayerName = reader.GetString(9);
                        return objects;
                    }
                    return null;
                }
            }
            
        }
        
    }
}


