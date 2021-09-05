using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CSharp_EventLog
{
    class GetEventLog
    {
        public static void EventLog_4624(string name = "EventLogResults.txt")
        {
            //判断要写入的结果文件是否存在, 不存在则创建文件
            string file = $@"{Directory.GetCurrentDirectory()}\{name}";

            if (File.Exists(file) == false)
            {
                CreateFileWrite.CreateFile(file);
            }

            EventLog log = new EventLog("Security");  //读取 "安全日志"

            IEnumerable<EventLogEntry> entries = log.Entries.Cast<EventLogEntry>().Where(x => x.InstanceId == 4624);  //读取4624日志
            foreach (EventLogEntry log1 in entries)
            {
                string text = log1.Message;
                string ipaddress = SelectContent.SelectEventLogContent(text, "源网络地址:	", "源端口:");
                string signInToProcess = SelectContent.SelectEventLogContent(text, "新登录:", "进程信息:");
                string username = SelectContent.SelectEventLogContent(signInToProcess, "帐户名:		", "帐户域:");
                if (username == string.Empty)
                {
                    username = SelectContent.SelectEventLogContent(signInToProcess, "帐户名称:		", "帐户域:");
                }

                string accountDomain = SelectContent.SelectEventLogContent(signInToProcess, "帐户域:		", "登录 ID:");

                DateTime time = log1.TimeGenerated;  //事件发生时间

                if (ipaddress.Length >= 7)  //判断ip长度大于等于7则写入ip
                {
                    CreateFileWrite.WriteFile(file, "\r\n-----------------------------------");

                    //写入事件发生时间
                    CreateFileWrite.WriteFile(file, "Time: " + time);

                    //写入账户名
                    CreateFileWrite.WriteFile(file, "UserName: " + username.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", ""));

                    //写入域
                    CreateFileWrite.WriteFile(file, "AccountDomain: " + accountDomain.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", ""));

                    //写入ip
                    CreateFileWrite.WriteFile(file, "Remote ip: " + ipaddress.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", ""));
                }
            }
        }

        public static void EventLog_4625(string name = "EventLogResults.txt")
        {
            //判断要写入的结果文件是否存在, 不存在则创建文件
            string file = $@"{Directory.GetCurrentDirectory()}\{name}";

            if (File.Exists(file) == false)
            {
                CreateFileWrite.CreateFile(file);
            }

            //读取安全日志
            EventLog log = new EventLog("Security");

            //读取4625日志
            IEnumerable<EventLogEntry> entries = log.Entries.Cast<EventLogEntry>().Where(x => x.InstanceId == 4625);
            foreach (EventLogEntry log1 in entries)
            {
                string text = log1.Message;
                string ipaddress = SelectContent.SelectEventLogContent(text, "源网络地址:	", "源端口:");
                string signInToProcess = SelectContent.SelectEventLogContent(text, "登录失败的帐户:", "失败信息:");
                string username = SelectContent.SelectEventLogContent(signInToProcess, "帐户名:		", "帐户域:");
                if (username == string.Empty)
                {
                    username = SelectContent.SelectEventLogContent(signInToProcess, "帐户名称:		", "帐户域:");
                }

                string accountDomain = SelectContent.SelectEventLogContent(signInToProcess, "帐户域:		", "\r");  //筛选出账户域

                DateTime time = log1.TimeGenerated;  //事件发生时间

                if (ipaddress.Length >= 7)
                {
                    CreateFileWrite.WriteFile(file, "\r\n-----------------------------------");

                    //写入事件发生时间
                    CreateFileWrite.WriteFile(file, "Time: " + time);
                    
                    //写入账户名
                    CreateFileWrite.WriteFile(file, "UserName: " + username.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", ""));

                    //写入账户域
                    CreateFileWrite.WriteFile(file, "AccountDomain: " + accountDomain.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", ""));

                    //写入ip
                    CreateFileWrite.WriteFile(file, "Remote ip: " + ipaddress.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", ""));
                }
            }
        }

        public static void Win2003EventLog(string name = "EventLogResults.txt")
        {
            //判断要写入的结果文件是否存在, 不存在则创建文件
            string file = $@"{Directory.GetCurrentDirectory()}\{name}";

            if (File.Exists(file) == false)
            {
                CreateFileWrite.CreateFile(file);
            }

            EventLog log = new EventLog("Security");  //读取 "安全日志"

            IEnumerable<EventLogEntry> entries = log.Entries.Cast<EventLogEntry>().Where(x => x.InstanceId == 528);  //读取528日志, windows2003 "528"日志代表用户成功登录到计算机
            foreach (EventLogEntry log1 in entries)
            {
                string text = log1.Message;
                string ipaddress = SelectContent.SelectEventLogContent(text, "源网络地址:	", "源端口:");  //筛选ip
                string username = SelectContent.SelectEventLogContent(text, "用户名: 	", "域:");  //筛选用户名
                string accountDomain = SelectContent.SelectEventLogContent(text, "调用方域:	", "调用方登录 ID:");  //筛选域

                DateTime time = log1.TimeGenerated;  //事件发生时间

                if (ipaddress.Length >= 7)  //判断ip长度大于等于7则写入ip
                {
                    CreateFileWrite.WriteFile(file, "\r\n-----------------------------------");

                    //写入事件发生时间
                    CreateFileWrite.WriteFile(file, @"Time: " + time);

                    //写入账户名
                    CreateFileWrite.WriteFile(file, "UserName: " + username.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", ""));

                    //写入域
                    CreateFileWrite.WriteFile(file, "AccountDomain: " + accountDomain.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", ""));

                    //写入ip
                    CreateFileWrite.WriteFile(file, "Remote ip: " + ipaddress.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", ""));
                }
            }
        }
    }
}