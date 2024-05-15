# Intervall-Ping
Ping computers with defined intervall. THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND...
![Intervall-Ping console output](ping.png)

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
You can also download x64 Windows binary [Intervall-Ping.exe](Intervall-Ping.exe)
 with SHA256: A54AFD236B7AA89366625476CCCEC7E76F34799A833AB39E83E6D56BC13CF5A1
