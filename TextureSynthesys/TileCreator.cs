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
    class TileCreator
    {
        public enum edges {
            EDGE_BOTTOM,
            EDGE_LEFT,
            EDGE_TOP,
            EDGE_RIGHT
        };

        // MODO: N = 0
        // Implementação para criar bordas no modo n = 0

        // A imagem de entrada source deve ser uma imagem quadrada.
        Bitmap createBoundaryTile(int boxSize, Bitmap source, int mode = 0)
        {
            // Aloca imagem quadrada em memória, representando o
            // boundary tile a ser gerado.
            Bitmap bTile = new Bitmap(boxSize, boxSize);

            // Seleciona região triangular da imagem source
            // "i" vai iterar sobre as posições verticais da região
            for (int i = 0; i < boxSize / 2; i++)
            {
                // "j" vai iterar sobre as posições horizontais da região,
                // sendo limitado pelo valor de "i", pois deve percorrer
                // a hipotenusa do triângulo.
                for(int j = 0; j <= boxSize / 2 - i ; j++)
                {
                    // Pega a informação do pixel em dada posição na imagem original
                    Color pixel = source.GetPixel(j, i);

                    // Posiciona o pixel na posição equivalente do tile
                    bTile.SetPixel(j, i, pixel);
                    // Reflexão horizontal
                    bTile.SetPixel(boxSize - j, i, pixel);
                    bTile.SetPixel(j, boxSize - i, pixel);
                    bTile.SetPixel(boxSize - j, boxSize - i, pixel);

                    // Inversão dos valores de i e j, para realizar a "rotação",
                    // e completar os espaços faltantes
                    bTile.SetPixel(i, j, pixel);
                    // Reflexão horizontal (valores invertidos)
                    bTile.SetPixel(boxSize - i, j, pixel);
                    bTile.SetPixel(i, boxSize - j, pixel);
                    bTile.SetPixel(boxSize - i, boxSize - j, pixel);
                }
            }

            // Retorna o boundary tile gerado.
            return bTile;
        }

        Bitmap createRandomTile(int boxSize, Bitmap source)
        {
            // Aloca imagem quadrada de tamanho definido pelo
            // usuário, representando o tile aleatório que
            // parte do wallpaper.
            Bitmap rTile = new Bitmap(boxSize, boxSize);

            // Escolhe uma seção aleatória da imagem source, de tamanho 
            // boxSize x boxSize
            Random rand = new Random();
            int x = rand.Next(0, source.Width - boxSize);
            int y = rand.Next(0, source.Height - boxSize);

            // Define os pixels da nova imagem como sendo os pixels da
            // seção aleatória escolhida.
            for (int i = 0; i < 0 + boxSize; i++)
            {
                for (int j = 0; j < 0 + boxSize; j++)
                {
                    // pos_x e pos_y representam a posição (x, y) no canto
                    // superior esquerdo da região quadrada aleatória escolhida
                    Color pixel = source.GetPixel(i + x, j + y);
                    rTile.SetPixel(i, j, pixel);
                }
            }

            // Retorna o tile aleatório escolhido
            return rTile;
        }

        Bitmap interiorBlend(edges edge, int boxSize, Bitmap bTile, Bitmap sTile, float a, float b, int colorThreshold)
        {
            Bitmap fTile = new Bitmap(boxSize, boxSize);

            for (int x = 0; x < sTile.Width; x++)
            {
                for (int y = 0; y < sTile.Height; y++)
                {
                    Color source = sTile.GetPixel(x, y);
                    Color boundary = bTile.GetPixel(x, y);

                    float influence = straightLineValue(edge, boxSize, x, y, a, b);
                    influence *= thresholdLineValue(colorThreshold, source, boundary);
                    influence *= leftDiagonalValue(edge, boxSize, x, y, a, b);
                    influence *= rightDiagonalValue(edge, boxSize, x, y, a, b);

                    int finalRed = (int)(influence * (float)boundary.R + (1 - influence) * (float)source.R);
                    int finalGreen = (int)(influence * (float)boundary.G + (1 - influence) * (float)source.G);
                    int finalBlue = (int)(influence * (float)boundary.B + (1 - influence) * (float)source.B);

                    Color finalColor = Color.FromArgb(finalRed, finalGreen, finalBlue);
                    
                    fTile.SetPixel(x, y, finalColor);
                }
            }

            return fTile;
        }

        // Equivalente à função f0 citada na tese. Ela calcula o valor
        // da influência do boundary tile na background de acordo com
        // a distância do pixel da aresta que estamos calculando.
        float straightLineValue(edges edge, int boxSize, int pos_x, int pos_y, float a, float b)
        {
            // A variável coordinate será usada para generalizar a fórmula
            // de distância da aresta.
            int coordinate = 0;

            switch (edge)
            {
                case edges.EDGE_BOTTOM:
                    {
                        coordinate = boxSize - pos_y;
                        break;
                    }
                case edges.EDGE_RIGHT:
                    {
                        coordinate = boxSize - pos_x;
                        break;
                    }
                case edges.EDGE_TOP:
                    {
                        coordinate = pos_y;
                        break;
                    }
                case edges.EDGE_LEFT:
                    {
                        coordinate = pos_x;
                        break;
                    }
            }

            float distance = (float)coordinate / (float)boxSize;

            if (distance < a)
                return 1f;
            else if (distance >= a && distance <= b)
                return Math.Abs( (distance - b) / (a - b) );
            else
                return 0f;
        }

        float thresholdLineValue(int threshold, Color source, Color boundary)
        {
            int difference = Math.Abs((int)source.R - (int)boundary.R) + Math.Abs((int)source.G - (int)boundary.G) + Math.Abs((int)source.B - (int)boundary.B);

            if (difference < threshold)
                return 0f;
            else 
                return 1f;
        }

        float leftDiagonalValue(edges edge, int boxSize, int pos_x, int pos_y, float a, float b)
        {
            int vert = 0;
            int horiz = 0;

            switch (edge)
            {
                case edges.EDGE_BOTTOM:
                    {
                        vert = boxSize - pos_y;
                        horiz = pos_x;
                        break;
                    }
                case edges.EDGE_RIGHT:
                    {
                        vert = boxSize - pos_x;
                        horiz = boxSize - pos_y;
                        break;
                    }
                case edges.EDGE_TOP:
                    {
                        vert = pos_y;
                        horiz = boxSize - pos_x;
                        break;
                    }
                case edges.EDGE_LEFT:
                    {
                        vert = pos_x;
                        horiz = pos_y;
                        break;
                    }
            }

            float angle = (float) Math.Atan2((double)vert, (double)horiz);

            if (angle < a)
                return 1f;
            else if (angle >= a && angle <= b)
                return Math.Abs((angle - b) / (a - b));
            else
                return 0f;
        }

        // Igual à implementação do left diagonal, só que reajusta
        // os valores horizontais e verticais para o cálculo do ângulo.
        float rightDiagonalValue(edges edge, int boxSize, int pos_x, int pos_y, float a, float b)
        {
            int vert = 0;
            int horiz = 0;

            switch (edge)
            {
                case edges.EDGE_BOTTOM:
                    {
                        vert = boxSize - pos_y;
                        horiz = boxSize - pos_x;
                        break;
                    }
                case edges.EDGE_RIGHT:
                    {
                        vert = boxSize - pos_x;
                        horiz = pos_y;
                        break;
                    }
                case edges.EDGE_TOP:
                    {
                        vert = pos_y;
                        horiz = pos_x;
                        break;
                    }
                case edges.EDGE_LEFT:
                    {
                        vert = pos_x;
                        horiz = boxSize - pos_y;
                        break;
                    }
            }

            float angle = (float)Math.Atan2((double)vert, (double)horiz);

            if (angle < a)
                return 1f;
            else if (angle >= a && angle <= b)
                return Math.Abs((angle - b) / (a - b));
            else
                return 0f;
        }

    }
}
