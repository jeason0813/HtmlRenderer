﻿//Apache2, 2014-present, WinterDev

using PixelFarm.Drawing;
using LayoutFarm.CustomWidgets;
namespace LayoutFarm
{
    [DemoNote("4.3.2 UIHtmlBox with ContentMx")]
    class Demo_UIHtmlBox_ContentMx : DemoBase
    {
        HtmlBoxes.HtmlHost htmlHost;
        HtmlBoxes.HtmlHost GetHtmlHost(SampleViewport viewport)
        {
            if (htmlHost == null)
            {
                htmlHost = HtmlHostCreatorHelper.CreateHtmlHost(viewport, null, null);
                var htmlBoxContentMx = new HtmlHostContentManager();
                var contentMx = new LayoutFarm.ContentManagers.ImageContentManager();
                contentMx.ImageLoadingRequest += contentMx_ImageLoadingRequest;
                htmlBoxContentMx.AddImageContentMan(contentMx);
                htmlBoxContentMx.Bind(htmlHost);
            }
            return htmlHost;
        }

        string imgFolderPath = null;
        protected override void OnStartDemo(SampleViewport viewport)
        {
            var appPath = System.Windows.Forms.Application.ExecutablePath;
            int pos = appPath.IndexOf("\\bin\\");
            if (pos > -1)
            {
                string sub01 = appPath.Substring(0, pos);
                imgFolderPath = sub01 + "\\images";
            }
            //==================================================
            //html box
            var htmlBox = new HtmlBox(GetHtmlHost(viewport), 800, 600);
            viewport.AddChild(htmlBox);
            string html = "<html><head></head><body><div>OK1</div><div>3 Images</div><img src=\"sample01.png\"></img><img src=\"sample01.png\"></img><img src=\"sample01.png\"></img></body></html>";
            htmlBox.LoadHtmlString(html);
        }

        void contentMx_ImageLoadingRequest(object sender, LayoutFarm.ContentManagers.ImageRequestEventArgs e)
        {
            //load resource -- sync or async? 
            string absolutePath = imgFolderPath + "\\" + e.ImagSource;
            if (!System.IO.File.Exists(absolutePath))
            {
                return;
            }
            //load
             
            e.SetResultImage(LoadBitmap(absolutePath));
        }
    }
}