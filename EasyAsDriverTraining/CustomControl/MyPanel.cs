﻿namespace EasyAsDriverTraining.CustomControl
{
    public sealed class MyPanel : System.Windows.Forms.Panel
    {
        public MyPanel()
        {
            this.SetStyle(System.Windows.Forms.ControlStyles.UserPaint|System.Windows.Forms.ControlStyles.AllPaintingInWmPaint
                |System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, true);
            this.DoubleBuffered = true;
        }
    }
}
