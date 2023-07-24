using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHash
{
    /// <summary>
    /// 文件校验类
    /// </summary>
    internal class FileHash
    {
        /// <summary>
        /// 校验文件
        /// </summary>
        /// <param name="path">文件路径</param>
        public void Hash(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            long size = fileInfo.Length;
            Debug.WriteLine($"size: {size}");

            FileStream fileStream = File.OpenRead(path);
            Debug.WriteLine("file open");

            long current = 0;
            byte[] buffer = new byte[4096];

            while (true)
            {
                int len = fileStream.Read(buffer, 0, buffer.Length);
                current += len;
                Debug.WriteLine($"current: {current} len: {len}");
                if (current == size)
                {
                    break;
                }
            }

            fileStream.Close();
            Debug.WriteLine("file close");
        }

    }
}
