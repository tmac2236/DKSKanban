using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebKanban
{
    public class DAO
    {
        
            #region Private Data
            protected SqlConnection objConnection;
            private string strConnectionString = "";
            #endregion

            #region Constructor
            public DAO(string ConnectionString)
            {
                strConnectionString = ConnectionString;
                objConnection = new SqlConnection(strConnectionString);
            }

            public DAO()
            {
                objConnection = new SqlConnection(strConnectionString);
            }
            #endregion

            #region Properties
            public string ConnectionString
            {
                get
                {
                    return strConnectionString;
                }
            }
            #endregion

            #region Private Functions
            private SqlCommand BuildIntCommand(string strStoredProcName,IDataParameter[] parameters)
            {
                SqlCommand objCommand = BuildQueryCommand(strStoredProcName, parameters);

                objCommand.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4,
                        ParameterDirection.ReturnValue, false, 0, 0, string.Empty,
                        DataRowVersion.Default, null));

                return objCommand;
            }

            private SqlCommand BuildQueryCommand(string strStoredProcName,IDataParameter[] parameters)
            {
                SqlCommand objCommand = new SqlCommand(strStoredProcName, objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter parameter in parameters)
                {
                    objCommand.Parameters.Add(parameter);
                }

                return objCommand;
            }

            private SqlCommand BuildSQLIntCommand(string strStoredProcName, IDataParameter[] parameters)
            {
                SqlCommand objCommand =BuildSQLQueryCommand(strStoredProcName, parameters);

                objCommand.Parameters.Add(new SqlParameter("ReturnValue",
                    SqlDbType.Int, 4,
                    ParameterDirection.ReturnValue, false, 0, 0, string.Empty,
                    DataRowVersion.Default, null));

                return objCommand;
            }

            private SqlCommand BuildSQLQueryCommand(string SQL,IDataParameter[] parameters)
            {
                SqlCommand objCommand = new SqlCommand(SQL, objConnection);
                objCommand.CommandType = CommandType.Text;

                foreach (SqlParameter parameter in parameters)
                {
                    objCommand.Parameters.Add(parameter);
                }

                return objCommand;
            }

            private SqlCommand BuildSQLQueryCommand(string SQL)
            {
                SqlCommand objCommand = new SqlCommand(SQL, objConnection);
                objCommand.CommandType = CommandType.Text;
                return objCommand;
            }
        #endregion

        #region RunSQL
        public int RunSQL(string SQL, IDataParameter[] parameters)
            {
                objConnection.Open();
                SqlCommand objCommand = BuildSQLQueryCommand(SQL, parameters);
                int intRowsAffected = objCommand.ExecuteNonQuery();
                return (intRowsAffected);
            }
            public string RunSQLReturnResult(string SQL, IDataParameter[] parameters)
            {
                objConnection.Open();
                SqlCommand objCommand = BuildSQLIntCommand(SQL, parameters);
                //int RowsAffected = objCommand.ExecuteNonQuery();
                //int intResult = (int)objCommand.Parameters["ReturnValue"].Value;

                string strResult = objCommand.ExecuteScalar().ToString();
                return (strResult);
            }

            public SqlDataReader RunSQLReturnDataReader(string SQL,IDataParameter[] parameters)
            {
                SqlDataReader objReader = null;

                objConnection.Open();
                SqlCommand objCommand = BuildSQLQueryCommand(SQL, parameters);
                objReader =objCommand.ExecuteReader(CommandBehavior.CloseConnection);
                return objReader;
            }

            public DataSet RunSQLReturnDataSet(string SQL)
            {
                    DataSet objDataSet = new DataSet();

                    objConnection.Open();
                    SqlDataAdapter objDA = new SqlDataAdapter();
                    objDA.SelectCommand = BuildSQLQueryCommand(SQL);
                    objDA.Fill(objDataSet);
                    objConnection.Close();

                    return objDataSet;
        }

            public DataSet RunSQLReturnDataSet(string SQL,IDataParameter[] parameters)
            {
                return (RunSQLReturnDataSet(SQL, parameters, "default"));
            }

            public DataSet RunSQLReturnDataSet(string SQL,IDataParameter[] parameters, string TableName)
            {
                DataSet objDataSet = new DataSet();

                objConnection.Open();
                SqlDataAdapter objDA = new SqlDataAdapter();
                objDA.SelectCommand = BuildSQLQueryCommand(SQL, parameters);
                objDA.Fill(objDataSet, TableName);
                objConnection.Close();

                return objDataSet;
            }
            #endregion

            #region RunProcedure Overloads
            public int RunProcedure(string StoredProcName,
                            IDataParameter[] parameters,
                            out int RowsAffected)
            {
                int intResult;

                objConnection.Open();
                SqlCommand objCommand = BuildIntCommand(StoredProcName, parameters);
                RowsAffected = objCommand.ExecuteNonQuery();
                intResult = (int)objCommand.Parameters["ReturnValue"].Value;
                objConnection.Close();

                return intResult;
            }

            public SqlDataReader RunProcedure(string StoredProcName,IDataParameter[] parameters)
            {
                SqlDataReader objReader;

                objConnection.Open();
                SqlCommand objCommand = BuildQueryCommand(StoredProcName, parameters);
                objCommand.CommandType = CommandType.StoredProcedure;
                objReader = objCommand.ExecuteReader(CommandBehavior.CloseConnection);
                return objReader;
            }

            public DataSet RunProcedure(string StoredProcName,
                    IDataParameter[] parameters,
                    string TableName)
            {
                DataSet objDataSet = new DataSet();
                objConnection.Open();
                SqlDataAdapter objDA = new SqlDataAdapter();
                objDA.SelectCommand = BuildQueryCommand(StoredProcName, parameters);
                objDA.Fill(objDataSet, TableName);
                objConnection.Close();

                return objDataSet;
            }

            public void RunProcedure(string StoredProcName,
                    IDataParameter[] parameters,
                    DataSet DataSet,
                    string TableName)
            {
                objConnection.Open();
                SqlDataAdapter objDA = new SqlDataAdapter();
                objDA.SelectCommand = BuildIntCommand(StoredProcName, parameters);
                objDA.Fill(DataSet, TableName);
                objConnection.Close();
            }
            #endregion
        }
    
}