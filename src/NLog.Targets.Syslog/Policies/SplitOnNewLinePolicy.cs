// Licensed under the BSD license
// See the LICENSE file in the project root for more information

using NLog.Common;
using System;
using NLog.Targets.Syslog.Settings;

namespace NLog.Targets.Syslog.Policies
{
    internal class SplitOnNewLinePolicy : IBasicPolicy<string, string[]>
    {
        private readonly EnforcementConfig enforcementConfig;
        private static readonly char[] LineSeps = { '\r', '\n' };

        public SplitOnNewLinePolicy(EnforcementConfig enforcementConfig)
        {
            this.enforcementConfig = enforcementConfig;
        }

        public bool IsApplicable()
        {
            return enforcementConfig.SplitOnNewLine;
        }

        public bool CausesSplitOf(string s)
        {
            return s.IndexOfAny(LineSeps) >= 0;
        }

        public string[] Apply(string s)
        {
            var split = s.Split(LineSeps, StringSplitOptions.RemoveEmptyEntries);
            InternalLogger.Trace("[Syslog] Split '{0}' on new line", s);
            return split;
        }
    }
}