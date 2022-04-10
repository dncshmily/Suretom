using System;
using System.Collections.Generic;
using System.Text;

namespace Suretom.Client.DataToolsModel
{
    public class PathQueryDto
    {
        public string Path { get; set; }
        public string LocalPath { get; set; }
        public string AbsolutePath { get; set; }
        public string QueryString { get; set; }
        public string XOssProcess { get; set; }
    }
}