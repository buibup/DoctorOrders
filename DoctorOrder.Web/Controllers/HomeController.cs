using DoctorOrder.Web.Models;
using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Mvc;
using static DoctorOrder.Web.Models.PatientDrugModels;

namespace DoctorOrder.Web.Controllers
{
    public class HomeController : Controller
    {
        string epiRowId = string.Empty;
        public ActionResult Index()
        {

            PatientDrugModel ptDrug = new PatientDrugModel();
            PatientDrugViewModels ptDrugVM = new PatientDrugViewModels();
            PatientDrugGroupViewModel ptDrugGVM = new PatientDrugGroupViewModel();

            HttpCookie lastEpiRowId = new HttpCookie("EpiRowId");
            HttpCookie testJson = new HttpCookie("testJson");

            if (Request.QueryString["epiRowId"] != null)
            {
                epiRowId = Request.QueryString["epiRowId"];
                lastEpiRowId["lastEpiRowId"] = epiRowId;
                lastEpiRowId.Expires = DateTime.Now.AddHours(1);
                Response.Cookies.Add(lastEpiRowId);

                string path = "";
                if (Request.QueryString["testJson"] != null) {
                    string[] filePath = Request.QueryString["testJson"].Split('|');
                    string fileName = Server.MapPath(filePath[0] + @"\" + filePath[1]);
                    path = Path.Combine(Environment.CurrentDirectory, filePath[0] + @"\", fileName);
                }
                else if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings["DataJsonTest"])) {
                    string[] filePath = ConfigurationManager.AppSettings["DataJsonTest"].ToString().Split('|');
                    string fileName = Server.MapPath(filePath[0] + @"\" + filePath[1]);
                    path = Path.Combine(Environment.CurrentDirectory, filePath[0] + @"\", fileName);
                }
                
                ptDrug = PatientDrugModels.GetPatientDrug(epiRowId, path);

                ptDrugVM = PatientDrugViewModels.GetPatientDrugViewModel(ptDrug);

                ptDrugGVM.ToPatientDrugGroupViewModel(ptDrugVM);

                ptDrugGVM = ptDrugGVM.GetPatientDrugGroupViewModel();

            }

            return View("Index", ptDrugGVM);

        }
        
    }
}