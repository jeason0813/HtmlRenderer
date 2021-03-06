﻿//MIT, 2014-present, WinterDev
using System;
namespace LayoutFarm.Demo
{
    public abstract class DemoBase
    {
        public void StartDemo(HtmlPanel panel)
        {
            this.OnStartDemo(panel);
        }
        protected virtual void OnStartDemo(HtmlPanel panel)
        {
        }
        public static PixelFarm.Drawing.Image LoadBitmap(string filename)
        {
            System.Drawing.Bitmap gdiBmp = new System.Drawing.Bitmap(filename);
            DemoBitmap bmp = new DemoBitmap(gdiBmp.Width, gdiBmp.Height, gdiBmp);
            return bmp;
        }
        public static PixelFarm.Drawing.Image LoadBitmap(System.Drawing.Bitmap bmp)
        {
            return new DemoBitmap(bmp.Width, bmp.Height, bmp);
        }
    }
    sealed class DemoBitmap : PixelFarm.Drawing.Image
    {
        int width;
        int height;

        byte[] rawImageBuffer;
        public DemoBitmap(int w, int h, byte[] rawImageBuffer, bool isInvertedImg = false)
        {
            this.width = w;
            this.height = h;
            this.rawImageBuffer = rawImageBuffer;
        }

        public DemoBitmap(int w, int h, System.Drawing.Bitmap innerImage)
        {
            this.width = w;
            this.height = h;
            SetCacheInnerImage(this, innerImage);
        }
        public override int Width
        {
            get { return this.width; }
        }
        public override int Height
        {
            get { return this.height; }
        }

        public override void Dispose()
        {
        }
        public override bool IsReferenceImage
        {
            get { return false; }
        }
        public override int ReferenceX
        {
            get { return 0; }
        }
        public override int ReferenceY
        {
            get { return 0; }
        }
        public byte[] GetRawImageBuffer()
        {
            return rawImageBuffer;
        }

        public override void RequestInternalBuffer(ref ImgBufferRequestArgs buffRequest)
        {
            throw new NotImplementedException();
        }
    }


    //public class DemoNoteAttribute : Attribute
    //{
    //    public DemoNoteAttribute(string msg)
    //    {
    //        this.Message = msg;
    //    }
    //    public string Message { get; set; }
    //}
    //class DemoInfo
    //{
    //    public readonly Type DemoType;
    //    public readonly string DemoNote;
    //    public DemoInfo(Type demoType, string demoNote)
    //    {
    //        this.DemoType = demoType;
    //        this.DemoNote = demoNote;
    //    }
    //    public override string ToString()
    //    {
    //        if (string.IsNullOrEmpty(DemoNote))
    //        {
    //            return this.DemoType.Name;
    //        }
    //        else
    //        {
    //            return this.DemoType.Name + " : " + this.DemoNote;
    //        }
    //    }
    //}
}