using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TgBot
{
    public class RateLimiter
    {
        private readonly int tokensPerSecond;
        private DateTime lastRequestTime;
        private int tokensAvailable;

        public RateLimiter(int tokensPerSecond)
        {
            this.tokensPerSecond = tokensPerSecond;
            this.tokensAvailable = tokensPerSecond;
            this.lastRequestTime = DateTime.MinValue;
        }

        public bool TryAcquire()
        {
            lock (this)
            {
                // Calculate time elapsed since the last request
                var currentTime = DateTime.Now;
                var elapsedTime = currentTime - lastRequestTime;

                // Refill tokens based on elapsed time
                tokensAvailable += (int)(elapsedTime.TotalSeconds * tokensPerSecond);

                // Cap the tokens available at the maximum rate
                tokensAvailable = Math.Min(tokensAvailable, tokensPerSecond);

                // Check if there are enough tokens for the request
                if (tokensAvailable >= 1)
                {
                    tokensAvailable--;
                    lastRequestTime = currentTime;
                    return true; // Request allowed
                }
                else
                {
                    return false; // Request denied due to rate limiting
                }
            }
        }
    }

}
