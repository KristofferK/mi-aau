using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace MazeBois
{
    public class ImageGenerator
    {
        public void GenerateImage(Dictionary<Tuple<int, int>, int> result, List<Coord> path, MazeRepresentaion maze)
        {
            Image resultImage = new Bitmap(maze.Cols * 100, maze.Rows * 100, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(resultImage);
            Font fontFroniterValue = new Font(new FontFamily("arial"), 28, FontStyle.Bold, GraphicsUnit.Pixel);
            Font fontContent = new Font(new FontFamily("arial"), 20, FontStyle.Bold, GraphicsUnit.Pixel);

            for (var i = 0; i < maze.Rows; i++)
            {
                for (var j = 0; j < maze.Cols; j++)
                {
                    graphics.FillRectangle(GetColor(maze, path, i, j), new Rectangle(j * 100, i * 100, 100, 100));

                    var tuple = new Tuple<int, int>(i, j);
                    if (result.ContainsKey(tuple))
                    {
                        graphics.DrawString(result[tuple].ToString("D2"), fontFroniterValue, new SolidBrush(Color.Black), new PointF(j * 100 + 25, i * 100 + 25));
                    }
                    else
                    {
                        graphics.DrawString("xx", fontFroniterValue, new SolidBrush(Color.Black), new PointF(j * 100 + 25, i * 100 + 25));
                    }

                    graphics.DrawString(maze.AtPos(i, j).ToString(), fontContent, new SolidBrush(Color.Black), new PointF(j * 100, i * 100));
                }
            }

            resultImage.Save(Path.Combine(Path.GetTempPath(), "maze.jpg"), ImageFormat.Jpeg);
            graphics.Dispose();
            fontFroniterValue.Dispose();
            fontContent.Dispose();
            resultImage.Dispose();
        }

        private SolidBrush GetColor(MazeRepresentaion maze, List<Coord> path, int i, int j)
        {
            if (path.Any(e => e.X == i && e.Y == j)) return new SolidBrush(Color.Violet);
            var c = maze.AtPos(i, j);
            if (c == 's') return new SolidBrush(Color.Cyan);
            else if (c == 'g') return new SolidBrush(Color.Cyan);
            else if (c == '1') return new SolidBrush(Color.Green);
            else if (c == '0') return new SolidBrush(Color.Red);
            return new SolidBrush(Color.White);
        }
    }
}