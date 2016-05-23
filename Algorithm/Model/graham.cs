using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Media.Playback;
using Windows.UI.Xaml.Shapes;

namespace Algorithm.Model
{
    public class graham
    {
        /// <summary>
        /// 分治法 快包
        /// </summary>
        /// <param name="point">所有点</param>
        /// <returns>围住</returns>
        public List<Point> divide_conquer(List<Point> point)
        {
            Point p0 = hul_long(point);//最左边点
            Point pn = hup_long(point);//最右边的点
            point.Remove(p0);
            point.Remove(pn);

            List<Point> round_point=new List<Point>()
            {
                p0,
                pn
            };

            line _line = new line()
            {
                x = p0,
                y = pn
            };
            divide_conquer(point, round_point, _line);
            _line = new line()
            {
                x = pn,
                y = p0
            };
            divide_conquer(point, round_point, _line);

            round_point = divide_conquer(round_point, true);
            return round_point;
        }

        public List<Point> divide_conquer(List<Point> point,bool _point)
        {
            if (!_point)
            {
                return point;
            }
            List<Point> temp=new List<Point>();
            Point p = point[0];
            temp.Add(p);
            double n = double.MaxValue;
            double t;

            point.RemoveAt(0);
            while (point.Count>0)
            {
                for (int i = 0; i < point.Count; i++)
                {
                    t = pointline(temp.Last(), point[i]);
                    if (t < n)
                    {
                        p = point[i];
                        n = t;
                    }
                }
                temp.Add(p);
                n = double.MaxValue;
                point.Remove(p);
            }
            return temp;
        }

        /// <summary>
        /// 最左边点
        /// 如果点连通，最下的点
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private static Point hul_long(IEnumerable<Point> point)
        {
            Point p0;
            p0.X = -1;
            foreach (Point temp in point.Where(temp => p0.X < 0 || p0.X > temp.X || (p0.Y > temp.Y && p0.X == temp.X)))
            {
                p0 = temp;
            }
            return p0;
        }
        /// <summary>
        /// 最右边的点
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private static Point hup_long(IEnumerable<Point> point)
        {
            Point pn;
            pn.X = -1;
            pn.Y = -1;
            foreach (Point temp in point.Where(temp => pn.X < 0 || pn.X < temp.X || (pn.Y < temp.Y && Math.Abs(pn.X - temp.X) < 0.000001)))
            {
                pn = temp;
            }
            return pn;
        }

        private static void divide_conquer(IList<Point> point, ICollection<Point> hup, line _line)
        {
            if (point.Count < 1)
            {
                return;
            }
            Point[] temp=new Point[point.Count];
            point.CopyTo(temp, 0);
            point = temp.ToList();

            Point p;
            p.X = -1;
            p = divide_conquer(point, _line, p);

            if (p.X < 0)
            {
                return;
            }

            hup.Add(p);
            line dy = new line()
            {
                x = _line.x,
                y = p
            };
            divide_conquer(point, hup, dy);
            dy = new line()
            {
                x = p,
                y = _line.y
            };
            divide_conquer(point, hup, dy);
        }

        private static Point divide_conquer(IList<Point> point, line t, Point p)
        {
            t.n = 0;

            for (int i = 0; i < point.Count; i++)
            {
                double n = pointline(t, point[i]);
                if (n > 0)
                {
                    if (p.X < 0 || t.n < n)
                    {
                        p = point[i];
                        t.n = n;
                    }
                }
                else
                {
                    point.RemoveAt(i);
                    i--;
                }
            }

            return p;
        }

        /// <summary>
        /// 点到直线
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private static double pointline(line t, Point p)
        {
            return t.x.X * t.y.Y + p.X * t.x.Y + t.y.X * p.Y - p.X * t.y.Y - t.y.X * t.x.Y - t.x.X * p.Y;
        }

        private static double pointline(Point t, Point p)
        {
            return Math.Sqrt(Math.Pow(t.X - p.X, 2) + Math.Pow(t.Y - p.Y, 2));
        }

