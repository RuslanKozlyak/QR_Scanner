using O2S.Components.PDFRender4NET;
using System;
using System.Drawing;
using System.Windows.Forms;
using ZXing;

namespace QR_Scanner
{
    public partial class Form1 : Form
    {
        private IBarcodeReader barcodeReader = new BarcodeReader();

        private Point selectionAreaStartPoint;
        private Rectangle selectionArea = new Rectangle();

        private Brush selectionBrush = new SolidBrush(Color.FromArgb(128, 72, 145, 220));

        private double hRatio = 0;
        private double wRatio = 0;

        private Bitmap pageImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            resultTextBox.Clear();
            CroppedPicBox.Image = null;

            if (OpenFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = OpenFileDialog.FileName;

            //Открываем полученный PDF файл
            PDFFile pdfFile = PDFFile.Open(filename);
            //Преобразуем его в изображение (Bitmap)
            pageImage = pdfFile.GetPageImage(0, 300);
            PDFPicBox.Image = pageImage;
            //Рассчитываем разность в координатах между пикчербоксом и
            //оригинальным изображением, чтобы можно было преобразовать
            //координаты для отрисовки вырезанного изображения.
            //Это возникает из за установленного поля SizeMode = StretchImage
            hRatio = (double)pageImage.Height / PDFPicBox.Height;
            wRatio = (double)pageImage.Width / PDFPicBox.Width;
        }

        private void PDFPicBox_MouseDown(object sender, MouseEventArgs e)
        {
            //Задаем начальную точку области выделения для вырезки ищоражения
            selectionAreaStartPoint = e.Location;
        }

        private void PDFPicBox_MouseMove(object sender, MouseEventArgs e)
        {
            //Пока не отжата левая кнопака перерисовываем область выделения
            if (e.Button != MouseButtons.Left)
                return;
            Point tempEndPoint = e.Location;
            selectionArea.Location = new Point(
                Math.Min(selectionAreaStartPoint.X, tempEndPoint.X),
                Math.Min(selectionAreaStartPoint.Y, tempEndPoint.Y));
            selectionArea.Size = new Size(
                Math.Abs(selectionAreaStartPoint.X - tempEndPoint.X),
                Math.Abs(selectionAreaStartPoint.Y - tempEndPoint.Y));
            PDFPicBox.Invalidate();
        }

        private void PDFPicBox_Paint(object sender, PaintEventArgs e)
        {
            //Иент возникающий при каждом движении мышкой по пикчербоксу из за вызова
            //метода PDFPicBox.Invalidate(), который заставляет пикчер бок перерисовываться
            try
            {
                if (PDFPicBox.Image != null)
                {
                    if (selectionArea.Width > 0 && selectionArea.Height > 0)
                    {
                        e.Graphics.FillRectangle(selectionBrush, selectionArea);

                        //Пересчитываем в пропорциях координаты для вырезки изображения
                        selectionArea.X = (int)(selectionArea.X * wRatio);
                        selectionArea.Y = (int)(selectionArea.Y * hRatio);
                        selectionArea.Width = (int)(selectionArea.Width * wRatio);
                        selectionArea.Height = (int)(selectionArea.Height * hRatio);

                        var img = (Bitmap)PDFPicBox.Image;
                        //С помощью метода Clone можно удобно вырезать изображение
                        //перекопировав только прямоугольную его часть из SelectionArea
                        var crop = img.Clone(selectionArea, img.PixelFormat);
                        CroppedPicBox.Image = crop;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Не выходите за границы!");
            }

        }

        private void DecodeButton_Click(object sender, EventArgs e)
        {
            //Декодируем QR код, который содержится в CroppedPicBox
            if (CroppedPicBox.Image != null)
            {
                //Получаем Bitmap изображения из CroppedPicBox
                var QR = (Bitmap)CroppedPicBox.Image;
                //Используем метод для декодирования QR кода из библиотеки Zxing
                var result = barcodeReader.Decode(QR);
                if (result != null)
                    resultTextBox.Text = result.Text;
                else
                    resultTextBox.Text = "Неудается распознать QR код!";
            }
            else
                MessageBox.Show("Сначала выделите QR код или откройте PDF файл!");

        }

        private void AutoScanButton_Click(object sender, EventArgs e)
        {
            //Второй вариант получения QR кода
            //Работает только для данного тестового документа, 
            //так как только здесь мы знаем где находится QR код
            if (pageImage != null)
            {
                var rect = new Rectangle(new Point(100, 100), new Size(300, 300));
                var QR = pageImage.Clone(rect, pageImage.PixelFormat);
                CroppedPicBox.Image = QR;
                var result = barcodeReader.Decode(QR);
                if (result != null)
                    resultTextBox.Text = result.Text;
                else
                    resultTextBox.Text = "Неудается распознать QR код!";
            }
            else
                MessageBox.Show("Сначала откройте PDF файл!");

        }
    }
}
