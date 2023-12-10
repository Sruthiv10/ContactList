using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFL.TechStack.Infrastructure.ServiceBus
{
    public class CustomRetryPolicy : ServiceBusRetryPolicy
    {
        private readonly int _retryCount;
        private readonly int _retryDelay;

        public CustomRetryPolicy(int retryCount, int retryDelay)
        {
            _retryCount = retryCount;
            _retryDelay = retryDelay;
        }

        public override TimeSpan? CalculateRetryDelay(Exception lastException, int attemptCount)
        {
            return TimeSpan.FromSeconds(_retryDelay);
        }

        public override TimeSpan CalculateTryTimeout(int attemptCount)
        {
            return TimeSpan.FromSeconds(_retryCount);
        }
    }
}
