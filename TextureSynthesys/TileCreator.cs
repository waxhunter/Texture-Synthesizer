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
    abstract class TileCreator
    {
        public enum edges {
            EDGE_BOTTOM,
            EDGE_LEFT,
            EDGE_TOP,
            EDGE_RIGHT
        };

        //Cria uma matriz de 16x16 boundary tiles de acordo com o método n = 2.
        public static Bitmap[,,] createBoundaryTileN2(int boxSize, Bitmap source)
        {
            // Recupera as 4 tiles do source.
            Bitmap[] bOriginalTiles = new Bitmap[4];
            bOriginalTiles[0] = new Bitmap(boxSize / 2, boxSize / 2);
            bOriginalTiles[1] = new Bitmap(boxSize / 2, boxSize / 2);
            bOriginalTiles[2] = new Bitmap(boxSize / 2, boxSize / 2);
            bOriginalTiles[3] = new Bitmap(boxSize / 2, boxSize / 2);

            //Inicializa os pixels de cada tile.
            for (int i = 0; i < boxSize / 2; i++)
            {
                for (int j = 0; j < boxSize / 2; j++)
                {
                    Color pixel0 = source.GetPixel(i, j); //Na outra é (j, i), mas deveria ser assim, verificar se der bug.
                    Color pixel1 = source.GetPixel(boxSize / 2 + i, j);
                    Color pixel3 = source.GetPixel(i, boxSize / 2 + j);

                    // Guarda imagens com lado compatível virado para baixo.
                    bOriginalTiles[0].SetPixel(i, j, pixel0);
                    bOriginalTiles[1].SetPixel(boxSize / 2 - i - 1, boxSize / 2 - j - 1, pixel1);
                    bOriginalTiles[2].SetPixel(j, boxSize / 2 - i - 1, pixel0);
                    bOriginalTiles[3].SetPixel(boxSize / 2 - j - 1, i, pixel3);
                }
            }

            // Cria a matriz de 16x16 tiles conjuntos.
            Bitmap[,,] tilesMatrix = new Bitmap[16, 16, 4];
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    //Encontra a ordem das tiles neste conjunto.
                    int[] boundaryArray = new int[4];
                    boundaryArray[0] = i / 4;
                    boundaryArray[1] = i % 4;
                    boundaryArray[2] = j / 4;
                    boundaryArray[3] = j % 4;

                    // Array de 4 boundary tiles na posicão correta.
                    Bitmap[] rotatedTiles = new Bitmap[4];

                    //Boundary Tile 0 não é rotacionada...
                    rotatedTiles[0] = (Bitmap) bOriginalTiles[boundaryArray[0]].Clone();

                    //Boundary Tile 1 é rotacionada em 90º...
                    rotatedTiles[1] = new Bitmap(boxSize / 2, boxSize / 2);
                    for (int l = 0; l < boxSize / 2; l++)
                    {
                        for (int m = 0; m < boxSize / 2; m++)
                        {
                            Color pixel = bOriginalTiles[boundaryArray[1]].GetPixel(l, m);
                            rotatedTiles[1].SetPixel(boxSize / 2 - m - 1, l, pixel);
                        }
                    }

                    //Boundary Tile 2 é rotacionado em 180º...
                    rotatedTiles[2] = new Bitmap(boxSize / 2, boxSize / 2);
                    for (int l = 0; l < boxSize / 2; l++)
                    {
                        for (int m = 0; m < boxSize / 2; m++)
                        {
                            Color pixel = bOriginalTiles[boundaryArray[2]].GetPixel(l, m);
                            rotatedTiles[2].SetPixel(boxSize / 2 - l - 1, boxSize / 2 - m - 1, pixel);
                        }
                    }

                    //Boundary Tile 3 é rotacionada em -90º...
                    rotatedTiles[3] = new Bitmap(boxSize / 2, boxSize / 2);
                    for (int l = 0; l < boxSize / 2; l++)
                    {
                        for (int m = 0; m < boxSize / 2; m++)
                        {
                            Color pixel = bOriginalTiles[boundaryArray[3]].GetPixel(l, m);
                            rotatedTiles[3].SetPixel(m, boxSize / 2 - l - 1, pixel);
                        }
                    }

                    // Salva na matriz...
                    tilesMatrix[i, j, 0] = rotatedTiles[0];
                    tilesMatrix[i, j, 1] = rotatedTiles[1];
                    tilesMatrix[i, j, 2] = rotatedTiles[2];
                    tilesMatrix[i, j, 3] = rotatedTiles[3];
                }
            }

            return tilesMatrix;
        }

        //Cria as boundary tiles do método n = 1.
        public static Bitmap[, ,] createBoundaryTileN1(int boxSize, Bitmap source)
        {
            // Recupera as 2 tiles do source.
            Bitmap[] bOriginalTiles = new Bitmap[2];
            bOriginalTiles[0] = new Bitmap(boxSize / 2, boxSize / 2);
            bOriginalTiles[1] = new Bitmap(boxSize / 2, boxSize / 2);

            //Inicializa os pixels de cada tile.
            for (int i = 0; i < boxSize / 2; i++)
            {
                for (int j = 0; j < boxSize / 2; j++)
                {
                    Color pixel0 = source.GetPixel(i, j); //Na outra é (j, i), mas deveria ser assim, verificar se der bug.
                    Color pixel1 = source.GetPixel(boxSize / 2 + i, j);

                    // Guarda imagens com lado compatível virado para baixo.
                    bOriginalTiles[0].SetPixel(i, j, pixel0);
                    bOriginalTiles[1].SetPixel(boxSize / 2 - i - 1, boxSize / 2 - j - 1, pixel1);
                }
            }

            // Cria a matriz de 4x4 tiles conjuntos.
            Bitmap[, ,] tilesMatrix = new Bitmap[4, 4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //Encontra a ordem das tiles neste conjunto.
                    int[] boundaryArray = new int[4];
                    boundaryArray[0] = i / 2;
                    boundaryArray[1] = i % 2;
                    boundaryArray[2] = j / 2;
                    boundaryArray[3] = j % 2;

                    // Array de 4 boundary tiles na posicão correta.
                    Bitmap[] rotatedTiles = new Bitmap[4];

                    //Boundary Tile 0 não é rotacionada...
                    rotatedTiles[0] = (Bitmap)bOriginalTiles[boundaryArray[0]].Clone();

                    //Boundary Tile 1 é rotacionada em 90º...
                    rotatedTiles[1] = new Bitmap(boxSize / 2, boxSize / 2);
                    for (int l = 0; l < boxSize / 2; l++)
                    {
                        for (int m = 0; m < boxSize / 2; m++)
                        {
                            Color pixel = bOriginalTiles[boundaryArray[1]].GetPixel(l, m);
                            rotatedTiles[1].SetPixel(boxSize / 2 - m - 1, l, pixel);
                        }
                    }

                    //Boundary Tile 2 é rotacionado em 180º...
                    rotatedTiles[2] = new Bitmap(boxSize / 2, boxSize / 2);
                    for (int l = 0; l < boxSize / 2; l++)
                    {
                        for (int m = 0; m < boxSize / 2; m++)
                        {
                            Color pixel = bOriginalTiles[boundaryArray[2]].GetPixel(l, m);
                            rotatedTiles[2].SetPixel(boxSize / 2 - l - 1, boxSize / 2 - m - 1, pixel);
                        }
                    }

                    //Boundary Tile 3 é rotacionada em -90º...
                    rotatedTiles[3] = new Bitmap(boxSize / 2, boxSize / 2);
                    for (int l = 0; l < boxSize / 2; l++)
                    {
                        for (int m = 0; m < boxSize / 2; m++)
                        {
                            Color pixel = bOriginalTiles[boundaryArray[3]].GetPixel(l, m);
                            rotatedTiles[3].SetPixel(m, boxSize / 2 - l - 1, pixel);
                        }
                    }

                    // Salva na matriz...
                    tilesMatrix[i, j, 0] = rotatedTiles[0];
                    tilesMatrix[i, j, 1] = rotatedTiles[1];
                    tilesMatrix[i, j, 2] = rotatedTiles[2];
                    tilesMatrix[i, j, 3] = rotatedTiles[3];
                }
            }

            return tilesMatrix;
        }

        // MODO: N = 0
        // Implementação para criar bordas no modo n = 0

        // A imagem de entrada source deve ser uma imagem quadrada.
        public static Bitmap createBoundaryTileN0(int boxSize, Bitmap source)
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
                for(int j = i; j <= boxSize / 2 ; j++)
                {
                    // Pega a informação do pixel em dada posição na imagem original
                    Color pixel = source.GetPixel(j, i);

                    // Posiciona o pixel na posição equivalente do tile
                    bTile.SetPixel(j, i, pixel);
                    // Reflexão horizontal
                    bTile.SetPixel(boxSize - j - 1, i, pixel);
                    bTile.SetPixel(j, boxSize - i - 1, pixel);
                    bTile.SetPixel(boxSize - j - 1, boxSize - i - 1, pixel);

                    // Inversão dos valores de i e j, para realizar a "rotação",
                    // e completar os espaços faltantes
                    bTile.SetPixel(i, j, pixel);
                    // Reflexão horizontal (valores invertidos)
                    bTile.SetPixel(boxSize - i - 1, j, pixel);
                    bTile.SetPixel(i, boxSize - j - 1, pixel);
                    bTile.SetPixel(boxSize - i - 1, boxSize - j - 1, pixel);
                }
            }

            // Retorna o boundary tile gerado.
            return bTile;
        }

        public static Bitmap createRandomTile(int boxSize, Bitmap source)
        {
            // Aloca imagem quadrada de tamanho definido pelo
            // usuário, representando o tile aleatório que
            // parte do wallpaper.
            Bitmap rTile = new Bitmap(boxSize, boxSize);

            // Escolhe uma seção aleatória da imagem source, de tamanho 
            // boxSize x boxSize
            Random rand = new Random();
            int x = 0;
            for (int i = 0; i < 10; i++)
            {
                x = rand.Next(0, source.Width - boxSize);
            }
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

        public static Bitmap interiorBlend(edges edge, int boxSize, Bitmap boundaryTile, Bitmap sourceTile, float lin_a, float lin_b, float ang_a, float ang_b, int colorThreshold)
        {
            Bitmap fTile = new Bitmap(boxSize, boxSize);

            for (int x = 0; x < sourceTile.Width; x++)
            {
                bool zeroedColumn = false;
                for (int y = 0; y < sourceTile.Height; y++)
                {
                    int vert = 0;
                    int horiz = 0;

                    switch (edge)
                    {
                        case edges.EDGE_BOTTOM:
                            {
                                vert = boxSize - y - 1;
                                horiz = x;
                                break;
                            }
                        case edges.EDGE_RIGHT:
                            {
                                vert = boxSize - x - 1;
                                horiz = boxSize - y - 1;
                                break;
                            }
                        case edges.EDGE_TOP:
                            {
                                vert = y;
                                horiz = boxSize - x - 1;
                                break;
                            }
                        case edges.EDGE_LEFT:
                            {
                                vert = x;
                                horiz = y;
                                break;
                            }
                    }

                    Color source = sourceTile.GetPixel(horiz, vert);
                    Color boundary = boundaryTile.GetPixel(horiz, vert);

                    float influence = straightLineValue(edge, boxSize, x, y, lin_a, lin_b);
                    influence *= leftDiagonalValue(edge, boxSize, x, y, ang_a, ang_b);
                    influence *= rightDiagonalValue(edge, boxSize, x, y, ang_a, ang_b);

                    if (thresholdLineValue(colorThreshold, source, boundary) == 0f || zeroedColumn == true)
                    {
                        influence = 0f;
                        zeroedColumn = true;
                    }

                    //if (influence < 0.7f)
                        //Console.WriteLine("influence is minor");

                    int finalRed = (int)(influence * (float)boundary.R + (1f - influence) * (float)source.R);
                    int finalGreen = (int)(influence * (float)boundary.G + (1f - influence) * (float)source.G);
                    int finalBlue = (int)(influence * (float)boundary.B + (1f - influence) * (float)source.B);

                    Color finalColor = Color.FromArgb(finalRed, finalGreen, finalBlue);
                    
                    fTile.SetPixel(x, y, finalColor);
                }
            }

            return fTile;
        }

        // Equivalente à função f0 citada na tese. Ela calcula o valor
        // da influência do boundary tile na background de acordo com
        // a distância do pixel da aresta que estamos calculando.
        public static float straightLineValue(edges edge, int boxSize, int pos_x, int pos_y, float a, float b)
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
                return Math.Abs((distance - b) / (a - b));
            else
            {
                //Console.WriteLine("value is zero");
                return 0f;
            }
        }

        public static float thresholdLineValue(int threshold, Color source, Color boundary)
        {
            int difference = Math.Abs((int)source.R - (int)boundary.R) + Math.Abs((int)source.G - (int)boundary.G) + Math.Abs((int)source.B - (int)boundary.B);

            if (difference < threshold)
                return 0f;
            else 
                return 1f;
        }

        public static float leftDiagonalValue(edges edge, int boxSize, int pos_x, int pos_y, float a, float b)
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

            float angle = (float) RadianToDegree(Math.Atan2((double)vert, (double)horiz));

            if (angle < 90f * a)
                return 1f;
            else if (angle >= 90f * a && angle <= 90f * b)
                return Math.Abs((angle - 90f * b) / (90f * a - 90f * b));
            else
            {
                return 0f;
            }
        }

        // Igual à implementação do left diagonal, só que reajusta
        // os valores horizontais e verticais para o cálculo do ângulo.
        public static float rightDiagonalValue(edges edge, int boxSize, int pos_x, int pos_y, float a, float b)
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

            float angle = (float) RadianToDegree(Math.Atan2((double)vert, (double)horiz));

            if (angle < 90f * a)
                return 1f;
            else if (angle >= 90f * a && angle <= 90f * b)
                return Math.Abs((angle - 90f * b) / (90f * a - 90f * b));
            else
                return 0f;
        }

        private static double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }
    }
}
