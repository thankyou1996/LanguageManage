using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LanguagesManage
{
    class LanguageGet
    {
        /// <summary>
        /// 数据库连接语句
        /// </summary>
        private static string connectionString = "Data Source=.;Initial Catalog=LanguageDB;Integrated Security=True";

        /// <summary>
        /// 代表选择语言
        /// </summary>
        public static int typeID = 0;

        /// <summary>
        /// 读取
        /// </summary>
        public static DataTable dtScript = QuerySQL("SELECT * FROM V_ALLScript").Tables[0];


        /// <summary>
        /// 执行一句查询语句返回第一行第一列
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        private static object CountQuertSQL(string SQLString, SqlParameter[] paras)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(command, connection, SQLString, paras);
                        object obj = command.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || Object.Equals(obj, DBNull.Value))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }
        }


        /// <summary>
        /// 执行一条查询语句，返回查询结果(DataSet)
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>查询结果(DataSet)</returns>
        private static DataSet QuerySQL(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    PrepareCommand(command, connection, SQLString, null);
                    using (SqlDataAdapter data = new SqlDataAdapter(command))
                    {
                        DataSet ds = new DataSet();
                        try
                        {
                            data.Fill(ds, "ds");
                            command.Parameters.Clear();
                        }
                        catch (SqlException ex)
                        {
                            throw ex;
                        }
                        return ds;
                    }
                }
            }

        }

        /// <summary>
        /// command赋值
        /// </summary>
        /// <param name="command"></param>
        /// <param name="connection"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParas"></param>
        private static void PrepareCommand(SqlCommand command, SqlConnection connection, string commandText, SqlParameter[] commandParas)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            command.Connection = connection;
            command.CommandText = commandText;
            command.CommandType = CommandType.Text;
            if (commandParas != null)
            {
                foreach (SqlParameter param in commandParas)
                {
                    if ((param.Direction == ParameterDirection.InputOutput || param.Direction == ParameterDirection.Input) &&
                        (param.Value == null))
                    {
                        param.Value = DBNull.Value;
                    }
                    command.Parameters.Add(param);
                }
            }
        }

        /// <summary>
        /// 获取内存表信息
        /// </summary>
        public void getScriptDt()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM V_ALLScript ");
            dtScript = QuerySQL(sb.ToString()).Tables[0]; //获取所有语言信息
        }

        /// <summary>
        /// 获取已有的语言类型
        /// </summary>
        public  static DataSet getLanguageType()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM T_type ");
            return QuerySQL(sb.ToString());
        }


        /// <summary>
        /// 从数据库中读取信息（scriptID,typeID)(返回值有可能为NULL)
        /// </summary>
        /// <param name="scriptID">语句ID</param>
        /// <param name="typeID">语言ID</param>
        /// <returns></returns>
        public static string getContentFromDB(int scriptID)
        {
            string fieldName = "Content";
            if (typeID == 0)
            {
                fieldName = "BasicText";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT " + fieldName + " FROM V_ALLScript ");
            sb.Append("WHERE ScriptID=@scriptID ");
            if (typeID != 0)
            {
                sb.Append("AND TypeID=@typeID ");
            }
            SqlParameter[] parameters ={
                                       new SqlParameter("@scriptID",SqlDbType.Int),
                                       new SqlParameter("@typeID",SqlDbType.Int)
                                       };
            parameters[0].Value = scriptID;
            parameters[1].Value = typeID;
            object obj = CountQuertSQL(sb.ToString(), parameters) == null;
            if (obj == null)
            {
                return "###";
            }
            else
            {
                return Convert.ToString(obj);
            }
            
        }


        /// <summary>
        /// 从内存表中读取信息(通过ID)(返回值有可能为空)
        /// </summary>
        /// <param name="scriptID">语句ID</param>
        /// <param name="typeID">语言ID</param>
        /// <returns></returns>
        public static string getContentFromDT(int scriptID)
        {
            string fieldName = "Content";
            if (typeID == 0)
            {
                fieldName = "BasicText";
            }

            string content = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("ScriptID =" + scriptID + " ");
            if (typeID != 0)
            {
                sb.Append("AND TypeID =" + typeID + " ");
            }

            DataRow[] drs = dtScript.Select(sb.ToString());
            if (drs.Count() > 0)
            {
                content = drs[0]["" + fieldName + ""].ToString();
            }
            return content;
        }

    }
}
