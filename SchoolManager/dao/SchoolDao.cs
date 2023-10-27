using MySql.Data.MySqlClient;
using SchoolManager.entity;
using SchoolManager.entity.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.dao
{
    internal class SchoolDao
    {
        private string connString = "server=localhost;port=3306;database=school;user=root;password=123456";

        private static SchoolDao? instance;
        
        public static SchoolDao GetInstance()
        {
            instance ??= new SchoolDao();
            return instance;
        }

        private void log(string type, string tableName)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO log (type,table_name,time) VALUES (@type,@tableName,@time)", conn);
                cmd.Parameters.AddWithValue("type", type);
                cmd.Parameters.AddWithValue("tableName", tableName);
                cmd.Parameters.AddWithValue("time", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }

        public List<LogInfo> GetLog()
        {
            using(MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM log",conn);
                var reader=cmd.ExecuteReader();
                var list = new List<LogInfo>();
                while (reader.Read())
                {
                    list.Add(new LogInfo
                    {
                        Id = reader.GetInt32("id"),
                        Type = reader.GetString("type"),
                        TableName = reader.GetString("table_name"),
                        Time = (DateTime)reader["time"]
                    });
                }
                return list;
            }
        }

        public string GetSchoolInfo()
        {
            using(MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM school", conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return reader.GetString(0);
                }
                else return string.Empty;
            }
        }
        public List<ISchool> GetClasses()
        {
            List<ISchool> list = new List<ISchool>();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM class",conn);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new Class()
                        {
                            Cid = (int)reader["id"],
                            Cname = (string)reader["name"],
                            Children = GetStudentsFromClass((int)reader["id"])
                        });
                    }            
                }
            }
            return list;
        }

        public List<ISchool> GetStudentsFromClass(int classId)
        {
            List<ISchool> list = new List<ISchool>();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM student WHERE from_class="+classId,conn);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new Student()
                        {
                            Sid = (int)reader["id"],
                            Sname = (string)reader["name"],
                            FromClass = (int)reader["from_class"]
                        });
                    }
                }
            }
            return list;
        }

        public int AddClass(string className)
        {
            log("Insert", "class");
            using(MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO class (name) VALUES (@className)",conn);
                command.Parameters.AddWithValue("className", className);
                command.ExecuteNonQuery();
                MySqlCommand command2 = new MySqlCommand("SELECT id FROM class WHERE name=@className", conn);
                command2.Parameters.AddWithValue("className", className);
                var reader= command2.ExecuteReader();
                reader.Read();
                return (int)reader["id"];
            }
        }

        public int AddStudent(string name,int from)
        {
            log("Insert", "student");
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO student (name,from_class) VALUES (@name,@from)",conn);
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("from",from);
                command.ExecuteNonQuery();

                MySqlCommand command2 = new MySqlCommand("SELECT id FROM student WHERE name=@name", conn);
                command2.Parameters.AddWithValue("name", name);
                var reader = command2.ExecuteReader();
                reader.Read();
                return (int)reader["id"];
            }
        }

        public int DeleteClass(int id)
        {
            log("Delete", "class");
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM class WHERE id=@id", conn);
                command.Parameters.AddWithValue("id", id);
                return command.ExecuteNonQuery();   
            }
        }
        public int DeleteStudent(int id)
        {
            log("Delete", "student");
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM student WHERE id=@id", conn);
                command.Parameters.AddWithValue("id", id);
                return command.ExecuteNonQuery();
            }
        }

        public int UpdateClass(int id,string name)
        {
            log("Update", "class");
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("UPDATE class SET name=@name WHERE id=@id", conn);
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("id", id);
                return command.ExecuteNonQuery();
            }
        }

        public int UpdateStudent(int id,string name)
        {
            log("Update", "student");
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("UPDATE student SET name=@name WHERE id=@id", conn);
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("id", id);
                return command.ExecuteNonQuery();
            }
        }

        public int UpdateSchool(string name)
        {
            log("Update", "school");
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("UPDATE school SET name=@name", conn);
                command.Parameters.AddWithValue("name", name);
                return command.ExecuteNonQuery();
            }
        }
    }
}
