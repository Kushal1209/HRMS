using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using HRMS.Models;

namespace HRMS_Portal.Models
{
    public class EmployeeDB
    {
        SqlConnection conn = new SqlConnection("Data Source=(localdb)//ProjectModels;Initial Catalog=exigotech;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public string AddEmployeeRecord(RequestModel requestModel)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("cp_CreateEmpRequest", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstname", requestModel.Firstname);
                cmd.Parameters.AddWithValue("@lastname", requestModel.Lastname);
                cmd.Parameters.AddWithValue("@email", requestModel.Email);
                cmd.Parameters.AddWithValue("@mobile", requestModel.Mobile);
                cmd.Parameters.AddWithValue("@doj", requestModel.Doj);
                cmd.Parameters.AddWithValue("@bunitid", requestModel.BUnitID);
                cmd.Parameters.AddWithValue("@deptid", requestModel.DeptID);
                cmd.Parameters.AddWithValue("@sdeptid", requestModel.SDeptID);
                cmd.Parameters.AddWithValue("@designation", requestModel.Designation);
                cmd.Parameters.AddWithValue("@rmid", requestModel.RMID);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return ("Onboarding Request Created Successfully!!");
            }
            catch (Exception ex)
            {
                if (conn.State==ConnectionState.Open)
                {
                    conn.Close();
                }
                return (ex.Message.ToString());
            }
        }

    }
}
