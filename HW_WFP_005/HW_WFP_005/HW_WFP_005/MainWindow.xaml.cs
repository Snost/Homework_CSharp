using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HW_WFP_005
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentShape = "Rectangle";
        private Brush currentColor = Brushes.Black;
        private bool isDrawing = false;
        private Point startPoint;
        private Shape tempShape;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RectangleButton_Click(object sender, RoutedEventArgs e)
        {
            currentShape = "Rectangle";
        }

        private void EllipseButton_Click(object sender, RoutedEventArgs e)
        {
            currentShape = "Ellipse";
        }

        private void LineButton_Click(object sender, RoutedEventArgs e)
        {
            currentShape = "Line";
        }

        private void ColorButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                currentColor = button.Background;
            }
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDrawing = true;
            startPoint = e.GetPosition(DrawingCanvas);

            switch (currentShape)
            {
                case "Rectangle":
                    tempShape = new Rectangle
                    {
                        Stroke = currentColor,
                        StrokeThickness = 2
                    };
                    Canvas.SetLeft(tempShape, startPoint.X);
                    Canvas.SetTop(tempShape, startPoint.Y);
                    break;
                case "Ellipse":
                    tempShape = new Ellipse
                    {
                        Stroke = currentColor,
                        StrokeThickness = 2
                    };
                    Canvas.SetLeft(tempShape, startPoint.X);
                    Canvas.SetTop(tempShape, startPoint.Y);
                    break;
                case "Line":
                    tempShape = new Line
                    {
                        Stroke = currentColor,
                        StrokeThickness = 2,
                        X1 = startPoint.X,
                        Y1 = startPoint.Y
                    };
                    break;
            }

            if (tempShape != null)
            {
                DrawingCanvas.Children.Add(tempShape);
            }
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDrawing = false;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && tempShape != null)
            {
                Point currentPoint = e.GetPosition(DrawingCanvas);

                switch (currentShape)
                {
                    case "Rectangle":
                        var r = (Rectangle)tempShape;
                        double rWidth = Math.Abs(currentPoint.X - startPoint.X);
                        double rHeight = Math.Abs(currentPoint.Y - startPoint.Y);
                        r.Width = rWidth;
                        r.Height = rHeight;
                        Canvas.SetLeft(r, Math.Min(currentPoint.X, startPoint.X));
                        Canvas.SetTop(r, Math.Min(currentPoint.Y, startPoint.Y));
                        break;

                    case "Ellipse":
                        var ell = (Ellipse)tempShape;
                        double eWidth = Math.Abs(currentPoint.X - startPoint.X);
                        double eHeight = Math.Abs(currentPoint.Y - startPoint.Y);
                        ell.Width = eWidth;
                        ell.Height = eHeight;
                        Canvas.SetLeft(ell, Math.Min(currentPoint.X, startPoint.X));
                        Canvas.SetTop(ell, Math.Min(currentPoint.Y, startPoint.Y));
                        break;

                    case "Line":
                        var line = (Line)tempShape;
                        line.X2 = currentPoint.X;
                        line.Y2 = currentPoint.Y;
                        break;
                }
            }
        }
    }
}