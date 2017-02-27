using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Personal_Info_CRUD.Models;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;

namespace Personal_Info_CRUD.Controllers
{
    public class InfoesController : ApiController
    {
        private PersonalInfoEntities db = new PersonalInfoEntities();


        // GET: api/Infoes
        #region Show Information
        public IEnumerable<Info> GetInfoes()
        {
            return db.Infoes;
        }
        #endregion
       
        // GET: api/Infoes/5
        #region Single Data Return
        [ResponseType(typeof(Info))]
        public IHttpActionResult GetInfo(int id)
        {
            Info info = db.Infoes.Find(id);
            if (info == null)
            {
                return NotFound();
            }

            return Ok(info);
        }
        #endregion

        // PUT: api/Infoes/5
        // POST: api/Infoes
        #region Insert and Update Information
        [ResponseType(typeof(void))]
        public IHttpActionResult PostInfo(JToken Info)
        {
            Info inf = new Info();
            inf = new JavaScriptSerializer().Deserialize<Info>(Info.ToString());
            if(inf.SL>0)
            {
                //store procedure for Update Info
                db.SP_UpdatePersonalInfo(inf.Name, inf.Age, inf.DOB, inf.Address, inf.Status, DateTime.Now,inf.SL);
            }
            else
            {   
                //store procedure for Insert Info
                db.SP_AddPersonalInfo(inf.Name, inf.Age, inf.DOB, inf.Address, inf.Status);
                db.SaveChanges();
            }
         
            return Ok();
        }
        #endregion

        // DELETE: api/Infoes/5
        #region Delete Information
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int SL)
        {
            db.SP_DeletePersonalInfo(SL);
            db.SaveChanges();
            return Ok(SL);
        }
        #endregion

    }
}