using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextureSynthesys
{
    class TextureSelection
    {
        TextureSynthesizer UI;

        Bitmap sourceImage;
        public Bitmap displayedImage;

        Pen selectionPen = new Pen(Color.Red, 1);
        Graphics selectionGraphics;

        public int center_x = 0;
        public int center_y = 0;

        public int size = 32;

        public void SetSourceUI(TextureSynthesizer sourceUI)
        {
            UI = sourceUI;
        }

        public void SetSourceImage(ref Bitmap img)
        {
            sourceImage = img;
            displayedImage = new Bitmap(sourceImage);
            selectionGraphics = Graphics.FromImage(displayedImage);
            UpdateImage();
        }

        public void MoveCenter(int offset_x, int offset_y)
        {
            center_x += offset_x;
            center_y += offset_y;
            UpdateImage();
        }

        public void ChangeSize(int newSize)
        {
            size = newSize;
            UpdateImage();
        }

        public void UpdateImage()
        {
            displayedImage.Dispose();
            displayedImage = new Bitmap(sourceImage);
            selectionGraphics = Graphics.FromImage(displayedImage);

            Point imageCenter = new Point(displayedImage.Width / 2, displayedImage.Height / 2);
            Point squareUpperLeft = new Point((imageCenter.X + center_x - (size/2)), (imageCenter.Y + center_y + (size/2)));
            Point squareLowerLeft = new Point((imageCenter.X + center_x - (size/2)), (imageCenter.Y + center_y - (size/2)));
            Point squareUpperRight = new Point((imageCenter.X + center_x + (size/2)), (imageCenter.Y + center_y + (size/2)));
            Point squareLowerRight = new Point((imageCenter.X + center_x + (size/2)), (imageCenter.Y + center_y - (size/2)));

            selectionGraphics.DrawLine(selectionPen, squareUpperLeft, squareUpperRight);
            selectionGraphics.DrawLine(selectionPen, squareUpperRight, squareLowerRight);
            selectionGraphics.DrawLine(selectionPen, squareLowerRight, squareLowerLeft);
            selectionGraphics.DrawLine(selectionPen, squareLowerLeft, squareUpperLeft);

            UI.UpdateImage();
        }

    }
}
