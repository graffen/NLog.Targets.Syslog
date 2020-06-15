// Licensed under the BSD license
// See the LICENSE file in the project root for more information

using NLog.Layouts;
using NLog.Targets.Syslog.Policies;
using System.Globalization;
using System.Text;
using NLog.Targets.Syslog.MessageStorage;
using NLog.Targets.Syslog.Settings;

namespace NLog.Targets.Syslog.MessageCreation
{
    internal class Rfc3164 : MessageBuilder
    {
        private const string TimestampFormat = "{0:MMM} {0,11:d HH:mm:ss}";
        private static readonly byte[] SpaceBytes = { 0x20 };

        private readonly bool outputPri;
        private readonly bool outputHeader;
        private readonly bool outputSpace;
        private readonly Layout hostnameLayout;
        private readonly Layout tagLayout;
        private readonly PlainHostnamePolicySet hostnamePolicySet;
        private readonly TagPolicySet tagPolicySet;
        private readonly ContentPolicySet contentPolicySet;
        private readonly AsciiMessagePolicy asciiMessagePolicy;

        public Rfc3164(Facility facility, LogLevelSeverityConfig logLevelSeverityConfig, Rfc3164Config rfc3164Config, EnforcementConfig enforcementConfig) : base(facility, logLevelSeverityConfig, enforcementConfig)
        {
            hostnamePolicySet = new PlainHostnamePolicySet(enforcementConfig);
            tagPolicySet = new TagPolicySet(enforcementConfig);
            contentPolicySet = new ContentPolicySet(enforcementConfig);
            asciiMessagePolicy = new AsciiMessagePolicy(enforcementConfig);

            outputPri = rfc3164Config.OutputPri;
            outputHeader = rfc3164Config.OutputHeader;
            outputSpace = rfc3164Config.OutputSpaceBeforeMsg;
            hostnameLayout = rfc3164Config.Hostname;
            tagLayout = rfc3164Config.Tag;
        }

        protected override void PrepareMessage(ByteArray buffer, LogEventInfo logEvent, string pri, string logEntry)
        {
            AppendPri(buffer, pri);
            AppendHeader(buffer, logEvent);
            AppendSpace(buffer);
            AppendMsg(buffer, logEvent, logEntry);

            asciiMessagePolicy.Apply(buffer);
        }

        private void AppendPri(ByteArray buffer, string pri)
        {
            if (!outputPri)
                return;
            buffer.AppendAscii(pri);
        }

        private void AppendHeader(ByteArray buffer, LogEventInfo logEvent)
        {
            if (!outputHeader)
                return;
            var timestamp = string.Format(CultureInfo.InvariantCulture, TimestampFormat, logEvent.TimeStamp);
            var host = hostnamePolicySet.Apply(hostnameLayout.Render(logEvent));
            buffer.AppendAscii(timestamp);
            buffer.AppendBytes(SpaceBytes);
            buffer.AppendAscii(host);
        }

        private void AppendSpace(ByteArray buffer)
        {
            if (!outputSpace)
                return;
            buffer.AppendBytes(SpaceBytes);
        }

        private void AppendMsg(ByteArray buffer, LogEventInfo logEvent, string logEntry)
        {
            var tag = tagPolicySet.Apply(tagLayout.Render(logEvent));
            var content = contentPolicySet.Apply(logEntry);
            buffer.AppendAscii(tag);
            buffer.AppendAscii(content);
        }
    }
}