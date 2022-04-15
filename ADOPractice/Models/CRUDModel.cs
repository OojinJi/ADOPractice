using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ADOPractice.Models
{
    public class CRUDModel
    {
        public DataTable GetALLStudents()
        {
            DataTable dt = new DataTable();
            string strConString = @"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog=Database1.mdf; Integrated Security=true";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tbleStudent", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;  

            
        }
        public DataTable GetStudentById(int intStudentID)
        {
            DataTable dt = new DataTable();
            string strConString = @"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog=Database1.mdf; Integrated Security=true";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblStudent where student_id" + intStudentID, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public int UpdateStudent(int intStudentID, string strStudentName, string strGender, int intAge)
        {
            string strConString = @"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog=Database1.mdf; Integrated Security=true";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = @"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog=Database1.mdf; Integrated Security=true";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studname", strStudentName);
                cmd.Parameters.AddWithValue("@studage", intAge);
                cmd.Parameters.AddWithValue("@gender", strGender);
                cmd.Parameters.AddWithValue("@studid", intStudentID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertStudent(string strStudentName, string strGender, int intAge)
        {
            string strConString = @"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog=Database1.mdf; Integrated Security=true";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Insert into tblStudent (student_name, student_age,student_gender) values(@studname, @studage , @gender)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studname", strStudentName);
                cmd.Parameters.AddWithValue("@studage", intAge);
                cmd.Parameters.AddWithValue("@gender", strGender);
                return cmd.ExecuteNonQuery();
            } 
        }

        public int DeleteStudent(int intStudentID)
        {
            string strConString = @"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog=Database1.mdf; Integrated Security=true";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = ("Delete from tblStudent where student_id=@studid");
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studid", intStudentID);
                return cmd.ExecuteNonQuery();
            }
        }

    }
}