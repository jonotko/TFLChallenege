using System;
using System.Collections.Generic;

namespace TFLChallenge
{
    public class RoadStatusAPIResponse
    {
        public bool Success { get; set; }

        public List<RoadStatus> JsonResponse { get; set; }

        public RoadStatusAPIResponse(bool success, List<RoadStatus> jsonResponse)
        {
            this.Success = success;
            this.JsonResponse = jsonResponse;
        }
    }
}
