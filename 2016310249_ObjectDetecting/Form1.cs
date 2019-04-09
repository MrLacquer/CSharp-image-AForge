using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using System.Drawing.Imaging;
using AForge;
using AForge.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;

namespace _2016310249_ObjectDetecting
{
    public partial class Form1 : Form
    {
        FilterInfoCollection _device;
        VideoCaptureDevice _CaptureDevice;
        Bitmap _bitmapEdgeImage, _bitmapBinaryImage, _bitmapGreyImage, _bitmapBlurImage, _colorFilterImage;
        //ColorFiltering _colorFilter = new ColorFiltering();
        EuclideanColorFiltering _colorFilter = new EuclideanColorFiltering();
        System.Drawing.Font _font = new System.Drawing.Font("Times New Roman", 48, FontStyle.Bold);
        System.Drawing.SolidBrush _brush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        SobelEdgeDetector _edgeFilter = new SobelEdgeDetector();
        Pen _PictureboxPen = new Pen(Color.Black, 5);

        bool _blurFlag = false;
        int ipenWidth = 5, iFeatureWidth;
        int iThreshold = 40, iRadius = 40;
        int iColorMode = 1, iRedValue = 220, iGreenValue = 30, iBlueValue = 30;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        #region Form_Load, Closing
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                _device = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                for (var i = 0; i < _device.Count; i++)
                    comboBox1.Items.Add(_device[i].Name);              
                                   
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                StopCameras();
            }
            catch
            {
                return;
            }
        }
        #endregion
             
        #region MyMethods
        private void SrartCameras(int deviceindex)
        {
            try
            {
                _CaptureDevice = new VideoCaptureDevice(_device[deviceindex].MonikerString);
                _CaptureDevice.NewFrame += new NewFrameEventHandler(get_Frame);
                //Start the Capture Device
                _CaptureDevice.Start();

                listBox1.Items.Add("Webcam connect");
                ScrollDown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StopCameras()
        {
            try
            {
                _CaptureDevice.Stop();
            }
            catch (Exception)
            {
                return;
            }
        }

        void ScrollDown()
        {
            try
            {
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                listBox1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void get_Frame(object sender, NewFrameEventArgs eventArgs)
        {
            //Insert image into Picuture Box
            Bitmap _BsourceFrame = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = BlobDetection(_BsourceFrame);
            pictureBox2.Image = _bitmapEdgeImage;
            pictureBox3.Image = _bitmapBinaryImage;
            pictureBox4.Image = _colorFilterImage;
            //if (_blurFlag == true)
            //{
            //    pictureBox4.Image = _bitmapBlurImage;
            //}
            //else if (_blurFlag == false)
            //{
            //    pictureBox4.Image = _bitmapBlurImage;
            //}            
        }

        private System.Drawing.Point[] ToPointsArray(List<IntPoint> points)
        {
            System.Drawing.Point[] array = new System.Drawing.Point[points.Count];

            for (int i = 0, n = points.Count; i < n; i++)
            {
                array[i] = new System.Drawing.Point(points[i].X, points[i].Y);
            }

            return array;
        }

        private void sbRedColor_Scroll(object sender, ScrollEventArgs e)
        {
            iRedValue = sbRedColor.Value;

            listBox1.Items.Add("Red: " + iRedValue.ToString());
            ScrollDown();
        }

        private void sbBlueColor_Scroll(object sender, ScrollEventArgs e)
        {
            iBlueValue = sbBlueColor.Value;

            listBox1.Items.Add("Blue: " + iBlueValue.ToString());
            ScrollDown();
        }

        private void sbGreenColor_Scroll(object sender, ScrollEventArgs e)
        {
            iGreenValue = sbGreenColor.Value;

            listBox1.Items.Add("Green: " + iGreenValue.ToString());
            ScrollDown();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void rbRed_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRed.Checked == true)
            {
                iColorMode = 1;
                sbRadius.Value = 100;
                iRadius = sbRadius.Value;

                sbRedColor.Value = 220;
                sbGreenColor.Value = 30;
                sbBlueColor.Value = 30;

                listBox1.Items.Add("Red: " + iRedValue.ToString());
                ScrollDown();
            }            
        }

        private void rbBlue_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBlue.Checked == true)
            {
                iColorMode = 2;
                sbRadius.Value = 180;
                iRadius = sbRadius.Value;

                sbRedColor.Value = 30;
                sbGreenColor.Value = 30;
                sbBlueColor.Value = 240;

                listBox1.Items.Add("Blue: " + iBlueValue.ToString());
                ScrollDown();
            }
        }

        private void rbGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGreen.Checked == true)
            {
                iColorMode = 3;
                sbRadius.Value = 180;
                iRadius = sbRadius.Value;

                sbRedColor.Value = 5;
                sbGreenColor.Value = 240;
                sbBlueColor.Value = 5;

                listBox1.Items.Add("Green: " + iGreenValue.ToString());
                ScrollDown();
            }
        }       

        private void sbRadius_Scroll(object sender, ScrollEventArgs e)
        {
            iRadius = sbRadius.Value;
            listBox1.Items.Add(iRadius.ToString());
            ScrollDown();
        }

        private void cbBlur_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBlur.Checked)
                _blurFlag = true;
            else
                _blurFlag = false;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                StopCameras();
                SrartCameras(comboBox1.SelectedIndex);
                //CaptureDevi.NewFrame += new NewFrameEventHandler(CaptureDevi_NewFrame);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sbThreshold_Scroll(object sender, ScrollEventArgs e)
        {
            iThreshold = sbThreshold.Value;
            listBox1.Items.Add(iThreshold.ToString());
            ScrollDown();
        }

        private double FindDistance(int _pixel)
        {
            ///
            /// distance(D): distance of object from the camera
            /// _focalLength(F): focal length of camera
            /// _pixel(P): apparent width in pixel
            /// _ObjectWidth(W): width of object
            /// 
            /// F = (P*D)/W
            ///     -> D = (W*F)/P
            ///
            double _distance;
            double _ObjectWidth = 10, _focalLength = 604.8;

            //_distance = Convert.ToInt16((_ObjectWidth * _focalLength) / _pixel);
            _distance = (_ObjectWidth * _focalLength) / _pixel;

            return _distance;
        }
        #endregion

        #region Blob Detection
        /// <summary> Blob Detection    
        /// This method for color object detection by Blob counter algorithm.
        /// If you using this method, then you can detecting as follows:
        ///             red circle, rectangle, triangle
        ///             blue circle, rectangle, triangle
        ///             green circle, rectangle, triangle
        /// the process of this method as follow:
        ///     1. color filtering by Euclidean filtering(R, G, B).
        ///     2. the grayscale filtering based on color filtered image.
        ///     3. In this step, you can choose the blur option. Applied blur option(or not),
        ///        this method donging Sobel edge filtering based on grayscale(or grayscale + blur) image.
        ///     4. the binary filtering based on edge filter image.
        ///     5. Finally, detecting object, distance from the camera and degree are expreed on picturebox 1.
        /// </summary>

        private Bitmap BlobDetection(Bitmap _bitmapSourceImage)
        {
            #region Color filtering by Euclidean filtering       
            switch (iColorMode)
            {
                case 1:
                    //_colorFilter.CenterColor = new RGB(230, 30, 30);
                    iRedValue = sbRedColor.Value;
                    iBlueValue = sbBlueColor.Value;
                    iGreenValue = sbGreenColor.Value;

                    _colorFilter.CenterColor = new RGB((byte)iRedValue, (byte)iGreenValue, (byte)iBlueValue);
                    _colorFilter.Radius = (short)iRadius;
                    _colorFilterImage = _colorFilter.Apply(_bitmapSourceImage);
                    break;
                case 2:
                    iRedValue = sbRedColor.Value;
                    iBlueValue = sbBlueColor.Value;
                    iGreenValue = sbGreenColor.Value;

                    _colorFilter.CenterColor = new RGB((byte)iRedValue, (byte)iGreenValue, (byte)iBlueValue);
                    _colorFilter.Radius = (short)iRadius;
                    _colorFilterImage = _colorFilter.Apply(_bitmapSourceImage);
                    break;
                case 3:
                    iRedValue = sbRedColor.Value;
                    iBlueValue = sbBlueColor.Value;
                    iGreenValue = sbGreenColor.Value;

                    _colorFilter.CenterColor = new RGB((byte)iRedValue, (byte)iGreenValue, (byte)iBlueValue);
                    _colorFilter.Radius = (short)iRadius;
                    _colorFilterImage = _colorFilter.Apply(_bitmapSourceImage);
                    break;
            }
            #endregion

            Grayscale _grayscale = new Grayscale(0.2125, 0.7154, 0.0721);
            _bitmapGreyImage = _grayscale.Apply(_colorFilterImage);

            #region blur option with Edge filter
            //create a edge detector instance
            if (_blurFlag == true)
            {
                //Blur _blurfilter = new Blur();
                GaussianBlur _blurfilter = new GaussianBlur(1.5);
                _bitmapBlurImage = _blurfilter.Apply(_bitmapGreyImage);
                _bitmapEdgeImage = _edgeFilter.Apply(_bitmapBlurImage);
            }
            else if(_blurFlag==false)
            {
                _bitmapEdgeImage = _edgeFilter.Apply(_bitmapGreyImage);
            }
            #endregion

            Threshold _threshold = new Threshold(iThreshold);
            _bitmapBinaryImage = _threshold.Apply(_bitmapEdgeImage);

            ///
            /// blob counter algorithm initailze. 
            /// BlobCounter.MinWidth and MinHeight -> for the defined minimum region
            ///
            BlobCounter _blobCounter = new BlobCounter();
            //Configure Filter
            _blobCounter.MinWidth = 70;
            _blobCounter.MinHeight = 70;
            _blobCounter.FilterBlobs = true;
            _blobCounter.ProcessImage(_bitmapBinaryImage);

            Blob[] _blobPoints = _blobCounter.GetObjectsInformation();
            Graphics _g = Graphics.FromImage(_bitmapSourceImage);
            SimpleShapeChecker _shapeChecker = new SimpleShapeChecker();

            for (int i = 0; i < _blobPoints.Length; i++)
            {
                List<IntPoint> _edgePoint = _blobCounter.GetBlobsEdgePoints(_blobPoints[i]);
                List<IntPoint> _corners = null;
                AForge.Point _center;
                float _radius;
                #region detecting Rectangle
                ///
                /// _corners: the corner of Quadrilateral
                /// 
                if (_shapeChecker.IsQuadrilateral(_edgePoint, out _corners))
                {
                    //Drawing the reference point of the picturebox
                    _g.DrawEllipse(_PictureboxPen, (float)(pictureBox1.Size.Width),
                                                   (float)(pictureBox1.Size.Height),
                                                   (float)10, (float)10);

                    // Drawing setting for outline of detected object
                    Rectangle[] _rects = _blobCounter.GetObjectsRectangles();                   
                    System.Drawing.Point[] _coordinates = ToPointsArray(_corners);
                    Pen _pen = new Pen(Color.Blue, ipenWidth);
                    int _x = _coordinates[0].X;
                    int _y = _coordinates[0].Y;

                    // Drawing setting for centroid of detected object
                    int _centroid_X = (int)_blobPoints[0].CenterOfGravity.X;
                    int _centroid_Y = (int)_blobPoints[0].CenterOfGravity.Y;                                        

                    //Drawing the centroid point of object
                    _g.DrawEllipse(_pen, (float)(_centroid_X), (float)(_centroid_Y), (float)10, (float)10);
                    //Degree calculation
                    int _deg_x = (int)_centroid_X - pictureBox1.Size.Width;
                    int _deg_y = pictureBox1.Size.Height - (int)_centroid_Y;
                    textBox1.Text = ("Degree: (" + _deg_x + ", " + _deg_y + ")");

                    ///
                    /// Drawing outline of detected object
                    /// 
                    if (_coordinates.Length == 4)
                    {                        
                        string _shapeString = "" + _shapeChecker.CheckShapeType(_edgePoint);
                        _g.DrawString(_shapeString, _font, _brush, _x, _y);
                        _g.DrawPolygon(_pen, ToPointsArray(_corners));                        
                    }

                    //size of rectange
                    foreach (Rectangle rc in _rects)
                    {
                        ///for debug
                        //System.Diagnostics.Debug.WriteLine(
                        //    string.Format("Rect size: ({0}, {1})", rc.Width, rc.Height));

                        iFeatureWidth = rc.Width;
                        //check the FindDistance method.
                        double dis = FindDistance(iFeatureWidth);
                        _g.DrawString(dis.ToString("N2") + "cm", _font, _brush, _x, _y + 60);
                    }
                }
                #endregion

                #region detecting Circle
                ///
                /// _center: the center of circle
                /// _radius: the radius of circle
                ///
                if (_shapeChecker.IsCircle(_edgePoint, out _center, out _radius))
                {
                    //Drawing the reference point
                    _g.DrawEllipse(_PictureboxPen, (float)(pictureBox1.Size.Width), 
                                                   (float)(pictureBox1.Size.Height), 
                                                   (float)10, (float)10);

                    // Drawing setting for outline of detected object
                    Rectangle[] _rects = _blobCounter.GetObjectsRectangles();
                    Pen _pen = new Pen(Color.Red, ipenWidth);
                    string _shapeString = "" + _shapeChecker.CheckShapeType(_edgePoint);                    
                    int _x = (int)_center.X;
                    int _y = (int)_center.Y;
                    ///
                    /// Drawing outline of detected object
                    ///
                    _g.DrawString(_shapeString, _font, _brush, _x, _y);
                    _g.DrawEllipse(_pen, (float)(_center.X - _radius),
                                         (float)(_center.Y - _radius),
                                         (float)(_radius * 2),
                                         (float)(_radius * 2));

                    //Drawing the centroid point of object
                    int _centroid_X = (int)_blobPoints[0].CenterOfGravity.X;
                    int _centroid_Y = (int)_blobPoints[0].CenterOfGravity.Y;
                    _g.DrawEllipse(_pen, (float)(_centroid_X),(float)(_centroid_Y),(float)10, (float)10);
                    //Degree calculation
                    int _deg_x = _centroid_X - pictureBox1.Size.Width;
                    int _deg_y = pictureBox1.Size.Height - _centroid_Y;
                    textBox1.Text = ("Degree: (" + _deg_x + ", " + _deg_y + ")");

                    //size of rectange
                    foreach (Rectangle rc in _rects)
                    {
                        ///for debug
                        //System.Diagnostics.Debug.WriteLine(
                        //    string.Format("Circle size: ({0}, {1})", rc.Width, rc.Height));
                        iFeatureWidth = rc.Width;
                        double dis = FindDistance(iFeatureWidth);                        
                        _g.DrawString(dis.ToString("N2") + "cm", _font, _brush, _x, _y + 60);
                    }
                }
                #endregion

                #region detecting Triangle
                ///
                /// _corners: the corner of Triangle
                ///
                if (_shapeChecker.IsTriangle(_edgePoint, out _corners))
                {
                    //Drawing the reference point
                    _g.DrawEllipse(_PictureboxPen, (float)(pictureBox1.Size.Width),
                                                   (float)(pictureBox1.Size.Height),
                                                   (float)10, (float)10);

                    // Drawing setting for outline of detected object
                    Rectangle[] _rects = _blobCounter.GetObjectsRectangles();
                    Pen _pen = new Pen(Color.Green, ipenWidth);
                    string _shapeString = "" + _shapeChecker.CheckShapeType(_edgePoint);
                    int _x = (int)_center.X;
                    int _y = (int)_center.Y;

                    // Drawing setting for centroid of detected object
                    int _centroid_X = (int)_blobPoints[0].CenterOfGravity.X;
                    int _centroid_Y = (int)_blobPoints[0].CenterOfGravity.Y;
                    ///
                    /// Drawing outline of detected object
                    ///
                    _g.DrawString(_shapeString, _font, _brush, _x, _y);
                    _g.DrawPolygon(_pen, ToPointsArray(_corners));

                    //Drawing the centroid point of object
                    _g.DrawEllipse(_pen, (float)(_centroid_X), (float)(_centroid_Y), (float)10, (float)10);
                    //Degree calculation
                    int _deg_x = (int)_centroid_X - pictureBox1.Size.Width;
                    int _deg_y = pictureBox1.Size.Height - (int)_centroid_Y;
                    textBox1.Text = ("Degree: (" + _deg_x + ", " + _deg_y + ")");
                    //size of rectange
                    foreach (Rectangle rc in _rects)
                    {
                        ///for debug
                        //System.Diagnostics.Debug.WriteLine(
                        //    string.Format("Triangle Size: ({0}, {1})", rc.Width, rc.Height));

                        iFeatureWidth = rc.Width;
                        double dis = FindDistance(iFeatureWidth);
                        _g.DrawString(dis.ToString("N2") + "cm", _font, _brush, _x, _y + 60);
                    }
                }
                #endregion
            }
            return _bitmapSourceImage;
        }
        #endregion

    }
}
