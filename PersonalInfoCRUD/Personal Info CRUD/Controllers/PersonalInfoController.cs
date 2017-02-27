using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Personal_Info_CRUD.Models;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace Personal_Info_CRUD.Controllers
{
    public class PersonalInfoController : Controller
    {
        HttpClient client = new HttpClient();
        #region Constructor for httpclient 
         public PersonalInfoController()
         {
           client.BaseAddress = new Uri("http://localhost:51935/");
           client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/json"));
          }
        #endregion
        
        #region Get Information list
        public ActionResult Index()
        {  
            HttpResponseMessage response = client.GetAsync("api/infoes").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<PersonalInfoViewModel>>().Result;
            }
            return View();
        }
        #endregion
        
        #region Create Form Call
        public ActionResult Create()
        {
         return View();
        }
        #endregion

        #region Post Data to Api for Inserting
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonalInfoViewModel Piv)
        {
            Piv.DataInsertTime = DateTime.Now;    
            var Info = new JavaScriptSerializer().Serialize(Piv);
            HttpResponseMessage response = client.PostAsJsonAsync("api/infoes", Info).Result;
          
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<PersonalInfoViewModel>().Result;
            }
            return RedirectToAction("Index"); 
        }
        #endregion

        #region Edit Form with read from Api
        public ActionResult Edit(int SL)
        {
            HttpResponseMessage response = client.GetAsync("api/infoes/"+SL.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
            ViewBag.result = response.Content.ReadAsAsync<Info>().Result;
            }
            return View(ViewBag.result);
             }
        #endregion

        #region Edited Data post to Api
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonalInfoViewModel Piv,int SL)
        {
            Piv.SL = SL;
            Piv.DataInsertTime = DateTime.Now;
            var Info = new JavaScriptSerializer().Serialize(Piv);
            HttpResponseMessage response = client.PostAsJsonAsync("api/infoes", Info).Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<PersonalInfoViewModel>().Result;
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Data Post to api
        public ActionResult Delete(int SL)
        {
            InfoesController PIC = new InfoesController();
            PIC.Delete(SL);
            ViewBag.msg = "Delete Data";
            return RedirectToAction("Index");
            
        }
        #endregion
    }
}