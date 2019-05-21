using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using MvcWebSite.Models;
using MvcWebSite.Utils;

namespace MvcWebSite.Base
{
    public class DBUtils
    {
        public static string classconnstrings = System.Configuration.ConfigurationManager.ConnectionStrings["YGHD"].ConnectionString;

        public List<Menu> GetNav(string sql)
        {
            List<Menu> returnlist = new List<Menu>();
            List<Menu> remainlist = new List<Menu>();
            using (SqlConnection conn = new SqlConnection(classconnstrings))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Menu menu = new Menu(dr);
                        if (menu.PID == -1)
                        {
                            returnlist.Add(menu);
                        }
                        else
                        {
                            if (returnlist.FirstOrDefault(t => t.MID == menu.PID) != null)
                            {
                                returnlist.FirstOrDefault(t => t.MID == menu.PID).ChildMenu.Add(menu);
                            }
                            else
                            {
                                remainlist.Add(menu);
                            }
                        }
                    }
                    conn.Close();
                }
            };

            foreach (Menu menu in remainlist)
            {
                if (returnlist.FirstOrDefault(t => t.MID == menu.PID) != null)
                {
                    returnlist.FirstOrDefault(t => t.MID == menu.PID).ChildMenu.Add(menu);
                }
            }

            foreach (Menu menu in returnlist)
            {
                menu.ChildMenu = menu.ChildMenu.OrderBy(t => t.MOrder).ToList();
            }

            return returnlist;
        }

        public List<Slide> GetFriendLink(int tflag, int id = 0)
        {
            string sql = "";

            if (id != 0)
            {
                sql = string.Format("select a.* from [Tb_Web_Slide]a,[Tb_Web_SlideType]b where [InvalidDate]>GETDATE() and a.[Isdel]=0 and a.[SType]=b.[SType] and b.[TFlag]={0} and b.[SType]={1}", tflag, id);
            }
            else
            {
                sql = string.Format("select a.* from [Tb_Web_Slide]a,[Tb_Web_SlideType]b where [InvalidDate]>GETDATE() and a.[Isdel]=0 and a.[SType]=b.[SType] and b.[TFlag]={0}", tflag);
            }

            List<Slide> returnlist = new List<Slide>();
            using (SqlConnection conn = new SqlConnection(classconnstrings))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        returnlist.Add(new Slide(dr));
                    }
                    conn.Close();
                }
            };
            return returnlist;
        }

        public List<Course> GetCourse(string sql)
        {
            List<Course> returnlist = new List<Course>();
            using (SqlConnection conn = new SqlConnection(classconnstrings))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        returnlist.Add(new Course(dr));
                    }
                    conn.Close();
                }
            };
            return returnlist;
        }

        public Course GetCourseByID(int id)
        {
            string sql = string.Format("select * from [Tb_Course] where [CID]={0}", id);
            Course data = new Course();
            using (SqlConnection conn = new SqlConnection(classconnstrings))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        data = new Course(dr);
                    }
                    conn.Close();
                }
            };
            return data;
        }

        public Site GetSite()
        {
            string sql = "select top 1 * from [Tb_Web_Site] where [Isdel]=0 ";
            Site data = new Site();
            using (SqlConnection conn = new SqlConnection(classconnstrings))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        data = new Site(dr);
                    }
                    conn.Close();
                }
            };
            return data;
        }


        public List<GradeLevel> GetGradeLevel(string sql)
        {
            List<GradeLevel> returnlist = new List<GradeLevel>();
            using (SqlConnection conn = new SqlConnection(classconnstrings))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        returnlist.Add(new GradeLevel(dr));
                    }
                    conn.Close();
                }
            };
            return returnlist;
        }

        public GradeLevel GetGradeLevelByID(int id)
        {
            string sql = string.Format("select * from [Tb_Grade_Level] where [GLID]={0}", id);
            GradeLevel data = new GradeLevel();
            using (SqlConnection conn = new SqlConnection(classconnstrings))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        data = new GradeLevel(dr);
                    }
                    conn.Close();
                }
            };
            return data;
        }




        public List<Comment> GetComment(string sql)
        {
            List<Comment> returnlist = new List<Comment>();
            using (SqlConnection conn = new SqlConnection(classconnstrings))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        returnlist.Add(new Comment(dr));
                    }
                    conn.Close();
                }
            };
            return returnlist;
        }

        public List<Menu> GetMenuByParentID(int id)
        {
            string sql = string.Format("select * from [Tb_Web_Menu] where [PID]={0} and [MType]!=1 and [MType]!=3", id);
            List<Menu> returnlist = new List<Menu>();
            using (SqlConnection conn = new SqlConnection(classconnstrings))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        returnlist.Add(new Menu(dr));
                    }
                    conn.Close();
                }
            };
            return returnlist;
        }


        public Menu GetMenuByID(int id)
        {
            string sql = string.Format("select * from [Tb_Web_Menu]");
            if (id != 0)
            {
                sql = sql + " where MID=" + id;
            }
            Menu data = new Menu();
            using (SqlConnection conn = new SqlConnection(classconnstrings))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        data = new Menu(dr);
                        data.ChildMenu = this.GetMenuByParentID(data.MID);
                        for (int i = 0; i < data.ChildMenu.Count; i++)
                        {
                            data.ChildMenu[i] = GetMenuByID(data.ChildMenu[i].MID);
                        }
                    }
                    conn.Close();
                }
            };
            return data;
        }

        public New GetNewByID(int id)
        {
            string sql = string.Format("select *,dbo.getUserName(a.NAuthor) as 'NAuthorName',dbo.getUserName(a.AduitUser) as 'AduitUserName',c.MName from  [Tb_Web_News] a,[Tb_Web_Menu] c where c.[MID]=a.[MID] and a.nid={0}", id);

            //string sql = string.Format("select *,a.RealName as 'NAuthorName',b.RealName as 'AduitUserName',c.MName from [Tb_Web_News],[Tb_SysUser] a,[Tb_SysUser]b,[Tb_Web_Menu] c where a.UID=[Tb_Web_News].NAuthor and b.UID=[Tb_Web_News].AduitUser and c.[MID]=[Tb_Web_News].[MID] and [NID]={0}", id);
            New data = new New();
            using (SqlConnection conn = new SqlConnection(classconnstrings))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        data = new New(dr);
                    }
                    conn.Close();
                }
            };
            //还需要加一点击量
            sql = string.Format("update [Tb_Web_News] set ReadCount=( case when ReadCount is null then 1 else ReadCount+1 end ) where nid={0}", id);
            DoSql(sql);


            return data;
        }

        public int GetNewCount(int menuid = 0, string menulist = "", bool ischild = false, bool isimagenew = false, bool isrecommand = false, bool istop = false, string searchtext = "")
        {
            int count = 0;
            string sql = "SELECT count(NID) as 'Count' from [Tb_Web_News] a";
            if (ischild)
            {
                sql = sql + ",[Tb_Web_Menu] b";
            }
            sql = sql + "  where (a.[isdel]=0 and a.[IsAudit]=1";
            if (menuid != 0 || !string.IsNullOrEmpty(menulist))
            {
                if (ischild)
                {
                    if (string.IsNullOrEmpty(menulist))
                    {
                        sql = sql + "  and a.[MID]=b.[MID] and (b.[MID]=" + menuid + " or b.[PID]=" + menuid + ") ";
                    }
                    else
                    {
                        sql = sql + "  and a.[MID]=b.[MID] and (";
                        foreach (string mid in menulist.Split(','))
                        {
                            try
                            {
                                sql = sql + " (b.[MID]=" + Convert.ToInt32(mid) + " or b.[PID]=" + Convert.ToInt32(mid) + ") or";
                            }
                            catch
                            {

                            }
                        }
                        sql = sql.Substring(0, sql.Length - 2) + ")";
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(menulist))
                    {
                        sql = sql + " and a.[MID]=" + menuid;
                    }
                    else
                    {
                        sql = sql + "  and (";
                        foreach (string mid in menulist.Split(','))
                        {
                            try
                            {
                                sql = sql + "(a.[MID]=" + Convert.ToInt32(mid) + ") or";
                            }
                            catch
                            {

                            }

                        }
                        sql = sql.Substring(0, sql.Length - 2) + ")";
                    }
                }

            }
            if (!string.IsNullOrEmpty(searchtext))
            {
                //防注入
                searchtext = searchtext.Replace("'", "''");
                sql = sql + "  and [NewsTitle] like '%" + searchtext + "%'";
            }
            if (isimagenew)
            {
                sql = sql + "  and [IsImgNews]=1";
            }
            if (isrecommand)
            {
                sql = sql + "  and [IsRecommend]=1";
            }
            sql = sql + ")";

            using (SqlConnection conn = new SqlConnection(classconnstrings))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        count = Convert.ToInt32(dr["Count"]);
                    }
                    conn.Close();
                }
            };


            return count;
        }

        public List<New> GetNew(int menuid = 0, string menulist = "", bool ischild = false, bool isimagenew = false, bool isrecommand = false, bool istop = false, int pageindex = 1, int pagesize = 10, int contentcount = 50, string searchtext = "")
        {
            //需要优化
            string sql = "DECLARE @indextable TABLE(rowid INT IDENTITY(1,1),nid int)"
+ "  INSERT INTO @indextable(nid)"
+ "  SELECT NID  from [Tb_Web_News] a";
            if (ischild)
            {
                sql = sql + ",[Tb_Web_Menu] b";
            }
            sql = sql + "  where (a.[isdel]=0 and a.[AuditState]=1 and a.[Nstate]=1";
            if (menuid != 0 || !string.IsNullOrEmpty(menulist))
            {
                if (ischild)
                {
                    //获取真正的menulist

                    if (string.IsNullOrEmpty(menulist))
                    {
                        menulist = GetChildMenu(menuid.ToString());
                    }
                    else
                    {
                        menulist = GetChildMenu(menulist);
                    }

                    menulist = menulist.TrimEnd(',');

                    if (string.IsNullOrEmpty(menulist))
                    {
                        sql = sql + "  and a.[MID]=b.[MID] and (b.[MID]=" + menuid + " or b.[PID]=" + menuid + ") ";
                    }
                    else
                    {
                        sql = sql + "  and a.[MID]=b.[MID] and (";
                        foreach (string mid in menulist.Split(','))
                        {
                            try
                            {
                                sql = sql + " (b.[MID]=" + Convert.ToInt32(mid) + " or b.[PID]=" + Convert.ToInt32(mid) + ") or";
                            }
                            catch
                            {

                            }
                        }
                        sql = sql.Substring(0, sql.Length - 2) + ")";
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(menulist))
                    {
                        sql = sql + " and a.[MID]=" + menuid;
                    }
                    else
                    {
                        sql = sql + "  and (";
                        foreach (string mid in menulist.Split(','))
                        {
                            try
                            {
                                sql = sql + "(a.[MID]=" + Convert.ToInt32(mid) + ") or";
                            }
                            catch
                            {

                            }

                        }
                        sql = sql.Substring(0, sql.Length - 2) + ")";
                    }
                }

            }
            if (!string.IsNullOrEmpty(searchtext))
            {
                //防注入
                searchtext = searchtext.Replace("'", "''");
                sql = sql + "  and [NewsTitle] like '%" + searchtext + "%'";
            }
            if (isimagenew)
            {
                sql = sql + "  and [IsImgNews]=1";
            }
            if (isrecommand)
            {
                sql = sql + "  and [IsRecommend]=1";
            }

            sql = sql + ")   order by";
            if (istop)
            {
                sql = sql + "  [IsTop] desc,";
                ;
            }
            sql = sql + " [NOrder],[CreateDate] desc";
            sql = sql
+ " select m.* from (select b.*,c.RealName as 'NAuthorName',d.RealName as 'AduitUserName',e.MName "
+ " from [Tb_Web_News] b,[Tb_SysUser] c,[Tb_SysUser] d,[Tb_Web_Menu] e "
+ " where c.UID=b.NAuthor and d.UID=b.AduitUser and b.MID=e.MID "
+ " union all "
+ " select b.*,c.RealName as 'NAuthorName','' as 'AduitUserName',e.MName "
+ " from [Tb_Web_News] b,[Tb_SysUser] c,[Tb_Web_Menu] e "
+ " where c.UID=b.NAuthor and (b.AduitUser is null or b.AduitUser='') and b.MID=e.MID "
+ " union all "
+ " select b.*,'' as 'NAuthorName',d.RealName as 'AduitUserName',e.MName "
+ " from [Tb_Web_News] b,[Tb_SysUser] d,[Tb_Web_Menu] e "
+ " where (b.NAuthor is null or b.NAuthor='') and d.UID=b.AduitUser and b.MID=e.MID "
+ "  union all "
+ " select b.*,'' as 'NAuthorName','' as 'AduitUserName',e.MName "
+ " from [Tb_Web_News] b,[Tb_Web_Menu] e "
+ " where (b.NAuthor is null or b.NAuthor='') and  (b.AduitUser is null or b.AduitUser='') and b.MID=e.MID "
+ " ) m,@indextable t"
+ "  where t.nid=m.NID and t.rowid>" + (pageindex - 1) * pagesize + " and t.rowid<=" + pageindex * pagesize + " order by t.rowid ";

            List<New> returnlist = new List<New>();
            using (SqlConnection conn = new SqlConnection(classconnstrings))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        returnlist.Add(new New(dr));
                    }
                    conn.Close();
                }
            };

            foreach (New news in returnlist)
            {
                news.NContent = new BaseUtils().InitContent(news.NContent);
                if (news.NContent.Length > contentcount)
                {
                    news.NContent = news.NContent.Substring(0, contentcount) + "……";
                }
            }

            return returnlist;
        }

        public List<EduResource> GetResource(int gid = 0, int cid = 0, int etype = 0)
        {
            string sql = "select * from [Tb_EduResource] where [IsOpen]=1 and [AuditState]=1";
            if (gid != 0)
            {
                sql = sql + "  and [GID]=" + gid;
            }
            if (cid != 0)
            {
                sql = sql + "  and [CID]=" + cid;
            }
            if (etype != 0)
            {
                sql = sql + "  and [EType]=" + etype;
            }
            sql = sql + "   order by CreateDate desc";

            List<EduResource> returnlist = new List<EduResource>();
            using (SqlConnection conn = new SqlConnection(classconnstrings))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        returnlist.Add(new EduResource(dr));
                    }
                    conn.Close();
                }
            };
            return returnlist;
        }



        public Details MainDetails(string userid)
        {
            Details details = new Details();
            string sql = "exec [up_Tb_Main_Paged] '" + userid + "'";
            using (SqlConnection conn = new SqlConnection(classconnstrings))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        details = new Details(dr);
                    }
                    conn.Close();
                }
            };
            return details;
        }

        public bool IsLoginSuccess(string username, string password, out SysUser user)
        {
            bool result = false;
            user = new SysUser();
            string sql = "exec [up_Tb_SysUser_Login] @username,@password,'-1'";
            using (SqlConnection conn = new SqlConnection(classconnstrings))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar, 40).Value = username;
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar, 40).Value = password;
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        //若不是-1则登录
                        string userid = dr[0].ToString();
                        if (userid != "-1")
                        {
                            user = LoginCookie(userid);
                            result = true;
                        }
                        else
                        {
                            break;
                        }
                    }
                    conn.Close();
                }
            };


            return result;
        }


        public SysUser LoginCookie(string id)
        {
            string sql = "SELECT *,[dbo].getUstate(UState) UStateName,dbo.getDepName(DepID) DepName,dbo.getStuMark(UID) Mark,dbo.getCampusName(CID) as CampusName FROM [Tb_SysUser] WHERE [UID] = '" + id + "'";
            SysUser user = new SysUser();
            using (SqlConnection conn = new SqlConnection(classconnstrings))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        //若不是-1则登录                        
                        user = new SysUser(dr);
                    }
                    conn.Close();
                }
            };


            return user;
        }


        public List<KeyValuePair<int, string>> UserNewCount()
        {
            string sql = "select count(1) as 'Count',dbo.getUserName(NAuthor) as 'Name' from [Tb_Web_News] group by NAuthor";

            List<KeyValuePair<int, string>> usernewlist = new List<KeyValuePair<int, string>>();
            using (SqlConnection conn = new SqlConnection(classconnstrings))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        //若不是-1则登录  
                        if (!string.IsNullOrEmpty(dr["Name"].ToString()))
                        {
                            usernewlist.Add(new KeyValuePair<int, string>(Convert.ToInt32(dr["Count"]), dr["Name"].ToString()));
                        }
                    }
                    conn.Close();
                }
            };

            usernewlist = usernewlist.OrderByDescending(t => t.Key).ToList();
            return usernewlist;
        }


        public List<Menu> GetFullPath(int mid)
        {
            List<Menu> menulist = new List<Menu>();
            string sql = "declare @mid varchar(50) ='' declare @mname varchar(50) ='' declare @id int =" + mid + " while @id>0 begin select @mid=@mid+CONVERT(varchar(50), mid)+',' ,@mname=@mname+mname+',',@id=pid from [Tb_Web_Menu] where mid=@id end select @mid as 'MidList',@mname as 'MNameList'";
            using (SqlConnection conn = new SqlConnection(classconnstrings))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        string midlist = dr["MidList"].ToString();
                        string namelist = dr["MNameList"].ToString();

                        for (int i = 0; i < midlist.Split(',').Length; i++)
                        {
                            if (!string.IsNullOrEmpty(midlist.Split(',')[i]) && !string.IsNullOrEmpty(namelist.Split(',')[i]))
                            {
                                menulist.Add(new Menu
                                {
                                    MID = Convert.ToInt32(midlist.Split(',')[i]),
                                    MName = namelist.Split(',')[i]
                                });
                            }
                        }


                    }
                    conn.Close();
                }
            }
            return menulist;
        }


        public void InsertPrinMailbox(string linktype, string pmcontent, string realname, string link)
        {
            string sql = "insert into Tb_PrinMailbox ([PMContent],[RealName],[@linktype]) values (@pmcontent,@realname,@link)";
            using (SqlConnection conn = new SqlConnection(classconnstrings))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@linktype", SqlDbType.NVarChar, 40).Value = linktype;
                    cmd.Parameters.Add("@pmcontent", SqlDbType.NVarChar, 1000).Value = pmcontent;
                    cmd.Parameters.Add("@realname", SqlDbType.NVarChar, 40).Value = realname;
                    cmd.Parameters.Add("@link", SqlDbType.NVarChar, 40).Value = link;
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            };
        }

        public void InsertComment(int nid, string title, string content, string linkuser, string linktype)
        {
            New thisnew = this.GetNewByID(nid);
            Menu menu = this.GetMenuByID(thisnew.MID);
            string sql = "insert into [Tb_Web_Comment] ([CID],[NID],[ComTitle],[ComContent],[LinkUser],[LinkType],[IsPublish],[ComDate],[Isdel],[CFlag]) values ((SELECT CID=(case when max([CID]) is null then 1 else max([CID])+1 end) FROM [Tb_Web_Comment]),@nid,@title,@content,@linkuser,@linktype," + (menu.IsAudit == 1 ? "0" : "1") + ",GETDATE(),0,2)";
            using (SqlConnection conn = new SqlConnection(classconnstrings))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@nid", SqlDbType.Int, 4).Value = nid;
                    cmd.Parameters.Add("@title", SqlDbType.NVarChar, 100).Value = title;
                    cmd.Parameters.Add("@content", SqlDbType.NVarChar, 1000).Value = content;
                    cmd.Parameters.Add("@linkuser", SqlDbType.NVarChar, 40).Value = linkuser;
                    cmd.Parameters.Add("@linktype", SqlDbType.NVarChar, 40).Value = linktype;
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            };
        }


        public void DoSql(string sql)
        {
            if (filterSql(sql))
            {
                using (SqlConnection conn = new SqlConnection(classconnstrings))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                };
            }
        }

        public bool filterSql(string sSql)
        {
            int srcLen, decLen = 0;
            sSql = sSql.ToLower().Trim();
            srcLen = sSql.Length;
            sSql = sSql.Replace("exec", "");
            sSql = sSql.Replace("delete", "");
            sSql = sSql.Replace("master", "");
            sSql = sSql.Replace("truncate", "");
            sSql = sSql.Replace("declare", "");
            sSql = sSql.Replace("create", "");
            sSql = sSql.Replace("xp_", "no");
            decLen = sSql.Length;
            if (srcLen == decLen) return true; else return false;
        }

        private string GetChildMenu(string menulist, string result = "")
        {
            if (string.IsNullOrEmpty(menulist))
            {
                return "";
            }
            else
            {
                foreach (string mid in menulist.Split(','))
                {
                    Menu menu = GetMenuByID(Convert.ToInt32(mid));
                    if (menu.ChildMenu.Count > 0)
                    {
                        foreach (Menu childmenu in menu.ChildMenu)
                        {
                            result = result + GetChildMenu(childmenu.MID.ToString(), "") + ",";
                        }
                    }
                    else
                    {
                        return result + mid;
                    }
                }
            }

            return result;
        }

    }
}