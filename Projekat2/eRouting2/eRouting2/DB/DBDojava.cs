using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;

namespace eRouting2
{
    class DBDojava
    {
        public List<Dojava> Dojave { get; set; }
        public DBDojava()
        {
            Dojave = new List<Dojava>();
        }
        public void ucitajAdministratore()
        {
            try
            {
                Dojave = new List<Dojava>();
                String query = "SELECT * FROM Dojava;";
                DBConnectionString s = new DBConnectionString();
                using (SqlConnection con = new SqlConnection(s.GetString()))
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = query;
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                           // Dojava a = new Dojava(reader.GetInt32(0), vrsta, List<>, reader.GetDateTime(3), reader.GetString(4));
                            //Dojave.Add(a);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception: " + e.Message);
            }
        }
        public int brisiDojavu(Dojava d)
        {
            try
            {
                String query = "DELETE FROM Dojava WHERE id = :id;";
                DBConnectionString s = new DBConnectionString();
                using (SqlConnection con = new SqlConnection(s.GetString()))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;
                    SqlParameter id = new SqlParameter();
                    id.Value = d.Id;
                    id.ParameterName = "id";
                    cmd.Parameters.Add(id);
                    con.Open();
                    int r = 0;
                    if (con.State == System.Data.ConnectionState.Open)
                        r = cmd.ExecuteNonQuery();
                    con.Close();
                    return r;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception: " + e.Message);
                return 0;
            }
        }
        public int unesiDojavu(Dojava d)
        {
            try
            {
                String query = "insert into Dojava " +
                    "values (:Id,:,:Vrsta,:Ocjene,:ProcjenaCekanja,:Lokacija)";
                DBConnectionString s = new DBConnectionString();
                using (SqlConnection con = new SqlConnection(s.GetString()))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;

                    SqlParameter id = new SqlParameter();
                    id.Value = d.Id;
                    id.ParameterName = "id";

                    SqlParameter vrsta = new SqlParameter();
                    vrsta.Value = d.Vrsta;
                    vrsta.ParameterName = "vrsta";

                    SqlParameter ocjene = new SqlParameter();
                    ocjene.Value = d.Ocjene;
                    ocjene.ParameterName = "ocjene";

                    SqlParameter procjenaCekanja = new SqlParameter();
                    procjenaCekanja.Value = d.ProcjenaCekanja;
                    procjenaCekanja.ParameterName = "procjenaCekanja";

                    SqlParameter lokacija= new SqlParameter();
                    lokacija.Value = d.Lokacija;
                    lokacija.ParameterName = "lokacija";

                    cmd.Parameters.Add(id);
                    cmd.Parameters.Add(vrsta);
                    cmd.Parameters.Add(ocjene);
                    cmd.Parameters.Add(procjenaCekanja);
                    cmd.Parameters.Add(lokacija);

                    int k = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    return k;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception: " + e.Message);
                return 0;
            }
        }
    }
}
