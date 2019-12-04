using System;
using Microsoft.Extensions.DependencyInjection;
using MtvCoUkParser.Services;
using MtvCoUkParser.Services.Implements;

namespace MtvCoUkParser
{
    static class Injection
    {
        public static IServiceProvider Provider { get; private set; }

        public static void Startup()
            => Provider = new ServiceCollection()
                .AddTransient<ICrudeData, CrudeData>()
                .AddTransient<INameCreatortor, NameCreator>()
                .AddTransient<ITrackCreator, TrackCreator>()
                .AddTransient<IChartCreator, ChartCreator>()
                .BuildServiceProvider();
    }
}
