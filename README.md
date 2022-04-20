# HyReptile
  - # 介绍 ![c#](https://img.shields.io/badge/c%23-8.0-red) ![netstandard2.1](https://img.shields.io/badge/netstandard-2.1-blue)
  - # HyReptile 是使用c# 编写的一个轻量爬虫库， 可使用少量代码实现爬虫功能
  - 本项目分为两个模块
  - RepitleCore  (爬虫核心爬虫负责模拟发送请求)
  - RepitlePaser (负责对响应的html进行解析)
 - # 快速上手
  ```bash
   Install-Package RepitleCore -Version 1.0.0
  ```
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
   var response= await repitle.StartReptile();
  ```
  
  - 下载流媒体对象
  ``` c# 
    await HyRepitle.DownFile("path/a.jpeg",response.GetContent());
  ```
 - # 获取html
 ``` c#
    //对结果进行编码
    response.GetText(CodingEnum.GB2312);
 ```
- # 使用常用工具类
- # 获取一个user-agent
```c#
  RepitleUntity.GetUserAgent(UserAgentEnum.Android);
```
- # 获取当前时间戳
```c#
    RepitleUntity.GetTimeStamp();
```
- # Example
- # 样例1
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
  - # 
  - # 流媒体下载
  ``` c#
           HyRepitle repitle=new HyRepitle();
            
            repitle.Request("GET","http://www.240ps.com/images/ad/bot_9_1.jpg");
     

            repitle.User_Agent("Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.85 Safari/537.36");
            
            repitle.Headers("Host","www.240ps.com");
            
            repitle.AddCookie("ASPSESSIONIDQCBQQTRR=DOPFLANBANACGKKLJHNPLCNM; Hm_lvt_a51d8817652d1bb0611c5f7cfbb13209=1648813376,1648880465,1650114164,1650185402; Hm_lpvt_a51d8817652d1bb0611c5f7cfbb13209=1650185694");
            
            IRepitResponse response= await repitle.StartReptile();
        
            
            await HyRepitle.DownFile("../a.jpg",response.GetContent());
  ```
