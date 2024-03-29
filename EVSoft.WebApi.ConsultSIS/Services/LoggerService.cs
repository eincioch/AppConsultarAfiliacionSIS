﻿using EVSoft.WebApi.ConsultSIS.Contracts;
using NLog;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVSoft.WebApi.ConsultSIS.Services
{
    public class LoggerService : ILoggerService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}
