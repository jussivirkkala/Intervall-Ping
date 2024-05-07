# pingr
Ping computers with defined interval. THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND...
![Ping console output](pingr.png)

Build .NET8.0.4 SDK (www.dot.net) into single win-x64 exe with following command.
```
dotnet publish  -p:IncludeAllContentForSelfExtract=true
``` 

Project file has 
``` 
<PublishTrimmed>true</PublishTrimmed>
<PublishSingleFile>true</PublishSingleFile>
<SelfContained>true</SelfContained>
<RuntimeIdentifier>win-x64</RuntimeIdentifier>		
``` 
You can also download x64 Windows binary [pingr.exe](pingr.exe)
 with SHA256: CA6A647C2BD12A687F6F272D0EACAE6ECD9E1BFAB090DC22ACBAAD8308F33F43
