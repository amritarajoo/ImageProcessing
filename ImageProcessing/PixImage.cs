using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 *  The PixImage class represents an image, which is a rectangular grid of
 *  color pixels.  Each pixel has red, green, and blue intensities in the range
 *  0...255.  Descriptions of the methods you must implement appear below.
 *  They include a constructor of the form
 *
 *      public PixImage(int width, int height);
 *
 *  that creates a black (zero intensity) image of the specified width and
 *  height.  Pixels are numbered in the range (0...width - 1, 0...height - 1).
 *
 *  All methods in this class must be implemented to complete Part I.
 */


namespace ImageProcessing
{
    public class PixImage
    {
        /// <summary>
        ///  Define any variables associated with a PixImage object here.  These
        ///  variables MUST be private.
        /// </summary>
        private int ImageHeight;
        private int ImageWidth;
        private PixelColor[,] PixelMatrix;

        /// <summary>
        /// PixImage() constructs an empty PixImage with a specified width and height.
        /// Every pixel has red, green, and blue intensities of zero (solid black).
        /// </summary>
        /// <param name="width"> the width of the image. </param>
        /// <param name="height"> the height of the image. </param>
        public PixImage(int width, int height)
        {
            this.ImageHeight = height;
            this.ImageWidth = width;
            PixelMatrix = new PixelColor[height, width];
        }


        /// <summary>
        /// returns the width of the image.
        /// </summary>
        public virtual int Width
        {
            get
            {
                return ImageWidth;
            }
        }

        /// <summary>
        /// returns the height of the image.
        /// </summary>
        public virtual int Height
        {
            get
            {
                return ImageHeight;
            }
        }

        /// <summary>
        /// getRed() returns the red intensity of the pixel at coordinate (x, y).
        /// </summary>
        /// <param name="x"> the x-coordinate of the pixel. </param>
        /// <param name="y"> the y-coordinate of the pixel. </param>
        /// <returns> the red intensity of the pixel at coordinate (x, y). </returns>
        public virtual short getRed(int x, int y)
        {
            if (x >= 0 && x < ImageWidth && y >= 0 && y < ImageHeight)
            {
                return PixelMatrix[y, x].Red;
            }
            else
            {
                throw new ArgumentException(string.Format("x and y values should be in range [0-{0}],[0-{1}]",ImageWidth - 1, ImageHeight - 1));
            }

        }

        /// <summary>
        /// getGreen() returns the green intensity of the pixel at coordinate (x, y).
        /// </summary>
        /// <param name="x"> the x-coordinate of the pixel. </param>
        /// <param name="y"> the y-coordinate of the pixel. </param>
        /// <returns> the green intensity of the pixel at coordinate (x, y). </returns>
        public virtual short getGreen(int x, int y)
        {
            if (x >= 0 && x < ImageWidth && y >= 0 && y < ImageHeight)
            {
                return PixelMatrix[y, x].Green;
            }
            else
            {
                throw new ArgumentException(string.Format("x and y values should be in range [0-{0}],[0-{1}]", ImageWidth - 1, ImageHeight - 1));
            }

        }

        /// <summary>
        /// getBlue() returns the blue intensity of the pixel at coordinate (x, y).
        /// </summary>
        /// <param name="x"> the x-coordinate of the pixel. </param>
        /// <param name="y"> the y-coordinate of the pixel. </param>
        /// <returns> the blue intensity of the pixel at coordinate (x, y). </returns>
        public virtual short getBlue(int x, int y)
        {
            if (x >= 0 && x < ImageWidth && y >= 0 && y < ImageHeight)
            {
                return PixelMatrix[y, x].Blue;
            }
            else
            {
                throw new ArgumentException(string.Format("x and y values should be in range [0-{0}],[0-{1}]", ImageWidth - 1, ImageHeight - 1));
            }
        }
        /// <summary>
        /// setPixel() sets the pixel at coordinate (x, y) to specified red, green,
        /// and blue intensities.
        ///   
        /// If any of the three color intensities is NOT in the range 0...255, then
        /// this method does NOT change any of the pixel intensities.
        /// </summary>
        /// <param name="x"> the x-coordinate of the pixel. </param>
        /// <param name="y"> the y-coordinate of the pixel. </param>
        /// <param name="red"> the new red intensity for the pixel at coordinate (x, y). </param>
        /// <param name="green"> the new green intensity for the pixel at coordinate (x, y). </param>
        /// <param name="blue"> the new blue intensity for the pixel at coordinate (x, y). </param>
        public virtual void setPixel(int x, int y, short red, short green, short blue)
        {
            if (x >= 0 && x < ImageWidth && y >= 0 && y < ImageHeight)
            {
                PixelMatrix[y, x] = new PixelColor(red, green, blue);
            }
            else
            {
                throw new ArgumentException(string.Format("x and y values should be in range [0-{0}],[0-{1}]", ImageWidth - 1, ImageHeight - 1));
            }
        }

