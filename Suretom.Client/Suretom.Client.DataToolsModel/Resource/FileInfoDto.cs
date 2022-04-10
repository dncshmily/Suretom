using System;
using System.Collections.Generic;
using System.Text;

namespace Suretom.Client.DataToolsModel
{
    /// <summary>
    ///
    /// </summary>
    public class FileInfoDto
    {
        public bool Success { get; set; } = true;
        public string Data { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;
    }
}