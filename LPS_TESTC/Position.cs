using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPS_TESTC
{
    [Serializable()]
    class Position
    {
        public string version { get; set; }

        public Boolean alive { get; set; }

        public string tagId { get; set; }

        public Boolean success { get; set; }

        public string timestamp { get; set; }

        public data data { get; set; }


    }

    [Serializable()]

    class metrics
    {
        public string latency { get; set; }
        public rates rates { get; set; }
    }

    [Serializable()]
    class orientation
    {
        public string yaw { get; set; }
        public string roll { get; set; }
        public string pitch { get; set; }

    }

    [Serializable()]
    class coordinates
    {
        public string x { get; set; }
        public string y { get; set; }
        public string z { get; set; }

    }

    [Serializable()]
    class tagData
    {

    }

    [Serializable()]
    class rates
    {
        public string update { get; set; }

        public string success { get; set; }
    }
    [Serializable()]
    class data
    {

        public tagData tagData { get; set; }

        public string[] anchorData { get; set; }

        public coordinates coordinates { get; set; }

        public orientation orientation { get; set; }

        public metrics metrics { get; set; }


    }

}
