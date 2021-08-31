using System;

namespace CSharp_EventLog
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0 || args[0] == "-h")
            {
                Console.WriteLine(@"Usage of CSharpEventLog.exe:
    -4624:  Get Event Log For 4624
    -4625:  Get Event Log For 4625
    -uniq:  Remove Repeats results And Count the number of repetitions

Example:  CSharpEventLog.exe -4624/-4625
          CSharpEventLog.exe -4624/-4625 -uniq

");
            }

            //调用4624, 默认只输出 "eventLogResults.txt", 不进行去重以及统计重复次数
            else if (args.Length == 1 && (args[0] == "-4624"))
            {
                EventLog_4624_4625.EventLog_4624();

            }
            //调用4625, 默认只输出 "eventLogResults.txt", 不进行去重以及统计重复次数
            else if (args.Length == 1 && (args[0] == "-4625"))
            {
                EventLog_4624_4625.EventLog_4625();
            }

            //调用4624, -o 允许指定输出全部结果的文件名
            //else if (args.Length == 3 && (args[0] == "-4624") && (args[1] == "-o"))
            //{
            //    EventLog_4624_4625.EventLog_4624(args[2]);
            //}
            //调用4625, -o 允许指定输出全部结果的文件名
            //else if (args.Length == 3 && (args[0] == "-4625") && (args[1] == "-o"))
            //{
            //    EventLog_4624_4625.EventLog_4625(args[2]);
            //}

            //调用4624, -uniq 进行去重, 默认输出 "eventLogResults.txt", "ips.txt", "names.txt", "numberOfOccurrences.txt" 四个文件
            else if (args.Length == 2 && (args[0] == "-4624") && (args[1] == "-uniq"))
            {
                EventLog_4624_4625.EventLog_4624();
                RemoveRepeat.RemoveRepeatIp();
                CreateFileWrite.WriteFile("numberOfOccurrences.txt", "\r\n=================================================================\r\n");
                RemoveRepeat.RemoveRepeatUserName();
                CreateFileWrite.WriteFile("numberOfOccurrences.txt", "\r\n=================================================================\r\n");
                RemoveRepeat.RemoveRepeatAccountDomain();
            }
            //调用4625, -uniq 进行去重, 默认输出 "eventLogResults.txt", "ips.txt", "names.txt", "numberOfOccurrences.txt" 四个文件
            else if (args.Length == 2 && (args[0] == "-4625") && (args[1] == "-uniq"))
            {
                EventLog_4624_4625.EventLog_4625();
                RemoveRepeat.RemoveRepeatIp();
                CreateFileWrite.WriteFile("numberOfOccurrences.txt", "\r\n=================================================================\r\n");
                RemoveRepeat.RemoveRepeatUserName();
                CreateFileWrite.WriteFile("numberOfOccurrences.txt", "\r\n=================================================================\r\n");
                RemoveRepeat.RemoveRepeatAccountDomain();
            }

            //调用4624, -uniq 进行去重, -o 允许指定输出全部结果的文件名, 输出 "自定义的文件名", "ips.txt", "names.txt", "numberOfOccurrences.txt" 四个文件
            //else if (args.Length == 4 && (args[0] == "-4624") && (args[1] == "-o") && (args[3] == "-uniq"))
            //{
            //    EventLog_4624_4625.EventLog_4624(args[2]);
            //    RemoveRepeat.RemoveRepeatIP(fileName : args[2]);
            //    CreateFileWrite.WriteFile("numberOfOccurrences.txt", "\r\n======================================================\r\n");
            //    RemoveRepeat.RemoveRepeatUserName(fileName : args[2]);

            //}
            //调用4625, -uniq 进行去重, -o 允许指定输出全部结果的文件名, 输出 "自定义的文件名", "ips.txt", "names.txt", "numberOfOccurrences.txt" 四个文件
            //else if (args.Length == 4 && (args[0] == "-4625") && (args[1] == "-o") && (args[3] == "-uniq"))
            //{
            //    EventLog_4624_4625.EventLog_4625(args[2]);
            //    RemoveRepeat.RemoveRepeatIP(fileName : args[2]);
            //    CreateFileWrite.WriteFile("numberOfOccurrences.txt", "\r\n======================================================\r\n");
            //    RemoveRepeat.RemoveRepeatUserName(fileName: args[2]);

            //}

        }

    }
}