        /// <summary>
        /// toString() returns a String representation of this PixImage.
        /// 
        /// This method isn't required, but it should be very useful to you when
        /// you're debugging your code.  It's up to you how you represent a PixImage
        /// as a String.
        /// </summary>
        /// <returns> a String representation of this PixImage. </returns>
        public override string ToString()
        {
            return "";
        }

        /// <summary>
        /// boxBlur() returns a blurred version of "this" PixImage.
        /// 
        /// If numIterations == 1, each pixel in the output PixImage is assigned
        /// a value equal to the average of its neighboring pixels in "this" PixImage,
        /// INCLUDING the pixel itself.
        /// 
        /// A pixel not on the image boundary has nine neighbors--the pixel itself and
        /// the eight pixels surrounding it.  A pixel on the boundary has six
        /// neighbors if it is not a corner pixel; only four neighbors if it is
        /// a corner pixel.  The average of the neighbors is the sum of all the
        /// neighbor pixel values (including the pixel itself) divided by the number
        /// of neighbors, with non-integer quotients rounded toward zero (as C# does
        /// naturally when you divide two integers).
        /// 
        /// Each color (red, green, blue) is blurred separately.  The red input should
        /// have NO effect on the green or blue outputs, etc.
        /// 
        /// The parameter numIterations specifies a number of repeated iterations of
        /// box blurring to perform.  If numIterations is zero or negative, "this"
        /// PixImage is returned (not a copy).  If numIterations is positive, the
        /// return value is a newly constructed PixImage.
        /// 
        /// IMPORTANT:  DO NOT CHANGE "this" PixImage!!!  All blurring/changes should
        /// appear in the new, output PixImage only.
        /// </summary>
        /// <param name="numIterations"> the number of iterations of box blurring. </param>
        /// <returns> a blurred version of "this" PixImage. </returns>
        public virtual PixImage boxBlur(int numIterations)
        {
            // Replace the following line with your solution.
            PixelColor[,] pixelsSource = new PixelColor[ImageHeight, ImageWidth];
            for (int y = 0; y < ImageHeight; y++)
            {
                for (int x = 0; x < ImageWidth; x++)
                {
                    pixelsSource[y, x] = new PixelColor(
                        PixelMatrix[y, x].Red,
                        PixelMatrix[y, x].Green,
                        PixelMatrix[y, x].Blue);
                }
            }

            PixelColor[,] pixelsResult = new PixelColor[ImageHeight, ImageWidth];
            for (int k = 0; k < numIterations; k++)
            {
                for (int y = 0; y < ImageHeight; y++)
                {
                    for (int x = 0; x < ImageWidth; x++)
                    {
                        pixelsResult[y, x] = new PixelColor(
                            pixelsSource[y, x].Red,
                            pixelsSource[y, x].Green,
                            pixelsSource[y, x].Blue);
                    }
                }

                SetPixelAverageVal(pixelsSource, pixelsResult, 1); //red
                SetPixelAverageVal(pixelsSource, pixelsResult, 2); //green
                SetPixelAverageVal(pixelsSource, pixelsResult, 3); //blue

                for (int y = 0; y < ImageHeight; y++)
                {
                    for (int x = 0; x < ImageWidth; x++)
                    {
                        pixelsSource[y, x] = new PixelColor(
                            pixelsResult[y, x].Red,
                            pixelsResult[y, x].Green,
                            pixelsResult[y, x].Blue);
                    }
                }

            }

            PixImage resultImage = new PixImage(ImageWidth, ImageHeight);
            for (int y = 0; y < ImageHeight; y++)
            {
                for (int x = 0; x < ImageWidth; x++)
                {
                    resultImage.setPixel(
                        x,
                        y,
                        pixelsResult[y, x].Red,
                        pixelsResult[y, x].Green,
                        pixelsResult[y, x].Blue);
                }
            }

            return resultImage;
        }

