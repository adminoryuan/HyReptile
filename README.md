# HyReptile(项目正在开发中)
  - # 介绍 []('https://img.shields.io/badge/%E7%88%AC%E8%99%AB-c%23-red')
  - # HyReptile 是使用c# 编写的一个轻量爬虫库， 可使用少量代码实现爬虫功能
  - 本项目分为两个模块
  - RepitleCore  (爬虫核心爬虫负责模拟发送请求)
  - RepitlePaser (负责对响应的html进行解析)
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
 - # 快速上手
  - nuget 安装 HyReplite
  - # 使用
  - 创建对象
  - 
   ```c# 
  HyRepitle repitle = new HyRepitle();
  ```
  - 添加请求头
  ```c#
    repitle.Headers(key,val)
  ```
  - 获得响应
  ```c#
    await repitle.StartReptile();
  ```
  
  - 下载流媒体对象
  ``` c# 
    await HyRepitle.DownFile("path/a.jpeg",response.GetContent());
  ```
