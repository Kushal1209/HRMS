using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HRMS.Models;
using HRMS_Portal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HRMS_Portal.Controllers
{
    public class EmployeeOnRequestController : Controller
    {

        private readonly EmployeeContext _ec;

        public EmployeeOnRequestController(EmployeeContext ec)
        {
            _ec = ec;
        }

        public IActionResult OnboardRequest()
        {
            //----- Business Unit List ----- //

            List<BUnit> bunit = new List<BUnit>();
            bunit = (from busunit in _ec.tbl_bunit
                     select busunit).ToList();
            bunit.Insert(0, new BUnit { BUnitID = 0, Businessunit = "Select Business Unit" });
            ViewBag.Listofbunit = bunit;

            //----- Reporting Manager List----- //

            List<RM> rm = new List<RM>();
            rm = (from rem in _ec.tbl_rm
                  select rem).ToList();
            rm.Insert(0, new RM { RMID = 0, ReportingManager = "Select Reporting Manager" });
            ViewBag.Listofrm = rm;

            //----- Department List ----- //

            List<Dept> dept = new List<Dept>();
            dept = (from depart in _ec.tbl_dept
                    select depart).ToList();
            dept.Insert(0, new Dept { DeptID = 0, Department = "Select Department" });
            ViewBag.Listofdept = dept;

            return View();
        }

        //----- SubDepartment List ----- //

        public JsonResult GETSubDept(int SDeptID)
        {
            List<SDept> sdept = new List<SDept>();

            sdept = (from subdept in _ec.tbl_sdept
                     where subdept.DeptID == SDeptID
                     select subdept).ToList();

            sdept.Insert(0, new SDept { SDeptID = 0, SubDepartment = "Select SubDepartment" });

            return Json(new SelectList(sdept, "SDeptID", "SubDepartment"));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OnboardRequest(RequestModel requestModel)
        {

            _ec.tbl_employeedetails.Add(requestModel);
            _ec.SaveChanges();

            return View();
        }

        public IActionResult AssignOnBoardReq()
        {
            return View();
        }
    }
}