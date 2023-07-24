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
                    break;
                }
            }

            fileStream.Close();
            Debug.WriteLine("file close");

            string md5 = BitConverter.ToString(_md5.Hash).Replace("-", "");
            string sha1 = BitConverter.ToString(_sha1.Hash).Replace("-", "");
            string sha256 = BitConverter.ToString(_sha256.Hash).Replace("-", "");
            string sha384 = BitConverter.ToString(_sha384.Hash).Replace("-", "");
            string sha512 = BitConverter.ToString(_sha512.Hash).Replace("-", "");
            _md5.Initialize();
            _sha1.Initialize();
            _sha256.Initialize();
            _sha384.Initialize();
            _sha512.Initialize();
            Debug.WriteLine($"md5: {md5}");
            Debug.WriteLine($"sha1: {sha1}");
            Debug.WriteLine($"sha256: {sha256}");
            Debug.WriteLine($"sha384: {sha384}");
            Debug.WriteLine($"sha512: {sha512}");
        }

    }
}
