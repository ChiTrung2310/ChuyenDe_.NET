using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BanHang18.Lib
{
    class Encryption
    {
        #region Methods for Hashing Algorithm
        /// <summary>
        /// Phương thức sử dụng cho mục tiêu băm dữ liệu bằng các thuật toán: MD5, SHA1, SHA256, SHA384, SHA512
        /// </summary>
        /// <param name="plainText">Chuỗi dữ liệu cần băm</param>
        /// <param name="hashMethod">Sử dụng HashingProvider để yêu cầu thuật toán băm: 
        ///                          MD5CryptoServiceProvider, SHA256CryptoServiceProvider, ...</param>
        /// <returns>Chuỗi kết quả sau khi băn</returns>
        private string ComputeHash(string plainText, HashAlgorithm hashMethod)
        {
            //--- Chuyển chuỗi thông tin thành mảng các Bytes ---------------------------------
            Byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
            //--- Gọi phương thức băm để tiến hành băm dữ liệu từ inputBytes ------------------
            Byte[] hashedBytes = hashMethod.ComputeHash(inputBytes);
            //--- Chuyển kết quả từ mảng thành chuỗi trước khi trả về -------------------------
            return BitConverter.ToString(hashedBytes);
        }
        /// <summary>
        /// Băm dữ liệu bằng thuật toán MD5
        /// </summary>
        /// <param name="plainText">Chuỗi dữ liệu cần băm</param>
        /// <returns></returns>
        public string MD5_Hashing(string plainText)
        {
            return ComputeHash(plainText, new MD5CryptoServiceProvider());
        }
        /// <summary>
        /// Băm dữ liệu bằng thuật toán SHA1 [160 Bits : 20 Bytes]
        /// </summary>
        /// <param name="plainText">Chuỗi dữ liệu cần băm</param>
        /// <returns></returns>
        public string SHA1_Hashing(string plainText)
        {
            return ComputeHash(plainText, new SHA1CryptoServiceProvider());
        }
        /// <summary>
        /// Băm dữ liệu bằng thuật toán SHA256 
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public string SHA256_Hashing(string plainText)
        {
            return ComputeHash(plainText, new SHA256CryptoServiceProvider());
        }
        /// <summary>
        /// Băm dữ liệu bằng thuật toán SHA384 
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public string SHA384_Hashing(string plainText)
        {
            return ComputeHash(plainText, new SHA384CryptoServiceProvider());
        }
        /// <summary>
        /// Băm dữ liệu bằng thuật toán SHA512 
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public string SHA512_Hashing(string plainText)
        {
            return ComputeHash(plainText, new SHA512CryptoServiceProvider());
        }
        #endregion
        #region Nhóm phương thức dùng cho mã hóa đối xứng

        #endregion
        #region Nhóm các phương thức dùng cho mã hóa RAS

        #endregion
    }
}
