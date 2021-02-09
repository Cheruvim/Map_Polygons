using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using TestJson;
using Newtonsoft.Json;

namespace Maps_Area
{
    

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            // Настройки для компонента GMap
            gmap.Bearing = 0;
            // Перетаскивание правой кнопки мыши
            gmap.CanDragMap = true;
            // Перетаскивание карты левой кнопкой мыши
            gmap.DragButton = MouseButtons.Left;

            gmap.GrayScaleMode = true;

            // Все маркеры будут показаны
            gmap.MarkersEnabled = true;
            // Максимальное приближение
            gmap.MaxZoom = 18;
            // Минимальное приближение
            gmap.MinZoom = 2;
            // Курсор мыши в центр карты
            gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;

            // Отключение нигативного режима
            gmap.NegativeMode = false;
            // Разрешение полигонов
            gmap.PolygonsEnabled = true;
            // Разрешение маршрутов
            gmap.RoutesEnabled = true;
            // Скрытие внешней сетки карты
            gmap.ShowTileGridLines = false;
            // При загрузке 10-кратное увеличение
            gmap.Zoom = 10;

            // Изменение размеров
            // gmap.Dock = DockStyle.Fill;

            // Чья карта используется
            gmap.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;

            // Загрузка этой точки на карте
            
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.Position = new GMap.NET.PointLatLng(47.2226466, 38.8391624);

            // Создаём новый список маркеров
            GMapOverlay markersOverlay = new GMapOverlay("markers");

            // Инициализация красного маркера с указанием его коордиант
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(47.219538, 38.919806), GMarkerGoogleType.red);
            marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);

            // Текст отображаемый с маркером
            marker.ToolTipText = "Software Technologies";
            // Добавляем маркер в список маркеров
            markersOverlay.Markers.Add(marker);
            gmap.Overlays.Add(markersOverlay);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Инициализируем новую переменную класса SaveFileDialog,
                //открывающий диалоговое окно для сохранения файла. 
                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    //Задаем текущую строку фильтра имен файлов,
                    //которая определяет варианты, доступные в поле 
                    //"Сохранить как тип файла" или "Файлы типа"
                    //диалогового окна.                    
                    dialog.Filter = "PNG (*.png)|*.png";

                    //Задаем строку, содержащую имя файла,
                    //выбранное в диалоговом  окне файла.
                    dialog.FileName = "GMap.NET image";

                    //Создаем новое изображение и
                    //передаем компонент с картой.
                    Image image = this.gmap.ToImage();

                    if (image != null)
                    {
                        using (image)
                        {
                            //Запускаем общее диалоговое окно с
                            //заданным по умолчанию владельцем.                          
                            //Данное окно возвращает объект
                            //System.Windows.Forms.DialogResult.OK,
                            //если пользователь нажимает кнопку
                            //ОК в диалоговом окне; в противном случае 
                            //— объект System.Windows.Forms.DialogResult.Cancel.
                            //Если пользователь нажал ОК, то идем дальше.
                            if (dialog.ShowDialog() == DialogResult.OK)
                            {
                                //Заносим в переменную имя файла введенное 
                                //в диалоговом окне.
                                string fileName = dialog.FileName;

                                //Выполняем проверку:
                                //был ли задан формат изображения карты,
                                //если нет, то добавляем после имени
                                //расширение файла.
                                if (!fileName.EndsWith(".png",
                                    StringComparison.OrdinalIgnoreCase))
                                {
                                    fileName += ".png";
                                }
                                //Выполняем сохранение изображения карты.
                                image.Save(fileName);

                                //Выводим сообщение об успешном сохранении 
                                //и пути к данному изображению карты.
                                MessageBox.Show("Карта успешно сохранена в директории: "
                                    + Environment.NewLine
                                    + dialog.FileName, "GMap.NET",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Asterisk);
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                //Если на одном из этапов сохранения произошла ошибка 
                MessageBox.Show("Ошибка при сохранении карты: "
                    + Environment.NewLine
                    + exception.Message,
                    "GMap.NET",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
            }
        }

        private void Area_Click(object sender, EventArgs e)
        {
            GMapOverlay polyOverlay = new GMapOverlay("Мак");





            




            List<PointLatLng> points = new List<PointLatLng>();
            CPoint point1 = new CPoint(47.219538, 38.919806);
            CPoint point2 = new CPoint(47.219350, 38.919666);
            CPoint point3 = new CPoint(47.219283, 38.919865);
            CPoint point4 = new CPoint(47.219473, 38.920003);

            points.Add(new PointLatLng(point1.x, point1.y)); // левый вверх
            points.Add(new PointLatLng(point2.x, point2.y)); // левый низ
            points.Add(new PointLatLng(point3.x, point3.y)); // правый низ
            points.Add(new PointLatLng(point4.x, point4.y)); // правый вверх

            GMapPolygon polygon = new GMapPolygon(points, "МакДональдс");
            polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
            polygon.Stroke = new Pen(Color.Red, 1);
            polyOverlay.Polygons.Add(polygon);
            gmap.Overlays.Add(polyOverlay);
        }
    }
    
}