        private void SetPixelAverageVal(PixelColor[,] pixelsSource, PixelColor[,] pixelsResult, int color)
        {
            int w = ImageWidth;
            int h = ImageHeight;
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    int sum = 0;
                    int count = 0;
                    switch (color)
                    {
                        case 1:
                            sum = pixelsSource[y,x].Red;
                            count = 1;
                            if (x + 1 < w && y + 1 < h)
                            {
                                sum += pixelsSource[y + 1, x + 1].Red;
                                count++;
                            }
                            if (y + 1 < h)
                            {
                                sum += pixelsSource[y + 1, x].Red;
                                count++;
                            }

                            if (x - 1 >= 0 && y + 1 < h)
                            {
                                sum += pixelsSource[y + 1, x - 1].Red;
                                count++;
                            }
                            if (x - 1 >= 0)
                            {
                                sum += pixelsSource[y, x - 1].Red;
                                count++;
                            }
                            if (x - 1 >= 0 && y - 1 >= 0)
                            {
                                sum += pixelsSource[y-1, x - 1].Red;
                                count++;
                            }
                            if (y - 1 >= 0)
                            {
                                sum += pixelsSource[y - 1, x].Red;
                                count++;
                            }
                            if (x + 1 < w && y - 1 >= 0)
                            {
                                sum += pixelsSource[y - 1, x + 1].Red;
                                count++;
                            }
                            if (x + 1 < w)
                            {
                                sum += pixelsSource[y, x + 1].Red;
                                count++;
                            }
                            pixelsResult[y, x].Red = (short) (sum / count);
                            break;

                        case 2:
                            sum = pixelsSource[y,x].Green;
                            count = 1;
                            if (x + 1 < w && y + 1 < h)
                            {
                                sum += pixelsSource[y + 1, x + 1].Green;
                                count++;
                            }
                            if (y + 1 < h)
                            {
                                sum += pixelsSource[y + 1, x].Green;
                                count++;
                            }

                            if (x - 1 >= 0 && y + 1 < h)
                            {
                                sum += pixelsSource[y + 1, x - 1].Green;
                                count++;
                            }
                            if (x - 1 >= 0)
                            {
                                sum += pixelsSource[y, x - 1].Green;
                                count++;
                            }
                            if (x - 1 >= 0 && y - 1 >= 0)
                            {
                                sum += pixelsSource[y - 1, x - 1].Green;
                                count++;
                            }
                            if (y - 1 >= 0)
                            {
                                sum += pixelsSource[y - 1, x].Green;
                                count++;
                            }
                            if (x + 1 < w && y - 1 >= 0)
                            {
                                sum += pixelsSource[y - 1, x + 1].Green;
                                count++;
                            }
                            if (x + 1 < w)
                            {
                                sum += pixelsSource[y, x + 1].Green;
                                count++;
                            }
                            pixelsResult[y, x].Green = (short)(sum / count);
                            break;
                        case 3:
                            sum = pixelsSource[y,x].Blue;
                            count = 1;
                            if (x + 1 < w && y + 1 < h)
                            {
                                sum += pixelsSource[y + 1, x + 1].Blue;
                                count++;
                            }
                            if (y + 1 < h)
                            {
                                sum += pixelsSource[y + 1, x].Blue;
                                count++;
                            }

                            if (x - 1 >= 0 && y + 1 < h)
                            {
                                sum += pixelsSource[y + 1, x - 1].Blue;
                                count++;
                            }
                            if (x - 1 >= 0)
                            {
                                sum += pixelsSource[y, x - 1].Blue;
                                count++;
                            }
                            if (x - 1 >= 0 && y - 1 >= 0)
                            {
                                sum += pixelsSource[y - 1, x - 1].Blue;
                                count++;
                            }
                            if (y - 1 >= 0)
                            {
                                sum += pixelsSource[y - 1, x].Blue;
                                count++;
                            }
                            if (x + 1 < w && y - 1 >= 0)
                            {
                                sum += pixelsSource[y - 1, x + 1].Blue;
                                count++;
                            }
                            if (x + 1 < w)
                            {
                                sum += pixelsSource[y, x + 1].Blue;
                                count++;
                            }
                            pixelsResult[y, x].Blue = (short)(sum / count);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// mag2gray() maps an energy (squared vector magnitude) in the range
        /// 0...24,969,600 to a grayscale intensity in the range 0...255.  The map
        /// is logarithmic, but shifted so that values of 5,080 and below map to zero.
        /// 
        /// DO NOT CHANGE THIS METHOD.  If you do, you will not be able to get the
        /// correct images and pass the autograder.
        /// </summary>
        /// <param name="mag"> the energy (squared vector magnitude) of the pixel whose
        /// intensity we want to compute. </param>
        /// <returns> the intensity of the output pixel. </returns>
        private static short mag2gray(long mag)
        {
            short intensity = (short)(30.0 * Math.Log(1.0 + (double)mag) - 256.0);

            // Make sure the returned intensity is in the range 0...255, regardless of
            // the input value.
            if (intensity < 0)
            {
                intensity = 0;
            }
            else if (intensity > 255)
            {
                intensity = 255;
            }
            return intensity;
        }

        /// <summary>
        /// sobelEdges() applies the Sobel operator, identifying edges in "this"
        /// image.  The Sobel operator computes a magnitude that represents how
        /// strong the edge is.  We compute separate gradients for the red, blue, and
        /// green components at each pixel, then sum the squares of the three
        /// gradients at each pixel.  We convert the squared magnitude at each pixel
        /// into a grayscale pixel intensity in the range 0...255 with the logarithmic
        /// mapping encoded in mag2gray().  The output is a grayscale PixImage whose
        /// pixel intensities reflect the strength of the edges.
        ///   
        /// See http://en.wikipedia.org/wiki/Sobel_operator#Formulation for details.
        /// </summary>
        /// <returns> a grayscale PixImage representing the edges of the input image.
        /// Whiter pixels represent stronger edges. </returns>
        public virtual PixImage sobelEdges()
        {
            int[,] gx = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] gy = new int[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };

            PixelColor[,] pixelResult = new PixelColor[ImageHeight, ImageWidth];
            for (int y = 0; y < ImageHeight; y++)
                for (int x = 0; x < ImageWidth; x++)
                {
                    int[,] adjacentPixelsRed = FindAdjacentPixels(y, x, 1); //red
                    int[,] adjacentPixelsGreen = FindAdjacentPixels(y, x, 2); //green
                    int[,] adjacentPixelsBlue = FindAdjacentPixels(y, x, 3); //blue

                    int redGx = FindGradient(gx, adjacentPixelsRed);
                    int redGy = FindGradient(gy, adjacentPixelsRed);
                    int greenGx = FindGradient(gx, adjacentPixelsGreen);
                    int greenGy = FindGradient(gy, adjacentPixelsGreen);
                    int blueGx = FindGradient(gx, adjacentPixelsBlue);
                    int blueGy = FindGradient(gy, adjacentPixelsBlue);

                    // calculate energy value 
                    int energyValue = (redGx * redGx) + (greenGx * greenGx) + (blueGx * blueGx) +
                                      (redGy * redGy) + (greenGy * greenGy) + (blueGy * blueGy);

                    // calculate final value by by calling mag2gray
                    short greyValue = mag2gray(energyValue);

                    //setting grey value in each Pixel
                    pixelResult[y, x] = new PixelColor(greyValue, greyValue, greyValue);
                }

                //Constructing the result Image
                PixImage resultImage = new PixImage(ImageWidth, ImageHeight);
                for (int y = 0; y < ImageHeight; y++)
                    for (int x = 0; x < ImageWidth; x++)
                    {
                        resultImage.setPixel(x, y, pixelResult[y, x].Red, pixelResult[y, x].Green, pixelResult[y, x].Blue);
                    }

                return resultImage;
        }

        public int[,] FindAdjacentPixels(int y, int x, int color)
        {
            int[,] adjacent = new int[3, 3];
            switch (color)
            {
                case 1:
                    //top left
                    if (y - 1 >= 0 && x - 1 >= 0)
                    {
                        adjacent[0, 0] = PixelMatrix[y - 1, x - 1].Red;
                    }
                    else 
                    {
                        if (y - 1 >= 0)
                        {
                            adjacent[0, 0] = PixelMatrix[y - 1, x].Red;
                        }
                        else if (x - 1 >= 0)
                        {
                            adjacent[0, 0] = PixelMatrix[y, x - 1].Red;
                            
                        }
                        else
                        {
                            adjacent[0, 0] = PixelMatrix[y, x].Red;
                        }
                    }
                    
                    //top
                    adjacent[0, 1] = (y - 1 >= 0) ?
                        PixelMatrix[y - 1, x].Red :
                        PixelMatrix[y, x].Red;

                    //top right
                    if (y - 1 >= 0 && x + 1 < ImageWidth)
                    {
                        adjacent[0, 2] = PixelMatrix[y - 1, x + 1].Red;
                    }
                    else
                    {
                        if (y - 1 >= 0)
                        {
                             adjacent[0, 2] = PixelMatrix[y - 1, x].Red;
                        }
                        else if (x + 1 < ImageWidth)
                        {
                            adjacent[0, 2] = PixelMatrix[y, x + 1].Red;
                        }
                        else
                        {
                            adjacent[0, 2] = PixelMatrix[y, x].Red;
                        }
                    }

                    //left
                    adjacent[1, 0] = (x - 1 >= 0) ?
                        PixelMatrix[y, x - 1].Red :
                        PixelMatrix[y, x].Red;

                    //middle
                    adjacent[1, 1] = PixelMatrix[y, x].Red;

                    //right
                    adjacent[1, 2] = (x + 1 < ImageWidth) ?
                        PixelMatrix[y, x + 1].Red :
                        PixelMatrix[y, x].Red;

                    //left bottom
                    if (y + 1 < ImageHeight && x - 1 >= 0)
                    {
                        adjacent[2, 0] = PixelMatrix[y + 1, x - 1].Red;
                    }
                    else 
                    {
                        if (y + 1 < ImageHeight)
                        {
                            adjacent[2, 0] = PixelMatrix[y + 1, x].Red;
                        }
                        else if (x - 1 >= 0)
                        {
                            adjacent[2, 0] = PixelMatrix[y, x - 1].Red;
                            
                        }
                        else
                        {
                            adjacent[2, 0] = PixelMatrix[y, x].Red;
                        }
                    }

                    //bottom
                    adjacent[2, 1] = (y + 1 < ImageHeight) ?
                        PixelMatrix[y + 1, x].Red :
                         PixelMatrix[y, x].Red;

                    //bottom right
                    if (y + 1 < ImageHeight && x + 1 < ImageWidth)
                    {
                        adjacent[2, 2] = PixelMatrix[y + 1, x + 1].Red;
                    }
                    else 
                    {
                        if (y + 1 < ImageHeight)
                        {
                            adjacent[2, 2] = PixelMatrix[y + 1, x].Red;
                        }
                        else if (x + 1 < ImageWidth)
                        {
                            adjacent[2, 2] = PixelMatrix[y, x + 1].Red;
                            
                        }
                        else
                        {
                            adjacent[2, 2] = PixelMatrix[y, x].Red;
                        }
                    }
                    break;
                case 2:
                    //top left
                    if (y - 1 >= 0 && x - 1 >= 0)
                    {
                        adjacent[0, 0] = PixelMatrix[y - 1, x - 1].Green;
                    }
                    else
                    {
                        if (y - 1 >= 0)
                        {
                            adjacent[0, 0] = PixelMatrix[y - 1, x].Green;
                        }
                        else if (x - 1 >= 0)
                        {
                            adjacent[0, 0] = PixelMatrix[y, x - 1].Green;

                        }
                        else
                        {
                            adjacent[0, 0] = PixelMatrix[y, x].Green;
                        }
                    }

                    //top
                    adjacent[0, 1] = (y - 1 >= 0) ?
                        PixelMatrix[y - 1, x].Green :
                        PixelMatrix[y, x].Green;

                    //top right
                    if (y - 1 >= 0 && x + 1 < ImageWidth)
                    {
                        adjacent[0, 2] = PixelMatrix[y - 1, x + 1].Green;
                    }
                    else
                    {
                        if (y - 1 >= 0)
                        {
                            adjacent[0, 2] = PixelMatrix[y - 1, x].Green;
                        }
                        else if (x + 1 < ImageWidth)
                        {
                            adjacent[0, 2] = PixelMatrix[y, x + 1].Green;
                        }
                        else
                        {
                            adjacent[0, 2] = PixelMatrix[y, x].Green;
                        }
                    }

                    //left
                    adjacent[1, 0] = (x - 1 >= 0) ?
                        PixelMatrix[y, x - 1].Green :
                        PixelMatrix[y, x].Green;

                    //middle
                    adjacent[1, 1] = PixelMatrix[y, x].Green;

                    //right
                    adjacent[1, 2] = (x + 1 < ImageWidth) ?
                        PixelMatrix[y, x + 1].Green :
                        PixelMatrix[y, x].Green;

                    //left bottom
                    if (y + 1 < ImageHeight && x - 1 >= 0)
                    {
                        adjacent[2, 0] = PixelMatrix[y + 1, x - 1].Green;
                    }
                    else
                    {
                        if (y + 1 < ImageHeight)
                        {
                            adjacent[2, 0] = PixelMatrix[y + 1, x].Green;
                        }
                        else if (x - 1 >= 0)
                        {
                            adjacent[2, 0] = PixelMatrix[y, x - 1].Green;

                        }
                        else
                        {
                            adjacent[2, 0] = PixelMatrix[y, x].Green;
                        }
                    }

                    //bottom
                    adjacent[2, 1] = (y + 1 < ImageHeight) ?
                        PixelMatrix[y + 1, x].Green :
                         PixelMatrix[y, x].Green;

                    //bottom right
                    if (y + 1 < ImageHeight && x + 1 < ImageWidth)
                    {
                        adjacent[2, 2] = PixelMatrix[y + 1, x + 1].Green;
                    }
                    else
                    {
                        if (y + 1 < ImageHeight)
                        {
                            adjacent[2, 2] = PixelMatrix[y + 1, x].Green;
                        }
                        else if (x + 1 < ImageWidth)
                        {
                            adjacent[2, 2] = PixelMatrix[y, x + 1].Green;

                        }
                        else
                        {
                            adjacent[2, 2] = PixelMatrix[y, x].Green;
                        }
                    }
                    break;
                case 3:
                    //top left
                    if (y - 1 >= 0 && x - 1 >= 0)
                    {
                        adjacent[0, 0] = PixelMatrix[y - 1, x - 1].Blue;
                    }
                    else
                    {
                        if (y - 1 >= 0)
                        {
                            adjacent[0, 0] = PixelMatrix[y - 1, x].Blue;
                        }
                        else if (x - 1 >= 0)
                        {
                            adjacent[0, 0] = PixelMatrix[y, x - 1].Blue;

                        }
                        else
                        {
                            adjacent[0, 0] = PixelMatrix[y, x].Blue;
                        }
                    }

                    //top
                    adjacent[0, 1] = (y - 1 >= 0) ?
                        PixelMatrix[y - 1, x].Blue :
                        PixelMatrix[y, x].Blue;

                    //top right
                    if (y - 1 >= 0 && x + 1 < ImageWidth)
                    {
                        adjacent[0, 2] = PixelMatrix[y - 1, x + 1].Blue;
                    }
                    else
                    {
                        if (y - 1 >= 0)
                        {
                            adjacent[0, 2] = PixelMatrix[y - 1, x].Blue;
                        }
                        else if (x + 1 < ImageWidth)
                        {
                            adjacent[0, 2] = PixelMatrix[y, x + 1].Blue;
                        }
                        else
                        {
                            adjacent[0, 2] = PixelMatrix[y, x].Blue;
                        }
                    }

                    //left
                    adjacent[1, 0] = (x - 1 >= 0) ?
                        PixelMatrix[y, x - 1].Blue :
                        PixelMatrix[y, x].Blue;

                    //middle
                    adjacent[1, 1] = PixelMatrix[y, x].Blue;

                    //right
                    adjacent[1, 2] = (x + 1 < ImageWidth) ?
                        PixelMatrix[y, x + 1].Blue :
                        PixelMatrix[y, x].Blue;

                    //left bottom
                    if (y + 1 < ImageHeight && x - 1 >= 0)
                    {
                        adjacent[2, 0] = PixelMatrix[y + 1, x - 1].Blue;
                    }
                    else
                    {
                        if (y + 1 < ImageHeight)
                        {
                            adjacent[2, 0] = PixelMatrix[y + 1, x].Blue;
                        }
                        else if (x - 1 >= 0)
                        {
                            adjacent[2, 0] = PixelMatrix[y, x - 1].Blue;

                        }
                        else
                        {
                            adjacent[2, 0] = PixelMatrix[y, x].Blue;
                        }
                    }

                    //bottom
                    adjacent[2, 1] = (y + 1 < ImageHeight) ?
                        PixelMatrix[y + 1, x].Blue :
                         PixelMatrix[y, x].Blue;

                    //bottom right
                    if (y + 1 < ImageHeight && x + 1 < ImageWidth)
                    {
                        adjacent[2, 2] = PixelMatrix[y + 1, x + 1].Blue;
                    }
                    else
                    {
                        if (y + 1 < ImageHeight)
                        {
                            adjacent[2, 2] = PixelMatrix[y + 1, x].Blue;
                        }
                        else if (x + 1 < ImageWidth)
                        {
                            adjacent[2, 2] = PixelMatrix[y, x + 1].Blue;

                        }
                        else
                        {
                            adjacent[2, 2] = PixelMatrix[y, x].Blue;
                        }
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid Case");
            }

            return adjacent;
        }

        public int FindGradient(int[,] gr, int[,] neighbours)
        {
            int sum = 0;
            int w = neighbours.GetLength(0);
            int h = neighbours.GetLength(1);

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    sum += gr[y, x] * neighbours[y, x];
                }
            }
            return sum;
        }

