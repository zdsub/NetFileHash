using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
        /// MD5校验对象
        /// </summary>
        private readonly MD5CryptoServiceProvider _md5 = new MD5CryptoServiceProvider();

        /// <summary>
        /// SHA1校验对象
        /// </summary>
        private readonly SHA1CryptoServiceProvider _sha1 = new SHA1CryptoServiceProvider();

        /// <summary>
        /// SHA256校验对象
        /// </summary>
        private readonly SHA256CryptoServiceProvider _sha256 = new SHA256CryptoServiceProvider();

        /// <summary>
        /// SHA384校验对象
        /// </summary>
        private readonly SHA384CryptoServiceProvider _sha384 = new SHA384CryptoServiceProvider();

        /// <summary>
        /// SHA512校验对象
        /// </summary>
        private readonly SHA512CryptoServiceProvider _sha512 = new SHA512CryptoServiceProvider();

        /// <summary>
        /// 是否停止计算
        /// </summary>
        public bool IsStop { get; set; } 

        /// <summary>
        /// 待计算文件路径集合
        /// </summary>
        public List<string> FileList = new List<string>();

        /// <summary>
        /// 校验结果
        /// </summary>
        public string Result { get; private set; }

        /// <summary>
        /// 总校验进度
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// 当前校验进度
        /// </summary>
        public int Progress { get; set; }

        /// <summary>
        /// 批量校验文件
        /// </summary>
        /// <param name="fileList">文件路径集合</param>
        public void Hash()
        {
            Index = 0;

            foreach (string file in FileList)
            {
                Hash(file);
            }
        }

        /// <summary>
        /// 校验文件
        /// </summary>
        /// <param name="file">文件路径</param>
        private void Hash(string file)
        {
            FileInfo fileInfo = new FileInfo(file);

             if (!fileInfo.Attributes.HasFlag(FileAttributes.Archive))
            {
                AddErrorResult(file, "不是文件");
                return;
            }
            else if(!fileInfo.Exists)
            {
                AddErrorResult(file, "文件不存在");
                return;
            }

            FileStream fileStream = File.OpenRead(file);

            long current = 0;
            long size = fileInfo.Length;
            byte[] buffer = new byte[4096];

            while (current != size && !IsStop)
            {
                int len = fileStream.Read(buffer, 0, buffer.Length);
                current += len;
                Progress = (int) ((double) current / size * 100);
                
                if (current != size)
                {
                    _md5.TransformBlock(buffer, 0, len, null, 0);
                    _sha1.TransformBlock(buffer, 0, len, null, 0);
                    _sha256.TransformBlock(buffer, 0, len, null, 0);
                    _sha384.TransformBlock(buffer, 0, len, null, 0);
                    _sha512.TransformBlock(buffer, 0, len, null, 0);
                }
                else
                {
                    _md5.TransformFinalBlock(buffer, 0, len);
                    _sha1.TransformFinalBlock(buffer, 0, len);
                    _sha256.TransformFinalBlock(buffer, 0, len);
                    _sha384.TransformFinalBlock(buffer, 0, len);
                    _sha512.TransformFinalBlock(buffer, 0, len);
                }
            }

            fileStream.Close();

            if (current == size)
            {
                string md5 = BitConverter.ToString(_md5.Hash).Replace("-", "");
                string sha1 = BitConverter.ToString(_sha1.Hash).Replace("-", "");
                string sha256 = BitConverter.ToString(_sha256.Hash).Replace("-", "");
                string sha384 = BitConverter.ToString(_sha384.Hash).Replace("-", "");
                string sha512 = BitConverter.ToString(_sha512.Hash).Replace("-", "");

                Index++;
                Result += $"文件: {fileInfo.FullName}\r\n" +
                          $"大小: {size}字节\r\n" +
                          $"MD5: {md5}\r\n" +
                          $"SHA1: {sha1}\r\n" +
                          $"SHA256: {sha256}\r\n" +
                          $"SHA384: {sha384}\r\n" +
                          $"SHA512: {sha512}\r\n\r\n";

                _md5.Initialize();
                _sha1.Initialize();
                _sha256.Initialize();
                _sha384.Initialize();
                _sha512.Initialize();
            }
        }

        /// <summary>
        /// 添加错误信息
        /// </summary>
        /// <param name="file">文件路径</param>
        /// <param name="error">错误信息</param>
        private void AddErrorResult(string file, string error)
        {
            Result += $"文件: {file}\r\n" +
                      $"{error}\r\n\r\n";
            Progress = 100;
            Index++;
        }
    }
}
