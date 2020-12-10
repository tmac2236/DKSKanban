using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using isRock.Framework.PageMethods;
using Newtonsoft.Json;

namespace WebKanban
{
    public partial class getKanbanDataByLine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static DataSet GetKanBanDataSet(string line)
        {
            DataSet ds = new DataSet();
            DAO dao = new DAO(ConfigurationManager.ConnectionStrings["CONN"].ConnectionString.ToString());
            SqlParameter para1 = new SqlParameter("@LINEID", SqlDbType.Char);
            para1.Value = line;
            IDataParameter[] parameters = new IDataParameter[] { para1 };
            ds = dao.RunProcedure("PROD_GET_KANBAN_PRODUCT_LINE", parameters, "table");
            return ds;
        }

        public static DataSet GetKanBanTQCDataSet(string line)
        {
            DataSet ds = new DataSet();
            DAO dao = new DAO(ConfigurationManager.ConnectionStrings["CONN"].ConnectionString.ToString());
            SqlParameter para1 = new SqlParameter("@LINEID", SqlDbType.Char);
            para1.Value = line;
            IDataParameter[] parameters = new IDataParameter[] { para1 };
            ds = dao.RunProcedure("PROD_GET_KANBAN_TQC", parameters, "table");
            return ds;
        }

        [System.Web.Services.WebMethod(enableSession: true)]
        public static PageMethodDefaultResult<string> GetData1()
        {
            
            
            DataSet ds = new DataSet();
            ds = GetKanBanDataSet("ST1");
            
            var result = new PageMethodDefaultResult<string>()
            {
                Data = JsonConvert.SerializeObject(ds.Tables[0],Formatting.Indented),
                isSuccess = true
            };
            return result;
        }
        //抓ST1 TQC alan
        [System.Web.Services.WebMethod(enableSession: true)]
        public static PageMethodDefaultResult<string> GetDataA()
        {

            DataSet ds = new DataSet();
            ds = GetKanBanTQCDataSet("ST1");

            var result = new PageMethodDefaultResult<string>()
            {
                Data = JsonConvert.SerializeObject(ds.Tables[0], Formatting.Indented),
                isSuccess = true
            };
            return result;
        }


        [System.Web.Services.WebMethod(enableSession: true)]
        public static PageMethodDefaultResult<string> GetData2()
        {
            DataSet ds = new DataSet();
            ds = GetKanBanDataSet("ST2");
            var result = new PageMethodDefaultResult<string>()
            {
                Data = JsonConvert.SerializeObject(ds.Tables[0], Formatting.Indented),
                isSuccess = true
            };
            return result;
        }

        //抓ST2 TQC alan
        [System.Web.Services.WebMethod(enableSession: true)]
        public static PageMethodDefaultResult<string> GetDataB()
        {

            DataSet ds = new DataSet();
            ds = GetKanBanTQCDataSet("ST2");

            var result = new PageMethodDefaultResult<string>()
            {
                Data = JsonConvert.SerializeObject(ds.Tables[0], Formatting.Indented),
                isSuccess = true
            };
            return result;
        }

        [System.Web.Services.WebMethod(enableSession: true)]
        public static PageMethodDefaultResult<string> GetData3()
        {

            DataSet ds = new DataSet();
            ds = GetKanBanDataSet("ST3");
            var result = new PageMethodDefaultResult<string>()
            {
                Data = JsonConvert.SerializeObject(ds.Tables[0], Formatting.Indented),
                isSuccess = true
            };
            return result;
        }

        //抓ST3 TQC alan
        [System.Web.Services.WebMethod(enableSession: true)]
        public static PageMethodDefaultResult<string> GetDataC()
        {

            DataSet ds = new DataSet();
            ds = GetKanBanTQCDataSet("ST3");

            var result = new PageMethodDefaultResult<string>()
            {
                Data = JsonConvert.SerializeObject(ds.Tables[0], Formatting.Indented),
                isSuccess = true
            };
            return result;
        }

        [System.Web.Services.WebMethod(enableSession: true)]
        public static PageMethodDefaultResult<string> GetData4()
        {

            DataSet ds = new DataSet();
            ds = GetKanBanDataSet("ST4");
            var result = new PageMethodDefaultResult<string>()
            {
                Data = JsonConvert.SerializeObject(ds.Tables[0], Formatting.Indented),
                isSuccess = true
            };
            return result;
        }

        //抓ST4 TQC alan
        [System.Web.Services.WebMethod(enableSession: true)]
        public static PageMethodDefaultResult<string> GetDataD()
        {

            DataSet ds = new DataSet();
            ds = GetKanBanTQCDataSet("ST4");

            var result = new PageMethodDefaultResult<string>()
            {
                Data = JsonConvert.SerializeObject(ds.Tables[0], Formatting.Indented),
                isSuccess = true
            };
            return result;
        }
        [System.Web.Services.WebMethod(enableSession: true)]
        public static PageMethodDefaultResult<string> GetData5()
        {

            DataSet ds = new DataSet();
            ds = GetKanBanDataSet("ST5");
            var result = new PageMethodDefaultResult<string>()
            {
                Data = JsonConvert.SerializeObject(ds.Tables[0], Formatting.Indented),
                isSuccess = true
            };
            return result;
        }


        //抓ST5 TQC alan
        [System.Web.Services.WebMethod(enableSession: true)]
        public static PageMethodDefaultResult<string> GetDataE()
        {

            DataSet ds = new DataSet();
            ds = GetKanBanTQCDataSet("ST5");

            var result = new PageMethodDefaultResult<string>()
            {
                Data = JsonConvert.SerializeObject(ds.Tables[0], Formatting.Indented),
                isSuccess = true
            };
            return result;
        }

        [System.Web.Services.WebMethod(enableSession: true)]
        public static PageMethodDefaultResult<string> GetData6()
        {

            DataSet ds = new DataSet();
            ds = GetKanBanDataSet("ASY");
            var result = new PageMethodDefaultResult<string>()
            {
                Data = JsonConvert.SerializeObject(ds.Tables[0], Formatting.Indented),
                isSuccess = true
            };
            return result;
        }

        //抓ASY TQC alan
        [System.Web.Services.WebMethod(enableSession: true)]
        public static PageMethodDefaultResult<string> GetDataF()
        {

            DataSet ds = new DataSet();
            ds = GetKanBanTQCDataSet("ASY");

            var result = new PageMethodDefaultResult<string>()
            {
                Data = JsonConvert.SerializeObject(ds.Tables[0], Formatting.Indented),
                isSuccess = true
            };
            return result;
        }

        [System.Web.Services.WebMethod(enableSession: true)]
        public static PageMethodDefaultResult<string> GetData7()
        {
            DataSet ds = new DataSet();
            ds = GetKanBanDataSet("STF");
            var result = new PageMethodDefaultResult<string>()
            {
                Data = JsonConvert.SerializeObject(ds.Tables[0], Formatting.Indented),
                isSuccess = true
            };
            return result;
        }

        //抓STF TQC alan
        [System.Web.Services.WebMethod(enableSession: true)]
        public static PageMethodDefaultResult<string> GetDataG()
        {

            DataSet ds = new DataSet();
            ds = GetKanBanTQCDataSet("STF");

            var result = new PageMethodDefaultResult<string>()
            {
                Data = JsonConvert.SerializeObject(ds.Tables[0], Formatting.Indented),
                isSuccess = true
            };
            return result;
        }
    }
}