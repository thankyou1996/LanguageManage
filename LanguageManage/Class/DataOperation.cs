using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DBHelperSQL;

namespace LanguagesManage
{
    public  class DataOperation
    {
        /********************************************************  
  
        //创建日期:2016-03-17
  
        //作者:洪栋城 
  	
        //內容说明:　多语言录入
  
        ********************************************************/
        /// <summary>
        /// 获取语言库所有信息()
        /// </summary>
        /// <returns></returns>
        public DataSet getV_script()
        {
            string storeProcName = "proc_V_AllBySelectALL";
            IDataParameter[] parameters ={
                                       
                                       };
            return DBHelpSQL.RunProceDure(storeProcName, parameters, "ds");
        }

        #region  语言类型操作(T_type)
        /// <summary>
        /// 获取语言类型表信息
        /// </summary>
        /// <returns></returns>
        public DataSet getType()
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append("SELECT TypeID,LanguageName,Reserved_1,AddTime FROM T_type");
            sb.Append("SELECT * FROM T_type");
            return DBHelpSQL.QuerySQL(sb.ToString());
        }

        /// <summary>
        /// 更新T_type表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool updateTypeDt(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM T_type ");
            return DBHelpSQL.UpdateView(sb.ToString(), dt);
        }
        
        /// <summary>
        /// 查询是否存在某种类型
        /// </summary>
        /// <param name="TyprText"></param>
        /// <returns></returns>
        public int existsType(string TypeText)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT Count(*) FROM T_type ");
            sb.Append("WHERE LanguageName=@TypeText ");
            SqlParameter[] parameter ={
                                     new SqlParameter("@TypeText",SqlDbType.NVarChar,20)
                                     };
            parameter[0].Value = TypeText;
            return Convert.ToInt32(DBHelpSQL.CountQuerySQL(sb.ToString(), parameter));
        }

        public int existsType(string languageName, string languageName2, string languageAbbreviation)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT COUNT(1) FROM T_type ");
            sb.Append("WHERE LanguageName=@languageName ");
            sb.Append("Or Reserved_1=@languaheName2 ");
            sb.Append("OR Reserved_2=@languageAbbreviation ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@languageName",SqlDbType.NVarChar,50),
                                      new SqlParameter("@languaheName2",SqlDbType.NVarChar,50),
                                      new SqlParameter("@languageAbbreviation",SqlDbType.NVarChar,50)
                                      };
            parameters[0].Value = languageName;
            parameters[1].Value = languageName2;
            parameters[2].Value = languageAbbreviation;
            return Convert.ToInt32 (DBHelpSQL.CountQuerySQL(sb.ToString(),parameters));
        }
        /// <summary>
        /// 添加语言类型
        /// </summary>
        /// <param name="LanguageName">语言名称</param>
        /// <param name="TypeText">语言名称</param>
        /// <param name="AdminName"></param>
        /// <returns></returns>
        public int addType(string LanguageName,string LanguageName2,string languageAbbreviation, string AdminName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO T_type(LanguageName,Reserved_1,Reserved_2,AdminName) ");
            sb.Append("VALUES(@LanguageName,@LanguageName2,@languageAbbreviation,@AdminName) ");
            SqlParameter[] parameters ={
                                     new SqlParameter("@LanguageName",SqlDbType.NVarChar,50),
                                     new SqlParameter("@LanguageName2",SqlDbType.NVarChar,50),
                                     new SqlParameter("@languageAbbreviation",SqlDbType.NVarChar,50),
                                     new SqlParameter("@AdminName",SqlDbType.NVarChar,20)
                                     };
            parameters[0].Value = LanguageName;
            parameters[1].Value = LanguageName2;
            parameters[2].Value = languageAbbreviation;
            parameters[3].Value = AdminName;
            return DBHelpSQL.ExecuteSQL(sb.ToString(), parameters);
        }

        /// <summary>
        /// 获取语言ID(通过语言名称)(-1为不存在该语言的ID)
        /// </summary>
        /// <param name="LangName"></param>
        /// <returns></returns>
        public int getTypeID(string LangName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT TypeID FROM T_type ");
            sb.Append("WHERE LanguageName=@LanguageName OR Reserved_1=@LanguageName ");
            SqlParameter[] parameters ={
                                       new SqlParameter("@LanguageName",SqlDbType.NVarChar,50)
                                       };
            parameters[0].Value = LangName;
            try
            {
                return Convert.ToInt32(DBHelpSQL.CountQuerySQL(sb.ToString(), parameters));
            }
            catch
            {
                return -1;
            }
            
        }

        /// <summary>
        /// 获取所有的语言ID
        /// </summary>
        /// <returns></returns>
        public DataSet getAllTypeID()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT TypeID FROM T_type");
            return DBHelpSQL.QuerySQL(sb.ToString());
        }

        /// <summary>
        /// 获取所有语言名称（外语）
        /// </summary>
        /// <returns></returns>
        public string getLanguageNames()
        {
            DataTable dt = getType().Tables[0];
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("[" + dr["LanguageName"] + "],");
            }

            if (sb.Length == 0)
            {
                return null;
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        /// <summary>
        /// 获取所有语言名称（中文）
        /// </summary>
        /// <returns></returns>
        public string getLanguageName()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT Reserved_1 FROM T_type ");
            DataTable dt = DBHelpSQL.QuerySQL(sb.ToString()).Tables[0];
            StringBuilder sb1 = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb1.Append("[" + dt.Rows[i][0].ToString() + "],");
            }
            if (sb1.Length == 0)
            {
                return null;
            }
            sb1.Remove(sb1.Length - 1, 1);
            return sb1.ToString();
        }

        /// <summary>
        /// 修类型名称
        /// </summary>
        /// <param name="TypeID"></param>
        /// <param name="LanguageName">语言名称</param>
        /// <param name="LanguageName2">语言，（中文）</param>
        /// <param name="AdminName">管理员</param>
        /// <returns></returns>
        public int updateType(int TypeID, string LanguageName, string LanguageName2, string AdminName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE T_type SET ");
            sb.Append("LanguageName=@LanguageName,Reserved_1=@LanguageName2,AdminName=@AdminName ");
            sb.Append("WHERE TypeID=@TypeID");
            SqlParameter[] parameters ={
                                      new SqlParameter("@LanguageName",SqlDbType.NVarChar,50),
                                      new SqlParameter("@LanguageName2",SqlDbType.NVarChar,50),
                                      new SqlParameter("@AdminName",SqlDbType.NVarChar,20),
                                      new SqlParameter("@TypeID",SqlDbType.Int)
                                      };
            parameters[0].Value = LanguageName;
            parameters[1].Value = LanguageName2;
            parameters[2].Value = AdminName;
            parameters[3].Value = TypeID;
            return DBHelpSQL.ExecuteSQL(sb.ToString(), parameters);
        }

        public int updateType(int typeID, string languageName, string languageName2, string languageAbbreviation, string adminName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE T_type ");
            sb.Append("SET LanguageName=@languageName,Reserved_1=@languageName2,Reserved_2=@languageAbbreviation,AdminName=@adminName ");
            sb.Append("WHERE TypeID=@typeID ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@languageName",SqlDbType.NVarChar,50),
                                      new SqlParameter("@languageName2",SqlDbType.NVarChar,50),
                                      new SqlParameter("@languageAbbreviation",SqlDbType.NVarChar,50),
                                      new SqlParameter("@adminName",SqlDbType.NVarChar,20),
                                      new SqlParameter("@typeID",SqlDbType.Int)
                                      };
            parameters[0].Value = languageName;
            parameters[1].Value = languageName2;
            parameters[2].Value = languageAbbreviation;
            parameters[3].Value = adminName;
            parameters[4].Value = typeID;
            return DBHelpSQL.ExecuteSQL(sb.ToString(), parameters);
        }
        /// <summary>
        ///  组成DictionaryEntry（key代表参数，Value代表SQL语句)（用于更新数据）
        /// </summary>
        /// <param name="typeID"></param>
        /// <param name="languageName"></param>
        /// <param name="languageName2"></param>
        /// <param name="adminName"></param>
        /// <returns></returns>
        public DictionaryEntry paraAndSQLTypeUpdate(int typeID, string languageName, string languageName2,string adminName)
        {
            DictionaryEntry de;
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE T_type ");
            sb.Append("SET [LanguageName]=@languageName ,[Reserved_1]=@languageName2 , [AdminName]=@adminName , [UpdateTime]=GETDATE() ");
            sb.Append("WHERE [TypeID]=@typeID ");
            SqlParameter[] parameters ={
                                        new SqlParameter("@languageName",SqlDbType.NVarChar,50),
                                        new SqlParameter("@languageName2",SqlDbType.NVarChar,50),
                                        new SqlParameter("@adminName",SqlDbType.NVarChar,20),
                                        new SqlParameter("@typeID",SqlDbType.Int)
                                        };
            parameters[0].Value = languageName;
            parameters[1].Value = languageName2;
            parameters[2].Value = adminName;
            parameters[3].Value = typeID;
            de = new DictionaryEntry(parameters, sb.ToString());
            return de;

        }

        public DataSet getSelectedType(int [] selectedTypes)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM T_type ");
            sb.Append("WHERE ");
            for (int i = 0; i < selectedTypes.Length; i++)
            {
                sb.Append("TypeID="+selectedTypes[i]+" OR ");
            }
            sb.Remove(sb.Length - 3, 3);
            return DBHelpSQL.QuerySQL(sb.ToString());
        }
        #endregion

        #region 脚本表操作（T_Script）

        public DataSet getScript()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM T_Script ");
            return DBHelpSQL.QuerySQL(sb.ToString());
        }

        public DataSet getScriptClone()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT  TOP 1 * FROM T_Script ");
            return DBHelpSQL.QuerySQL(sb.ToString());
        }
        

        /// <summary>
        /// 更新语言表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool updateScriptDt(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM T_Script ");

            return DBHelpSQL.UpdateView(sb.ToString(), dt);
        }

        /// <summary>
        /// 添加语句
        /// </summary>
        /// <param name="ScriptID">语句ID</param>
        /// <param name="TypeID">语言ID</param>
        /// <param name="content">内容</param>
        /// <param name="AdminName">管理员姓名</param>
        /// <returns></returns>
        public int addScript(int ScriptID, int TypeID, string content, string AdminName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO T_Script(ScriptID,TypeID,Content,AdminName) ");
            sb.Append("VALUES(@ScriptID,@TypeID,@Content,@AdminName) ");
            SqlParameter[] parameter ={
                                      new SqlParameter("@ScriptID",SqlDbType.Int),
                                      new SqlParameter("@TypeID",SqlDbType.Int),
                                      new SqlParameter("@Content",SqlDbType.NVarChar,1500),
                                      new SqlParameter("@AdminName",SqlDbType.NVarChar,20)
                                     };
            parameter[0].Value = ScriptID;
            parameter[1].Value = TypeID;
            parameter[2].Value = content;
            parameter[3].Value = AdminName;
            return DBHelpSQL.ExecuteSQL(sb.ToString(), parameter);
        }

        /// <summary>
        /// 修改语言表
        /// </summary>
        /// <param name="ScriptID"></param>
        /// <param name="TypeID"></param>
        /// <param name="toContent"></param>
        /// <param name="AdminName"></param>
        /// <returns></returns>
        public int updateScript(int ScriptID, int TypeID, string toContent, string AdminName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE T_Script ");
            sb.Append("SET Content=@toContent ,AdminName=@AdminName,UpdateTime=getDate() ");
            sb.Append("WHERE ScriptID=@ScriptID and TypeID=@TypeID ");
            SqlParameter[] parameters ={
                                    new SqlParameter("@toContent",SqlDbType.NVarChar,1500),
                                    new SqlParameter("@AdminName",SqlDbType.NVarChar,20),
                                    new SqlParameter("@ScriptID",SqlDbType.Int),
                                    new SqlParameter("TypeID",SqlDbType.Int)
                                    };
            parameters[0].Value = toContent;
            parameters[1].Value = AdminName;
            parameters[2].Value = ScriptID;
            parameters[3].Value = TypeID;
            return DBHelpSQL.ExecuteSQL(sb.ToString(), parameters);
        }

        /// <summary>
        /// 组成DictionaryEntry（key代表参数，Value代表SQL语句)（用于添加数据）
        /// </summary>
        /// <param name="ScriptID"></param>
        /// <param name="TypeID"></param>
        /// <param name="content"></param>
        /// <param name="AdminName"></param>
        /// <returns></returns>
        public DictionaryEntry paraAndSQLScriptInsert(int ScriptID, int TypeID, string content, string AdminName)
        {
            DictionaryEntry de;
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO T_Script(ScriptID,TypeID,Content,AdminName) ");
            sb.Append("VALUES(@ScriptID,@TypeID,@Content,@AdminName) ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@ScriptID",SqlDbType.Int),
                                      new SqlParameter("@TypeID",SqlDbType.Int),
                                      new SqlParameter("@Content",SqlDbType.NVarChar,1500),
                                      new SqlParameter("@AdminName",SqlDbType.NVarChar,20)
                                      };
            parameters[0].Value = ScriptID;
            parameters[1].Value = TypeID;
            parameters[2].Value = content;
            parameters[3].Value = AdminName;
            de = new DictionaryEntry(parameters, sb.ToString());
            return de;
        }

        /// <summary>
        /// 组成DictionaryEntry(key代表参数，value代表SQL语句)（用于更新数据）
        /// </summary>
        /// <param name="ScriptID"></param>
        /// <param name="TypeID"></param>
        /// <param name="content"></param>
        /// <param name="AdminName"></param>
        /// <returns></returns>
        public DictionaryEntry paraAndSQLScriptUpdate(int scriptID, int typeID, string content, string adminName)
        {
            DictionaryEntry de;
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE T_Script ");
            sb.Append("SET Content=@content , AdminName=@adminName ,UpdateTime=GETDATE() ");
            sb.Append("WHERE ScriptID=@scriptID AND TypeID=@typeID ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@content",SqlDbType.NVarChar,1500),
                                      new SqlParameter("@adminName",SqlDbType.NVarChar,20),
                                      new SqlParameter("@scriptID",SqlDbType.Int),
                                      new SqlParameter("@typeID",SqlDbType.Int)
                                      };
            parameters[0].Value = content;
            parameters[1].Value = adminName;
            parameters[2].Value = scriptID;
            parameters[3].Value = typeID;
            de = new DictionaryEntry(parameters, sb.ToString());
            return de;
        }

        /// <summary>
        /// 获取选中语言的语言库信息
        /// </summary>
        /// <param name="typeIDs"></param>
        /// <returns></returns>
        public DataSet getScriptXml(int[] typeIDs)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM T_Script ");
            sb.Append("WHERE ");
            for (int i = 0; i < typeIDs.Length; i++)
            {
                sb.Append("TypeID=" + typeIDs[i] + " OR ");
            };
            sb.Remove(sb.Length - 3, 3);
            return DBHelpSQL.QuerySQL(sb.ToString());
        }
        #endregion

        #region 基本中文表操作（T_BsaicScript）
        /// <summary>
        /// 获取所有的基本语句
        /// </summary>
        /// <returns></returns>
        public DataSet getBasicScript()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT T_BasicScript.* , T_Position.Position ");
            sb.Append("FROM T_BasicScript,T_Position ");
            sb.Append("WHERE T_BasicScript.PositionID = T_Position.PositionID");
            return DBHelpSQL.QuerySQL(sb.ToString());
        }

        /// <summary>
        /// 更新界面信息
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool updateBasicDt(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM T_BasicScript ");
            return DBHelpSQL.UpdateView(sb.ToString(), dt);
        }

        /// <summary>
        /// 添加基本语句
        /// </summary>
        /// <param name="ScriptText"></param>
        /// <param name="AdminName"></param>
        /// <returns></returns>
        public int AddBasicScript(string BasicText, string AdminName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO T_BasicScript(BasicText,AdminName) ");
            sb.Append("VALUES (@BasicText,@AdminName) ");
            SqlParameter[] parameter ={
                                     new SqlParameter("@BasicText",SqlDbType.NVarChar,1500),
                                     new SqlParameter("@AdminName",SqlDbType.NVarChar,20)
                                     };
            parameter[0].Value = BasicText;
            parameter[1].Value = AdminName;
            return DBHelpSQL.ExecuteSQL(sb.ToString(), parameter);
        }

        /// <summary>
        /// 添加语句
        /// </summary>
        /// <param name="BasicText">文本</param>
        /// <param name="position">位置</param>
        /// <param name="adminName">操作人员</param>
        /// <returns></returns>
        public int addBasicScript(string basicText, int positionID, string adminName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO T_BasicScript (BasicText,PositionID,AddTime,AdminName) ");
            sb.Append("VALUES (@basicText,@position,GETDATE(),@adminName) ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@basicText",SqlDbType.NVarChar,1500),
                                      new SqlParameter("@position",SqlDbType.Int),
                                      new SqlParameter("@adminName",SqlDbType.NVarChar,20)
                                      };
            parameters[0].Value = basicText;
            parameters[1].Value = positionID;
            parameters[2].Value = adminName;
            return DBHelpSQL.ExecuteSQL(sb.ToString(), parameters);
        }

        public int addBasicScript(string basicText, int positionID, string position2, string adminName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO T_BasicScript (BasicText,PositionID,Reserved_1,AddTime,AdminName ) ");
            sb.Append("VALUES (@basicText,@position,@position2,GETDATE(),@adminName) ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@basicText",SqlDbType.NVarChar,1500),
                                      new SqlParameter("@position",SqlDbType.Int),
                                      new SqlParameter("@position2",SqlDbType.NVarChar,50),
                                      new SqlParameter("@adminName",SqlDbType.NVarChar,20)
                                      };
            parameters[0].Value = basicText;
            parameters[1].Value = positionID;
            parameters[2].Value = position2;
            parameters[3].Value = adminName;
            return DBHelpSQL.ExecuteSQL(sb.ToString(), parameters);
        }


        /// <summary>
        /// 获取语句ID(所有)
        /// </summary>
        /// <returns></returns>
        public DataSet getBasicScriptID()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ScriptID FROM T_BasicScript ");
            return DBHelpSQL.QuerySQL(sb.ToString());
            
        }

        /// <summary>
        /// 获取最近更新的语句
        /// </summary>
        /// <param name="createTime"></param>
        /// <returns></returns>
        public DataSet getBasicScriptID(DateTime createTime)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ScriptID FROM T_BasicScript ");
            sb.Append("WHERE AddTime>=@createTime ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@createTime",SqlDbType.DateTime)
                                      };
            parameters[0].Value = createTime;
            return DBHelpSQL.QuerySQL(sb.ToString(), parameters);
        }

        /// <summary>
        /// 获取基本语句的ID
        /// </summary>
        /// <param name="BasicText"></param>
        /// <returns></returns>
        public int getScriptID(string BasicText)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM T_BasicScript ");
            sb.Append("WHERE BasicText=@BasicText ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@BasicText",SqlDbType.NVarChar,1500)
                                      };
            parameters[0].Value = BasicText;
            object returnInt = DBHelpSQL.CountQuerySQL(sb.ToString(), parameters);
            if ( returnInt== null)
            {
                return -1;
            }
            return Convert.ToInt32(returnInt);
        }

        public int getScriptID(string basicText, int positionID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ScriptID FROM T_BasicScript ");
            sb.Append("WHERE BasicText=@basicText ");
            sb.Append("AND PositionID=@positionID ");
            SqlParameter[] parameters ={
                                       new SqlParameter("@basicText",SqlDbType.NVarChar,1500),
                                       new SqlParameter("@positionID",SqlDbType.Int)
                                       };
            parameters[0].Value = basicText;
            parameters[1].Value = positionID;
            object obj = DBHelpSQL.CountQuerySQL(sb.ToString(), parameters);
            if (obj == null)
            {
                return -1;
            }
            return Convert.ToInt32(obj);
        }

        public int getScriptID(string basicText, int positionID, string position2)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ScriptID FROM T_BasicScript ");
            sb.Append("WHERE BasicText=@basicText AND PositionID=@positionID ");
            sb.Append("AND ( Reserved_1=@position2 OR Reserved_1 IS NULL) ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@basicText",SqlDbType.NVarChar,1500),
                                      new SqlParameter("@positionID",SqlDbType.Int),
                                      new SqlParameter("@position2",SqlDbType.NVarChar,50)
                                      };
            parameters[0].Value = basicText;
            parameters[1].Value = positionID;
            parameters[2].Value = position2;
            object obj = DBHelpSQL.CountQuerySQL(sb.ToString(), parameters);
            if (obj == null)
            {
                return -1;
            }
            return Convert.ToInt32(obj);
        }

        /// <summary>
        /// 修改基本语句
        /// </summary>
        /// <param name="ScriptID"></param>
        /// <param name="toBasic"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public int updateBasic(int ScriptID, string basicText,int positionID, string AdminName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE T_BasicScript ");
            sb.Append("SET BasicText=@basicText,PositionID=@positionID ,UpdateTime=GETDATE(),AdminName=@AdminName ");
            sb.Append("WHERE ScriptID=@ScriptID ");
            SqlParameter[] parameters ={
                                    new SqlParameter("@basicText",SqlDbType.NVarChar,300),
                                    new SqlParameter("@positionID",SqlDbType.Int),
                                    new SqlParameter("@AdminName",SqlDbType.NVarChar,20),
                                    new SqlParameter("@ScriptID",SqlDbType.Int)
                                    };
            parameters[0].Value = basicText;
            parameters[1].Value = positionID;
            parameters[2].Value = AdminName;
            parameters[3].Value = ScriptID;
            return DBHelpSQL.ExecuteSQL(sb.ToString(), parameters);
        }


        /// <summary>
        /// 获取某个项目的所有基本语言
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public DataSet getBasicScript(int projectID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT T_BasicScript.* ,T_Position.Position,T_Projects.ProjectName ");
            sb.Append("FROM T_BasicScript ,  T_Position , T_Projects  ");
            sb.Append("WHERE T_BasicScript.PositionID=T_Position.PositionID ");
            sb.Append("AND T_Position.ProjectID =T_Projects.ProjectID ");
            sb.Append("AND T_Projects.ProjectID=@projectID ");
            SqlParameter[] parameters ={
                                    new SqlParameter("@projectID",SqlDbType.Int)
                                    };
            parameters[0].Value = projectID;
            return DBHelpSQL.QuerySQL(sb.ToString(), parameters);
        }

        public DataSet getBasicScript(int[] projectIDs)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT T_BasicScript.* ,T_Position.Position,T_Projects.ProjectName ");
            sb.Append("FROM T_BasicScript ,  T_Position , T_Projects  ");
            sb.Append("WHERE T_BasicScript.PositionID=T_Position.PositionID ");
            sb.Append("AND T_Position.ProjectID =T_Projects.ProjectID ");
            sb.Append("AND ");
            sb.Append(" ( ");
            
            for (int i=0;i<projectIDs.Length ;i++)
            {
                sb.Append("T_Projects.ProjectID="+projectIDs[i]+" OR ");
            }
            sb.Remove(sb.Length-3, 3);
            sb.Append(" ) ");
            return DBHelpSQL.QuerySQL(sb.ToString());
            
        }

        /// <summary>
        /// 获取某个类的所有语言信息 
        /// </summary>
        /// <param name="positionID"></param>
        /// <param name="projectID"></param>
        /// <returns></returns>
        public DataSet getBasicScript(int positionID, int projectID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT T_BasicScript.* ,T_Position.Position,T_Projects.ProjectName ");
            sb.Append("FROM T_BasicScript ,  T_Position , T_Projects  ");
            sb.Append("WHERE T_BasicScript.PositionID=T_Position.PositionID ");
            sb.Append("AND T_Position.ProjectID =T_Projects.ProjectID ");
            sb.Append("AND T_BasicScript.PositionID=@positionID ");
            sb.Append("AND T_Projects.ProjectID=@projectID ");
            SqlParameter[] parameters ={
                                       new SqlParameter("@positionID",SqlDbType.Int),
                                       new SqlParameter("@projectID",SqlDbType.Int)
                                       };
            parameters[0].Value = positionID;
            parameters[1].Value = projectID;
            return DBHelpSQL.QuerySQL(sb.ToString(), parameters);
        }

        public DataSet getBasicScript(int projectId,int positionId, int pageSize, int pageIndex)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT TOP "+pageSize+" * FROM (");
            sb.Append("SELECT ROW_NUMBER() OVER(ORDER BY ScriptID) AS RowNum, T_BasicScript.*,T_Position.Position,T_Projects.ProjectName ");
            sb.Append("FROM T_BasicScript,T_Position,T_Projects ");
            sb.Append("WHERE T_BasicScript.PositionID=T_Position.PositionID ");
            sb.Append("AND T_Position.ProjectID=T_Projects.ProjectID ");
            sb.Append("AND T_Projects.ProjectID=" + projectId + " ");
            if (positionId != 0)
            {
                sb.Append("AND T_Position.PositionId=" + positionId + "");
            }
            sb.Append(") A ");
            sb.Append("WHERE RowNum>" + pageSize + "*" + pageIndex + " ");

            sb.Append("\n");
            sb.Append("SELECT COUNT(1) FROM T_BasicScript,T_Position,T_Projects ");
            sb.Append("WHERE T_BasicScript.PositionID=T_Position.PositionID ");
            sb.Append("AND T_Position.ProjectID=T_Projects.ProjectID ");
            sb.Append("AND T_Projects.ProjectID=" + projectId + " ");
            if (positionId != 0)
            {
                sb.Append("AND T_Position.PositionId=" + positionId + "");
            }
            return DBHelpSQL.QuerySQL(sb.ToString());
        }

        /// <summary>
        /// 是否存在相同信息
        /// </summary>
        /// <param name="basicText"></param>
        /// <returns></returns>
        public int existsBasicScript(string basicText,int positionID)
        {
            //StringBuilder sb = new StringBuilder();
            //sb.Append("SELECT COUNT(1) FROM T_BasicScript ");
            //sb.Append("WHERE BasicText=@basicText ");
            //sb.Append("AND positionID=@position ");
            //SqlParameter[] parameters ={
            //                          new SqlParameter("@basicText",SqlDbType.NVarChar,300),
            //                          new SqlParameter("@position",SqlDbType.Int)
            //                          };
            //parameters[0].Value = basicText;
            //parameters[1].Value = positionID;
            //return Convert.ToInt32(DBHelpSQL.CountQuerySQL(sb.ToString(), parameters));

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM T_BasicScript ");
            sb.Append("WHERE BasicText=@basicText ");
            sb.Append("AND PositionID=@positionID ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@basicText",SqlDbType.NVarChar,300),
                                      new SqlParameter("@positionID",SqlDbType.Int)
                                      };
            parameters[0].Value = basicText;
            parameters[1].Value = positionID;
            return Convert.ToInt32(DBHelpSQL.CountQuerySQL(sb.ToString(), parameters));
        }


        public DictionaryEntry paraAndSQLBasicInsert(int scriptID, int typeID, string basicText, string adminName)
        {
            DictionaryEntry de;
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO T_Script(ScriptID,TypeID,Content,AdminName) ");
            sb.Append("VALUES (@scriptID,@typeID,@content,@adminName) ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@scriptID",SqlDbType.Int),
                                      new SqlParameter("@typeID",SqlDbType.Int),
                                      new SqlParameter("@content",SqlDbType.NVarChar,1500),
                                      new SqlParameter("@adminName",SqlDbType.NVarChar,20)
                                      };
            parameters[0].Value = scriptID;
            parameters[1].Value = typeID;
            parameters[2].Value = basicText;
            parameters[3].Value = adminName;
            de = new DictionaryEntry(parameters, sb.ToString());
            return de;
        }

        /// <summary>
        /// 组成更新语句
        /// </summary>
        /// <param name="scriptID"></param>
        /// <param name="basicText"></param>
        /// <param name="adminName"></param>
        /// <returns></returns>
        public DictionaryEntry paraAndSQLBasicUpdate(int scriptID,string basicText,string adminName)
        {
            DictionaryEntry de;
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE T_BasicScript ");
            sb.Append("SET BasicText=@basicText,AdminName=@adminName,UpdateTime=GETDATE() ");
            sb.Append("WHERE ScriptID=@scriptID ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@basicText",SqlDbType.NVarChar,1500),
                                      new SqlParameter("@adminName",SqlDbType.NVarChar,20),
                                      new SqlParameter("@scriptID",SqlDbType.Int)
                                      };
            parameters[0].Value = basicText;
            parameters[1].Value = adminName;
            parameters[2].Value = scriptID;
            de = new DictionaryEntry(parameters, sb.ToString());
            return de;
        }
        #endregion

        #region 位置表操作（T_Position）
        /// <summary>
        /// 获取表信息
        /// </summary>
        /// <returns></returns>
        public DataSet getPosition()
        {
            StringBuilder sb = new StringBuilder();
            //SELECT T_Position.*,T_Projects.ProjectName FROM T_Position,T_Projects WHERE T_Position.ProjectID=T_Projects.ProjectID 

            sb.Append("SELECT T_Position.*,T_Projects.ProjectName ");
            sb.Append("FROM T_Position,T_Projects ");
            sb.Append("WHERE T_Position.ProjectID=T_Projects.ProjectID ");

            return DBHelpSQL.QuerySQL(sb.ToString());
        }

        public DataSet getPosition(int projectID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT T_Position.*,T_Projects.ProjectName ");
            sb.Append("FROM T_Position,T_Projects ");
            sb.Append("WHERE T_Position.ProjectID=T_Projects.ProjectID ");
            sb.Append("AND T_Projects.ProjectID=@projectID ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@projectID",SqlDbType.Int)
                                      };
            parameters[0].Value = projectID;
            return DBHelpSQL.QuerySQL(sb.ToString(), parameters);
        }

        public object getPositionID(string position,int projectID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM T_Position ");
            sb.Append("WHERE position=@position ");
            sb.Append("AND projectID=@projectID ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@position",SqlDbType.NVarChar,50),
                                      new SqlParameter("@projectID",SqlDbType.Int)
                                      };
            parameters[0].Value = position;
            parameters[1].Value = projectID;
            return DBHelpSQL.CountQuerySQL(sb.ToString(), parameters);
        }
        /// <summary>
        /// 将试图数据更新至数据库
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool updatePositionDt(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM T_Position ");

            return DBHelpSQL.UpdateView(sb.ToString(), dt);
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public int existsPosition( string position , int projectID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT COUNT(1) FROM T_Position ");
            sb.Append("WHERE Position=@position  ");
            sb.Append("AND ProjectID=@projectID ");
            SqlParameter[] parameters ={
                                      new  SqlParameter("@position",SqlDbType.NVarChar,50),
                                      new SqlParameter("@projectID",SqlDbType.Int)
                                      };
            parameters[0].Value = position;
            parameters[1].Value = projectID;
            int existsInt = Convert.ToInt32(DBHelpSQL.CountQuerySQL(sb.ToString(),parameters));
            return existsInt;
        }

        /// <summary>
        /// 添加窗体位置
        /// </summary>
        /// <param name="position"></param>
        /// <param name="adminName"></param>
        /// <returns></returns>
        public int insertPosition(string position,int projectID, string adminName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO T_Position(Position,ProjectID ,AdminName,AddTime) ");
            sb.Append("Values (@position,@projectID,@adminName,GETDATE()) ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@position",SqlDbType.NVarChar,50),
                                      new SqlParameter("@projectID",SqlDbType.Int),
                                      new SqlParameter("@adminName",SqlDbType.NVarChar,20)
                                      };
            parameters[0].Value = position;
            parameters[1].Value = projectID;
            parameters[2].Value = adminName;
            return DBHelpSQL.ExecuteSQL(sb.ToString(), parameters);
                
        }


        /// <summary>
        /// 更新信息
        /// </summary>
        /// <param name="positionID"></param>
        /// <param name="position"></param>
        /// <param name="projectID"></param>
        /// <param name="adminName"></param>
        /// <returns></returns>
        public int updatePosition(int positionID, string position, int projectID, string adminName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE T_Position ");
            sb.Append("SET Position=@position ,ProjectID=@projectID ,UpdateTime=GETDATE(), AdminName=@adminName ");
            sb.Append("WHERE PositionID=@positionID ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@position",SqlDbType.NVarChar,50),
                                      new SqlParameter("@projectID",SqlDbType.Int),
                                      new SqlParameter("@adminName",SqlDbType.NVarChar,20),
                                      new SqlParameter("@positionID",SqlDbType.Int)
                                      };
            parameters[0].Value = position;
            parameters[1].Value = projectID;
            parameters[2].Value = adminName;
            parameters[3].Value = positionID;
            return DBHelpSQL.ExecuteSQL(sb.ToString(), parameters);
        }
        #endregion

        #region 获取未进行输入语言翻译
        /// <summary>
        /// 获取未输入翻译的数量
        /// </summary>
        /// <returns></returns>
        public int getNotInputCount()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT COUNT(1) FROM T_Script ");
            sb.Append("WHERE Content='###' or Content= NULL");
            return Convert.ToInt32(DBHelpSQL.CountQuerySQL(sb.ToString()));
        }

        /// <summary>
        /// 获取未输入翻译的数量（某一种语言）
        /// </summary>
        /// <param name="TypeID">语言类型ID</param>
        /// <returns></returns>
        public int getNotInputCount(int TypeID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT COUNT(1) FROM T_Script ");
            sb.Append("WHERE (Content ='###' or Content= NULL) ");
            sb.Append("AND TypeID=@TypeID");
            SqlParameter[] parameters ={
                                       new SqlParameter("@TypeID",SqlDbType.Int)
                                       };
            parameters[0].Value = TypeID;
            return Convert.ToInt32(DBHelpSQL.CountQuerySQL(sb.ToString(), parameters));
        }

        /// <summary>
        /// 获取未输入的信息(结果集)
        /// </summary>
        /// <returns></returns>
        public DataSet getNoInput()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM T_Script ");
            sb.Append("WHERE Content='###' or Content= NULL");
            return DBHelpSQL.QuerySQL(sb.ToString());
        }

        /// <summary>
        /// 获取未输入的信息（结果集）（某种语言）
        /// </summary>
        /// <param name="TypeID">语言的ID</param>
        /// <returns></returns>
        public DataSet getNoInput(int TypeID)
        {
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM T_Script ");
            sb.Append("WHERE (Content ='###' or Content= NULL) ");
            sb.Append("AND TypeID=@TypeID ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@TypeID",SqlDbType.Int)
                                      };
            parameters[0].Value = TypeID;
            ds = DBHelpSQL.QuerySQL(sb.ToString(), parameters);
            return ds;
        }



        #endregion

        #region 对视图的相关查询操作

        public DataSet getV_Script(string LanguageName)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(LanguageName))
            {
                sb.Append("SELECT ScriptID,ProjectName,Position,BasicText ");  //最终显示的列（列名可以重复，使用参数赋值会异常，有待改进）
                sb.Append("FROM ");
                sb.Append("(");
                sb.Append("SELECT ScriptID,LanguageName,ProjectName,Position,Content,BasicText "); //此方法查找的是语言类型名（可以修改为中文）
                sb.Append("FROM V_ALLScript ");//数据源（视图）
                sb.Append(") P ");
            }
            else
            {
                sb.Append("SELECT ScriptID,ProjectName,Position,BasicText," + LanguageName + " ");  //最终显示的列（列名可以重复，使用参数赋值会异常，有待改进）
                sb.Append("FROM ");
                sb.Append("(");
                sb.Append("SELECT ScriptID,LanguageName,Position,ProjectName,Content,BasicText "); //此方法查找的是语言类型名（可以修改为中文）
                sb.Append("FROM V_ALLScript ");//数据源（视图）
                sb.Append(") P ");
                sb.Append("PIVOT"); //行转列关键字
                sb.Append("(");
                sb.Append("MIN(Content) ");
                sb.Append("FOR LanguageName in ");
                sb.Append("(" + LanguageName + ")");
                sb.Append(") ");
                sb.Append("AS T");
            }
            return DBHelpSQL.QuerySQL(sb.ToString());
        }

        /// <summary>
        /// 获取V_AllScript数据 以外语为列 分页
        /// </summary>
        /// <param name="languageName"></param>
        /// <param name="projectId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public DataSet getV_Script(string languageName, int projectId, int pageSize, int pageIndex)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(languageName))
            {
                sb.Append("SELECT TOP " + pageSize + " * ");
                sb.Append("FROM ( ");
                sb.Append("SELECT ROW_NUMBER() OVER (ORDER BY ScriptID) AS Number , ScriptID,ProjectName,Position,BasicText ");
                sb.Append("From V_AllScript ");
                if (projectId != 0)
                {
                    sb.Append("WHERE ProjectID=" + projectId + " ");
                }
                sb.Append(") A ");
                sb.Append("WHERE Number>" + pageSize + "*" + pageIndex + " ");
            }
            else
            {
                sb.Append("SELECT TOP " + pageSize + " * ");
                sb.Append("From ( ");
                sb.Append("SELECT ROW_NUMBER() OVER(ORDER BY ScriptID) AS Number, ScriptID,ProjectName,Position,BasicText,"+languageName+" ");
                sb.Append("FROM ( ");
                sb.Append("SELECT ScriptID,LanguageName2,Position,ProjectName,Content,BasicText ");
                sb.Append("FROM V_AllScript ");
                if (projectId != 0)
                {
                    sb.Append("WHERE ProjectId="+projectId+" ");
                }
                sb.Append(") P ");
                sb.Append("PIVOT ( ");
                sb.Append("MIN(Content) ");
                sb.Append("FOR LanguageName2 in ");
                sb.Append("(" + languageName + ") ");
                sb.Append(") AS T ");
                sb.Append(") A ");
                sb.Append("WHERE Number>"+pageSize+"*"+pageIndex+" ");
            }
            sb.Append("\n");
            if (projectId == 0)
            {
                sb.Append("SELECT COUNT(1) FROM T_BasicScript ");
            }
            else
            {
                sb.Append("SELECT COUNT(1) FROM T_BasicScript,T_Position ");
                sb.Append("WHERE T_Position.PositionID=T_BasicScript.PositionID ");
                sb.Append("AND ProjectID="+projectId+" ");
            }
            
            return DBHelpSQL.QuerySQL(sb.ToString());
        }

        public DataSet getV_Scriptt(string languageName,int projectId,string position,int pageSize,int pageIndex)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(languageName))
            {
                sb.Append("SELECT TOP" + pageSize + "  * FROM (");
                sb.Append("SELECT ROW_NUMBER() OVER (ORDER BY ScriptID) AS Number, ScriptID,ProjectName,Position,BasicText ");
                sb.Append("From V_AllScript ");
                if (projectId != 0)
                {
                    sb.Append("WHERE ProjectId="+projectId+" ");
                    if (position != "全部")
                    {
                        sb.Append("AND Position='" + position + "' ");
                    }
                }
                
                sb.Append(") A ");
                sb.Append("WHERE Number>" + pageSize + "* " + pageIndex + " ");
                
            }
            else
            {
                sb.Append("SELECT TOP " + pageSize + " * From (");
                sb.Append("SELECT ROW_NUMBER() OVER(ORDER BY BasicText ) AS Number, ScriptID,ProjectName,Position,BasicText," + languageName + " ");
                sb.Append("FROM ( ");
                sb.Append("SELECT ScriptID,LanguageName2,Position,ProjectName,Content,BasicText ");
                sb.Append("FROM V_AllScript  ");
                if (projectId != 0)
                {
                    sb.Append("WHERE ProjectID=" + projectId + " ");
                    if (position != "全部")
                    {
                        sb.Append("AND Position='" + position + "' ");
                    }
                }
                sb.Append(") P ");
                sb.Append("PIVOT ( ");
                sb.Append("MIN(Content) ");
                sb.Append("FOR LanguageName2 in ");
                sb.Append("(" + languageName + ") ");
                sb.Append(") AS T ");
                sb.Append(") A ");
                sb.Append("WHERE Number >" + pageSize + "*" + pageIndex + " ");

            }
            //sb.Append("ORDER BY BasicText ");
            sb.Append("\n");
            sb.Append("SELECT COUNT(1)  FROM T_BasicScript,T_Position,T_Projects ");
            sb.Append("WHERE T_BasicScript.PositionID=T_Position.PositionID ");
            sb.Append("AND T_Position.ProjectID=T_Projects.ProjectID ");
            if(projectId!=0)
            {
                sb.Append("AND T_Projects.ProjectId="+projectId+" ");
                if (position != "全部")
                {
                    sb.Append("AND T_Position.Position='"+position+"' ");
                }
            }
            
            return DBHelpSQL.QuerySQL(sb.ToString());
        }
        public DataSet getV_ScriptXml(int[] typeIDs,int [] projectIDs)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM V_ALLScript ");
            sb.Append("WHERE ");
            sb.Append(" ( ");
            for (int i = 0; i < typeIDs.Length; i++)
            {
                sb.Append("TypeID=" + typeIDs[i] + " OR ");
            };
            sb.Remove(sb.Length - 3, 3);
            sb.Append(" ) ");
            sb.Append(" AND ");
            sb.Append("(");

            for (int j = 0; j < projectIDs.Length; j++)
            { 
            sb.Append("ProjectID  ="+projectIDs[j]+" OR ");
            }
            sb.Remove(sb.Length - 3, 3);
            sb.Append(")");
            return DBHelpSQL.QuerySQL(sb.ToString());
        }

        /// <summary>
        /// 获取脚本数量
        /// </summary>
        /// <returns></returns>
        public int countV_Script()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT COUNT(1) FROM V_AllScript ");
            return Convert.ToInt32(DBHelpSQL.CountQuerySQL(sb.ToString()));
        }

        #endregion

        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="adminName">管理员名称</param>
        /// <param name="password">管理员密码</param>
        public int adminLogin(string adminName,string password)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE T_Admin ");
            sb.Append("SET LastLoginTime=GETDATE() ");
            sb.Append("WHERE AdminName=@adminName AND [Password]=@password ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@adminName",SqlDbType.NVarChar,20),
                                      new SqlParameter("@password",SqlDbType.NVarChar,20)
                                      };
            parameters[0].Value = adminName;
            parameters[1].Value = password;
            return DBHelpSQL.ExecuteSQL(sb.ToString(), parameters);
        }


        /// <summary>
        /// 执行多条数据库语句
        /// </summary>
        /// <param name="Sqlstrings"></param>
        /// <returns></returns>
        public bool ExecuteSQLs(Hashtable Sqlstrings)
        {
            try
            {
                DBHelpSQL.ExecuteSQLTran(Sqlstrings);
                return true;
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// 执行多条数据库语句(按照插入顺序)
        /// </summary>
        /// <param name="SQLlist"></param>
        /// <returns></returns>
        public bool ExecuteSQLs(List<DictionaryEntry> SQLlist)
        {
            try
            {
                DBHelpSQL.ExecuteSQLTran(SQLlist);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        #region 项目表操作（T_Projects）
        /// <summary>
        /// 获取所有项目信息
        /// </summary>
        /// <returns></returns>
        public DataSet getProjects()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM T_Projects");
            return DBHelpSQL.QuerySQL(sb.ToString());
        }

        /// <summary>
        /// 查看项目名称是否存在
        /// </summary>
        /// <param name="projectName"></param>
        /// <returns></returns>
        public int existsProject(string projectName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT COUNT(1) FROM T_Projects ");
            sb.Append("WHERE ProjectName=@projectName ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@projectName",SqlDbType.NVarChar,100)
                                      };
            parameters[0].Value = projectName;
            return Convert.ToInt32(DBHelpSQL.CountQuerySQL(sb.ToString(), parameters));
        }

        public int getProjectId(string projectName,string solutionName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ProjectID FROM T_Projects ");
            sb.Append("WHERE projectName=@projectName ");
            sb.Append("AND SolutionName=@solutionName ");
            SqlParameter[] parameters ={
                                      new SqlParameter("@projectName",SqlDbType.NVarChar,100),
                                      new SqlParameter("@solutionName",SqlDbType.NVarChar,100)
                                      };
            parameters[0].Value = projectName;
            parameters[1].Value = solutionName;
            return Convert.ToInt32(DBHelpSQL.CountQuerySQL(sb.ToString(), parameters));
        }

        /// <summary>
        /// 添加项目信息
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="solutionName"></param>
        /// <param name="remarks"></param>
        /// <param name="adminName"></param>
        /// <returns></returns>
        public int insertProject(string projectName, string solutionName, string remarks, string adminName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO T_Projects ");
            sb.Append("(ProjectName,SolutionName,LastModifyTime,Remarks,AddTime,AdminName) ");
            sb.Append("VALUES (@projectName,@solutionName,GETDATE(),@remarks,GETDATE(),@adminName)");
            SqlParameter[] parameters ={
                                      new SqlParameter("@projectName",SqlDbType.NVarChar,100),
                                      new SqlParameter("@solutionName",SqlDbType.NVarChar,100),
                                      new SqlParameter("@remarks",SqlDbType.NVarChar,1000),
                                      new SqlParameter("@adminName",SqlDbType.NVarChar,20)
                                      };
            parameters[0].Value = projectName;
            parameters[1].Value = solutionName;
            parameters[2].Value = remarks;
            parameters[3].Value = adminName;
            sb.Append("\n");
            return DBHelpSQL.ExecuteSQL(sb.ToString(), parameters);
        }

        /// <summary>
        /// 更新项目信息
        /// </summary>
        /// <param name="projectID"></param>
        /// <param name="projectName"></param>
        /// <param name="solutionName"></param>
        /// <param name="remarks"></param>
        /// <param name="adminName"></param>
        /// <returns></returns>
        public int updateProject(int projectID,string projectName,string solutionName,string remarks,string adminName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE T_Projects ");
            sb.Append("SET ProjectName=@projectName,SolutionName=@solutionName,Remarks=@remarks, ");
            sb.Append("LastModifyTime=GETDATE(), UpdateTime=GETDATE(),AdminName=@adminName ");
            sb.Append("WHERE ProjectID=@projectID ");
            SqlParameter[] parameters = {
                                       new SqlParameter("@projectName",SqlDbType.NVarChar,100),
                                       new SqlParameter("@solutionName",SqlDbType.NVarChar,100),
                                       new SqlParameter("@remarks",SqlDbType.NVarChar,1000),
                                       new SqlParameter("@adminName",SqlDbType.NVarChar,20),
                                       new SqlParameter("@projectID",SqlDbType.Int)
                                       };
            parameters[0].Value = projectName;
            parameters[1].Value = solutionName;
            parameters[2].Value = remarks;
            parameters[3].Value = adminName;
            parameters[4].Value = projectID;
            return DBHelpSQL.ExecuteSQL(sb.ToString(), parameters);
        }

        public DataSet getSelectedProject(int[] selectedProjetIDs)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM T_Projects ");
            sb.Append("WHERE ");
            for (int i = 0; i < selectedProjetIDs.Length; i++)
            {
                sb.Append("ProjectID=" + selectedProjetIDs[i] + " OR ");
            }
            sb.Remove(sb.Length - 3, 3);
            return DBHelpSQL.QuerySQL(sb.ToString());
        }
        #endregion



        public static int dbExists()
        {
            try
            {
                return DBHelpSQL.dbExists("LanguageDB");
            }
            catch
            {
                return -1;
            }
        }


        public string getScriptContent(int scriptId, int typeId)
        {
            StringBuilder sb = new StringBuilder();
            if (typeId == 0)
            {
                sb.Append("SELECT BasicText FROM T_BasicScript ");
                sb.Append("WHERE ScriptID=@scriptId ");
                SqlParameter[] parameters ={
                                          new SqlParameter("@scriptId",SqlDbType.Int)
                                          };
                parameters[0].Value = scriptId;
                return Convert.ToString(DBHelpSQL.CountQuerySQL(sb.ToString(), parameters));
            }
            else
            {
                sb.Append("SELECT Content FROM T_Script ");
                sb.Append("WHERE ScriptID=@scriptId ");
                sb.Append("AND TypeID=@typeId ");
                SqlParameter[] parameters ={
                                          new SqlParameter("@scriptId",SqlDbType.Int),
                                          new SqlParameter("@typeId",SqlDbType.Int)
                                          };
                parameters[0].Value = scriptId;
                parameters[1].Value = typeId;
                return Convert.ToString(DBHelpSQL.CountQuerySQL(sb.ToString(), parameters));
            }
        }

    }
}
