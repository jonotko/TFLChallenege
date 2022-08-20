using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TFLChallenge
{
    public interface ITflApiClient
    {
        Task<RoadStatusAPIResponse> GetRoadStatusFor(string roadName);
    }
}