    /// <summary>
    /// TEST CODE:  YOU DO NOT NEED TO FILL IN ANY METHODS BELOW THIS POINT.
    /// You are welcome to add tests, though.  Methods below this point will not
    /// be tested.  This is not the autograder, which will be provided separately.
    /// </summary>


    /// <summary>
    /// doTest() checks whether the condition is true and prints the given error
    /// message if it is not.
    /// </summary>
    /// <param name="b"> the condition to check. </param>
    /// <param name="msg"> the error message to print if the condition is false. </param>
    private static void doTest(bool b, string msg)
        {
            if (b)
            {
                Console.WriteLine("Good.");
            }
            else
            {
                Console.Error.WriteLine(msg);
            }
        }

        /// <summary>
        /// array2PixImage() converts a 2D array of grayscale intensities to
        /// a grayscale PixImage.
        /// </summary>
        /// <param name="pixels"> a 2D array of grayscale intensities in the range 0...255. </param>
        /// <returns> a new PixImage whose red, green, and blue values are equal to
        /// the input grayscale intensities. </returns>
        private static PixImage array2PixImage(int[][] pixels)
        {
            int width = pixels.Length;
            int height = pixels[0].Length;
            PixImage image = new PixImage(width, height);

            for (int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    image.setPixel(x, y, (short)pixels[x][y], (short)pixels[x][y], (short)pixels[x][y]);
                }
            }

