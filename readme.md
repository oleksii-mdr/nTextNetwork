nTextNetwork
============

The aim of this project is to provide an open source text analysis library for .NET platform.

The main interface to use is [ITextStatistic](https://github.com/oleksii-mdr/nTextNetwork/blob/master/src/app/nTextNetwork.Core/Interfaces/ITextStatistic.cs).

Sample code:
```CSharp
using(Stream stream = File.OpenRead("C:\somefile.txt"))
{
    ITextStatisticBuilder builder = new TextStatisticsBuilder();
    ITextStatistic stats = builder.Build(stream);
}
```

See it working
-------------
Application is deployed to [nTextNetwork](http://ntextnetwork.apphb.com/).
Testing code is located at [staging](http://ntextnetwork.apphb.com/staging).

Developer corner
-------------
*   [CI engine](https://appharbor.com/applications/ntextnetwork)