using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Proximity;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
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
            canvas.Children.Clear();
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
        }


        private void divide_graham(object sender, RoutedEventArgs e)
        {
            Model.graham _model_graham = new graham();
            int n = 500;
            List<Point> point = new List<Point>();
            canvas.Children.Clear();
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
                    Fill = new SolidColorBrush(Colors.Gray),
                    //Fill = new SolidColorBrush(Color.FromArgb(0xff,0xff,0xa,0x2))

                    //Stroke = new SolidColorBrush(Colors.Gray)
                };
                canvas.Children.Add(path);
            }



            //point = _model_graham.divide_conquer(point);
            //方法1
            //n = point.Count;
            ////for (int i = 0; i < n; i++)
            ////{
            ////    Windows.UI.Xaml.Shapes.Path path = new Windows.UI.Xaml.Shapes.Path
            ////    {
            ////        Data = new EllipseGeometry()
            ////        {
            ////            Center = point[i],
            ////            RadiusX = 5,
            ////            RadiusY = 5
            ////        },
            ////        Fill = new SolidColorBrush(Colors.Gray)
            ////    };
            ////    canvas.Children.Add(path);
            ////}
            //PathFigure Figures = new PathFigure();
            ////var figures=new LineSegment();
            //for (int i = 0; i < n; i++)
            //{
            //    Figures.Segments.Add(new LineSegment()
            //    {
            //        Point = point[i]
            //    });
            //    /*new PathFigure().Segments.Add(new LineSegment() {})*/
            //    ;
            //}
            //Figures.Segments.Add(new LineSegment()
            //{
            //    Point = point[0]
            //});
            //Figures.StartPoint = point[0];

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


            //方法2
            //List<TuLine> tuline = _model_graham.brute(point);

            //var path_figure = new PathGeometry();

            //foreach (TuLine temp in tuline)
            //{
            //    var path_segment = new PathFigure()
            //    {
            //        StartPoint = temp.Begin
            //    };

            //    var line = new LineSegment()
            //    {
            //        Point = temp.End
            //    };
            //    path_segment.Segments.Add(line);

            //    path_figure.Figures.Add(path_segment);
            //}
            //canvas.Children.Add(new Path()
            //{
            //    Stroke = new SolidColorBrush(Colors.Gray),
            //    StrokeThickness = 1,
            //    Data = path_figure
            //});


            //方法3
            //point = _model_graham.brute_conquer(point);
            //PathGeometry path_figure = new PathGeometry();
            //for (int i = 0; i < point.Count; i++)
            //{
            //    PathFigure path_segment = new PathFigure()
            //    {
            //        StartPoint = point[i]
            //    };
            //    i++;
            //    LineSegment line = new LineSegment()
            //    {
            //        Point = point[i]
            //    };
            //    path_segment.Segments.Add(line);
            //    path_figure.Figures.Add(path_segment);
            //}
            //canvas.Children.Add(new Path()
            //{
            //    Stroke = new SolidColorBrush(Colors.Gray),
            //    StrokeThickness = 1,
            //    Data = path_figure
            //});

            //方法3.1
            point = _model_graham.brute_conquer(point);

            for (int i = 0; i < point.Count; i++)
            {
                for (int j = i + 1; j < point.Count; j++)
                {
                    if (Math.Abs(point[i].X - point[j].X) < 0.000001 && Math.Abs(point[i].Y - point[j].Y) < 0.000001)
                    {
                        point.RemoveAt(j);
                        j--;
                    }
                }
            }

            point = _model_graham.divide_conquer(point, true);

            n = point.Count;

            PathFigure figures = new PathFigure();

            for (int i = 0; i < n; i++)
            {
                figures.Segments.Add(new LineSegment()
                {
                    Point = point[i]
                });
            }
            figures.Segments.Add(new LineSegment()
            {
                Point = point[0]
            });
            figures.StartPoint = point[0];

            Windows.UI.Xaml.Shapes.Path path_figure = new Path()
            {
                Data = new PathGeometry()
                {
                    Figures = new PathFigureCollection()
                    {
                        figures
                    }
                },
                Stroke = new SolidColorBrush(Colors.Gray)
            };
            canvas.Children.Add(path_figure);
        }
    }
}
