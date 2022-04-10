using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suretom.Client.DataPlatformServices
{
    public interface ITestService
    {
        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        string Test(int id, string name);
    }
}