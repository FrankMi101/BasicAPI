using BusinessOL;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PLF.Controllers
{/// <summary>
/// Professional Learning Form Web Api. provide the Form title and content Restful API call information
/// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PLFController : ApiController
    {
        /// <summary>
        /// call API method  http://localhost:9517/Api/PLF
        ///  this is a default API call.  Will return PLF form all Title and content items Json file by school and year.
        /// </summary>

        /// <returns>PLF Form content list  </returns>
        public IEnumerable<FormContent> Get()
        {

            List<FormContent> list = FormData.ListofContent("20182019", "0290");

            return list;
        }
        /// <summary>
        /// Call API method http://localhost:9517/api/PLF/?schoolYear=20182019schoolCode=0290
        /// pass school year 20182019 parameter 
        /// pass school code 0290 parameter
        /// </summary>
        /// <param name="schoolYear"> pass school year 20182019 parameter </param>
        /// <param name="schoolCode"> pass school code 0290 parameter </param>
        /// <returns></returns>
        // GET: api/PLF
        public IEnumerable<FormContent> Get(string schoolYear, string schoolCode)
        {

            List<FormContent> list = FormData.ListofContent(schoolYear, schoolCode);

            return list;
        }
        /// <summary>
        /// call API method http://localhost:9517/api/PLF/?schoolYear=20182019schoolCode=0290itemCode=PLP11 
        ///  by provide the itemCode, Web API will return one string value of itemCode  
        ///  pass school year 20182019 parameter
        ///  pass school Code 0290 parameter 
        ///  pass Item code PLP11 parameter
        /// </summary>
        /// <param name="schoolYear"> pass school year 20182019 parameter </param>
        /// <param name="schoolCode"> pass school Code 0290 parameter </param>
        /// <param name="itemCode">   pass Item code PLP11 parameter</param>
        /// <returns>PLF Form content by item code</returns>
        // GET: api/PLF/itemCode
        public string Get(string schoolYear, string schoolCode, string itemCode)
        {
            return FormData.Content("Content", "", "", schoolYear, schoolCode, itemCode);
        }

        /// <summary>
        ///  Call method http://localhost:9517/api/PLF/?schoolYear=20182019schoolCode=0290itemCode=PLP11value=myinputtext
        ///  by provide the value the Web API will save the value to database and return save or update action result.
        /// </summary>
        /// <param name="schoolYear"></param>
        /// <param name="schoolCode"></param>
        /// <param name="itemCode"></param>
        /// <param name="value"></param>
        /// <returns>PLF Form save content and get save result back</returns>
        // GET: api/PLF/itemCode/value
        public string Get(string schoolYear, string schoolCode, string itemCode, string value)
        {
            ParameterSP0 parameter = new ParameterSP0 { Operate = "Content", UserID="", UserRole ="", SchoolYear = schoolYear, SchoolCode = schoolCode, ItemCode =  itemCode, Value = value };

            return FormData.Content(parameter);
        }

        /// <summary>
        ///  http://localhost:9517/api/PLF/?userID=mif&schoolYear=20182019schoolCode=0290itemCode=PLP11 
        /// This is save the content to Database using POST method
        /// </summary>
        /// <param name="plfcontent">  PLF form content object </param>
      
        // POST: api/PLF 
        public void Post( FormContent1 plfcontent) 
        {
            ParameterSP0 parameter = new ParameterSP0 { Operate = "Content", SchoolYear = plfcontent.SchoolYear, SchoolCode = plfcontent.SchoolCode, ItemCode = plfcontent.ItemCode, Value = plfcontent.Notes };
            FormData.Content(parameter);
          //  FormData.Content("Content", plfcontent.Title, "", plfcontent.SchoolYear, plfcontent.SchoolCode, plfcontent.ItemCode, plfcontent.Notes);
        }

        /// <summary>
        /// PUT  method  not setup yet
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT: api/PLF/5
        public void Put(int id, [FromBody]string value)
        {
        }
        /// <summary>
        /// Delete Method. not setup yet
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/PLF/5
        public void Delete(int id)
        {
        }
    }
}
