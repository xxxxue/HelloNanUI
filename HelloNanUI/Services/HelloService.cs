using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NetDimension.NanUI.DataServiceResource;
using NetDimension.NanUI.ResourceHandler;

namespace HelloNanUI.Services
{

    [DataRoute("/hello")]
    public class HelloService : DataService
    {
        // 获取当前时间戳
        private string GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }


        public class UserInfo
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Version { get; set; }
            public string Url { get; set; }
        }


        //public ResourceResponse SayHi(ResourceRequest request)
        //{
        //    // 反序列化 JSON 数据
        //    var result = request.DeserializeObjectFromJson<UserInfo>();

        //    return Json(new { success = true, timestamp = GetTimeStamp(), result });
        //}
       [RouteGet("getFrameWorks")]
        public ResourceResponse GetFrameWorks(ResourceRequest request)
        {

            var list = new List<UserInfo>()
            {
                new UserInfo()
                {
                    Id = 1,
                    Name = "React",
                    Version ="v1",
                    Url ="http://www.baidu1.com"
                },
                new UserInfo()
                {
                    Id = 2,
                    Name = "Vue",
                    Version ="v21",
                    Url ="http://www.baidu2.com"
                },
                new UserInfo()
                {
                    Id = 3,
                    Name = "Angular",
                    Version ="v31",
                    Url ="http://www.baidu3.com"
                },
            };

            // 返回json
            return Json(new
            {
                Succeeded = true,
                Data = new
                {
                    Items = list,
                    TotalCount = 100,
                }
            });
        }


    }
}
