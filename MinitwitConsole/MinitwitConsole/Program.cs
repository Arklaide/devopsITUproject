using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using Npgsql;

namespace MinitwitConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            string docStr = "ITU-Minitwit Tweet Flagging Tool\n\n Usage:\n  flag_tool <tweet_id>...\n flag_tool -i\n flag_tool -h\n Options:\n -h            Show this screen.\n -i            Dump all tweets and authors to STDOUT.\n";

            Console.WriteLine("Getting Connection ...");

            var cs = "Server=db-postgresql-fra1-81861-do-user-10848725-0.b.db.ondigitalocean.com;Port=25060;Database=defaultdb;User Id=doadmin;Password=NXtS7RFWPWnqlcJX;Include Error Detail=true;";

            using var con = new NpgsqlConnection(cs);


            try
            {
                Console.WriteLine("Openning Connection ...");

                //opening connection
                con.Open();

                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            var argument = Console.ReadLine();
            switch (argument)
            {
                case "-h":
                    Console.WriteLine(docStr);
                    break;
                case "-i":
                    PrintTwits(con);
                    break;
                default:
                    if (argument == null)
                    {

                    }
                    else
                    {
                        SetFlagged(con, argument.Split());

                    }
                    break;
            }

            Console.Read();
        }

        private static void PrintTwits(NpgsqlConnection con) {
            //string sql = "SELECT * FROM  \"Message\" limit 10";
            string sql = @"SELECT * FROM ""Message"" limit 10";
            using var cmd = new NpgsqlCommand(sql, con);

            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine("{0} \t {1}  \t {2} \t {3}", rdr.GetInt32(0), rdr.GetString(1),
                        rdr.GetDateTime(2), rdr.GetInt32(4));
            }
        }
        private static void SetFlagged(NpgsqlConnection con, string[] ids) {
         
            int i;
            for (i = 0; i < ids.Length; i++)
            {
                try
                {
                    var intvalue = int.Parse(ids[i]);   
                }
                catch {
                    Console.WriteLine("Unable to parse integer value: " + ids[i]);
                    return;
                }
                try
                {
                    var UpdateCmd = @"UPDATE ""Message"" SET flagged = true WHERE ""message_Id"" = @p1";


                    using (NpgsqlCommand command = new NpgsqlCommand(UpdateCmd, con))
                    {
                        command.Parameters.AddWithValue("p1", int.Parse(ids[i]));
                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine("Flagged entry: " + ids[i]);
                }
                catch(Exception e) {
                    Console.WriteLine("SQL error" + e.Message);
                }
                
            }
            
        }
    }
}





//#include <sqlite3.h>
//#include <stdio.h>
//#include <stdlib.h>
//#include <string.h>

//char* docStr = "ITU-Minitwit Tweet Flagging Tool\n\n"
//               "Usage:\n"
//               "  flag_tool <tweet_id>...\n"
//               "  flag_tool -i\n"
//               "  flag_tool -h\n"
//               "Options:\n"
//               "-h            Show this screen.\n"
//               "-i            Dump all tweets and authors to STDOUT.\n";

//static int callback(void* data, int argc, char** argv, char** azColName)
//{
//    printf("%s,%s,%s,%s\n", argv[0] ? argv[0] : "NULL",
//           argv[1] ? argv[1] : "NULL", argv[2] ? argv[2] : "NULL",
//           argv[4] ? argv[4] : "NULL");
//    return 0;
//}

//int main(int argc, char* argv[])
//{
//    sqlite3* db;
//    char* zErrMsg = 0;
//    int rc;
//    char query[256];
//    const char* data = "Callback function called";

//    rc = sqlite3_open("/tmp/minitwit.db", &db);
//    if (rc)
//    {
//        fprintf(stderr, "Can't open database: %s\n", sqlite3_errmsg(db));
//        return (0);
//    }
//    if (argc == 2 && strcmp(argv[1], "-h") == 0)
//    {
//        fprintf(stdout, "%s\n", docStr);
//    }
//    if (argc == 2 && strcmp(argv[1], "-i") == 0)
//    {
//        strcpy(query, "SELECT * FROM message");
//        /* Execute SQL statement */
//        rc = sqlite3_exec(db, query, callback, (void*)data, &zErrMsg);
//        if (rc != SQLITE_OK)
//        {
//            fprintf(stderr, "SQL error: %s\n", zErrMsg);
//            sqlite3_free(zErrMsg);
//        }
//    }
//    if (argc >= 2 && strcmp(argv[1], "-i") != 0 && strcmp(argv[1], "-h") != 0)
//    {
//        int i;
//        for (i = 1; i < argc; i++)
//        {
//            strcpy(query, "UPDATE message SET flagged=1 WHERE message_id=");
//            strcat(query, argv[i]);
//            rc = sqlite3_exec(db, query, callback, (void*)data, &zErrMsg);
//            if (rc != SQLITE_OK)
//            {
//                fprintf(stderr, "SQL error: %s\n", zErrMsg);
//                sqlite3_free(zErrMsg);
//            }
//            else
//            {
//                printf("Flagged entry: %s\n", argv[i]);
//            }
//        }
//    }

//    sqlite3_close(db);
//    return 0;
//}