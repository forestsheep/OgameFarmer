using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalaxyFarmer
{
    internal class ConstString
    {
        /// <summary>
        /// Access数据库访问程序未装提示
        /// </summary>
        internal const string suggest_db_conn_program_not_install = "您很有可能未安装数据库连接程序，建议下载并安装：\r\ndownload.microsoft.com/download/7/0/3/703ffbcb-dc0c-4e19-b0da-1463960fdcdb/AccessDatabaseEngine.exe";

        /// <summary>
        /// 返回的HTML content临时存放地点
        /// </summary>
        internal const string HTML_PATH = "html.txt";

        /// <summary>
        /// 不能同时访问页面的错误提示
        /// </summary>
        internal const string CANNOT_DO_MUTLTI_THINGS = "你不能同时做两件事！";
    }
}
