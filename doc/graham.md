# win10 uwp ���η�


��ʵ����˵Path����Ϊ�������һ���򵥵ķ��Ρ�

�㷨�漰����һ��ƽ�漸�ε�֪ʶ������������p1p2p3�����������������ʽ�Ķ���֮һ�� 
$$
\begin{array}{cccc} 
| x1 & y1 & 1 & | \\
| x2 & y2 & 1 & | &=\\
| x3 & y3 & 1 & | \\
\end{array}
$$


 $$x1*y2+x3*y1+x2*y3-x3*y2-x2*y1-x1*y3  = x1*y2-x2*y1+x3*(y1-y2)+y3*(x2-x1)$$
 
���ҵ���P3 ������P1P2������ʱ�򣬱��ʽΪ�����Ҳ���ʽΪ��������ͬ�ߵĻ����ʽΪ0���㷨�о����øü��������ж�һ������һ���ߵ���໹���Ҳࡣ

�μ���http://www.cnblogs.com/Booble/archive/2011/03/10/1980089.html

��������һ����̨���������кܶ�㣬�͵õ��ߣ�������δ��õ���`List<Point> point`���������õ��ıߵĵ㻭��

��ʵ���ǿ����ü򵥵�Path����δ�Path����

���ǿ���ʹ��EllipseGeometry

EllipseGeometry��Geometry������Geometry��һῴ��Path��Data���ǵģ����ǿ���ʹ��

```
                Windows.UI.Xaml.Shapes.Path path = new Windows.UI.Xaml.Shapes.Path
                {
                    Data = new EllipseGeometry()
                };
```

Ϊʲô�����һ�ʹ��EllipseGeometry����Ϊ�Ҿ���Ҫһ������Ϊ���ģ�X�Ĵ�С��Y�ģ�Ȼ����ǵ�

```
                Windows.UI.Xaml.Shapes.Path path = new Windows.UI.Xaml.Shapes.Path
                {
                    Data = new EllipseGeometry()
                    {
                        Center = point,
                        RadiusX = 5,
                        RadiusY = 5
                    }
                };
```

��ô������Ҫ������ɫ

�Ͼ䲻ҪŪ���Ǹ� �� ����ɫ

ʵ�ģ�Fill = new SolidColorBrush(Colors.Gray)����Ϊ���ǿ���ʹ�ü�Colors�������ҪRBG����ô����ʹ��

```
                    Fill = new SolidColorBrush(new Color()
                    {
                        R = 0,
                        B = 0,
                        G = 0
                    })
```

Ȼ���������û��ǲ��ã����Ǳ�������ʮ����

```
                    Fill = new SolidColorBrush(new Color()
                    {
                        R = 0x23,
                        B = 0x54,
                        G = 0xa
                    })
```

���ͣ�blog.csdn.net/lindexi_gd

��������������ࣺ

```
Fill = new SolidColorBrush(Color.FromArgb(0xff,0xff,0xa,0x2))
```

�����������Ǻö࣬����������wrû�и�����stringתColor�����ٸ���΢����Դ����԰�stringתΪColor��Ϊ�򵥣��Ҿ�û��д��������Ҫ�����˺ܾã������Ҫ���Խ��� 53078485

���������Ѿ�Ū�û��㣬���ǿ���û��

```
Stroke = new SolidColorBrush(Colors.Gray)
```

�������ǾͿ��Ի����ĺ�ʵ��

��֮ǰ�Ĵ�����Ϊ���Ǻ�̨

![����дͼƬ����](http://img.blog.csdn.net/20160523191436593)

������Ҫ����

����

```
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
```


�����������̫���ˣ����ǿ���Ū����

```
            PathGeometry path_figure = new PathGeometry();
            for (int i = 0; i < point.Count; i++)
            {
                PathFigure path_segment = new PathFigure()
                {
                    StartPoint = point[i]
                };
                i++;
                LineSegment line = new LineSegment()
                {
                    Point = point[i]
                };
                path_segment.Segments.Add(line);
                path_figure.Figures.Add(path_segment);
            }
```

PathFigure��һ����`StartPoint = point[i]`��LineSegment�ڶ�����`path_segment.Segments.Add(line);`����`path_segment`�����������涨��`path_figure`

�����ȵ�һ�������`path_segment`����������������ԣ����������ڲ���ȥ��

���룺https://github.com/lindexi/Algorithm

������������

![����дͼƬ����](http://img.blog.csdn.net/20160523191446249)