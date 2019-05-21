using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using MvcWebSite.Models;

namespace MvcWebSite.Base
{
    public class DBUtils
    {
        public static string classconnstrings = System.Configuration.ConfigurationManager.ConnectionStrings["YGHD"].ConnectionString;

        public List<Menu> GetNav(string sql)
        {
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
                        }
                    }
                    conn.Close();
                }
            };
            return returnlist;
        }

        public List<Slide> GetFriendLink(int tflag)
        {
            string sql = "select a.* from [Tb_Web_Slide]a,[Tb_Web_SlideType]b where a.[Isdel]=0 and a.[SType]=b.[SType] and b.[TFlag]=" + tflag;
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
            string sql = "select * from [Tb_Course] where [CID]=" + id;
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
            string sql = "select * from [Tb_Grade_Level] where [GLID]=" + id;
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
            string sql = "select * from [Tb_Web_Menu] where [PID]=" + id;
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
            string sql = "select * from [Tb_Web_Menu] where MID=" + id;
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
                    }
                    conn.Close();
                }
            };
            return data;
        }

        public New GetNewByID(int id)
        {
            string sql = "select *,a.RealName as 'NAuthorName',b.RealName as 'AduitUserName' from [Tb_Web_News],[Tb_SysUser] a,[Tb_SysUser]b where a.UID=[Tb_Web_News].NAuthor and b.UID=[Tb_Web_News].AduitUser and [NID]=" + id;
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
            return data;
        }

        public List<New> GetNew(int menuid = 0, bool isimagenew = false, bool isrecommand = false, int pageindex = 1, int pagesize = 10)
        {
            string sql = "DECLARE @indextable TABLE(rowid INT IDENTITY(1,1),nid int)"
+ "  INSERT INTO @indextable(nid)"
+ "  SELECT NID  from [Tb_Web_News]"
+ "  where ([isdel]=0 and [IsAudit]=1";
            if (menuid != 0)
            {
                sql = sql + "  and [MID]=" + menuid;
            }
            if (isimagenew)
            {
                sql = sql + "  and [IsImgNews]=1";
            }
            if (isrecommand)
            {
                sql = sql + "  and [IsRecommend]=1";
            }
            sql = sql + ")   order by [IsTop] desc,[CreateDate] desc";
            sql = sql
+ "  select b.*,c.RealName as 'NAuthorName',d.RealName as 'AduitUserName' from @indextable t,[Tb_Web_News] b,[Tb_SysUser] c,[Tb_SysUser]d "
+ "  where t.nid=b.NID and c.UID=b.NAuthor and d.UID=b.AduitUser  and t.rowid>" + (pageindex - 1) * pagesize + " and t.rowid<=" + pagesize;

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


        public void AddComment(int nid, string title, string content, string linkuser, string linktype)
        {
            string sql = "insert into [Tb_Web_Comment] ([CID],[NID],[ComTitle],[ComContent],[LinkUser],[LinkType],[IsPublish],[ComDate],[Isdel],[CFlag])"
                          + "values ((SELECT CID=max(CID)+1 FROM [Tb_Web_Comment])," + nid + ",'" + title + "','" + content + "','" + linkuser + "','" + linktype + "',1,GETDATE(),0,2)";
            New data = new New();
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
}