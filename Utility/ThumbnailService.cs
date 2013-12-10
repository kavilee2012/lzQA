using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;

namespace Utility
{
    public class ThumbnailService
    {
        #region 生成缩略图
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="sourceImagePath">源图路径（带文件名的完整物理路径）</param>
        /// <param name="thumbImagePath">缩略图路径（带文件名的完整物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="thumbMode">生成缩略图的方式</param>    
        public static void MakeThumb(string sourceImagePath, string thumbImagePath, int width, int height, ThumbMode thumbMode)
        {
            if (string.IsNullOrEmpty(sourceImagePath))
            {
                throw new SourceImagePathIsNullOrEmptyException();
            }

            if (!File.Exists(sourceImagePath))
            {
                throw new SourceFileNotExistException();
            }

            if (string.IsNullOrEmpty(thumbImagePath))
            {
                throw new ThumbImagePathIsNullOrEmptyException();
            }
            string directory = Path.GetDirectoryName(thumbImagePath);
            if (!Directory.Exists(directory))
            {
                throw new ThumbImagePathNotExistException();
            }

            try
            {
                using (Image sourceImage = Image.FromFile(sourceImagePath))
                {

                    if (width <= 0 && width >= sourceImage.Width)
                    {
                        throw new ThumbImageWidthIsErrorException();
                    }

                    if (height <= 0 && height >= sourceImage.Height)
                    {
                        throw new ThumbImageHeigthIsErrorException();
                    }

                    int towidth = width;
                    int toheight = height;

                    int x = 0;
                    int y = 0;
                    int ow = sourceImage.Width;
                    int oh = sourceImage.Height;

                    switch (thumbMode)
                    {
                        case ThumbMode.HW://指定高宽缩放（不变形）
                            int tempheight = sourceImage.Height * width / sourceImage.Width;
                            if (tempheight > height)
                            {
                                towidth = sourceImage.Width * height / sourceImage.Height;
                            }
                            else
                            {
                                toheight = sourceImage.Height * width / sourceImage.Width;
                            }
                            break;
                        case ThumbMode.W://指定宽，高按比例                    
                            toheight = sourceImage.Height * width / sourceImage.Width;
                            break;
                        case ThumbMode.H://指定高，宽按比例
                            towidth = sourceImage.Width * height / sourceImage.Height;
                            break;
                        case ThumbMode.CUT://指定高宽裁减（不变形）                
                            if ((double)sourceImage.Width / (double)sourceImage.Height > (double)towidth / (double)toheight)
                            {
                                oh = sourceImage.Height;
                                ow = sourceImage.Height * towidth / toheight;
                                y = 0;
                                x = (sourceImage.Width - ow) / 2;
                            }
                            else
                            {
                                ow = sourceImage.Width;
                                oh = sourceImage.Width * height / towidth;
                                x = 0;
                                y = (sourceImage.Height - oh) / 2;
                            }
                            break;
                    }

                    //新建一个bmp图片
                    using (Image bitmap = new Bitmap(towidth, toheight))
                    {

                        //新建一个画板
                        using (Graphics g = Graphics.FromImage(bitmap))
                        {

                            //设置高质量插值法
                            g.InterpolationMode = InterpolationMode.High;

                            //设置高质量,低速度呈现平滑程度
                            g.SmoothingMode = SmoothingMode.HighQuality;

                            //清空画布并以透明背景色填充
                            g.Clear(Color.Transparent);

                            //在指定位置并且按指定大小绘制原图片的指定部分
                            g.DrawImage(sourceImage, new Rectangle(0, 0, towidth, toheight),
                                new Rectangle(x, y, ow, oh),
                                GraphicsUnit.Pixel);
                        }

                        //验证缩略图的保存路径是否带有文件名,如果没有带文件名则用 thumb_原文件名
                        if (!Regex.IsMatch(thumbImagePath, @"[^\\\/:\*\?""<>\|]+\.[^\\\/:\*\?""<>\|]+$", RegexOptions.Compiled))
                        {
                            thumbImagePath = thumbImagePath + "thumb_" + sourceImagePath.Remove(0, sourceImagePath.LastIndexOf(@"\") + 1);
                        }

                        //以源文件相同的格式保存缩略图
                        bitmap.Save(thumbImagePath, sourceImage.RawFormat);
                    }
                }
            }
            catch (OutOfMemoryException)
            {
                throw new SourceFileIsNotImageException();
            }
        }
        #endregion
    }
}

/// <summary>
/// 缩略图的缩略模式
/// </summary>
public enum ThumbMode
{
    /// <summary>
    /// 指定高宽缩放（不变形）
    /// </summary>
    HW,
    /// <summary>
    /// 指定宽，高按比例 
    /// </summary>
    W,
    /// <summary>
    /// 指定高，宽按比例
    /// </summary>
    H,
    /// <summary>
    /// 指定高宽裁减（不变形） 
    /// </summary>
    CUT
}
