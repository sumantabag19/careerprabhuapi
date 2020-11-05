using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CareerPrahuWebAPI.AppData;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using HtmlToOpenXml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using OfficeOpenXml;
using OfficeOpenXml.Style;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CareerPrahuWebAPI.WebAPI
{

    [Authorize]
    [ApiController]
    [Route("api")]
    public class CareerPrabhuAppAPI : Controller
    {
        IConfiguration _iconfiguration;
        int status = 0;


        [Obsolete]
        public CareerPrabhuAppAPI(IConfiguration iconfiguration, IHostingEnvironment hosting)
        {
            _iconfiguration = iconfiguration;
            _hostingEnvironment = hosting;
            //Response.ContentType = "application/json ; charset=utf-8";
        }

        [Obsolete]
        private IHostingEnvironment _hostingEnvironment;


        //API for bind state
        [HttpGet]
        [AllowAnonymous]
        [Route("Getstate")]
        public IActionResult BindState()
        {
            DataSet ds = new DataSet();
            string json = "";

            StateResponse StateRes = new StateResponse();
            List<StateDetail> objstate = new List<StateDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("BindState", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    StateRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        StateDetail objlist = new StateDetail();
                        objlist.statename = Convert.ToString(row["state_name"]);
                        objlist.stateid = Convert.ToInt32(row["state_id"]);

                        objstate.Add(objlist);
                    }

                    StateRes.data = objstate;
                    StateRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(StateRes, settings);
                }
                else
                {
                    StateRes.status = false;
                    StateRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(StateRes, settings);

                }

            }
            catch (Exception ex)
            {

                StateRes.status = false;
                StateRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(StateRes, settings);

            }

            return Ok(json);
        }



        [HttpGet]
    
        [Route("GetCareerListing")]
        public IActionResult GetCareerListing()
        {
            DataSet ds = new DataSet();
            string json = "";

            CareerListingResponse StateRes = new CareerListingResponse();
            List<CareerListingDetail> objstate = new List<CareerListingDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("bindcareerlisting_career", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    StateRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        CareerListingDetail objlist = new CareerListingDetail();
                        objlist.career = Convert.ToString(row["career"]);
                        objlist.careerid = Convert.ToInt32(row["careerid"]);

                        objstate.Add(objlist);
                    }

                    StateRes.data = objstate;
                    StateRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(StateRes, settings);
                }
                else
                {
                    StateRes.status = false;
                    StateRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(StateRes, settings);

                }

            }
            catch (Exception ex)
            {

                StateRes.status = false;
                StateRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(StateRes, settings);

            }

            return Ok(json);
        }





        [HttpGet]
        [AllowAnonymous]
        [Route("Getstatedemo1")]
        public IActionResult Getstatedemo()
        {
            DataSet ds = new DataSet();
            string json = "";

            StateResponse StateRes = new StateResponse();
            List<StateDetail> objstate = new List<StateDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("BindState", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    StateRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        StateDetail objlist = new StateDetail();
                        objlist.statename = Convert.ToString(row["state_name"]);
                        objlist.stateid = Convert.ToInt32(row["state_id"]);

                        objstate.Add(objlist);
                    }

                    StateRes.data = objstate;
                    StateRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(StateRes, settings);
                }
                else
                {
                    StateRes.status = false;
                    StateRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(StateRes, settings);

                }

            }
            catch (Exception ex)
            {

                StateRes.status = false;
                StateRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(StateRes, settings);

            }

            return Ok(json);
        }





        //[HttpPost]
        //[Route("Getstate")]
        //public IActionResult BindState()
        //{
        //    DataSet ds = new DataSet();
        //    string json = "";

        //    StateResponse StateRes = new StateResponse();
        //    List<StateDetail> objstate = new List<StateDetail>();
        //    try
        //    {
        //        MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


        //        MySqlCommand cmd = new MySqlCommand("BindState", con);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        con.Open();
        //        MySqlDataAdapter da = new MySqlDataAdapter();
        //        da.SelectCommand = cmd;
        //        da.Fill(ds);
        //        con.Close();


        //        if (ds.Tables.Count > 0)
        //        {

        //            StateRes.status = true;
        //            foreach (DataRow row in ds.Tables[0].Rows)
        //            {
        //                StateDetail objlist = new StateDetail();
        //                objlist.statename = Convert.ToString(row["state_name"]);
        //                objlist.stateid = Convert.ToInt32(row["state_id"]);

        //                objstate.Add(objlist);
        //            }

        //            StateRes.data = objstate;
        //            StateRes.message = "Success";
        //            JsonSerializerSettings settings = new JsonSerializerSettings();
        //            settings.NullValueHandling = NullValueHandling.Ignore;
        //            json = JsonConvert.SerializeObject(StateRes, settings);
        //        }
        //        else
        //        {
        //            StateRes.status = false;
        //            StateRes.message = "Something went wrong";

        //            JsonSerializerSettings settings = new JsonSerializerSettings();
        //            settings.NullValueHandling = NullValueHandling.Ignore;
        //            json = JsonConvert.SerializeObject(StateRes, settings);

        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        StateRes.status = false;
        //        StateRes.message = ex.Message;
        //        JsonSerializerSettings settings = new JsonSerializerSettings();
        //        settings.NullValueHandling = NullValueHandling.Ignore;
        //        json = JsonConvert.SerializeObject(StateRes, settings);

        //    }

        //    return Ok(json);
        //}












        //Api for bind city according to state

        [HttpGet]
        [AllowAnonymous]
        [Route("Getcity")]
        //public IActionResult BindCity([FromBody] )
        public IActionResult BindCity([FromHeader] getcity data)
        {
            DataSet ds = new DataSet();
            string json = "";
           // data.stateid = 21;
            CityResponse CityRes = new CityResponse();
            List<CityDetail> objcity = new List<CityDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("BindCity", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("stateid", data.stateid);

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    CityRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        CityDetail ObjCityList = new CityDetail();
                        ObjCityList.cityname = Convert.ToString(row["city_name"]);
                        ObjCityList.cityid = Convert.ToInt32(row["city_id"]);

                        objcity.Add(ObjCityList);
                    }

                    CityRes.data = objcity;
                    CityRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CityRes, settings);
                }
                else
                {
                    CityRes.status = false;
                    CityRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CityRes, settings);

                }

            }
            catch (Exception ex)
            {

                CityRes.status = false;
                CityRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(CityRes, settings);

            }

            return Ok(json);
        }

        //Api for bind school according to city

        [HttpGet]
        [AllowAnonymous]
        [Route("Getschool")]
        public IActionResult BindSchool([FromHeader] getschool data)

        {
            DataSet ds = new DataSet();
            string json = "";
            //data.stateid = 31;
            //data.cityid = 25;
            SchoolResponse SchoolRes = new SchoolResponse();
            List<SchoolDetail> objschool = new List<SchoolDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("BindSchool", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("stateid", data.stateid);
                cmd.Parameters.AddWithValue("cityid", data.cityid);

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    SchoolRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        SchoolDetail ObjSchoolList = new SchoolDetail();
                        ObjSchoolList.schoolname = Convert.ToString(row["school_name"]);
                        ObjSchoolList.schoolid = Convert.ToInt32(row["school_id"]);

                        objschool.Add(ObjSchoolList);
                    }

                    SchoolRes.data = objschool;
                    SchoolRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(SchoolRes, settings);
                }
                else
                {
                    SchoolRes.status = false;
                    SchoolRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(SchoolRes, settings);

                }

            }
            catch (Exception ex)
            {

                SchoolRes.status = false;
                SchoolRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(SchoolRes, settings);

            }

            return Ok(json);
        }


        //Api for bind class 
        [HttpGet]
        [AllowAnonymous]
        [Route("Getclass")]
        public IActionResult BindClass()
        {
            DataSet ds = new DataSet();
            string json = "";

            ClassResponse ClassRes = new ClassResponse();
            List<ClassDetail> objclass = new List<ClassDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("BindClassApi", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    ClassRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ClassDetail objlist = new ClassDetail();
                        objlist.classname = Convert.ToString(row["class_name"]);
                        objlist.classid = Convert.ToInt32(row["class_id"]);

                        objclass.Add(objlist);
                    }

                    ClassRes.data = objclass;
                    ClassRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ClassRes, settings);
                }
                else
                {
                    ClassRes.status = false;
                    ClassRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ClassRes, settings);

                }

            }
            catch (Exception ex)
            {

                ClassRes.status = false;
                ClassRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(ClassRes, settings);

            }

            return Ok(json);
        }

        //Api for bind stream
        [HttpGet]
        [AllowAnonymous]
        [Route("Getstream")]
        public IActionResult BindStream()
        {
            DataSet ds = new DataSet();
            string json = "";

            StreamResponse StreamRes = new StreamResponse();
            List<StreamDetail> objstream = new List<StreamDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("bindstream", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    StreamRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        StreamDetail objlist = new StreamDetail();
                        objlist.streamname = Convert.ToString(row["Stream_name"]);
                        objlist.streamid = Convert.ToInt32(row["Stream_id"]);

                        objstream.Add(objlist);
                    }

                    StreamRes.data = objstream;
                    StreamRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(StreamRes, settings);
                }
                else
                {
                    StreamRes.status = false;
                    StreamRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(StreamRes, settings);

                }

            }
            catch (Exception ex)
            {

                StreamRes.status = false;
                StreamRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(StreamRes, settings);

            }

            return Ok(json);
        }


        //API for login type
        [HttpGet]
        [AllowAnonymous]
        [Route("GetLoginType")]
        public IActionResult GetLoginType()
        {
            DataSet ds = new DataSet();
            string json = "";

            LoginTypeResponse TypeRes = new LoginTypeResponse();
            List<LoginTypeDetailsDetail> objtype = new List<LoginTypeDetailsDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("bindlogintype", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    TypeRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        LoginTypeDetailsDetail objlist = new LoginTypeDetailsDetail();
                        objlist.logintypename = Convert.ToString(row["typename"]);
                        objlist.logintypeid = Convert.ToInt32(row["typeid"]);

                        objtype.Add(objlist);
                    }

                    TypeRes.data1 = objtype;
                    TypeRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(TypeRes, settings);
                }
                else
                {
                    TypeRes.status = false;
                    TypeRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(TypeRes, settings);

                }

            }
            catch (Exception ex)
            {

                TypeRes.status = false;
                TypeRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(TypeRes, settings);

            }

            return Ok(json);
        }


        //API for get language type
        [HttpGet]
        [AllowAnonymous]
        [Route("Getlanguage")]
        public IActionResult Getlanguage()
        {
            DataSet ds = new DataSet();
            string json = "";

            LanguageResponse StreamRes = new LanguageResponse();
            List<LanguageDetail> objstream = new List<LanguageDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("BindLanguage", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {
                    StreamRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        LanguageDetail objlist = new LanguageDetail();
                        objlist.languagename = Convert.ToString(row["languagetype"]);
                        objlist.languageid = Convert.ToInt32(row["languageid"]);
                        objstream.Add(objlist);
                    }

                    StreamRes.data = objstream;
                    StreamRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(StreamRes, settings);
                }
                else
                {
                    StreamRes.status = false;
                    StreamRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(StreamRes, settings);

                }

            }
            catch (Exception ex)
            {

                StreamRes.status = false;
                StreamRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(StreamRes, settings);

            }

            return Ok(json);
        }



        //Api for registration

        [AllowAnonymous]
        [HttpPost]
        [Route("StudentRegistration")]
        [Obsolete]
        public IActionResult StudentRegistration([FromBody] StudentRegistration data)
        {

            StudentRegistrationResponse stures = new StudentRegistrationResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";
            string username = "";
            string pwd = "";
            string mobiles = "";
            string parentemail = "";
            string parentpwd = "";


            if (data.stu_name == "" || data.stu_email == "" || data.mobileno == "" || data.stu_schoolstate == 0 || data.stu_schoolcity == 0 || data.school_id == 0 || data.stu_class == 0 || data.language ==0)
            {
                stures.status = false;
                stures.data = new RegisteredData();
                stures.message = "Invalid Parameter";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(stures, settings);
            }
            //else
            //{
            //    username = data.stu_email;
            //    pwd = data.stu_email.Substring(0, 2) + Guid.NewGuid().ToString().Substring(0, 4);
            //    mobiles = data.mobileno;

            //    parentemail = data.p_username;
            //    parentpwd = data.p_username.Substring(0, 2) + Guid.NewGuid().ToString().Substring(0, 4);

            //}

            //if (data.p_username == "")
            //{
            //    stures.status = false;
            //    stures.data = new RegisteredData();
            //    stures.message = "Invalid Parents Username";


                //    settings.NullValueHandling = NullValueHandling.Ignore;
                //    json = JsonConvert.SerializeObject(stures, settings);
                //}
                //else
                //{
                //    parentemail = data.p_username;
                //    parentpwd = data.p_username.Substring(0, 2) + Guid.NewGuid().ToString().Substring(0, 4);

                //}




                //if (data.stu_schoolstate == 0 || data.stu_schoolcity == 0 || data.school_id == 0)
                //{
                //    stures.status = false;
                //    stures.data = new RegisteredData();
                //    stures.message = "Invalid StateID Or CityID Or SchoolID";


                //    settings.NullValueHandling = NullValueHandling.Ignore;
                //    json = JsonConvert.SerializeObject(stures, settings);
                //}
                //if (data.stu_stream == 0 || data.stu_class == 0)
                //{
                //    stures.status = false;
                //    stures.data = new RegisteredData();
                //    stures.message = "Invalid StreamID Or ClassID";


                //    settings.NullValueHandling = NullValueHandling.Ignore;
                //    json = JsonConvert.SerializeObject(stures, settings);
                //}


            else
            {

                

                username = data.stu_email;
                pwd = data.stu_email.Substring(0, 2) + Guid.NewGuid().ToString().Substring(0, 4);
                mobiles = data.mobileno;

                //parentemail = data.p_username;
                //parentpwd = data.p_username.Substring(0, 2) + Guid.NewGuid().ToString().Substring(0, 4);
                parentemail = "";
                parentpwd = "";

                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("StudentRegistration_New", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("studentid", data.stu_portalid);

                    cmd.Parameters.AddWithValue("studentname", data.stu_name);

                    cmd.Parameters.AddWithValue("username", data.stu_email);
                    cmd.Parameters.AddWithValue("email", data.stu_email);
                    cmd.Parameters.AddWithValue("pwd", pwd);
                    cmd.Parameters.AddWithValue("mobile", data.mobileno);
                    cmd.Parameters.AddWithValue("stateid", data.stu_schoolstate);
                    cmd.Parameters.AddWithValue("cityid", data.stu_schoolcity);
                    cmd.Parameters.AddWithValue("schoolid", data.school_id);
                    cmd.Parameters.AddWithValue("classid", data.stu_class);
                    cmd.Parameters.AddWithValue("stream",  data.stu_stream);
                    cmd.Parameters.AddWithValue("parent_email", parentemail);
                    cmd.Parameters.AddWithValue("parent_pwd", parentpwd);
                    cmd.Parameters.AddWithValue("languageid_d", data.language);

                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();
                    if (result == "Success")
                    {

                        if (data.school_id == 12786)
                        {
                            Execqry("insert into tbl_schoolmaster(school_state,school_city,school_name,bystudent)values(" + data.stu_schoolstate + "," + data.stu_schoolcity + ",'" + data.schoolname + "',"+ 1 +")");

                        }


                        stures.status = true;
                        stures.data = new RegisteredData();

                        DataSet ds1 = new DataSet();
                        try
                        {
                            MySqlCommand cmd1 = new MySqlCommand("GetEmailSms_career", con);
                            cmd1.CommandType = CommandType.StoredProcedure;

                            con.Open();
                            MySqlDataAdapter da1 = new MySqlDataAdapter();
                            da1.SelectCommand = cmd1;
                            da1.Fill(ds1);
                            con.Close();
                            string _Message = ds1.Tables[0].Rows[0]["careerstudentregister"].ToString();
                            string _Message1 = ds1.Tables[0].Rows[0]["email"].ToString();
                            string _sms = ds1.Tables[0].Rows[0]["sms"].ToString();
                            if (data.stu_email != "")
                            {
                                MySqlCommand cmd2 = new MySqlCommand("UpdateEmailStatus", con);
                                cmd1.CommandType = CommandType.StoredProcedure;
                                cmd1.Parameters.AddWithValue("email", data.stu_email);

                                con.Open();
                                MySqlDataAdapter da2 = new MySqlDataAdapter();
                                da2.SelectCommand = cmd2;

                                con.Close();
                                _Message = _Message.Replace("@candidatename", data.stu_name);
                                _Message = _Message.Replace("@username", data.stu_email);
                                _Message = _Message.Replace("@password", pwd);


                                SendMail("CareerPrabhu Student Portal Login", data.stu_email, "", _Message);

                                //_Message1 = _Message1.Replace("@candidatename", data.stu_name);
                                //_Message1 = _Message1.Replace("@username", parentemail);
                                //_Message1 = _Message1.Replace("@password", parentpwd);


                                //SendMail("CareerPrabhu Student Portal Login", parentemail, "", _Message1);
                                _sms = _sms.Replace("@username", data.stu_email);
                                _sms = _sms.Replace("@pwd", pwd);


                                if (data.mobileno.Length >= 1)
                                {
                                    if (data.mobileno != "")
                                    {
                                        mobiles += "," + data.mobileno + "";
                                    }
                                    if (data.mobileno != "")
                                    {
                                        mobiles += "," + data.mobileno + "";
                                    }
                                    SendSMS(data.mobileno, _sms);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            string mmm = e.Message;
                        }


                        stures.message = "Your account credentials has been sent on your registered email and mobile number";
                        //stures.message = "Student Registered Successfully:ID-" + username + ",Pwd:" + pwd + "";
                        //stures.message = "Student Registered Successfully:ID-" + username + ",Pwd:" + pwd + "";
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }
                    else if (result == "Mobile Number Already Exists.")
                    {
                        stures.status = false;
                        stures.data = new RegisteredData();
                        stures.message = "Mobile Number Already Exists.";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }
                    else if (result == "Email Id Already Exists.")
                    {
                        stures.status = false;
                        stures.data = new RegisteredData();
                        stures.message = "Email Id Already Exists.";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }
                    else
                    {
                        stures.status = false;
                        stures.data = new RegisteredData();
                        stures.message = json;


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }



                }
                catch (Exception e)
                {
                    stures.status = false;
                    stures.data = new RegisteredData();
                    stures.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);

                }
            }

           


            return Ok(json);
        }

        //send email method
        //[Obsolete]
        //private void SendMail(string _Subject, string _CC, string _BCC, string _Messages)
        //{
        //    string from = "contact.wonderskool@gmail.com";
        //    MailMessage mail = new MailMessage();
        //    mail.To.Add(_CC);

        //    if (_CC != "")
        //    {
        //        mail.To.Add(_CC);

        //    }



        //    mail.CC.Add(new MailAddress("contact.wonderskool@gmail.com"));
        //    mail.From = new MailAddress(from, "Wonderskool", System.Text.Encoding.UTF8);
        //    mail.ReplyTo = new MailAddress(from, "WonderSkool");
        //    mail.Subject = _Subject;
        //    mail.SubjectEncoding = System.Text.Encoding.UTF8;
        //    mail.Body = _Messages;
        //    mail.BodyEncoding = System.Text.Encoding.UTF8;
        //    mail.IsBodyHtml = true;
        //    mail.Priority = MailPriority.High;
        //    System.Net.NetworkCredential aCred = new System.Net.NetworkCredential("contact.wonderskool@gmail.com", "ws@edu@contact");
        //    SmtpClient client = new SmtpClient("ssl://smtp.gmail.com", 465);
        //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    client.EnableSsl = true;
        //    client.UseDefaultCredentials = false;
        //    client.Credentials = aCred;
        //    try
        //    {
        //        client.Send(mail);
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = ex.Message;
        //        // Response.Write(ex.Message);
        //        //  return;
        //    }
        //}

        [Obsolete]
        private void SendMail2(string _Subject, string _CC, string _BCC, string _Messages, string _pwd)
        {
            DataSet ds = new DataSet();
            string from = "contact.wonderskool@gmail.com";
            //string from = "sumantabag19@gmail.com";
            string Error = "";
            MailMessage mail = new MailMessage();
            mail.To.Add("contact.wonderskool@gmail.com");
            mail.From = new MailAddress(from, "Student Payment", System.Text.Encoding.UTF8);
            mail.Subject = _Subject;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = _Messages;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            //client.Host = "124.247.226.44";
            //124.247.226.44,6434
            client.Host = "smtp.gmail.com";
            //client.Port = 25;
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential("contact.wonderskool@gmail.com", "ws@edu@contact");
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Port = 587; // Gmail works on this port
                               //client.Port = 9025;
                               //  client.EnableSsl = true; //Gmail works on Server Secured Layer
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }

        }







        [Obsolete]
        private void SendMail(string _Subject, string _CC, string _BCC, string _Messages)
        {
            DataSet ds = new DataSet();
            string from = "contact.wonderskool@gmail.com";
            //string from = "sumantabag19@gmail.com";
            string Error = "";
            MailMessage mail = new MailMessage();
            mail.To.Add(_CC);
            mail.From = new MailAddress(from, "Wonderskool", System.Text.Encoding.UTF8);
            mail.Subject = _Subject;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = _Messages;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            //client.Host = "124.247.226.44";
            //124.247.226.44,6434
            client.Host = "smtp.gmail.com";
            //client.Port = 25;
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("contact.wonderskool@gmail.com", "ws@edu@contact");
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Port = 587; // Gmail works on this port
                               //client.Port = 9025;
          //  client.EnableSsl = true; //Gmail works on Server Secured Layer
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
         
        }




        //api for send sms
        private void SendSMS(string mobileno, string msg)
        {
            try
            {
                string url = "";
                DataSet dsurl = new DataSet();
                emailsending email = new emailsending();
                msg = msg.Replace("&", "%26");
                msg = msg.Replace("+", "%2B");
                msg = msg.Replace("%", "%25");
                msg = msg.Replace("#", "%23");
                msg = msg.Replace("=", "%3D");
                msg = msg.Replace("^", "%5E");
                msg = msg.Replace("~", "%7E");
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                MySqlCommand cmd2 = new MySqlCommand("GetUrlSms", con);
                cmd2.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataAdapter da2 = new MySqlDataAdapter();
                da2.SelectCommand = cmd2;
                da2.Fill(dsurl);
                con.Close();
                if (dsurl.Tables.Count > 0)
                {
                    url = dsurl.Tables[0].Rows[0]["smsapiurl"].ToString();
                }
                else
                {
                    url = "";
                }


                // string url = clscon.Return_string("select smsapiurl from tbemailsms where formatid=1");
                url = url.Replace("@msg", msg);
                url = url.Replace("@mobile", mobileno);
                email.readHtmlPage(url);
            }
            catch { }
        }






        //Api start for prepratory material

        //Api for prepratory category bind
        [HttpGet]
        [Route("GetPrepratoryCategory")]
        public IActionResult GetPrepratoryCategory([FromHeader] GetPrepratoryCategory obj)

        {
            DataSet ds = new DataSet();
            string json = "";
            //obj.stu_id = 1265;


            PrepratoryCategoryResponse PrepRes = new PrepratoryCategoryResponse();
            List<PrepratoryCategoryDetail> objprep = new List<PrepratoryCategoryDetail>();

            if (obj.stu_id == 0)
            {
                PrepRes.status = false;
                PrepRes.message = "Invalid StudentID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(PrepRes, settings);
            }
            else
            {

                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("VIP_TEST", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("stu_id", obj.stu_id);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        PrepRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            PrepratoryCategoryDetail ObjPrepList = new PrepratoryCategoryDetail();
                            ObjPrepList.categoryname = Convert.ToString(row["categoryname"]);
                            ObjPrepList.prepid = Convert.ToInt32(row["prepid"]);


                            if(Convert.ToString(row["filename"]) == "olympiad")
                            {
                                ObjPrepList.logo1 = "http://admin.careerprabhu.com/" + "Logo/" + "olympiad_1.png";
                                ObjPrepList.logo2 = "http://admin.careerprabhu.com/" + "Logo/" + "olympiad-white_2.png";
                            }

                            if (Convert.ToString(row["filename"]) == "scholarship")
                            {
                                ObjPrepList.logo1 = "http://admin.careerprabhu.com/" + "Logo/" + "scholarship_1.png";
                                ObjPrepList.logo2 = "http://admin.careerprabhu.com/" + "Logo/" + "scholarship-white_2.png";
                            }

                            if (Convert.ToString(row["filename"]) == "Entrance")
                            {
                                ObjPrepList.logo1 = "http://admin.careerprabhu.com/" + "Logo/" + "Entrance.png";
                                ObjPrepList.logo2 = "http://admin.careerprabhu.com/" + "Logo/" + "Entrance-white.png";
                            }
                            //if (Convert.ToString(row["filename"]) == "competiotion")
                            //{
                            //    ObjPrepList.logo1 = "http://admin.careerprabhu.com/" + "Logo/" + "competiotion_1.png";
                            //    ObjPrepList.logo2 = "http://admin.careerprabhu.com/" + "Logo/" + "competiotion-white_2.png";
                            //}



                            objprep.Add(ObjPrepList);

                        }

                        PrepRes.data = objprep;
                        PrepRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(PrepRes, settings);
                    }
                    else
                    {
                        PrepRes.status = false;
                        PrepRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(PrepRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    PrepRes.status = false;
                    PrepRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(PrepRes, settings);

                }

            }





            return Ok(json);
        }

        //API for prepratory title after click of category
        [HttpGet]
        [Route("GetPrepTitle")]
        public IActionResult GetPrepTitle([FromHeader] GetPrepratoryTitle obj)

        {
            DataSet ds = new DataSet();
            string json = "";
            //obj.prepid = 1;
            string career = "";
            PrepratoryTitleResponse PrepTitleRes = new PrepratoryTitleResponse();
            List<PrepratoryTitleDetail> objpreptitle = new List<PrepratoryTitleDetail>();
            if (obj.prepid == 0 || obj.classid == 0)
            {
                PrepTitleRes.status = false;
                PrepTitleRes.message = "Invalid PrepratoryID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(PrepTitleRes, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("BindPrepTitleAPI_New_update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("prep_id", obj.prepid);
                    cmd.Parameters.AddWithValue("classid_d", obj.classid);
                    cmd.Parameters.AddWithValue("streamid_d", obj.streamid);
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        PrepTitleRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            PrepratoryTitleDetail ObjPrepTitleList = new PrepratoryTitleDetail();
                            ObjPrepTitleList.prepname = Convert.ToString(row["prepname"]);
                            ObjPrepTitleList.prepnameid = Convert.ToInt32(row["prepnameid"]);
                            ObjPrepTitleList.description = Convert.ToString(row["description"]);
                            career = Convert.ToString(row["career_id"]);


                            objpreptitle.Add(ObjPrepTitleList);
                        }

                        PrepTitleRes.data = objpreptitle;
                        PrepTitleRes.message = "Success";
                        if (career != "")
                        {
                            PrepTitleRes.iscareer = true;
                        }
                        else
                        {
                            PrepTitleRes.iscareer = false;
                        }
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(PrepTitleRes, settings);
                    }
                    else
                    {
                        PrepTitleRes.status = false;
                        PrepTitleRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(PrepTitleRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    PrepTitleRes.status = false;
                    PrepTitleRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(PrepTitleRes, settings);

                }
            }



            return Ok(json);
        }

        //API for bind career
        [HttpGet]
        [Route("Getcareer")]
        public IActionResult BindCareer()
        {
            DataSet ds = new DataSet();
            string json = "";

            CareerResponse CareerRes = new CareerResponse();
            List<CareerDetail> objcareer = new List<CareerDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("bindcareer", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    CareerRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        CareerDetail objlist = new CareerDetail();
                        objlist.careername = Convert.ToString(row["careername"]);
                        objlist.careerid = Convert.ToInt32(row["careerid"]);

                        objcareer.Add(objlist);
                    }

                    CareerRes.data = objcareer;
                    CareerRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CareerRes, settings);
                }
                else
                {
                    CareerRes.status = false;
                    CareerRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CareerRes, settings);

                }

            }
            catch (Exception ex)
            {

                CareerRes.status = false;
                CareerRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(CareerRes, settings);

            }

            return Ok(json);
        }

        //Api for filter prepratory title  wrt career
        [HttpGet]
        [Route("FilterPrepratoryTitle")]
        public IActionResult FilterPrepratoryTitle([FromHeader] GetFilterPrepratory data)

        {
            DataSet ds = new DataSet();
            string json = "";
            //data.prepid = 1;
            //data.careerid = "19";
            FilterPrepTitleResponse FilterPrepRes = new FilterPrepTitleResponse();
            List<FilterPrepTitleDetail> objfilterprep = new List<FilterPrepTitleDetail>();
            if (data.prepid == 0)
            {
                FilterPrepRes.status = false;
                FilterPrepRes.message = "Invalid PrepratoryID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(FilterPrepRes, settings);

            }
            else if (data.careerid == 0)
            {
                FilterPrepRes.status = false;
                FilterPrepRes.message = "Invalid CareerID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(FilterPrepRes, settings);

            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("Career_Filter", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("prep_id", data.prepid);
                    cmd.Parameters.AddWithValue("p_career", data.careerid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        FilterPrepRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            FilterPrepTitleDetail ObjPrepList = new FilterPrepTitleDetail();
                            ObjPrepList.prepname = Convert.ToString(row["prepname"]);
                            ObjPrepList.prepnameid = Convert.ToInt32(row["prepnameid"]);

                            objfilterprep.Add(ObjPrepList);
                        }

                        FilterPrepRes.data = objfilterprep;
                        FilterPrepRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FilterPrepRes, settings);
                    }
                    else
                    {
                        FilterPrepRes.status = false;
                        FilterPrepRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FilterPrepRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    FilterPrepRes.status = false;
                    FilterPrepRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(FilterPrepRes, settings);

                }
            }





            return Ok(json);
        }


        //API for bind name of previous year paper
        [HttpGet]
        [Route("GetPrevYearPaper")]
        public IActionResult GetPrevYearPaper([FromHeader] BindPapernamePrepratory data)
        {
            DataSet ds = new DataSet();
            string json = "";

            PrevYearNameResponse PrevNameRes = new PrevYearNameResponse();
            List<PrevYearNameDetail> objprevyear = new List<PrevYearNameDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                //MySqlCommand cmd = new MySqlCommand("bindprevyearname", con);
                MySqlCommand cmd = new MySqlCommand("bindTestname_update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("d_type", data.materialtype);
                cmd.Parameters.AddWithValue("prepid_d", data.prepid);
                cmd.Parameters.AddWithValue("prepnameid_d", data.prepnameid);
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    PrevNameRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        PrevYearNameDetail objlist = new PrevYearNameDetail();
                        objlist.testname = Convert.ToString(row["papername"]);
                        objlist.testnameid = Convert.ToInt32(row["id"]);

                        objprevyear.Add(objlist);
                    }

                    PrevNameRes.data = objprevyear;
                    PrevNameRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(PrevNameRes, settings);
                }
                else
                {
                    PrevNameRes.status = false;
                    PrevNameRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(PrevNameRes, settings);

                }

            }
            catch (Exception ex)
            {

                PrevNameRes.status = false;
                PrevNameRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(PrevNameRes, settings);

            }

            return Ok(json);
        }
        
        //Api for get material detail
        [HttpGet]
        [Route("ShowMaterial")]
        public IActionResult ShowMaterial([FromHeader] DownloadPrepratory data)

        {
            DataSet ds = new DataSet();
            string json = "";
            //data.prepid = 1;
            //data.prepnameid = 2;
            //data.materialtype = 2;
            UploadMaterialResponse DownloadRes = new UploadMaterialResponse();
            List<UploadMaterialDetail> objdownload = new List<UploadMaterialDetail>();

            if (data.prepid == 0)
            {
                DownloadRes.status = false;
                DownloadRes.message = "Invalid PrepratoryID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(DownloadRes, settings);
            }
            else if (data.prepnameid == 0)
            {
                DownloadRes.status = false;
                DownloadRes.message = "Invalid Prepratory TitleID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(DownloadRes, settings);
            }
            else if (data.materialtype == 0)
            {
                DownloadRes.status = false;
                DownloadRes.message = "Invalid Material Type";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(DownloadRes, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("DownoadMaterial", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("prep_id", data.prepid);
                    cmd.Parameters.AddWithValue("prepname_id", data.prepnameid);
                    cmd.Parameters.AddWithValue("d_type", data.materialtype);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        DownloadRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            UploadMaterialDetail ObjDownloadList = new UploadMaterialDetail();
                            ObjDownloadList.pdfpath = Convert.ToString(row["pdfpath"]);
                            ObjDownloadList.imagepath = Convert.ToString(row["imagepath"]);
                            ObjDownloadList.url = Convert.ToString(row["url"]);

                            objdownload.Add(ObjDownloadList);
                        }

                        DownloadRes.data = objdownload;
                        DownloadRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(DownloadRes, settings);
                    }
                    else
                    {
                        DownloadRes.status = false;
                        DownloadRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(DownloadRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    DownloadRes.status = false;
                    DownloadRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(DownloadRes, settings);

                }
            }




            return Ok(json);
        }

        //Api for download material

        [HttpGet]
        [Route("DownloadMaterial")]
        public IActionResult DownloadMaterial([FromHeader] DownloadPrepratory data)

        {
            DataSet ds = new DataSet();
            string json = "";
            //data.prepid = 1;
            //data.prepnameid = 2;
            //data.materialtype = 2;
            DowloadMaterialResponse DownloadRes = new DowloadMaterialResponse();
            List<DownloadMaterialDetail> objdownload = new List<DownloadMaterialDetail>();

            List<DownloadMaterialUrlDetail> objdownloadurl = new List<DownloadMaterialUrlDetail>();

            if (data.prepid == 0 || data.prepnameid == 0)
            {
                DownloadRes.status = false;
                DownloadRes.message = "Invalid PrepratoryID Or Prepratoryname ID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(DownloadRes, settings);
            }
            else if (data.prepnameid == 0)
            {
                DownloadRes.status = false;
                DownloadRes.message = "Invalid Prepratory TitleID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(DownloadRes, settings);
            }
            else if (data.materialtype == 0)
            {
                DownloadRes.status = false;
                DownloadRes.message = "Invalid Material Type";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(DownloadRes, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("DownoadMaterial", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("prep_id", data.prepid);
                    cmd.Parameters.AddWithValue("prepname_id", data.prepnameid);
                    cmd.Parameters.AddWithValue("d_type", data.materialtype);
                    cmd.Parameters.AddWithValue("d_name", data.papername);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        DownloadRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {

                            DownloadMaterialDetail ObjDownloadList = new DownloadMaterialDetail();
                            DownloadMaterialUrlDetail objurllist = new DownloadMaterialUrlDetail();

                            if (data.materialtype == 1)
                            {

                                if (Convert.ToString(row["pdfpath"]) == "" || Convert.ToString(row["pdfpath"]) == null)
                                {
                                    //ObjDownloadList.pdfpath = "";
                                }
                                else
                                {
                                    ObjDownloadList.pdfpath = "http://admin.careerprabhu.com/" + "previousyearpdf/" + Convert.ToString(row["pdfpath"]);

                                }

                                if (Convert.ToString(row["imagepath"]) == "" || Convert.ToString(row["imagepath"]) == null)
                                {
                                    //ObjDownloadList.imagepath = "";
                                }
                                else
                                {
                                    ObjDownloadList.imagepath = "http://admin.careerprabhu.com/" + "prviousyearimage/" + Convert.ToString(row["imagepath"]);

                                }






                                //ObjDownloadList.url = Convert.ToString(row["url"]);
                                objurllist.url = Convert.ToString(row["url"]);
                                objurllist.name = Convert.ToString(row["ptext"]);


                                if(Convert.ToString(row["pdfpath"]) == "" || Convert.ToString(row["pdfpath"]) == null)
                                {

                                }
                                else
                                {
                                    objdownload.Add(ObjDownloadList);

                                }
                            }
                            if (data.materialtype == 2)
                            {

                                if (Convert.ToString(row["pdfpath"]) == "" || Convert.ToString(row["pdfpath"]) == null)
                                {
                                    ObjDownloadList.pdfpath = "";
                                }
                                else
                                {
                                    ObjDownloadList.pdfpath = "http://admin.careerprabhu.com/" + "samplepdf/" + Convert.ToString(row["pdfpath"]);

                                }

                                if (Convert.ToString(row["imagepath"]) == "" || Convert.ToString(row["imagepath"]) == null)
                                {
                                    ObjDownloadList.imagepath = "";
                                }
                                else
                                {
                                    ObjDownloadList.imagepath = "http://admin.careerprabhu.com/" + "sampleimage/" + Convert.ToString(row["imagepath"]);

                                }




                                //ObjDownloadList.url = Convert.ToString(row["url"]);
                                objurllist.url = Convert.ToString(row["url"]);
                                objurllist.name = Convert.ToString(row["stext"]);

                                if(Convert.ToString(row["pdfpath"]) == "" || Convert.ToString(row["pdfpath"]) == null)
                                {

                                }
                                else
                                {
                                    objdownload.Add(ObjDownloadList);
                                }
                            }
                            if (data.materialtype == 3)
                            {

                                //ObjDownloadList.pdfpath = Convert.ToString(row["pdfpath"]);
                                //ObjDownloadList.imagepath = Convert.ToString(row["imagepath"]);


                                //ObjDownloadList.url = Convert.ToString(row["url"]);
                              
                                objurllist.url = Convert.ToString(row["url"]);
                                objurllist.name = Convert.ToString(row["mtext"]);
                            }
                            if (data.materialtype == 4)
                            {

                                if(Convert.ToString(row["pdfpath"]) == "" || Convert.ToString(row["pdfpath"]) == null)
                                {
                                    ObjDownloadList.pdfpath = "";
                                }
                                else
                                {
                                    ObjDownloadList.pdfpath = "http://admin.careerprabhu.com/" + "samplepdf/" + Convert.ToString(row["pdfpath"]);

                                }

                                if (Convert.ToString(row["imagepath"]) == "" || Convert.ToString(row["imagepath"]) == null)
                                {
                                    ObjDownloadList.imagepath = "";
                                }
                                else
                                {
                                    ObjDownloadList.imagepath = "http://admin.careerprabhu.com/" + "sampleimage/" + Convert.ToString(row["imagepath"]);

                                }



                                objurllist.url = Convert.ToString(row["url"]);
                                objurllist.name = Convert.ToString(row["atext"]);

                                if(Convert.ToString(row["pdfpath"]) == "" || Convert.ToString(row["pdfpath"]) == null)
                                {

                                }
                                else
                                {
                                    objdownload.Add(ObjDownloadList);
                                }
                            }
                            if (data.materialtype == 5)
                            {
                                objurllist.url = Convert.ToString(row["url"]);
                                objurllist.name = Convert.ToString(row["rtext"]);
                            }
                            if (data.materialtype == 6)
                            {
                                objurllist.url = Convert.ToString(row["url"]);
                                objurllist.name = Convert.ToString(row["ftext"]);
                            }
                            if (data.materialtype == 7)
                            {
                                objurllist.url = Convert.ToString(row["url"]);
                                objurllist.name = Convert.ToString(row["paidtext"]);
                            }



                            //objdownload.Add(ObjDownloadList);
                            objdownloadurl.Add(objurllist);
                        }
                        if(data.materialtype == 1 || data.materialtype == 2 || data.materialtype == 4)
                        {
                            DownloadRes.data = objdownload;
                            DownloadRes.data1 = objdownloadurl;
                            DownloadRes.message = "Success";
                            JsonSerializerSettings settings = new JsonSerializerSettings();
                            settings.NullValueHandling = NullValueHandling.Ignore;
                            json = JsonConvert.SerializeObject(DownloadRes, settings);
                        }
                        else
                        {
                            //DownloadRes.data = objdownload;
                           DownloadRes.data1 = objdownloadurl;
                            DownloadRes.message = "Success";
                            JsonSerializerSettings settings = new JsonSerializerSettings();
                            settings.NullValueHandling = NullValueHandling.Ignore;
                            json = JsonConvert.SerializeObject(DownloadRes, settings);
                        }
                      
                    }
                    else
                    {
                        DownloadRes.status = false;
                        DownloadRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(DownloadRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    DownloadRes.status = false;
                    DownloadRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(DownloadRes, settings);

                }
            }

            return Ok(json);
        }



        













        //Api for login

        [AllowAnonymous]
        [HttpPost]
        [Route("LoginManager")]
        public IActionResult LoginManager([FromBody] GetLoginData data)
        {
            string json = "";
            string username = "";
            string pwd = "";
            string token = "";
            string logintokenkey = "";
            string result = "";
            JsonSerializerSettings settings = new JsonSerializerSettings();
            LoginDetail login = new LoginDetail();
           LoginResponse res = new LoginResponse();
            DataSet ds = new DataSet();


            if(data.Login_type == 1)
            {
                if (data.UserName == "" || data.P_Password == "" || data.UserName == null || data.P_Password == null)
                {
                    res.Status = false;
                    res.Message = "Invalid Student UserName Or Password";
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(res, settings);
                }
                else
                {
                    username = data.UserName;
                    pwd = data.P_Password;
                    token = GetToken(Convert.ToString(data.UserName));
                    logintokenkey= Guid.NewGuid().ToString();
                }
            }
            else if(data.Login_type == 2)
            {
                if (data.UserName == "" || data.P_Password == "" || data.UserName == null || data.P_Password == null)
                {
                    res.Status = false;
                    res.Message = "Invalid Parents UserName Or Password";
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(res, settings);
                }
                else
                {
                    username = data.UserName;
                    pwd = data.P_Password;
                    token = GetToken(Convert.ToString(data.UserName));
                    logintokenkey = Guid.NewGuid().ToString();
                }
            }
            else if (data.Login_type == 3)
            {
                if (data.UserName == "" || data.P_Password == "" || data.UserName == null || data.P_Password == null)
                {
                    res.Status = false;
                    res.Message = "Invalid Principal UserName Or Password";
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(res, settings);
                }
                else
                {
                    username = data.UserName;
                    pwd = data.P_Password;
                    token = GetToken(Convert.ToString(data.UserName));
                    logintokenkey = Guid.NewGuid().ToString();
                }
            }
            if(data.Login_type == 0 && data.Login_type == 0 && data.Login_type == 0)
            {
                res.Status = false;
                res.Message = "Please Select User Type";
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(res, settings);
            }
            else
            {
                try
                {

                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("StudentLoginManager", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("LoginType_d", data.Login_type);
                    cmd.Parameters.AddWithValue("UserName_d", username);
                    cmd.Parameters.AddWithValue("Pwd_d", pwd);
                    cmd.Parameters.AddWithValue("token_d", token);
                    cmd.Parameters.AddWithValue("tokenloginkey_d", logintokenkey);
                    //cmd.Parameters.AddWithValue("studentportalid_d", data.Student_id);
                    cmd.Parameters.AddWithValue("deviceIMEI_d", data.IMEI);
                    cmd.Parameters.AddWithValue("devicetype_d", data.DeviceType);
                    cmd.Parameters.AddWithValue("OsVersion_d", data.OsVersion);
                    cmd.Parameters.AddWithValue("appversion_d", data.AppVersion_d);
                    cmd.Parameters.AddWithValue("Lang_d", data.Lang);
                    cmd.Parameters.AddWithValue("devicetoken_d", data.Device_token);
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;

                    da.Fill(ds);
                    con.Close();

                    if (ds.Tables.Count > 0)
                    {

                        res.Status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {

                            if(Convert.ToInt32(row["LoginType"].ToString()) == 1 || Convert.ToInt32(row["LoginType"].ToString()) == 2)
                            {
                                //LoginDetail ObjPrepList = new LoginDetail();
                                json = JsonConvert.SerializeObject(ds.Tables[0], Formatting.Indented);
                                //ObjPrepList.Token = GetToken(Convert.ToString(ds.Tables[0].Rows[0]["studentid"]));
                                login.studentid = Convert.ToInt32(row["studentid"]);// Same As DataBase column Name 

                                login.logintype = Convert.ToInt32(row["LoginType"]);

                            
                                login.p_user = row["username"].ToString();// Storing Data Base data into Local Variable
                                login.Token = row["Token"].ToString();
                                login.studentname = row["stu_name"].ToString();
                                login.mobileno = row["stu_mobile"].ToString();
                                login.loginkey = row["LoginKey"].ToString();
                                login.classid = Convert.ToInt32(row["class_id"]);
                                login.classname = row["class_name"].ToString();
                                login.usertype = Convert.ToInt32(row["user_type"].ToString());
                                login.ispaid = Convert.ToInt32(row["ispayment"].ToString());
                                login.streamid = Convert.ToInt32(row["stream_id"]);
                                login.streamname = Convert.ToString(row["streamname"]);
                                login.languageid = Convert.ToInt32(row["languageid"]);

                                // login.Add(ObjPrepList);

                            }
                            else
                            {
                        
                                json = JsonConvert.SerializeObject(ds.Tables[0], Formatting.Indented);
                          
                                login.principalid = Convert.ToInt32(row["principalid"]);// Same As DataBase column Name 

                                login.logintype = Convert.ToInt32(row["LoginType"]);


                                login.p_user = row["username"].ToString();// Storing Data Base data into Local Variable
                                login.Token = row["Token"].ToString();
                                login.loginkey = row["LoginKey"].ToString();
                              
                                login.usertype = Convert.ToInt32(row["user_type"].ToString());
                                login.stateid = Convert.ToInt32(row["stateid"]);
                                login.cityid = Convert.ToInt32(row["cityid"]);
                                login.schoolid = Convert.ToInt32(row["schoolid"]);
                                login.schoollogo = "https://www.wonderskool.com/uploads/" + "school_logo/" + Convert.ToString(row["school_logo"]);
                                login.schoolname = Convert.ToString(row["school_name"].ToString());
                                login.ispaid = Convert.ToInt32(row["ispayment"].ToString());
                                login.languageid = Convert.ToInt32(row["languageid"]);
                            }


                        }



                        //log mantain start

                        json = JsonConvert.SerializeObject(res);
                        json = json.Replace("[", "");
                        json = json.Replace("]", "");

                        //Getting IP Address of local System
                        string ip = GetLocalIP();

                        //Getting data From IP Address
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://ip-api.com/json/" + ip);
                        request.Method = "POST";
                        request.ContentType = "application/json";

                        WebResponse webResponse = request.GetResponse();
                        Stream webStream = webResponse.GetResponseStream();
                        StreamReader responseReader = new StreamReader(webStream);
                        string response = responseReader.ReadToEnd();
                        response = "{Table1: [" + response + "]}";
                        DataSet IPdetail = JsonConvert.DeserializeObject<DataSet>(response);
                        // Console.Out.WriteLine(response);
                        responseReader.Close();

                        //Saving App downloading logs
                        if (Convert.ToInt32(ds.Tables[0].Rows[0]["user_type"]) == 1 || Convert.ToInt32(ds.Tables[0].Rows[0]["user_type"]) == 2)
                        {
                            AppDownloadingLogs(
                                                       Convert.ToInt32(ds.Tables[0].Rows[0]["studentid"]),

                                                       token, ip, IPdetail.Tables[0].Rows[0]["country"].ToString(),
                                                       IPdetail.Tables[0].Rows[0]["regionName"].ToString(),
                                                       IPdetail.Tables[0].Rows[0]["city"].ToString(),
                                                       IPdetail.Tables[0].Rows[0]["as"].ToString(),
                                                       data.IMEI
                                                       );
                        }
                        else
                        {
                            AppDownloadingLogs_new(
                             Convert.ToInt32(ds.Tables[0].Rows[0]["principalid"]),

                             token, ip, IPdetail.Tables[0].Rows[0]["country"].ToString(),
                             IPdetail.Tables[0].Rows[0]["regionName"].ToString(),
                             IPdetail.Tables[0].Rows[0]["city"].ToString(),
                             IPdetail.Tables[0].Rows[0]["as"].ToString(),
                             data.IMEI
                             );
                        }
                           


                        //log mantain end
                        if (Convert.ToInt32(ds.Tables[0].Rows[0]["LoginType"]) == 1 || Convert.ToInt32(ds.Tables[0].Rows[0]["LoginType"]) == 2)
                        {
                            try
                            {
                                if (Convert.ToInt32(ds.Tables[1].Rows[0]["ispassout"]) == 1)
                                {
                                    login.ispassout = false;
                                }
                                else
                                {
                                    login.ispassout = true;
                                }
                            }
                            catch (Exception e)
                            {
                                login.ispassout = true;
                            }
                        }
                           



                        res.data = login;
                        res.Message = "Success";
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(res, settings);



                    }
                    else
                    {
                        res.Status = false;
                        res.Message = "Invalid Credentials";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(res, settings);
                    }

                }
                catch (Exception ex)
                {
                    res.Status = false;
                    res.Message = ex.Message;

                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(res, settings);

                }
            }

            



            return Ok(json);
        }





        public string GetYouTubeId(string url)
        {
            //var regex = @"(?:youtube\.com\/(?:[^\/]+\/.+\/|(?:v|e(?:mbed)?|watch)\/|.*[?&amp;]v=)|youtu\.be\/)([^""&amp;?\/ ]{11})";
            var regex = "(?:.+?)?(?:\\/v\\/|watch\\/|\\?v=|\\&v=|youtu\\.be\\/|\\/v=|^youtu\\.be\\/)([a-zA-Z0-9_-]{11})+";

            var match = Regex.Match(url, regex);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return url;
        }



        //get system ip address
        public string GetLocalIP()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://checkip.dyndns.org");
            request.Method = "POST";
            request.ContentType = "application/json";

            WebResponse webResponse = request.GetResponse();
            Stream webStream = webResponse.GetResponseStream();
            StreamReader responseReader = new StreamReader(webStream);
            string response = responseReader.ReadToEnd();
            string[] IP = response.Split(':');
            response = IP[1].Replace("</body></html>\r\n", "");
            response = response.TrimStart();
            return response;

        }
        //log mantain function
        public void AppDownloadingLogs(int studentid,string token, string ip_address, string country, string state, string city, string address, string deviceIMEI)
        {
            MantainLoginLog obj = new MantainLoginLog();
            DataSet ds = new DataSet();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                MySqlCommand cmd = new MySqlCommand("SaveStudentLog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("studentid_d", studentid);
                cmd.Parameters.AddWithValue("token_d", token);
                cmd.Parameters.AddWithValue("ip_d", ip_address);
                cmd.Parameters.AddWithValue("country_d", country);
                cmd.Parameters.AddWithValue("state_d", state);
                cmd.Parameters.AddWithValue("city_d", city);
                cmd.Parameters.AddWithValue("address_d", address);
                cmd.Parameters.AddWithValue("imei_d", deviceIMEI);
               
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();
            }
            catch (Exception ex)
            {

            }
        }

        //create token
        private string GetToken(string UserId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_iconfiguration.GetSection("ConnectionStrings").GetSection("KEY").Value.ToString());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, UserId.ToString())
                }),
                Expires = DateTime.Now.AddYears(Convert.ToInt32(_iconfiguration.GetSection("ConnectionStrings").GetSection("TimeOut").Value)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        //API for Portfolio start
        //API for bind trait
        [HttpGet]
        [Route("Gettrait")]
        public IActionResult BindTrait()
        {
            DataSet ds = new DataSet();
            string json = "";

            TraitResponse TraitRes = new TraitResponse();
            List<TraitDetail> objtrait = new List<TraitDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("BindTrait", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    TraitRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        TraitDetail objlist = new TraitDetail();
                        objlist.trait = Convert.ToString(row["trait"]);
                        objlist.traitid = Convert.ToInt32(row["traitid"]);

                        objtrait.Add(objlist);
                    }

                    TraitRes.data = objtrait;
                    TraitRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(TraitRes, settings);
                }
                else
                {
                    TraitRes.status = false;
                    TraitRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(TraitRes, settings);

                }

            }
            catch (Exception ex)
            {

                TraitRes.status = false;
                TraitRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(TraitRes, settings);

            }

            return Ok(json);
        }

        //API for show guideline for portfolio


        [HttpGet]
        [Route("GetGuideline")]
        public IActionResult BindGuideline([FromHeader] GetGuideline data)

        {
            DataSet ds = new DataSet();
            string json = "";

            GuidelineResponse GuideRes = new GuidelineResponse();
            List<GuidelineDetail> objguide = new List<GuidelineDetail>();
            if(data.Traitid == 0)
            {
                GuideRes.status = false;
                GuideRes.message = "Invalid TraitID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(GuideRes, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("ShowGuidelineData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("traitid_d", data.Traitid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        GuideRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            GuidelineDetail ObjGuideList = new GuidelineDetail();
                            ObjGuideList.countryname = Convert.ToString(row["countryname"]);
                            ObjGuideList.location = Convert.ToString(row["location"]);
                            ObjGuideList.universityname = Convert.ToString(row["universityname"]);
                            ObjGuideList.guideline = Convert.ToString(row["guideline"]);
                            ObjGuideList.link = Convert.ToString(row["link"]);
                            objguide.Add(ObjGuideList);
                        }

                        GuideRes.data = objguide;
                        GuideRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(GuideRes, settings);
                    }
                    else
                    {
                        GuideRes.status = false;
                        GuideRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(GuideRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    GuideRes.status = false;
                    GuideRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(GuideRes, settings);

                }
            }
            return Ok(json);
        }

        //Api for filter guideline
        [HttpGet]
        [Route("FilterGuideline")]
        public IActionResult FilterGuideline([FromHeader] GetFilterGuideline data)

        {
            DataSet ds = new DataSet();
            string json = "";

            FilterGuidelineResponse GuideRes = new FilterGuidelineResponse();
            List<FilterGuidelineDetail> objguide = new List<FilterGuidelineDetail>();
            if (data.Traitid == 0)
            {
                GuideRes.status = false;
                GuideRes.message = "Invalid TraitID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(GuideRes, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("FilterGuideline", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("traitid_d", data.Traitid);
                    cmd.Parameters.AddWithValue("filter_name", data.Filtername);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        GuideRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            FilterGuidelineDetail ObjGuideList = new FilterGuidelineDetail();
                            ObjGuideList.countryname = Convert.ToString(row["countryname"]);
                            ObjGuideList.location = Convert.ToString(row["location"]);
                            ObjGuideList.universityname = Convert.ToString(row["universityname"]);
                            ObjGuideList.guideline = Convert.ToString(row["guideline"]);
                            ObjGuideList.link = Convert.ToString(row["link"]);
                            objguide.Add(ObjGuideList);
                        }

                        GuideRes.data = objguide;
                        GuideRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(GuideRes, settings);
                    }
                    else
                    {
                        GuideRes.status = false;
                        GuideRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(GuideRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    GuideRes.status = false;
                    GuideRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(GuideRes, settings);

                }
            }
            return Ok(json);
        }

        //API for Portfolio end

        //API for Statement Of Purpose Start
        [HttpGet]
        [Route("GetSopIntrest")]
        public IActionResult GetSopIntrest()
        {
            DataSet ds = new DataSet();
            string json = "";

            SOPIntrestResponse IntrestRes = new SOPIntrestResponse();
            List<SOPIntrestDetail> objintrest = new List<SOPIntrestDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("BindSopIntrest", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    IntrestRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        SOPIntrestDetail objlist = new SOPIntrestDetail();
                        objlist.intrestname = Convert.ToString(row["intrestname"]);
                        objlist.intrestid = Convert.ToInt32(row["intrestid"]);

                        objintrest.Add(objlist);
                    }

                    IntrestRes.data = objintrest;
                    IntrestRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(IntrestRes, settings);
                }
                else
                {
                    IntrestRes.status = false;
                    IntrestRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(IntrestRes, settings);

                }

            }
            catch (Exception ex)
            {

                IntrestRes.status = false;
                IntrestRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(IntrestRes, settings);

            }

            return Ok(json);
        }



        //API for bind sample 
        [HttpGet]
        [Route("FilterSampleSopData")]
        public IActionResult FilterSampleSopData([FromHeader] GetSampleSop data)

        {
            DataSet ds = new DataSet();
            string json = "";

            SampleSOPResponse SampleSopRes = new SampleSOPResponse();
            List<SampleSOPDetail> objsamplesop = new List<SampleSOPDetail>();
            //if (data.intrestid == 0)
            //{
            //    SampleSopRes.status = false;
            //    SampleSopRes.message = "Invalid IntrestID";

            //    JsonSerializerSettings settings = new JsonSerializerSettings();
            //    settings.NullValueHandling = NullValueHandling.Ignore;
            //    json = JsonConvert.SerializeObject(SampleSopRes, settings);
            //}
            //else
            //{
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("ShowSampleSOPData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("intrestid_d", data.intrestid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        SampleSopRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            SampleSOPDetail ObjSampleList = new SampleSOPDetail();
                            ObjSampleList.title = Convert.ToString(row["title"]);
                            ObjSampleList.description = Convert.ToString(row["description"]);

                            objsamplesop.Add(ObjSampleList);
                        }

                        SampleSopRes.data = objsamplesop;
                        SampleSopRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(SampleSopRes, settings);
                    }
                    else
                    {
                        SampleSopRes.status = false;
                        SampleSopRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(SampleSopRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    SampleSopRes.status = false;
                    SampleSopRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(SampleSopRes, settings);

                }
            //}
            return Ok(json);
        }

        //API for bind table for sample sop data
        [HttpGet]
        [Route("GetSampleSopData")]
        public IActionResult GetSampleSopData()

        {
            DataSet ds = new DataSet();
            string json = "";

            SampleSOPResponse SampleSopRes = new SampleSOPResponse();
            List<SampleSOPDetail> objsamplesop = new List<SampleSOPDetail>();
           
            
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("GetSampleSOPAPIData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                   

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        SampleSopRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            SampleSOPDetail ObjSampleList = new SampleSOPDetail();
                            ObjSampleList.title = Convert.ToString(row["title"]);
                            ObjSampleList.description = Convert.ToString(row["description"]);

                            objsamplesop.Add(ObjSampleList);
                        }

                        SampleSopRes.data = objsamplesop;
                        SampleSopRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(SampleSopRes, settings);
                    }
                    else
                    {
                        SampleSopRes.status = false;
                        SampleSopRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(SampleSopRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    SampleSopRes.status = false;
                    SampleSopRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(SampleSopRes, settings);

                }
            
            return Ok(json);
        }


        //API start for personal essay

        //Api for show record of sample essay
        [HttpGet]
        [Route("GetSampleEssayData")]
        public IActionResult GetSampleEssayData()

        {
            DataSet ds = new DataSet();
            string json = "";

            SampleEssayResponse EssayRes = new SampleEssayResponse();
            List<SampleEsssayDetail> objessay = new List<SampleEsssayDetail>();


            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("BindSampleEssayGrid", con);
                cmd.CommandType = CommandType.StoredProcedure;


                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    EssayRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        SampleEsssayDetail ObjEssayList = new SampleEsssayDetail();
                        ObjEssayList.title = Convert.ToString(row["essaytitle"]);
                        ObjEssayList.description = Convert.ToString(row["description"]);
                        ObjEssayList.link = Convert.ToString(row["link"]);
                        ObjEssayList.filename = "http://admin.careerprabhu.com/" + "uploadpersonalessaypdf/" + Convert.ToString(row["filename"]);

                        objessay.Add(ObjEssayList);
                    }

                    EssayRes.data = objessay;
                    EssayRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EssayRes, settings);
                }
                else
                {
                    EssayRes.status = false;
                    EssayRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EssayRes, settings);

                }

            }
            catch (Exception ex)
            {

                EssayRes.status = false;
                EssayRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(EssayRes, settings);

            }

            return Ok(json);
        }

        //API for filter sample essay data according to country and university
        [HttpGet]
        [Route("FilterSampleEssayData")]
        public IActionResult FilterSampleEssayData([FromHeader] GetSampleEssay data)

        {
            DataSet ds = new DataSet();
            string json = "";

            SampleEssayResponse FilterEssayRes = new SampleEssayResponse();
            List<SampleEsssayDetail> objessay = new List<SampleEsssayDetail>();
          
            
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("BindSampleEssayAPIGridFilter", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("countryid_d", data.countryid);
                cmd.Parameters.AddWithValue("universityid_d", data.universityid);

                con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        FilterEssayRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            SampleEsssayDetail ObjSampleEssayList = new SampleEsssayDetail();
                            ObjSampleEssayList.title = Convert.ToString(row["essaytitle"]);
                            ObjSampleEssayList.description = Convert.ToString(row["description"]);
                            ObjSampleEssayList.link = Convert.ToString(row["link"]);
                            ObjSampleEssayList.filename = " http://admin.careerprabhu.com/" + "uploadpersonalessaypdf/" + Convert.ToString(row["filename"]);
                            objessay.Add(ObjSampleEssayList);
                        }

                        FilterEssayRes.data = objessay;
                        FilterEssayRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FilterEssayRes, settings);
                    }
                    else
                    {
                        FilterEssayRes.status = false;
                        FilterEssayRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FilterEssayRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    FilterEssayRes.status = false;
                    FilterEssayRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(FilterEssayRes, settings);

                }
            
            return Ok(json);
        }


        //API for bind country
        [HttpGet]
        [Route("Getcountry")]
        public IActionResult BindCountry()
        {
            DataSet ds = new DataSet();
            string json = "";

            CountryResponse CountryRes = new CountryResponse();
            List<CountryDetail> objcountry = new List<CountryDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("BindCountry", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    CountryRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        CountryDetail objlist = new CountryDetail();
                        objlist.countryname = Convert.ToString(row["countryname"]);
                        objlist.countryid = Convert.ToInt32(row["countryid"]);

                        objcountry.Add(objlist);
                    }

                    CountryRes.data = objcountry;
                    CountryRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CountryRes, settings);
                }
                else
                {
                    CountryRes.status = false;
                    CountryRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CountryRes, settings);

                }

            }
            catch (Exception ex)
            {

                CountryRes.status = false;
                CountryRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(CountryRes, settings);

            }

            return Ok(json);
        }
        //API for bind university according to country
        [HttpGet]
        [Route("Getuniversity")]
        public IActionResult BindUniversity([FromHeader] getuniversity data)

        {
            DataSet ds = new DataSet();
            string json = "";
            //data.stateid = 21;
            UniversityResponse UnivRes = new UniversityResponse();
            List<UniversityDetail> objuniv = new List<UniversityDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("BindUniversity", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("countryid_d", data.countryid);

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    UnivRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        UniversityDetail ObjUnivList = new UniversityDetail();
                        ObjUnivList.universityname = Convert.ToString(row["universityname"]);
                        ObjUnivList.universityid = Convert.ToInt32(row["universityid"]);

                        objuniv.Add(ObjUnivList);
                    }

                    UnivRes.data = objuniv;
                    UnivRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(UnivRes, settings);
                }
                else
                {
                    UnivRes.status = false;
                    UnivRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(UnivRes, settings);

                }

            }
            catch (Exception ex)
            {

                UnivRes.status = false;
                UnivRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(UnivRes, settings);

            }

            return Ok(json);
        }




        //API for bind draft
        [HttpGet]
        [Route("Getdraft")]
        public IActionResult BindDraft()
        {
            DataSet ds = new DataSet();
            string json = "";

            DraftResponse DraftRes = new DraftResponse();
            List<DraftDetail> objdraft = new List<DraftDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("BindDraft", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    DraftRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DraftDetail objlist = new DraftDetail();
                        objlist.drafttype = Convert.ToString(row["drafttype"]);
                        objlist.draftid = Convert.ToInt32(row["draftid"]);

                        objdraft.Add(objlist);
                    }

                    DraftRes.data = objdraft;
                    DraftRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(DraftRes, settings);
                }
                else
                {
                    DraftRes.status = false;
                    DraftRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(DraftRes, settings);

                }

            }
            catch (Exception ex)
            {

                DraftRes.status = false;
                DraftRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(DraftRes, settings);

            }

            return Ok(json);
        }

        //API for bind version
        [HttpGet]
        [Route("Getversion")]
        public IActionResult BindVersion()
        {
            DataSet ds = new DataSet();
            string json = "";

            VersionResponse VersionRes = new VersionResponse();
            List<VersionDetail> objversion = new List<VersionDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("BindVersion", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    VersionRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        VersionDetail objlist = new VersionDetail();
                        objlist.versiontype = Convert.ToString(row["versiontype"]);
                        objlist.versionid = Convert.ToInt32(row["versionid"]);

                        objversion.Add(objlist);
                    }

                    VersionRes.data = objversion;
                    VersionRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(VersionRes, settings);
                }
                else
                {
                    VersionRes.status = false;
                    VersionRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(VersionRes, settings);

                }

            }
            catch (Exception ex)
            {

                VersionRes.status = false;
                VersionRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(VersionRes, settings);

            }

            return Ok(json);
        }

        //API for save wite your essay
        [HttpPost]
        [Route("WriteSampleEssay")]
        
        public IActionResult WriteSampleEssay([FromBody] SaveWriteEssay data)
        {

            EssayResponse stures = new EssayResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
           string result = "";





            if (data.draftid == "" || data.versionid == "")
            {
                stures.status = false;
                stures.data = new EssayData();
                stures.message = "Invalid Draft Or Version";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(stures, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("savewriteessay", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("essayid_d", data.essayid);

                    cmd.Parameters.AddWithValue("draftid_d", data.draftid);
                    cmd.Parameters.AddWithValue("versionid_d", data.versionid);
                    cmd.Parameters.AddWithValue("essaydetail_d", data.essaydetail);
                    cmd.Parameters.AddWithValue("studentid_d", data.studentid);



                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();


                    if (result == "Success")
                    {
                        stures.status = true;
                        stures.data = new EssayData();
                        stures.message = "Saved Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }
                    else
                    {
                        stures.status = false;
                        stures.data = new EssayData();
                        stures.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }

                }
                catch (Exception e)
                {
                    stures.status = false;
                    stures.data = new EssayData();
                    stures.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);

                }
            }

            return Ok(json);
        }

        //Bind essay data
        [HttpGet]
        [Route("GetEssayData")]
        public IActionResult GetEssayData([FromHeader] SaveWriteEssay data)

        {
            DataSet ds = new DataSet();
            string json = "";

            DisplayEssayResponse EssayRes = new DisplayEssayResponse();
            List<DisplayEssayDetail> objessay = new List<DisplayEssayDetail>();


            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("BindWriteEssayData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("studentid_d", data.studentid);


                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    EssayRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DisplayEssayDetail ObjEssayList = new DisplayEssayDetail();
                        ObjEssayList.essayid = Convert.ToInt32(row["essayid"]);
                        ObjEssayList.draftid = Convert.ToString(row["draftid"]);
               
                        ObjEssayList.versionid = Convert.ToString(row["versionid"]);
                    
                        ObjEssayList.essaydetail = Convert.ToString(row["essaydetail"]);
                        

                        objessay.Add(ObjEssayList);
                    }

                    EssayRes.data = objessay;
                    EssayRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EssayRes, settings);
                }
                else
                {
                    EssayRes.status = false;
                    EssayRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EssayRes, settings);

                }

            }
            catch (Exception ex)
            {

                EssayRes.status = false;
                EssayRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(EssayRes, settings);

            }

            return Ok(json);
        }


        //Edit write essay data
        [HttpGet]
        [Route("EditEssayData")]
        public IActionResult EditEssayData([FromHeader] EditWriteEssay data)

        {
            DataSet ds = new DataSet();
            string json = "";

            EditEssayResponse EssayRes = new EditEssayResponse();
            EditEssayDetail objessay = new EditEssayDetail();


            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("EditWriteEssayData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("essayid_d", data.essayid);


                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables.Count > 0)
                {

                    EssayRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        // EditEssayDetail ObjEssayList = new EditEssayDetail();
                        objessay.essayid = Convert.ToInt32(row["essayid"]);
                        objessay.draftid = Convert.ToString(row["draftid"]);
                   
                        objessay.versionid = Convert.ToString(row["versionid"]);
                    
                        objessay.essaydetail = Convert.ToString(row["essaydetail"]);


                        //objessay.Add(ObjEssayList);
                    }

                    EssayRes.data = objessay;
                    EssayRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EssayRes, settings);
                }
                else
                {
                    EssayRes.status = false;
                    EssayRes.message = "Something went wrong";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EssayRes, settings);

                }

            }
            catch (Exception ex)
            {

                EssayRes.status = false;
                EssayRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(EssayRes, settings);

            }

            return Ok(json);
        }


        //API for update write essay data 
        [HttpPost]
        [Route("UpdateWriteSampleEssay")]

        public IActionResult UpdateWriteSampleEssay([FromBody] UpateWriteEssay data)
        {

            UpdateEssayResponse stures = new UpdateEssayResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";





            if (data.draftid == "" || data.versionid == "")
            {
                stures.status = false;
                stures.data = new UpdateEssayData();
                stures.message = "Invalid Draft Or Version";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(stures, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("updatewriteessay", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("essayid_d", data.essayid);

                    cmd.Parameters.AddWithValue("draftid_d", data.draftid);
                    cmd.Parameters.AddWithValue("versionid_d", data.versionid);
                    cmd.Parameters.AddWithValue("essaydetail_d", data.essaydetail);



                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();


                    if (result == "Success")
                    {
                        stures.status = true;
                        stures.data = new UpdateEssayData();
                        stures.message = "Updated Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }
                    else
                    {
                        stures.status = false;
                        stures.data = new UpdateEssayData();
                        stures.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }

                }
                catch (Exception e)
                {
                    stures.status = false;
                    stures.data = new UpdateEssayData();
                    stures.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);

                }
            }

            return Ok(json);
        }

        //API for delete write essay data

        [HttpGet]
        [Route("DeleteWriteSampleEssay")]

        public IActionResult DeleteWriteSampleEssay([FromHeader] DeleteWriteEssay data)
        {

            DeleteEssayResponse stures = new DeleteEssayResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";





           
            
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("DeleteWriteEssayData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("essayid_d", data.essayid);

                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();


                    if (result == "Success")
                    {
                        stures.status = true;
                        stures.data = new DeleteEssayData();
                        stures.message = "Deleted Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }
                    else
                    {
                        stures.status = false;
                        stures.data = new DeleteEssayData();
                        stures.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }

                }
                catch (Exception e)
                {
                    stures.status = false;
                    stures.data = new DeleteEssayData();
                    stures.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);

                }
            

            return Ok(json);
        }



        //API for save write sop data
     
        [HttpPost]
        [Route("WriteSOP")]

        public IActionResult WriteSOP([FromBody] SaveWriteSOP data)
        {

            WriteSOPResponse stures = new WriteSOPResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";





            if (data.draftid == "" || data.versionid == "")
            {
                stures.status = false;
                stures.data = new WriteSOPData();
                stures.message = "Invalid Draft Or Version";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(stures, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("savewriteSOP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("essayid_d", data.sopid);

                    cmd.Parameters.AddWithValue("draftid_d", data.draftid);
                    cmd.Parameters.AddWithValue("versionid_d", data.versionid);
                    cmd.Parameters.AddWithValue("essaydetail_d", data.essaydetail);
                    cmd.Parameters.AddWithValue("studentid_d", data.studentid);



                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();


                    if (result == "Success")
                    {
                        stures.status = true;
                        stures.data = new WriteSOPData();
                        stures.message = "Saved Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }
                    else
                    {
                        stures.status = false;
                        stures.data = new WriteSOPData();
                        stures.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }

                }
                catch (Exception e)
                {
                    stures.status = false;
                    stures.data = new WriteSOPData();
                    stures.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);

                }
            }

            return Ok(json);
        }

        //API for bind sop data
        [HttpGet]
        [Route("GetWriteSOPData")]
        public IActionResult GetWriteSOPData([FromHeader] SaveWriteSOP data)

        {
            DataSet ds = new DataSet();
            string json = "";

            DisplayWriteSOPResponse SOPRes = new DisplayWriteSOPResponse();
            List<DisplayWriteSOPDetail> objsop = new List<DisplayWriteSOPDetail>();


            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("BindWriteSOPData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("studentid_d", data.studentid);


                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    SOPRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DisplayWriteSOPDetail ObjSopList = new DisplayWriteSOPDetail();
                        ObjSopList.sopid = Convert.ToInt32(row["sopid"]);
                        ObjSopList.draftid = Convert.ToString(row["draftid"]);
                      
                        ObjSopList.versionid = Convert.ToString(row["versionid"]);
                       
                        ObjSopList.essaydetail = Convert.ToString(row["essaydetail"]);


                        objsop.Add(ObjSopList);
                    }

                    SOPRes.data = objsop;
                    SOPRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(SOPRes, settings);
                }
                else
                {
                    SOPRes.status = false;
                    SOPRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(SOPRes, settings);

                }

            }
            catch (Exception ex)
            {

                SOPRes.status = false;
                SOPRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(SOPRes, settings);

            }

            return Ok(json);
        }

        //API for edit write sop data
        [HttpGet]
        [Route("EditWriteSOPData")]
        public IActionResult EditWriteSOPData([FromHeader] EditWriteSOPData data)

        {
            DataSet ds = new DataSet();
            string json = "";

            EditWriteSopResponse SopRes = new EditWriteSopResponse();
            EditWriteSopDetail objessay = new EditWriteSopDetail();


            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("EditWriteSopData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("sopid_d", data.sopid);


                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables.Count > 0)
                {

                    SopRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        //EditWriteSopDetail ObjEssayList = new EditWriteSopDetail();
                        objessay.sopid = Convert.ToInt32(row["sopid"]);
                        objessay.draftid = Convert.ToString(row["draftid"]);
                       
                        objessay.versionid = Convert.ToString(row["versionid"]);
                     
                        objessay.essaydetail = Convert.ToString(row["essaydetail"]);


                       // objessay.Add(ObjEssayList);
                    }

                    SopRes.data = objessay;
                    SopRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(SopRes, settings);
                }
                else
                {
                    SopRes.status = false;
                    SopRes.message = "Something went wrong";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(SopRes, settings);

                }

            }
            catch (Exception ex)
            {

                SopRes.status = false;
                SopRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(SopRes, settings);

            }

            return Ok(json);
        }


        //API for update write sop data

        [HttpPost]
        [Route("UpdateWriteSOPEssay")]

        public IActionResult UpdateWriteSOPEssay([FromBody] UpateWriteSOPEssay data)
        {

            UpdateWriteSopResponse stures = new UpdateWriteSopResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";





            if (data.draftid == "" || data.versionid == "")
            {
                stures.status = false;
                stures.data = new UpdateWriteSopData();
                stures.message = "Invalid Draft Or Version";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(stures, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("updatewriteSop", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("sopid_d", data.sopid);

                    cmd.Parameters.AddWithValue("draftid_d", data.draftid);
                    cmd.Parameters.AddWithValue("versionid_d", data.versionid);
                    cmd.Parameters.AddWithValue("essaydetail_d", data.essaydetail);



                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();


                    if (result == "Success")
                    {
                        stures.status = true;
                        stures.data = new UpdateWriteSopData();
                        stures.message = "Updated Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }
                    else
                    {
                        stures.status = false;
                        stures.data = new UpdateWriteSopData();
                        stures.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }

                }
                catch (Exception e)
                {
                    stures.status = false;
                    stures.data = new UpdateWriteSopData();
                    stures.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);

                }
            }

            return Ok(json);
        }

        //API for delete Write Sop data
        [HttpGet]
        [Route("DeleteWriteSop")]

        public IActionResult DeleteWriteSop([FromHeader] DeleteWriteSOP data)
        {

            DeleteWriteSOpResponse stures = new DeleteWriteSOpResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";







            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                MySqlCommand cmd = new MySqlCommand("DeleteWriteSopData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("message", "");
                cmd.Parameters["message"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("sopid_d", data.sopid);

                con.Open();
                cmd.ExecuteScalar();
                result = cmd.Parameters["message"].Value.ToString();
                con.Close();


                if (result == "Success")
                {
                    stures.status = true;
                    stures.data = new DeleteWriteSopData();
                    stures.message = "Deleted Successfully";


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);
                }
                else
                {
                    stures.status = false;
                    stures.data = new DeleteWriteSopData();
                    stures.message = "Something Went Wrong";


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);
                }

            }
            catch (Exception e)
            {
                stures.status = false;
                stures.data = new DeleteWriteSopData();
                stures.message = e.Message;


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(stures, settings);

            }


            return Ok(json);
        }



        //Life coaches APi

        [HttpGet]
        [Route("GetLifeCoachesData")]
        public IActionResult GetLifeCoachesData()

        {
            DataSet ds = new DataSet();
            string json = "";

            DisplayLifeCoachResponse LifeCoachRes = new DisplayLifeCoachResponse();
            List<DisplayLifeCoachDetail> objcoach = new List<DisplayLifeCoachDetail>();


            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("Getlifecoachtopic", con);
                cmd.CommandType = CommandType.StoredProcedure;


                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    LifeCoachRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DisplayLifeCoachDetail ObjCoachList = new DisplayLifeCoachDetail();

                        ObjCoachList.topicid = Convert.ToInt32(row["topicid"]);
                        ObjCoachList.topicname = Convert.ToString(row["topicname"]);



                        objcoach.Add(ObjCoachList);
                    }

                    LifeCoachRes.data = objcoach;
                    LifeCoachRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(LifeCoachRes, settings);
                }
                else
                {
                    LifeCoachRes.status = false;
                    LifeCoachRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(LifeCoachRes, settings);

                }

            }
            catch (Exception ex)
            {

                LifeCoachRes.status = false;
                LifeCoachRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(LifeCoachRes, settings);

            }

            return Ok(json);
        }

        //Api for get life coaches data
        [HttpGet]
        [Route("LifeCoacheDetail")]
        public IActionResult LifeCoacheDetail([FromHeader] LifeCoachDetailData data)

        {
            DataSet ds = new DataSet();
            string json = "";

            DisplayLifeCoachDetailResponse CoachDetailRes = new DisplayLifeCoachDetailResponse();
            List<DisplayLifeCoach> objcoach = new List<DisplayLifeCoach>();


            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("GetlifecoachDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("topicid_d", data.topicid);
                

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    CoachDetailRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DisplayLifeCoach ObjCoachList = new DisplayLifeCoach();

                        ObjCoachList.filename = "http://admin.careerprabhu.com/" + "uploadlifecoachpdf/" + Convert.ToString(row["filename"]);
                        ObjCoachList.link = Convert.ToString(row["link"]);


                        objcoach.Add(ObjCoachList);
                    }

                    CoachDetailRes.data = objcoach;
                    CoachDetailRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CoachDetailRes, settings);
                }
                else
                {
                    CoachDetailRes.status = false;
                    CoachDetailRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CoachDetailRes, settings);

                }

            }
            catch (Exception ex)
            {

                CoachDetailRes.status = false;
                CoachDetailRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(CoachDetailRes, settings);

            }

            return Ok(json);
        }


      

        public void Execqry(string qry)
        {
            MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
            if ((con.State == ConnectionState.Closed) || (con.State == ConnectionState.Broken))
                con.Open();
            MySqlCommand cmd = new MySqlCommand(qry);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }



        //API for professional help master
        [HttpGet]
        [Route("ProfessionalHelpMaster")]
        public IActionResult ProfessionalHelpMaster()

        {
            DataSet ds = new DataSet();
            string json = "";

            ProfessionalHelpResponse HelpRes = new ProfessionalHelpResponse();
            List<ProfessionalHelpDetail> objhelp = new List<ProfessionalHelpDetail>();


            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("GetSoppropData", con);
                cmd.CommandType = CommandType.StoredProcedure;


                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    HelpRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ProfessionalHelpDetail ObjCoachList = new ProfessionalHelpDetail();

                        ObjCoachList.testimonials = Convert.ToString(row["testimonial"]);
                        ObjCoachList.image = "http://admin.careerprabhu.com/" + "SOP/" + Convert.ToString(row["filename"]);
                        



                        objhelp.Add(ObjCoachList);
                    }

                    HelpRes.data = objhelp;
                    HelpRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(HelpRes, settings);
                }
                else
                {
                    HelpRes.status = false;
                    HelpRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(HelpRes, settings);

                }

            }
            catch (Exception ex)
            {

                HelpRes.status = false;
                HelpRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(HelpRes, settings);

            }

            return Ok(json);
        }


        //API for profile builder start


            //Api for bind stream
        [HttpGet]
        [Route("GetTranscriptClass")]
        public IActionResult GetTranscriptClass()
        {
            DataSet ds = new DataSet();
            string json = "";

            ClassTranscriptResponse ClassRes = new ClassTranscriptResponse();
            List<ClassTranscriptDetail> objclass = new List<ClassTranscriptDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("BindClassApi", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    ClassRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ClassTranscriptDetail objlist = new ClassTranscriptDetail();
                        objlist.classname = Convert.ToString(row["class_name"]);
                        objlist.classid = Convert.ToInt32(row["class_id"]);
                        //if(Convert.ToInt32(row["class_id"]) == 4 || Convert.ToInt32(row["class_id"]) == 5 || Convert.ToInt32(row["class_id"]) == 6)
                        //{
                        //    objlist.isstream = true;
                        //}
                        //else
                        //{
                        //    objlist.isstream = false;
                        //}

                        objclass.Add(objlist);
                    }

                    ClassRes.data = objclass;
                    ClassRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ClassRes, settings);
                }
                else
                {
                    ClassRes.status = false;
                    ClassRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ClassRes, settings);

                }

            }
            catch (Exception ex)
            {

                ClassRes.status = false;
                ClassRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(ClassRes, settings);

            }

            return Ok(json);
        }

        //Api for bind stream
        [HttpGet]
        [Route("GetTranscriptStream")]
        public IActionResult GetTranscriptStream()
        {
            DataSet ds = new DataSet();
            string json = "";

            TransciptStreamResponse StreamRes = new TransciptStreamResponse();
            List<TranscriptStreamDetail> objstream = new List<TranscriptStreamDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("bindstream", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    StreamRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        TranscriptStreamDetail objlist = new TranscriptStreamDetail();
                        objlist.streamname = Convert.ToString(row["Stream_name"]);
                        objlist.streamid = Convert.ToInt32(row["Stream_id"]);

                        objstream.Add(objlist);
                    }

                    StreamRes.data = objstream;
                    StreamRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(StreamRes, settings);
                }
                else
                {
                    StreamRes.status = false;
                    StreamRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(StreamRes, settings);

                }

            }
            catch (Exception ex)
            {

                StreamRes.status = false;
                StreamRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(StreamRes, settings);

            }

            return Ok(json);
        }

        //API for save transcript data
        [AllowAnonymous]
        [HttpPost]
        [Route("SaveTranscriptData")]
        [Obsolete]
        public async Task<IActionResult> SaveTranscriptData([FromForm] SaveTranscriptDoc obj)
        {
            string json = "";
            string result = "";
            string guid = "";
            string pdffilename = "";
            string uploadDirectory = "";
            string qry = "";
            int maxid = 0;

            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            TranscriptAPIResponse objppfr = new TranscriptAPIResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();

 


            if (obj.studentid == 0 || obj.classid == 0 || obj.schoolname == "" || obj.avggrade == "" || obj.avgper == "")
            {
                objppfr.status = false;
                objppfr.data = new TranscriptAPIData();
                objppfr.message = "Invalid Paramater";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(objppfr, settings);
            }
            //else if (obj.Uploads == null)
            //{
            //    objppfr.status = false;
            //    objppfr.data = new TranscriptAPIData();
            //    objppfr.message = "Invalid File Format";


            //    settings.NullValueHandling = NullValueHandling.Ignore;
            //    json = JsonConvert.SerializeObject(objppfr, settings);
            //}
            else
            {
                try
                {



                    //save in parent table start


                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("savetranscriptdata", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("studentid_d", obj.studentid);
                    cmd.Parameters.AddWithValue("classid_d", obj.classid);
                    
                    cmd.Parameters.AddWithValue("schoolname_d", obj.schoolname);
                    cmd.Parameters.AddWithValue("avggrade_d", obj.avggrade);
                    cmd.Parameters.AddWithValue("avgper_d", obj.avgper);
                   



                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();

                    if (result == "Success")
                    {
                        try
                        {
                            qry = "SELECT MAX(transcriptid) as trans_id FROM tbl_transcript";
                            MySqlCommand cmd1 = new MySqlCommand(qry, con);

                            MySqlDataAdapter da1 = new MySqlDataAdapter();
                            da1.SelectCommand = cmd1;
                            da1.Fill(ds1);
                            con.Close();
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                maxid = Convert.ToInt32(ds1.Tables[0].Rows[0]["trans_id"]);
                            }
                            else
                            {
                                maxid = 0;
                            }
                        }
                        catch (Exception e)
                        {

                        }

                        if (obj.Uploads != null)
                        {
                            foreach (IFormFile item in obj.Uploads)
                            {
                                guid = Guid.NewGuid().ToString();
                                pdffilename = guid + item.FileName;


                                Execqry("insert into tbl_transcriptdocument(transcriptid,orgmarksheet,newmarksheet)values(" + maxid + ", '" + item.FileName + "','" + guid + "')");

                                string strdocPath = _hostingEnvironment.WebRootPath + "\\uploadtranscript\\";
                                if (!Directory.Exists(strdocPath))
                                {
                                    System.IO.Directory.CreateDirectory(_hostingEnvironment.WebRootPath + "/uploadtranscript");
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadtranscript");

                                }
                                else
                                {
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadtranscript");
                                }


                                var filePath = Path.Combine(uploadDirectory, pdffilename);

                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                {
                                    await item.CopyToAsync(fileStream);
                                }




                            }
                        }

                        objppfr.status = true;
                        objppfr.data = new TranscriptAPIData();
                        objppfr.message = "Saved Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }
                    else
                    {
                        objppfr.status = true;
                        objppfr.data = new TranscriptAPIData();
                        objppfr.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }


                   


                }
                catch (Exception e)
                {
                    objppfr.status = true;
                    objppfr.data = new TranscriptAPIData();
                    objppfr.message = e.Message.ToString();


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(objppfr, settings);
                }
            }




            return Ok(json);
        }

        //API for get transcript data

        [HttpGet]
        [Route("GetTranscriptData")]
        public IActionResult GetTranscriptData([FromHeader] TranscriptData_Stu obj)
        {
            DataSet ds = new DataSet();
            string json = "";

            GetTransciptResponse TransRes = new GetTransciptResponse();
            List<GetTranscriptDetail> objtrans = new List<GetTranscriptDetail>();
            List<GetTranscriptDetailDoc> objtransdoc;
            if (obj.studentid == 0)
            {
                TransRes.status = false;
                TransRes.message = "Invalid StudentID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(TransRes, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("BindTranscriptData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("studentid_d", obj.studentid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        TransRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            GetTranscriptDetail objlist = new GetTranscriptDetail();

                            //GetTranscriptDetailDoc objdoc = new GetTranscriptDetailDoc();
                            objlist.transcriptid = Convert.ToInt32(row["transcriptid"]);
                            //objlist.streamname = Convert.ToString(row["Stream_name"]);
                            objlist.classname = Convert.ToString(row["class_name"]);
                            objlist.schoolname = Convert.ToString(row["schoolname"]);
                            objlist.avggrade = Convert.ToString(row["avggrade"]);
                            objlist.avgper = Convert.ToString(row["avgper"]);

                            // objdoc.file = "http://apis.careerprabhu.com/" + "uploadtranscript/" + Convert.ToString(row["docname"]);
                            objtransdoc = new List<GetTranscriptDetailDoc>();


                            if(ds.Tables[1].Rows.Count > 0)
                            {
                                foreach (DataRow row1 in ds.Tables[1].Rows)
                                {
                                    if (objlist.transcriptid == Convert.ToInt32(row1["transcriptid"]))
                                    {
                                        GetTranscriptDetailDoc objdoc = new GetTranscriptDetailDoc();
                                        if (Convert.ToString(row1["docname"]) == "N/A" || Convert.ToString(row1["docname"]) == "" || Convert.ToString(row1["docname"]) == null)
                                        {
                                            //objdoc.file = "N/A";
                                            //objdoc.filename = "";
                                        }
                                        else
                                        {
                                            objdoc.file = "http://apis.careerprabhu.com/" + "uploadtranscript/" + Convert.ToString(row1["docname"]);
                                            objdoc.filename = Convert.ToString(row1["filename"]);
                                            objtransdoc.Add(objdoc);


                                        }

                                    }

                                }
                                objlist.data1 = objtransdoc;
                            }
                            
                            
                            objtrans.Add(objlist);
                           
                        }

                        TransRes.data = objtrans;
                       // TransRes.data = objtransdoc;
                        TransRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(TransRes, settings);
                    }
                    else
                    {
                        TransRes.status = false;
                        TransRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(TransRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    TransRes.status = false;
                    TransRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(TransRes, settings);

                }
            }
            

            return Ok(json);
        }

        //API for edit  transcipt data
        [HttpGet]
        [Route("EditTranscriptData")]
        public IActionResult EditTranscriptData([FromHeader] EditTranscriptData_Stu obj)
        {
            DataSet ds = new DataSet();
            string json = "";

            EditTransciptResponse TransEditRes = new EditTransciptResponse();
            EditTranscriptDetail objedittrans = new EditTranscriptDetail();
            if (obj.transcriptid == 0)
            {
                TransEditRes.status = false;
                TransEditRes.message = "Invalid TranscriptID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(TransEditRes, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("EditTranscriptData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("transcriptid_d", obj.transcriptid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        TransEditRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            //EditTranscriptDetail objlist = new EditTranscriptDetail();
                            objedittrans.transcriptid = Convert.ToInt32(row["transcriptid"]);
                            objedittrans.classid = Convert.ToInt32(row["classid"]);
                            objedittrans.classname = Convert.ToString(row["class_name"]);
                            //objlist.streamid = Convert.ToInt32(row["streamid"]);
                            //objlist.streamname = Convert.ToString(row["Stream_name"]);

                            objedittrans.schoolname = Convert.ToString(row["schoolname"]);
                            objedittrans.avggrade = Convert.ToString(row["avggrade"]);
                            objedittrans.avgper = Convert.ToString(row["avgper"]);

                            // objlist.filename = "http://apis.careerprabhu.com/" + "uploadtranscript/" + Convert.ToString(row["docname"]);


                            //objedittrans.Add(objlist);
                        }

                        TransEditRes.data = objedittrans;
                        TransEditRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(TransEditRes, settings);
                    }
                    else
                    {
                        TransEditRes.status = false;
                        TransEditRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(TransEditRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    TransEditRes.status = false;
                    TransEditRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(TransEditRes, settings);

                }
            }


            return Ok(json);
        }


        //API for update transcript data
        [AllowAnonymous]
        [HttpPost]
        [Route("UpdateTranscriptData")]
        [Obsolete]
        public async Task<IActionResult> UpdateTranscriptData([FromForm] UpdateTranscriptDoc obj)
        {
            string json = "";
            string result = "";
            string guid = "";
            string pdffilename = "";
            string uploadDirectory = "";
            string qry = "";
            int maxid = 0;

            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            TranscriptAPIUpdateResponse objppfr = new TranscriptAPIUpdateResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();




            if (obj.studentid == 0 || obj.classid == 0 )
            {
                objppfr.status = false;
                objppfr.data = new TranscriptAPIUpdateData();
                objppfr.message = "Invalid StudentID Or ClassID";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(objppfr, settings);
            }
            else if (obj.schoolname == "" || obj.avggrade == "" || obj.avgper == "")
            {
                objppfr.status = false;
                objppfr.data = new TranscriptAPIUpdateData();
                objppfr.message = "Invalid School Name Or Average Grade Or Average Percentage";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(objppfr, settings);
            }
            else
            {
                try
                {



                    //save in parent table start


                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("updatetranscriptdata", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("transcriptid_d", obj.transcriptid);
                    cmd.Parameters.AddWithValue("studentid_d", obj.studentid);
                    cmd.Parameters.AddWithValue("classid_d", obj.classid);
                    
                    cmd.Parameters.AddWithValue("schoolname_d", obj.schoolname);
                    cmd.Parameters.AddWithValue("avggrade_d", obj.avggrade);
                    cmd.Parameters.AddWithValue("avgper_d", obj.avgper);




                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();

                    if (result == "Success")
                    {
                       

                        if (obj.Uploads != null)
                        {
                            Execqry("delete from tbl_transcriptdocument where transcriptid="+obj.transcriptid);
                            foreach (IFormFile item in obj.Uploads)
                            {
                                guid = Guid.NewGuid().ToString();
                                pdffilename = guid + item.FileName;


                                Execqry("insert into tbl_transcriptdocument(transcriptid,orgmarksheet,newmarksheet)values(" + obj.transcriptid + ", '" + item.FileName + "','" + guid + "')");

                                string strdocPath = _hostingEnvironment.WebRootPath + "\\uploadtranscript\\";
                                if (!Directory.Exists(strdocPath))
                                {
                                    System.IO.Directory.CreateDirectory(_hostingEnvironment.WebRootPath + "/uploadtranscript");
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadtranscript");

                                }
                                else
                                {
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadtranscript");
                                }


                                var filePath = Path.Combine(uploadDirectory, pdffilename);

                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                {
                                    await item.CopyToAsync(fileStream);
                                }




                            }
                        }

                        objppfr.status = true;
                        objppfr.data = new TranscriptAPIUpdateData();
                        objppfr.message = "Updated Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }
                    else
                    {
                        objppfr.status = true;
                        objppfr.data = new TranscriptAPIUpdateData();
                        objppfr.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }





                }
                catch (Exception e)
                {
                    objppfr.status = true;
                    objppfr.data = new TranscriptAPIUpdateData();
                    objppfr.message = e.Message.ToString();


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(objppfr, settings);
                }
            }




            return Ok(json);
        }

        //API for delete transcript data

        [HttpGet]
        [Route("DeleteTranscriptData")]

        public IActionResult DeleteTranscriptData([FromHeader] DeleteTranscriptData data)
        {

            DeleteTranscriptResponse transres = new DeleteTranscriptResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";







            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                MySqlCommand cmd = new MySqlCommand("DeleteTranscript", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("message", "");
                cmd.Parameters["message"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("transcriptid_d", data.transcriptid);

                con.Open();
                cmd.ExecuteScalar();
                result = cmd.Parameters["message"].Value.ToString();
                con.Close();


                if (result == "Success")
                {
                    transres.status = true;
                    transres.data = new DeleteTranscript();
                    transres.message = "Deleted Successfully";


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(transres, settings);
                }
                else
                {
                    transres.status = false;
                    transres.data = new DeleteTranscript();
                    transres.message = "Something Went Wrong";


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(transres, settings);
                }

            }
            catch (Exception e)
            {
                transres.status = false;
                transres.data = new DeleteTranscript();
                transres.message = e.Message;


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(transres, settings);

            }


            return Ok(json);
        }




        //api for save cv
        [AllowAnonymous]
        [HttpPost]
        [Route("SaveStudentCV")]
        [Obsolete]
        public async Task<IActionResult> SaveStudentCV([FromForm] SaveStudentDoc obj)
        {
            string json = "";
            string result = "";
            string guid = "";
            string pdffilename = "";
            string uploadDirectory = "";
            string qry = "";
            int maxid = 0;

            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            CVAPIResponse objppfr = new CVAPIResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();




            if (obj.studentid == 0)
            {
                objppfr.status = false;
                objppfr.data = new CVAPIData();
                objppfr.message = "Invalid Paramater";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(objppfr, settings);
            }
            else if (obj.Uploads == null)
            {
                objppfr.status = false;
                objppfr.data = new CVAPIData();
                objppfr.message = "Invalid File Format";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(objppfr, settings);
            }
            else
            {
                try
                {


                    //save in parent table start

                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("savetCVData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("studentid_d", obj.studentid);
                   
                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();

                    if (result == "Success")
                    {
                        try
                        {
                            qry = "SELECT MAX(cvid) as cv_id FROM tbl_CV";
                            MySqlCommand cmd1 = new MySqlCommand(qry, con);

                            MySqlDataAdapter da1 = new MySqlDataAdapter();
                            da1.SelectCommand = cmd1;
                            da1.Fill(ds1);
                            con.Close();
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                maxid = Convert.ToInt32(ds1.Tables[0].Rows[0]["cv_id"]);
                            }
                            else
                            {
                                maxid = 0;
                            }
                        }
                        catch (Exception e)
                        {

                        }

                        if (obj.Uploads != null)
                        {
                            foreach (IFormFile item in obj.Uploads)
                            {
                                guid = Guid.NewGuid().ToString();
                                pdffilename = guid + item.FileName;
                             

                                Execqry("insert into tbl_CVdocument(cvid,orgcvname,newcvname)values(" + maxid + ", '" + "cv_" + item.FileName + "','" + guid + "')");

                                string strdocPath = _hostingEnvironment.WebRootPath + "\\uploadCVS\\";
                                if (!Directory.Exists(strdocPath))
                                {
                                    System.IO.Directory.CreateDirectory(_hostingEnvironment.WebRootPath + "/uploadCVS");
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadCVS");

                                }
                                else
                                {
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadCVS");
                                }


                                var filePath = Path.Combine(uploadDirectory, pdffilename);

                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                {
                                    await item.CopyToAsync(fileStream);
                                }




                            }
                        }

                        objppfr.status = true;
                        objppfr.data = new CVAPIData();
                        objppfr.message = "Saved Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }
                    else
                    {
                        objppfr.status = true;
                        objppfr.data = new CVAPIData();
                        objppfr.message = "Updated Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }





                }
                catch (Exception e)
                {
                    objppfr.status = true;
                    objppfr.data = new CVAPIData();
                    objppfr.message = e.Message.ToString();


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(objppfr, settings);
                }
            }




            return Ok(json);
        }



        [HttpGet]
        [Route("GetStudentCVData")]
        public IActionResult GetStudentCVData([FromHeader] StuCVData_Stu obj)
        {
            DataSet ds = new DataSet();
            string json = "";

            GetStuCVResponse TransRes = new GetStuCVResponse();
            GetStuCVDetail objtrans = new GetStuCVDetail();
            GetStuCVbannerDetail objban = new GetStuCVbannerDetail();


            if (obj.studentid == 0)
            {
                TransRes.status = false;
                TransRes.message = "Invalid StudentID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(TransRes, settings);
            }
            else
            {
                try
                {

                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("BindStuCVData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("studentid_d", obj.studentid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objban.banner = "http://admin.careerprabhu.com/" + "SOP/" + "primiumbanner.png";
                        TransRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {

                            objtrans.filename = Convert.ToString(row["filename"]);
                            objtrans.cvid = Convert.ToInt32(row["cvid"]);

                            objtrans.cvlink = "http://apis.careerprabhu.com/" + "uploadCVS/" + Convert.ToString(row["docname"]);
                           
                        }

                        TransRes.data = objtrans;
                        // TransRes.data = objtransdoc;
                        TransRes.banner = objban;

                        TransRes.message = "Success";
                        
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(TransRes, settings);
                    }
                    else
                    {
                        TransRes.status = false;
                        TransRes.message = "No Data Found";
                        objban.banner = "http://admin.careerprabhu.com/" + "SOP/" + "primiumbanner.png";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(TransRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    TransRes.status = false;
                    TransRes.message = ex.Message;
                    objban.banner = "http://admin.careerprabhu.com/" + "SOP/" + "primiumbanner.png";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(TransRes, settings);

                }
            }


            return Ok(json);
        }



        [HttpGet]
        [Route("DeleteStudentData")]

        public IActionResult DeleteStudentData([FromHeader] DeleteStuCvData data)
        {

            DeleteTranscriptResponse transres = new DeleteTranscriptResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";
            if (data.cvid == 0)
            {
                transres.status = false;
                transres.message = "Invalid Parameter";

                
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(transres, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("DeleteStuCV", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("cvid_d", data.cvid);

                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();


                    if (result == "Success")
                    {
                        transres.status = true;
                        transres.data = new DeleteTranscript();
                        transres.message = "Deleted Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(transres, settings);
                    }
                    else
                    {
                        transres.status = false;
                        transres.data = new DeleteTranscript();
                        transres.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(transres, settings);
                    }

                }
                catch (Exception e)
                {
                    transres.status = false;
                    transres.data = new DeleteTranscript();
                    transres.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(transres, settings);

                }
            }

          


            return Ok(json);
        }




        //API for Ecp starts here


        //API for save ECP data
        [AllowAnonymous]
        [HttpPost]
        [Route("SaveEcpData")]
        [Obsolete]
        public async Task<IActionResult> SaveEcpData([FromForm] SaveEcpDoc obj)
        {
            string json = "";
            string result = "";
            string guid = "";
            string pdffilename = "";
            string uploadDirectory = "";
            string qry = "";
            int maxid = 0;

            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            ECPAPIResponse objppfr = new ECPAPIResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            
           


            if (obj.studentid == 0 || obj.topic == "" || obj.fromdate == "" ||obj.todate =="" || obj.description =="" || obj.learning=="")
            {
                objppfr.status = false;
                objppfr.data = new EcpAPIData();
                objppfr.message = "Invalid Parameter";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(objppfr, settings);
            }
           //else if(obj.Uploads == null)
           // {
           //     objppfr.status = false;
           //     objppfr.data = new EcpAPIData();
           //     objppfr.message = "Invalid File Format";


           //     settings.NullValueHandling = NullValueHandling.Ignore;
           //     json = JsonConvert.SerializeObject(objppfr, settings);
           // }
        
          
            else
            {
                try
                {



                    //save in parent table start


                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("saveecpdata", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("studentid_d", obj.studentid);
                    cmd.Parameters.AddWithValue("topic_d", obj.topic);
                    cmd.Parameters.AddWithValue("fromdate_d", Converter(obj.fromdate));
                    cmd.Parameters.AddWithValue("todate_d", Converter(obj.todate));
                    cmd.Parameters.AddWithValue("certificatefrom_d", obj.certificatefrom);
                    cmd.Parameters.AddWithValue("description_d", obj.description);
                    cmd.Parameters.AddWithValue("learning_d", obj.learning);




                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();

                    if (result == "Success")
                    {
                        try
                        {
                            qry = "SELECT MAX(ecpid) as ecpid_id FROM tbl_ECP";
                            MySqlCommand cmd1 = new MySqlCommand(qry, con);

                            MySqlDataAdapter da1 = new MySqlDataAdapter();
                            da1.SelectCommand = cmd1;
                            da1.Fill(ds1);
                            con.Close();
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                maxid = Convert.ToInt32(ds1.Tables[0].Rows[0]["ecpid_id"]);
                            }
                            else
                            {
                                maxid = 0;
                            }
                        }
                        catch (Exception e)
                        {

                        }

                        if (obj.Uploads != null)
                        {
                            foreach (IFormFile item in obj.Uploads)
                            {
                                guid = Guid.NewGuid().ToString();
                                pdffilename = guid + item.FileName;


                                Execqry("insert into tbl_ECPdoc(ecpid,orgfilename,newfilename)values(" + maxid + ", '" + item.FileName + "','" + guid + "')");

                                string strdocPath = _hostingEnvironment.WebRootPath + "\\uploadecpscript\\";
                                if (!Directory.Exists(strdocPath))
                                {
                                    System.IO.Directory.CreateDirectory(_hostingEnvironment.WebRootPath + "/uploadecpscript");
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadecpscript");

                                }
                                else
                                {
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadecpscript");
                                }


                                var filePath = Path.Combine(uploadDirectory, pdffilename);

                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                {
                                    await item.CopyToAsync(fileStream);
                                }




                            }
                        }

                        objppfr.status = true;
                        objppfr.data = new EcpAPIData();
                        objppfr.message = "Saved Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }
                    else
                    {
                        objppfr.status = true;
                        objppfr.data = new EcpAPIData();
                        objppfr.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }





                }
                catch (Exception e)
                {
                    objppfr.status = true;
                    objppfr.data = new EcpAPIData();
                    objppfr.message = e.Message.ToString();


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(objppfr, settings);
                }
            }




            return Ok(json);
        }

        //API for get ecp data
        [HttpGet]
        [Route("GetEcpData")]
        public IActionResult GetEcpData([FromHeader] ECPData_Stu obj)
        {
            DataSet ds = new DataSet();
            string json = "";

            GetECPResponse EcpRes = new GetECPResponse();
            List<GetECPDetail> objtrans = new List<GetECPDetail>();
            if (obj.studentid == 0)
            {
                EcpRes.status = false;
                EcpRes.message = "Invalid StudentID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(EcpRes, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("BindECPData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("studentid_d", obj.studentid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        EcpRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            GetECPDetail objlist = new GetECPDetail();
                            objlist.ecpid = Convert.ToInt32(row["ecpid"]);
                            objlist.topic = Convert.ToString(row["topic"]);
                            objlist.fromdate = Convert.ToString(row["fromdate"]);
                            objlist.todate = Convert.ToString(row["todate"]);
                            objlist.description = Convert.ToString(row["description"]);
                            objlist.learning = Convert.ToString(row["learning"]);
                            objlist.certificationfrom = Convert.ToString(row["certificatefrom"]);

                            if (Convert.ToString(row["orgfilename"]) == "" || Convert.ToString(row["orgfilename"]) ==null)
                            {
                                objlist.originalfilename = "N/A";
                            }
                            else
                            {
                                objlist.originalfilename = Convert.ToString(row["orgfilename"]);
                            }



                            if (Convert.ToString(row["docname"]) == "N/A")
                            {
                                objlist.filename = Convert.ToString(row["docname"]);
                            }
                            else
                            {
                                objlist.filename = "http://apis.careerprabhu.com/" + "uploadecpscript/" + Convert.ToString(row["docname"]);
                            }
                           


                            objtrans.Add(objlist);
                        }

                        EcpRes.data = objtrans;
                        EcpRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(EcpRes, settings);
                    }
                    else
                    {
                        EcpRes.status = false;
                        EcpRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(EcpRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    EcpRes.status = false;
                    EcpRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EcpRes, settings);

                }
            }


            return Ok(json);
        }

        //API for edit ecp data
        [HttpGet]
        [Route("EditECPData")]
        public IActionResult EditECPData([FromHeader] EditECPData_Stu obj)
        {
            DataSet ds = new DataSet();
            string json = "";

            EditECPResponse ECPEditRes = new EditECPResponse();
            EditECPDetail objedittrans = new EditECPDetail();
            if (obj.ecpid == 0)
            {
                ECPEditRes.status = false;
                ECPEditRes.message = "Invalid ECPID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(ECPEditRes, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("EditECPData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("ecpid_d", obj.ecpid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        ECPEditRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            //EditECPDetail objlist = new EditECPDetail();
                            objedittrans.ecpid = Convert.ToInt32(row["ecpid"]);
                            objedittrans.topic = Convert.ToString(row["topic"]);
                            objedittrans.fromdate = Convert.ToString(row["fromdate"]);

                            objedittrans.todate = Convert.ToString(row["todate"]);

                            objedittrans.certificatefrom = Convert.ToString(row["certificatefrom"]);
                            objedittrans.description = Convert.ToString(row["description"]);
                            objedittrans.learning = Convert.ToString(row["learning"]);

                            // objlist.filename = "http://apis.careerprabhu.com/" + "uploadtranscript/" + Convert.ToString(row["docname"]);


                            //objedittrans.Add(objlist);
                        }

                        ECPEditRes.data = objedittrans;
                        ECPEditRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(ECPEditRes, settings);
                    }
                    else
                    {
                        ECPEditRes.status = false;
                        ECPEditRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(ECPEditRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    ECPEditRes.status = false;
                    ECPEditRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ECPEditRes, settings);

                }
            }


            return Ok(json);
        }

        //API for update ecp data
        [AllowAnonymous]
        [HttpPost]
        [Route("UpdateECPData")]
        [Obsolete]
        public async Task<IActionResult> UpdateECPData([FromForm] UpdateECPDoc obj)
        {
            string json = "";
            string result = "";
            string guid = "";
            string pdffilename = "";
            string uploadDirectory = "";
            string qry = "";
            int maxid = 0;

            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            ECPAPIUpdateResponse objppfr = new ECPAPIUpdateResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();




            if (obj.studentid == 0 || obj.topic == "" || obj.fromdate == "" || obj.todate == "" || obj.description == "" || obj.learning == "")
            {
                objppfr.status = false;
                objppfr.data = new ECPAPIUpdateData();
                objppfr.message = "Invalid Parameter";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(objppfr, settings);
            }

            else
            {
                try
                {



                    //save in parent table start


                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("UpdateECPData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("ecpid_d", obj.ecpid);
                    cmd.Parameters.AddWithValue("studentid_d", obj.studentid);
                    cmd.Parameters.AddWithValue("topic_d", obj.topic);
                    cmd.Parameters.AddWithValue("fromdate_d", Converter(obj.fromdate));
                    cmd.Parameters.AddWithValue("todate_d", Converter(obj.todate));
                    cmd.Parameters.AddWithValue("certificatefrom_d", obj.certificatefrom);
                    cmd.Parameters.AddWithValue("description_d", obj.description);
                    cmd.Parameters.AddWithValue("learning_d", obj.learning);




                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();

                    if (result == "Success")
                    {


                        if (obj.Uploads != null)
                        {
                            Execqry("delete from tbl_ecpdoc where ecpid=" + obj.ecpid);
                            foreach (IFormFile item in obj.Uploads)
                            {
                                guid = Guid.NewGuid().ToString();
                                pdffilename = guid + item.FileName;


                                Execqry("insert into tbl_ecpdoc(ecpid,orgfilename,newfilename)values(" + obj.ecpid + ", '" + item.FileName + "','" + guid + "')");

                                string strdocPath = _hostingEnvironment.WebRootPath + "\\uploadecpscript\\";
                                if (!Directory.Exists(strdocPath))
                                {
                                    System.IO.Directory.CreateDirectory(_hostingEnvironment.WebRootPath + "/uploadecpscript");
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadecpscript");

                                }
                                else
                                {
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadecpscript");
                                }


                                var filePath = Path.Combine(uploadDirectory, pdffilename);

                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                {
                                    await item.CopyToAsync(fileStream);
                                }




                            }
                        }

                        objppfr.status = true;
                        objppfr.data = new ECPAPIUpdateData();
                        objppfr.message = "Updated Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }
                    else
                    {
                        objppfr.status = true;
                        objppfr.data = new ECPAPIUpdateData();
                        objppfr.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }





                }
                catch (Exception e)
                {
                    objppfr.status = true;
                    objppfr.data = new ECPAPIUpdateData();
                    objppfr.message = e.Message.ToString();


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(objppfr, settings);
                }
            }




            return Ok(json);
        }


        //API for delete ECP data
        [HttpGet]
        [Route("DeleteECPData")]

        public IActionResult DeleteECPData([FromHeader] DeleteECPData data)
        {

            DeleteECPResponse ecpres = new DeleteECPResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";
            if (data.ecpid == 0)
            {
                ecpres.status = false;
                ecpres.message = "Invalid ECPID";

               
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(ecpres, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("DeleteECPData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("ecpid_d", data.ecpid);

                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();


                    if (result == "Success")
                    {
                        ecpres.status = true;
                        ecpres.data = new DeleteECP();
                        ecpres.message = "Deleted Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(ecpres, settings);
                    }
                    else
                    {
                        ecpres.status = false;
                        ecpres.data = new DeleteECP();
                        ecpres.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(ecpres, settings);
                    }

                }
                catch (Exception e)
                {
                    ecpres.status = false;
                    ecpres.data = new DeleteECP();
                    ecpres.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ecpres, settings);

                }
            }

            


            return Ok(json);
        }

        //API for ECA Data




        //API for Ecp ends here


        //API for ECA starts here

        //API for save ECA data


        //API for bind level
        [HttpGet]
        [Route("BindLevel")]
        public IActionResult BindLevel()
        {
            DataSet ds = new DataSet();
            string json = "";

            GetLevelResponse EcpRes = new GetLevelResponse();
            List<GetLevelDetail> objtrans = new List<GetLevelDetail>();
           
            
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("BindLevel", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        EcpRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                        GetLevelDetail objlist = new GetLevelDetail();
                            objlist.levelid = Convert.ToInt32(row["levelid"]);
                            objlist.level = Convert.ToString(row["levelname"]);
                            


                            objtrans.Add(objlist);
                        }

                        EcpRes.data = objtrans;
                        EcpRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(EcpRes, settings);
                    }
                    else
                    {
                        EcpRes.status = false;
                        EcpRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(EcpRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    EcpRes.status = false;
                    EcpRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EcpRes, settings);

                }
            


            return Ok(json);
        }




        [AllowAnonymous]
        [HttpPost]
        [Route("SaveEcAData")]
        [Obsolete]
        public async Task<IActionResult> SaveEcAData([FromForm] SaveEcaDoc obj)
        {
            string json = "";
            string result = "";
            string guid = "";
            string pdffilename = "";
            string uploadDirectory = "";
            string qry = "";
            int maxid = 0;

            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            ECPAPIResponse objppfr = new ECPAPIResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();




            if (obj.studentid == 0 || obj.classid==0 || obj.activity == "" || obj.fromdate == "" || obj.todate == "" || obj.achievement == "" || obj.learning == "" || obj.level ==0)
            {
                objppfr.status = false;
                objppfr.data = new EcpAPIData();
                objppfr.message = "Invalid Parameter";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(objppfr, settings);
            }
          //else if(obj.Uploads == null)
          //  {
          //      objppfr.status = false;
          //      objppfr.data = new EcpAPIData();
          //      objppfr.message = "Invalid File Format";


          //      settings.NullValueHandling = NullValueHandling.Ignore;
          //      json = JsonConvert.SerializeObject(objppfr, settings);
          //  }


            else
            {
                try
                {



                    //save in parent table start


                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("saveecadata", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("studentid_d", obj.studentid);
                    cmd.Parameters.AddWithValue("classid_d", obj.classid);
                    cmd.Parameters.AddWithValue("activity_d", obj.activity);
                    cmd.Parameters.AddWithValue("fromdate_d", Converter(obj.fromdate));
                    cmd.Parameters.AddWithValue("todate_d", Converter(obj.todate));
                    cmd.Parameters.AddWithValue("level_d", obj.level);
                    cmd.Parameters.AddWithValue("achievement_d", obj.achievement);
                    cmd.Parameters.AddWithValue("learning_d", obj.learning);




                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();

                    if (result == "Success")
                    {
                        try
                        {
                            qry = "SELECT MAX(ecaid) as ecaid_id FROM tbl_eca";
                            MySqlCommand cmd1 = new MySqlCommand(qry, con);

                            MySqlDataAdapter da1 = new MySqlDataAdapter();
                            da1.SelectCommand = cmd1;
                            da1.Fill(ds1);
                            con.Close();
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                maxid = Convert.ToInt32(ds1.Tables[0].Rows[0]["ecaid_id"]);
                            }
                            else
                            {
                                maxid = 0;
                            }
                        }
                        catch (Exception e)
                        {

                        }

                        if (obj.Uploads != null)
                        {
                            foreach (IFormFile item in obj.Uploads)
                            {
                                guid = Guid.NewGuid().ToString();
                                pdffilename = guid + item.FileName;


                                Execqry("insert into tbl_ecadoc(ecaid,orgfilename,newfilename)values(" + maxid + ", '" + item.FileName + "','" + guid + "')");

                                string strdocPath = _hostingEnvironment.WebRootPath + "\\uploadecadata\\";
                                if (!Directory.Exists(strdocPath))
                                {
                                    System.IO.Directory.CreateDirectory(_hostingEnvironment.WebRootPath + "/uploadecadata");
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadecadata");

                                }
                                else
                                {
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadecadata");
                                }


                                var filePath = Path.Combine(uploadDirectory, pdffilename);

                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                {
                                    await item.CopyToAsync(fileStream);
                                }




                            }
                        }

                        objppfr.status = true;
                        objppfr.data = new EcpAPIData();
                        objppfr.message = "Saved Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }
                    else
                    {
                        objppfr.status = true;
                        objppfr.data = new EcpAPIData();
                        objppfr.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }





                }
                catch (Exception e)
                {
                    objppfr.status = true;
                    objppfr.data = new EcpAPIData();
                    objppfr.message = e.Message.ToString();


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(objppfr, settings);
                }
            }




            return Ok(json);
        }

        //API for get Ecp Data
        [HttpGet]
        [Route("GetEcaData")]
        public IActionResult GetEcaData([FromHeader] ECAData_Stu obj)
        {
            DataSet ds = new DataSet();
            string json = "";

            GetECAResponse EcpRes = new GetECAResponse();
            List<GetECADetail> objtrans = new List<GetECADetail>();
            if (obj.studentid == 0)
            {
                EcpRes.status = false;
                EcpRes.message = "Invalid StudentID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(EcpRes, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("BindECAData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("studentid_d", obj.studentid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        EcpRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            GetECADetail objlist = new GetECADetail();
                            objlist.ecaid = Convert.ToInt32(row["ecaid"]);
                            objlist.activityname = Convert.ToString(row["activityname"]);
                            objlist.level = Convert.ToString(row["ecalevel"]);
                            objlist.fromdate = Convert.ToString(row["fromdate"]);
                            objlist.todate = Convert.ToString(row["todate"]);
                            objlist.achievement = Convert.ToString(row["achievement"]);
                            objlist.learning = Convert.ToString(row["learning"]);
                            objlist.classname = Convert.ToString(row["class_name"]);
                            if (Convert.ToString(row["orgfilename"]) == "" || Convert.ToString(row["orgfilename"]) == null)
                            {
                                objlist.originalfilename = "N/A";

                            }
                            else
                            {
                                objlist.originalfilename = Convert.ToString(row["orgfilename"]);

                            }


                            if (Convert.ToString(row["docname"]) == "N/A")
                            {
                                objlist.filename = Convert.ToString(row["docname"]);
                            }
                            else
                            {
                                objlist.filename = "http://apis.careerprabhu.com/" + "uploadecadata/" + Convert.ToString(row["docname"]);
                            }
                                
                           


                            objtrans.Add(objlist);
                        }

                        EcpRes.data = objtrans;
                        EcpRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(EcpRes, settings);
                    }
                    else
                    {
                        EcpRes.status = false;
                        EcpRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(EcpRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    EcpRes.status = false;
                    EcpRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EcpRes, settings);

                }
            }


            return Ok(json);
        }

        //API for edit ECA data
        [HttpGet]
        [Route("EditECAData")]
        public IActionResult EditECAData([FromHeader] EditECAData_Stu obj)
        {
            DataSet ds = new DataSet();
            string json = "";

            EditECAResponse ECPEditRes = new EditECAResponse();
            EditECADetail objedittrans = new EditECADetail();
            if (obj.ecaid == 0)
            {
                ECPEditRes.status = false;
                ECPEditRes.message = "Invalid ECAID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(ECPEditRes, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("EditECAData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("ecaid_d", obj.ecaid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        ECPEditRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            //EditECADetail objlist = new EditECADetail();
                            objedittrans.ecaid = Convert.ToInt32(row["ecaid"]);
                            objedittrans.classid = Convert.ToInt32(row["class_id"]);
                            objedittrans.classname = Convert.ToString(row["class_name"]);
                            objedittrans.fromdate = Convert.ToString(row["fromdate"]);

                            objedittrans.todate = Convert.ToString(row["todate"]);

                            objedittrans.activityname = Convert.ToString(row["activityname"]);
                            objedittrans.level = Convert.ToInt32(row["ecalevel"]);
                            objedittrans.levelname = Convert.ToString(row["levelname"]);
                            objedittrans.learning = Convert.ToString(row["learning"]);
                            objedittrans.achievement = Convert.ToString(row["achievement"]);

                            // objlist.filename = "http://apis.careerprabhu.com/" + "uploadtranscript/" + Convert.ToString(row["docname"]);


                            //objedittrans.Add(objlist);
                        }

                        ECPEditRes.data = objedittrans;
                        ECPEditRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(ECPEditRes, settings);
                    }
                    else
                    {
                        ECPEditRes.status = false;
                        ECPEditRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(ECPEditRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    ECPEditRes.status = false;
                    ECPEditRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ECPEditRes, settings);

                }
            }


            return Ok(json);
        }


        //API for update eca data
        [AllowAnonymous]
        [HttpPost]
        [Route("UpdateECAData")]
        [Obsolete]
        public async Task<IActionResult> UpdateECAData([FromForm] UpdateECADoc obj)
        {
            string json = "";
            string result = "";
            string guid = "";
            string pdffilename = "";
            string uploadDirectory = "";
            string qry = "";
            int maxid = 0;

            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            ECAAPIUpdateResponse objppfr = new ECAAPIUpdateResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();




            if (obj.studentid == 0 || obj.classid==0 || obj.activity == "" || obj.fromdate == "" || obj.todate == "" || obj.achievement == "" || obj.learning == "" ||  obj.level == 0)
            {
                objppfr.status = false;
                objppfr.data = new ECAAPIUpdateData();
                objppfr.message = "Invalid Parameter";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(objppfr, settings);
            }

            else
            {
                try
                {



                    //save in parent table start


                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("updateecadata", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("ecaid_d", obj.ecaid);
                    cmd.Parameters.AddWithValue("studentid_d", obj.studentid);
                    cmd.Parameters.AddWithValue("classid_d", obj.classid);
                    cmd.Parameters.AddWithValue("activity_d", obj.activity);
                    cmd.Parameters.AddWithValue("fromdate_d", Converter(obj.fromdate));
                    cmd.Parameters.AddWithValue("todate_d", Converter(obj.todate));
                    cmd.Parameters.AddWithValue("level_d", obj.level);
                    cmd.Parameters.AddWithValue("achievement_d", obj.achievement);
                    cmd.Parameters.AddWithValue("learning_d", obj.learning);




                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();

                    if (result == "Success")
                    {


                        if (obj.Uploads != null)
                        {
                            Execqry("delete from tbl_ecadoc where ecaid=" + obj.ecaid);
                            foreach (IFormFile item in obj.Uploads)
                            {
                                guid = Guid.NewGuid().ToString();
                                pdffilename = guid + item.FileName;


                                Execqry("insert into tbl_ecadoc(ecaid,orgfilename,newfilename)values(" + obj.ecaid + ", '" + item.FileName + "','" + guid + "')");

                                string strdocPath = _hostingEnvironment.WebRootPath + "\\uploadecpscript\\";
                                if (!Directory.Exists(strdocPath))
                                {
                                    System.IO.Directory.CreateDirectory(_hostingEnvironment.WebRootPath + "/uploadecpscript");
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadecpscript");

                                }
                                else
                                {
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadecpscript");
                                }


                                var filePath = Path.Combine(uploadDirectory, pdffilename);

                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                {
                                    await item.CopyToAsync(fileStream);
                                }




                            }
                        }

                        objppfr.status = true;
                        objppfr.data = new ECAAPIUpdateData();
                        objppfr.message = "Updated Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }
                    else
                    {
                        objppfr.status = true;
                        objppfr.data = new ECAAPIUpdateData();
                        objppfr.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }





                }
                catch (Exception e)
                {
                    objppfr.status = true;
                    objppfr.data = new ECAAPIUpdateData();
                    objppfr.message = e.Message.ToString();


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(objppfr, settings);
                }
            }




            return Ok(json);
        }

        //API for delete eca data
        [HttpGet]
        [Route("DeleteECAData")]

        public IActionResult DeleteECAData([FromHeader] DeleteECAData data)
        {

            DeleteECAResponse ecpres = new DeleteECAResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";
            if (data.ecaid == 0)
            {
                ecpres.status = false;
                ecpres.message = "Invalid ECAID";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(ecpres, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("DeleteECAData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("ecaid_d", data.ecaid);

                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();


                    if (result == "Success")
                    {
                        ecpres.status = true;
                        ecpres.data = new DeleteECA();
                        ecpres.message = "Deleted Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(ecpres, settings);
                    }
                    else
                    {
                        ecpres.status = false;
                        ecpres.data = new DeleteECA();
                        ecpres.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(ecpres, settings);
                    }

                }
                catch (Exception e)
                {
                    ecpres.status = false;
                    ecpres.data = new DeleteECA();
                    ecpres.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ecpres, settings);

                }
            }




            return Ok(json);
        }


        //API for ECA ends here


        //API for social work starts here

        //API for save social work

        [AllowAnonymous]
        [HttpPost]
        [Route("SaveSocialWorkData")]
        [Obsolete]
        public async Task<IActionResult> SaveSocialWorkData([FromForm] SaveSocialWorkDoc obj)
        {
            string json = "";
            string result = "";
            string guid = "";
            string pdffilename = "";
            string uploadDirectory = "";
            string qry = "";
            int maxid = 0;

            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            SocialWorkResponse objppfr = new SocialWorkResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();


            if (obj.studentid == 0 || obj.classid == 0 || obj.fromdate == "" || obj.todate == "" || obj.description == "" || obj.learning == "" || obj.socialwork == "")
            {
                objppfr.status = false;
                objppfr.data = new SocialWorkData();
                objppfr.message = "Invalid Parameter";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(objppfr, settings);
            }
            //else if(obj.Uploads == null)
            //{
            //    objppfr.status = false;
            //    objppfr.data = new SocialWorkData();
            //    objppfr.message = "Invalid File Format";


            //    settings.NullValueHandling = NullValueHandling.Ignore;
            //    json = JsonConvert.SerializeObject(objppfr, settings);
            //}


            else
            {
                try
                {

                    //save in parent table start


                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("savesoicialdata", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("studentid_d", obj.studentid);
                    cmd.Parameters.AddWithValue("classid_d", obj.classid);
                    cmd.Parameters.AddWithValue("socialwork_d", obj.socialwork);
                    cmd.Parameters.AddWithValue("fromdate_d", Converter(obj.fromdate));
                    cmd.Parameters.AddWithValue("todate_d", Converter(obj.todate));
                    cmd.Parameters.AddWithValue("description_d", obj.description);
                    
                    cmd.Parameters.AddWithValue("learning_d", obj.learning);

                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();

                    if (result == "Success")
                    {
                        try
                        {
                            qry = "SELECT MAX(socialworkid) as social_id FROM tbl_socialwork";
                            MySqlCommand cmd1 = new MySqlCommand(qry, con);

                            MySqlDataAdapter da1 = new MySqlDataAdapter();
                            da1.SelectCommand = cmd1;
                            da1.Fill(ds1);
                            con.Close();
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                maxid = Convert.ToInt32(ds1.Tables[0].Rows[0]["social_id"]);
                            }
                            else
                            {
                                maxid = 0;
                            }
                        }
                        catch (Exception e)
                        {

                        }
                     

                        if (obj.Uploads != null)
                        {
                            foreach (IFormFile item in obj.Uploads)
                            {
                                guid = Guid.NewGuid().ToString();
                                pdffilename = guid + item.FileName;


                                Execqry("insert into tbl_socialworkdoc(socialworkid,orgfilename,newfilename)values(" + maxid + ", '" + item.FileName + "','" + guid + "')");

                                string strdocPath = _hostingEnvironment.WebRootPath + "\\uploadsocialdata\\";
                                if (!Directory.Exists(strdocPath))
                                {
                                    System.IO.Directory.CreateDirectory(_hostingEnvironment.WebRootPath + "/uploadsocialdata");
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadsocialdata");

                                }
                                else
                                {
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadsocialdata");
                                }


                                var filePath = Path.Combine(uploadDirectory, pdffilename);

                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                {
                                    await item.CopyToAsync(fileStream);
                                }

                            }
                        }

                        objppfr.status = true;
                        objppfr.data = new SocialWorkData();
                        objppfr.message = "Saved Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }
                    else
                    {
                        objppfr.status = true;
                        objppfr.data = new SocialWorkData();
                        objppfr.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }

                }
                catch (Exception e)
                {
                    objppfr.status = true;
                    objppfr.data = new SocialWorkData();
                    objppfr.message = e.Message.ToString();


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(objppfr, settings);
                }
            }

            return Ok(json);
        }

        //API for get social work data

        [HttpGet]
        [Route("GetSocialWorkData")]
        public IActionResult GetSocialWorkData([FromHeader] SocialWorkData_Stu obj)
        {
            DataSet ds = new DataSet();
            string json = "";

            GetSocialWorkResponse SocialRes = new GetSocialWorkResponse();
            List<GetSocialWorkDetail> objsocial = new List<GetSocialWorkDetail>();
            if (obj.studentid == 0)
            {
                SocialRes.status = false;
                SocialRes.message = "Invalid StudentID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(SocialRes, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("BindSocialData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("studentid_d", obj.studentid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        SocialRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            GetSocialWorkDetail objlist = new GetSocialWorkDetail();
                            objlist.socialworkid = Convert.ToInt32(row["socialworkid"]);
                            objlist.socialwork = Convert.ToString(row["socialwork"]);
                            objlist.description = Convert.ToString(row["description"]);
                            objlist.fromdate = Convert.ToString(row["fromdate"]);
                            objlist.todate = Convert.ToString(row["todate"]);
                            
                            objlist.learning = Convert.ToString(row["learning"]);
                            objlist.classname = Convert.ToString(row["class_name"]);

                            if (Convert.ToString(row["orgfilename"]) == "" || Convert.ToString(row["orgfilename"])==null)
                            {
                                objlist.originalfilename = "N/A";

                            }
                            else
                            {
                                objlist.originalfilename = Convert.ToString(row["orgfilename"]);

                            }



                            if (Convert.ToString(row["docname"]) == "N/A")
                            {
                                objlist.filename = Convert.ToString(row["docname"]);
                            }
                            else
                            {
                                objlist.filename = "http://apis.careerprabhu.com/" + "uploadsocialdata/" + Convert.ToString(row["docname"]);
                            }
                            


                            objsocial.Add(objlist);
                        }

                        SocialRes.data = objsocial;
                        SocialRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(SocialRes, settings);
                    }
                    else
                    {
                        SocialRes.status = false;
                        SocialRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(SocialRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    SocialRes.status = false;
                    SocialRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(SocialRes, settings);

                }
            }


            return Ok(json);
        }

        //API for edit social work
        [HttpGet]
        [Route("EditSocialWorkData")]
        public IActionResult EditSocialWorkData([FromHeader] EditSocialData_Stu obj)
        {
            DataSet ds = new DataSet();
            string json = "";

            EditSocialResponse SocialEditRes = new EditSocialResponse();
            EditSocialDetail objeditsocial = new EditSocialDetail();
            if (obj.socialworkid == 0)
            {
                SocialEditRes.status = false;
                SocialEditRes.message = "Invalid SocialWork ID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(SocialEditRes, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("EditSocialData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("socialworkid_d", obj.socialworkid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        SocialEditRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            //EditECADetail objlist = new EditECADetail();
                            objeditsocial.socialworkid = Convert.ToInt32(row["socialworkid"]);
                            objeditsocial.socialwork = Convert.ToString(row["socialwork"]);
                            objeditsocial.classid = Convert.ToInt32(row["class_id"]);
                            objeditsocial.classname = Convert.ToString(row["class_name"]);
                            objeditsocial.fromdate = Convert.ToString(row["fromdate"]);

                            objeditsocial.todate = Convert.ToString(row["todate"]);

                            objeditsocial.description = Convert.ToString(row["description"]);
                            
                            objeditsocial.learning = Convert.ToString(row["learning"]);
                            

                            // objlist.filename = "http://apis.careerprabhu.com/" + "uploadtranscript/" + Convert.ToString(row["docname"]);


                            //objedittrans.Add(objlist);
                        }

                        SocialEditRes.data = objeditsocial;
                        SocialEditRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(SocialEditRes, settings);
                    }
                    else
                    {
                        SocialEditRes.status = false;
                        SocialEditRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(SocialEditRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    SocialEditRes.status = false;
                    SocialEditRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(SocialEditRes, settings);

                }
            }


            return Ok(json);
        }

        //API for update transcript data
        [AllowAnonymous]
        [HttpPost]
        [Route("UpdateSocialWorkData")]
        [Obsolete]
        public async Task<IActionResult> UpdateSocialWorkData([FromForm] UpdateSocialDoc obj)
        {
            string json = "";
            string result = "";
            string guid = "";
            string pdffilename = "";
            string uploadDirectory = "";
            string qry = "";
            int maxid = 0;

            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            SocialWorkUpdateResponse objppfr = new SocialWorkUpdateResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();




            if (obj.studentid == 0 || obj.classid == 0 || obj.fromdate == "" || obj.todate == "" || obj.description == "" || obj.learning == "" || obj.socialwork == "")
            {
                objppfr.status = false;
                objppfr.data = new SocialWorkUpdateData();
                objppfr.message = "Invalid Parameter";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(objppfr, settings);
            }

            else
            {
                try
                {



                    //save in parent table start


                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("updatesocialdata", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("socialworkid_d", obj.socialworkid);
                    cmd.Parameters.AddWithValue("studentid_d", obj.studentid);
                    cmd.Parameters.AddWithValue("classid_d", obj.classid);
                    cmd.Parameters.AddWithValue("description_d", obj.description);
                    cmd.Parameters.AddWithValue("fromdate_d", Converter(obj.fromdate));
                    cmd.Parameters.AddWithValue("todate_d", Converter(obj.todate));
                    cmd.Parameters.AddWithValue("learning_d", obj.learning);
                    cmd.Parameters.AddWithValue("socialwork_d", obj.socialwork);





                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();

                    if (result == "Success")
                    {


                        if (obj.Uploads != null)
                        {
                            Execqry("delete from tbl_socialworkdoc where socialworkid=" + obj.socialworkid);
                            foreach (IFormFile item in obj.Uploads)
                            {
                                guid = Guid.NewGuid().ToString();
                                pdffilename = guid + item.FileName;


                                Execqry("insert into tbl_socialworkdoc(socialworkid,orgfilename,newfilename)values(" + obj.socialworkid + ", '" + item.FileName + "','" + guid + "')");

                                string strdocPath = _hostingEnvironment.WebRootPath + "\\uploadsocialdata\\";
                                if (!Directory.Exists(strdocPath))
                                {
                                    System.IO.Directory.CreateDirectory(_hostingEnvironment.WebRootPath + "/uploadsocialdata");
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadsocialdata");

                                }
                                else
                                {
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadsocialdata");
                                }


                                var filePath = Path.Combine(uploadDirectory, pdffilename);

                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                {
                                    await item.CopyToAsync(fileStream);
                                }




                            }
                        }

                        objppfr.status = true;
                        objppfr.data = new SocialWorkUpdateData();
                        objppfr.message = "Updated Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }
                    else
                    {
                        objppfr.status = true;
                        objppfr.data = new SocialWorkUpdateData();
                        objppfr.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }





                }
                catch (Exception e)
                {
                    objppfr.status = false;
                    objppfr.data = new SocialWorkUpdateData();
                    objppfr.message = e.Message.ToString();


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(objppfr, settings);
                }
            }




            return Ok(json);
        }

        //API for delete social work
        [HttpGet]
        [Route("DeleteSocialWorkData")]

        public IActionResult DeleteSocialWorkData([FromHeader] DeleteSocialData data)
        {

            DeleteSocialResponse ecpres = new DeleteSocialResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";
            if (data.socialworkid == 0)
            {
                ecpres.status = false;
                ecpres.message = "Invalid SocialWork ID";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(ecpres, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("DeleteSocialData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("socialworkid_d", data.socialworkid);

                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();


                    if (result == "Success")
                    {
                        ecpres.status = true;
                        ecpres.data = new DeleteSocialWOrk();
                        ecpres.message = "Deleted Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(ecpres, settings);
                    }
                    else
                    {
                        ecpres.status = false;
                        ecpres.data = new DeleteSocialWOrk();
                        ecpres.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(ecpres, settings);
                    }

                }
                catch (Exception e)
                {
                    ecpres.status = false;
                    ecpres.data = new DeleteSocialWOrk();
                    ecpres.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ecpres, settings);

                }
            }




            return Ok(json);
        }




        //API for social work ends here


        //API for work experience starts here

        //API for save work experience 

        [AllowAnonymous]
        [HttpPost]
        [Route("SaveWorkExperienceData")]
        [Obsolete]
        public async Task<IActionResult> SaveWorkExperienceData([FromForm] SaveWorkExpDoc obj)
        {
            string json = "";
            string result = "";
            string guid = "";
            string pdffilename = "";
            string uploadDirectory = "";
            string qry = "";
            int maxid = 0;

            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            WorkExperienceResponse objppfr = new WorkExperienceResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();


            if (obj.studentid == 0  || obj.fromdate == "" || obj.todate == ""|| obj.projecttopic == "" || obj.description == "" || obj.learning == "" || obj.companyname == "")
            {
                objppfr.status = false;
                objppfr.data = new WorkExperienceData();
                objppfr.message = "Invalid Parameter";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(objppfr, settings);
            }
            //else if(obj.Uploads == null)
            //{
            //    objppfr.status = false;
            //    objppfr.data = new WorkExperienceData();
            //    objppfr.message = "Invalid File Format";


            //    settings.NullValueHandling = NullValueHandling.Ignore;
            //    json = JsonConvert.SerializeObject(objppfr, settings);
            //}


            else
            {
                try
                {

                    //save in parent table start


                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("saveworkdata", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("studentid_d", obj.studentid);
                    cmd.Parameters.AddWithValue("companyname_d", obj.companyname);
                    cmd.Parameters.AddWithValue("topic_d", obj.projecttopic);
                    cmd.Parameters.AddWithValue("fromdate_d", Converter(obj.fromdate));
                    cmd.Parameters.AddWithValue("todate_d", Converter(obj.todate));
                    cmd.Parameters.AddWithValue("description_d", obj.description);

                    cmd.Parameters.AddWithValue("learning_d", obj.learning);

                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();

                    if (result == "Success")
                    {
                        try
                        {
                            qry = "SELECT MAX(workid) as work_id FROM tbl_workexperience";
                            MySqlCommand cmd1 = new MySqlCommand(qry, con);

                            MySqlDataAdapter da1 = new MySqlDataAdapter();
                            da1.SelectCommand = cmd1;
                            da1.Fill(ds1);
                            con.Close();
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                maxid = Convert.ToInt32(ds1.Tables[0].Rows[0]["work_id"]);
                            }
                            else
                            {
                                maxid = 0;
                            }
                        }
                        catch (Exception e)
                        {

                        }

                        if (obj.Uploads != null)
                        {
                            foreach (IFormFile item in obj.Uploads)
                            {
                                guid = Guid.NewGuid().ToString();
                                pdffilename = guid + item.FileName;


                                Execqry("insert into tbl_workexperiencedoc(workid,orgfilename,newfilename)values(" + maxid + ", '" + item.FileName + "','" + guid + "')");

                                string strdocPath = _hostingEnvironment.WebRootPath + "\\uploadExperiencedata\\";
                                if (!Directory.Exists(strdocPath))
                                {
                                    System.IO.Directory.CreateDirectory(_hostingEnvironment.WebRootPath + "/uploadExperiencedata");
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadExperiencedata");

                                }
                                else
                                {
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadExperiencedata");
                                }


                                var filePath = Path.Combine(uploadDirectory, pdffilename);

                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                {
                                    await item.CopyToAsync(fileStream);
                                }

                            }
                        }

                        objppfr.status = true;
                        objppfr.data = new WorkExperienceData();
                        objppfr.message = "Saved Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }
                    else
                    {
                        objppfr.status = true;
                        objppfr.data = new WorkExperienceData();
                        objppfr.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }

                }
                catch (Exception e)
                {
                    objppfr.status = true;
                    objppfr.data = new WorkExperienceData();
                    objppfr.message = e.Message.ToString();


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(objppfr, settings);
                }
            }

            return Ok(json);
        }

        //API for get data
        [HttpGet]
        [Route("GetWorkExpData")]
        public IActionResult GetWorkExpData([FromHeader] WorkExperienceData_Stu obj)
        {
            DataSet ds = new DataSet();
            string json = "";

            GetWorExpResponse EcpRes = new GetWorExpResponse();
            List<GetWorkExpDetail> objtrans = new List<GetWorkExpDetail>();
            if (obj.studentid == 0)
            {
                EcpRes.status = false;
                EcpRes.message = "Invalid StudentID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(EcpRes, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("BindWorkExpData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("studentid_d", obj.studentid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        EcpRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            GetWorkExpDetail objlist = new GetWorkExpDetail();
                            objlist.workid = Convert.ToInt32(row["workid"]);
                            objlist.projecttopic = Convert.ToString(row["projecttopic"]);
                            objlist.fromdate = Convert.ToString(row["fromdate"]);
                            objlist.todate = Convert.ToString(row["todate"]);
                            objlist.description = Convert.ToString(row["description"]);
                            objlist.learning = Convert.ToString(row["learning"]);
                            objlist.companyname = Convert.ToString(row["companyname"]);

                            if (Convert.ToString(row["orgfilename"]) == "" || Convert.ToString(row["orgfilename"]) ==null)
                            {
                                objlist.originalfilename = "N/A";
                            }
                            else
                            {
                                objlist.originalfilename = Convert.ToString(row["orgfilename"]);
                            }




                            if (Convert.ToString(row["docname"]) == "N/A")
                            {
                                objlist.filename = Convert.ToString(row["docname"]);
                            }
                            else
                            {
                                objlist.filename = "http://apis.careerprabhu.com/" + "uploadExperiencedata/" + Convert.ToString(row["docname"]);
                            }
                           


                            objtrans.Add(objlist);
                        }

                        EcpRes.data = objtrans;
                        EcpRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(EcpRes, settings);
                    }
                    else
                    {
                        EcpRes.status = false;
                        EcpRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(EcpRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    EcpRes.status = false;
                    EcpRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EcpRes, settings);

                }
            }


            return Ok(json);
        }


        //API for edit record
        [HttpGet]
        [Route("EditWorkExpData")]
        public IActionResult EditWorkExpData([FromHeader] EditWorkExpData_Stu obj)
        {
            DataSet ds = new DataSet();
            string json = "";

            EditWorkExpResponse ECPEditRes = new EditWorkExpResponse();
            EditWorkExpDetail objedittrans = new EditWorkExpDetail();
            if (obj.workid == 0)
            {
                ECPEditRes.status = false;
                ECPEditRes.message = "Invalid WorkID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(ECPEditRes, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("EditWorkExpData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("workid_d", obj.workid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        ECPEditRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            //EditECPDetail objlist = new EditECPDetail();
                            objedittrans.workid = Convert.ToInt32(row["workid"]);
                            objedittrans.projecttopic = Convert.ToString(row["projecttopic"]);
                            objedittrans.fromdate = Convert.ToString(row["fromdate"]);

                            objedittrans.todate = Convert.ToString(row["todate"]);

                            objedittrans.companyname = Convert.ToString(row["companyname"]);
                            objedittrans.description = Convert.ToString(row["description"]);
                            objedittrans.learning = Convert.ToString(row["learning"]);

                            // objlist.filename = "http://apis.careerprabhu.com/" + "uploadtranscript/" + Convert.ToString(row["docname"]);


                            //objedittrans.Add(objlist);
                        }

                        ECPEditRes.data = objedittrans;
                        ECPEditRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(ECPEditRes, settings);
                    }
                    else
                    {
                        ECPEditRes.status = false;
                        ECPEditRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(ECPEditRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    ECPEditRes.status = false;
                    ECPEditRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ECPEditRes, settings);

                }
            }


            return Ok(json);
        }

        //API for update data
        [AllowAnonymous]
        [HttpPost]
        [Route("UpdateWorkExpData")]
        [Obsolete]
        public async Task<IActionResult> UpdateWorkExpData([FromForm] UpdateWorkExpDoc obj)
        {
            string json = "";
            string result = "";
            string guid = "";
            string pdffilename = "";
            string uploadDirectory = "";
            string qry = "";
            int maxid = 0;

            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            WorkExpUpdateResponse objppfr = new WorkExpUpdateResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();

            if (obj.studentid == 0 || obj.fromdate == "" || obj.todate == "" || obj.projecttopic == "" || obj.description == "" || obj.learning == "" || obj.companyname == "")
            {
                objppfr.status = false;
                objppfr.data = new WorkExpUpdateData();
                objppfr.message = "Invalid Parameter";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(objppfr, settings);
            }

            else
            {
                try
                {

                    //save in parent table start

                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("UpdateWorkExpData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("workid_d", obj.workid);
                    cmd.Parameters.AddWithValue("studentid_d", obj.studentid);
                    cmd.Parameters.AddWithValue("companyname_d", obj.companyname);
                    cmd.Parameters.AddWithValue("topic_d", obj.projecttopic);
                    cmd.Parameters.AddWithValue("fromdate_d", Converter(obj.fromdate));
                    cmd.Parameters.AddWithValue("todate_d", Converter(obj.todate));
                    cmd.Parameters.AddWithValue("description_d", obj.description);

                    cmd.Parameters.AddWithValue("learning_d", obj.learning);

                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();

                    if (result == "Success")
                    {


                        if (obj.Uploads != null)
                        {
                            Execqry("delete from tbl_workexperiencedoc where workid=" + obj.workid);
                            foreach (IFormFile item in obj.Uploads)
                            {
                                guid = Guid.NewGuid().ToString();
                                pdffilename = guid + item.FileName;


                                Execqry("insert into tbl_workexperiencedoc(workid,orgfilename,newfilename)values(" + obj.workid + ", '" + item.FileName + "','" + guid + "')");

                                string strdocPath = _hostingEnvironment.WebRootPath + "\\uploadExperiencedata\\";
                                if (!Directory.Exists(strdocPath))
                                {
                                    System.IO.Directory.CreateDirectory(_hostingEnvironment.WebRootPath + "/uploadExperiencedata");
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadExperiencedata");

                                }
                                else
                                {
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadExperiencedata");
                                }


                                var filePath = Path.Combine(uploadDirectory, pdffilename);

                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                {
                                    await item.CopyToAsync(fileStream);
                                }

                            }
                        }

                        objppfr.status = true;
                        objppfr.data = new WorkExpUpdateData();
                        objppfr.message = "Updated Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }
                    else
                    {
                        objppfr.status = true;
                        objppfr.data = new WorkExpUpdateData();
                        objppfr.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }

                }
                catch (Exception e)
                {
                    objppfr.status = true;
                    objppfr.data = new WorkExpUpdateData();
                    objppfr.message = e.Message.ToString();


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(objppfr, settings);
                }
            }

            return Ok(json);
        }

        //API for delete work experience
        [HttpGet]
        [Route("DeleteWorkExpData")]

        public IActionResult DeleteWorkExpData([FromHeader] DeleteWorkExpData data)
        {

            DeleteWorkExpResponse ecpres = new DeleteWorkExpResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";
            if (data.workid == 0)
            {
                ecpres.status = false;
                ecpres.message = "Invalid WorkID";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(ecpres, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("DeleteWorkExpData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("workid_d", data.workid);

                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();


                    if (result == "Success")
                    {
                        ecpres.status = true;
                        ecpres.data = new DeleteWorkExp();
                        ecpres.message = "Deleted Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(ecpres, settings);
                    }
                    else
                    {
                        ecpres.status = false;
                        ecpres.data = new DeleteWorkExp();
                        ecpres.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(ecpres, settings);
                    }

                }
                catch (Exception e)
                {
                    ecpres.status = false;
                    ecpres.data = new DeleteWorkExp();
                    ecpres.message = e.Message;

                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ecpres, settings);

                }
            }

            return Ok(json);
        }




        //API for work experience ends here



        //API for summer school starts here


        //Api for bind summer school data
        [HttpGet]
        [Route("SummerSchoolData")]
        public IActionResult SummerSchoolData([FromHeader] GetSumerData data)

        {
            DataSet ds = new DataSet();
            string json = "";

            SummerSchoolResponse SummerRes = new SummerSchoolResponse();
            List<SummerSchoolDetail> objsummer = new List<SummerSchoolDetail>();
            //if (data.intrestid == 0 || data.countryid == 0)
            //{
            //    SummerRes.status = false;
            //    SummerRes.message = "Invalid IntrestID Or CountryID";

            //    JsonSerializerSettings settings = new JsonSerializerSettings();
            //    settings.NullValueHandling = NullValueHandling.Ignore;
            //    json = JsonConvert.SerializeObject(SummerRes, settings);
            //}

            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("BindSummerSchoolData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("countryid_d", data.countryid);
                cmd.Parameters.AddWithValue("intrestid_d", data.intrestid);

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    SummerRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        SummerSchoolDetail ObjSummerList = new SummerSchoolDetail();
                        ObjSummerList.countryname = Convert.ToString(row["countryname"]);
                        ObjSummerList.location = Convert.ToString(row["location"]);
                        ObjSummerList.cityname = Convert.ToString(row["cityname"]);
                        ObjSummerList.universityname = Convert.ToString(row["universityname"]);
                        ObjSummerList.topic = Convert.ToString(row["summertopic"]);
                        ObjSummerList.link = Convert.ToString(row["link"]);
                        ObjSummerList.description = Convert.ToString(row["description"]);
                        ObjSummerList.fees = Convert.ToString(row["fees"]);
                        ObjSummerList.duration = Convert.ToString(row["duration"]);
                        ObjSummerList.intrest = Convert.ToString(row["intrestarea"]);
                        ObjSummerList.applicationlink = Convert.ToString(row["applicationlink"]);

                        objsummer.Add(ObjSummerList);
                    }

                    SummerRes.data = objsummer;
                    SummerRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(SummerRes, settings);
                }
                else
                {
                    SummerRes.status = false;
                    SummerRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(SummerRes, settings);

                }

            }
            catch (Exception ex)
            {

                SummerRes.status = false;
                SummerRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(SummerRes, settings);

            }

            return Ok(json);
        }


        //API for get intrest arer for summer school
        [HttpGet]
        [Route("GetIntrestArea")]
        public IActionResult BindIntrest()
        {
            DataSet ds = new DataSet();
            string json = "";

            IntrestResponse StateRes = new IntrestResponse();
            List<IntrestDetail> objstate = new List<IntrestDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("bindintrestareaapi", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    StateRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        IntrestDetail objlist = new IntrestDetail();
                        objlist.intrestname = Convert.ToString(row["repositoryname"]);
                        objlist.intrestid= Convert.ToInt32(row["repositoryid"]);

                        objstate.Add(objlist);
                    }

                    StateRes.data = objstate;
                    StateRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(StateRes, settings);
                }
                else
                {
                    StateRes.status = false;
                    StateRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(StateRes, settings);

                }

            }
            catch (Exception ex)
            {

                StateRes.status = false;
                StateRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(StateRes, settings);

            }

            return Ok(json);
        }



        //API for save summer school data

        [AllowAnonymous]
        [HttpPost]
        [Route("SaveSummerSchoolData")]
        [Obsolete]
        public async Task<IActionResult> SaveSummerSchoolData([FromForm] SaveSummerSchoolDoc obj)
        {
            string json = "";
            string result = "";
            string guid = "";
            string pdffilename = "";
            string uploadDirectory = "";
            string qry = "";
            int maxid = 0;

            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            SummerSchoolAPIResponse objppfr = new SummerSchoolAPIResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();

            if (obj.studentid == 0 || obj.classid == 0 || obj.schoolname == "" || obj.univercity == "" || obj.location == "" || obj.description=="" || obj.fromdate =="" || obj.todate =="")
            {
                objppfr.status = false;
                objppfr.data = new SummerSchoolAPIData();
                objppfr.message = "Invalid Parameter";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(objppfr, settings);
            }  
            //else if(obj.Uploads == null)
            //{
            //    objppfr.status = false;
            //    objppfr.data = new SummerSchoolAPIData();
            //    objppfr.message = "Invalid File Format";


            //    settings.NullValueHandling = NullValueHandling.Ignore;
            //    json = JsonConvert.SerializeObject(objppfr, settings);
            //}
            else
            {
                try
                {
                    //save in parent table start
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("savesummerschoolapidata", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;

                    cmd.Parameters.AddWithValue("studentid_d", obj.studentid);
                    cmd.Parameters.AddWithValue("classid_d", obj.classid);
                    cmd.Parameters.AddWithValue("schoolname_d", obj.schoolname);

                    cmd.Parameters.AddWithValue("locatio_d", obj.location);
                    cmd.Parameters.AddWithValue("univercity_d", obj.univercity);
                    cmd.Parameters.AddWithValue("description_d", obj.description);
                    cmd.Parameters.AddWithValue("fromdate_d", Converter(obj.fromdate));

                    cmd.Parameters.AddWithValue("todate_d", Converter(obj.todate));

                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();

                    if (result == "Success")
                    {
                        try
                        {
                            qry = "SELECT MAX(schoolid) as school_id FROM tbl_savesummerschoolapi";
                            MySqlCommand cmd1 = new MySqlCommand(qry, con);

                            MySqlDataAdapter da1 = new MySqlDataAdapter();
                            da1.SelectCommand = cmd1;
                            da1.Fill(ds1);
                            con.Close();
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                maxid = Convert.ToInt32(ds1.Tables[0].Rows[0]["school_id"]);
                            }
                            else
                            {
                                maxid = 0;
                            }
                        }
                        catch (Exception e)
                        {

                        }

                        if (obj.Uploads != null)
                        {
                            foreach (IFormFile item in obj.Uploads)
                            {
                                guid = Guid.NewGuid().ToString();
                                pdffilename = guid + item.FileName;


                                Execqry("insert into tbl_summerschooldocdetail(schoolid,orgpdfname,newpdfname)values(" + maxid + ", '" + item.FileName + "','" + guid + "')");

                                string strdocPath = _hostingEnvironment.WebRootPath + "\\uploadsummerschool\\";
                                if (!Directory.Exists(strdocPath))
                                {
                                    System.IO.Directory.CreateDirectory(_hostingEnvironment.WebRootPath + "/uploadsummerschool");
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadsummerschool");

                                }
                                else
                                {
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadsummerschool");
                                }


                                var filePath = Path.Combine(uploadDirectory, pdffilename);

                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                {
                                    await item.CopyToAsync(fileStream);
                                }
                            }
                        }
                    }
                    objppfr.status = true;
                    objppfr.data = new SummerSchoolAPIData();
                    objppfr.message = "Saved Successfully";
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(objppfr, settings);
                }
                catch (Exception e)
                {
                    objppfr.status = true;
                    objppfr.data = new SummerSchoolAPIData();
                    objppfr.message = e.Message.ToString();


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(objppfr, settings);
                }
            }

            return Ok(json);
        }


        //API for get summer school data


        [HttpGet]
        [Route("GetSummerData")]
        public IActionResult GetSummerData([FromHeader] SummerData_Stu obj)
        {
            DataSet ds = new DataSet();
            string json = "";

            GetSummerResponse EcpRes = new GetSummerResponse();
            List<GetSummerDetail> objtrans = new List<GetSummerDetail>();
            if (obj.studentid == 0)
            {
                EcpRes.status = false;
                EcpRes.message = "Invalid StudentID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(EcpRes, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("BindSummerData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("studentid_d", obj.studentid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        EcpRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            GetSummerDetail objlist = new GetSummerDetail();
                            objlist.schoolid = Convert.ToInt32(row["schoolid"]);
                            objlist.classname = Convert.ToString(row["classname"]);
                            objlist.schoolname = Convert.ToString(row["schoolname"]);
                            objlist.fromdate = Convert.ToString(row["fromdate"]);
                            objlist.todate = Convert.ToString(row["todate"]);
                            objlist.location = Convert.ToString(row["location"]);
                            objlist.university = Convert.ToString(row["univercity"]);
                            objlist.descriptioin = Convert.ToString(row["description"]);

                            if (Convert.ToString(row["orgpdfname"]) == "" || Convert.ToString(row["orgpdfname"]) == null)
                            {
                                objlist.originalfilename = "N/A";
                            }
                            else
                            {
                                objlist.originalfilename = Convert.ToString(row["orgpdfname"]);
                            }




                            if (Convert.ToString(row["docname"]) == "N/A")
                            {
                                objlist.filename = Convert.ToString(row["docname"]);
                            }
                            else
                            {
                                objlist.filename = "http://apis.careerprabhu.com/" + "uploadsummerschool/" + Convert.ToString(row["docname"]);
                            }

                           


                            objtrans.Add(objlist);
                        }

                        EcpRes.data = objtrans;
                        EcpRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(EcpRes, settings);
                    }
                    else
                    {
                        EcpRes.status = false;
                        EcpRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(EcpRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    EcpRes.status = false;
                    EcpRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EcpRes, settings);

                }
            }


            return Ok(json);
        }

        //API for edit school data

        [HttpGet]
        [Route("EditSummerData")]
        public IActionResult EditSummerData([FromHeader] EditSummerData_Stu obj)
        {
            DataSet ds = new DataSet();
            string json = "";

            EditSummerResponse ECPEditRes = new EditSummerResponse();
            EditSummerDetail objedittrans = new EditSummerDetail();
            if (obj.schoolid == 0)
            {
                ECPEditRes.status = false;
                ECPEditRes.message = "Invalid SchoolID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(ECPEditRes, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("EditSummerData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("schoolid_d", obj.schoolid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        ECPEditRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            //EditECADetail objlist = new EditECADetail();
                            objedittrans.schoolid = Convert.ToInt32(row["schoolid"]);
                            objedittrans.classid = Convert.ToInt32(row["class_id"]);
                            objedittrans.classname = Convert.ToString(row["class_name"]);
                            objedittrans.fromdate = Convert.ToString(row["fromdate"]);

                            objedittrans.todate = Convert.ToString(row["todate"]);

                            objedittrans.schoolname = Convert.ToString(row["schoolname"]);
                            objedittrans.location = Convert.ToString(row["location"]);
                            objedittrans.description = Convert.ToString(row["description"]);
                            objedittrans.univercity = Convert.ToString(row["univercity"]);


                           // objedittrans.filename = "http://apis.careerprabhu.com/" + "uploadtranscript/" + Convert.ToString(row["docname"]);


                            //objedittrans.Add(objlist);
                        }

                        ECPEditRes.data = objedittrans;
                        ECPEditRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(ECPEditRes, settings);
                    }
                    else
                    {
                        ECPEditRes.status = false;
                        ECPEditRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(ECPEditRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    ECPEditRes.status = false;
                    ECPEditRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ECPEditRes, settings);

                }
            }


            return Ok(json);
        }

        //API for update school data
        [AllowAnonymous]
        [HttpPost]
        [Route("UpdateSummerData")]
        [Obsolete]
        public async Task<IActionResult> UpdateSummerData([FromForm] UpdateSummerDoc obj)
        {
            string json = "";
            string result = "";
            string guid = "";
            string pdffilename = "";
            string uploadDirectory = "";
            string qry = "";
            int maxid = 0;

            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            SummerUpdateResponse objppfr = new SummerUpdateResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();




            if (obj.studentid == 0 || obj.classid == 0 || obj.schoolname == "" || obj.univercity == "" || obj.location == "" || obj.description == "" || obj.fromdate == "" || obj.todate == "")
            {
                objppfr.status = false;
                objppfr.data = new SummerUpdateData();
                objppfr.message = "Invalid Parameter";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(objppfr, settings);
            }

            else
            {
                try
                {



                    //save in parent table start


                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("updatesummerschoolapidata", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("schoolid_d", obj.schoolid);
                    cmd.Parameters.AddWithValue("studentid_d", obj.studentid);
                    cmd.Parameters.AddWithValue("classid_d", obj.classid);
                    cmd.Parameters.AddWithValue("schoolname_d", obj.schoolname);

                    cmd.Parameters.AddWithValue("locatio_d", obj.location);
                    cmd.Parameters.AddWithValue("univercity_d", obj.univercity);
                    cmd.Parameters.AddWithValue("description_d", obj.description);
                    cmd.Parameters.AddWithValue("fromdate_d", Converter(obj.fromdate));

                    cmd.Parameters.AddWithValue("todate_d", Converter(obj.todate));




                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();

                    if (result == "Success")
                    {


                        if (obj.Uploads != null)
                        {
                            Execqry("delete from tbl_summerschooldocdetail where schoolid=" + obj.schoolid);
                            foreach (IFormFile item in obj.Uploads)
                            {
                                guid = Guid.NewGuid().ToString();
                                pdffilename = guid + item.FileName;


                                Execqry("insert into tbl_summerschooldocdetail(schoolid,orgpdfname,newpdfname)values(" + obj.schoolid + ", '" + item.FileName + "','" + guid + "')");

                                string strdocPath = _hostingEnvironment.WebRootPath + "\\uploadsummerschool\\";
                                if (!Directory.Exists(strdocPath))
                                {
                                    System.IO.Directory.CreateDirectory(_hostingEnvironment.WebRootPath + "/uploadsummerschool");
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadsummerschool");

                                }
                                else
                                {
                                    uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "uploadsummerschool");
                                }


                                var filePath = Path.Combine(uploadDirectory, pdffilename);

                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                {
                                    await item.CopyToAsync(fileStream);
                                }




                            }
                        }

                        objppfr.status = true;
                        objppfr.data = new SummerUpdateData();
                        objppfr.message = "Updated Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }
                    else
                    {
                        objppfr.status = true;
                        objppfr.data = new SummerUpdateData();
                        objppfr.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }


                }
                catch (Exception e)
                {
                    objppfr.status = true;
                    objppfr.data = new SummerUpdateData();
                    objppfr.message = e.Message.ToString();


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(objppfr, settings);
                }
            }

            return Ok(json);
        }

        //API for delete summer data
        [HttpGet]
        [Route("DeleteSummerData")]

        public IActionResult DeleteSummerData([FromHeader] DeleteSummerData data)
        {

            DeleteSummerResponse ecpres = new DeleteSummerResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";
            if (data.schoolid == 0)
            {
                ecpres.status = false;
                ecpres.message = "Invalid SchoolID";

                ecpres.data = new DeleteSummer();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(ecpres, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("DeleteSummerData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("schoolid_d", data.schoolid);

                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();


                    if (result == "Success")
                    {
                        ecpres.status = true;
                        ecpres.data = new DeleteSummer();
                        ecpres.message = "Deleted Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(ecpres, settings);
                    }
                    else
                    {
                        ecpres.status = false;
                        ecpres.data = new DeleteSummer();
                        ecpres.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(ecpres, settings);
                    }

                }
                catch (Exception e)
                {
                    ecpres.status = false;
                    ecpres.data = new DeleteSummer();
                    ecpres.message = e.Message;

                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ecpres, settings);

                }
            }

            return Ok(json);
        }


        //API for Ask Query starts here

        [HttpPost]
        [Route("AskQuery")]

        public IActionResult AskQuery([FromBody] SaveWriteQuery data)
        {

            WriteQueryResponse stures = new WriteQueryResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";





            if (data.studentquery == "" || data.studentid == 0 )
            {
                stures.status = false;
                stures.data = new WriteQueryData();
                stures.message = "Invalid Query And Student ID";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(stures, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("savewritequery", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    
                    cmd.Parameters.AddWithValue("Query_d", data.studentquery);
                    cmd.Parameters.AddWithValue("studentid_d", data.studentid);



                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();


                    if (result == "Success")
                    {
                        stures.status = true;
                        stures.data = new WriteQueryData();
                        stures.message = "Saved Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }
                    else
                    {
                        stures.status = false;
                        stures.data = new WriteQueryData();
                        stures.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }

                }
                catch (Exception e)
                {
                    stures.status = false;
                    stures.data = new WriteQueryData();
                    stures.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);

                }
            }

            return Ok(json);
        }

        //APi for ask query end here


        //API for get query ans



        [HttpGet]
        [Route("GetQueryAns")]
        public IActionResult GetQueryAns([FromHeader] Query_Stu obj)
        {
            DataSet ds = new DataSet();
            string json = "";

            GetQueryResponse EcpRes = new GetQueryResponse();
            List<GetQueryDetail> objtrans = new List<GetQueryDetail>();
            if (obj.studentid == 0)
            {
                EcpRes.status = false;
                EcpRes.message = "Invalid StudentID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(EcpRes, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("GetQueryAns", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("studentid_d", obj.studentid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        EcpRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            GetQueryDetail objlist = new GetQueryDetail();
                            objlist.studentid = Convert.ToInt32(row["stu_id"]);
                            objlist.queryid = Convert.ToInt32(row["Queryid"]);
                            objlist.query = Convert.ToString(row["Question"]);
                            objlist.ansquery = Convert.ToString(row["Counesellorans"]);



                            objtrans.Add(objlist);
                        }

                        EcpRes.data = objtrans;
                        EcpRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(EcpRes, settings);
                    }
                    else
                    {
                        EcpRes.status = false;
                        EcpRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(EcpRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    EcpRes.status = false;
                    EcpRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EcpRes, settings);

                }
            }


            return Ok(json);
        }






        //API for summer school ends here



        //API for webinar start here


        //API for Archive Webinar
        [HttpGet]
        [Route("GetArchiveWebinar")]
        public IActionResult GetArchiveWebinar([FromHeader] ArchiveWebinar_Stu obj)
        {
            DataSet ds = new DataSet();
            string json = "";
            ArchiveWebinarResponse ArchiveRes = new ArchiveWebinarResponse();
            List<ArchiveWebinarDetail> objarchive = new List<ArchiveWebinarDetail>();

            //if (obj.studentid == 0)
            //{
            //    ArchiveRes.status = false;
            //    ArchiveRes.message = "Invalid StudentID";

            //    JsonSerializerSettings settings = new JsonSerializerSettings();
            //    settings.NullValueHandling = NullValueHandling.Ignore;
            //    json = JsonConvert.SerializeObject(ArchiveRes, settings);
            //}
            //else
            //{

                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("ArchiveWebinar", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("stu_id", obj.studentid);
                    cmd.Parameters.AddWithValue("month_d", obj.month);
                    cmd.Parameters.AddWithValue("year_d", obj.year);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        ArchiveRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            ArchiveWebinarDetail ObjArchiveList = new ArchiveWebinarDetail();
                            ObjArchiveList.ArchiveVideo = Convert.ToString(row["OrgVideoName"]);
                            ObjArchiveList.Topic = Convert.ToString(row["topic"]);
                            ObjArchiveList.starttime = Convert.ToString(row["starttime"]);
                            ObjArchiveList.endtime = Convert.ToString(row["endtime"]);

                            ObjArchiveList.startdate = Convert.ToString(row["ondate"]);
                            ObjArchiveList.enddate = Convert.ToString(row["enddatetime"]);
                            ObjArchiveList.videoduration = Convert.ToString(row["timeduration"]);
                        ObjArchiveList.thumbnails = "http://admin.careerprabhu.com/" + "uploadimages/" + Convert.ToString(row["thumbnails"]);

                        objarchive.Add(ObjArchiveList);
                        }

                        ArchiveRes.data = objarchive;
                        ArchiveRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(ArchiveRes, settings);
                    }
                    else
                    {
                        ArchiveRes.status = false;
                        ArchiveRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(ArchiveRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    ArchiveRes.status = false;
                    ArchiveRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ArchiveRes, settings);

                }

           // }

            return Ok(json);
        }

        //API for future webinar
        [HttpGet]
        [Route("GetFutureWebinar")]
        public IActionResult GetFutureWebinar([FromHeader] FutureWebinar_Stu obj)

        {
            DataSet ds = new DataSet();
            string json = "";
            
            
            FutureWebinarResponse FutureRes = new FutureWebinarResponse();
            List<FutureWebinarDetail> objfuture = new List<FutureWebinarDetail>();
           

            //if (obj.studentid == 0)
            //{
            //    FutureRes.status = false;
            //    FutureRes.message = "Invalid StudentID";

            //    JsonSerializerSettings settings = new JsonSerializerSettings();
            //    settings.NullValueHandling = NullValueHandling.Ignore;
            //    json = JsonConvert.SerializeObject(FutureRes, settings);
            //}
            //else
            //{

                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("UpcomingWebinar", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("stu_id", obj.studentid); 
                    if(obj.fromdate == null || obj.fromdate == "")
                    {
                        cmd.Parameters.AddWithValue("fromdate_d", "0000/00/00");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("fromdate_d", Converter(obj.fromdate));
                    }
                cmd.Parameters.AddWithValue("month_d", obj.month.Substring(0, 2));
                cmd.Parameters.AddWithValue("year_d", obj.month.Substring(3,4));



                con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        FutureRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            FutureWebinarDetail ObjFutureList = new FutureWebinarDetail();
                           // ObjFutureList.FutureVideo = Convert.ToString(row["OrgVideoName"]);
                            ObjFutureList.Topic = Convert.ToString(row["topic"]);
                            ObjFutureList.starttime = Convert.ToString(row["starttime"]);
                            ObjFutureList.endtime = Convert.ToString(row["endtime"]);

                            ObjFutureList.startdate = Convert.ToString(row["ondate"]);
                            ObjFutureList.enddate = Convert.ToString(row["enddatetime"]);
                        ObjFutureList.thumbnails = "http://admin.careerprabhu.com/" + "uploadimages/" + Convert.ToString(row["thumbnails"]);

                        objfuture.Add(ObjFutureList);
                        }

                        FutureRes.data = objfuture;
                        FutureRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);
                    }
                    else
                    {
                        FutureRes.status = false;
                        FutureRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    FutureRes.status = false;
                    FutureRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(FutureRes, settings);

                }

            //}

            return Ok(json);
        }


        //API for get upcoming webinar
        [HttpGet]
        [Route("GetUpcomingWebinar")]
        public IActionResult GetUpcomingWebinar([FromHeader] FutureWebinar_Stu obj)

        {
            DataSet ds = new DataSet();
            string json = "";


            UpcomingWebinarResponse FutureRes = new UpcomingWebinarResponse();
            UpcomingWebinarDetail objfuture = new UpcomingWebinarDetail();


            //if (obj.studentid == 0)
            //{
            //    FutureRes.status = false;
            //    FutureRes.message = "Invalid StudentID";

            //    JsonSerializerSettings settings = new JsonSerializerSettings();
            //    settings.NullValueHandling = NullValueHandling.Ignore;
            //    json = JsonConvert.SerializeObject(FutureRes, settings);
            //}
            //else
            //{

                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("upcomingvideo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("stu_id", obj.studentid);
                  
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        FutureRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            //UpcomingWebinarDetail ObjFutureList = new UpcomingWebinarDetail();
                            objfuture.timing = Convert.ToString(row["duration"]);
                            


                            //objfuture.Add(ObjFutureList);
                        }

                        FutureRes.data = objfuture;
                        FutureRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);
                    }
                    else
                    {
                        FutureRes.status = false;
                        FutureRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    FutureRes.status = false;
                    FutureRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(FutureRes, settings);

                }

            //}

            return Ok(json);
        }


        //API for get live webinar
        [HttpGet]
        [Route("GetLiveWebinar")]
        public IActionResult GetLiveWebinar([FromHeader] LiveWebinar_Stu obj)
        {
            DataSet ds = new DataSet();
            string json = "";
            LiveWebinarResponse ArchiveRes = new LiveWebinarResponse();
            LiveWebinarDetail objarchive = new LiveWebinarDetail();
            List<CareerGenieDetail> objcareer = new List<CareerGenieDetail>();
            UpcomingwebinarDetail uwd = new UpcomingwebinarDetail();
            JsonSerializerSettings settings = new JsonSerializerSettings();

            //if (obj.studentid == 0)
            //{
            //    ArchiveRes.status = false;
            //    ArchiveRes.message = "Invalid StudentID";

               
            //    settings.NullValueHandling = NullValueHandling.Ignore;
            //    json = JsonConvert.SerializeObject(ArchiveRes, settings);
            //}
            //else
            //{

                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("LiveWebinar_test_updated", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("stu_id", obj.studentid);            
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();



                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        uwd.timing = Convert.ToString(ds.Tables[1].Rows[0]["duration"]);
                        ArchiveRes.isupcomingwebinar = 1;
                        ArchiveRes.upcomingwebinar = uwd;
                    ArchiveRes.testlink = "https://www.wonderskool.com/services/taketest_app?student_id=" + obj.studentid;

                    ArchiveRes.ispermission = Convert.ToInt32(ds.Tables[2].Rows[0]["ispermission"]);

                    ArchiveRes.paidstatus = Convert.ToInt32(ds.Tables[2].Rows[0]["paid"]);
                }
                    else
                    {
                        ArchiveRes.isupcomingwebinar = 0;
                        ArchiveRes.upcomingwebinar = new UpcomingwebinarDetail();
                   ArchiveRes.paidstatus = Convert.ToInt32(ds.Tables[2].Rows[0]["paid"]);
                    ArchiveRes.ispermission = Convert.ToInt32(ds.Tables[2].Rows[0]["ispermission"]);

                    ArchiveRes.testlink = "https://www.wonderskool.com/services/taketest_app?student_id=" + obj.studentid;

                }


                if (ds.Tables[0].Rows.Count > 0)
                    {

                            ArchiveRes.status = true;
                       
                        ArchiveRes.issubscriptionmessage = 0;
                    //ArchiveRes.testlink = "https://www.wonderskool.com/services/taketest_app?student_id=" + obj.studentid;


                    //ArchiveRes.paidstatus = Convert.ToInt32(ds.Tables[1].Rows[0]["paystatus"]);

                    ArchiveRes.subscriptionmessage = new List<CareerGenieDetail>();
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            //LiveWebinarDetail ObjArchiveList = new LiveWebinarDetail();

                            if(Convert.ToString(row["OrgVideoName"]).Contains("you") == true)
                            {
                                ArchiveRes.isvideoavailable = 0;
                                ArchiveRes.isyoutubevideoavailable = 1;
                                objarchive.livevideo = GetYouTubeId(Convert.ToString(row["orgvideoname"]));
                            objarchive.thumbnails = "http://admin.careerprabhu.com/" + "uploadimages/" + Convert.ToString(row["thumbnails"]);
                            }
                            else
                            {
                                ArchiveRes.isvideoavailable = 1;
                                ArchiveRes.isyoutubevideoavailable = 0;
                                objarchive.livevideo = Convert.ToString(row["OrgVideoName"]);
                            // objarchive.livechat = Convert.ToString(row["chatlink"]);

                            string _Message1 = Convert.ToString(row["chatlink_d"]);
                            string _Message = _Message1.Replace("@chatlink", Convert.ToString(row["chatlink"]));
                            objarchive.livechat = _Message;
                            



                            objarchive.thumbnails = "http://admin.careerprabhu.com/" + "uploadimages/" + Convert.ToString(row["thumbnails"]);
                            }

                         
                            objarchive.Topic = Convert.ToString(row["topic"]);
                            objarchive.starttime = Convert.ToString(row["starttime"]);
                            objarchive.endtime = Convert.ToString(row["endtime"]);

                            objarchive.startdate = Convert.ToString(row["ondate"]);
                            objarchive.enddate = Convert.ToString(row["enddatetime"]);
                            objarchive.videoduration = Convert.ToString(row["timeduration"]);

                           // objarchive.Add(ObjArchiveList);
                        }

                        ArchiveRes.livewebinar = objarchive;
                        ArchiveRes.message = "Success";
            
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(ArchiveRes, settings);
                    }
                    else
                    {
                        ArchiveRes.status = true;
                        ArchiveRes.isvideoavailable = 0;
                        ArchiveRes.isyoutubevideoavailable = 0;
                        ArchiveRes.livewebinar = new LiveWebinarDetail() ;
                        ArchiveRes.issubscriptionmessage = 1;
                    //ArchiveRes.paidstatus = Convert.ToInt32(ds.Tables[1].Rows[0]["paystatus"]);
                    MySqlConnection con1 = new SoftwareConnection(_iconfiguration).GetConnection();


                        MySqlCommand cmd1 = new MySqlCommand("GetCareerGenie", con);
                        cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("stu_id", obj.studentid);

                    con1.Open();
                        MySqlDataAdapter da1 = new MySqlDataAdapter();
                        da1.SelectCommand = cmd1;
                        da1.Fill(ds);
                        con1.Close();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                CareerGenieDetail ObjGenieList = new CareerGenieDetail();
                                ObjGenieList.careergeniemessage = Convert.ToString(row["Message"]);
                                ObjGenieList.messageid = Convert.ToInt32(row["subscriptionid"]);
                            ObjGenieList.notificationtype = Convert.ToInt32(row["notificationid"]);

                            objcareer.Add(ObjGenieList);
                            }

                            ArchiveRes.subscriptionmessage = objcareer;
                          
                         
                            settings.NullValueHandling = NullValueHandling.Ignore;
                            json = JsonConvert.SerializeObject(ArchiveRes, settings);
                        }



                     
                        ArchiveRes.message = "Success";

                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(ArchiveRes, settings);
                    }
                }
                catch (Exception ex)
                {
                    ArchiveRes.status = false;
                    ArchiveRes.message = ex.Message;
                
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ArchiveRes, settings);
                }
            //}
            return Ok(json);
        }




        [HttpGet]
        [Route("GetNotification")]
        public IActionResult GetNotification([FromHeader] CareerGenieNoti obj)
        {
            DataSet ds = new DataSet();
            string json = "";

            NotificationResponse EcpRes = new NotificationResponse();
            List<NotificationDetail> objtrans = new List<NotificationDetail>();

            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("GetCareerGenie", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("stu_id", obj.studentid);
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    EcpRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        NotificationDetail objlist = new NotificationDetail();
                        objlist.messageid = Convert.ToInt32(row["subscriptionid"]);
                        objlist.message = Convert.ToString(row["message"]);
                        


                        objtrans.Add(objlist);
                    }

                    EcpRes.data = objtrans;
                    EcpRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EcpRes, settings);
                }
                else
                {
                    EcpRes.status = false;
                    EcpRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EcpRes, settings);

                }

            }
            catch (Exception ex)
            {

                EcpRes.status = false;
                EcpRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(EcpRes, settings);

            }

            return Ok(json);
        }


        [HttpGet]
        [Route("GetNotificationDetail")]
        public IActionResult GetNotificationDetail([FromHeader] Notification_Stu obj)
        {
            DataSet ds = new DataSet();
            string json = "";

            NotificationDetailResponse EcpRes = new NotificationDetailResponse();
            NotificationDetail_stu objtrans = new NotificationDetail_stu();

            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("GetCareerGenieDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("notificationid", obj.notificationid);
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    EcpRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {

                        objtrans.message = Convert.ToString(row["description"]);
                 
                    }

                    EcpRes.data = objtrans;
                    EcpRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EcpRes, settings);
                }
                else
                {
                    EcpRes.status = false;
                    EcpRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EcpRes, settings);

                }

            }
            catch (Exception ex)
            {

                EcpRes.status = false;
                EcpRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(EcpRes, settings);

            }

            return Ok(json);
        }






        //API for get seek professional help
        [HttpGet]
        [Route("GetSeekProfessionalData")]
        public IActionResult GetSeekProfessionalData()
        {
            DataSet ds = new DataSet();
            string json = "";

            ProfessionalResponse EcpRes = new ProfessionalResponse();
            List<ProfessionalDetail> objtrans = new List<ProfessionalDetail>();
           
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("GetSoppropDataApi", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        EcpRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                        ProfessionalDetail objlist = new ProfessionalDetail();                         
                            objlist.testimonials = Convert.ToString(row["testimonials"]);
                        objlist.name = Convert.ToString(row["testimonialname"]);
                        objlist.image = "http://admin.careerprabhu.com/" + "SOP/" + Convert.ToString(row["filename"]);


                        objtrans.Add(objlist);
                        }

                        EcpRes.data = objtrans;
                        EcpRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(EcpRes, settings);
                    }
                    else
                    {
                        EcpRes.status = false;
                        EcpRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(EcpRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    EcpRes.status = false;
                    EcpRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EcpRes, settings);

                }
  
            return Ok(json);
        }

        //API for logout
        [AllowAnonymous]
        [HttpGet]
        [Route("Logout")]

        public IActionResult Logout([FromHeader] Logout_Stu data)
        {

            LogoutResponse stures = new LogoutResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";

            if ((data.studentid == 0 && data.principalid==0)  || data.IMEI == "")
            {
                stures.status = false;
                //stures.data = new LogoutDetail();
                stures.message = "Invalid Student ID or IMEI No.";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(stures, settings);
            }          
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("StudentLogout", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("studentid_d", data.studentid);
                    cmd.Parameters.AddWithValue("principalid_d", data.principalid);
                    cmd.Parameters.AddWithValue("imei_d", data.IMEI);
                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();


                    if (result == "Success")
                    {
                        stures.status = true;
                        //stures.data = new LogoutDetail();
                        stures.message = "Logout Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }
                    else
                    {
                        stures.status = false;
                        //stures.data = new LogoutDetail();
                        stures.message = "Something Went Wrong";
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }

                }
                catch (Exception e)
                {
                    stures.status = false;
                    //stures.data = new LogoutDetail();
                    stures.message = e.Message;
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);

                }
            }
            return Ok(json);
        }

        //API for privacy policy
        [HttpGet]
        [Route("DisplayPrivacyPolicy")]
        public IActionResult DisplayPrivacyPolicy()
        {
            DataSet ds = new DataSet();
            string json = "";

            PrivacyResponse EcpRes = new PrivacyResponse();
            PrivacyDetail objtrans = new PrivacyDetail();

            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("privacypolicy", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    EcpRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        objtrans.description = Convert.ToString(row["policy"]);                
                    }

                    EcpRes.data = objtrans;
                    EcpRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EcpRes, settings);
                }
                else
                {
                    EcpRes.status = false;
                    EcpRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EcpRes, settings);

                }

            }
            catch (Exception ex)
            {

                EcpRes.status = false;
                EcpRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(EcpRes, settings);

            }

            return Ok(json);
        }



        //API for webinar ends here

        //API for get student data for feedback
        [HttpGet]
        [Route("GetStudentDataFeedback")]
        public IActionResult GetStudentDataFeedback([FromHeader] Feedback_Stu obj)

        {
            DataSet ds = new DataSet();
            string json = "";
            StudentResponse FutureRes = new StudentResponse();
            StudentDetail objfuture = new StudentDetail();


            if (obj.studentid == 0)
            {
                FutureRes.status = false;
                FutureRes.message = "Invalid StudentID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(FutureRes, settings);
            }
            else
            {

                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("Bindfeedbackdata", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("studentid_d", obj.studentid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        FutureRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            //UpcomingWebinarDetail ObjFutureList = new UpcomingWebinarDetail();
                            objfuture.studentname = Convert.ToString(row["stu_name"]);
                            objfuture.mobileno = Convert.ToString(row["stu_mobile"]);
                            objfuture.email = Convert.ToString(row["stu_username"]);
                            objfuture.classid = Convert.ToInt32(row["stu_class"]);
                            objfuture.classname = Convert.ToString(row["class_name"]);
                            objfuture.streamid = Convert.ToInt32(row["stream_id"]);
                            objfuture.streamname = Convert.ToString(row["Stream_Name"]);

                            //objfuture.Add(ObjFutureList);
                        }

                        FutureRes.data = objfuture;
                        FutureRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);
                    }
                    else
                    {
                        FutureRes.status = false;
                        FutureRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    FutureRes.status = false;
                    FutureRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(FutureRes, settings);

                }

            }

            return Ok(json);
        }

        //API for save feedback
        [HttpPost]
        [Route("StudentFeedback")]
        [Obsolete]
        public IActionResult StudentFeedback([FromBody] FeedbackQuery data)
        {

            FeedbackResponse stures = new FeedbackResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();

            string json = "";
            string result = "";

            if (data.studentid==0 || data.feedback=="" || data.rating=="")
            {
                stures.status = false;
                stures.data = new FeedbackData();
                stures.message = "Invalid Parameter";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(stures, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("savefeedback", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("studentid_d", data.studentid);
                    cmd.Parameters.AddWithValue("feedback_d", data.feedback);
                    cmd.Parameters.AddWithValue("rating_d", data.rating);
                    con.Open();
                    cmd.ExecuteScalar();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();


                    if (result == "Success")
                    {
                        stures.status = true;
                        stures.data = new FeedbackData();
                        stures.message = "Thank you for your feedback. Concerned person will get back to you ! ";





                        try
                        {
                            MySqlCommand cmd1 = new MySqlCommand("GetFeedBack_career", con);
                            cmd1.CommandType = CommandType.StoredProcedure;

                            con.Open();
                            MySqlDataAdapter da1 = new MySqlDataAdapter();
                            da1.SelectCommand = cmd1;
                            da1.Fill(ds1);
                            con.Close();
                            string _Message = ds1.Tables[0].Rows[0]["careerfeedback"].ToString();
                          
                            if (ds.Tables[0].Rows[0]["stu_username"].ToString() != "")
                            {
                               
                                _Message = _Message.Replace("@candidatename", ds.Tables[0].Rows[0]["stu_name"].ToString());
                                _Message = _Message.Replace("@username", ds.Tables[0].Rows[0]["stu_username"].ToString());
                                _Message = _Message.Replace("@class", ds.Tables[0].Rows[0]["stu_class"].ToString());
                                _Message = _Message.Replace("@stream", ds.Tables[0].Rows[0]["stu_stream"].ToString());
                                _Message = _Message.Replace("@school", ds.Tables[0].Rows[0]["stu_school"].ToString());
                                _Message = _Message.Replace("@mobile", ds.Tables[0].Rows[0]["stu_mobile"].ToString());
                                _Message = _Message.Replace("@feedback", ds.Tables[0].Rows[0]["stu_feedback"].ToString());




                                SendFeedMail("CareerPrabhu Student Feedback", ds.Tables[0].Rows[0]["stu_username"].ToString(), "", _Message);

                            }
                        }
                        catch (Exception e)
                        {
                            string mmm = e.Message;
                        }











                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }
                    else
                    {
                        stures.status = false;
                        stures.data = new FeedbackData();
                        stures.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }

                }
                catch (Exception e)
                {
                    stures.status = false;
                    stures.data = new FeedbackData();
                    stures.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);

                }
            }

            return Ok(json);
        }


        [Obsolete]
        private void SendFeedMail(string _Subject, string _CC, string _BCC, string _Messages)
        {
            DataSet ds = new DataSet();
            string from = _CC;
            //string from = "sumantabag19@gmail.com";
            string Error = "";
            MailMessage mail = new MailMessage();
            mail.To.Add("contact.wonderskool@gmail.com");
            mail.From = new MailAddress(_CC, "CareerPrabhu", System.Text.Encoding.UTF8);
            mail.Subject = _Subject;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = _Messages;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            //client.Host = "124.247.226.44";
            //124.247.226.44,6434
            client.Host = "smtp.gmail.com";
            //client.Port = 25;
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("contact.wonderskool@gmail.com", "ws@edu@contact");
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Port = 587; // Gmail works on this port
                               //client.Port = 9025;
                               //  client.EnableSsl = true; //Gmail works on Server Secured Layer
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }

        }



        //API for count video
        [HttpGet]
        [Route("CountWebinarVideo")]
        public IActionResult CoundWebinarVideo([FromHeader] CountWebinar_Stu obj)

        {
            DataSet ds = new DataSet();
            string json = "";


            CountWebinarResponse FutureRes = new CountWebinarResponse();
            List<CountWebinarDetail> objfuture = new List<CountWebinarDetail>();


            //if (obj.studentid == 0)
            //{
            //    FutureRes.status = false;
            //    FutureRes.message = "Invalid StudentID";

            //    JsonSerializerSettings settings = new JsonSerializerSettings();
            //    settings.NullValueHandling = NullValueHandling.Ignore;
            //    json = JsonConvert.SerializeObject(FutureRes, settings);
            //}
            //else
            //{

                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("CountvideoWebinar", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("stu_id", obj.studentid);
                  
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        FutureRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            CountWebinarDetail ObjFutureList = new CountWebinarDetail();
                            ObjFutureList.date = Convert.ToString(row["ondate"]);
                            ObjFutureList.noofcount = Convert.ToString(row["noofevent"]);
                 


                            objfuture.Add(ObjFutureList);
                        }

                        FutureRes.data = objfuture;
                        FutureRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);
                    }
                    else
                    {
                        FutureRes.status = false;
                        FutureRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    FutureRes.status = false;
                    FutureRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(FutureRes, settings);

                }

            //}

            return Ok(json);
        }

        //API for 12 passout student save

        [HttpPost]
        [Route("PassoutStudent")]
        public IActionResult PassoutStudent([FromBody] passoutstudentdata data)
        {

            PassoutResponse stures = new PassoutResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";

            if (data.isdrop == 0 || data.isdrop ==1)
            {
                if(data.isdrop == 0)
                {
                    if (data.studentid == 0 || data.university == "" || data.college == "" || data.country == "" || data.state == "" || data.city == "" || data.course == "" || data.specialization == "")
                    {
                        stures.status = false;
                        // stures.data = new PassoutData();
                        stures.message = "Invalid Parameter";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }

                    else
                    {
                        try
                        {
                            MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                            MySqlCommand cmd = new MySqlCommand("PassoutStudent", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("message", "");
                            cmd.Parameters["message"].Direction = ParameterDirection.Output;
                            cmd.Parameters.AddWithValue("studentid_d", data.studentid);
                            cmd.Parameters.AddWithValue("isdrop_d", data.isdrop);
                            cmd.Parameters.AddWithValue("university_d", data.university);
                            cmd.Parameters.AddWithValue("college_d", data.college);
                            cmd.Parameters.AddWithValue("country_d", data.country);
                            cmd.Parameters.AddWithValue("state_d", data.state);
                            cmd.Parameters.AddWithValue("city_d", data.city);
                            cmd.Parameters.AddWithValue("course_d", data.course);
                            cmd.Parameters.AddWithValue("specialization_d", data.specialization);
                            con.Open();
                            cmd.ExecuteScalar();
                            result = cmd.Parameters["message"].Value.ToString();
                            con.Close();


                            if (result == "Success")
                            {
                                stures.status = true;
                                stures.data = new PassoutData();
                                stures.message = "Saved Successfully";


                                settings.NullValueHandling = NullValueHandling.Ignore;
                                json = JsonConvert.SerializeObject(stures, settings);
                            }
                            else
                            {
                                stures.status = false;
                                // stures.data = new PassoutData();
                                stures.message = "Something Went Wrong";


                                settings.NullValueHandling = NullValueHandling.Ignore;
                                json = JsonConvert.SerializeObject(stures, settings);
                            }

                        }
                        catch (Exception e)
                        {
                            stures.status = false;
                            //stures.data = new PassoutData();
                            stures.message = e.Message;


                            settings.NullValueHandling = NullValueHandling.Ignore;
                            json = JsonConvert.SerializeObject(stures, settings);

                        }
                    }


                }
                else
                {
                    try
                    {
                        MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                        MySqlCommand cmd = new MySqlCommand("PassoutStudent", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("message", "");
                        cmd.Parameters["message"].Direction = ParameterDirection.Output;
                        cmd.Parameters.AddWithValue("studentid_d", data.studentid);
                        cmd.Parameters.AddWithValue("isdrop_d", data.isdrop);
                        cmd.Parameters.AddWithValue("university_d", data.university);
                        cmd.Parameters.AddWithValue("college_d", data.college);
                        cmd.Parameters.AddWithValue("country_d", data.country);
                        cmd.Parameters.AddWithValue("state_d", data.state);
                        cmd.Parameters.AddWithValue("city_d", data.city);
                        cmd.Parameters.AddWithValue("course_d", data.course);
                        cmd.Parameters.AddWithValue("specialization_d", data.specialization);
                        con.Open();
                        cmd.ExecuteScalar();
                        result = cmd.Parameters["message"].Value.ToString();
                        con.Close();


                        if (result == "Success")
                        {
                            stures.status = true;
                            stures.data = new PassoutData();
                            stures.message = "Saved Successfully";


                            settings.NullValueHandling = NullValueHandling.Ignore;
                            json = JsonConvert.SerializeObject(stures, settings);
                        }
                        else
                        {
                            stures.status = false;
                            // stures.data = new PassoutData();
                            stures.message = "Something Went Wrong";


                            settings.NullValueHandling = NullValueHandling.Ignore;
                            json = JsonConvert.SerializeObject(stures, settings);
                        }

                    }
                    catch (Exception e)
                    {
                        stures.status = false;
                        //stures.data = new PassoutData();
                        stures.message = e.Message;


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);

                    }
                }

            }
            
            return Ok(json);
        }


        //API for forgot password
        [AllowAnonymous]
        [HttpPost]
        [Route("SendOTP")]
        [Obsolete]
        public IActionResult SendOTO([FromBody] SendOtp data)
        {

            PassoutResponse stures = new PassoutResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";

           
                    if (data.mobileno =="")
                    {
                        stures.status = false;
                        stures.message = "Invalid Parameter";
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }
              
            else
            {
                try
                {
                    Random generator = new Random();
                    String otp = generator.Next(100000, 1000000).ToString("D6");
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("saveotp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    //cmd.Parameters.AddWithValue("email_d", data.email);
                    cmd.Parameters.AddWithValue("mobile_d", data.mobileno);
                    cmd.Parameters.AddWithValue("otp_d", otp);
                   
                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();


                    if (result == "Success")
                    {
                        SendEmailMessageRegistration(data.mobileno,otp);
                        if (status == 0)
                        {
                            stures.status = false;
                            stures.message = "Incorretct Email Or Mobile No.";
                            settings.NullValueHandling = NullValueHandling.Ignore;
                            json = JsonConvert.SerializeObject(stures, settings);
                        }
                        else
                        {
                            stures.status = true;
                            stures.message = "Otp Sent To Registered Email Or Mobile No.";
                            settings.NullValueHandling = NullValueHandling.Ignore;
                            json = JsonConvert.SerializeObject(stures, settings);
                        }

                       

                    }
                    else
                    {
                        stures.status = false;
                        // stures.data = new PassoutData();
                        stures.message = "Account not registered with career prabhu";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }

                }
                catch (Exception e)
                {
                    stures.status = false;
                    //stures.data = new PassoutData();
                    stures.message = "Account not registered with career prabhu";


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);

                }
            }


            return Ok(json);
        }



        [Obsolete]
        private void SendMail1(string _Subject, string _CC, string _BCC, string _Messages)
        {
            DataSet ds = new DataSet();
            string from = "contact.wonderskool@gmail.com";
            //string from = "sumantabag19@gmail.com";
            string Error = "";
            MailMessage mail = new MailMessage();
            mail.To.Add(_CC);
            mail.From = new MailAddress(from, "Wonderskool", System.Text.Encoding.UTF8);
            mail.Subject = _Subject;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = _Messages;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            //client.Host = "124.247.226.44";
            //124.247.226.44,6434
            client.Host = "smtp.gmail.com";
            //client.Port = 25;
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("contact.wonderskool@gmail.com", "ws@edu@contact");
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Port = 587; // Gmail works on this port
                               //client.Port = 9025;
                               //  client.EnableSsl = true; //Gmail works on Server Secured Layer
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }

        }

        [Obsolete]
        private int SendEmailMessageRegistration(string mobileno, string otp)
        {
            
            emailsending objemail = new emailsending();

            if(mobileno.Contains("@") == true || mobileno.Contains(".") == true)
            {
                int email_d = Return_Int("select count(*) from tbl_studentportal where stu_username='" + mobileno + "'");

                if (email_d > 0)
                {
                    string msg = "Your one time authentication password is " + otp;
                    SendMail1("Reset Password", mobileno, "", msg);
                    //SendOtpSMS(mobileno, msg);
                    status = 1;
                }
                else
                {
                    status = 0;
                }
            }
            else
            {
                if (mobileno.Length == 10)
                {
                    int mobile_d = Return_Int("select count(*) from tbl_studentportal where stu_mobile='" + mobileno + "'");
                    if (mobile_d > 0)
                    {
                        string msg = "Your one time authentication password is " + otp;
                        // objemail.SendGMail(email, "One Time Authentication Password to Register at hitbullseye.com", msg);
                        SendOtpSMS(mobileno, msg);
                        status = 1;
                    }
                    else
                    {
                        status = 0;
                    }



                }
                else
                {
                    string msg = "Incorrect Mobile No.";
                    status = 0;
                }
            }
            //if(email=="" || email == null)
            //{
            //    if (mobileno.Length == 10)
            //    {
            //        int mobile_d = Return_Int("select count(*) from tbl_studentportal where stu_mobile='" + mobileno +"'");
            //        if (mobile_d > 0)
            //        {
            //            string msg = "Your one time authentication password is " + otp;
            //            // objemail.SendGMail(email, "One Time Authentication Password to Register at hitbullseye.com", msg);
            //            SendOtpSMS(mobileno, msg);
            //            status = 1;
            //        }
            //        else
            //        {
            //            status = 0;
            //        }



            //    }
            //    else
            //    {
            //        string msg = "Incorrect Mobile No.";
            //        status = 0;
            //    }
            //}
            //if(mobileno=="" || mobileno == null)
            //{
            //    if (email.Contains("@") == true)
            //    {


            //        int email_d = Return_Int("select count(*) from tbl_studentportal where stu_username='" + email + "'");

            //        if(email_d > 0)
            //        {
            //            string msg = "Your one time authentication password is " + otp;
            //            SendMail1("Reset Password", email, "", msg);
            //            //SendOtpSMS(mobileno, msg);
            //            status = 1;
            //        }
            //        else
            //        {
            //            status = 0;
            //        }



            //    }
            //    else
            //    {
            //        string msg = "Incorrect Email";
            //        status = 0;
            //    }
            //}

            //if (mobileno != "" && email != null && email.Contains("@") == true && mobileno.Length == 10)
            //{

            //    // objemail.SendGMail(email, "One Time Authentication Password to Register at hitbullseye.com", msg);


            //    int mobile_d = Return_Int("select count(*) from tbl_studentportal where stu_mobile='"+ mobileno + "'");
            //    int email_d = Return_Int("select count(*) from tbl_studentportal where stu_username='" + email + "'");

            //    if (mobile_d > 0)
            //    {
            //        string msg = "Your one time authentication password is " + otp;
            //        SendOtpSMS(mobileno, msg);
            //        status = 1;
            //    }
            //    else
            //    {
            //        status = 0;
            //    }
            //    if (email_d > 0)
            //    {
            //        string msg = "Your one time authentication password is " + otp;
            //        SendMail1("Reset Password", email, "", msg);
            //        status = 1;
            //    }
            //    else
            //    {
            //        status = 0;
            //    }




            //}
            //else
            //{
            //    string msg = "Incorrect Email Or Mobile No";
            //    status = 0;
            //}

            //    //if (email.Contains("@") == true && mobileno.Length == 10)
            //    //{

            //    //    string msg = "Your one time authentication password is " + otp;
            //    //    // objemail.SendGMail(email, "One Time Authentication Password to Register at hitbullseye.com", msg);
            //    //    SendOtpSMS(mobileno, msg);
            //    //    status = 1;

            //    //}
            return status;
        }


        public int Return_Int(string st)
        {
            MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
            int code = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand(st, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                dr.Read();
                if (dr[0] is DBNull)
                {
                }
                else
                {
                    code = Convert.ToInt32(dr[0]);
                }


            }
            dr.Close();
            con.Close();
            return (code);
        }


        private void SendOtpSMS(string mobileno, string msg)
        {
            try
            {
                string url = "";
                DataSet dsurl = new DataSet();
                emailsending email = new emailsending();
                msg = msg.Replace("&", "%26");
                msg = msg.Replace("+", "%2B");
                msg = msg.Replace("%", "%25");
                msg = msg.Replace("#", "%23");
                msg = msg.Replace("=", "%3D");
                msg = msg.Replace("^", "%5E");
                msg = msg.Replace("~", "%7E");
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                MySqlCommand cmd2 = new MySqlCommand("GetUrlSms", con);
                cmd2.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataAdapter da2 = new MySqlDataAdapter();
                da2.SelectCommand = cmd2;
                da2.Fill(dsurl);
                con.Close();
                if (dsurl.Tables.Count > 0)
                {
                    url = dsurl.Tables[0].Rows[0]["smsapiurl"].ToString();
                }
                else
                {
                    url = "";
                }


                // string url = clscon.Return_string("select smsapiurl from tbemailsms where formatid=1");
                url = url.Replace("@msg", msg);
                url = url.Replace("@mobile", mobileno);
                email.readHtmlPage(url);
            }
            catch { }
        }


        //match otp
        [AllowAnonymous]
        [HttpGet]
        [Route("MatchOTP")]
        public IActionResult MatchOTP([FromHeader] matchOTPSTu data)

        {
            DataSet ds = new DataSet();
            string json = "";
            string result = "";
            OtpMatchResponse FutureRes = new OtpMatchResponse();
    
            if ( data.mobileno == "")
            {
                FutureRes.status = false;
                FutureRes.message = "Invalid StudentID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(FutureRes, settings);
            }
            else
            {

                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("submitotp", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    //cmd.Parameters.AddWithValue("email_d", data.email);
                    cmd.Parameters.AddWithValue("mobile_d", data.mobileno);
                    cmd.Parameters.AddWithValue("otp_d", data.otp);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();


                    if (result == "1")
                    {
                        FutureRes.status = true;
                        FutureRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);
                    }
                    else
                    {
                        FutureRes.status = false;
                        FutureRes.message = "Wrong OTP Try Again";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    FutureRes.status = false;
                    FutureRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(FutureRes, settings);

                }

            }

            return Ok(json);
        }


        //Change password
        [HttpPost]
        [Route("ChangePassword")]
        public IActionResult UpdatePassword([FromBody] UpdateStuPassword data)
        {

            PassoutResponse stures = new PassoutResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";
            string passres = "";


            if (data.studentid == 0 || data.oldpassword == "" || data.newpassword=="")
            {
                stures.status = false;
                stures.message = "Invalid Parameter";
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(stures, settings);
            }

            else
            {
                try
                {
                    
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("matcholdpassword", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("studentid_d", data.studentid);
                    cmd.Parameters.AddWithValue("oldpassword_d", data.oldpassword);
                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                   // con.Close();


                    if (result == "1")
                    {
                        
                        MySqlCommand cmd1 = new MySqlCommand("updatepassword", con);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("message", "");
                        cmd1.Parameters["message"].Direction = ParameterDirection.Output;
                        cmd1.Parameters.AddWithValue("studentid_d", data.studentid);
                        cmd1.Parameters.AddWithValue("newpassword_d", data.newpassword);
                      
                        cmd1.ExecuteScalar();
                        passres = cmd1.Parameters["message"].Value.ToString();
                        con.Close();
                        if (passres == "Success")
                        {
                            stures.status = true;
                            stures.message = "Password Change Succesfully";
                            settings.NullValueHandling = NullValueHandling.Ignore;
                            json = JsonConvert.SerializeObject(stures, settings);
                        }
                        else
                        {
                            stures.status = false;
                            stures.message = "failed";
                            settings.NullValueHandling = NullValueHandling.Ignore;
                            json = JsonConvert.SerializeObject(stures, settings);
                        }


                    }
                    else
                    {
                        con.Close();
                        stures.status = false;
                        stures.message = "Wrong Old Password";
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }

                }
                catch (Exception e)
                {
                    stures.status = false;
                    //stures.data = new PassoutData();
                    stures.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);

                }
            }


            return Ok(json);
        }


        //Update Password
        [AllowAnonymous]
        [HttpPost]
        [Route("UpdatePassword")]
        public IActionResult ChnagePassword([FromBody] ForgotStuPassword data)
        {
            ChangeResponse stures = new ChangeResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";

            if (data.mobileno == "" || data.newpassword == "" || data.confirmpassword == "")
            {
                stures.status = false;
                stures.message = "Invalid Parameter";
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(stures, settings);
            }
            else if(data.newpassword != data.confirmpassword)
            {
                stures.status = false;
                stures.message = "Mismatch Password";
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(stures, settings);
            }

            else
            {
                try
                {

                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("changepasswordapi", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    //cmd.Parameters.AddWithValue("email_d", data.email);
                    cmd.Parameters.AddWithValue("mobileno_d", data.mobileno);
                    cmd.Parameters.AddWithValue("newpassword_d", data.newpassword);
                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                     con.Close();

                    if(result == "Success")
                    {
                        stures.status = true;
                        stures.message = "Password Changed Successfully";
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }
                    else
                    {
                        stures.status = false;
                        stures.message = "Faile";
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }


                  

                }
                catch (Exception e)
                {
                    stures.status = false;
                    //stures.data = new PassoutData();
                    stures.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);

                }
            }


            return Ok(json);
        }

        //API for month
        [HttpGet]
        [Route("GetMonth")]
        public IActionResult GetMonth()
        {
            DataSet ds = new DataSet();
            string json = "";

            MonthResponse StateRes = new MonthResponse();
            List<MonthDetail> objstate = new List<MonthDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("Bindmonth", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    StateRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        MonthDetail objlist = new MonthDetail();
                        objlist.month = Convert.ToString(row["monthname_d"]);
                        objlist.monthid = Convert.ToInt32(row["monthid"]);

                        objstate.Add(objlist);
                    }

                    StateRes.data = objstate;
                    StateRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(StateRes, settings);
                }
                else
                {
                    StateRes.status = false;
                    StateRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(StateRes, settings);

                }

            }
            catch (Exception ex)
            {

                StateRes.status = false;
                StateRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(StateRes, settings);

            }

            return Ok(json);
        }

        //API for year
        [HttpGet]
        [Route("GetYear")]
        public IActionResult GetYear()
        {
            DataSet ds = new DataSet();
            string json = "";

            YearResponse StateRes = new YearResponse();
            List<YearDetail> objstate = new List<YearDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("Bindyear", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    StateRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        YearDetail objlist = new YearDetail();
                        objlist.year = Convert.ToString(row["yearname"]);
                        objlist.yearid = Convert.ToInt32(row["yearid"]);

                        objstate.Add(objlist);
                    }

                    StateRes.data = objstate;
                    StateRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(StateRes, settings);
                }
                else
                {
                    StateRes.status = false;
                    StateRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(StateRes, settings);

                }

            }
            catch (Exception ex)
            {

                StateRes.status = false;
                StateRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(StateRes, settings);

            }

            return Ok(json);
        }


        //API for previous webinar
        [HttpGet]
        [Route("GetPreviousWebinar")]
        public IActionResult GetPreviousWebinar([FromHeader] PreviousWebinar_Stu obj)

        {
            DataSet ds = new DataSet();
            string json = "";


            PreviousWebinarResponse FutureRes = new PreviousWebinarResponse();
            PreviousWebinarDetail objfuture = new PreviousWebinarDetail();


            //if (obj.studentid == 0)
            //{
            //    FutureRes.status = false;
            //    FutureRes.message = "Invalid StudentID";

            //    JsonSerializerSettings settings = new JsonSerializerSettings();
            //    settings.NullValueHandling = NullValueHandling.Ignore;
            //    json = JsonConvert.SerializeObject(FutureRes, settings);
            //}
            //else
            //{

                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("previousvideo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("stu_id", obj.studentid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        FutureRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                       
                            objfuture.previousvideo = Convert.ToString(row["OrgVideoName"]);
                            objfuture.Topic = Convert.ToString(row["topic"]);
                            objfuture.starttime = Convert.ToString(row["starttime"]);
                            objfuture.endtime = Convert.ToString(row["endtime"]);
                            objfuture.videoduration = Convert.ToString(row["duration"]);
                            objfuture.startdate = Convert.ToString(row["ondate"]);
                            objfuture.enddate = Convert.ToString(row["enddatetime"]);

                        }

                        FutureRes.data = objfuture;
                        FutureRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);
                    }
                    else
                    {
                        FutureRes.status = false;
                        FutureRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    FutureRes.status = false;
                    FutureRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(FutureRes, settings);

                }

            //}

            return Ok(json);
        }


        //API get guideline
        [HttpGet]
        [Route("GetStudentGuideline")]
        public IActionResult Getguideline([FromHeader] GetGuide obj)
        {
            DataSet ds = new DataSet();
            string json = "";

            GuidelineAPIResponse StateRes = new GuidelineAPIResponse();
            GuidelineDetailAPI objstate = new GuidelineDetailAPI();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("Getguideline", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pageid_d", obj.pageid);

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    StateRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {

                        objstate.description = Convert.ToString(row["guideline"]);
                      

                  
                    }

                    StateRes.data = objstate;
                    StateRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(StateRes, settings);
                }
                else
                {
                    StateRes.status = false;
                    StateRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(StateRes, settings);

                }

            }
            catch (Exception ex)
            {

                StateRes.status = false;
                StateRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(StateRes, settings);

            }

            return Ok(json);
        }


        //API for student profile


        [HttpGet]
        [Route("GetProfileInfo")]
        public IActionResult GetProfileInfo([FromHeader] profile_Stu obj)

        {
            DataSet ds = new DataSet();
            string json = "";


            ProfileResponse FutureRes = new ProfileResponse();
            ProfileDetail objfuture = new ProfileDetail();


            if (obj.studentid == 0 && obj.principalid==0)
            {
                FutureRes.status = false;
                FutureRes.message = "Invalid ID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(FutureRes, settings);
            }
            else
            {

                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("GetStudentProfileData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("stu_id", obj.studentid);
                    cmd.Parameters.AddWithValue("prncipalid_id", obj.principalid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        FutureRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            if (obj.studentid == 0)
                            {
                                objfuture.id = Convert.ToInt32(row["principalid"]);
                                objfuture.name = Convert.ToString(row["principalname"]);
                                objfuture.email = Convert.ToString(row["email"]);
                                objfuture.mobileno = Convert.ToString(row["mobileno"]);
                                objfuture.stateid = Convert.ToInt32(row["state_id"]);
                                objfuture.state = Convert.ToString(row["state_name"]);
                                objfuture.cityid = Convert.ToInt32(row["city_id"]);
                                objfuture.city = Convert.ToString(row["city_name"]);
                                objfuture.schoolname = Convert.ToString(row["school_name"]);



                                if (Convert.ToString(row["profilephoto"]) == "")
                                {
                                    objfuture.profilephoto = "";
                                }
                                else
                                {
                                    objfuture.profilephoto = "http://apis.careerprabhu.com/" + "uploadcoachphoto/" + Convert.ToString(row["profilephoto"]);
                                }
                            
                                
                            }
                            else
                            {
                                objfuture.id = Convert.ToInt32(row["studentid"]);
                                objfuture.name = Convert.ToString(row["studentname"]);
                                objfuture.schoolname = Convert.ToString(row["schoolname"]);
                                objfuture.email = Convert.ToString(row["email"]);
                                objfuture.mobileno = Convert.ToString(row["mobileno"]);
                                objfuture.stateid = Convert.ToInt32(row["stateid"]);
                                objfuture.state = Convert.ToString(row["statename"]);
                                objfuture.cityid = Convert.ToInt32(row["cityid"]);
                                objfuture.city = Convert.ToString(row["cityname"]);

                                objfuture.classid = Convert.ToInt32(row["classid"]);
                                objfuture.classname = Convert.ToString(row["classname"]);
                                if(Convert.ToInt32(row["classid"]) > 3)
                                {
                                    objfuture.streamid = Convert.ToInt32(row["streamid"]);
                                    objfuture.streamname = Convert.ToString(row["streamname"]);
                                }
                                else
                                {
                                    objfuture.streamid = 0;
                                    objfuture.streamname ="";
                                }
                               
                                objfuture.languageid = Convert.ToInt32(row["languageid"]);
                                objfuture.language = Convert.ToString(row["languagetype"]);

                                if(Convert.ToString(row["profilephoto"]) == "")
                                {
                                    objfuture.profilephoto = "";
                                }
                                else
                                {
                                    objfuture.profilephoto = "http://apis.careerprabhu.com/" + "Profilephoto/" + Convert.ToString(row["profilephoto"]);
                                }

                                
                            }
                          
                        }

                        FutureRes.data = objfuture;
                        FutureRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);
                    }
                    else
                    {
                        FutureRes.status = false;
                        FutureRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    FutureRes.status = false;
                    FutureRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(FutureRes, settings);

                }

            }

            return Ok(json);
        }


        //API for update student detail


        //[AllowAnonymous]
        //[HttpPost]
        //[Route("UpdateProfileData")]
        //[Obsolete]
        //public async Task<IActionResult> UpdateProfileData([FromForm] UpdateStudentProfileData obj)
        //{
        //    string json = "";
        //    string result = "";
        //    string guid = "";
        //    string pdffilename = "";
        //    string uploadDirectory = "";
        //    string orgphotoname = "";
        //    string qry = "";
        //    int maxid = 0;
        //    DataSet ds = new DataSet();
        //    DataSet ds1 = new DataSet();
        //    ProfileUpdateResponse objppfr = new ProfileUpdateResponse();
        //    JsonSerializerSettings settings = new JsonSerializerSettings();
        //    if (obj.profilepic != null)
        //    {

        //        foreach (IFormFile item in obj.profilepic)
        //        {
        //            guid = Guid.NewGuid().ToString();
        //            orgphotoname = item.FileName;
        //            pdffilename = guid + item.FileName;
        //            string strdocPath = _hostingEnvironment.WebRootPath + "\\Profilephoto\\";
        //            if (!Directory.Exists(strdocPath))
        //            {
        //                System.IO.Directory.CreateDirectory(_hostingEnvironment.WebRootPath + "/Profilephoto");
        //                uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "Profilephoto");

        //            }
        //            else
        //            {
        //                uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "Profilephoto");
        //            }

        //            var filePath = Path.Combine(uploadDirectory, pdffilename);

        //            using (var fileStream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await item.CopyToAsync(fileStream);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        guid = "";
        //        pdffilename = "";
        //    }
        //    if (obj.studentid == 0)
        //    {
        //        if (obj.principalid == 0 || obj.principalname == "")
        //        {
        //            objppfr.status = false;
        //            objppfr.message = "Invalid Parameter";
        //            settings.NullValueHandling = NullValueHandling.Ignore;
        //            json = JsonConvert.SerializeObject(objppfr, settings);
        //        }
        //    }
        //    else if(obj.principalid == 0)
        //    {
        //        if (obj.studentid == 0 || obj.classid == 0 || obj.schoolname == "" || obj.studentname == "" || obj.streamid == 0 || obj.classid == 0 || obj.stateid == 0 || obj.cityid == 0)
        //        {
        //            objppfr.status = false;
        //            objppfr.message = "Invalid Parameter";
        //            settings.NullValueHandling = NullValueHandling.Ignore;
        //            json = JsonConvert.SerializeObject(objppfr, settings);
        //        }
        //    }

        //    else
        //    {
        //        try
        //        {
        //            MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
        //            MySqlCommand cmd = new MySqlCommand("UpdateProfileData", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("message", "");
        //            cmd.Parameters["message"].Direction = ParameterDirection.Output;
        //            cmd.Parameters.AddWithValue("studentid_d", obj.studentid);
        //            cmd.Parameters.AddWithValue("principalid_d", obj.principalid);
        //            cmd.Parameters.AddWithValue("studentname_d", obj.studentname);
        //            cmd.Parameters.AddWithValue("principalname_d", obj.principalname);
        //            cmd.Parameters.AddWithValue("schoolname_d", obj.schoolname);
        //            cmd.Parameters.AddWithValue("email_d", obj.email);
        //            cmd.Parameters.AddWithValue("mobileno_d", obj.mobileno);
        //            cmd.Parameters.AddWithValue("stateid_d", obj.stateid);
        //            cmd.Parameters.AddWithValue("cityid_d", obj.cityid);
        //            cmd.Parameters.AddWithValue("classid_d", obj.classid);
        //            cmd.Parameters.AddWithValue("streamid_d", obj.streamid);
        //            cmd.Parameters.AddWithValue("newphotoname_d", guid);
        //            cmd.Parameters.AddWithValue("orgphotoname_d", orgphotoname);
        //            con.Open();
        //            cmd.ExecuteScalar();
        //            result = cmd.Parameters["message"].Value.ToString();
        //            if (result == "Success")
        //            {
        //                objppfr.status = true;
        //                objppfr.message = "Updated Successfully";
        //                settings.NullValueHandling = NullValueHandling.Ignore;
        //                json = JsonConvert.SerializeObject(objppfr, settings);
        //            }
        //            else
        //            {
        //                objppfr.status = true;
        //                objppfr.message = "Failed To Update.";
        //                settings.NullValueHandling = NullValueHandling.Ignore;
        //                json = JsonConvert.SerializeObject(objppfr, settings);
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            objppfr.status = true;
        //            objppfr.message = e.Message.ToString();
        //            settings.NullValueHandling = NullValueHandling.Ignore;
        //            json = JsonConvert.SerializeObject(objppfr, settings);
        //        }
        //    }

        //    return Ok(json);
        //}




        [AllowAnonymous]
        [HttpPost]
        [Route("UpdateProfileData")]
        [Obsolete]
        public async Task<IActionResult> UpdateProfileData([FromForm] UpdateStudentProfileData obj)
        {
            string json = "";
            string result = "";
            string guid = "";
            string pdffilename = "";
            string uploadDirectory = "";
            string orgphotoname = "";
            string qry = "";
            int maxid = 0;
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            ProfileUpdateResponse objppfr = new ProfileUpdateResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            if (obj.profilepic != null)
            {

                foreach (IFormFile item in obj.profilepic)
                {
                    guid = Guid.NewGuid().ToString();
                    orgphotoname = item.FileName;
                    pdffilename = guid + item.FileName;
                    string strdocPath = _hostingEnvironment.WebRootPath + "\\Profilephoto\\";
                    if (!Directory.Exists(strdocPath))
                    {
                        System.IO.Directory.CreateDirectory(_hostingEnvironment.WebRootPath + "/Profilephoto");
                        uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "Profilephoto");

                    }
                    else
                    {
                        uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "Profilephoto");
                    }

                    var filePath = Path.Combine(uploadDirectory, pdffilename);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(fileStream);
                    }
                }
            }
            else
            {
                guid = "";
                pdffilename = "";
            }
         
                if (obj.studentid == 0 || obj.classid == 0 || obj.schoolname == "" || obj.studentname == "" || obj.stateid == 0 || obj.cityid == 0 || obj.languageid==0)
                {
                    objppfr.status = false;
                    objppfr.message = "Invalid Parameter";
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(objppfr, settings);
                }
            

            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("UpdateProfileData_New", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("studentid_d", obj.studentid);
                 
                    cmd.Parameters.AddWithValue("studentname_d", obj.studentname);
            
                    cmd.Parameters.AddWithValue("schoolname_d", obj.schoolname);
                    cmd.Parameters.AddWithValue("email_d", obj.email);
                    cmd.Parameters.AddWithValue("mobileno_d", obj.mobileno);
                    cmd.Parameters.AddWithValue("stateid_d", obj.stateid);
                    cmd.Parameters.AddWithValue("cityid_d", obj.cityid);
                    cmd.Parameters.AddWithValue("classid_d", obj.classid);
                    cmd.Parameters.AddWithValue("streamid_d", (obj.classid > 3 ? obj.streamid : 0));
                    cmd.Parameters.AddWithValue("languageid_d", obj.languageid);
                    cmd.Parameters.AddWithValue("newphotoname_d", guid);
                    cmd.Parameters.AddWithValue("orgphotoname_d", orgphotoname);
                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                    if (result == "Success")
                    {
                        objppfr.status = true;
                        objppfr.message = "Updated Successfully";
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }
                    else
                    {
                        objppfr.status = true;
                        objppfr.message = "Failed To Update.";
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objppfr, settings);
                    }
                }
                catch (Exception e)
                {
                    objppfr.status = true;
                    objppfr.message = e.Message.ToString();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(objppfr, settings);
                }
            }

            return Ok(json);
        }






        //Api for life coach section
        [HttpGet]
        [Route("GetCoachType")]
        public IActionResult GetCoachType()
        {
            DataSet ds = new DataSet();
            string json = "";

            CoachTypeResponse ClassRes = new CoachTypeResponse();
            List<CoachTypeDetail> objclass = new List<CoachTypeDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("BindTopic", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    ClassRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        CoachTypeDetail objlist = new CoachTypeDetail();
                        objlist.coachtype = Convert.ToString(row["topic"]);
                        objlist.coachtypeid = Convert.ToInt32(row["ID"]);

                        objclass.Add(objlist);
                    }

                    ClassRes.data = objclass;
                    ClassRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ClassRes, settings);
                }
                else
                {
                    ClassRes.status = false;
                    ClassRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ClassRes, settings);

                }

            }
            catch (Exception ex)
            {

                ClassRes.status = false;
                ClassRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(ClassRes, settings);

            }

            return Ok(json);
        }

        //API for get coach list according to coacch type
        [HttpGet]
        [Route("GetCoachList")]
        public IActionResult GetCoachList([FromHeader] LifeCoachList obj)

        {
            DataSet ds = new DataSet();
            string json = "";


            CoachResponse FutureRes = new CoachResponse();
            List<CoachDetail> objfuture = new List<CoachDetail>();


            if (obj.coachtypeid == 0)
            {
                FutureRes.status = false;
                FutureRes.message = "Invalid CoachTypeID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(FutureRes, settings);
            }
            else
            {

                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("BindCoachList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("coachtypeid_id", obj.coachtypeid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        FutureRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            CoachDetail objlist = new CoachDetail();
                            objlist.coachid = Convert.ToInt32(row["coachid"]);
                            objlist.coachname = Convert.ToString(row["coachname"]);
                            objlist.description = Convert.ToString(row["description"]);

                            objlist.profilephoto = "http://admin.careerprabhu.com/" + "uploadcoachphoto/" + Convert.ToString(row["profilepic"]);
                            objfuture.Add(objlist);
                        }

                        FutureRes.data = objfuture;
                        FutureRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);
                    }
                    else
                    {
                        FutureRes.status = false;
                        FutureRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    FutureRes.status = false;
                    FutureRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(FutureRes, settings);

                }

            }

            return Ok(json);
        }


        //API for life coach details
        [HttpGet]
        [Route("CoachDetails")]
        public IActionResult CoachDetails([FromHeader] CoachInfo data)

        {
            DataSet ds = new DataSet();
            string json = "";

            CoachInfoResponse Res = new CoachInfoResponse();
            CoachInfoDetail coachinfo = new CoachInfoDetail();

            List<CoachCareerDetail> coachcareer = new List<CoachCareerDetail>();
            List<CoachInterviewDetail> coachinterview = new List<CoachInterviewDetail>();

            List<CoachJourneyDetail> coachjourney = new List<CoachJourneyDetail>();
            List<CoachArticleDetail> coacharticle = new List<CoachArticleDetail>();

            if (data.coachid == 0)
            {
                Res.status = false;
                Res.message = "Invalid CoachID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(Res, settings);
            }
           
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("BindCoachInfo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("coachid_d", data.coachid);
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        Res.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {



                            coachinfo.coachname = Convert.ToString(row["coachname"]);
                            coachinfo.description = Convert.ToString(row["description"]);
                            coachinfo.fbid = Convert.ToString(row["fbid"]);
                            coachinfo.linkedinid = Convert.ToString(row["linkedin"]);
                            coachinfo.mobileno = Convert.ToString(row["mobileno"]);
                            coachinfo.email = Convert.ToString(row["email"]);
                            coachinfo.coachtype = Convert.ToString(row["coachtype"]);
                            if(Convert.ToString(row["profilepic"]) == "")
                            {
                                coachinfo.profilepic = "";
                            }
                            else
                            {
                                coachinfo.profilepic = "http://admin.careerprabhu.com/" + "uploadcoachphoto/" + Convert.ToString(row["profilepic"]);
                            }

                           



                            //coachinfo.Add(objcoachlist);
                        }
                        foreach (DataRow row1 in ds.Tables[1].Rows)
                        {

                            CoachCareerDetail objcareerlist = new CoachCareerDetail();

                            objcareerlist.career = Convert.ToString(row1["careername"]);

                            coachcareer.Add(objcareerlist);
                        }
                        foreach (DataRow row2 in ds.Tables[2].Rows)
                        {

                            CoachInterviewDetail objinterviewlist = new CoachInterviewDetail();

                            objinterviewlist.interviewtitle = Convert.ToString(row2["interviewtitle"]);
                            objinterviewlist.interviewsubtitle = Convert.ToString(row2["inteviewsubtitle"]);

                            if (Convert.ToString(row2["videolink"]) == "" || Convert.ToString(row2["videolink"]) == null)
                            {
                                objinterviewlist.videolink = "";
                            }
                            else
                            {
                                objinterviewlist.videolink = Convert.ToString(row2["videolink"]);
                            }


                            if (Convert.ToString(row2["interviewdoc"]) == "")
                            {
                                objinterviewlist.interviewdocument = "";
                            }
                            else
                            {
                                objinterviewlist.interviewdocument = "http://admin.careerprabhu.com/" + "lifecoachactivity/" + Convert.ToString(row2["interviewdoc"]);
                            }
                            
                            
                            coachinterview.Add(objinterviewlist);
                        }


                        foreach (DataRow row3 in ds.Tables[3].Rows)
                        {

                            CoachJourneyDetail objjourneylist = new CoachJourneyDetail();

                            objjourneylist.journeytitle = Convert.ToString(row3["interviewtitle"]);
                            objjourneylist.journeysubtitle = Convert.ToString(row3["inteviewsubtitle"]);

                            if (Convert.ToString(row3["videolink"]) == "" || Convert.ToString(row3["videolink"]) == null)
                            {
                                objjourneylist.videolink = "";
                            }
                            else
                            {
                                objjourneylist.videolink = Convert.ToString(row3["videolink"]);
                            }

                            if (Convert.ToString(row3["interviewdoc"]) == "")
                            {
                                objjourneylist.journeydocument = "";
                            }
                            else
                            {
                                objjourneylist.journeydocument = "http://admin.careerprabhu.com/" + "lifecoachactivity/" + Convert.ToString(row3["interviewdoc"]);
                            }
                           

                            coachjourney.Add(objjourneylist);
                        }
                        foreach (DataRow row4 in ds.Tables[4].Rows)
                        {

                            CoachArticleDetail objarticlelist = new CoachArticleDetail();

                            objarticlelist.articletitle = Convert.ToString(row4["interviewtitle"]);
                            objarticlelist.articlesubtitle = Convert.ToString(row4["inteviewsubtitle"]);

                            if (Convert.ToString(row4["videolink"]) == "" || Convert.ToString(row4["videolink"]) == null)
                            {
                                objarticlelist.videolink = "";
                            }
                            else
                            {
                                objarticlelist.videolink = Convert.ToString(row4["videolink"]);
                            }


                            if (Convert.ToString(row4["interviewdoc"]) == "")
                            {
                                objarticlelist.articledocument = "";
                            }
                            else
                            {
                                objarticlelist.articledocument = "http://admin.careerprabhu.com/" + "lifecoachactivity/" + Convert.ToString(row4["interviewdoc"]);
                            }

                            

                            coacharticle.Add(objarticlelist);
                        }





                        Res.coachinfo = coachinfo;
                        Res.careerinfo = coachcareer;
                        Res.coachinterviewinfo = coachinterview;
                        Res.coachjourneyinfo = coachjourney;
                        Res.coacharticleinfo = coacharticle;
                        Res.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(Res, settings);
                    }
                    else
                    {
                        Res.status = false;
                        Res.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(Res, settings);

                    }

                }
                catch (Exception ex)
                {

                    Res.status = false;
                    Res.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(Res, settings);

                }
            }

            return Ok(json);
        }


        [HttpGet]
        [Route("SearchRepositoryListing")]
        public IActionResult SearchRepositoryListing([FromHeader] RepositoryListVideoPDF obj)
        {
            DataSet ds = new DataSet();
            string json = "";

            RepositoryResponse ClassRes = new RepositoryResponse();
            List<RepositoryDetail> objclass = new List<RepositoryDetail>();

            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("SearchCareerListing_API", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("career_d", obj.career);
                cmd.Parameters.AddWithValue("languageid_d", obj.languageid);

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    ClassRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        RepositoryDetail objlist = new RepositoryDetail();
                        objlist.heading = Convert.ToString(row["heading"]);
                        objlist.listingid = Convert.ToInt32(row["listing_id"]);

                        if (Convert.ToString(row["feature_image"]) == "" || Convert.ToString(row["feature_image"]) == null)
                        {
                            objlist.listingimage = "";
                        }
                        else
                        {

                            objlist.listingimage = "https://www.wonderskool.com//" + "uploads//" + Convert.ToString(row["feature_image"]);
                        }
                        objlist.videolink = Convert.ToString(row["videourl"]);

                        objclass.Add(objlist);
                    }



                    ClassRes.data = objclass;

                    ClassRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ClassRes, settings);
                }
                else
                {
                    ClassRes.status = false;
                    ClassRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ClassRes, settings);

                }

            }
            catch (Exception ex)
            {

                ClassRes.status = false;
                ClassRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(ClassRes, settings);

            }



            return Ok(json);
        }






        //API for Career Repository
        [HttpGet]
        [Route("RepositoryListing")]
        public IActionResult RepositoryListing([FromHeader] RepositoryListVideoPDF obj)
        {
            DataSet ds = new DataSet();
            string json = "";

            RepositoryResponse ClassRes = new RepositoryResponse();
            List<RepositoryDetail> objclass = new List<RepositoryDetail>();
           
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("BindCareerListing_API", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("lim", obj.pageid);
                cmd.Parameters.AddWithValue("languageid_d", obj.languageid);

                con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        ClassRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            RepositoryDetail objlist = new RepositoryDetail();
                            objlist.heading = Convert.ToString(row["heading"]);
                            objlist.listingid = Convert.ToInt32(row["listing_id"]);

                            if (Convert.ToString(row["feature_image"]) == "" || Convert.ToString(row["feature_image"]) == null)
                            {
                                objlist.listingimage = "";
                            }
                            else
                            {

                                objlist.listingimage = "https://www.wonderskool.com//" + "uploads//" + Convert.ToString(row["feature_image"]);
                            }
                            objlist.videolink = Convert.ToString(row["videourl"]);

                            objclass.Add(objlist);
                        }

                      

                        ClassRes.data = objclass;
                       
                        ClassRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(ClassRes, settings);
                    }
                    else
                    {
                        ClassRes.status = false;
                        ClassRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(ClassRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    ClassRes.status = false;
                    ClassRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ClassRes, settings);

                }

            

            return Ok(json);
        }

        //API for repository details
        [HttpGet]
        [Route("RepositoryDetails")]
        public IActionResult RepositoryDetails([FromHeader] RepositoryList obj)

        {
            DataSet ds = new DataSet();
            string json = "";


            ListingResponse FutureRes = new ListingResponse();
            ListingDetail objfuture = new ListingDetail();


            if (obj.listingid == 0)
            {
                FutureRes.status = false;
                FutureRes.message = "Invalid ListingID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(FutureRes, settings);
            }
            else
            {

                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("ShowCarerDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("listingid_d", obj.listingid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        FutureRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {

                       
                            objfuture.description = Convert.ToString(row["description"]);

                            if(Convert.ToString(row["listing_pdf"]) == "" || Convert.ToString(row["listing_pdf"]) == null)
                            {
                                objfuture.listingpdf = "";
                            }
                            else
                            {
                            
                                objfuture.listingpdf = "https://www.wonderskool.com//" + "uploads//" + Convert.ToString(row["listing_pdf"]);
                            }

                            
                        }

                        FutureRes.data = objfuture;
                        FutureRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);
                    }
                    else
                    {
                        FutureRes.status = false;
                        FutureRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    FutureRes.status = false;
                    FutureRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(FutureRes, settings);

                }

            }

            return Ok(json);
        }


        //API for article
        [HttpGet]
        [Route("ArticleListing")]
        public IActionResult ArticleListing([FromHeader] RepositoryListVideoPDF obj)
        {
            DataSet ds = new DataSet();
            string json = "";

            ArticleResponse ClassRes = new ArticleResponse();
            List<ArticleDetail> objclass = new List<ArticleDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("ArticleListing_new", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("lim", obj.pageid);

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    ClassRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ArticleDetail objlist = new ArticleDetail();
                        objlist.heading = Convert.ToString(row["heading"]);
                        objlist.articleid = Convert.ToInt32(row["id"]);

                        if (Convert.ToString(row["feature_image"]) == "" || Convert.ToString(row["feature_image"]) == null)
                        {
                            objlist.articleimage = "";
                        }
                        else
                        {

                            objlist.articleimage = "https://www.wonderskool.com//" + "uploads//" + Convert.ToString(row["feature_image"]);
                        }


                        objclass.Add(objlist);
                    }

                    ClassRes.data = objclass;
                    ClassRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ClassRes, settings);
                }
                else
                {
                    ClassRes.status = false;
                    ClassRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ClassRes, settings);

                }

            }
            catch (Exception ex)
            {

                ClassRes.status = false;
                ClassRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(ClassRes, settings);

            }

            return Ok(json);
        }


        //API for get article listing details
        [HttpGet]
        [Route("ArticleDetails")]
        public IActionResult ArticleDetails([FromHeader] ArticleList obj)

        {
            DataSet ds = new DataSet();
            string json = "";


            BlogResponse FutureRes = new BlogResponse();
            BlogDetail objfuture = new BlogDetail();


            if (obj.articleid == 0)
            {
                FutureRes.status = false;
                FutureRes.message = "Invalid ArticleID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(FutureRes, settings);
            }
            else
            {

                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("ShowArticleDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("articleid_d", obj.articleid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        FutureRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {


                            objfuture.description = Convert.ToString(row["description"]);



                        }

                        FutureRes.data = objfuture;
                        FutureRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);
                    }
                    else
                    {
                        FutureRes.status = false;
                        FutureRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    FutureRes.status = false;
                    FutureRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(FutureRes, settings);

                }

            }

            return Ok(json);
        }


        //API for placement start
        [HttpGet]
        [Route("GetAcademicYear")]
        public IActionResult GetAcademicYear()
        {
            DataSet ds = new DataSet();
            string json = "";

            AcademicResponse ClassRes = new AcademicResponse();
            List<AcademicDetail> objclass = new List<AcademicDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();

                MySqlCommand cmd = new MySqlCommand("BindAcademicYear", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    ClassRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        AcademicDetail objlist = new AcademicDetail();
                        objlist.academicyear = Convert.ToString(row["academicyear"]);
                        objlist.academicid = Convert.ToInt32(row["academicid"]);
                        objclass.Add(objlist);
                    }

                    ClassRes.data = objclass;
                    ClassRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ClassRes, settings);
                }
                else
                {
                    ClassRes.status = false;
                    ClassRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ClassRes, settings);

                }

            }
            catch (Exception ex)
            {

                ClassRes.status = false;
                ClassRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(ClassRes, settings);

            }

            return Ok(json);
        }

        //API for save student record
        [HttpPost]
        [Route("SavePlacementRecord")]
        public IActionResult PlacmentRecord([FromBody] SavePlacementRecord data)
        {

            SavePlacementResponse stures = new SavePlacementResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";
            if (data.studentid == 0 || data.studentname == "" || data.fathername == "" || data.mobileno == ""  || data.stateid == 0 || data.cityid == 0 || data.univercity == "" || data.college == "" || data.course == "" || data.specialization == "" || data.academicyear == "" || data.isdrop == 0)
            {
                stures.status = false;

                stures.message = "Invalid Parameter";
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(stures, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("saveplacementrecord", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("studentid_d", data.studentid);
                    cmd.Parameters.AddWithValue("studentname_d", data.studentname);
                    cmd.Parameters.AddWithValue("fathername_d", data.fathername);
                    cmd.Parameters.AddWithValue("mobile_d", data.mobileno);

                    cmd.Parameters.AddWithValue("stateid_d", data.stateid);
                    cmd.Parameters.AddWithValue("cityid_d", data.cityid);
                    cmd.Parameters.AddWithValue("univercity_d", data.univercity);
                    cmd.Parameters.AddWithValue("college_d", data.college);
                    cmd.Parameters.AddWithValue("course_d", data.course);
                    cmd.Parameters.AddWithValue("specialization_d", data.specialization);
                    cmd.Parameters.AddWithValue("drop_d", data.isdrop);
                    cmd.Parameters.AddWithValue("academicyear_d", data.academicyear);

                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();


                    if (result == "Success")
                    {
                        stures.status = true;
                        stures.message = "Saved Successfully";
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }
                    else
                    {
                        stures.status = false;

                        stures.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }

                }
                catch (Exception e)
                {
                    stures.status = false;

                    stures.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);

                }
            }

            return Ok(json);
        }


        //API for get placement data
        [HttpGet]
        [Route("GetPlacementRecord")]
        public IActionResult GetPlacementRecord([FromHeader] GetPlacementRecord data)

        {
            DataSet ds = new DataSet();
            string json = "";

            DisplayPlacementResponse SOPRes = new DisplayPlacementResponse();
            List<DisplayPlacementDetail> objsop = new List<DisplayPlacementDetail>();
            if (data.studentid == 0)
            {
                SOPRes.status = false;
                SOPRes.message = "Invalid Parameter";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(SOPRes, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("BindPlacementRecord", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("studentid_d", data.studentid);


                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        SOPRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            DisplayPlacementDetail ObjSopList = new DisplayPlacementDetail();
                            ObjSopList.placementid = Convert.ToInt32(row["placementid"]);
                            ObjSopList.studentname = Convert.ToString(row["studentname"]);
                            ObjSopList.fathername = Convert.ToString(row["fathername"]);
                            ObjSopList.univercity = Convert.ToString(row["univercity"]);
                            ObjSopList.college = Convert.ToString(row["college"]);
                            ObjSopList.course = Convert.ToString(row["course"]);
                            ObjSopList.specialization = Convert.ToString(row["specialization"]);
                            ObjSopList.academicyear = Convert.ToString(row["academicyear"]);
                            ObjSopList.isdrop = Convert.ToString(row["isdrop"]);
                            ObjSopList.statename = Convert.ToString(row["state_name"]);
                            ObjSopList.cityname = Convert.ToString(row["city_name"]);

                            objsop.Add(ObjSopList);
                        }

                        SOPRes.data = objsop;
                        SOPRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(SOPRes, settings);
                    }
                    else
                    {
                        SOPRes.status = false;
                        SOPRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(SOPRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    SOPRes.status = false;
                    SOPRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(SOPRes, settings);

                }
            }

            

            return Ok(json);
        }


       

        //API for edit placement record
        [HttpGet]
        [Route("EditPlacementData")]
        public IActionResult EditPlacementData([FromHeader] EditPlacemtData data)

        {
            DataSet ds = new DataSet();
            string json = "";

            EditPlacementResponse SopRes = new EditPlacementResponse();
            EditPlacementDetail objessay = new EditPlacementDetail();
            if(data.placementid == 0)
            {
                SopRes.status = false;
                SopRes.message = "Invalid Parameter";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(SopRes, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("EditPlacementRecord", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("placementid_d", data.placementid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables.Count > 0)
                    {

                        SopRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            //EditWriteSopDetail ObjEssayList = new EditWriteSopDetail();
                            objessay.placementid = Convert.ToInt32(row["placementid"]);
                            objessay.studentname = Convert.ToString(row["studentname"]);
                            objessay.fathername = Convert.ToString(row["fathername"]);
                            objessay.mobileno = Convert.ToString(row["mobileno"]);
                            objessay.stateid = Convert.ToInt32(row["stateid"]);
                            objessay.statename = Convert.ToString(row["state_name"]);
                            objessay.cityid = Convert.ToInt32(row["cityid"]);
                            objessay.cityname = Convert.ToString(row["city_name"]);
                            objessay.univercity = Convert.ToString(row["univercity"]);
                            objessay.college = Convert.ToString(row["college"]);
                            objessay.course = Convert.ToString(row["course"]);
                            objessay.specialization = Convert.ToString(row["specialization"]);
                            objessay.academicyear = Convert.ToString(row["academicyear"]);
                            objessay.isdrop = Convert.ToInt32(row["isdrop"]);


                            // objessay.Add(ObjEssayList);
                        }

                        SopRes.data = objessay;
                        SopRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(SopRes, settings);
                    }
                    else
                    {
                        SopRes.status = false;
                        SopRes.message = "Something went wrong";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(SopRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    SopRes.status = false;
                    SopRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(SopRes, settings);

                }
            }

            

            return Ok(json);
        }


        //API for update placement record
        [HttpPost]
        [Route("UpdatePlacementRecord")]
        public IActionResult UpdatePlacementRecord([FromBody] UpdatePlacementRecord data)
        {

            UpdatePlacementResponse stures = new UpdatePlacementResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";
            if (data.placementid==0 || data.studentid == 0 || data.studentname == "" || data.fathername == "" || data.mobileno == "" || data.stateid == 0 || data.cityid == 0 || data.univercity == "" || data.college == "" || data.course == "" || data.specialization == "" || data.academicyear == "" || data.isdrop == 0)
            {
                stures.status = false;

                stures.message = "Invalid Parameter";
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(stures, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("updateplacementrecord", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("placementid_d", data.placementid);
                    cmd.Parameters.AddWithValue("studentid_d", data.studentid);
                    cmd.Parameters.AddWithValue("studentname_d", data.studentname);
                    cmd.Parameters.AddWithValue("fathername_d", data.fathername);
                    cmd.Parameters.AddWithValue("mobile_d", data.mobileno);

                    cmd.Parameters.AddWithValue("stateid_d", data.stateid);
                    cmd.Parameters.AddWithValue("cityid_d", data.cityid);
                    cmd.Parameters.AddWithValue("univercity_d", data.univercity);
                    cmd.Parameters.AddWithValue("college_d", data.college);
                    cmd.Parameters.AddWithValue("course_d", data.course);
                    cmd.Parameters.AddWithValue("specialization_d", data.specialization);
                    cmd.Parameters.AddWithValue("drop_d", data.isdrop);
                    cmd.Parameters.AddWithValue("academicyear_d", data.academicyear);

                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();


                    if (result == "Success")
                    {
                        stures.status = true;
                        stures.message = "Updated Successfully";
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }
                    else
                    {
                        stures.status = false;

                        stures.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }

                }
                catch (Exception e)
                {
                    stures.status = false;

                    stures.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);

                }
            }

            return Ok(json);
        }


        //API for delete placement record
        [HttpGet]
        [Route("DeletePlacementRecord")]

        public IActionResult DeletePlacementRecord([FromHeader] DeletePlacement data)
        {

            DeletePlacementResponse stures = new DeletePlacementResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";
            if(data.placementid == 0)
            {
                stures.status = false;
            
                stures.message = "Invalid Parameter";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(stures, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("DeletePlacementData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("placementid_d", data.placementid);

                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();


                    if (result == "Success")
                    {
                        stures.status = true;

                        stures.message = "Deleted Successfully";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }
                    else
                    {
                        stures.status = false;
                        
                        stures.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }

                }
                catch (Exception e)
                {
                    stures.status = false;
                    
                    stures.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);

                }
            }

           


            return Ok(json);
        }


        //API for competation starts here
        [HttpGet]
        [Route("GetScholarship")]
        public IActionResult GetScholarship([FromHeader] ScholarshipList obj)
        {
            DataSet ds = new DataSet();
            string json = "";
            ScholarshipResponse FutureRes = new ScholarshipResponse();
            List<ScholarshipDetail> objfuture = new List<ScholarshipDetail>();
          
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("GetCompetationScholarchip_new", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("year_d", obj.year);
                    cmd.Parameters.AddWithValue("month_d", obj.month);
                cmd.Parameters.AddWithValue("classid_d", obj.classid);
                cmd.Parameters.AddWithValue("stream_d", obj.streamname == null ? "" : obj.streamname);
                cmd.Parameters.AddWithValue("lim", obj.pageid);
                con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        FutureRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                        ScholarshipDetail objlist = new ScholarshipDetail();
                        objlist.topic = Convert.ToString(row["heading"]);
                        objlist.description = Convert.ToString(row["description"]);
                        objlist.date = Convert.ToString(row["createdon"]);
                        objlist.url = Convert.ToString(row["urllink"]);
                        objfuture.Add(objlist);
                        }

                        FutureRes.data = objfuture;
                        FutureRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);
                    }
                    else
                    {
                        FutureRes.status = false;
                        FutureRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);
                    }
                }
                catch (Exception ex)
                {
                    FutureRes.status = false;
                    FutureRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(FutureRes, settings);
                }
            
            return Ok(json);
        }


        //API for entrance exam
        [HttpGet]
        [Route("GetEntranceExamDetail")]
        public IActionResult GetEntranceExamDetail([FromHeader] EntranceList obj)
        {
            DataSet ds = new DataSet();
            string json = "";
            EntranceResponse FutureRes = new EntranceResponse();
            List<EntranceDetail > objfuture = new List<EntranceDetail>();
          
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("GetEntranceDataApi_New_update1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("year_d", obj.year);
                    cmd.Parameters.AddWithValue("month_d", obj.month);
                cmd.Parameters.AddWithValue("classid_d", obj.classid);
                cmd.Parameters.AddWithValue("stream_d", obj.streamname ==null? "": obj.streamname);
                cmd.Parameters.AddWithValue("lim", obj.pageid);
                con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        FutureRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                        EntranceDetail objlist = new EntranceDetail();
                        objlist.examname = Convert.ToString(row["examname"]);
                            objlist.date = Convert.ToString(row["startdate"]);
                        objlist.description = Convert.ToString(row["description"]);
                        objlist.image = "https://www.wonderskool.com/" + "Uploads/" + Convert.ToString(row["image"]);
                        objlist.url = Convert.ToString(row["urllink"]);

                        objfuture.Add(objlist);
                        }

                        FutureRes.data = objfuture;
                        FutureRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);
                    }
                    else
                    {
                        FutureRes.status = false;
                        FutureRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);
                    }
                }
                catch (Exception ex)
                {
                    FutureRes.status = false;
                    FutureRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(FutureRes, settings);
                }
            
            return Ok(json);
        }



        //APIS for filter placement record
        [HttpGet]
        [Route("PlacementDetails")]
        public IActionResult PlacementDetails([FromHeader] PlacementList obj)
        {
            DataSet ds = new DataSet();
            string json = "";
            PlacementDatailsResponse FutureRes = new PlacementDatailsResponse();
            List<PlacemetDetail> objfuture = new List<PlacemetDetail>();


            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                MySqlCommand cmd = new MySqlCommand("getplacementdataapis", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("academicyear_d", (obj.academicyear == null ? "": obj.academicyear));
                cmd.Parameters.AddWithValue("streamid_d", obj.streamid);
                
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    FutureRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        PlacemetDetail objlist = new PlacemetDetail();
                        objlist.stream = Convert.ToString(row["streamname"]);
                        objlist.studentname = Convert.ToString(row["studentname"]);
                        objlist.fathername = Convert.ToString(row["fathername"]);
                        objlist.university = Convert.ToString(row["university"]);
                        objlist.college = Convert.ToString(row["college"]);

                        objfuture.Add(objlist);
                    }

                    FutureRes.data = objfuture;
                    FutureRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(FutureRes, settings);
                }
                else
                {
                    FutureRes.status = false;
                    FutureRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(FutureRes, settings);
                }
            }
            catch (Exception ex)
            {
                FutureRes.status = false;
                FutureRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(FutureRes, settings);
            }

            return Ok(json);
        }

        //Generate CV

        //[HttpGet]
        //[Route("GenerateCV")]
        //[Obsolete]
        //public IActionResult GenerateCV([FromHeader] cvstudent obj)
        //{
        //    DataSet ds = new DataSet();
        //    string json = "";
        //    string res = "";
        //    string document = "";
        //    CVResponse FutureRes = new CVResponse();
        //    List<StudentCVDetail> objfuture = new List<StudentCVDetail>();
        //    List<TranscriptCVDetail> objtrans = new List<TranscriptCVDetail>();
        //    List<ECACVDetail> objteca = new List<ECACVDetail>();
        //    List<ECPCVDetail> objtecp = new List<ECPCVDetail>();
        //    List<SocialCVDetail> objsoc = new List<SocialCVDetail>();
        //    List<WorkCVDetail> objwork = new List<WorkCVDetail>();
        //    List<SchoolCVDetail> objschool = new List<SchoolCVDetail>();
        //    GenerateCVDetail objcv = new GenerateCVDetail();
        //    if (obj.studentid == 0)
        //    {

        //        objcv.status = false;
        //        objcv.message = "Invalid StudentID";

        //        JsonSerializerSettings settings = new JsonSerializerSettings();
        //        settings.NullValueHandling = NullValueHandling.Ignore;
        //        json = JsonConvert.SerializeObject(objcv, settings);
        //    }
        //    else
        //    {
        //        try
        //        {
        //            MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
        //            MySqlCommand cmd = new MySqlCommand("StudentCVDetails", con);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.Parameters.AddWithValue("stu_id", obj.studentid);

        //            con.Open();
        //            MySqlDataAdapter da = new MySqlDataAdapter();
        //            da.SelectCommand = cmd;
        //            da.Fill(ds);
        //            con.Close();
        //            if (ds.Tables[0].Rows.Count > 0)
        //            {

        //                objcv.status = true;
        //                foreach (DataRow row in ds.Tables[0].Rows)
        //                {

        //                    StudentCVDetail objstu = new StudentCVDetail();

        //                    objstu.studentname = Convert.ToString(row["stu_name"]);
        //                    objstu.email = Convert.ToString(row["stu_username"]);
        //                    objstu.mobileno = Convert.ToString(row["stu_mobile"]);
        //                    objstu.academicyear = Convert.ToString(row["academicyear"]) == null?"": Convert.ToString(row["academicyear"]);
        //                    objstu.statename = Convert.ToString(row["state_name"]);
        //                    objstu.cityname = Convert.ToString(row["city_name"]);
        //                    objstu.schoolname = Convert.ToString(row["school_name"]);
        //                    objstu.classname = Convert.ToString(row["class_name"]);
        //                    objstu.streamname = Convert.ToString(row["stream_name"]);


        //                    objfuture.Add(objstu);
        //                }
        //                foreach (DataRow row1 in ds.Tables[1].Rows)
        //                {

        //                    TranscriptCVDetail objcareerlist = new TranscriptCVDetail();

        //                    objcareerlist.schoolname = Convert.ToString(row1["schoolname"]);
        //                    objcareerlist.grade = Convert.ToString(row1["avggrade"]);
        //                    objcareerlist.schoolname = Convert.ToString(row1["avgper"]);
        //                    objcareerlist.statename = Convert.ToString(row1["state_name"]);
        //                    objcareerlist.cityname = Convert.ToString(row1["city_name"]);

        //                    objtrans.Add(objcareerlist);
        //                }
        //                foreach (DataRow row2 in ds.Tables[2].Rows)
        //                {

        //                    ECACVDetail objinterviewlist = new ECACVDetail();

        //                    objinterviewlist.activityname = Convert.ToString(row2["activityname"]);
        //                    objinterviewlist.level = Convert.ToString(row2["levelname"]);
        //                    objinterviewlist.fromdate = Convert.ToString(row2["fromdate"]);
        //                    objinterviewlist.todate = Convert.ToString(row2["todate"]);
        //                    objinterviewlist.achievement = Convert.ToString(row2["achievement"]);
        //                    objinterviewlist.learning = Convert.ToString(row2["learning"]);
        //                    objinterviewlist.classname = Convert.ToString(row2["class_name"]);


        //                    objteca.Add(objinterviewlist);
        //                }


        //                foreach (DataRow row3 in ds.Tables[3].Rows)
        //                {

        //                    ECPCVDetail objjourneylist = new ECPCVDetail();

        //                    objjourneylist.topic = Convert.ToString(row3["topic"]);
        //                    objjourneylist.fromdate = Convert.ToString(row3["fromdate"]);
        //                    objjourneylist.todate = Convert.ToString(row3["todate"]);
        //                    objjourneylist.certificatefrom = Convert.ToString(row3["certificatefrom"]);
        //                    objjourneylist.desccription = Convert.ToString(row3["description"]);
        //                    objjourneylist.learning = Convert.ToString(row3["learning"]);

        //                    objtecp.Add(objjourneylist);
        //                }
        //                foreach (DataRow row4 in ds.Tables[4].Rows)
        //                {

        //                    SocialCVDetail objarticlelist = new SocialCVDetail();

        //                    objarticlelist.clasname = Convert.ToString(row4["class_name"]);
        //                    objarticlelist.fromdate = Convert.ToString(row4["fromdate"]);
        //                    objarticlelist.todate = Convert.ToString(row4["todate"]);
        //                    objarticlelist.socialwork = Convert.ToString(row4["socialwork"]);
        //                    objarticlelist.desccription = Convert.ToString(row4["description"]);
        //                    objarticlelist.learning = Convert.ToString(row4["learning"]);


        //                    objsoc.Add(objarticlelist);
        //                }
        //                foreach (DataRow row5 in ds.Tables[5].Rows)
        //                {

        //                    WorkCVDetail objarticlelist1 = new WorkCVDetail();

        //                    objarticlelist1.companyname = Convert.ToString(row5["companyname"]);
        //                    objarticlelist1.fromdate = Convert.ToString(row5["fromdate"]);
        //                    objarticlelist1.todate = Convert.ToString(row5["todate"]);
        //                    objarticlelist1.projecttopic = Convert.ToString(row5["projecttopic"]);
        //                    objarticlelist1.desccription = Convert.ToString(row5["description"]);
        //                    objarticlelist1.learning = Convert.ToString(row5["learning"]);


        //                    objwork.Add(objarticlelist1);
        //                }
        //                string fstsection = "";
        //                foreach (DataRow row6 in ds.Tables[6].Rows)
        //                {

        //                    SchoolCVDetail objarticlelist2 = new SchoolCVDetail();
        //                    fstsection = "<tr>";
        //                    objarticlelist2.schoolname = Convert.ToString(row6["schoolname"]);
        //                    objarticlelist2.fromdate = Convert.ToString(row6["fromdate"]);
        //                    objarticlelist2.todate = Convert.ToString(row6["todate"]);
        //                    objarticlelist2.state = Convert.ToString(row6["location"]);
        //                    objarticlelist2.university = Convert.ToString(row6["univercity"]);
        //                    objarticlelist2.description = Convert.ToString(row6["description"]);
        //                    objarticlelist2.classname = Convert.ToString(row6["class_name"]);
        //                    fstsection = fstsection + @"
        //                    <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>"+ objarticlelist2.schoolname + @"</td>
        //                    <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>" + objarticlelist2.fromdate + @"</td>
        //                    <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>" + objarticlelist2.todate + @"</td>
        //                    <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>" + objarticlelist2.state + @"</td>
        //                    <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>" + objarticlelist2.university + @"</td>
        //                    <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>" + objarticlelist2.description + @"</td>
        //                    <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>" + objarticlelist2.classname + @"</td>
        //                    </tr>";

        //                    objschool.Add(objarticlelist2);
        //                }




        //                //FutureRes.studentinfo = objfuture;
        //                //FutureRes.transcriptinfo = objtrans;
        //                //FutureRes.ecainfo = objteca;
        //                //FutureRes.ecpinfo = objtecp;
        //                //FutureRes.socialinfo = objsoc;
        //                //FutureRes.summerschoolinfo = objschool;
        //                //FutureRes.workinfo = objwork;
        //                objcv.message = "Success";


        //                document = @"
        //                 <table cellspŚacing='0' cellpadding='0' border='1' style='width:595pt; height:842pt; background:#fff; margin:0 auto; padding:30px; page-break-after:always; page-break-before:auto; page-break-inside:avoid;    margin-bottom: 20px;'>
        //                  <tr>
        //                   <td style='vertical-align:top'>
        //                    <table style=' width:100%; height:100%; background:#fff; padding:20px 20px;page-break-after:auto; page-break-before:auto; page-break-inside:avoid'>
        //                     <thead style='repeat:no-repeat'><tr style='height:10px'>
        //                      <td style='vertical-align:top; '>
        //                       <table cellpadding='0' cellspacing='0' border='0' style='width:100%;page-break-after:auto; page-break-before:auto; page-break-inside:avoid'>
        //                        <tr>
        //	                        <td style='vertical-align:top; text-align:right; width:227pt;'><p style='margin:0'><strong style='    font-size: 20px;
        //                    color: #000000;'>Ashish Thakur</strong></p><p style='margin:0; color: #b7b7b7;font-size: 25px;'></p></td>

        //                      <td style='vertical-align:top; text-align:right; width:277pt;'><p style='margin:0'><strong style='font-size: 20px;color: #888888; font-weight:300'>ashishthakur02111991@gmail.com</strong></p><p style='margin:0; color: #b7b7b7;font-size: 30px;'><strong style='font-size: 20px;
        //                    font-weight: 300;    color: #b7b7b7;'>+91-7508201488</strong></p></td>
        //                        </tr>
        //                       </table>
        //                      </td>
        //                     </tr></thead>
        //                     <tbody>
        //                     <tr>

        //                     </tr>

        //                     <tr>
        //                      <td style='vertical-align:top; height:220px'>
        //                      <h2>Academics</h2>
        //                       <table cellpadding='0' cellspacing='0' border='0' style='width:100%;page-break-after:auto; page-break-before:auto; page-break-inside:avoid'>
        //                        <tr>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff; font-size:14px; text-align:left'>Year</th>

        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>Class</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>Stream</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>School</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>City</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>State</th>

        //                        </tr>
        //                        " + fstsection + @"

        //                      </td>
        //                     </tr>

        //                     <tr>
        //                      <td style='vertical-align:top; height:220px'>
        //                      <h2>Summer School / Exchange program</h2>
        //                       <table cellpadding='0' cellspacing='0' border='0' style='width:100%;page-break-after:auto; page-break-before:auto; page-break-inside:avoid'>
        //                        <tr>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff; font-size:14px;text-align:left'>School Name</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>Class</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>From Date</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>ToDate</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>State</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>University</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>Description</th>


        //                        </tr>
        //                       " + fstsection + @"

        //                       </table>
        //                      </td>
        //                     </tr>
        //                     <tr>
        //                      <td style='vertical-align:top;height:220px'>
        //                      <h2>Work Experience/ Internship</h2>
        //                       <table cellpadding='0' cellspacing='0' border='0' style='width:100%;page-break-after:auto; page-break-before:auto; page-break-inside:avoid'>
        //                        <tr>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff; font-size:14px;text-align:left'>Company Name</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>From Date</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>To Date</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>Project</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>Description</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>Learning</th>


        //                        </tr>
        //                        <tr>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>


        //                        </tr>

        //                       </table>
        //                      </td>
        //                     </tr>
        //                     <tr>
        //                      <td style='vertical-align:top;page-break-after:auto; page-break-before:auto; page-break-inside:avoid'>
        //                      <h2>Social Work</h2>
        //                       <table cellpadding='0' cellspacing='0' border='0' style='width:100%;page-break-after:auto; page-break-before:auto; page-break-inside:avoid'>
        //                        <tr>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff; font-size:14px;text-align:left'>Class Name</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>From Date</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>To Date</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>Social Work</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>Description</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>Learning</th>


        //                        </tr>
        //                        <tr>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>


        //                        </tr>

        //                       </table>
        //                      </td>
        //                     </tr>
        //                      <tr>
        //                      <td style='vertical-align:top;page-break-after:auto; page-break-before:auto; page-break-inside:avoid'>
        //                      <h2>Extra Curricular Activities</h2>
        //                       <table cellpadding='0' cellspacing='0' border='0' style='width:100%;page-break-after:auto; page-break-before:auto; page-break-inside:avoid'>
        //                        <tr>

        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>Activity</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>Level</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>From Date </th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>To Date</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>Achievement</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>Learning</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>Class Name</th>

        //                        </tr>
        //                        <tr>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>


        //                        </tr>

        //                       </table>
        //                      </td>
        //                     </tr>


        //                     <tr>
        //                      <td style='vertical-align:top;page-break-after:auto; page-break-before:auto; page-break-inside:avoid'>
        //                      <h2>Transcript</h2>
        //                       <table cellpadding='0' cellspacing='0' border='0' style='width:100%;page-break-after:auto; page-break-before:auto; page-break-inside:avoid'>
        //                        <tr>

        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>School Name</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>Avg. Grade</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>Avg. Percentage</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>State</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>City</th>


        //                        </tr>
        //                        <tr>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>



        //                        </tr>

        //                       </table>
        //                      </td>
        //                     </tr>

        //                     <tr>
        //                      <td style='vertical-align:top;page-break-after:auto; page-break-before:auto; page-break-inside:avoid'>
        //                      <h2>Extra Certificate Program</h2>
        //                       <table cellpadding='0' cellspacing='0' border='0' style='width:100%;page-break-after:auto; page-break-before:auto; page-break-inside:avoid'>
        //                        <tr>

        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>Topic</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>Certificate</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>From Date </th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>To Date</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>Description</th>
        //	                        <th style='padding:10px 5px; background:#3f4fa5; color:#fff;font-size:14px;text-align:left'>Learning</th>


        //                        </tr>
        //                        <tr>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>
        //	                        <td style='border:1px solid #dedede;padding:10px 5px;font-size:14px'>--</td>



        //                        </tr>

        //                       </table>
        //                      </td>
        //                     </tr>







        //                       </table>
        //                      </td>
        //                     </tr>


        //                    </table>
        //                   </td>
        //                  </tr>
        //                 </table>
        //                ";

        //                string uniquename = Guid.NewGuid().ToString();
        //               res= generateword(document, uniquename, obj.studentid);
        //                objcv.cv = res;
        //                objcv.status = true;
        //                objcv.message = "Success";


        //                JsonSerializerSettings settings = new JsonSerializerSettings();
        //                settings.NullValueHandling = NullValueHandling.Ignore;
        //                json = JsonConvert.SerializeObject(objcv, settings);
        //            }
        //            else
        //            {
        //                objcv.status = false;
        //                objcv.message = "No Data Found";

        //                JsonSerializerSettings settings = new JsonSerializerSettings();
        //                settings.NullValueHandling = NullValueHandling.Ignore;
        //                json = JsonConvert.SerializeObject(objcv, settings);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            objcv.status = false;
        //            objcv.message = ex.Message;
        //            JsonSerializerSettings settings = new JsonSerializerSettings();
        //            settings.NullValueHandling = NullValueHandling.Ignore;
        //            json = JsonConvert.SerializeObject(objcv, settings);
        //        }
        //    }


        //    return Ok(json);
        //}




        [HttpGet]
        [Route("GenerateCV")]
        [Obsolete]
        public IActionResult GenerateCV([FromHeader] cvstudent obj)
        {
            DataSet ds = new DataSet();
            string json = "";
            string res = "";
            string document = "";
            string name1 = "";
            string mob1 = "";
            string user1 = "";
            CVResponse FutureRes = new CVResponse();
            List<StudentCVDetail> objfuture = new List<StudentCVDetail>();
            List<TranscriptCVDetail> objtrans = new List<TranscriptCVDetail>();
            List<ECACVDetail> objteca = new List<ECACVDetail>();
            List<ECPCVDetail> objtecp = new List<ECPCVDetail>();
            List<SocialCVDetail> objsoc = new List<SocialCVDetail>();
            List<WorkCVDetail> objwork = new List<WorkCVDetail>();
            List<SchoolCVDetail> objschool = new List<SchoolCVDetail>();
            GenerateCVDetail objcv = new GenerateCVDetail();
            if (obj.studentid == 0)
            {

                objcv.status = false;
                objcv.message = "Invalid StudentID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(objcv, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("StudentCVDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("stu_id", obj.studentid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        objcv.status = true;
                        string fstsection1 = "";
                        
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {

                            StudentCVDetail objstu = new StudentCVDetail();
                            fstsection1 = "<tr>";
                            objstu.studentname = Convert.ToString(row["stu_name"]);
                            name1 = Convert.ToString(row["stu_name"]);
                            objstu.email = Convert.ToString(row["stu_username"]);
                            user1 = Convert.ToString(row["stu_username"]);
                            objstu.mobileno = Convert.ToString(row["stu_mobile"]);
                            mob1 = Convert.ToString(row["stu_mobile"]);
                            objstu.academicyear = Convert.ToString(row["academicyear"]) == null ? "" : Convert.ToString(row["academicyear"]);
                            objstu.statename = Convert.ToString(row["state_name"]);
                            objstu.cityname = Convert.ToString(row["city_name"]);
                            objstu.schoolname = Convert.ToString(row["school_name"]);
                            objstu.classname = Convert.ToString(row["class_name"]);
                            objstu.streamname = Convert.ToString(row["stream_name"]);
                            fstsection1 = fstsection1 + @"
                             <td>" + objstu.studentname + @"</td>
                        <td>" + objstu.email + @"</td>
                        <td>" + objstu.mobileno + @"</td>
                        <td>" + objstu.academicyear + @"</td>
                        <td>" + objstu.statename + @"</td>
                        <td>" + objstu.cityname + @"</td>
                        <td>" + objstu.schoolname + @"</td>
<td>" + objstu.classname + @"</td>
<td>" + objstu.streamname + @"</td>

                       
                    </tr>";

                            objfuture.Add(objstu);
                        }
                        string fstsection2 = "";
                        foreach (DataRow row1 in ds.Tables[1].Rows)
                        {

                            TranscriptCVDetail objcareerlist = new TranscriptCVDetail();
                            fstsection2 = "<tr>";
                            objcareerlist.schoolname = Convert.ToString(row1["schoolname"]);
                            objcareerlist.grade = Convert.ToString(row1["avggrade"]);
                            objcareerlist.percentage = Convert.ToString(row1["avgper"]);
                            objcareerlist.statename = Convert.ToString(row1["state_name"]);
                            objcareerlist.cityname = Convert.ToString(row1["city_name"]);
                            fstsection2 = fstsection2 + @"
                             <td>" + objcareerlist.schoolname + @"</td>
                        <td>" + objcareerlist.grade + @"</td>
                        <td>" + objcareerlist.percentage + @"</td>
                        <td>" + objcareerlist.statename + @"</td>
                        <td>" + objcareerlist.cityname + @"</td>
                      
                       
                    </tr>";
                            objtrans.Add(objcareerlist);
                        }
                        string fstsection3 = "";
                        foreach (DataRow row2 in ds.Tables[2].Rows)
                        {

                            ECACVDetail objinterviewlist = new ECACVDetail();
                            fstsection3 = "<tr>";
                            objinterviewlist.activityname = Convert.ToString(row2["activityname"]);
                            objinterviewlist.level = Convert.ToString(row2["levelname"]);
                            objinterviewlist.fromdate = Convert.ToString(row2["fromdate"]);
                            objinterviewlist.todate = Convert.ToString(row2["todate"]);
                            objinterviewlist.achievement = Convert.ToString(row2["achievement"]);
                            objinterviewlist.learning = Convert.ToString(row2["learning"]);
                            objinterviewlist.classname = Convert.ToString(row2["class_name"]);
                            fstsection3 = fstsection3 + @"
                             <td>" + objinterviewlist.activityname + @"</td>
                        <td>" + objinterviewlist.level + @"</td>
                        <td>" + objinterviewlist.fromdate + @"</td>
                        <td>" + objinterviewlist.todate + @"</td>
                        <td>" + objinterviewlist.achievement + @"</td>
                      <td>" + objinterviewlist.learning + @"</td>
                        <td>" + objinterviewlist.classname + @"</td>
                       
                    </tr>";

                            objteca.Add(objinterviewlist);
                        }

                        string fstsection4 = "";
                        foreach (DataRow row3 in ds.Tables[3].Rows)
                        {

                            ECPCVDetail objjourneylist = new ECPCVDetail();
                            fstsection4 = "<tr>";
                            objjourneylist.topic = Convert.ToString(row3["topic"]);
                            objjourneylist.fromdate = Convert.ToString(row3["fromdate"]);
                            objjourneylist.todate = Convert.ToString(row3["todate"]);
                            objjourneylist.certificatefrom = Convert.ToString(row3["certificatefrom"]);
                            objjourneylist.desccription = Convert.ToString(row3["description"]);
                            objjourneylist.learning = Convert.ToString(row3["learning"]);
                            fstsection4 = fstsection4 + @"
                             <td>" + objjourneylist.topic + @"</td>
                        <td>" + objjourneylist.fromdate + @"</td>
                        <td>" + objjourneylist.todate + @"</td>
                        <td>" + objjourneylist.certificatefrom + @"</td>
                        <td>" + objjourneylist.desccription + @"</td>
                      <td>" + objjourneylist.learning + @"</td>
                      
                       
                    </tr>";
                            objtecp.Add(objjourneylist);
                        }
                        string fstsection5 = "";
                        foreach (DataRow row4 in ds.Tables[4].Rows)
                        {

                            SocialCVDetail objarticlelist = new SocialCVDetail();
                            fstsection5 = "<tr>";
                            objarticlelist.clasname = Convert.ToString(row4["class_name"]);
                            objarticlelist.fromdate = Convert.ToString(row4["fromdate"]);
                            objarticlelist.todate = Convert.ToString(row4["todate"]);
                            objarticlelist.socialwork = Convert.ToString(row4["socialwork"]);
                            objarticlelist.desccription = Convert.ToString(row4["description"]);
                            objarticlelist.learning = Convert.ToString(row4["learning"]);

                            fstsection5 = fstsection5 + @"
                             <td>" + objarticlelist.clasname + @"</td>
                        <td>" + objarticlelist.fromdate + @"</td>
                        <td>" + objarticlelist.todate + @"</td>
                        <td>" + objarticlelist.socialwork + @"</td>
                        <td>" + objarticlelist.desccription + @"</td>
                      <td>" + objarticlelist.learning + @"</td>
                      
                       
                    </tr>";
                            objsoc.Add(objarticlelist);
                        }
                        string fstsection6 = "";
                        foreach (DataRow row5 in ds.Tables[5].Rows)
                        {

                            WorkCVDetail objarticlelist1 = new WorkCVDetail();
                            fstsection6 = "<tr>";
                            objarticlelist1.companyname = Convert.ToString(row5["companyname"]);
                            objarticlelist1.fromdate = Convert.ToString(row5["fromdate"]);
                            objarticlelist1.todate = Convert.ToString(row5["todate"]);
                            objarticlelist1.projecttopic = Convert.ToString(row5["projecttopic"]);
                            objarticlelist1.desccription = Convert.ToString(row5["description"]);
                            objarticlelist1.learning = Convert.ToString(row5["learning"]);
                            fstsection6 = fstsection6 + @"
                             <td>" + objarticlelist1.companyname + @"</td>
                        <td>" + objarticlelist1.fromdate + @"</td>
                        <td>" + objarticlelist1.todate + @"</td>
                        <td>" + objarticlelist1.projecttopic + @"</td>
                        <td>" + objarticlelist1.desccription + @"</td>
                      <td>" + objarticlelist1.learning + @"</td>
                      
                       
                    </tr>";

                            objwork.Add(objarticlelist1);
                        }
                        string fstsection = "";
                        foreach (DataRow row6 in ds.Tables[6].Rows)
                        {

                            SchoolCVDetail objarticlelist2 = new SchoolCVDetail();
                            fstsection = "<tr>";
                            objarticlelist2.schoolname = Convert.ToString(row6["schoolname"]);
                            objarticlelist2.fromdate = Convert.ToString(row6["fromdate"]);
                            objarticlelist2.todate = Convert.ToString(row6["todate"]);
                            objarticlelist2.state = Convert.ToString(row6["location"]);
                            objarticlelist2.university = Convert.ToString(row6["univercity"]);
                            objarticlelist2.description = Convert.ToString(row6["description"]);
                            objarticlelist2.classname = Convert.ToString(row6["class_name"]);
                            fstsection = fstsection + @"
                             <td>" + objarticlelist2.schoolname + @"</td>
                        <td>" + objarticlelist2.fromdate + @"</td>
                        <td>" + objarticlelist2.todate + @"</td>
                        <td>" + objarticlelist2.state + @"</td>
                        <td>" + objarticlelist2.university + @"</td>
                        <td>" + objarticlelist2.description + @"</td>
                        <td>" + objarticlelist2.classname + @"</td>
                       
                    </tr>";

                            objschool.Add(objarticlelist2);
                        }

                        objcv.message = "Success";


                        document = @"
	                       <div class='container' width='1170px' style='width:1170px;margin:0 auto;'>
        <div align='center' style='text-align: center;'>
            <h2 style='color:#009688;'>Resume</h2>
            <h4>Name- " + name1 + @"</h4>         
            <p><span>Phone-" + mob1 + @"</span> | <span>" + user1 + @"</span></p>
        </div>
        <div align='center' style='text-align:center;'>

<h4 align='left' style='color:#F44336;margin-bottom:5px;text-align: left;'>Academics</h4>
            
<table border='1' align='center' width='100%' style='width:100%;'>
                <thead>
                    <tr bgcolor='#009688'>
                        <th style='color: #fff;'>Student Name</th>
                        <th style='color: #fff;'>Email</th>
                        <th style='color: #fff;'>Mobile No.</th>
                        <th style='color: #fff;'>Academicyear</th>
                        <th style='color: #fff;'>State</th>
                        <th style='color: #fff;'>City</th>
                        <th style='color: #fff;'>School</th>
<th style='color: #fff;'>Class</th>
                        <th style='color: #fff;'>Stream</th>
                        
                    </tr>
                </thead>
                <tbody>
                   " + fstsection1 + @"
                </tbody>
            </table>



            
<h4 align='left' style='color:#F44336;margin-bottom:5px;text-align: left;'>Transcript</h4>

<table border='1' align='center' width='100%' style='width:100%;'>
                <thead>
                    <tr bgcolor='#009688'>
                        <th style='color: #fff;'> School Name</th>
                        <th style='color: #fff;'>Grade</th>
                        <th style='color: #fff;'>Percentage</th>
                        <th style='color: #fff;'>State</th>
                        <th style='color: #fff;'>City</th>
                      <th style='color: #fff;'></th>
                        <th style='color: #fff;'></th>
                        <th style='color: #fff;'></th>
                        <th style='color: #fff;'></th>
                        
                    </tr>
                </thead>
                <tbody>
                   " + fstsection2 + @"
                </tbody>
            </table>


<h4 align='left' style='color:#F44336;margin-bottom:5px;text-align: left;'>Extra Curricular Activity (ECA)</h4>

<table border='1' align='center' width='100%' style='width:100%;'>
                <thead>
                    <tr bgcolor='#009688'>
                        <th style='color: #fff;'>Activity Name</th>
                        <th style='color: #fff;'>Lavel</th>
                        <th style='color: #fff;'>From Date</th>
                        <th style='color: #fff;'>To Date</th>
                        <th style='color: #fff;'>Achievement</th>
 <th style='color: #fff;'>Learning</th>
                        <th style='color: #fff;'>Class</th>
                     <th style='color: #fff;'></th>
                        <th style='color: #fff;'></th>
                        
                    </tr>
                </thead>
                <tbody>
                   " + fstsection3 + @"
                </tbody>
            </table>



<h4 align='left' style='color:#F44336;margin-bottom:5px;text-align: left;'>Extra Curricular Program (ECP)</h4>

<table border='1' align='center' width='100%' style='width:100%;'>
                <thead>
                    <tr bgcolor='#009688'>
                        <th style='color: #fff;'>Topic</th>
                        
                        <th style='color: #fff;'>From Date</th>
                        <th style='color: #fff;'>To Date</th>
                        <th style='color: #fff;'>Certificate From</th>
 <th style='color: #fff;'>Description</th>
                        <th style='color: #fff;'>Learning</th>
                     
                        <th style='color: #fff;'></th>
 <th style='color: #fff;'></th>
                        <th style='color: #fff;'></th>
                    </tr>
                </thead>
                <tbody>
                   " + fstsection4 + @"
                </tbody>
            </table>


<h4 align='left' style='color:#F44336;margin-bottom:5px;text-align: left;'>Social Work</h4>

<table border='1' align='center' width='100%' style='width:100%;'>
                <thead>
                    <tr bgcolor='#009688'>
                        <th style='color: #fff;'>Class</th>
                        
                        <th style='color: #fff;'>From Date</th>
                        <th style='color: #fff;'>To Date</th>
                        <th style='color: #fff;'>Social WOrk</th>
 <th style='color: #fff;'>Description</th>
                        <th style='color: #fff;'>Learning</th>
                         <th style='color: #fff;'></th>
 <th style='color: #fff;'></th>
                        <th style='color: #fff;'></th>
                        
                    </tr>
                </thead>
                <tbody>
                   " + fstsection5 + @"
                </tbody>
            </table>


<h4 align='left' style='color:#F44336;margin-bottom:5px;text-align: left;'>Work Experience</h4>

<table border='1' align='center' width='100%' style='width:100%;'>
                <thead>
                    <tr bgcolor='#009688'>
                        <th style='color: #fff;'>Company</th>
                        
                        <th style='color: #fff;'>From Date</th>
                        <th style='color: #fff;'>To Date</th>
                        <th style='color: #fff;'>Topic</th>
 <th style='color: #fff;'>Description</th>
                        <th style='color: #fff;'>Learning</th>
                     
                         <th style='color: #fff;'></th>
 <th style='color: #fff;'></th>
                        <th style='color: #fff;'></th>
                    </tr>
                </thead>
                <tbody>
                   " + fstsection6 + @"
                </tbody>
            </table>



<h4 align='left' style='color:#F44336;margin-bottom:5px;text-align: left;'>Summer School</h4>

<table border='1' align='center' width='100%' style='width:100%;'>
                <thead>
                    <tr bgcolor='#009688'>
                        <th style='color: #fff;'>School Name</th>
                        
                        <th style='color: #fff;'>From Date</th>
                        <th style='color: #fff;'>To Date</th>
<th style='color: #fff;'>State</th>
                        <th style='color: #fff;'>University</th>
 <th style='color: #fff;'>Description</th>
                        <th style='color: #fff;'>Class</th>
                     
                        <th style='color: #fff;'></th>
                        <th style='color: #fff;'></th>
                    </tr>
                </thead>
                <tbody>
                   " + fstsection + @"
                </tbody>
            </table>

        </div>
    </div>
                        ";

                        string uniquename = Guid.NewGuid().ToString();
                        res = generateword(document, uniquename, obj.studentid);
                        objcv.cv = res;
                        objcv.status = true;
                        objcv.message = "Success";


                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objcv, settings);
                    }
                    else
                    {
                        objcv.status = false;
                        objcv.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(objcv, settings);
                    }
                }
                catch (Exception ex)
                {
                    objcv.status = false;
                    objcv.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(objcv, settings);
                }
            }


            return Ok(json);
        }





        public string Converter(string ddate)
        {
            DateTime dt;


            char[] separator = new char[] { '/' };
            string[] strSplitArr = ddate.Split(separator);
            string dd, mm, yy;

            dd = strSplitArr[0].ToString();
            mm = strSplitArr[1].ToString();
            yy = strSplitArr[2].ToString();
            string db;
            db = mm + "/" + dd + "/" + yy;
            dt = Convert.ToDateTime(db);

            return dt.ToString("yyyy/MM/dd");

        }

        [Obsolete]
        public string generateword(string HtmlContent, string Docname,int StudentId)
        {
            DataSet ds = new DataSet();
            GenerateCVResponse FutureRes = new GenerateCVResponse();
            List<GenerateCVDetail> objfuture = new List<GenerateCVDetail>();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            string json = "";
            string Result = "";
           // GeneratepdfResp objresp = new GeneratepdfResp();
            string uploadDirectory = "";
            string strdocPath = _hostingEnvironment.WebRootPath + "\\Uploads\\";
            if (!Directory.Exists(strdocPath))
            {
                System.IO.Directory.CreateDirectory(_hostingEnvironment.WebRootPath + "/Uploads/");
                uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "Uploads");
            }
            else
            {
                uploadDirectory = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "Uploads");
            }


            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                MySqlCommand cmd = new MySqlCommand("savecv", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("message", "");
                cmd.Parameters["message"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("studentid_d", StudentId);
                cmd.Parameters.AddWithValue("guid_d", Docname);
                con.Open();
               
                cmd.ExecuteScalar();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                string result = cmd.Parameters["message"].Value.ToString();
           

                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {

                    FutureRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        GenerateCVDetail objlist = new GenerateCVDetail();


                        objlist.cv = "http://apis.careerprabhu.com/" + "Uploads/" + Convert.ToString(row["cv"]);
                        Result = objlist.cv;
                        objfuture.Add(objlist);
                    }

                    FutureRes.data = objfuture;
                    FutureRes.message = "Success";
                   
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(FutureRes, settings);
                }
                else
                {
                    FutureRes.status = false;
                    FutureRes.message = "No Data Found";

                    
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(FutureRes, settings);

                }




            }
            catch (Exception ex)
            {
                FutureRes.status = false;
                FutureRes.message = ex.Message;
             
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(FutureRes, settings);

            }

            try
            {
                HttpContext.Response.Clear();
                //string html = HtmlContent;
                string html = @"
                       <html lang='en'>
                           <head>
                               <meta charset='UTF-8'>
                               <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                               <meta http-equiv='X-UA-Compatible' content='ie=edge'>                      
                           </head>
                           <body>" + HtmlContent + @"
                           </body>
                       </html>";
                var sb = new StringBuilder();
                sb.Append(@"
                       <html lang='en'>
                           <head>
                               <meta charset='UTF-8'>
                               <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                               <meta http-equiv='X-UA-Compatible' content='ie=edge'>
                               
                           </head>
                           <body>");
                sb.Append(HtmlContent);
                sb.Append(@"
                           </body>
                       </html>");
                StringWriter sw = new StringWriter(sb);
                sw.WriteLine();
                string path = uploadDirectory;
                string filename = path + @"\" + Docname + @".docx";
                string filename1 = path + @"\" + Docname + @".pdf";
                //if (System.IO.File.Exists(filename)) System.IO.File.Delete(filename);

                using (Stream generatedDocument = new MemoryStream())

                //using (MemoryStream generatedDocument = new MemoryStream())
                //{
                // byte[] fileContents;
                using (WordprocessingDocument package = WordprocessingDocument.Create(filename, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = package.MainDocumentPart;
                    if (mainPart == null)
                    {
                        mainPart = package.AddMainDocumentPart();
                        new DocumentFormat.OpenXml.Wordprocessing.Document(new Body()).Save(mainPart);
                    }

                    HtmlConverter converter = new HtmlConverter(mainPart);
                    Body body = mainPart.Document.Body;

                    var paragraphs = converter.Parse(html);
                    for (int i = 0; i < paragraphs.Count; i++)
                    {
                        body.Append(paragraphs[i]);
                    }

                    mainPart.Document.Save();
                    // if (System.IO.File.Exists(filename)) { package.Save(); }
                    //else
                    //{
                    //    package.SaveAs(filename);
                    //}
                    //package.SaveAs(filename);
                    package.Save();
                    //package.Dispose();
                    package.Close();
                }

                //var Filewithpath = filename;
                //var Filewithpath2 = filename1;
                //Application app = new Application();
                //Document doc = app.Documents.Open(Filewithpath);
                //doc.SaveAs2(Filewithpath2, WdSaveFormat.wdFormatPDF);
                //doc.Close();
                //app.Quit();
                //Console.WriteLine("Completed");

                //Document doc = new Document(filename);
                //doc.Save(filename1, SaveFormat.Pdf);

            }
            catch (Exception ex)
            {
                FutureRes.status = false;
                FutureRes.message = ex.Message;
      
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(FutureRes, settings);


            }



            settings.NullValueHandling = NullValueHandling.Ignore;
            json = JsonConvert.SerializeObject(FutureRes, settings);
            return Result;
        }

        [HttpGet]
        [Route("StudentReport")]
        public IActionResult GetGenerateCV([FromHeader] CVLive obj)

        {
            DataSet ds = new DataSet();
            string json = "";


            GenerateCVResponse FutureRes = new GenerateCVResponse();
            List<GenerateCVDetail> objfuture = new List<GenerateCVDetail>();


            if (obj.studentid == 0)
            {
                FutureRes.status = false;
                FutureRes.message = "Invalid StudentID";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(FutureRes, settings);
            }
            else
            {

                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("GetCVInfo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("studentid_D", obj.studentid);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        FutureRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            GenerateCVDetail objlist = new GenerateCVDetail();
                       
                       
                            objlist.cv = "http://apis.careerprabhu.com/" + "Uploads/" + Convert.ToString(row["cv"]);
                            objfuture.Add(objlist);
                        }

                        FutureRes.data = objfuture;
                        FutureRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);
                    }
                    else
                    {
                        FutureRes.status = false;
                        FutureRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(FutureRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    FutureRes.status = false;
                    FutureRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(FutureRes, settings);

                }

            }

            return Ok(json);
        }


        //Google account login
        [AllowAnonymous]
        [HttpPost]
        [Route("GoogleCredentialLogin")]
        public string GoogleCredentialLogin([FromBody] GetLoginData data)
        {
            string json = "";
            string username = "";
            string pwd = "";
            string token = "";
            string logintokenkey = "";
            string result = "";
            JsonSerializerSettings settings = new JsonSerializerSettings();
            LoginDetail_google login = new LoginDetail_google();
            LoginResponse_google res = new LoginResponse_google();
            
                 DataSet ds = new DataSet();


            if (data.Login_type == 1)
            {
                if (data.UserName == "" || data.UserName == null )
                {
                    res.Status = false;
                    res.Message = "Invalid Student UserName";
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(res, settings);
                }
                else
                {
                    username = data.UserName;
             
                    token = GetToken(Convert.ToString(data.UserName));
                    logintokenkey = Guid.NewGuid().ToString();
                }
            }
            else if (data.Login_type == 2)
            {
                if (data.UserName == "" ||  data.UserName == null )
                {
                    res.Status = false;
                    res.Message = "Invalid Parents UserName";
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(res, settings);
                }
                else
                {
                    username = data.UserName;
               
                    token = GetToken(Convert.ToString(data.UserName));
                    logintokenkey = Guid.NewGuid().ToString();
                }
            }

            try
            {


                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                MySqlCommand cmd = new MySqlCommand("StudentGoogleLoginManager", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("LoginType_d", data.Login_type);
                cmd.Parameters.AddWithValue("UserName_d", username);
            
                cmd.Parameters.AddWithValue("token_d", token);
                cmd.Parameters.AddWithValue("tokenloginkey_d", logintokenkey);
                //cmd.Parameters.AddWithValue("studentportalid_d", data.Student_id);
                cmd.Parameters.AddWithValue("deviceIMEI_d", data.IMEI);
                cmd.Parameters.AddWithValue("devicetype_d", data.DeviceType);
                cmd.Parameters.AddWithValue("OsVersion_d", data.OsVersion);
                cmd.Parameters.AddWithValue("appversion_d", data.AppVersion_d);
                cmd.Parameters.AddWithValue("Lang_d", data.Lang);
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;

                da.Fill(ds);
                con.Close();

               
                 if (ds.Tables.Count > 0)
                    {

                        res.Status = true;
                        if (Convert.ToString(ds.Tables[0].Rows[0]["profilestatus"]) == "0")
                        {
                            res.profilestatus = 0;
                        }
                        else
                        {
                            res.profilestatus = 1;
                        }
                        if(res.profilestatus == 0)
                    {
                        res.data = new LoginDetail_google();
                        
                        res.Message = "Success";
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(res, settings);
                    }

                    else
                    {
                        foreach (DataRow row in ds.Tables[1].Rows)
                        {
                            //LoginDetail ObjPrepList = new LoginDetail();
                            json = JsonConvert.SerializeObject(ds.Tables[1], Formatting.Indented);
                            //ObjPrepList.Token = GetToken(Convert.ToString(ds.Tables[0].Rows[0]["studentid"]));
                            login.studentid = Convert.ToInt32(row["studentid"]);// Same As DataBase column Name 

                            login.logintype = Convert.ToInt32(row["LoginType"]);
                            login.logintype = Convert.ToInt32(row["LoginType"]);


                            login.p_user = row["username"].ToString();// Storing Data Base data into Local Variable
                            login.Token = row["Token"].ToString();
                            login.loginkey = row["LoginKey"].ToString();
                            login.classid = Convert.ToInt32(row["class_id"]);
                            login.classname = row["class_name"].ToString();

                            if (Convert.ToInt32(row["class_id"]) > 3)
                            {
                                login.streamid = Convert.ToInt32(row["stream_id"]);
                                login.streamname = row["stream_name"].ToString();
                            }
                            else
                            {
                                login.streamid = 0;
                                login.streamname = "";
                            }

                            login.usertype = Convert.ToInt32(row["user_type"].ToString());
                            // login.Add(ObjPrepList);

                        }


                        //log mantain start

                        json = JsonConvert.SerializeObject(res);
                        json = json.Replace("[", "");
                        json = json.Replace("]", "");

                        //Getting IP Address of local System
                        string ip = GetLocalIP();

                        //Getting data From IP Address
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://ip-api.com/json/" + ip);
                        request.Method = "POST";
                        request.ContentType = "application/json";

                        WebResponse webResponse = request.GetResponse();
                        Stream webStream = webResponse.GetResponseStream();
                        StreamReader responseReader = new StreamReader(webStream);
                        string response = responseReader.ReadToEnd();
                        response = "{Table1: [" + response + "]}";
                        DataSet IPdetail = JsonConvert.DeserializeObject<DataSet>(response);
                        // Console.Out.WriteLine(response);
                        responseReader.Close();

                        //Saving App downloading logs
                        //AppDownloadingLogs(
                        //    Convert.ToInt32(ds.Tables[1].Rows[0]["studentid"]),

                        //    token, ip, IPdetail.Tables[1].Rows[0]["country"].ToString(),
                        //    IPdetail.Tables[1].Rows[0]["regionName"].ToString(),
                        //    IPdetail.Tables[1].Rows[0]["city"].ToString(),
                        //    IPdetail.Tables[1].Rows[0]["as"].ToString(),
                        //    data.IMEI
                        //    );


                        //log mantain end
                        try
                        {
                            if (Convert.ToInt32(ds.Tables[2].Rows[0]["ispassout"]) == 1)
                            {
                                login.ispassout = false;
                            }
                            else
                            {
                                login.ispassout = true;
                            }
                        }
                        catch (Exception e)
                        {
                            login.ispassout = true;
                        }



                        res.data = login;
                        
                        res.Message = "Success";
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(res, settings);


                    }




                }
                    else
                    {
                        
                        res.Status = false;
                        res.Message = "Invalid Credentials";

                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(res, settings);
                    }
                

             

            }
            catch (Exception ex)
            {
                res.Status = false;
                res.Message = ex.Message;

                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(res, settings);

            }

            return json;
        }


        //port folio api start here
        [HttpGet]
        [Route("BindState")]
        public IActionResult BindStateCareer([FromHeader] Getstatedetail data)
        {
            DataSet ds = new DataSet();
            string json = "";

            CareerStateResponse CountryRes = new CareerStateResponse();
            List<CareerStateDetail> objcountry = new List<CareerStateDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("BindLocation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("countryid_d", data.countryid);
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    CountryRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        CareerStateDetail objlist = new CareerStateDetail();
                        objlist.statename = Convert.ToString(row["location"]);
                        objlist.stateid = Convert.ToInt32(row["locationid"]);

                        objcountry.Add(objlist);
                    }

                    CountryRes.data = objcountry;
                    CountryRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CountryRes, settings);
                }
                else
                {
                    CountryRes.status = false;
                    CountryRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CountryRes, settings);

                }

            }
            catch (Exception ex)
            {

                CountryRes.status = false;
                CountryRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(CountryRes, settings);

            }

            return Ok(json);
        }


        [HttpGet]
        [Route("BindCity")]
        public IActionResult BindCityCareer([FromHeader] Getcitydetail data)
        {
            DataSet ds = new DataSet();
            string json = "";

            CareerCityResponse CountryRes = new CareerCityResponse();
            List<CareerCityDetail> objcountry = new List<CareerCityDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("BindCityCareer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("countryid_d", data.countryid);
                cmd.Parameters.AddWithValue("locationid_d", data.stateid);
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    CountryRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        CareerCityDetail objlist = new CareerCityDetail();
                        objlist.cityname = Convert.ToString(row["cityname"]);
                        objlist.cityid = Convert.ToInt32(row["cityid"]);

                        objcountry.Add(objlist);
                    }

                    CountryRes.data = objcountry;
                    CountryRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CountryRes, settings);
                }
                else
                {
                    CountryRes.status = false;
                    CountryRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CountryRes, settings);

                }

            }
            catch (Exception ex)
            {

                CountryRes.status = false;
                CountryRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(CountryRes, settings);

            }

            return Ok(json);
        }


        [HttpGet]
        [Route("BindSubtrait")]
        public IActionResult BindSubtraitCareer([FromHeader] Getsubtrait data)
        {
            DataSet ds = new DataSet();
            string json = "";

            CareersubtraitResponse CountryRes = new CareersubtraitResponse();
            List<CareersubtraitDetail> objcountry = new List<CareersubtraitDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("BindSubtrait", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("traitid_d", data.traitid);
                
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    CountryRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        CareersubtraitDetail objlist = new CareersubtraitDetail();
                        objlist.subtrait = Convert.ToString(row["subtrait"]);
                        objlist.subtraitid = Convert.ToInt32(row["sampleportfolioid"]);

                        objcountry.Add(objlist);
                    }

                    CountryRes.data = objcountry;
                    CountryRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CountryRes, settings);
                }
                else
                {
                    CountryRes.status = false;
                    CountryRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CountryRes, settings);

                }

            }
            catch (Exception ex)
            {

                CountryRes.status = false;
                CountryRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(CountryRes, settings);

            }

            return Ok(json);
        }



        [HttpGet]
        [Route("ShowPortfolioData")]
        public IActionResult ShowPortfolioData([FromHeader] Getportfoliodata data)
        {
            DataSet ds = new DataSet();
            string json = "";

            ShowsubtraitResponse CountryRes = new ShowsubtraitResponse();
            List<ShowsubtraitDetail> objcountry = new List<ShowsubtraitDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("BindPortfolioGuidelinedetail_update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("traitid_d", data.traitid);
                cmd.Parameters.AddWithValue("subtraitid_d", data.subtraitid);
                cmd.Parameters.AddWithValue("countryid_d", data.countryid);
                cmd.Parameters.AddWithValue("stateid_d", data.stateid);
                cmd.Parameters.AddWithValue("cityid_d", data.cityid);
                cmd.Parameters.AddWithValue("languageid_d", data.languageid);

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    CountryRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ShowsubtraitDetail objlist = new ShowsubtraitDetail();
                        objlist.videolink = Convert.ToString(row["link"]);


                        if (Convert.ToString(row["orgfilename"]) == "" || Convert.ToString(row["orgfilename"]) == null)
                        {
                            objlist.originalfilename = Convert.ToString(row["orgfilename"]);
                        }
                        else
                        {
                            objlist.originalfilename = Convert.ToString(row["orgfilename"]);
                        }



                        if (Convert.ToString(row["imagepath"])=="" || Convert.ToString(row["imagepath"]) == null)
                        {
                            objlist.image = "";
                        }
                        else
                        {
                            objlist.image = "http://admin.careerprabhu.com/" + "sampleportfoliopdf/" + Convert.ToString(row["imagepath"]);
                        }
                       
                        objlist.trait = Convert.ToString(row["trait"]);
                        objlist.subtrait = Convert.ToString(row["subtrait"]);
                        objlist.countryname = Convert.ToString(row["countryname"]);
                        objlist.statename = Convert.ToString(row["location"]);
                        objlist.cityname = Convert.ToString(row["cityname"]);
                        objlist.university = Convert.ToString(row["universityname"]);
                        objlist.guideline = Convert.ToString(row["guideline"]);
                        objlist.description = Convert.ToString(row["description"]);

                        objcountry.Add(objlist);
                    }

                    CountryRes.data = objcountry;
                    CountryRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CountryRes, settings);
                }
                else
                {
                    CountryRes.status = false;
                    CountryRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CountryRes, settings);

                }

            }
            catch (Exception ex)
            {

                CountryRes.status = false;
                CountryRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(CountryRes, settings);

            }

            return Ok(json);
        }


        //APIS for principal dashboard

        //api for bind studentname
        [HttpGet]
        [Route("GetStudentName")]
        public IActionResult GetStudentName([FromHeader] GetStudentData data)
        {
            DataSet ds = new DataSet();
            string json = "";

            ShowStuentResponse CountryRes = new ShowStuentResponse();
            List<ShowStudentDetail> objcountry = new List<ShowStudentDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("BindStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("schoolid_d", data.schoolid);
                cmd.Parameters.AddWithValue("stateid_d", data.stateid);
                cmd.Parameters.AddWithValue("cityid_d", data.cityid);
                cmd.Parameters.AddWithValue("classid_d", data.classid);
                cmd.Parameters.AddWithValue("streamid_d", data.streamid);

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    CountryRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ShowStudentDetail objlist = new ShowStudentDetail();
                        objlist.studentid = Convert.ToInt32(row["studentid"]);
                        objlist.studentname = Convert.ToString(row["studentname"]);

                        objcountry.Add(objlist);
                    }

                    CountryRes.data = objcountry;
                    CountryRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CountryRes, settings);
                }
                else
                {
                    CountryRes.status = false;
                    CountryRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CountryRes, settings);

                }

            }
            catch (Exception ex)
            {

                CountryRes.status = false;
                CountryRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(CountryRes, settings);

            }

            return Ok(json);
        }

        //API for premium screen
        [HttpGet]
        [Route("GetPremiumProduct")]
        public IActionResult GetPremiumProduct([FromHeader] GetPremiumStatusStudentData data)
        {
            DataSet ds = new DataSet();
            string json = "";

            PremiumResponse ClassRes = new PremiumResponse();
            List<PremiumDetail> objclass = new List<PremiumDetail>();
            
            BannerDetail objbanner = new BannerDetail();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();

                MySqlCommand cmd = new MySqlCommand("BindPremiumProduct_new", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("studentid_d", data.studentid);
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    ClassRes.status = true;
                    objbanner.banner = "http://admin.careerprabhu.com/" + "SOP/" + "primiumbanner.png";
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        PremiumDetail objlist = new PremiumDetail();
                        objlist.productname = Convert.ToString(row["productname"]);
                        objlist.productid = Convert.ToInt32(row["productid"]);
                        objlist.status = Convert.ToInt32(row["paymentstatus"]);
                        objlist.description = Convert.ToString(row["description"]);

                        objclass.Add(objlist);
                    }

                   


                    ClassRes.data = objclass;
                
                    ClassRes.banner = objbanner;
                    ClassRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ClassRes, settings);
                }
                else
                {
                    ClassRes.status = false;
                    ClassRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(ClassRes, settings);

                }

            }
            catch (Exception ex)
            {

                ClassRes.status = false;
                ClassRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(ClassRes, settings);

            }

            return Ok(json);
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("PrincipalLoginManager")]
        public string PrincipalLoginManager([FromBody] GetPrincipalLoginData data)
        {
            string json = "";
            string username = "";
            string pwd = "";
            string token = "";
            string logintokenkey = "";
            string result = "";
            JsonSerializerSettings settings = new JsonSerializerSettings();
            PrincipalLoginDetail login = new PrincipalLoginDetail();
            PrincipalLoginResponse res = new PrincipalLoginResponse();
            DataSet ds = new DataSet();


            if (data.Login_type == 3)
            {
                if (data.UserName == "" || data.P_Password == "" || data.UserName == null || data.P_Password == null)
                {
                    res.Status = false;
                    res.Message = "Invalid Principal UserName Or Password";
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(res, settings);
                }
                else
                {
                    username = data.UserName;
                    pwd = data.P_Password;
                    token = GetToken(Convert.ToString(data.UserName));
                    logintokenkey = Guid.NewGuid().ToString();

                    try
                    {


                        MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                        MySqlCommand cmd = new MySqlCommand("PrincipalLoginManager", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("LoginType_d", data.Login_type);
                        cmd.Parameters.AddWithValue("UserName_d", username);
                        cmd.Parameters.AddWithValue("Pwd_d", pwd);
                        cmd.Parameters.AddWithValue("token_d", token);
                        cmd.Parameters.AddWithValue("tokenloginkey_d", logintokenkey);
                        //cmd.Parameters.AddWithValue("studentportalid_d", data.Student_id);
                        cmd.Parameters.AddWithValue("deviceIMEI_d", data.IMEI);
                        cmd.Parameters.AddWithValue("devicetype_d", data.DeviceType);
                        cmd.Parameters.AddWithValue("OsVersion_d", data.OsVersion);
                        cmd.Parameters.AddWithValue("appversion_d", data.AppVersion_d);
                        cmd.Parameters.AddWithValue("Lang_d", data.Lang);
                        con.Open();
                        MySqlDataAdapter da = new MySqlDataAdapter();
                        da.SelectCommand = cmd;

                        da.Fill(ds);
                        con.Close();

                        if (ds.Tables.Count > 0)
                        {

                            res.Status = true;
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                //LoginDetail ObjPrepList = new LoginDetail();
                                json = JsonConvert.SerializeObject(ds.Tables[0], Formatting.Indented);
                                //ObjPrepList.Token = GetToken(Convert.ToString(ds.Tables[0].Rows[0]["studentid"]));
                                login.principalid = Convert.ToInt32(row["principalid"]);// Same As DataBase column Name 

                                login.logintype = Convert.ToInt32(row["LoginType"]);
                                login.stateid = Convert.ToInt32(row["stateid"]);
                                login.cityid = Convert.ToInt32(row["cityid"]);
                                login.schoolid = Convert.ToInt32(row["schoolid"]);
                                login.p_user = row["username"].ToString();// Storing Data Base data into Local Variable
                                login.Token = row["Token"].ToString();
                                login.loginkey = row["LoginKey"].ToString();


                                // login.Add(ObjPrepList);

                            }



                            //log mantain start

                            json = JsonConvert.SerializeObject(res);
                            json = json.Replace("[", "");
                            json = json.Replace("]", "");

                            //Getting IP Address of local System
                            string ip = GetLocalIP();

                            //Getting data From IP Address
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://ip-api.com/json/" + ip);
                            request.Method = "POST";
                            request.ContentType = "application/json";

                            WebResponse webResponse = request.GetResponse();
                            Stream webStream = webResponse.GetResponseStream();
                            StreamReader responseReader = new StreamReader(webStream);
                            string response = responseReader.ReadToEnd();
                            response = "{Table1: [" + response + "]}";
                            DataSet IPdetail = JsonConvert.DeserializeObject<DataSet>(response);
                            // Console.Out.WriteLine(response);
                            responseReader.Close();

                            //Saving App downloading logs
                            AppDownloadingLogs_new(
                                Convert.ToInt32(ds.Tables[0].Rows[0]["principalid"]),

                                token, ip, IPdetail.Tables[0].Rows[0]["country"].ToString(),
                                IPdetail.Tables[0].Rows[0]["regionName"].ToString(),
                                IPdetail.Tables[0].Rows[0]["city"].ToString(),
                                IPdetail.Tables[0].Rows[0]["as"].ToString(),
                                data.IMEI
                                );





                            res.data = login;
                            res.Message = "Success";
                            settings.NullValueHandling = NullValueHandling.Ignore;
                            json = JsonConvert.SerializeObject(res, settings);



                        }
                        else
                        {
                            res.Status = false;
                            res.Message = "Invalid Credentials";


                            settings.NullValueHandling = NullValueHandling.Ignore;
                            json = JsonConvert.SerializeObject(res, settings);
                        }

                    }
                    catch (Exception ex)
                    {
                        res.Status = false;
                        res.Message = ex.Message;

                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(res, settings);

                    }


                }
            }
            
            return json;
        }

        public void AppDownloadingLogs_new(int studentid, string token, string ip_address, string country, string state, string city, string address, string deviceIMEI)
        {
            MantainLoginLog obj = new MantainLoginLog();
            DataSet ds = new DataSet();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                MySqlCommand cmd = new MySqlCommand("SavePrincipalLog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("principalid_d", studentid);
                cmd.Parameters.AddWithValue("token_d", token);
                cmd.Parameters.AddWithValue("ip_d", ip_address);
                cmd.Parameters.AddWithValue("country_d", country);
                cmd.Parameters.AddWithValue("state_d", state);
                cmd.Parameters.AddWithValue("city_d", city);
                cmd.Parameters.AddWithValue("address_d", address);
                cmd.Parameters.AddWithValue("imei_d", deviceIMEI);

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();
            }
            catch (Exception ex)
            {

            }
        }


        //API for guideline video and pdf
        [HttpGet]
        [Route("GetGuidelineVideoPDF")]
        public IActionResult GetGuidelineVideoPDF([FromHeader] GetGuidelineData data)
        {
            DataSet ds = new DataSet();
            string json = "";

            ShowGuidelineResponse CountryRes = new ShowGuidelineResponse();
            ShowGuidelineDetail objcountry = new ShowGuidelineDetail();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                MySqlCommand cmd = new MySqlCommand("getvideopdf_new", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("pageid_d", data.pageid);
                cmd.Parameters.AddWithValue("languageid_d", data.languageid);
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    CountryRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        objcountry.video = Convert.ToString(row["url"]);
                        objcountry.originalfilename = Convert.ToString(row["orgfilename"]);

                        objcountry.pdf = "http://admin.careerprabhu.com/" + "masterupload/" + Convert.ToString(row["pdf"]);
                    }

                    CountryRes.data = objcountry;
                    CountryRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CountryRes, settings);
                }
                else
                {
                    CountryRes.status = false;
                    CountryRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CountryRes, settings);

                }

            }
            catch (Exception ex)
            {

                CountryRes.status = false;
                CountryRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(CountryRes, settings);

            }

            return Ok(json);
        }



        [HttpGet]
        [Route("GetTestDetail")]
        public IActionResult GetTestDetail([FromHeader] GetTestData data)
        {
            DataSet ds = new DataSet();
            string json = "";

            GetTestResponse CountryRes = new GetTestResponse();
            GetTestDetail objcountry = new GetTestDetail();

            if(data.studentid ==0 || data.classid == 0)
            {
                CountryRes.status = false;
                CountryRes.message = "Invalid Parameter";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(CountryRes, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("GetTestDetail_Student", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("studentid_d", data.studentid);
                    cmd.Parameters.AddWithValue("classid_d", data.classid);
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                    if (ds.Tables.Count > 0)
                    //if (ds.Tables[0].Rows.Count > 0)
                    {
                        CountryRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            objcountry.studentname = Convert.ToString(row["studentname"]);
                            objcountry.classid = Convert.ToInt32(row["class"]);
                            objcountry.classname = Convert.ToString(row["classname"]);
                            objcountry.cityid = Convert.ToInt32(row["cityid"]);
                            objcountry.cityname = Convert.ToString(row["cityname"]);
                            objcountry.schoolid = Convert.ToInt32(row["schoolid"]);
                            objcountry.schoolname = Convert.ToString(row["schoolname"]);
                            objcountry.stateid = Convert.ToInt32(row["stateid"]);
                            objcountry.statename = Convert.ToString(row["statename"]);
                            objcountry.email = Convert.ToString(row["email"]);
                            objcountry.mobileno = Convert.ToString(row["mobile"]);
                            objcountry.referby = Convert.ToString(row["refer"]);

                        }
                        foreach (DataRow row in ds.Tables[1].Rows)
                        {

                            objcountry.actualprice = Convert.ToDecimal(row["coursefees"]);
                            objcountry.conveniencefeed = Convert.ToDecimal(row["conveinencefees"]);
                            objcountry.cgst = Convert.ToDecimal(row["cgst_percentage"]);
                            objcountry.sgst = Convert.ToDecimal(row["sgst"]);
                            objcountry.amounttobepaid = Convert.ToDecimal(row["amounttobepaid"]);
                        }
                        foreach (DataRow row in ds.Tables[2].Rows)
                        {

                            objcountry.isstatus = Convert.ToString(row["status"]);
                            objcountry.paymentstatus = Convert.ToInt32(row["stu_paystatus"]);
                           
                        }



                        CountryRes.data = objcountry;
                        CountryRes.message = "Success";

                        if (objcountry.isstatus == "failure")
                        {
                            CountryRes.Link = "";
                        }
                        else
                        {
                            CountryRes.Link = "https://www.wonderskool.com/services/taketest_app?student_id=" + data.studentid;
                        }
                            
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(CountryRes, settings);
                    }
                    else
                    {
                        CountryRes.status = false;
                        CountryRes.message = "No Data Found";
                        
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(CountryRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    CountryRes.status = false;
                    CountryRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CountryRes, settings);

                }

            }

            return Ok(json);
        }

        [HttpPost]
        [Route("PayNow")]
        public IActionResult PayNow([FromBody] SavePaymentInfo data)
        {

            TestResponse stures = new TestResponse();
            TestData testdt = new TestData();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string guid_d =Guid.NewGuid().ToString();
            Random generator = new Random();

            String otp = generator.Next(100000, 1000000).ToString("D6") + guid_d;
            string json = "";
            string result = "";
            if (data.studentid==0)
            {
                stures.status = false;
                
                stures.message = "Invalid DraftID Or VersionID";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(stures, settings);
            }
            else
            {
                try
                {

                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("PaymentTest", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("studentid_d", data.studentid);
                    cmd.Parameters.AddWithValue("guid_d", otp);
                    cmd.Parameters.AddWithValue("receiptno_d", 0);
                    cmd.Parameters.AddWithValue("amount_d", 0);
                    cmd.Parameters.AddWithValue("paymentid_d", "");
                    cmd.Parameters.AddWithValue("status_d", "");
                    cmd.Parameters.AddWithValue("paystatus_d", 0);
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;

                    da.Fill(ds);
                    con.Close();


                      
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                        stures.status = true;

                        foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                testdt.uniqueid = Convert.ToString(row["txn_id"]);
                                testdt.studentid = Convert.ToInt32(row["stu_id"]);

                            }


                            stures.data = testdt;
                            stures.message = "Success";
                          
                            settings.NullValueHandling = NullValueHandling.Ignore;
                            json = JsonConvert.SerializeObject(stures, settings);
                        }
                        else
                        {
                            stures.status = false;

                            stures.message = "No Data Found";


                            settings.NullValueHandling = NullValueHandling.Ignore;
                            json = JsonConvert.SerializeObject(stures, settings);
                        }

                  

                }
                catch (Exception e)
                {
                    stures.status = false;
                    stures.data = new TestData();
                    stures.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);

                }
            }

            return Ok(json);
        }


        [HttpPost]
        [Route("PaymentStatus")]
        public IActionResult PaymentStatus([FromBody] SavePaymentStatusInfo data)
        {

            TestResponse stures = new TestResponse();
            TestData testdt = new TestData();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string guid_d = Guid.NewGuid().ToString();
            Random generator = new Random();
            string receiptno = "CP-20-" + generator.Next(100000, 1000000).ToString("D6");
            String otp = generator.Next(100000, 1000000).ToString("D6") + guid_d;
            string json = "";
            string result = "";
            if (data.studentid == 0 ||data.status=="" || data.amount==0 || data.paymentid =="" || data.uniqueid =="")
            {
                stures.status = false;

                stures.message = "Invalid Parameter";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(stures, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("updatepaymentstatus", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("studentid_d", data.studentid);
                    cmd.Parameters.AddWithValue("guid_d", data.uniqueid);
                    cmd.Parameters.AddWithValue("receiptno_d", receiptno);
                    cmd.Parameters.AddWithValue("amount_d", data.amount);
                    cmd.Parameters.AddWithValue("paymentid_d", data.paymentid);
                    cmd.Parameters.AddWithValue("status_d", data.status);
                    cmd.Parameters.AddWithValue("paystatus_d", data.status == "Success" ? 1 : 0);
                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();

                    if(result == "Success")
                    {
                        stures.status = true;
                 
                        stures.message = "Success";







                        //stures.link = "https://www.wonderskool.com/services/taketest_app?student_id=" + data.studentid;
                        //stures.paymentstatus = 1;

                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }
                    else
                    {
                        stures.status = false;
       
                        stures.message = "Something Went Wrong";
                        //stures.link = "";
                        //stures.paymentstatus = 0;
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }


                }
                catch (Exception e)
                {
                    stures.status = false;
             
                    stures.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);

                }
            }

            return Ok(json);
        }

        [HttpGet]
        [Route("GetTestStatusReport")]
        public IActionResult GetTestStatusReport([FromHeader] GetTestStatusData data)
        {
            DataSet ds = new DataSet();
            string json = "";

            GetTestStatusResponse CountryRes = new GetTestStatusResponse();
            List<GetTestStatusDetail> objclass = new List<GetTestStatusDetail>();
            GetTestPercentageDetail objcountry = new GetTestPercentageDetail();

                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("TestStatusReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("schoolid_d", data.schoolid);
                    cmd.Parameters.AddWithValue("classid_d", data.classid);
                cmd.Parameters.AddWithValue("streamid_d", data.streamid);
                cmd.Parameters.AddWithValue("academicyear_d", data.academicyear == null ? "": data.academicyear) ;
                con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                    if (ds.Tables.Count > 0)
                    //if (ds.Tables[0].Rows.Count > 0)
                    {
                        CountryRes.status = true;
                    foreach (DataRow row in ds.Tables[1].Rows)
                    {
                        GetTestStatusDetail gettest = new GetTestStatusDetail();
                        gettest.studentname = Convert.ToString(row["stu_name"]);
                        gettest.classname = Convert.ToString(row["class_name"]);
                        gettest.streamname = Convert.ToString(row["Stream_Name"]);
                        gettest.emali = Convert.ToString(row["stu_username"]);
                        objclass.Add(gettest);
                    }
                    
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {

                            objcountry.attendpercentage = Convert.ToDecimal(row["attendper"]);
                            objcountry.pendingpercentage = Convert.ToDecimal(row["pendingper"]);
                          
                        }

                        CountryRes.data = objclass;
                    CountryRes.data1 = objcountry;
                    CountryRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(CountryRes, settings);
                    }
                    else
                    {
                        CountryRes.status = false;
                        CountryRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(CountryRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    CountryRes.status = false;
                    CountryRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CountryRes, settings);

                }

            

            return Ok(json);
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("GetTestStatusReport_Download")]
        public IActionResult GetTestStatusReport_Download([FromHeader] GetTestStatusData data)
        {
            DataSet ds = new DataSet();
            string json = "";

            GetTestStatusResponse CountryRes = new GetTestStatusResponse();
            List<GetTestStatusDetail> objclass = new List<GetTestStatusDetail>();
            GetTestPercentageDetail objcountry = new GetTestPercentageDetail();

            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                MySqlCommand cmd = new MySqlCommand("TestStatusReport", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("schoolid_d", data.schoolid);
                cmd.Parameters.AddWithValue("classid_d", data.classid);
                cmd.Parameters.AddWithValue("streamid_d", data.streamid);
                cmd.Parameters.AddWithValue("academicyear_d", data.academicyear == null ? "" : data.academicyear);
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        //var stream = new MemoryStream();

                        byte[] fileContents;
                        using (var package = new ExcelPackage())
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Logs");

                            int totalRows = ds.Tables[1].Rows.Count;
                            worksheet.Row(1).Height = 20;
                            worksheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            worksheet.Row(1).Style.Font.Bold = true;
                            worksheet.Row(1).Style.Font.Color.SetColor(System.Drawing.Color.Blue);
                            worksheet.Cells[1, 1, 1, 5].Merge = true;
                            worksheet.Cells[1, 1, 1, 5].Value = "All Log Report";
                            worksheet.Cells[2, 1].Value = "Student Name";
                            worksheet.Cells[2, 2].Value = "Email";
                            worksheet.Cells[2, 3].Value = "Class";
                            worksheet.Cells[2, 4].Value = "Stream";
                            

                            int i = 0;
                            for (int row = 3; row <= totalRows + 2; row++)
                            {

                                worksheet.Cells[row, 1].Value = i + 1;
                                worksheet.Cells[row, 2].Value = ds.Tables[1].Rows[i]["stu_name"];
                                worksheet.Cells[row, 3].Value = ds.Tables[1].Rows[i]["stu_username"];
                                worksheet.Cells[row, 4].Value = ds.Tables[1].Rows[i]["class_name"];
                                worksheet.Cells[row, 5].Value = ds.Tables[1].Rows[i]["Stream_Name"];
                                i++;
                            }
                            fileContents = package.GetAsByteArray();
                        }
                        ///stream.Position = 0;
                        string excelName = $"Pending Stuent List-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

                        //return File(stream, "application/octet-stream", excelName);  
                        // Stream newstream = File(stream, "application/octet-stream", excelName);


                        FileStreamResult fileStreamResult;
                        Stream stream = new MemoryStream(fileContents);

                        //ZipFile.CreateFromDirectory(uploadDirectory, zipPath, System.IO.Compression.CompressionLevel.Fastest, false);
                        //FileStream fileStreamInput = new FileStream(stream, FileMode.Open, FileAccess.Read, FileShare.Delete);
                        fileStreamResult = new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                        fileStreamResult.FileDownloadName = excelName;
                        return fileStreamResult;


                        //return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);


                    }
                    else
                    {
                        return Ok();
                    }
                }
                else
                {
                    return Ok();
                }

            }
            
            catch (Exception ex)
            {

            }


            return Ok();

        }


        [HttpGet]
        [Route("GetSelfAnalysisData")]
        public IActionResult GetSelfAnalysisData([FromHeader] GetSelfAnalysis data)

        {
            DataSet ds = new DataSet();
            string json = "";

            SelfAnalysisResponse EssayRes = new SelfAnalysisResponse();
            SelfAnalysisDetail objessay = new SelfAnalysisDetail();


            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("GetAnalysisReport", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("classid_d", data.classid);
                cmd.Parameters.AddWithValue("streamid_d", data.streamid);

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables.Count > 0)
                {

                    EssayRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                   
                        objessay.description = Convert.ToString(row["description"]);
                        objessay.instruction = Convert.ToString(row["instruction"]);

                    }

                    EssayRes.data = objessay;
                    EssayRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EssayRes, settings);
                }
                else
                {
                    EssayRes.status = false;
                    EssayRes.message = "Something went wrong";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EssayRes, settings);

                }

            }
            catch (Exception ex)
            {

                EssayRes.status = false;
                EssayRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(EssayRes, settings);

            }

            return Ok(json);
        }


        [HttpGet]
        [Route("GetCollegeRepositoryData")]
        public IActionResult GetCollegeRepositoryData([FromHeader] GetCollegeData data)
        {
            DataSet ds = new DataSet();
            string json = "";

            CollegeRepositoryResponse EssayRes = new CollegeRepositoryResponse();
            List<CollegRepositoryDetail> objessay = new List<CollegRepositoryDetail>();
            if (data.listingid == 0)
            {
                EssayRes.status = false;
                EssayRes.message = "Invalid Parameter";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(EssayRes, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                    MySqlCommand cmd = new MySqlCommand("GetCollegeList_new", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("careerid_d", data.listingid);
                    cmd.Parameters.AddWithValue("languageid_d", data.languageid);
                    cmd.Parameters.AddWithValue("countryid_d", data.countryid);
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        EssayRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            CollegRepositoryDetail objcol = new CollegRepositoryDetail();
                            objcol.collegename = Convert.ToString(row["collegename"]);
                            objcol.description = Convert.ToString(row["description"]);
                            if (Convert.ToString(row["image"]) == "")
                            {
                                objcol.image = "";
                            }
                            else
                            {
                                objcol.image = "http://admin.careerprabhu.com/" + "uploadimages/" + Convert.ToString(row["image"]);
                            }
                            objcol.videolink = Convert.ToString(row["videourl"]);
                            objessay.Add(objcol);
                        }

                        EssayRes.data = objessay;
                        EssayRes.message = "Success";
                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(EssayRes, settings);
                    }
                    else
                    {
                        EssayRes.status = false;
                        EssayRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(EssayRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    EssayRes.status = false;
                    EssayRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EssayRes, settings);

                }
            }
            

            return Ok(json);
        }


        [HttpGet]
        [Route("GetPremiumProductDetail")]
        public IActionResult GetPremiumProductDetail([FromHeader] GetPremiumData data)
        {
            DataSet ds = new DataSet();
            string json = "";

            GetPremiumResponse CountryRes = new GetPremiumResponse();
            GetPremiumDetail objcountry = new GetPremiumDetail();
            List<GetPremiumTestimonialsDetail> objpremium = new List<GetPremiumTestimonialsDetail>();
            GetPremiumVideoPdfDetail vidpdf = new GetPremiumVideoPdfDetail();

            if (data.productid == 0 || data.classid == 0 || data.studentid==0 || data.languageid==0)
            {
                CountryRes.status = false;
                CountryRes.message = "Invalid Parameter";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(CountryRes, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("GetPremiumProductDetail_updated", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("productid_d", data.productid);
                    cmd.Parameters.AddWithValue("classid_d", data.classid);
                    cmd.Parameters.AddWithValue("studentid_d", data.studentid);
                    cmd.Parameters.AddWithValue("languageid_d", data.languageid);
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                    if (ds.Tables.Count > 0)
                    //if (ds.Tables[0].Rows.Count > 0)
                    {
                        CountryRes.status = true;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            objcountry.actualprice = Convert.ToDecimal(row["fees"]);
                            objcountry.conveniencefees = Convert.ToDecimal(row["conveniencefees"]);
                            
                            objcountry.gst = Convert.ToDecimal(row["gst"]);
                            objcountry.amounttobepaid = Convert.ToDecimal(row["totalamount"]);

                            objcountry.gstamount = Convert.ToDecimal(row["gstamount"]);




                            objcountry.discountpercentage = 0;
                            objcountry.couponname = "";

                            objcountry.discountamount = 0;
                            objcountry.amountafterdiscount = Convert.ToDecimal(row["fees"]);


                        }


                        foreach (DataRow row in ds.Tables[1].Rows)
                            {
                                GetPremiumTestimonialsDetail objpremiumlist = new GetPremiumTestimonialsDetail();
                                objpremiumlist.name = Convert.ToString(row["NAME"]);
                                objpremiumlist.description = Convert.ToString(row["description"]);
                                objpremiumlist.link = Convert.ToString(row["orgvideoname"]);
                                if (Convert.ToString(row["image"]) == "")
                                {
                                    objpremiumlist.image = "";
                                }
                                else
                                {
                                //objpremiumlist.image = "http://admin.careerprabhu.com/" + "SOP/" + "primiumbanner.png";
                                objpremiumlist.image = "http://admin.careerprabhu.com/" + "uploadimages/" + Convert.ToString(row["image"]);
                                }

                            if (Convert.ToString(row["profilephoto"]) == "")
                            {
                                objpremiumlist.profilephoto = "";
                            }
                            else
                            {
                                //objpremiumlist.image = "http://admin.careerprabhu.com/" + "SOP/" + "primiumbanner.png";
                                objpremiumlist.profilephoto = "http://admin.careerprabhu.com/" + "uploadimages/" + Convert.ToString(row["profilephoto"]);
                            }

                            objpremiumlist.testimonials = Convert.ToString(row["testimonial"]);

                                objpremium.Add(objpremiumlist);
                            }


                       


                        foreach (DataRow row in ds.Tables[2].Rows)
                        {
                            if(Convert.ToInt32(row["paidstatus"]) == 0)
                            {
                                CountryRes.paidstatus = 0;
                            }
                            else
                            {
                                CountryRes.paidstatus = 1;
                            }
                        }
                        foreach (DataRow row in ds.Tables[3].Rows)
                        {
                            vidpdf.videolink = Convert.ToString(row["videolink"]);

                            vidpdf.pdffile = "http://admin.careerprabhu.com/" + "masterupload/" + Convert.ToString(row["docname"]);

                        }

                        foreach (DataRow row in ds.Tables[4].Rows)
                        {
                            vidpdf.productdescription = Convert.ToString(row["productdescription"]);

                           

                        }

                        CountryRes.data = objcountry;
                        CountryRes.data1 = objpremium;
                        CountryRes.data2 = vidpdf;
                        CountryRes.message = "Success";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(CountryRes, settings);
                    }
                    else
                    {
                        CountryRes.status = false;
                        CountryRes.message = "No Data Found";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(CountryRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    CountryRes.status = false;
                    CountryRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CountryRes, settings);

                }

            }

            return Ok(json);
        }


        [HttpPost]
        [Route("PremiumProductPayNow")]
        public IActionResult PremiumProductPayNow([FromBody] SavePremiumPaymentInfo data)
        {

            PremiumProductResponse stures = new PremiumProductResponse();
            PremimProductData testdt = new PremimProductData();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string guid_d = Guid.NewGuid().ToString();
            Random generator = new Random();

            String otp = generator.Next(100000, 1000000).ToString("D6") + guid_d;
            string json = "";
            string result = "";
            if (data.studentid == 0 || data.productid==0)
            {
                stures.status = false;

                stures.message = "Invalid Parameter";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(stures, settings);
            }
            else
            {
                try
                {

                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("PaymentPremium", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("studentid_d", data.studentid);
                    cmd.Parameters.AddWithValue("guid_d", otp);
                    cmd.Parameters.AddWithValue("receiptno_d", 0);
                    cmd.Parameters.AddWithValue("amount_d", 0);
                    cmd.Parameters.AddWithValue("paymentid_d", "");
                    cmd.Parameters.AddWithValue("status_d", "");
                    cmd.Parameters.AddWithValue("paystatus_d", 0);
                    cmd.Parameters.AddWithValue("productid_d", data.productid);
                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;

                    da.Fill(ds);
                    con.Close();



                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        stures.status = true;

                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            testdt.uniqueid = Convert.ToString(row["txn_id"]);
                            testdt.studentid = Convert.ToInt32(row["stu_id"]);

                        }


                        stures.data = testdt;
                        stures.message = "Success";

                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }
                    else
                    {
                        stures.status = false;

                        stures.message = "No Data Found";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }



                }
                catch (Exception e)
                {
                    stures.status = false;
                    stures.data = new PremimProductData();
                    stures.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);

                }
            }

            return Ok(json);
        }

        [HttpPost]
        [Route("PremiumPaymentStatus")]
        public IActionResult PremiumPaymentStatus([FromBody] SavePaymentStatusInfo data)
        {

            string mobiles = "";
            TestResponse stures = new TestResponse();
            TestData testdt = new TestData();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string guid_d = Guid.NewGuid().ToString();
            Random generator = new Random();
            string receiptno = "CP-20-" + generator.Next(100000, 1000000).ToString("D6");
            String otp = generator.Next(100000, 1000000).ToString("D6") + guid_d;
            string json = "";
            string result = "";
            if (data.studentid == 0 || data.status == "" || data.amount == 0 || data.paymentid == "" || data.uniqueid == "")
            {
                stures.status = false;

                stures.message = "Invalid Parameter";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(stures, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("updatepremiumpaymentstatus", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("studentid_d", data.studentid);
                    cmd.Parameters.AddWithValue("guid_d", data.uniqueid);
                    cmd.Parameters.AddWithValue("receiptno_d", receiptno);
                    cmd.Parameters.AddWithValue("amount_d", data.amount);
                    cmd.Parameters.AddWithValue("paymentid_d", data.paymentid);
                    cmd.Parameters.AddWithValue("status_d", data.status);
                    cmd.Parameters.AddWithValue("paystatus_d", data.status == "success" ? 1 : 0);
                    con.Open();
                    cmd.ExecuteScalar();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;

                    da.Fill(ds);
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();

                    if (result == "Success" && data.status == "success")
                    {
                        stures.status = true;

                        stures.message = "Payment Successful";



                        DataSet ds2 = new DataSet();
                        try
                        {
                            MySqlCommand cmd1 = new MySqlCommand("GetEmailSms_career_notification", con);
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("studentid_d", data.studentid);
                            cmd1.Parameters.AddWithValue("guid_d", data.uniqueid);


                            con.Open();
                            MySqlDataAdapter da1 = new MySqlDataAdapter();
                            da1.SelectCommand = cmd1;
                            da1.Fill(ds2);
                            con.Close();
                            string _Message = ds2.Tables[0].Rows[0]["adminmsg"].ToString();
                            string frommail = ds2.Tables[1].Rows[0]["stu_username"].ToString();
                            string pwd = ds2.Tables[1].Rows[0]["stu_password"].ToString();


                            _Message = _Message.Replace("@studentname", ds2.Tables[1].Rows[0]["stu_name"].ToString());
                            _Message = _Message.Replace("@class", ds2.Tables[1].Rows[0]["class_name"].ToString());
                            _Message = _Message.Replace("@stream", ds2.Tables[1].Rows[0]["stream_name"].ToString());
                            _Message = _Message.Replace("@state", ds2.Tables[1].Rows[0]["state_name"].ToString());
                            _Message = _Message.Replace("@city", ds2.Tables[1].Rows[0]["city_name"].ToString());
                            _Message = _Message.Replace("@school", ds2.Tables[1].Rows[0]["schoolname"].ToString());
                            _Message = _Message.Replace("@email", ds2.Tables[1].Rows[0]["stu_username"].ToString());
                            _Message = _Message.Replace("@mobile", ds2.Tables[1].Rows[0]["stu_mobile"].ToString());
                            _Message = _Message.Replace("@amount", Convert.ToString(data.amount));
                            _Message = _Message.Replace("@product", ds2.Tables[2].Rows[0]["productname"].ToString());
                            _Message = _Message.Replace("@already", ds2.Tables[3].Rows[0]["pr"].ToString());

                            SendMail2("CareerPrabhu Student Payment Detail", frommail, "", _Message, pwd);





                        }
                        catch (Exception e)
                        {
                            string mmm = e.Message;
                        }












                        DataSet ds1 = new DataSet();
                        try
                        {
                            MySqlCommand cmd1 = new MySqlCommand("GetProductEmailSms_career", con);
                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("prodid_d", Convert.ToInt32(ds1.Tables[0].Rows[0]["productid"].ToString()));

                            con.Open();
                            MySqlDataAdapter da1 = new MySqlDataAdapter();
                            da1.SelectCommand = cmd1;
                            da1.Fill(ds1);
                            con.Close();
                            
                            string _sms = ds1.Tables[0].Rows[0]["sms"].ToString();
                            if (ds.Tables[0].Rows[0]["stu_mobile"].ToString() != "")
                            {
                             
                                if (ds.Tables[0].Rows[0]["stu_mobile"].ToString().Length >= 1)
                                {
                                    if (ds.Tables[0].Rows[0]["stu_mobile"].ToString() != "")
                                    {
                                        mobiles += "," + ds.Tables[0].Rows[0]["stu_mobile"].ToString() + "";
                                    }
                                    if (ds.Tables[0].Rows[0]["stu_mobile"].ToString() != "")
                                    {
                                        mobiles += "," + ds.Tables[0].Rows[0]["stu_mobile"].ToString() + "";
                                    }
                                    SendSMS(mobiles, _sms);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            string mmm = e.Message;
                        }




                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }
                    else
                    {
                        stures.status = false;
                        stures.message = "Payment Failed";                      
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }


                }
                catch (Exception e)
                {
                    stures.status = false;

                    stures.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);

                }
            }

            return Ok(json);
        }


        [HttpGet]
        [Route("GetLoginStatusReport")]
        public IActionResult GetLoginStatusReport([FromHeader] GetTestStatusData data)
        {
            DataSet ds = new DataSet();
            string json = "";

            GetTestStatusResponse CountryRes = new GetTestStatusResponse();
            List<GetTestStatusDetail> objclass = new List<GetTestStatusDetail>();
            GetTestPercentageDetail objcountry = new GetTestPercentageDetail();

            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                MySqlCommand cmd = new MySqlCommand("LoginStatusReport", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("schoolid_d", data.schoolid);
                cmd.Parameters.AddWithValue("classid_d", data.classid);
                cmd.Parameters.AddWithValue("streamid_d", data.streamid);
                cmd.Parameters.AddWithValue("academicyear_d", data.academicyear == null ? "" : data.academicyear);
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();
                if (ds.Tables.Count > 0)
                //if (ds.Tables[0].Rows.Count > 0)
                {
                    CountryRes.status = true;
                    foreach (DataRow row in ds.Tables[1].Rows)
                    {
                        GetTestStatusDetail gettest = new GetTestStatusDetail();
                        gettest.studentname = Convert.ToString(row["stu_name"]);
                        gettest.classname = Convert.ToString(row["class_name"]);
                        gettest.streamname = Convert.ToString(row["Stream_Name"]);
                        gettest.emali = Convert.ToString(row["stu_username"]);
                        objclass.Add(gettest);
                    }

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {

                        objcountry.attendpercentage = Convert.ToDecimal(row["attendper"]);
                        objcountry.pendingpercentage = Convert.ToDecimal(row["pendingper"]);

                    }

                    CountryRes.data = objclass;
                   // CountryRes.data1 = objcountry;
                    CountryRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CountryRes, settings);
                }
                else
                {
                    CountryRes.status = false;
                    CountryRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CountryRes, settings);

                }

            }
            catch (Exception ex)
            {

                CountryRes.status = false;
                CountryRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(CountryRes, settings);

            }



            return Ok(json);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetLoginStatusReport_Download")]
        public IActionResult GetLoginStatusReport_Download([FromHeader] GetTestStatusData data)
        {
            DataSet ds = new DataSet();
            string json = "";

            GetTestStatusResponse CountryRes = new GetTestStatusResponse();
            List<GetTestStatusDetail> objclass = new List<GetTestStatusDetail>();
            GetTestPercentageDetail objcountry = new GetTestPercentageDetail();

            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                MySqlCommand cmd = new MySqlCommand("LoginStatusReport", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("schoolid_d", data.schoolid);
                cmd.Parameters.AddWithValue("classid_d", data.classid);
                cmd.Parameters.AddWithValue("streamid_d", data.streamid);
                cmd.Parameters.AddWithValue("academicyear_d", data.academicyear == null ? "" : data.academicyear);
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        //var stream = new MemoryStream();

                        byte[] fileContents;
                        using (var package = new ExcelPackage())
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Logs");

                            int totalRows = ds.Tables[1].Rows.Count;
                            worksheet.Row(1).Height = 20;
                            worksheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            worksheet.Row(1).Style.Font.Bold = true;
                            worksheet.Row(1).Style.Font.Color.SetColor(System.Drawing.Color.Blue);
                            worksheet.Cells[1, 1, 1, 5].Merge = true;
                            worksheet.Cells[1, 1, 1, 5].Value = "All Log Report";
                            worksheet.Cells[2, 1].Value = "Student Name";
                            worksheet.Cells[2, 2].Value = "Email";
                            worksheet.Cells[2, 3].Value = "Class";
                            worksheet.Cells[2, 4].Value = "Stream";


                            int i = 0;
                            for (int row = 3; row <= totalRows + 2; row++)
                            {

                                worksheet.Cells[row, 1].Value = i + 1;
                                worksheet.Cells[row, 2].Value = ds.Tables[1].Rows[i]["stu_name"];
                                worksheet.Cells[row, 3].Value = ds.Tables[1].Rows[i]["stu_username"];
                                worksheet.Cells[row, 4].Value = ds.Tables[1].Rows[i]["class_name"];
                                worksheet.Cells[row, 5].Value = ds.Tables[1].Rows[i]["Stream_Name"];
                                i++;
                            }
                            fileContents = package.GetAsByteArray();
                        }
                        ///stream.Position = 0;
                        string excelName = $"Pending Login Stuent List-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

                        //return File(stream, "application/octet-stream", excelName);  
                        // Stream newstream = File(stream, "application/octet-stream", excelName);


                        FileStreamResult fileStreamResult;
                        Stream stream = new MemoryStream(fileContents);

                        //ZipFile.CreateFromDirectory(uploadDirectory, zipPath, System.IO.Compression.CompressionLevel.Fastest, false);
                        //FileStream fileStreamInput = new FileStream(stream, FileMode.Open, FileAccess.Read, FileShare.Delete);
                        fileStreamResult = new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                        fileStreamResult.FileDownloadName = excelName;
                        return fileStreamResult;


                        //return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);


                    }
                    else
                    {
                        return Ok();
                    }
                }
                else
                {
                    return Ok();
                }

            }

            catch (Exception ex)
            {

            }


            return Ok();

        }


        [HttpGet]
        
        [Route("FAQList")]
        public IActionResult FAQList([FromHeader] GetFaqANS data)
        {
            DataSet ds = new DataSet();
            string json = "";

            FAQResponse StateRes = new FAQResponse();
            List<FAQDetail> objstate = new List<FAQDetail>();
            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("GetFAQ_new", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("career_d", data.career);
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {

                    StateRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        FAQDetail objlist = new FAQDetail();
                        objlist.faq = Convert.ToString(row["faq"]);
                        objlist.faqid = Convert.ToInt32(row["faqid"]);
                        objlist.answer = Convert.ToString(row["answer"]);
                        objstate.Add(objlist);
                    }

                    StateRes.data = objstate;
                    StateRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(StateRes, settings);
                }
                else
                {
                    StateRes.status = false;
                    StateRes.message = "No Data Found";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(StateRes, settings);

                }

            }
            catch (Exception ex)
            {

                StateRes.status = false;
                StateRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(StateRes, settings);

            }

            return Ok(json);
        }


        [HttpGet]
        [Route("GetFAQAnswer")]
        public IActionResult GetFAQAnswer([FromHeader] GetFaqANS data)

        {
            DataSet ds = new DataSet();
            string json = "";

            FAQAnsResponse EssayRes = new FAQAnsResponse();
            FAQAnsDetail objessay = new FAQAnsDetail();


            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("GetFaqAnswer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("faqid_d", data.faqid);
                

                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables.Count > 0)
                {

                    EssayRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {

                        objessay.faqid = Convert.ToInt32(row["faqid"]);
                        objessay.answer = Convert.ToString(row["answer"]);

                    }

                    EssayRes.data = objessay;
                    EssayRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EssayRes, settings);
                }
                else
                {
                    EssayRes.status = false;
                    EssayRes.message = "Something went wrong";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EssayRes, settings);

                }

            }
            catch (Exception ex)
            {

                EssayRes.status = false;
                EssayRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(EssayRes, settings);

            }

            return Ok(json);
        }


        [HttpGet]
        [Route("ReportAns")]
        public IActionResult ReportAns([FromHeader] GetFaqANS data)

        {
            DataSet ds = new DataSet();
            string json = "";

            FAQReportResponse EssayRes = new FAQReportResponse();
            FAQReportDetail objessay = new FAQReportDetail();


            try
            {
                MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


                MySqlCommand cmd = new MySqlCommand("GetReportAnswer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("faqid_d", data.faqid);


                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                con.Close();


                if (ds.Tables.Count > 0)
                {

                    EssayRes.status = true;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {

                        objessay.faqid = Convert.ToInt32(row["faqid"]);
                        objessay.answer = Convert.ToString(row["answer"]);
                        objessay.question = Convert.ToString(row["question"]);

                    }

                    EssayRes.data = objessay;
                    EssayRes.message = "Success";
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EssayRes, settings);
                }
                else
                {
                    EssayRes.status = false;
                    EssayRes.message = "Something went wrong";

                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(EssayRes, settings);

                }

            }
            catch (Exception ex)
            {

                EssayRes.status = false;
                EssayRes.message = ex.Message;
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(EssayRes, settings);

            }

            return Ok(json);
        }


        [HttpPost]
        [Route("ReportQuestion")]
        public IActionResult ReportQuestion([FromBody] SaveReportEssay data)
        {

            EssayResponse stures = new EssayResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";


            if (data.faqid == 0 || data.studentid == 0 || data.report == "")
            {
                stures.status = false;
                stures.data = new EssayData();
                stures.message = "Invalid Parametere";


                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(stures, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("savereport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("faqid_d", data.faqid);

                    cmd.Parameters.AddWithValue("studentid_d", data.studentid);
                    cmd.Parameters.AddWithValue("report_d", data.report);
                 



                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();


                    if (result == "Success")
                    {
                        stures.status = true;
                        stures.data = new EssayData();
                        stures.message = "Report Submitted";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }
                    else
                    {
                        stures.status = false;
                        stures.data = new EssayData();
                        stures.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }

                }
                catch (Exception e)
                {
                    stures.status = false;
                    stures.data = new EssayData();
                    stures.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);

                }
            }

            return Ok(json);
        }



        //Feedback section
        //[HttpGet]
        //[Route("GetFeedbackReplay")]
        //public IActionResult GetFeedbackReplay([FromHeader] Query_Stu obj)
        //{
        //    DataSet ds = new DataSet();
        //    string json = "";

        //    GetFeedbackResponse EcpRes = new GetFeedbackResponse();
        //    List<GetFeedbackDetail> objtrans = new List<GetFeedbackDetail>();
        //    if (obj.studentid == 0)
        //    {
        //        EcpRes.status = false;
        //        EcpRes.message = "Invalid StudentID";

        //        JsonSerializerSettings settings = new JsonSerializerSettings();
        //        settings.NullValueHandling = NullValueHandling.Ignore;
        //        json = JsonConvert.SerializeObject(EcpRes, settings);
        //    }
        //    else
        //    {
        //        try
        //        {
        //            MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();


        //            MySqlCommand cmd = new MySqlCommand("GetQueryAns", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("studentid_d", obj.studentid);

        //            con.Open();
        //            MySqlDataAdapter da = new MySqlDataAdapter();
        //            da.SelectCommand = cmd;
        //            da.Fill(ds);
        //            con.Close();


        //            if (ds.Tables[0].Rows.Count > 0)
        //            {

        //                EcpRes.status = true;
        //                foreach (DataRow row in ds.Tables[0].Rows)
        //                {
        //                    GetFeedbackDetail objlist = new GetFeedbackDetail();
        //                    objlist.studentid = Convert.ToInt32(row["stu_id"]);
        //                    objlist.feedbackid = Convert.ToInt32(row["Queryid"]);
        //                    objlist.feedback = Convert.ToString(row["Question"]);
        //                    objlist.feedbackreplay = Convert.ToString(row["Counesellorans"]);



        //                    objtrans.Add(objlist);
        //                }

        //                EcpRes.data = objtrans;
        //                EcpRes.message = "Success";
        //                JsonSerializerSettings settings = new JsonSerializerSettings();
        //                settings.NullValueHandling = NullValueHandling.Ignore;
        //                json = JsonConvert.SerializeObject(EcpRes, settings);
        //            }
        //            else
        //            {
        //                EcpRes.status = false;
        //                EcpRes.message = "No Data Found";

        //                JsonSerializerSettings settings = new JsonSerializerSettings();
        //                settings.NullValueHandling = NullValueHandling.Ignore;
        //                json = JsonConvert.SerializeObject(EcpRes, settings);

        //            }

        //        }
        //        catch (Exception ex)
        //        {

        //            EcpRes.status = false;
        //            EcpRes.message = ex.Message;
        //            JsonSerializerSettings settings = new JsonSerializerSettings();
        //            settings.NullValueHandling = NullValueHandling.Ignore;
        //            json = JsonConvert.SerializeObject(EcpRes, settings);

        //        }
        //    }


        //    return Ok(json);
        //}






        [HttpGet]
        [Route("ApplyPromoCode")]
        public IActionResult ApplyPromoCode([FromHeader] GetPremiumData data)
        {
            DataSet ds = new DataSet();
            string json = "";

            GetPremiumResponse CountryRes = new GetPremiumResponse();
            GetPremiumDetail objcountry = new GetPremiumDetail();
            List<GetPremiumTestimonialsDetail> objpremium = new List<GetPremiumTestimonialsDetail>();
            GetPremiumVideoPdfDetail vidpdf = new GetPremiumVideoPdfDetail();

            if (data.productid == 0 || data.classid == 0 || data.studentid == 0 || data.languageid == 0)
            {
                CountryRes.status = false;
                CountryRes.message = "Invalid Parameter";

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(CountryRes, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("GetPremiumProductDetail_Appliedcoupon_update", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("productid_d", data.productid);
                    cmd.Parameters.AddWithValue("classid_d", data.classid);
                    cmd.Parameters.AddWithValue("studentid_d", data.studentid);
                    cmd.Parameters.AddWithValue("languageid_d", data.languageid);
                    cmd.Parameters.AddWithValue("couponname_d", data.couponname);
                    cmd.Parameters.AddWithValue("key_d", data.key);

                    con.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                    if (ds.Tables.Count > 0)
                    //if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            objcountry.actualprice = Convert.ToDecimal(row["fees"]);
                            objcountry.conveniencefees = Convert.ToDecimal(row["conveniencefees"]);

                            objcountry.gst = Convert.ToDecimal(row["gst"]);
                            objcountry.amounttobepaid = Convert.ToDecimal(row["totalamount"]);
                            objcountry.discountpercentage = Convert.ToInt32(row["disc"]);
                            objcountry.couponname = Convert.ToString(row["cname"]);
                             
                            objcountry.discountamount = Convert.ToDecimal(row["discamt"]);
                            objcountry.amountafterdiscount = Convert.ToDecimal(row["amtbeforediscount"]);


                        }


                        foreach (DataRow row in ds.Tables[1].Rows)
                        {
                            GetPremiumTestimonialsDetail objpremiumlist = new GetPremiumTestimonialsDetail();
                            objpremiumlist.name = Convert.ToString(row["NAME"]);
                            objpremiumlist.description = Convert.ToString(row["description"]);
                            objpremiumlist.link = Convert.ToString(row["orgvideoname"]);
                            if (Convert.ToString(row["image"]) == "")
                            {
                                objpremiumlist.image = "";
                            }
                            else
                            {
                                //objpremiumlist.image = "http://admin.careerprabhu.com/" + "SOP/" + "primiumbanner.png";
                                objpremiumlist.image = "http://admin.careerprabhu.com/" + "uploadimages/" + Convert.ToString(row["image"]);
                            }

                            if (Convert.ToString(row["profilephoto"]) == "")
                            {
                                objpremiumlist.profilephoto = "";
                            }
                            else
                            {
                                //objpremiumlist.image = "http://admin.careerprabhu.com/" + "SOP/" + "primiumbanner.png";
                                objpremiumlist.profilephoto = "http://admin.careerprabhu.com/" + "uploadimages/" + Convert.ToString(row["profilephoto"]);
                            }

                            objpremiumlist.testimonials = Convert.ToString(row["testimonial"]);

                            objpremium.Add(objpremiumlist);
                        }





                        foreach (DataRow row in ds.Tables[2].Rows)
                        {
                            if (Convert.ToInt32(row["paidstatus"]) == 0)
                            {
                                CountryRes.paidstatus = 0;
                            }
                            else
                            {
                                CountryRes.paidstatus = 1;
                            }
                        }
                        foreach (DataRow row in ds.Tables[3].Rows)
                        {
                            vidpdf.videolink = Convert.ToString(row["videolink"]);

                            vidpdf.pdffile = "http://admin.careerprabhu.com/" + "masterupload/" + Convert.ToString(row["docname"]);

                        }

                        foreach (DataRow row in ds.Tables[4].Rows)
                        {
                            vidpdf.productdescription = Convert.ToString(row["productdescription"]);



                        }

                        CountryRes.data = objcountry;
                        CountryRes.data1 = objpremium;
                        CountryRes.data2 = vidpdf;

                        if(data.key == 0 && objcountry.discountamount > 0)
                        {
                            CountryRes.message = "Coupon Applied Successfully.";
                            CountryRes.status = true;


                        }
                        else if(data.key == 0 && (objcountry.discountpercentage <=0 || objcountry.discountamount <=0))
                        {
                            CountryRes.message = "Invalid Coupon Code";
                            CountryRes.status = false;


                        }
                        else
                        {
                            CountryRes.message = "Coupon Removed Successfully.";
                            CountryRes.status = true;


                        }



                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(CountryRes, settings);
                    }
                    else
                    {
                        CountryRes.status = false;
                        CountryRes.message = "Something Went Wrong.";

                        JsonSerializerSettings settings = new JsonSerializerSettings();
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(CountryRes, settings);

                    }

                }
                catch (Exception ex)
                {

                    CountryRes.status = false;
                    CountryRes.message = ex.Message;
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(CountryRes, settings);

                }

            }

            return Ok(json);
        }



        [HttpPost]
        [Route("TraceClickToApplyOrRead")]
        public IActionResult TraceClickToApplyOrRead([FromBody] TracedDate data)
        {

            SavePlacementResponse stures = new SavePlacementResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";
            if (data.studentid == 0 || data.typeid == 0 || data.clickstatus == 0)
            {
                stures.status = false;

                stures.message = "Invalid Parameter";
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(stures, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("savetracedata", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("studentid_d", data.studentid);
                    cmd.Parameters.AddWithValue("type_d", data.typeid);
                    cmd.Parameters.AddWithValue("clickstatus_d", data.clickstatus);
                   

                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();


                    if (result == "Success")
                    {
                        stures.status = true;
                        stures.message = "Report Submitted";
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }
                    else
                    {
                        stures.status = false;

                        stures.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }

                }
                catch (Exception e)
                {
                    stures.status = false;

                    stures.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);

                }
            }

            return Ok(json);
        }


        [HttpPost]
        [Route("TraceMaterialDownloadData")]
        public IActionResult TraceMaterialDownloadData([FromBody] TracedPrepDta data)
        {

            SavePlacementResponse stures = new SavePlacementResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";
            if (data.studentid == 0 || data.typeid == 0 || data.prepid == 0 )
            {
                stures.status = false;

                stures.message = "Invalid Parameter";
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(stures, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("savetraceprepdata", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("studentid_d", data.studentid);
                    cmd.Parameters.AddWithValue("type_d", data.typeid);
                    cmd.Parameters.AddWithValue("prepid_d", data.prepid);


                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();


                    if (result == "Success")
                    {
                        stures.status = true;
                        stures.message = "Report Submitted";
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }
                    else
                    {
                        stures.status = false;

                        stures.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }

                }
                catch (Exception e)
                {
                    stures.status = false;

                    stures.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);

                }
            }

            return Ok(json);
        }


        [HttpPost]
        [Route("TraceSelfAnalysisData")]
        public IActionResult TraceSelfAnalysisData([FromBody] TracedAnalysisData data)
        {

            SavePlacementResponse stures = new SavePlacementResponse();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            DataSet ds = new DataSet();
            string json = "";
            string result = "";
            if (data.studentid == 0 || data.teststatus == 0)
            {
                stures.status = false;

                stures.message = "Invalid Parameter";
                settings.NullValueHandling = NullValueHandling.Ignore;
                json = JsonConvert.SerializeObject(stures, settings);
            }
            else
            {
                try
                {
                    MySqlConnection con = new SoftwareConnection(_iconfiguration).GetConnection();
                    MySqlCommand cmd = new MySqlCommand("savetraceanalysisdata", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("message", "");
                    cmd.Parameters["message"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("studentid_d", data.studentid);
                    cmd.Parameters.AddWithValue("status_d", data.teststatus);


                    con.Open();
                    cmd.ExecuteScalar();
                    result = cmd.Parameters["message"].Value.ToString();
                    con.Close();


                    if (result == "Success")
                    {
                        stures.status = true;
                        stures.message = "Report Submitted";
                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }
                    else
                    {
                        stures.status = false;

                        stures.message = "Something Went Wrong";


                        settings.NullValueHandling = NullValueHandling.Ignore;
                        json = JsonConvert.SerializeObject(stures, settings);
                    }

                }
                catch (Exception e)
                {
                    stures.status = false;

                    stures.message = e.Message;


                    settings.NullValueHandling = NullValueHandling.Ignore;
                    json = JsonConvert.SerializeObject(stures, settings);

                }
            }

            return Ok(json);
        }




    }
    public class GetTestStatusData
    {
        public Int32 schoolid { get; set; }
        public Int32 classid { get; set; }
        public Int32 streamid { get; set; }
        public string academicyear { get; set; }
    }

    public class GetCollegeData
    {
        public Int32 listingid { get; set; }
        public Int32 languageid { get; set; }

        public Int32 countryid { get; set; }

    }
    public class GetPremiumData
    {
        public Int32 productid { get; set; }
        public Int32 classid { get; set; }
        public Int32 studentid { get; set; }
        public Int32 languageid { get; set; }

        public string couponname { get; set; }
        public Int32 key { get; set; }


    }

    public class GetPrincipalLoginData
    {
        public Int32 Login_type { get; set; }
        public string UserName { get; set; } = "";
        public string P_Password { get; set; } = "";
        public Int32 principalid { get; set; }
        public string DeviceType { get; set; } = "";
        public string OsVersion { get; set; } = "";
        public string Lang { get; set; } = "";
        public string IMEI { get; set; } = "";
        public string Token { get; set; } = "";
        public string TokenLoginKey { get; set; } = "";
        public string AppVersion_d { get; set; } = "";


    }
    public class SavePaymentInfo
    {
        
        public string receiptno { get; set; }
        public decimal amount { get; set; }
        public Int32 studentid { get; set; }
        public string paymentid { get; set; }
        public string status { get; set; }
        

    }


    public class SavePremiumPaymentInfo
    {

        public string receiptno { get; set; }
        public decimal amount { get; set; }
        public Int32 studentid { get; set; }
        public Int32 productid { get; set; }
        public string paymentid { get; set; }
        public string status { get; set; }


    }



    public class SavePaymentStatusInfo
    {

       
        public decimal amount { get; set; }
        public Int32 studentid { get; set; }
        public string paymentid { get; set; }
        public string status { get; set; }
        public string uniqueid { get; set; }


    }

    public class GetGuidelineData
    {
        public Int32 pageid { get; set; }
        public Int32 languageid { get; set; }


    }


    public class GetTestData
    {
        public Int32 studentid { get; set; }
        public Int32 classid { get; set; }
    }


    public class GetStudentData
    {
        public Int32 schoolid { get; set; }
        public Int32 stateid { get; set; }
        public Int32 cityid { get; set; }
        public Int32 classid { get; set; }
        public Int32 streamid { get; set; }
    }



    public class GetPremiumStatusStudentData
    {
        public Int32 studentid { get; set; }

    }

    public class Getportfoliodata
    {
        public Int32 countryid { get; set; }
        public Int32 languageid { get; set; }
        public Int32 traitid { get; set; }
        public Int32 subtraitid { get; set; }
        public Int32 stateid { get; set; }
        public Int32 cityid { get; set; }
    }

    public class Getstatedetail
    {
        public Int32 countryid { get; set; }
    }
    public class Getsubtrait
    {
        public Int32 traitid { get; set; }
    }
    public class Getcitydetail
    {
        public Int32 countryid { get; set; }
        public Int32 stateid { get; set; }
    }

    //class for login
    public class GetLoginData
    {
        public Int32 Login_type { get; set; }
        public string UserName { get; set; } = "";
        
        public string P_Password { get; set; } = "";
        public Int32 Student_id { get; set; }
        public string DeviceType { get; set; } = "";
        public string OsVersion { get; set; } = "";
        public string Lang { get; set; } = "";
        public string IMEI { get; set; } = "";
        public string Token { get; set; } = "";
        public string TokenLoginKey { get; set; } = "";
        public string AppVersion_d { get; set; } = "";
        public string Device_token { get; set; } = "";

    }

    //class for mantain login log
    public class MantainLoginLog
    {
       
    
        public Int32 Student_id { get; set; }
        public string ipaddress { get; set; } = "";
        public string IMEI { get; set; } = "";
        public string Token { get; set; } = "";
        public string country { get; set; } = "";
        public string state { get; set; } = "";
        public string city { get; set; } = "";
        public string address { get; set; } = "";


    }

    //classes for api start
    public class getcity
    {
        public Int32 stateid { get; set; }
    }
    public class getschool
    {
        public Int32 stateid { get; set; }
        public Int32 cityid { get; set; }
    }

    //class for registration
    public class StudentRegistration
    {
        public Int32 stu_portalid { get; set; }
        public string stu_name { get; set; }
        public string stu_email { get; set; }
        public string stu_password { get; set; }
        public string mobileno { get; set; }
        public Int32 stu_schoolstate { get; set; }
        public Int32 stu_schoolcity { get; set; }
        public Int32 school_id { get; set; }
        public Int32 stu_class { get; set; }
        public Int32 stu_stream { get; set; }
        public string p_username { get; set; }
        public string p_password { get; set; }

        public string schoolname { get; set; }

        public Int32 language { get; set; }

    }

    //class for get prepratory category 
    public class GetPrepratoryCategory
    {
        public Int32 stu_id { get; set; }
    }

    //class for prepratory category
    public class GetPrepratoryTitle
    {
        public Int32 prepid { get; set; }
        public Int32 classid { get; set; }
        public Int32 streamid { get; set; }

    }

    //class for filter prepratory title
    public class GetFilterPrepratory
    {
        public Int32 prepid { get; set; }
        public Int32 careerid { get; set; }
    }

    //class for prepratory material download
    public class DownloadPrepratory
    {
        public Int32 prepid { get; set; }
        public Int32 prepnameid { get; set; }
        public Int32 materialtype { get; set; }
        public string papername { get; set; }
    }

    //class for bind guideline  data according to trait
    public class GetGuideline
    {
        public Int32 Traitid { get; set; }
    }
    //Api for filter guideline
    public class GetFilterGuideline
    {
        public Int32 Traitid { get; set; }
        public string Filtername { get; set; }
    }
    //Api for bind table of sample sop
    public class GetSampleSop
    {
        public Int32 intrestid { get; set; }
    }

    //class for filter sample essay data 
    public class GetSampleEssay
    {
        public Int32 countryid { get; set; }
        public Int32 universityid { get; set; }
    }

    public class getuniversity
    {
        public Int32 countryid { get; set; }
    }
    public class SaveWriteEssay
    {
        public Int32 essayid { get; set; } = 0;
        public string draftid { get; set; }
        public string versionid { get; set; }
        public string essaydetail { get; set; }
        public Int32 studentid { get; set; }

    }



    public class SaveReportEssay
    {
        
        public Int32 faqid { get; set; }
        public Int32 studentid { get; set; }
        public string report { get; set; }
        

    }




    public class EditWriteEssay
    {
        public Int32 essayid { get; set; } 
    
    }
    public class GetSelfAnalysis
    {
        public Int32 classid { get; set; }
        public Int32 streamid { get; set; }
    }
    public class GetFaqANS
    {
        public Int32 faqid { get; set; }
        public string career { get; set; }

    }
    public class UpateWriteEssay
    {
        public Int32 essayid { get; set; } 
        public string draftid { get; set; }
        public string versionid { get; set; }
        public string essaydetail { get; set; }

    }
    public class DeleteWriteEssay
    {
        public Int32 essayid { get; set; }

    }
    public class GetSumerData
    {
        public Int32 countryid { get; set; }
        public Int32 intrestid { get; set; }
    }
    public class SaveWriteSOP
    {
        public Int32 sopid { get; set; } = 0;
        public string draftid { get; set; }
        public string versionid { get; set; }
        public string essaydetail { get; set; }
        public Int32 studentid { get; set; }

    }

    public class EditWriteSOPData
    {
        public Int32 sopid { get; set; }

    }
    public class UpateWriteSOPEssay
    {
        public Int32 sopid { get; set; }
        public string draftid { get; set; }
        public string versionid { get; set; }
        public string essaydetail { get; set; }

    }
    public class DeleteWriteSOP
    {
        public Int32 sopid { get; set; }

    }
    public class LifeCoachDetailData
    {
        public Int32 topicid { get; set; }
        
    }
    public class ArchiveWebinar_Stu
    {
        public Int32 studentid { get; set; }
        public Int32 month { get; set; }
        public Int32 year { get; set; }

    }
    public class FutureWebinar_Stu
    {
        public Int32 studentid { get; set; }
        public string fromdate { get; set; }
        public string month { get; set; }
    }

    public class SaveSummerSchoolDoc
    {
        public List<IFormFile> Uploads { get; set; }
        public Int32 studentid { get; set; }
        public Int32 classid { get; set; }
        public string schoolname { get; set; }
        public string univercity { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }

    }
    //class for transcript data
    public class SaveTranscriptDoc
    {
        public List<IFormFile> Uploads { get; set; }
        public Int32 studentid { get; set; }
        public Int32 classid { get; set; }
        public Int32 streamid { get; set; }
        public string schoolname { get; set; }
        public string avggrade { get; set; }
        public string avgper { get; set; }
        public string createdby { get; set; }
       

    }

    public class SaveStudentDoc
    {
        public List<IFormFile> Uploads { get; set; }
        public Int32 studentid { get; set; }
      

    }
    public class StuCVData_Stu
    {
        public Int32 studentid { get; set; }

    }

    public class TranscriptData_Stu
    {
        public Int32 studentid { get; set; }

    }
    public class EditTranscriptData_Stu
    {
        public Int32 transcriptid { get; set; }

    }

    //class for update transcript data
    public class UpdateTranscriptDoc
    {
        public List<IFormFile> Uploads { get; set; }
        public Int32 transcriptid { get; set; }
        public Int32 studentid { get; set; }
        public Int32 classid { get; set; }
        public Int32 streamid { get; set; }
        public string schoolname { get; set; }
        public string avggrade { get; set; }
        public string avgper { get; set; }
        public string createdby { get; set; }


    }
    public class DeleteTranscriptData
    {
        public Int32 transcriptid { get; set; }

    }


    public class DeleteStuCvData
    {
        public Int32 cvid { get; set; }

    }
    public class BindPapernamePrepratory
    {
        public Int32 materialtype { get; set; }
        public Int32 prepid { get; set; }
        public Int32 prepnameid { get; set; }
    }

    //class for Ecp api
    public class SaveEcpDoc
    {
        public List<IFormFile> Uploads { get; set; }
        public Int32 studentid { get; set; }
      
        public string topic { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string certificatefrom { get; set; }
        public string description { get; set; }
        public string learning { get; set; }
        


    }
    public class ECPData_Stu
    {
        public Int32 studentid { get; set; }

    }
    public class EditECPData_Stu
    {
        public Int32 ecpid { get; set; }

    }
    public class UpdateECPDoc
    {
        public List<IFormFile> Uploads { get; set; }
        public Int32 ecpid { get; set; }
        public Int32 studentid { get; set; }
        public string topic { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string certificatefrom { get; set; }
        public string description { get; set; }
        public string learning { get; set; }
        


    }
    public class DeleteECPData
    {
        public Int32 ecpid { get; set; }

    }

    public class SaveEcaDoc
    {
        public List<IFormFile> Uploads { get; set; }
        public Int32 studentid { get; set; }
        public Int32 classid { get; set; }
        public string activity { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public Int32 level { get; set; }
        public string achievement { get; set; }
        public string learning { get; set; }



    }

    public class ECAData_Stu
    {
        public Int32 studentid { get; set; }

    }
    public class EditECAData_Stu
    {
        public Int32 ecaid { get; set; }

    }

    public class UpdateECADoc
    {
        public List<IFormFile> Uploads { get; set; }
        public Int32 studentid { get; set; }
        public Int32 classid { get; set; }
        public string activity { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public Int32 level { get; set; }
        public string achievement { get; set; }
        public string learning { get; set; }
        public Int32 ecaid { get; set; }


    }
    public class DeleteECAData
    {
        public Int32 ecaid { get; set; }

    }

    public class SaveSocialWorkDoc
    {
        public List<IFormFile> Uploads { get; set; }
        public Int32 studentid { get; set; }
        public Int32 classid { get; set; }
        public string socialwork { get; set; }
        public string description { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string learning { get; set; }

    }
    public class SocialWorkData_Stu
    {
        public Int32 studentid { get; set; }

    }

    public class EditSocialData_Stu
    {
        public Int32 socialworkid { get; set; }

    }
    public class UpdateSocialDoc
    {
        public Int32 socialworkid { get; set; }
        public List<IFormFile> Uploads { get; set; }
        public Int32 studentid { get; set; }
        public Int32 classid { get; set; }
        public string socialwork { get; set; }
        public string description { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string learning { get; set; }


    }
    public class DeleteSocialData
    {
        public Int32 socialworkid { get; set; }

    }


    public class SaveWorkExpDoc
    {
        public List<IFormFile> Uploads { get; set; }
        public Int32 studentid { get; set; }
        public string companyname { get; set; }
        public string projecttopic { get; set; }
        public string description { get; set; }
        
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string learning { get; set; }

    }

    public class WorkExperienceData_Stu
    {
        public Int32 studentid { get; set; }

    }
    public class EditWorkExpData_Stu
    {
        public Int32 workid { get; set; }

    }

    public class UpdateWorkExpDoc
    {
        public List<IFormFile> Uploads { get; set; }
        public Int32 workid { get; set; }
        public Int32 studentid { get; set; }
        public string projecttopic { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string companyname { get; set; }
        public string description { get; set; }
        public string learning { get; set; }

    }
    public class DeleteWorkExpData
    {
        public Int32 workid { get; set; }

    }
    public class SummerData_Stu
    {
        public Int32 studentid { get; set; }

    }
    public class EditSummerData_Stu
    {
        public Int32 schoolid { get; set; }

    }
    public class UpdateSummerDoc
    {
        public List<IFormFile> Uploads { get; set; }
        public Int32 studentid { get; set; }
        public Int32 classid { get; set; }
        public string schoolname { get; set; }
        public string univercity { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public Int32 schoolid { get; set; }


    }
    public class DeleteSummerData
    {
        public Int32 schoolid { get; set; }

    }
    public class SaveWriteQuery
    {

        public string studentquery { get; set; }
        public Int32 studentid { get; set; }

    }
    public class Query_Stu
    {
        public Int32 studentid { get; set; }

    }
    public class UpcomingWebinar_Stu
    {
        public Int32 studentid { get; set; }
        

    }
    public class LiveWebinar_Stu
    {
        public Int32 studentid { get; set; }
 
    }


    public class Notification_Stu
    {
        public Int32 notificationid { get; set; }

    }

    public class CareerGenieNoti
    {
        public Int32 studentid { get; set; }

    }
    public class Logout_Stu
    {
        public Int32 studentid { get; set; }
        public Int32 principalid { get; set; }
        public string IMEI { get; set; }

    }
    public class Feedback_Stu
    {
        public Int32 studentid { get; set; }
        

    }
    public class FeedbackQuery
    {
        public int studentid { get; set; }
        public string studentname { get; set; }
        public string mobileno { get; set; }
        public string email { get; set; }
        public int classid { get; set; }
        public int streamid { get; set; }
        public string feedback { get; set; }
        public string rating { get; set; }
    }
    public class CountWebinar_Stu
    {
        public Int32 studentid { get; set; }
      

    }

    public class passoutstudentdata
    {
        public int isdrop { get; set; }
        public int studentid { get; set; }
        public string university { get; set; }
        public string college { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string course { get; set; }
        public string specialization { get; set; }
    }

    public class SendOtp
    {
        public string email { get; set; }
        public string mobileno { get; set; }

    }
    public class matchOTPSTu
    {
        public string email { get; set; }
        public string mobileno { get; set; }
        public string otp { get; set; }

    }

    public class UpdateStuPassword
    {
        public int studentid { get; set; }
        public string oldpassword { get; set; }
        public string newpassword { get; set; }

    }

    public class ForgotStuPassword
    {
        public string mobileno { get; set; }
        public string email { get; set; }
        public string newpassword { get; set; }
        public string confirmpassword { get; set; }

    }
    public class PreviousWebinar_Stu
    {
        public Int32 studentid { get; set; }
        

    }
    public class profile_Stu
    {
        public Int32 studentid { get; set; }
        public Int32 principalid { get; set; }

    }

    public class UpdateStudentProfileData
    {
        public List<IFormFile> profilepic { get; set; }
        public Int32 studentid { get; set; }
        public Int32 classid { get; set; }
        public Int32 streamid { get; set; }
        public string schoolname { get; set; }
        public string studentname { get; set; }
        public string email { get; set; }
        public string mobileno { get; set; }
        public Int32 stateid { get; set; }
        public Int32 cityid { get; set; }
        public Int32 principalid { get; set; }
        public string principalname { get; set; }

        public Int32 languageid { get; set; }

    }
    public class LifeCoachList
    {
        public Int32 coachtypeid { get; set; }


    }
    public class CVLive
    {
        public Int32 studentid { get; set; }


    }
    public class CoachInfo
    {
        public Int32 coachid { get; set; }

    }
    public class RepositoryList
    {
        public Int32 listingid { get; set; }


    }

    public class RepositoryListVideoPDF
    {
        public Int32 pageid { get; set; }
        public Int32 languageid { get; set; }

        public string career { get; set; }


    }
    public class ArticleList
    {
        public Int32 articleid { get; set; }


    }


    public class TracedDate
    {
        public Int32 studentid { get; set; }
        public Int32 typeid { get; set; } = 0;
        public Int32 clickstatus { get; set; } = 0;

    }


    public class TracedAnalysisData
    {
        public Int32 studentid { get; set; }
        public Int32 teststatus { get; set; } = 0;

    }

    public class TracedPrepDta
    {
        public Int32 studentid { get; set; }
        public Int32 prepid { get; set; } = 0;
        public Int32 typeid { get; set; } = 0;

    }


    public class SavePlacementRecord
    {
        public Int32 studentid { get; set; }
        public Int32 placementid { get; set; } = 0;
        public string studentname { get; set; }
        public string fathername { get; set; }
        public string mobileno { get; set; }
        public Int32 countryid { get; set; }
        public Int32 stateid { get; set; }
        public Int32 cityid { get; set; }
        public string univercity { get; set; }
        public string college { get; set; }
        public string course { get; set; }
        public string specialization { get; set; }
        public string academicyear { get; set; }
        public Int32 isdrop { get; set; }
    }
    public class GetPlacementRecord
    {
        public Int32 studentid { get; set; }
       
    }

    public class EditPlacemtData
    {
        public Int32 placementid { get; set; }
    }
    public class UpdatePlacementRecord
    {
        public Int32 studentid { get; set; }
        public Int32 placementid { get; set; } 
        public string studentname { get; set; }
        public string fathername { get; set; }
        public string mobileno { get; set; }
        public Int32 countryid { get; set; }
        public Int32 stateid { get; set; }
        public Int32 cityid { get; set; }
        public string univercity { get; set; }
        public string college { get; set; }
        public string course { get; set; }
        public string specialization { get; set; }
        public string academicyear { get; set; }
        public Int32 isdrop { get; set; }
    }
    public class DeletePlacement
    {
        public Int32 placementid { get; set; }

    }
    public class ScholarshipList
    {
        public Int32 year { get; set; }
        public Int32 month { get; set; }
        public Int32 pageid { get; set; }
        public Int32 classid { get; set; }
        public string streamname { get; set; }
    }
    public class EntranceList
    {
        public Int32 year { get; set; }
        public Int32 month { get; set; }
        public Int32 pageid { get; set; }
        public Int32 classid { get; set; }
        public string streamname { get; set; }
    }
    public class PlacementList
    {
        public string academicyear { get; set; }
        public Int32 streamid { get; set; }
        
    }


    public class cvstudent
    {
        
        public Int32 studentid { get; set; }

    }
    public class GetGuide
    {
        public Int32 pageid { get; set; }
    }
}
