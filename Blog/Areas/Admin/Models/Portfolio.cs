using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Blog.Areas.Admin.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string About { get; set; }
        public DateTime DateCreate { get; set; }
        public string ProjectType { get; set; }
        public string Language { get; set; }
        public string WebPage { get; set; }
        public string SourceLocation { get; set; }
        public string ReleaseLocation { get; set; }

        public Portfolio()
        {
            Id = 0;
            Title = "";
            About = "";
            DateCreate = DateTime.Now;
            ProjectType = "";
            Language = "";
            WebPage = "";
            SourceLocation = "";
            ReleaseLocation = "";
        }

        public Portfolio(MySqlDataReader dataReader)
        {
            /*Id = Convert.ToInt32(dataReader["P.id"]);
            Title = dataReader["P.title"].ToString();
            DateCreate = DateTime.ParseExact(dataReader["P.date_create"].ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            ProjectType = dataReader["PT.name"].ToString();
            Language = dataReader["L.name"].ToString();
            WebPage = dataReader["P.web_page"].ToString();
            SourceLocation = dataReader["P.source_location"].ToString();
            ReleaseLocation = dataReader["P.release_location"].ToString();*/
            Id = dataReader.GetInt32(0);
            Title = dataReader.GetString(1);
            About = dataReader.GetString(2);
            DateCreate = dataReader.GetDateTime(3);
            ProjectType = dataReader.GetString(4);
            Language = dataReader.GetString(5);
            WebPage = dataReader.IsDBNull(6) ? "" : dataReader.GetString(6);
            SourceLocation = dataReader.IsDBNull(7) ? "" : dataReader.GetString(7);
            ReleaseLocation = dataReader.IsDBNull(8) ? "" : dataReader.GetString(8);
        }

        public Portfolio(string title, string about, DateTime date_create, string project_type, string language, string web_page, string source_location, string release_location)
        {
            Id = 0;
            Title = title;
            About = about;
            DateCreate = date_create;
            ProjectType = project_type;
            Language = language;
            WebPage = web_page;
            SourceLocation = source_location;
            ReleaseLocation = release_location;
        }
        public List<Portfolio> GetAll()
        {
            List<Portfolio> PortfolioList = new List<Portfolio>();

            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT P.id, P.title, P.text, P.date_create, PT.name, L.name, P.web_page, P.source_location, P.release_location FROM portfolio P, project_type PT, language L WHERE PT.id = P.id_project_type AND L.id = P.id_language";

                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();

                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while(sdr.Read())
                        {
                            PortfolioList.Add(new Portfolio(sdr));
                        }
                    }
                    con.Close();
                }
            }

            return PortfolioList;
        }

        public Portfolio Get(int id)
        {
            Portfolio portfolio = new Portfolio();

            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT P.id, P.title, P.text, P.date_create, PT.name, L.name, P.web_page, P.source_location, P.release_location FROM portfolio P, project_type PT, language L WHERE PT.id = P.id_project_type AND L.id = P.id_language";

                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();

                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        portfolio = new Portfolio(sdr);
                        /*Id = sdr.GetInt32(0);
                        Title = sdr.GetString(1);
                        DateCreate = sdr.GetDateTime(2);
                        ProjectType = sdr.GetString(3);
                        Language = sdr.GetString(4);
                        WebPage = sdr.IsDBNull(5) ? "" : sdr.GetString(5);
                        SourceLocation = sdr.IsDBNull(6) ? "" : sdr.GetString(6);
                        ReleaseLocation = sdr.IsDBNull(7) ? "" : sdr.GetString(7);*/
                    }
                    con.Close();
                }
            }

            return portfolio;
        }

        public bool Insert()
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "INSERT INTO portfolio (title, text, date_create, id_project_type, id_language, web_page, source_location, release_location) VALUES (@title, @text, @date_create, @id_type_project, @id_language, @web_page, @source_location, @release_location)";

                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();

                    cmd.Parameters.AddWithValue("@title", Title);
                    cmd.Parameters.AddWithValue("@text", About);
                    cmd.Parameters.AddWithValue("@date_create", DateCreate);
                    cmd.Parameters.AddWithValue("@id_type_project", ProjectType);
                    cmd.Parameters.AddWithValue("@id_language", Language);
                    cmd.Parameters.AddWithValue("@web_page", WebPage);
                    cmd.Parameters.AddWithValue("@source_location", SourceLocation);
                    cmd.Parameters.AddWithValue("@release_location", ReleaseLocation);

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
            return true;
        }

        public bool Insert(Portfolio portfolio)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "INSERT INTO portfolio VALUES (@title, @text, @date_create, @id_type_project, @id_language, @web_page, @source_location, @release_location)";

                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();

                    cmd.Parameters.AddWithValue("@title", portfolio.Title);
                    cmd.Parameters.AddWithValue("@text", portfolio.About);
                    cmd.Parameters.AddWithValue("@date_create", portfolio.DateCreate);
                    cmd.Parameters.AddWithValue("@id_type_project", 1);
                    cmd.Parameters.AddWithValue("@id_language", 1);
                    cmd.Parameters.AddWithValue("@web_page", (portfolio.WebPage.Length == 0) ? null : portfolio.WebPage);
                    cmd.Parameters.AddWithValue("@source_location", (portfolio.SourceLocation.Length == 0) ? null : portfolio.SourceLocation);
                    cmd.Parameters.AddWithValue("@release_location", (portfolio.ReleaseLocation.Length == 0) ? null : portfolio.ReleaseLocation);

                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
            return true;
        }

        public bool Update(Portfolio portfolio)
        {
            return false;
        }

        public bool Remove(Portfolio portfolio)
        {
            return false;
        }
    }
}