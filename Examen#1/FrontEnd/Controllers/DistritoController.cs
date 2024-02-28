using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class DistritoController : Controller
    {
        IDistritoHelper DistritoHelper;

        public DistritoController(IDistritoHelper distritoHelper)
        {
            DistritoHelper = distritoHelper;
        }


        // GET: DistritoController
        public ActionResult Index()
        {
            List<DistritoViewModel> lista = DistritoHelper.GetDistritos();
            return View(lista);
        }

        // GET: DistritoController/Details/5
        public ActionResult Details(int id)
        {
            DistritoViewModel distrito = DistritoHelper.GetDistrito(id);
            return View(distrito);
        }

        // GET: DistritoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DistritoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DistritoViewModel distrito)
        {
            try
            {
                DistritoHelper.AddDistrito(distrito);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DistritoController/Edit/5
        public ActionResult Edit(int id)
        {

            DistritoViewModel distrito = DistritoHelper.GetDistrito(id);
            return View(distrito);
        }

        // POST: DistritoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DistritoViewModel distrito)
        {
            try
            {
                DistritoHelper.UpdateDistrito(distrito);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DistritoController/Delete/5
        public ActionResult Delete(int id)
        {

            DistritoViewModel distrito = DistritoHelper.GetDistrito(id);
            return View(distrito);
        }

        // POST: DistritoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DistritoViewModel distrito)
        {
            try
            {
                DistritoHelper.DeleteDistrito(distrito.DistritoId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}