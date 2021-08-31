# CSharp_EventLog
适用于：快速获取拿到权限的机器4624和4625事件日志信息，快速判断出有哪些域，哪个机器可能是运维人员的机器，有哪些ip段登录过该机器，运维人员使用的用户名等，有利于后期渗透重点关注
### 已上传打包好的文件，自行选择
2008可选择3.5版本，2012可选择4.0版本
## 使用方法：
```
-h  显示帮助信息
-4624 读取4624事件日志 默认输出 EventLogResults.txt 文件
-4625 读取4625事件日志 默认输出 EventLogResults.txt文件
-uniq  对结果进行去重 默认输出 ips.txt（去重后的ip）, AccountDomains.txt（去重后的域）, UserNames.txt（去重后的用户名）, NumberOfOccurrences.txt（统计所有重复出现的内容次数）
```
```
SharpEventLog.exe -4624/-4625
SharpEventLog.exe -4624/-4625 -uniq
```
目前不支持自定义输出文件名（因为觉得不是很实用，就没加这个功能）
![image](https://github.com/TryA9ain/CSharp_EventLog/blob/master/picture/Xnip2021-08-31_22-15-43.jpg)

## 产生的文件：
### EventLogResults.txt 文件内容为事件日志的全部内容（未进行去重）
![image](https://github.com/TryA9ain/CSharp_EventLog/blob/master/picture/2.jpg)
### ips.txt 文件内容为去重后的ip
![image](https://github.com/TryA9ain/CSharp_EventLog/blob/master/picture/7.jpg)
### AccountDomains.txt  内容为去重后的域：
![image](https://github.com/TryA9ain/CSharp_EventLog/blob/master/picture/3.jpg)
### UserNames.txt 内容为去重后的用户名
![image](https://github.com/TryA9ain/CSharp_EventLog/blob/master/picture/4.jpg)
### NumberOfOccurrences.txt 内容为统计重复出现次数
![image](https://github.com/TryA9ain/CSharp_EventLog/blob/master/picture/5.jpg)
## 可内存加载使用，根据情况来选择
```
execute-assembly C:\Users\Administrator\Desktop\CSharp_EventLog.exe -4624/-4625
execute-assembly C:\Users\Administrator\Desktop\CSharp_EventLog.exe -4624/-4625 -uniq
```
## 参考链接
https://github.com/uknowsec/SharpEventLog
