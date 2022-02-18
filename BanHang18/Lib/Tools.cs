using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace BanHang18.Lib
{
    class Tools
    {
        /// <summary>
        /// Convert image to String [Use to send image to Database varchar(max)]
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static string ImageToString(Image img)
        {
            using (MemoryStream ms = new MemoryStream()) //--Tự động giải phóng bộ nhớ 
            {
                
                try
                {
                    //---B1: Save image to memory and convert it to byte
                    img.Save(ms, getTypeOfImage(img));
                    //byte[] imgBytes = ms.ToArray();
                    //---B2: Convert from byte array 
                    //return Convert.ToBase64String(imgBytes);
                }
                catch
                {
                    //---Nếu người dùng không chọn hình thì lấy hình mặc định này
                    Image result = Properties.Resources.noImages;
                }
                byte[] imgBytes = ms.ToArray();
                return Convert.ToBase64String(imgBytes);
            }
        }

        /// <summary>
        /// Convert string to Image [Get from database and create image on C#]
        /// </summary>
        /// <param name="imgString"></param>
        /// <returns></returns>
        public static Image stringToImage(string imgString)
        {
            //---B1: Convert from string to Byte array and store in memory stream
            Image result = Properties.Resources.noImages;
            try
            {
                byte[] imgBytes = Convert.FromBase64String(imgString);
                MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
                //---B2: Convert from Byte array to Image and resturn to the caller
                ms.Write(imgBytes, 0, imgBytes.Length);
                result = Image.FromStream(ms, true);
            }
            catch
            {
                //--Không nói gì
            }
            return result;
        }

        /// <summary>
        /// Get type Of Image
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static ImageFormat getTypeOfImage(Image img)
        {
            ImageFormat result = ImageFormat.Emf;
            if (img.RawFormat.Equals(ImageFormat.Png))
                result = ImageFormat.Png;
            else if (img.RawFormat.Equals(ImageFormat.Jpeg))
                result = ImageFormat.Jpeg;
            else if (img.RawFormat.Equals(ImageFormat.Bmp))
                result = ImageFormat.Bmp;
            else if (img.RawFormat.Equals(ImageFormat.Icon))
                result = ImageFormat.Icon;
            else if (img.RawFormat.Equals(ImageFormat.Gif))
                result = ImageFormat.Gif;
            else if (img.RawFormat.Equals(ImageFormat.Tiff))
                result = ImageFormat.Tiff;
            else if (img.RawFormat.Equals(ImageFormat.Wmf))
                result = ImageFormat.Wmf;
            else 
                result = ImageFormat.Exif;

            return result;
        }
    }
}