        public List<Point> brute_conquer(List<Point> point)
        {
            //记录极点对
            List<Point> role = new List<Point>();

            //遍历
            for (int i = 0; i < point.Count - 1; i++)
            {
                for (int j = i + 1; j < point.Count; j++)
                {
                    double a = point[j].Y - point[i].Y;
                    double b = point[i].X - point[j].X;
                    double c = point[i].X * point[j].Y - point[i].Y * point[j].X;

                    int count = 0;
                    //将所有点代入方程
                    for (int k = 0; k < point.Count; k++)
                    {
                        double result = a * point[k].X + b * point[k].Y - c;
                        if (result > 0)
                        {
                            count++;
                        }
                        else if (result < 0)
                        {
                            count--;
                        }
                    }
                    //是极点，则将连线记录下来
                    if (Math.Abs(count) == point.Count - 2)
                    {
                        role.Add(point[i]);
                        role.Add(point[j]);
                    }
                }
            }
            return role;
        } 

        public List<TuLine> brute(List<Point> _list)
        {
            //记录极点对
            List<TuLine> role = new List<TuLine>();

            //遍历
            for (int i = 0; i < _list.Count - 1; i++)
            {
                for (int j = i + 1; j < _list.Count; j++)
                {
                    double a = _list[j].Y - _list[i].Y;
                    double b = _list[i].X - _list[j].X;
                    double c = _list[i].X * _list[j].Y - _list[i].Y * _list[j].X;

                    int count = 0;
                    //将所有点代入方程
                    for (int k = 0; k < _list.Count; k++)
                    {
                        double result = a * _list[k].X + b * _list[k].Y - c;
                        if (result > 0)
                        {
                            count++;
                        }
                        else if (result < 0)
                        {
                            count--;
                        }
                    }
                    //是极点，则将连线记录下来
                    if (Math.Abs(count) == _list.Count - 2)
                    {
                        TuLine line = new TuLine();
                        line.Begin = _list[i];
                        line.End = _list[j];
                        role.Add(line);
                    }
                }

            }
            return role;
        }
    }

    public class TuLine
    {
        public Point Begin
        {
            set;
            get;
        }
        public Point End
        {
            set;
            get;
        }
    }



    internal class hull
    {
        public hull()
        {

            //snhul("301123006277", 4);
            //sp();
        }

        public void onq()
        {
            int i;
            print("请选择实验");
            string temp = read();
            i = int.Parse(temp);

            if (i == 1)
            {
                sp();
            }
            else if (i == 2)
            {
                num();
            }
        }

        private void sp()
        {
            Random ran = new Random();
            int n = 100;
            List<Point> q = new List<Point>();
            for (int i = 0; i < n; i++)
            {
                q.Add(new Point()
                {
                    X = ran.Next(1000),
                    Y = ran.Next(1000)
                });
            }
            sq(q);
        }

        private void sq(List<Point> q)
        {
            Point p0 = hul(q);
            q.Remove(p0);
            Point pn = hpn(q);
            q.Remove(pn);


            List<Point> hup = new List<Point>()
            {
                p0,
                pn
            };
            line t = new line()
            {
                x = p0,
                y = pn
            };
            line dy = new line()
            {
                x = pn,
                y = p0
            };

            sq(q, hup, t);
            sq(q, hup, dy);

            print(hup);
        }

        private void print(List<Point> q)
        {
            StringBuilder str = new StringBuilder();
            foreach (Point temp in q)
            {
                str.Append(temp.X + " " + temp.Y + "\n");
            }
            print(str.ToString());
        }

