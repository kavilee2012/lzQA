using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;
using System.IO;
using System.Security.Cryptography;

namespace Utility
{
    public class EncryptService
    {
        #region 生成不可逆的32位MD5哈希密码
        /// <summary>
        /// 生成不可逆的32位MD5哈希密码
        /// </summary>
        /// <param name="strSource">需要加密的字符串</param>
        /// <param name="md5Bit">MD5加密的位数</param>
        /// <returns>加密后的MD5哈希密码</returns>
        public static string MD5Encrypt(string strSource, MD5Bit md5Bit)
        {
            if (string.IsNullOrEmpty(strSource))
            {
                throw new SourceIsNullOrEmptyException();
            }

            string MD5EncryptString = string.Empty;
            switch (md5Bit)
            {
                case MD5Bit.Bit16:
                    MD5EncryptString = FormsAuthentication.HashPasswordForStoringInConfigFile(strSource, "MD5").ToUpper().Substring(8, 16);
                    break;
                default:
                    MD5EncryptString = FormsAuthentication.HashPasswordForStoringInConfigFile(strSource, "MD5").ToUpper();
                    break;
            }
            return MD5EncryptString;
        }
        #endregion

        #region 加密字符串
        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="strSource">被加密的字符串</param>
        /// <param name="EncryptKey">加密用的密钥（8位加密KEY，同解密用的密钥相同）</param>
        /// <returns>加密后的字符串</returns>
        public static string EncryptedString(string strSource, string EncryptKey)
        {
            if (string.IsNullOrEmpty(strSource))
            {
                throw new SourceIsNullOrEmptyException();
            }

            if (string.IsNullOrEmpty(EncryptKey))
            {
                throw new EncryptKeyIsNullOrEmptyException();
            }

            byte[] IV = { 0x1E, 0xA2, 0x61, 0x5F, 0xD0, 0x3C, 0x99, 0xBB };//这里要与解密的相同，否则解密出来的结果会不相同。

            if (EncryptKey.Length < 8)
            {
                EncryptKey = EncryptKey.PadRight(8, '0');
            }
            else if (EncryptKey.Length > 8)
            {
                EncryptKey = EncryptKey.Remove(8);
            }

            byte[] byKey = null;
            byKey = Encoding.UTF8.GetBytes(EncryptKey.Substring(0, 8));

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] sourceByteArray = Encoding.UTF8.GetBytes(strSource);

