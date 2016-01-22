Syslog Target for NLog
======================

**NLog Syslog** is a custom target for [NLog](http://nlog-project.org/) version 4.2.2 allowing you to send logging messages to a UNIX-style Syslog server.

## Configuration

To use NLog Syslog, you simply wire it up as an extension in the NLog.config file and place the NLog.Targets.Syslog.dll in the same location as the NLog.dll & NLog.config files. Then use as you would any NLog target. To use TCP as transport protocol just specify protocol="tcp" in target configuration. Below is a sample NLog.config file:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
      xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">

  <extensions>
    <add assembly="NLog.Targets.Syslog" />
  </extensions>

  <targets>
    <target name="syslog" type="Syslog" syslogserver="127.0.0.1" port="514" facility="Local7" sender="MyProgram" layout="[CustomPrefix] ${machinename} ${message}" />
  </targets>

  <rules>
    <logger name="*" minLevel="Trace" appendTo="syslog"/>
  </rules>
</nlog>
```
The package is also available through NuGet. Simply search for "NLog.Targets.Syslog".


### Options

This NLog target provides default values for all configuration options.
Optionally, your configuration can override them using attributes on
`target`, as shown in the example configuration above.

#### Destination

* `syslogserver`: IP or hostname (default: `127.0.0.1`)
* `port`: Port of syslog listener (default: `514`)
* `protocol`: `udp` or `tcp` (default: `udp`)
* `ssl`: `false` or `true`; TCP only (default: `false`)
* `rfc`: Rfc compatibility for syslog message `Rfc3164` or `Rfc5424` (default: `Rfc3164`)

#### Syslog packet elements

Messages are sent using the format (framing) called syslog, which is
defined in [RFC 3164](http://www.ietf.org/rfc/rfc3164.txt) or 
[RFC 5424](http://tools.ietf.org/html/rfc5424). In addition
to a timestamp and the log message, RFC 3164 syslog messages include
other elements: sending device name (such as the machine's hostname),
sending app/component name (called "tag" in the RFC), facility, and
severity.

The following syslog elements can be overridden for RFC 3164:

* `machinename` ([Layout](https://github.com/NLog/NLog/wiki/Layouts)): name of sending system or entity (default: machine 
  [hostname](http://msdn.microsoft.com/en-us/library/system.net.dns.gethostname(v=vs.110).aspx)).
For example, ${machinename}
* `sender` ([Layout](https://github.com/NLog/NLog/wiki/Layouts)): name of sending component or application (default: 
  [calling method](http://msdn.microsoft.com/en-us/library/system.reflection.assembly.getcallingassembly(v=vs.110).aspx)).
For example, ${logger}
* `facility`: facility name (default: `Local1`)

For example, to make logs from multiple systems use the same device
identifier (rather than each system's hostname), one could set
`machinename` to `app-cloud`. The logs from different systems would
all appear to be from the same single entity called `app-cloud`.

The following additional syslog elements can be overridden for [RFC 5424](http://tools.ietf.org/html/rfc5424):

* `procid` ([Layout](https://github.com/NLog/NLog/wiki/Layouts)): [identifier](http://tools.ietf.org/html/rfc5424#section-6.2.6) (numeric or alphanumeric) of sending entity 
(default: -). For example, ${processid} or ${processname}
* `msgid` ([Layout](https://github.com/NLog/NLog/wiki/Layouts)): [message type identifier](http://tools.ietf.org/html/rfc5424#section-6.2.7) (numeric or alphanumeric) of sending entity 
(default: -). For example, ${callsite}
* `structureddata` ([Layout](https://github.com/NLog/NLog/wiki/Layouts)): [additional data](http://tools.ietf.org/html/rfc5424#section-6.3) of sending entity (default: -).
For example, [thread@12345 id="${threadid}" name="${threadname}"][mydata2@12345 num="1" code="mycode"]

#### Log message body

This target supports the standard NLog 
[layout](https://github.com/NLog/NLog/wiki/Layouts) directive to modify
the log message body. The syslog packet elements are not affected.


## NLog

See more about NLog at: http://nlog-project.org