        private void sq(List<Point> q, List<Point> hup, line t)
        {
            if (q.Count < 1)
            {
                return;
            }
            Point p;
            p.X = -1;
            t.n = 0;

            for (int i = 0; i < q.Count; i++)
            {
                double n = sq(t, q[i]);
                if (n > 0)
                {
                    if (p == null || t.n < n)
                    {
                        p = q[i];
                        t.n = n;
                    }
                }
                else
                {
                    q.RemoveAt(i);
                    i--;
                }
            }

            if (p.X<0)
            {
                return;
            }

            hup.Add(p);
            line dy = new line()
            {
                x = t.x,
                y = p
            };
            sq(q, hup, dy);
            dy = new line()
            {
                x = p,
                y = t.y
            };
            sq(q, hup, dy);
        }
        private double sq(line t, Point p)
        {
            return t.x.X * t.y.Y + p.X * t.x.Y + t.y.X * p.Y - p.X * t.y.Y - t.y.X * t.x.Y - t.x.X * p.Y;
        }

        private Point hpn(List<Point> q)
        {
            Point pn;
            pn.X = -1;
            pn.Y = -1;
            foreach (Point temp in q)
            {
                if (pn.X < 0 || pn.X > temp.X || (pn.Y > temp.Y && pn.X == temp.X))
                {
                    pn = temp;
                }
            }
            return pn;
        }
        private Point hul(List<Point> q)
        {
            Point p0 ;
            p0.X = -1;
            foreach (Point temp in q)
            {
                if (p0.X<0 || p0.X > temp.X || (p0.Y > temp.Y && p0.X == temp.X))
                {
                    p0 = temp;
                }
            }
            return p0;
        }

        private void num()
        {
            string str = "请输入一段数字";
            print(str);
            str = read();
            print("请输入删除数字");
            int s = int.Parse(read());
            snhul(str, s);
        }

        private void snhul(string str, int s)
        {
            str = sort(str, ref s);
            if (s == 0)
            {
                print(str);
                read();
                return;
            }

            List<int> n = new List<int>();


            foreach (var temp in str)
            {
                n.Add(temp - '0');
            }

            foreach (int temp in sort(n, s))
            {
                for (int i = 0; i < n.Count; i++)
                {
                    if (n[i] == temp)
                    {
                        n.RemoveAt(i);
                        break;
                    }
                }
            }

            print(n);
            read();
        }
        private string sort(string str, ref int s)
        {
            for (int i = s; i >= 0; i--)
            {
                if (str[i] == '0')
                {
                    s -= i;
                    return sort(str.Substring(i));
                }
            }
            return str;
        }
        private string sort(string str)
        {
            int i;
            for (i = 0; i < str.Length; i++)
            {
                if (str[i] != '0')
                {
                    break;
                }
            }
            return str.Substring(i);
        }
        private void print(List<int> n)
        {
            StringBuilder str = new StringBuilder();
            foreach (int temp in n)
            {
                str.Append(temp.ToString());
            }
            print(str.ToString());
        }

        private List<int> sort(List<int> n, int s)
        {
            List<int> a = n.ToList();
            a.Sort();
            a.RemoveRange(0, a.Count - 4);
            // n.Sort();
            //for (int i = 0; i < s && i<n.Count; i++)
            //{
            //    a.Add(n[i]);
            //}
            return a;
        }

        private string read()
        {
            return "";
        }

        private void print(string str)
        {
        }
    }

    internal class line
    {
        public Point x
        {
            set
            {
                _x = value;
            }
            get
            {
                return _x;
            }
        }
        public Point y
        {
            set
            {
                _y = value;
            }
            get
            {
                return _y;
            }
        }
        public double n
        {
            set;
            get;
        }
        private Point _x;
        private Point _y;

    }
    //internal class Point
    //{
    //    public double X
    //    {
    //        set
    //        {
    //            _x = value;
    //        }
    //        get
    //        {
    //            if (_x < 0)
    //            {
    //                _x = 0;
    //            }
    //            return _x;
    //        }
    //    }

    //    public double Y
    //    {
    //        set
    //        {
    //            _y = value;
    //        }
    //        get
    //        {
    //            if (_y < 0)
    //            {
    //                _y = 0;
    //            }
    //            return _y;
    //        }
    //    }
    //    private double _x;
    //    private double _y;
    //}
}
