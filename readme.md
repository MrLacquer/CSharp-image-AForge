# Object detecting using AForge dot net

This program can detecting object with measuring distance and degree(just one camera), using C# with AForge .net framework.

For this project, I've ref. to follow url:
https://www.pyimagesearch.com/2015/01/19/find-distance-camera-objectmarker-using-python-opencv/

The main method for color object detection by Blob counter algorithm.
If you using this method, then you can detecting as follows:
            red circle, rectangle, triangle
            blue circle, rectangle, triangle
            green circle, rectangle, triangle
the process of this method as follow:
    1. color filtering by Euclidean filtering(R, G, B).
    2. the grayscale filtering based on color filtered image.
    3. In this step, you can choose the blur option. Applied blur option(or not),
       this method donging Sobel edge filtering based on grayscale(or grayscale + blur) image.
    4. the binary filtering based on edge filter image.
    5. Finally, detecting object, distance from the camera and degree are expreed on picturebox 1.
