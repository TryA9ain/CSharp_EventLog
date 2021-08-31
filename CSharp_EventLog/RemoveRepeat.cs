using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CSharp_EventLog
{
    class RemoveRepeat
    {
        //对ip进行去重以及统计重复ip的次数
        public static void RemoveRepeatIp(string fileName = "EventLogResults.txt", string removeRepeatIpFileName = "ips.txt", string numberOfOccurrencesFile = "NumberOfOccurrences.txt")
        {
            //判断写入的文件是否存在, 不存在则创建文件
            string file = $@"{Directory.GetCurrentDirectory()}\{removeRepeatIpFileName}";
            
            if (File.Exists(file) == false)
            {
                CreateFileWrite.CreateFile(file);
            }

            //判断统计重复次数的文件是否存在, 不存在则创建文件
            string occurrencesFile = $@"{Directory.GetCurrentDirectory()}\{numberOfOccurrencesFile}";
            
            if (File.Exists(occurrencesFile) == false)
            {
                CreateFileWrite.CreateFile(occurrencesFile);
            }

            string text = File.ReadAllText(fileName);  //读取4624或4625日志输出的文件

            //统计重复出现ip的次数
            IEnumerable<string> numberOfOccurrencesList = Regex.Matches(text, @"Remote ip:.*").OfType<Match>().Select(x => x.Value.Replace("Remote ip: ", "").Replace("\r", ""));
            var numberOfOccurrencesDict = numberOfOccurrencesList.GroupBy(x => x).Select(x => new { ip = x.Key, NumberOfOccurrences = x.Count() });
            foreach (var numberOfOccurrencesIp in numberOfOccurrencesDict)
            {
                CreateFileWrite.WriteFile(occurrencesFile, numberOfOccurrencesIp.ToString().Replace("{ ", "").Replace(" }", "").Replace(",", "    "));
            }

            //对ip进行去重
            //IEnumerable<string> removeRepeatIpList = Regex.Matches(text, @"(((25[0-5]|2[0-4]\d|[01]?\d?\d)\.){3}(25[0-5]|2[0-4]\d|[01]?\d?\d))").OfType<Match>().Select(x => x.Value).Distinct();
            IEnumerable<string> removeRepeatIpList = numberOfOccurrencesList.Distinct();

            //写入去重后的ip
            foreach (string ip in removeRepeatIpList)
            {
                CreateFileWrite.WriteFile(file, ip);
            }
        }

        //对用户名进行去重以及统计重复用户名的次数
        public static void RemoveRepeatUserName(string fileName = "EventLogResults.txt", string removeRepeatUserFileName = "UserNames.txt", string numberOfOccurrencesFile = "NumberOfOccurrences.txt")
        {
            //判断写入的文件是否存在, 不存在则创建文件
            string file = $@"{Directory.GetCurrentDirectory()}\{removeRepeatUserFileName}";
            
            if (File.Exists(file) == false)
            {
                CreateFileWrite.CreateFile(removeRepeatUserFileName);
            }

            //判断要写入的统计重复的文件是否存在, 不存在则创建文件
            string occurrencesFile = $@"{Directory.GetCurrentDirectory()}\{numberOfOccurrencesFile}";

            if (File.Exists(file) == false)
            {
                CreateFileWrite.CreateFile(occurrencesFile);
            }

            //读取4624或4625日志输出的文件
            string text = File.ReadAllText(fileName);  

            //统计重复出现用户名的次数
            IEnumerable<string> numberOfOccurrencesList = Regex.Matches(text, @"UserName:.*").OfType<Match>().Select(x => x.Value.Replace("UserName: ", "").Replace("\r", ""));
            var numberOfOccurrencesDict = numberOfOccurrencesList.GroupBy(x => x).Select(x => new { UserName = x.Key, NumberOfOccurrences = x.Count() });
            foreach (var numberOfOccurrencesUsername in numberOfOccurrencesDict)
            {
                CreateFileWrite.WriteFile(occurrencesFile, numberOfOccurrencesUsername.ToString().Replace("{ ", "").Replace(" }", "").Replace(",", "    "));
            }

            //对用户名进行去重
            //IEnumerable<string> removeRepeatUserNameList = Regex.Matches(text, @"UserName:.*").OfType<Match>().Select(x => x.Value.Replace("UserName: ", "").Replace("\r", "")).Distinct();
            IEnumerable<string> removeRepeatUserNameList = numberOfOccurrencesList.Distinct();
            
            //写入去重后的用户名
            foreach (string userName in removeRepeatUserNameList)
            {
                CreateFileWrite.WriteFile(removeRepeatUserFileName, userName);
            }
        }

        //对域进行去重以及统计重复域的次数
        public static void RemoveRepeatAccountDomain(string fileName = "EventLogResults.txt", string removeRepeatAccountDomainFileName = "AccountDomains.txt", string numberOfOccurrencesFile = "NumberOfOccurrences.txt")
        {
            //判断写入的文件是否存在, 不存在则创建文件
            string file = $@"{Directory.GetCurrentDirectory()}\{removeRepeatAccountDomainFileName}";

            if (File.Exists(file) == false)
            {
                CreateFileWrite.CreateFile(removeRepeatAccountDomainFileName);
            }
            
            //判断要写入的统计重复的文件是否存在, 不存在则创建文件
            string occurrencesFile = $@"{Directory.GetCurrentDirectory()}\{numberOfOccurrencesFile}";

            if (File.Exists(file) == false)
            {
                CreateFileWrite.CreateFile(occurrencesFile);
            }

            //读取4624或4625日志输出的文件
            string text = File.ReadAllText(fileName);

            //统计重复出现的域次数
            IEnumerable<string> numberOfOccurrencesList = Regex.Matches(text, @"AccountDomain:.*").OfType<Match>().Select(x => x.Value.Replace("AccountDomain: ", "").Replace("\r", ""));
            var numberOfOccurrencesDict = numberOfOccurrencesList.GroupBy(x => x).Select(x => new { AccountDomain = x.Key, NumberOfOccurrences = x.Count() });
            foreach (var numberOfOccurrencesUsername in numberOfOccurrencesDict)
            {
                CreateFileWrite.WriteFile(occurrencesFile, numberOfOccurrencesUsername.ToString().Replace("{ ", "").Replace(" }", "").Replace(",", "    "));
            }

            //对域进行去重
            //IEnumerable<string> removeRepeatUserNameList = Regex.Matches(text, @"UserName:.*").OfType<Match>().Select(x => x.Value.Replace("UserName: ", "").Replace("\r", "")).Distinct();
            IEnumerable<string> removeRepeatUserNameList = numberOfOccurrencesList.Distinct();
            
            //写入去重后的域
            foreach (string userName in removeRepeatUserNameList)
            {
                CreateFileWrite.WriteFile(removeRepeatAccountDomainFileName, userName);
            }
        }
    }
}
