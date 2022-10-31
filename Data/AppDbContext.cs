using MySql.Data.MySqlClient;

namespace api.Data;

public static class AppDbContex
{
    public static MySqlConnection connection = new MySqlConnection("Server=localhost;Port=3306;Database=vitedotnet;User Id=root;Password=root");
}