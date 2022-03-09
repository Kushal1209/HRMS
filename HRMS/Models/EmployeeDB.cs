using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using HRMS.Models;
using System.Configuration;

namespace HRMS_Portal.Models
{
    public class EmployeeDB
    {
        //private readonly EmployeeContext _ec = null;

        //public EmployeeDB(EmployeeContext ec)
        //{
        //    _ec = ec;
        //}

        //public int CreateEmpReq(RequestModel RequestModel)
        //{
        //    var empreq = new RequestModel
        //    {
        //        Firstname = RequestModel.Firstname,
        //        Lastname = RequestModel.Lastname,
        //        Email = RequestModel.Email,
        //        Mobile = RequestModel.Mobile,
        //        Doj = RequestModel.Doj,
        //        BUnitID = RequestModel.BUnitID,
        //        DeptID = RequestModel.DeptID,
        //        SDeptID = RequestModel.SDeptID,
        //        Designation = RequestModel.Designation,
        //        RMID = RequestModel.RMID
        //    };

        //    _ec.tbl_employeedetails.Add(empreq);
        //    _ec.SaveChanges();

        //    return empreq.EmpID;
        //}
    }
}
