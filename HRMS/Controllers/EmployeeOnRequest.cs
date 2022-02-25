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

namespace HRMS_Portal.Controllers
{
    public class EmployeeOnRequest : Controller
    {
        private readonly EmployeeContext _ec;

        EmployeeDB db = new EmployeeDB();

        public EmployeeOnRequest(EmployeeContext ec)
        {
            _ec = ec;
        }

        public IActionResult Index()
        {
            return View();
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

            //----- Department and Sub-Department List ----- //

            List<Dept> dept = new List<Dept>();
            dept = (from depart in _ec.tbl_dept
                    select depart).ToList();
            dept.Insert(0, new Dept { DeptID = 0, Department = "Select Department" });
            ViewBag.Listofdept = dept;

            return View();
        }

        //----- Department and Sub-Department List ----- //

        public JsonResult GETSubDept(int SDeptID)
        {
            List<SDept> sdept = new List<SDept>();

            sdept = (from subdept in _ec.tbl_sdept
                     where subdept.DeptID == SDeptID
                     select subdept).ToList();

            sdept.Insert(0, new SDept { SDeptID = 0, SubDepartment = "Select Sub-Department" });

            return Json(new SelectList(sdept, "SDeptID", "SubDepartment"));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OnboardRequest(RequestModel RequestModel, Dept depart, IFormCollection iformCollection, [Bind] RequestModel requestModel)
        {
            //----- Business Unit List Validation ----- //

            if (RequestModel.BUnitID == 0)
            {
                ModelState.AddModelError("", "Select Business Unit");
            }

            int bunitselectlist = RequestModel.BUnitID;
            ViewBag.bunitselectlist = RequestModel.BUnitID;

            List<BUnit> bunit = new List<BUnit>();
            bunit = (from busunit in _ec.tbl_bunit
                     select busunit).ToList();
            bunit.Insert(0, new BUnit { BUnitID = 0, Businessunit = "Select Business Unit" });
            ViewBag.Listofbunit = bunit;



            //----- Reporting Manager List----- //

            if (RequestModel.RMID == 0)
            {
                ModelState.AddModelError("", "Select Reporting Manager");
            }

            int rmselectlist = RequestModel.RMID;
            ViewBag.rmselectlist = RequestModel.RMID;

            List<RM> rm = new List<RM>();
            rm = (from rem in _ec.tbl_rm
                  select rem).ToList();
            rm.Insert(0, new RM { RMID = 0, ReportingManager = "Select Reporting Manager" });
            ViewBag.Listofrm = rm;



            //----- Department and Sub-Department List Validation----- //

            if (RequestModel.DeptID == 0)
            {
                ModelState.AddModelError("", "Select Department");
            }
            else if (RequestModel.SDeptID == 0)
            {
                ModelState.AddModelError("", "Select Sub-Department");
            }

            var SDeptID = HttpContext.Request.Form["SDeptID"].ToString();

            List<Dept> dept = new List<Dept>();
            dept = (from department in _ec.tbl_dept
                    select department).ToList();
            dept.Insert(0, new Dept { DeptID = 0, Department = "Select Department" });
            ViewBag.Listofdept = dept;
            return View(dept);

            try
            {
                if (ModelState.IsValid)
                {
                    string resp = db.AddEmployeeRecord(requestModel);
                    TempData["msg"] = resp;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }
    }
}