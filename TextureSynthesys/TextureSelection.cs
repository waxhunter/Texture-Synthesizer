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
        TextureSynthesizer userInterface;

        Bitmap sourceImage;
        Pen selectionPen;

        public int pos_x = 0;
        public int pos_y = 0;

        public int size_x = 16;
        public int size_y = 16;

        public TextureSelection(TextureSynthesizer sourceUI, Color color)
        {
            userInterface = sourceUI;
            selectionPen = new Pen(color, 1);
            ChangeSize(sourceUI.tileSize, sourceUI.tileSize);
            UpdateImage();
        }

        public void MovePosition(int offset_x, int offset_y)
        {
            pos_x += offset_x;
            pos_y += offset_y;
            UpdateImage();
        }

        public void ChangeSize(int newSize_x, int newSize_y)
        {
            size_x = newSize_x;
            size_y = newSize_y;
            UpdateImage();
        }

        public void UpdateImage()
        {
            if (userInterface.textureMode >= TextureSynthesizer.textureModes.MODE_N0)
            {
                userInterface.RedrawSelection();
            }
        }

        public void DrawSelection()
        {
            if (userInterface.textureMode >= TextureSynthesizer.textureModes.MODE_N0)
            {
                Point squareUpperLeft = new Point(pos_x, pos_y);
                Point squareLowerLeft = new Point(pos_x,  pos_y + size_y);
                Point squareUpperRight = new Point(pos_x + size_x, pos_y);
                Point squareLowerRight = new Point(pos_x + size_x, pos_y + size_y);

                userInterface.selectionGraphics.DrawLine(selectionPen, squareUpperLeft, squareUpperRight);
                userInterface.selectionGraphics.DrawLine(selectionPen, squareUpperRight, squareLowerRight);
                userInterface.selectionGraphics.DrawLine(selectionPen, squareLowerRight, squareLowerLeft);
                userInterface.selectionGraphics.DrawLine(selectionPen, squareLowerLeft, squareUpperLeft);
            }
        }

        public bool MouseIsInSelectionBounds(int mouse_x, int mouse_y)
        {
            if ((!MouseIsInsideSelection(mouse_x, mouse_y)) &&
                (mouse_x > pos_x - 2) &&
                (mouse_x < pos_x + size_x + 2) &&
                (mouse_y < pos_y + size_y + 2) &&
                (mouse_y > pos_y - 2))
            {
                return true;
            }
            else
                return false;
        }

        public bool MouseIsInsideSelection(int mouse_x, int mouse_y)
        {
            if ((mouse_x > pos_x) &&
                (mouse_x < pos_x + size_x) &&
                (mouse_y < pos_y + size_y) &&
                (mouse_y > pos_y))
            {
                return true;
            }
            else
                return false;
        }
    }
}
