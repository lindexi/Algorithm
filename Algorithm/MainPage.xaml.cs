using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Algorithm.Model;
using Algorithm.ViewModel;
using Path = Windows.UI.Xaml.Shapes.Path;


//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace Algorithm
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ViewModel.viewModel view;
        public MainPage()
        {
            view = new viewModel();
            this.InitializeComponent();
        }

        private void graham(object sender, RoutedEventArgs e)
        {
            Model.graham _model_graham = new graham();
            int n = 500;
            List<Point> point = new List<Point>();
            Random ran = new Random();
            for (int i = 0; i < 100; i++)
            {
                Point temp = new Point(ran.NextDouble() * n, ran.NextDouble() * n);
                point.Add(temp);
                Windows.UI.Xaml.Shapes.Path path = new Windows.UI.Xaml.Shapes.Path
                {
                    Data = new EllipseGeometry()
                    {
                        Center = temp,
                        RadiusX = 5,
                        RadiusY = 5
                    },
                    //Fill = new SolidColorBrush(Colors.Gray)
                    Stroke = new SolidColorBrush(Colors.Gray)
                };
                canvas.Children.Add(path);
            }
            point = _model_graham.divide_conquer(point);

            n = point.Count;
            for (int i = 0; i < n; i++)
            {
               Windows.UI.Xaml.Shapes.Path path = new Windows.UI.Xaml.Shapes.Path
                {
                    Data = new EllipseGeometry()
                    {
                        Center = point[i],
                        RadiusX = 5,
                        RadiusY = 5
                    },
                    Fill = new SolidColorBrush(Colors.Gray)
                };
                canvas.Children.Add(path);
            }
            //PathFigure Figures = new PathFigure();
            ////var figures=new LineSegment();
            //for (int i = 0; i < n; i++)
            //{
            //    Figures.Segments.Add(new LineSegment()
            //    {
            //        Point = point[i]
            //    });
            //    /*new PathFigure().Segments.Add(new LineSegment() {})*/;
            //}
            //Figures.Segments.Add(new LineSegment()
            //{
            //    Point = point[0]
            //});

            //Windows.UI.Xaml.Shapes.Path PathFigure = new Path()
            //{
            //    Data = new PathGeometry()
            //    {
            //        Figures = new PathFigureCollection()
            //        {
            //            Figures
            //        }
            //    },
            //    Stroke = new SolidColorBrush(Colors.Gray)
            //};
            //canvas.Children.Add(PathFigure);
        }
    }
}
