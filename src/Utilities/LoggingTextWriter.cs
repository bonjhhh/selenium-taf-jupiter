using Serilog;
using System;
using System.IO;
using System.Text;

namespace SeleniumTestFramework.src.Utilities
{
    public class LoggingTextWriter : TextWriter
    {
        private readonly ILogger _logger;

        public LoggingTextWriter(ILogger logger)
        {
            _logger = logger;
        }

        public override Encoding Encoding => Encoding.UTF8;

        public override void WriteLine(string value)
        {
            _logger.Information(value);
        }

        public override void WriteLine(string format, params object[] arg)
        {
            _logger.Information(format, arg);
        }
    }
}