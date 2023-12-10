using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Serilog.Events;
using Serilog.Sinks.ApplicationInsights.TelemetryConverters;

namespace NEC.Fulfillment.Framework.Host.Extension
{
    public class CustomApplicationInsightsTelemetryConverter : TraceTelemetryConverter
    {
        public override IEnumerable<ITelemetry> Convert(LogEvent logEvent, IFormatProvider formatProvider)
        {
            foreach (ITelemetry telemetry in base.Convert(logEvent, formatProvider))
            {
                if (logEvent.Properties.ContainsKey("ErrorId"))
                {
                    telemetry.Context.Operation.Id = logEvent.Properties["ErrorId"].ToString();
                }
                telemetry.Context.Operation.Id = "viju";
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
