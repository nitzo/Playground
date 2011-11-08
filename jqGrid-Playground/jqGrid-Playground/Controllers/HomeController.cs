using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace jqGrid_Playground.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GridData()
        {
            User u = new User()
                         {
                             Id = "2",
                             Name = "Nitzan",
                             Email = "nitzanbar@gmail.com"
                         };

            /// Serialize to JSON
            //var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(myPerson.GetType());
            //var ms = new MemoryStream();
            //serializer.WriteObject(ms, u);
            //string json = Encoding.Default.GetString(ms.ToArray());

            var jqres = new jqGridResult()
                            {
                                page = 1,
                                records = 1,
                                total = 1
                            };

/*            jqres.rows.Add(new jqGridRow()
                               {
                                   id = 1,
                                   cell = u
                               });*/

            jqres.rows.Add(u);

            return this.Json(jqres,JsonRequestBehavior.AllowGet);
            //return new JsonResult() {ContentEncoding = Encoding.UTF8, ContentType = "text/json", Data = u};

        }

        public ActionResult CellUpdate()
        {
            return new HttpStatusCodeResult(200);
        }

    }

   
    [DataContract]
    public class User
    {
       

        [DataMember]
        public string Name;

        [DataMember]
        public string Id;

        [DataMember]
        public string Email;
    }

    [DataContract]
    public class jqGridResult
    {

        public jqGridResult()
        {
            rows = new List<object>();
        }

        [DataMember] 
        public int total;

        [DataMember]
        public int page;

        [DataMember]
        public int records;

        [DataMember] public List<object> rows;
    }

    [DataContract]
    public class jqGridRow
    {
        [DataMember]
        public int id;

        [DataMember]
        public object cell;
    }
}
