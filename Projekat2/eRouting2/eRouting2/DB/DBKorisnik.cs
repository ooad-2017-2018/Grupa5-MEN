using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;

namespace eRouting2
{
    class DBKorisnik
    {
        public List<Korisnik> Korisnici { get; set; }
        public DBKorisnik()
        {
            Korisnici = new List<Korisnik>();
        }
        public void UcitajKorisnike()
        {
            try
            {
                Korisnici = new List<Korisnik>();
                string query = "SELECT * FROM Korisnik;";
                DBConnectionString s = new DBConnectionString();
                using (SqlConnection c = new SqlConnection(s.GetString()))
                {
                    c.Open();
                    if(c.State== System.Data.ConnectionState.Open)
                    {
                        SqlCommand sc = c.CreateCommand();
                        sc.CommandText = query;
                        SqlDataReader reader = sc.ExecuteReader();
                        while (reader.Read())
                        {
                            Korisnik k = new Korisnik(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetInt32(6), reader.GetInt32(7));
                            Korisnici.Add(k);
                        }
                    }
                    c.Close();
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine("Exception: " + e.Message);

            }

        }
        public void ObrisiKorisnika(Korisnik k)
        {
            try
            {
                string query = "DELETE FROM Korisnik WHERE username = :username;";
                DBConnectionString s = new DBConnectionString();
                using (SqlConnection con = new SqlConnection(s.GetString()))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;
                    SqlParameter username = new SqlParameter();
                    username.Value = k.Username;
                    username.ParameterName = "username";
                    cmd.Parameters.Add(username);
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                        cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine("Exception: " + e.Message);
            }
        }
        public int UnesiKorisnika (Korisnik k)
        {
            try
            {
                string query = "INSERT INTO Korisnik VALUES (:Ime, :Prezime, :Email, :Username, :Password;)";
                DBConnectionString s = new DBConnectionString();
                using (SqlConnection con = new SqlConnection(s.GetString()))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;

                    SqlParameter Ime = new SqlParameter();
                    Ime.Value = k.Ime;
                    Ime.ParameterName = "Ime";
                    cmd.Parameters.Add(Ime);

                    SqlParameter Prezime = new SqlParameter();
                    Prezime.Value = k.Prezime;
                    Prezime.ParameterName = "Prezime";
                    cmd.Parameters.Add(Prezime);

                    SqlParameter Email = new SqlParameter();
                    Email.Value = k.Email;
                    Email.ParameterName = "Email";
                    cmd.Parameters.Add(Email);

                    SqlParameter Username = new SqlParameter();
                    Username.Value = k.Username;
                    Username.ParameterName = "Username";
                    cmd.Parameters.Add(Username);

                    SqlParameter Password = new SqlParameter();
                    Password.Value = k.Password;
                    Password.ParameterName = "Password";
                    cmd.Parameters.Add(Password);

                    int r = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    return r;

                }
            }
            catch(Exception e)
            {
                Debug.WriteLine("Exception: " + e.Message);
                return 0;
            }
        }

    }
}
