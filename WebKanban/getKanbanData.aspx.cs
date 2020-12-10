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
    public partial class getKanbanData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod(enableSession: true)]
        public static PageMethodDefaultResult<string> GetData1()
        {
            
            DAO dao = new DAO(ConfigurationManager.ConnectionStrings["CONN"].ConnectionString.ToString());
            DataSet ds = new DataSet();

            SqlParameter para1 = new SqlParameter("@type", SqlDbType.Char);
            para1.Value = "1";
            IDataParameter[] parameters = new IDataParameter[] { para1 };
            ds = dao.RunProcedure("PROD_GET_KANBAN_PRODUCT", parameters, "table");
            var result = new PageMethodDefaultResult<string>()
            {
                Data = JsonConvert.SerializeObject(ds.Tables[0],Formatting.Indented),
                isSuccess = true
            };
            return result;
        }

        [System.Web.Services.WebMethod(enableSession: true)]
        public static PageMethodDefaultResult<string> GetData2()
        {

            DAO dao = new DAO(ConfigurationManager.ConnectionStrings["CONN"].ConnectionString.ToString());
            DataSet ds = new DataSet();

            SqlParameter para1 = new SqlParameter("@type", SqlDbType.Char);
            para1.Value = "2";
            IDataParameter[] parameters = new IDataParameter[] { para1 };
            ds = dao.RunProcedure("PROD_GET_KANBAN_PRODUCT", parameters, "table");
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

            DAO dao = new DAO(ConfigurationManager.ConnectionStrings["CONN"].ConnectionString.ToString());
            DataSet ds = new DataSet();

            SqlParameter para1 = new SqlParameter("@type", SqlDbType.Char);
            para1.Value = "3";
            IDataParameter[] parameters = new IDataParameter[] { para1 };
            ds = dao.RunProcedure("PROD_GET_KANBAN_PRODUCT", parameters, "table");
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

            DAO dao = new DAO(ConfigurationManager.ConnectionStrings["CONN"].ConnectionString.ToString());
            DataSet ds = new DataSet();

            SqlParameter para1 = new SqlParameter("@type", SqlDbType.Char);
            para1.Value = "4";
            IDataParameter[] parameters = new IDataParameter[] { para1 };
            ds = dao.RunProcedure("PROD_GET_KANBAN_PRODUCT", parameters, "table");
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

            DAO dao = new DAO(ConfigurationManager.ConnectionStrings["CONN"].ConnectionString.ToString());
            DataSet ds = new DataSet();

            SqlParameter para1 = new SqlParameter("@type", SqlDbType.Char);
            para1.Value = "4";
            IDataParameter[] parameters = new IDataParameter[] { para1 };
            ds = dao.RunProcedure("PROD_GET_KANBAN_PRODUCT", parameters, "table");
            var result = new PageMethodDefaultResult<string>()
            {
                Data = JsonConvert.SerializeObject(ds.Tables[0], Formatting.Indented),
                isSuccess = true
            };
            return result;
        }
    }
}