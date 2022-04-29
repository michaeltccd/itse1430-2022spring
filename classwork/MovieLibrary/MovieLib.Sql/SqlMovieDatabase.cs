using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MovieLib.Sql
{
    /// <summary>Provides an implementation of <see cref="IMovieDatabase"/> using a SQL Server database.</summary>
    public class SqlMovieDatabase : MovieDatabase
    {
        /// <summary>Initializes an instance of the <see cref="SqlMovieDatabase"/> class.</summary>
        /// <param name="connectionString">The connection string.</param>
        public SqlMovieDatabase ( string connectionString )
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;

        protected override Movie AddCore ( Movie movie )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("AddMovie", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Add parameters
                //Approach 1 - Preferred for SQL
                cmd.Parameters.AddWithValue("@name", movie.Title);
                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.Duration);
                cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);

                //Approach 2 - when type detection won't work
                var parmRating = cmd.Parameters.Add("@rating", SqlDbType.NVarChar);
                parmRating.Value = movie.Rating;

                //Approach 3 - need complete control over parameter or access after call
                var parmDescription = new SqlParameter("@description", movie.Description);
                cmd.Parameters.Add(parmDescription);

                //Approach 4 - needs to be generic
                var parmGenre = cmd.CreateParameter();
                parmGenre.ParameterName = "@genre";
                parmGenre.DbType = DbType.String;
                parmGenre.Value = movie.Genre;
                cmd.Parameters.Add(parmGenre);

                object result = cmd.ExecuteScalar();

                movie.Id = Convert.ToInt32(result);
            };

            return movie;
        }

        protected override void DeleteCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                //Command - approach 2
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DeleteMovie";
                cmd.CommandType = CommandType.StoredProcedure;

                //Always use parameters to pass data to SQL
                // name: user input
                //SELECT * FROM Movies WHERE Name = ' + name + '
                // name: '; DELETE FROM Movies; + '                

                //Add parameter - approach 1
                cmd.Parameters.AddWithValue("@id", id);

                //Execute - no results (delete/updates)
                cmd.ExecuteNonQuery();
            };
        }

        protected override Movie FindByName ( string name )
        {
            //Streamed read
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("FindByName", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", name);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return LoadMovie(reader);
                    };
                };
            };

            return null;
        }

        protected override IEnumerable<Movie> GetAllCore ()
        {
            DataSet ds = new DataSet();

            //IDisposable
            using (var conn = OpenConnection())
            {
                //Create command - approach 1
                var command = new SqlCommand("GetMovies", conn);

                //Buffered IO                
                var da = new SqlDataAdapter(command);

                da.Fill(ds);
            };

            //Get the first table, have to use OfType<T> to get IEnumerable<T>
            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table != null)
                return table.Rows.OfType<DataRow>().Select(LoadMovie);

            return Enumerable.Empty<Movie>();
        }

        private Movie LoadMovie ( DataRow row )
        {
            return new Movie() {
                Id = Convert.ToInt32(row[0]),    //Array-based index and convert
                Title = row["Name"].ToString(),  //Array-based name and convert
                Description = row.Field<string>(2),     //Field-based index
                Duration = row.Field<int>("RunLength"), //Field-based name
                Rating = row.Field<string>("Rating"),
                ReleaseYear = row.Field<int>("ReleaseYear"),
                Genre = row.Field<string>("Genre"),
                IsClassic = row.Field<bool>("IsClassic"),
            };
        }

        private SqlConnection OpenConnection ()
        {
            //IDisposable
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }

        protected override Movie GetCore ( int id )
        {
            //Streamed read
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("GetMovie", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return LoadMovie(reader);
                    };
                };
            };

            return null;
        }

        private static Movie LoadMovie ( SqlDataReader reader ) => new Movie() {
            Id = Convert.ToInt32(reader[0]),    //Array-based index and convert
            Title = reader["Name"]?.ToString(),  //Array-based name and convert
            Description = reader.IsDBNull(2) ? "" : reader.GetFieldValue<string>(2),     //Field-based index
            Duration = reader.GetFieldValue<int>("RunLength"), //Field-based name
            Rating = reader.GetString(3),                  //Type-based ordinal
            ReleaseYear = reader.GetInt32("ReleaseYear"),  //Type-based name
            Genre = reader.GetFieldValue<string>("Genre"),
            IsClassic = reader.GetFieldValue<bool>("IsClassic"),
        };
        protected override void UpdateCore ( int id, Movie movie )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("UpdateMovie", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Add parameters
                //Approach 1 - Preferred for SQL
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", movie.Title);
                cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
                cmd.Parameters.AddWithValue("@runLength", movie.Duration);
                cmd.Parameters.AddWithValue("@isClassic", movie.IsClassic);

                //Approach 2 - when type detection won't work
                var parmRating = cmd.Parameters.Add("@rating", SqlDbType.NVarChar);
                parmRating.Value = movie.Rating;

                //Approach 3 - need complete control over parameter or access after call
                var parmDescription = new SqlParameter("@description", movie.Description);
                cmd.Parameters.Add(parmDescription);

                //Approach 4 - needs to be generic
                var parmGenre = cmd.CreateParameter();
                parmGenre.ParameterName = "@genre";
                parmGenre.DbType = DbType.String;
                parmGenre.Value = movie.Genre;
                cmd.Parameters.Add(parmGenre);

                cmd.ExecuteNonQuery();
            };
        }
    }
}
