using SparkTecTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkTecTest.Controllers
{
    public class PaymentsController : Controller
    {
        PaymentDBModels PaymentsDb = new PaymentDBModels();
        public enum selectType
        {
            Dollars,
            Pesos,
            Items
        }

        // GET: Payments
        public ActionResult Index()
        {
            using (PaymentsDb = new PaymentDBModels())
            {

               // IEnumerable<Payments> payments = PaymentsDb.Database.ExecuteSqlCommand(@"Exec spGetPaymentsByUser @userId", new SqlParameter("userId", 1));

                return View(PaymentsDb.Payments.ToList());
            }

        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Create()
        {
              
            return View();

        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Payments payment)
        {

            using (PaymentsDb = new PaymentDBModels())
            {
                PaymentsDb.Payments.Add(payment);
                PaymentsDb.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            using (PaymentsDb = new PaymentDBModels())
            {
                return View(PaymentsDb.Payments.Where(p => p.paymentId == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Edit(Payments payment)
        {
            try
            {
                using (PaymentsDb = new PaymentDBModels())
                {
                    PaymentsDb.Entry(payment).State = EntityState.Modified;
                    PaymentsDb.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return View();
            }


            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(FormCollection formCollection)
        {

            var idaux = 0;
            using (PaymentsDb = new PaymentDBModels())
            {
                if (formCollection["selectedItems"].Length > 0)
                {


                    string[] ids = formCollection["selectedItems"].Split(new char[] { ',' });
                    foreach (string id in ids)
                    {
                        idaux = int.Parse(id);
                        PaymentsDb.Payments.Remove(PaymentsDb.Payments.Where(p => p.paymentId == idaux).FirstOrDefault());
                    }


                    PaymentsDb.SaveChanges();

                }
                return RedirectToAction("Index");
            }

        }


    }
}