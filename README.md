# HyReptile
  - # 介绍 
  - HyReptile 是使用c# 编写的一个轻量爬虫库， 可使用少量代码实现爬虫功能
  - # 样例使用
  ``` c#
          HyRepitle repitle = new HyRepitle();

           repitle.Request("GET", "http://www.spvec.com.cn");

           repitle.Accpect("text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-    exchange;v=b3;q=0.9");

           repitle.AddCookie("JSESSIONID=A8EBF79CFFBE80C24EF6C91C7D3D46E8");

           repitle.User_Agent("Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.75 Safari/537.36");

           repitle.Headers("Accept-Language", "zh-CN,zh;q=0.9,en;q=0.8");
            
           repitle.Host("www.spvec.com.cn");

           repitle.Headers("Connection", "keep-alive");

          // repitle.Headers("Accept-Encoding", "gzip,deflate");

           IRepitResponse response= await repitle.StartReptile();

             
           Console.WriteLine(response.GetText(CodingEnum.Utf8)); //获取响应内容
  ```
