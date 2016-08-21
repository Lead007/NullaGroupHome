using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NullaGroupHome.About
{
    public struct TimeLineEvent
    {
        public string Event { get; set; }
        public string Date { get; set; }
    }

    public struct TimeLine
    {
        public TimeLineEvent[] Events { get; set; }
    }
}