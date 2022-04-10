using Suretom.Client.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suretom.Client.DataPlatformServices
{
    public class TestService : ServiceBase, ITestService
    {
        public TestService()
        {
            Urls.Add("Test", "TranscribeItemService/Test");
        }

        public string Test(int id, string name)
        {
            var param = new
            {
                Id = id,
                Name = name
            };

            var httpJsonParam = Newtonsoft.Json.JsonConvert.SerializeObject(param);

            var result = Post(httpJsonParam, Urls["Test"], this.GetType());
            if (result.Success)
            {
                return result.Data.ToString();
            }
            else
            {
                throw new Exception($"Test，{result.Message}");
            }
        }
    }
}