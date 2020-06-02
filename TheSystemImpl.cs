using System;
using Fivet.ZeroIce.model;
using Ice;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Fivet.ZeroIce
{
    public class TheSystemImpl : TheSystemDisp_
    {

        private readonly ILogger<TheSystemImpl> _logger;


        public TheSystemImpl(ILogger<TheSystemImpl> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _logger.LogDebug("Building TheSystemImpl ... ");
        }

        public override long getDelay(long clientTime, Current current = null)
        {

            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - clientTime;
        }
        
    }
}