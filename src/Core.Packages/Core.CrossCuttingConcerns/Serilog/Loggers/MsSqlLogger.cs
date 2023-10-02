using Core.CrossCuttingConcerns.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Serilog.Loggers
{
    public class MsSqlLogger : LoggerServiceBase
    {
        private readonly IConfiguration _configuration;

        public MsSqlLogger(IConfiguration configuration)
        {
            _configuration = configuration;

            var logConfiguration = _configuration.GetSection("SerilogConfigurations:MsSqlConfiguration").Get<MsSqlConfiguration>()
                ?? throw new Exception(SerilogMessages.NullOptionsMessage);

            MSSqlServerSinkOptions sinkOptions = new()
            {
                TableName = logConfiguration.TableName,
                AutoCreateSqlTable = logConfiguration.AutoCreateSqlTable
            };

            ColumnOptions columnOptions = new();

            Logger = new LoggerConfiguration().WriteTo.MSSqlServer(
                    connectionString: logConfiguration.ConnectionString,
                    sinkOptions: sinkOptions,
                    columnOptions: columnOptions
                ).CreateLogger();
        }
    }
}