            string strEncryptString = string.Empty;

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write))
                {
                    cs.Write(sourceByteArray, 0, sourceByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }

                strEncryptString = Convert.ToBase64String(ms.ToArray());
            }

            des.Clear();

            return strEncryptString;
        }
        #endregion

        #region 加密文件
        /// <summary>
        /// 加密文件
        /// </summary>
        /// <param name="SourceFilePath">源文件路径（被加密的文件路径）</param>
        /// <param name="TargetFilePath">目标文件路径（加密后生成的文件路径）</param>
        /// <param name="EncryptKey">加密文件用的密钥</param>
        public static void EncryptedFile(string SourceFilePath, string TargetFilePath, string EncryptKey)
        {
            if (string.IsNullOrEmpty(SourceFilePath))
            {
                throw new SourceFilePathIsNullOrEmptyException();
            }

            FileInfo fi = new FileInfo(SourceFilePath);

            if (!fi.Exists)
            {
                throw new SourceFileNotExistException();
            }

            if (fi.Length > 2048000)
            {
                throw new FileSizeIsGreaterThan2MException();
            }

            if (string.IsNullOrEmpty(TargetFilePath))
            {
                throw new TargetFilePathIsNullOrEmptyException();
            }

            if (string.IsNullOrEmpty(EncryptKey))
            {
                throw new EncryptKeyIsNullOrEmptyException();
            }

            byte[] IV = { 0x1E, 0xA2, 0x61, 0x5F, 0xD0, 0x3C, 0x99, 0xBB };//这里要与解密的相同，否则解密出来的结果会不相同。

            if (EncryptKey.Length < 8)
            {
                EncryptKey = EncryptKey.PadRight(8, '0');
            }
            else if (EncryptKey.Length > 8)
            {
                EncryptKey = EncryptKey.Remove(8);
            }

            byte[] byKey = null;
            byKey = Encoding.UTF8.GetBytes(EncryptKey.Substring(0, 8));

            using (FileStream fsSource = new FileStream(SourceFilePath, FileMode.Open, FileAccess.Read))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    byte[] bSource = new byte[100];

                    long readLength = 0;
                    long writeLength = fsSource.Length;
                    int iLength = 0;

                    DES des = new DESCryptoServiceProvider();

                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write))
                    {
                        while (readLength < writeLength)
                        {
                            iLength = fsSource.Read(bSource, 0, bSource.Length);
                            cs.Write(bSource, 0, iLength);
                            readLength = readLength + iLength;
                        }

                        cs.FlushFinalBlock();

                        using (FileStream fsTarget = new FileStream(TargetFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            ms.WriteTo(fsTarget);
                            fsTarget.Close();
                        }

                        cs.Clear();
                        cs.Close();
                    }

                    des.Clear();
                    ms.Close();
                }
                fsSource.Close();
            }
        }
        #endregion






        #region 解密字符串
        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="strSource">被解密的字符串</param>
        /// <param name="DecryptKey">解密用的密钥（8位加密KEY，同加密用的密钥相同）</param>
        /// <returns>解密后的字符串</returns>
        public static string DecryptedString(string strSource, string DecryptKey)
        {
            if (string.IsNullOrEmpty(strSource))
            {
                throw new SourceIsNullOrEmptyException();
            }

            if (string.IsNullOrEmpty(DecryptKey))
            {
                throw new EncryptKeyIsNullOrEmptyException();
            }

            byte[] IV = { 0x1E, 0xA2, 0x61, 0x5F, 0xD0, 0x3C, 0x99, 0xBB };//这里要与加密的相同，否则解密出来的结果会不相同。

            if (DecryptKey.Length < 8)
            {
                DecryptKey = DecryptKey.PadRight(8, '0');
            }
            else if (DecryptKey.Length > 8)
            {
                DecryptKey = DecryptKey.Remove(8);
            }

            byte[] byKey = null;
            byKey = Encoding.UTF8.GetBytes(DecryptKey.Substring(0, 8));

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            byte[] sourceByteArray = new Byte[strSource.Length];

            try
            {
                sourceByteArray = Convert.FromBase64String(strSource);
            }
            catch
            {
                throw new DecryptErrorException();
            }

            string strDecryptString = string.Empty;

            using (MemoryStream ms = new MemoryStream())
            {
                try
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write))
                    {
                        cs.Write(sourceByteArray, 0, sourceByteArray.Length);
                        cs.FlushFinalBlock();
                        cs.Close();
                    }
                }
                catch
                {
                    throw new DecryptErrorException();
                }

                strDecryptString = Encoding.UTF8.GetString(ms.ToArray());

                ms.Close();
            }

            des.Clear();

            return strDecryptString;
        }
        #endregion

        #region 解密文件
        /// <summary>
        /// 解密文件
        /// </summary>
        /// <param name="SourceFilePath">源文件路径（被解密的文件路径）</param>
        /// <param name="TargetFilePath">目标文件路径（解密后生成的文件路径）</param>
        /// <param name="DecryptKey">解密文件用的密钥</param>
        public static void DecryptFile(string SourceFilePath, string TargetFilePath, string DecryptKey)
        {
            if (string.IsNullOrEmpty(SourceFilePath))
            {
                throw new SourceFilePathIsNullOrEmptyException();
            }

            FileInfo fi = new FileInfo(SourceFilePath);

            if (!fi.Exists)
            {
                throw new SourceFileNotExistException();
            }

            if (fi.Length > 2048000)
            {
                throw new FileSizeIsGreaterThan2MException();
            }

            if (string.IsNullOrEmpty(TargetFilePath))
            {
                throw new TargetFilePathIsNullOrEmptyException();
            }

            if (string.IsNullOrEmpty(DecryptKey))
            {
                throw new EncryptKeyIsNullOrEmptyException();
            }

            byte[] IV = { 0x1E, 0xA2, 0x61, 0x5F, 0xD0, 0x3C, 0x99, 0xBB };//这里要与加密的相同，否则解密出来的结果会不相同。

            if (DecryptKey.Length < 8)
            {
                DecryptKey = DecryptKey.PadRight(8, '0');
            }
            else if (DecryptKey.Length > 8)
            {
                DecryptKey = DecryptKey.Remove(8);
            }

            byte[] byKey = null;
            byKey = Encoding.UTF8.GetBytes(DecryptKey.Substring(0, 8));

            using (FileStream fsSource = new FileStream(SourceFilePath, FileMode.Open, FileAccess.Read))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    byte[] bSource = new byte[100];

                    long readLength = 0;
                    long writeLength = fsSource.Length;
                    int iLength = 0;

                    DES des = new DESCryptoServiceProvider();
                    try
                    {
                        using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write))
                        {
                            while (readLength < writeLength)
                            {
                                iLength = fsSource.Read(bSource, 0, bSource.Length);
                                cs.Write(bSource, 0, iLength);
                                readLength = readLength + iLength;
                            }

                            cs.FlushFinalBlock();

                            using (FileStream fsTarget = new FileStream(TargetFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                            {
                                ms.WriteTo(fsTarget);
                                fsTarget.Close();
                            }

                            cs.Clear();
                            cs.Close();
                        }
                    }
                    catch (CryptographicException)
                    {
                        throw new DecryptErrorException();
                    }

                    des.Clear();
                    ms.Close();
                }
                fsSource.Close();
            }
        }
        #endregion
    }
}
