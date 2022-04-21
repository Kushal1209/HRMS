using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using HRMS.Data;

namespace HRMS.Controllers
{
    public class EmpController : Controller
    {

        private readonly EmpDbContext _context;

        public EmpController(EmpDbContext context)
        {
            _context = context;
        }

        public IActionResult OnboardRequest()
        {
            //----- Business Unit List ----- //

            List<BUnit> bunit = new List<BUnit>();
            bunit = (from busunit in _context.tbl_bunit
                     select busunit).ToList();
            bunit.Insert(0, new BUnit { BUnitID = 0, Businessunit = "Select Business Unit" });
            ViewBag.Listofbunit = bunit;

            //----- Reporting Manager List----- //

            List<RM> rm = new List<RM>();
            rm = (from rem in _context.tbl_rm
                  select rem).ToList();
            rm.Insert(0, new RM { RMID = 0, ReportingManager = "Select Reporting Manager" });
            ViewBag.Listofrm = rm;

            //----- Department List ----- //

            List<Dept> dept = new List<Dept>();
            dept = (from depart in _context.tbl_dept
                    select depart).ToList();
            dept.Insert(0, new Dept { DeptID = 0, Department = "Select Department" });
            ViewBag.Listofdept = dept;

            return View();
        }

        //----- SubDepartment List ----- //

        public JsonResult GETSubDept(int SDeptID)
        {
            try
            {
                List<SDept> sdept = new List<SDept>();

                sdept = (from subdept in _context.tbl_sdept
                         where subdept.DeptID == SDeptID
                         select subdept).ToList();

                sdept.Insert(0, new SDept { SDeptID = 0, SubDepartment = "Select SubDepartment" });

                return Json(new SelectList(sdept, "SDeptID", "SubDepartment"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OnboardRequest(RequestModel requestModel)
        {
            //if (ModelState.IsValid)
            //{
            try
            {
                _context.tbl_employeedetails.Add(requestModel);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //}
            return RedirectToAction(nameof(AssignOnBoardReq));
        }

        // GET: Emp
        public async Task<IActionResult> AssignOnBoardReq()
        {
            var assignOnBoardReq = (from asd in _context.tbl_assignonboardreq
                                    join tm in _context.tbl_tasks on asd.TaskID equals tm.TaskID
                                    join am in _context.tbl_assignee on asd.AssigneeID equals am.AssigneeID
                                    select new AssignOnBoardReq
                                    {
                                        AssignTaskID = asd.AssignTaskID,
                                        TaskID = tm.TaskID,
                                        TaskName = tm.TaskName,
                                        AssigneeID = am.AssigneeID,
                                        AssigneeName = am.AssigneeName,
                                        DueDate = asd.DueDate
                                    }).ToList();

            //return View(assignOnBoardReq);

            return View(await _context.tbl_assignonboardreq.ToListAsync());
        }

        // GET: Task/AddOrEdit
        // GET: Task/AddOrEdit/5

        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            //----- Assignee List -----
            List<Assignee> assign = new List<Assignee>();
            assign = (from assignee in _context.tbl_assignee
                      select assignee).ToList();
            assign.Insert(0, new Assignee { AssigneeID = 0, AssigneeName = "Select Assignee" });
            ViewBag.Listofassign = assign;

            //----- Task List -----
            List<Tasks> tasklst = new List<Tasks>();
            tasklst = (from tasks in _context.tbl_tasks
                       select tasks).ToList();
            tasklst.Insert(0, new Tasks { TaskID = 0, TaskName = "Select Task" });
            ViewBag.Listoftask = tasklst;

            if (id == 0)
            {
                return View(new AssignOnBoardReq());
            }
            else
            {
                var assignOnBoardReq = await _context.tbl_assignonboardreq.FindAsync(id);
                if (assignOnBoardReq == null)
                {
                    return NotFound();
                }
                return View(assignOnBoardReq);
            }
        }



        // POST: Emp/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("AssignTaskID, TaskID, TaskName, AssigneeID, AssigneeName, DueDate")] AssignOnBoardReq assignOnBoardReq)
        {
            //if (ModelState.IsValid)
            //{
            if (id == 0)
            {
                _context.tbl_assignonboardreq.Add(assignOnBoardReq);
                await _context.SaveChangesAsync();
            }
            else
            {
                try
                {
                    _context.tbl_assignonboardreq.Update(assignOnBoardReq);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignOnBoardReqExists(assignOnBoardReq.AssignTaskID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.tbl_assignonboardreq.ToList()) });
            //}
            //return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", assignOnBoardReq) });
        }

        // GET: Emp/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var assignOnBoardReq = await _context.tbl_assignonboardreq
        //        .FirstOrDefaultAsync(m => m.AssignTaskID == id);
        //    if (assignOnBoardReq == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(assignOnBoardReq);
        //}

        // POST: Emp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignOnBoardReq = await _context.tbl_assignonboardreq.FindAsync(id);
            _context.tbl_assignonboardreq.Remove(assignOnBoardReq);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.tbl_assignonboardreq.ToList()) });
        }

        private bool AssignOnBoardReqExists(int id)
        {
            return _context.tbl_assignonboardreq.Any(e => e.AssignTaskID == id);
        }
    }
}