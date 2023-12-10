using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Serilog.Events;
using Serilog.Sinks.ApplicationInsights.TelemetryConverters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RFL.TechStack.Framework.Host.Extension
{
    public class CustomTelemetryTraceConverter : TraceTelemetryConverter
    {
        public override IEnumerable<ITelemetry> Convert(LogEvent logEvent, IFormatProvider formatProvider)
        {
            foreach (ITelemetry telemetry in base.Convert(logEvent, formatProvider))
            {
                if (logEvent.Properties.ContainsKey("RequestId"))
                {
                    telemetry.Context.Operation.Id = logEvent.Properties["RequestId"].ToString();
                }
                if (logEvent.Properties.ContainsKey("ParentRequestId"))
                {
                    telemetry.Context.Operation.ParentId = logEvent.Properties["ParentRequestId"].ToString();
                }
                ISupportProperties propTelematry = (ISupportProperties)telemetry;

                var removeProps = new[] { "MessageTemplate", "ErrorId", "ErrorMessage" };
                removeProps = removeProps.Where(prop => propTelematry.Properties.ContainsKey(prop)).ToArray();

                foreach (var prop in removeProps)
                {
                    propTelematry.Properties.Remove(prop);
                }

                yield return telemetry;
            }
        }
    }
    public class CustomTelemetryEventConverter : EventTelemetryConverter
    {
        public override IEnumerable<ITelemetry> Convert(LogEvent logEvent, IFormatProvider formatProvider)
        {
            foreach (ITelemetry telemetry in base.Convert(logEvent, formatProvider))
            {
                if (logEvent.Properties.ContainsKey("RequestId"))
                {
                    telemetry.Context.Operation.Id = logEvent.Properties["RequestId"].ToString();
                    telemetry.Context.Operation.ParentId = logEvent.Properties["RequestId"].ToString();
                }
                if (logEvent.Properties.ContainsKey("ParentRequestId"))
                {
                    telemetry.Context.Operation.ParentId = logEvent.Properties["ParentRequestId"].ToString();
                }
                if (logEvent.Properties.ContainsKey("Stage"))
                {
                    telemetry.Context.Operation.Name = logEvent.Properties["Stage"].ToString();
                }
                ISupportProperties propTelematry = (ISupportProperties)telemetry;

                var removeProps = new[] { "MessageTemplate", "ErrorId", "ErrorMessage" };
                removeProps = removeProps.Where(prop => propTelematry.Properties.ContainsKey(prop)).ToArray();

                foreach (var prop in removeProps)
                {
                    propTelematry.Properties.Remove(prop);
                }

                yield return telemetry;
            }
        }
    } 
}