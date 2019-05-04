using System;
using System.Collections.Generic;
using System.Text;

namespace s3dynamo
{
    public class Rootobject
    {
        public Values[] value { get; set; }
    }

    public class Values
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }


}