            return image;
        }

        /// <summary>
        /// equals() checks whether two images are the same, i.e. have the same
        /// dimensions and pixels.
        /// </summary>
        /// <param name="image"> a PixImage to compare with "this" PixImage. </param>
        /// <returns> true if the specified PixImage is identical to "this" PixImage. </returns>
        public virtual bool Equals(PixImage image)
        {
            int width = Width;
            int height = Height;

            if (image == null || width != image.Width || height != image.Height)
            {
                return false;
            }

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (!(getRed(x, y) == image.getRed(x, y) && getGreen(x, y) == image.getGreen(x, y) && getBlue(x, y) == image.getBlue(x, y)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// main() runs a series of tests to ensure that the convolutions (box blur
        /// and Sobel) are correct.
        /// </summary>
        public static void Main(string[] args)
        {
            // Be forwarned that when you write arrays directly in C# as below,
            // each "row" of text is a column of your image--the numbers get
            // transposed.
            PixImage image1 = array2PixImage(new int[][]
            {
                new int[] {0, 10, 240},
                new int[] {30, 120, 250},
                new int[] {80, 250, 255}
            });
            Console.WriteLine("Testing getWidth/getHeight on a 3x3 image.  " + "Input image:");
            Console.Write(image1);
            doTest(image1.Width == 3 && image1.Height == 3, "Incorrect image width and height.");

            Console.WriteLine("Testing blurring on a 3x3 image.");
            doTest(image1.boxBlur(1).Equals(array2PixImage(new int[][]
                {
            new int[] {40, 108, 155},
            new int[] {81, 137, 187},
            new int[] {120, 164, 218}
                })), "Incorrect box blur (1 rep):\n" + image1.boxBlur(1));

            doTest(image1.boxBlur(2).Equals(array2PixImage(new int[][]
                {
            new int[] {91, 118, 146},
            new int[] {108, 134, 161},
            new int[] {125, 151, 176}
                })), "Incorrect box blur (2 rep):\n" + image1.boxBlur(2));
            doTest(image1.boxBlur(2).Equals(image1.boxBlur(1).boxBlur(1)),
                "Incorrect box blur (1 rep + 1 rep):\n" + image1.boxBlur(2) + image1.boxBlur(1).boxBlur(1));

            Console.WriteLine("Testing edge detection on a 3x3 image.");
            doTest(image1.sobelEdges().Equals(array2PixImage(new int[][]
                {
            new int[] {104, 189, 180},
            new int[] {160, 193, 157},
            new int[] {166, 178, 96}
                })), "Incorrect Sobel:\n" + image1.sobelEdges());


            PixImage image2 = array2PixImage(new int[][]
                {
            new int[] {0, 100, 100},
            new int[] {0, 0, 100}
                });
            Console.WriteLine("Testing getWidth/getHeight on a 2x3 image.  " + "Input image:");
            Console.Write(image2);
            doTest(image2.Width == 2 && image2.Height == 3, "Incorrect image width and height.");

            Console.WriteLine("Testing blurring on a 2x3 image.");
            doTest(image2.boxBlur(1).Equals(array2PixImage(new int[][]
                {
            new int[] {25, 50, 75},
            new int[] {25, 50, 75}
                })), "Incorrect box blur (1 rep):\n" + image2.boxBlur(1));

            Console.WriteLine("Testing edge detection on a 2x3 image.");
            doTest(image2.sobelEdges().Equals(array2PixImage(new int[][]
                {
            new int[] {122, 143, 74},
            new int[] {74, 143, 122}
                })), "Incorrect Sobel:\n" + image2.sobelEdges());

            Console.ReadKey();
        }
    }

    public class PixelColor
    {
        public short Red;
        public short Blue;
        public short Green;
        public PixelColor(short red, short green, short blue)
        {
            this.Red = red;
            this.Blue = blue;
            this.Green = green;
        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", this.Red, this.Green, this.Blue);
        }
    }
}
    
