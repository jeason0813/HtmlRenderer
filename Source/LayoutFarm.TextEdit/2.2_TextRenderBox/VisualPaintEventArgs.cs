﻿//2014 Apache2, WinterDev
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using LayoutFarm.Drawing;
namespace LayoutFarm.Text
{

    public class VisualPaintEventArgs : EventArgs
    {
        public Canvas canvas;
        public Rect updateArea;
        public VisualPaintEventArgs(Canvas canvas, Rect updateArea)
        {   
            this.canvas = canvas;
            this.updateArea = updateArea;
        }
        public Canvas Canvas
        {
            get
            {
                return canvas;
            }
        }
        public Rect UpdateArea
        {
            get
            {
                return updateArea;
            }
        }
    }

    public delegate void VisualPaintEventHandler(object sender, VisualPaintEventArgs e);

}