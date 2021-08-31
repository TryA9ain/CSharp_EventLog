
namespace CSharp_EventLog
{
    class SelectContent
    {
        //查找符合条件的事件日志内容
        public static string SelectEventLogContent(string sourse, string startString, string endString)
        {
            string result = string.Empty;
            int startindex, endindex;
            startindex = sourse.IndexOf(startString);
            if (startindex == -1)
            {
                return result;
            }

            string tmpstr = sourse.Substring(startindex + startString.Length);
            endindex = tmpstr.IndexOf(endString);
            if (endindex == -1)
            {
                return result;
            }

            result = tmpstr.Remove(endindex);
            return result;
        }

    }
}
