/*****************************************************************
** Copyright (c) 芜湖高科电子有限公司
** 创 建 人:      LFZ
** 创建日期:      2017年09月21日 09点31分
** 描   述:      实体类
** 修 改 人:      
** 修改日期:    
** 修改说明:
**-----------------------------------------------------------------
******************************************************************/
using System;

namespace GK.GKICMP.Entities
{

    public class MessageConfigEntity
    {

        /// <summary>
        /// MessageConfig表实体
        ///</summary>
        public MessageConfigEntity()
        {
        }


        /// <summary>
        /// MessageConfig表实体
        /// </summary>
        /// <param name="id"></param>
        /// <param name="url"></param>
        /// <param name="appkey"></param>
        /// <param name="secret"></param>
        /// <param name="singname"></param>
        /// <param name="tempcode"></param>
        /// <param name="dtype"></param>
        public MessageConfigEntity(int id, string url, string appkey, string secret, string singname, string tempcode, int dtype)
        {
            this.ID = id;
            this.Url = url;
            this.AppKey = appkey;
            this.Secret = secret;
            this.SingName = singname;
            this.TempCode = tempcode;
            this.DType = dtype;
        }

        private int id;//
        private string url;//
        private string appkey;//
        private string secret;//
        private string singname;//
        private string tempcode;//
        private int dtype;//


        ///<summary>
        ///
        ///</summary>
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public string AppKey
        {
            get
            {
                return appkey;
            }
            set
            {
                appkey = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public string Secret
        {
            get
            {
                return secret;
            }
            set
            {
                secret = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public string SingName
        {
            get
            {
                return singname;
            }
            set
            {
                singname = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public string TempCode
        {
            get
            {
                return tempcode;
            }
            set
            {
                tempcode = value;
            }
        }

        ///<summary>
        ///
        ///</summary>
        public int DType
        {
            get
            {
                return dtype;
            }
            set
            {
                dtype = value;
            }
        }
    }
}

