using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace RepitleCore
{
    /// <summary>
    /// ji
    /// </summary>
    public class HttpUntity
    {

        
        /// <summary>
        /// gzip 编码解压缩
        /// </summary>
        /// <param name="bodys"></param>
        /// <returns></returns>
       public static byte[] UnGzip(byte[] data)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    using (GZipStream gZipStream = new GZipStream(new MemoryStream(data), CompressionMode.Decompress))
                    {
                        byte[] bytes = new byte[40960];
                        int n;
                        while ((n = gZipStream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            stream.Write(bytes, 0, n);
                        }
                        gZipStream.Close();
                    }
 
                    return stream.ToArray();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
        
                Console.WriteLine("Unzip Catch");
                return null;
            }
          
        }
        public HttpUntity()
        {
        }
    }
}
