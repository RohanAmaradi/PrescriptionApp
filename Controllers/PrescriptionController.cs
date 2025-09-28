using Microsoft.AspNetCore.Mvc;
using PrescriptionApp.Data;
using PrescriptionApp.Models;
using System.Threading.Tasks;

namespace PrescriptionApp.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PrescriptionController(ApplicationDbContext db) => _db = db;

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Action = "Add";
            var model = new Prescription { FillStatus = "New", RequestTime = System.DateTime.Now };
            return View("AddEdit", model);
        }

        [HttpPost]
        public IActionResult Create(Prescription p)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Action = "Add";
                return View("AddEdit", p);
            }

            p.RequestTime = System.DateTime.Now;
            _db.Prescriptions.Add(p);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Edit(int id, string? slug) // slug accepted
        {
            var prescription = _db.Prescriptions.Find(id);
            if (prescription == null) return RedirectToAction("Index", "Home");
            ViewBag.Action = "Edit";
            return View("AddEdit", prescription);
        }

        [HttpPost]
        public IActionResult Edit(Prescription form)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Action = "Edit";
                return View("AddEdit", form);
            }

            var prescription = _db.Prescriptions.Find(form.PrescriptionId);
            if (prescription == null) return RedirectToAction("Index", "Home");

            prescription.MedicationName = form.MedicationName;
            prescription.FillStatus = form.FillStatus;
            prescription.Cost = form.Cost;

            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Delete(int id, string? slug) // slug accepted
        {
            var prescription = _db.Prescriptions.Find(id);
            if (prescription == null) return RedirectToAction("Index", "Home");
            return View(prescription);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int PrescriptionId)
        {
            var prescription = _db.Prescriptions.Find(PrescriptionId);
            if (prescription != null)
            {
                _db.Prescriptions.Remove(prescription);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}