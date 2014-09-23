﻿//2014 Apache2, WinterDev
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using LayoutFarm.Drawing;


namespace LayoutFarm
{
    public static class FormCanvasHelper
    {
        public static Form CreateNewFormCanvas(out UISurfaceViewportControl canvasViewport)
        {

            Form form1 = new Form();
            canvasViewport = new UISurfaceViewportControl();
            UISurfaceViewportControl innerViewport = canvasViewport;
            Rectangle screenClientAreaRect = Conv.ConvToRect(Screen.PrimaryScreen.WorkingArea);

            //----------------------
            var visualRoot = new MyRootGraphic(800, 600);
            var windowRoot = new MyTopWindowRenderBox(visualRoot, form1.Width, form1.Height);


            canvasViewport.SetupWindowRoot(windowRoot);
            canvasViewport.Bounds =
                new System.Drawing.Rectangle(0, 0,
                    screenClientAreaRect.Width,
                    screenClientAreaRect.Height);
            //----------------------

            form1.Controls.Add(canvasViewport);
            //----------------------
            MakeFormCanvas(form1, canvasViewport);
            //----------------------
            form1.SizeChanged += (s, e) =>
            {
                if (form1.WindowState == FormWindowState.Maximized)
                {
                    Screen currentScreen = GetScreenFromX(form1.Left);
                    //make full screen ?
                    if (innerViewport != null)
                    {
                        innerViewport.Size = currentScreen.WorkingArea.Size;
                        innerViewport.UpdateRootdocViewportSize();
                    }
                }
            };
            //----------------------
            return form1;

        }
        public static void MakeFormCanvas(Form form1, UISurfaceViewportControl surfaceViewportControl)
        {
            form1.FormClosing += (s, e) =>
            {
                surfaceViewportControl.Close();
            };

        }

        static Screen GetScreenFromX(int xpos)
        {
            Screen[] allScreens = Screen.AllScreens;
            int j = allScreens.Length;
            int accX = 0;
            for (int i = 0; i < j; ++i)
            {
                Screen sc1 = allScreens[i];
                if (accX + sc1.WorkingArea.Width > xpos)
                {
                    return sc1;
                }
            }
            return Screen.PrimaryScreen;
        }
    }
}