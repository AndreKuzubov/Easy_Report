using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WFormsAppWordExport
{
    public class AlignedLabel :Label
    {
        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                int w = Size.Width;
                base.Text = value;
                Point p = this.Location;
                if(TextAlign.Equals(ContentAlignment.MiddleRight))
                {
                    this.Location=new Point (p.X+w-Size.Width,p.Y);
                }
            }
        }

    }
}
