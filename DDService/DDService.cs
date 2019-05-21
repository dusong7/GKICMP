using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DDService
{
    public partial class DDService : ServiceBase
    {
        public DDService()
        {
            InitializeComponent();
        }

        public DateTime BeginDate = DateTime.Now;
        public DateTime EndDate = DateTime.Now;
        public JArray UserList = new JArray();

        public List<JArray> CUserList = new List<JArray>();

        protected override void OnStart(string[] args)
        {

            #region 职员工userid列表 存储在CUserList[i]中

            int ddcount =  new DDUtils().GetFactoryEmployeeCount();//获取通讯录总人数
            int yu = ddcount % 50;//取余
            int zeng = ddcount / 50;//取整
            int tt = 0;
            if (yu > 0)
            {
                zeng = zeng + 1;
            }
            for (int i = 0; i < zeng; i++)
            {
                tt = 50 * i;
                new DDUtils().ToBuildUserList(i, tt);//分页查询企业在职员工userid列表 存储在CUserList[i]中
            }

           // BuildUserList();
            System.Timers.Timer timer = new System.Timers.Timer(60000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(GetAttendence);
            timer.Enabled = true;
            #endregion


           
        }

        //钉钉ID 测试
        public void BuildUserList()
        {
            UserList.Add("03452243497666");
            UserList.Add("085146610134609723");
            UserList.Add("056415482627289950");
            UserList.Add("055551150027113057");
            UserList.Add("03153664332360");
            UserList.Add("065454412029179344");
            UserList.Add("04132266231212971");
        }

      
        //开始执行
        public void GetAttendence(object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                new DDUtils().GetAttendance(BeginDate, EndDate, UserList);
                BeginDate = EndDate;
                EndDate = DateTime.Now;
            }
            catch (Exception ex)
            {

            }

        }

        //开始执行 2
        public void ToGetAttendence(object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                for (int c = 0; c < CUserList.Count; c++)
                {
                    new DDUtils().ToGetAttendance(BeginDate, EndDate, CUserList, c);
                    //ToGetAttendance(BeginDate, EndDate, CUserList, c);
                }
                BeginDate = EndDate;
                EndDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(@"d:\DDKQ.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.WriteLine("执行插入错误原因(WindowsService: Service Exception)：" + ex.Message + "\n");
                sw.Flush();
                sw.Close();
                fs.Close();
            }

        }

        protected override void OnStop()
        {
        }

    }
}
