using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.MapProviders;
using GMap.NET;
using System.Data.SqlClient;
using System.Data;
using GMap.NET.WindowsForms;
using static LogisticaMapsWinforms.GmapHelperClass;

namespace LogisticaMapsWinforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        private int index=0;
        private DataTable T;
        private void Form1_Load(object sender, EventArgs e)
        {
            mapa.DragButton = MouseButtons.Left;
            mapa.CanDragMap = true;
            mapa.MapProvider = GMapProviders.GoogleMap;
            mapa.Position = new PointLatLng(39.308744, -0.4195172);
            mapa.MinZoom = 0;
            mapa.MaxZoom = 24;
            mapa.Zoom = 15;
            mapa.AutoScroll = true;
            mapa.MarkersEnabled = true;



            mapa.Overlays.Clear();
            GMapOverlay routes = new GMapOverlay("routes");
            GMapOverlay circles = new GMapOverlay("polygons");
            List<PointLatLng> points = new List<PointLatLng>();
            using (var _points = new SqlDataAdapter($"Select Latitude, Longitude, Accuracy from detReadingSessionLocations where Session='{Values.Session}' order by LocationReadingNumber", Values.Conn))
            {
                PointLatLng? punto1 = null;
                PointLatLng? punto2 = null;
                T = new DataTable();
                _points.Fill(T);
                foreach (DataRow point in T.Rows)
                {
                    if (punto1 != null)
                        punto2 = punto1;
                    punto1 = new PointLatLng(Convert.ToDouble(point["Latitude"]), Convert.ToDouble(point["Longitude"]));

                    if (punto2 != null)
                    {
                        var distance = punto1.DistanceTo(punto2) * 1000;
                        double accuracy = Convert.ToDouble(point["Accuracy"]);
                        if (distance > accuracy)
                        {
                            points.Add(punto1 ?? new PointLatLng());
                        }
                    }
                    else
                        points.Add(punto1 ?? new PointLatLng());
                }
                GMapRoute route = new GMapRoute(points, "Trayectoria de prueba");
                route.Stroke = new Pen(Color.Red, 3);
                routes.Routes.Add(route);
                mapa.Overlays.Add(routes);
                mapa.Refresh();
                mapa.ReloadMap();

            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (index<T.Rows.Count)
            {
                if (index > 0)
                    mapa.Overlays.RemoveAt(0);
                lblIndex.Text = index.ToString();
                var point = T.Rows[index];
                var circle = new GMapOverlay(index.ToString());
                circle.Polygons.Add(CreateCircle(Convert.ToDouble(point["Latitude"]), Convert.ToDouble(point["Longitude"]), Convert.ToDouble(point["Accuracy"])));
                mapa.Overlays.Add(circle);
                mapa.Refresh();
                mapa.ReloadMap();
                mapa.Zoom += 1;
                mapa.Zoom -= 1;
                index++;
            }
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (index >=0)
            {
                lblIndex.Text = index.ToString();
                var point = T.Rows[index];
                var circle = new GMapOverlay();
                circle.Polygons.Add(CreateCircle(Convert.ToDouble(point["Latitude"]), Convert.ToDouble(point["Longitude"]), Convert.ToDouble(point["Accuracy"])));
                mapa.Overlays.Add(circle);
                mapa.Refresh();
                mapa.ReloadMap();
                mapa.Zoom += 1;
                mapa.Zoom -= 1;
                index--;
            }
            

        }
    }
}
