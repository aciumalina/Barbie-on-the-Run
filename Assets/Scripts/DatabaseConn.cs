using UnityEngine;
using System.Data;
using MySql.Data.MySqlClient;
using System;

public class DatabaseConn : MonoBehaviour
{
    private static DatabaseConn instance;

    private MySqlConnection connection;
    private const string connectionString = "Server=127.0.0.1;User=root;Database=unitygame;Password=toor123;SslMode=None;";

    public static DatabaseConn Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("DatabaseConn").AddComponent<DatabaseConn>();
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        ConnectToDatabase();

    }


    void ConnectToDatabase()
    {
        connection = new MySqlConnection(connectionString);

        try
        {
            connection.Open();
            Debug.Log("Conexiunea la baza de date a fost deschisa cu succes.");
        }
        catch (MySqlException ex)
        {
            Debug.LogError("Eroare la deschiderea conexiunii la baza de date: " + ex.Message);
        }

    }

    public bool checkIfEmailExists(string email)
    {
        string query = "select count(*) from jucator where email = @email";

        using MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@email", email);

        // Execut? query-ul ?i ob?ine rezultatul
        int numarEmailuri = Convert.ToInt32(cmd.ExecuteScalar());

        // Dac? num?rul email-urilor este mai mare decât 0, email-ul exist? deja în tabel
        return numarEmailuri > 0;

    }

    public bool checkIfUsernameExists(string username)
    {
        string query = "select count(*) from jucator where username = @username";

        using MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@username", username);

        // Dac? num?rul email-urilor este mai mare decât 0, email-ul exist? deja în tabel
        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;

    }

    public void addUser(string email, string username, string pwd)
    {
        string hashedPwd = PasswordHasher.HashPassword(pwd);
        string query = "INSERT INTO jucator (email, username, password) VALUES (@email, @username, @hashedPwd)";

        using (MySqlCommand cmd = new MySqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@hashedPwd", hashedPwd);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Debug.Log("Datele au fost introduse cu succes!");
            }
            else
            {
                Debug.Log("Nu s-au introdus datele.");
            }
        }
        
    }

    public bool userLogin(string email, string pwd)
    {
        if (!checkIfEmailExists(email))
            return false;
        //altfel verific parola aferenta email-ului introdus
        string query = "select password from jucator where email = @email";

        using MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@email", email);

        object result = cmd.ExecuteScalar();
        string storedHash = result.ToString();
       
        if (!PasswordHasher.VerifyPassword(pwd, storedHash))
            return false;
        return true;

    }

    public string fetchUsername(string email)
    {
        string query = "select username from jucator where email = @email";

        using MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@email", email);

        object result = cmd.ExecuteScalar();
        return result.ToString();
    }

    void OnDestroy()
    {
        if (connection != null && connection.State == ConnectionState.Open)
        {
            connection.Close();
            Debug.Log("Conexiunea la baza de date a fost inchisa");
        }
    }
}

