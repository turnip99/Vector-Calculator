using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vector_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            EventManager.RegisterClassHandler(typeof(System.Windows.Controls.TextBox), System.Windows.Controls.TextBox.GotKeyboardFocusEvent, new KeyboardFocusChangedEventHandler(OnGotKeyboardFocus));
            InitializeComponent();
            Add.Click += Add_Click;
            Subtract.Click += Subtract_Click;
            Scale.Click += Scale_Click;
            Dot_Product.Click += Dot_Product_Click;
            Unit_Vector.Click += Unit_Vector_Click;
            Magnitude.Click += Magnitude_Click;
            Distance.Click += Distance_Click;
            Angle.Click += Angle_Click;
            Scalar_Proj.Click += Scalar_Proj_Click;
            Vector_Proj.Click += Vector_Proj_Click;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            bool valid = CheckIfDouble();
            if (!valid)
            {
                PostText("Error] Invalid input");
            }
            else
            {
                Vector v1 = new Vector(double.Parse(txt1x.Text), double.Parse(txt1y.Text), double.Parse(txt1z.Text));
                Vector v2 = new Vector(double.Parse(txt2x.Text), double.Parse(txt2y.Text), double.Parse(txt2z.Text));
                Vector v3 = new Vector((v1.x + v2.x), (v1.y + v2.y), (v1.z + v2.z));
                PostText("Addition] " + v1.ToString() + " + " + v2.ToString() + " = " + v3.ToString());
            }
        }

        private void Subtract_Click(object sender, RoutedEventArgs e)
        {
            bool valid = CheckIfDouble();
            if (!valid)
            {
                PostText("Error] Invalid input");
            }
            else
            {
                Vector v1 = new Vector(double.Parse(txt1x.Text), double.Parse(txt1y.Text), double.Parse(txt1z.Text));
                Vector v2 = new Vector(double.Parse(txt2x.Text), double.Parse(txt2y.Text), double.Parse(txt2z.Text));
                Vector v3 = new Vector((v1.x - v2.x), (v1.y - v2.y), (v1.z - v2.z));
                PostText("Subtraction] " + v1.ToString() + " - " + v2.ToString() + " = " + v3.ToString());
            }
        }

        private void Scale_Click(object sender, RoutedEventArgs e)
        {
            bool valid = CheckIfDouble();
            PopUp popup = new PopUp();
            popup.ShowDialog(); //execution will block here in this method until the popup closes
            string result = popup.username;
            double scalar;
            valid = double.TryParse(result, out scalar);
            if (!valid)
            {
                PostText("Error] Invalid input");
            }
            else
            {
                Vector v1 = new Vector(double.Parse(txt1x.Text), double.Parse(txt1y.Text), double.Parse(txt1z.Text));
                Vector v2 = new Vector(double.Parse(txt2x.Text), double.Parse(txt2y.Text), double.Parse(txt2z.Text));
                Vector v3 = new Vector((v1.x * scalar), (v1.y * scalar), (v1.z * scalar));
                Vector v4 = new Vector((v2.x * scalar), (v2.y * scalar), (v2.z * scalar));
                PostText("Scalar] " + scalar + " * " + v1.ToString() + " = " + v3.ToString());
                PostText("Scalar] " + scalar + " * " + v2.ToString() + " = " + v4.ToString());
            }
        }

        private void Dot_Product_Click(object sender, RoutedEventArgs e)
        {
            bool valid = CheckIfDouble();
            if (!valid)
            {
                PostText("Error] Invalid input");
            }
            else
            {
                Vector v1 = new Vector(double.Parse(txt1x.Text), double.Parse(txt1y.Text), double.Parse(txt1z.Text));
                Vector v2 = new Vector(double.Parse(txt2x.Text), double.Parse(txt2y.Text), double.Parse(txt2z.Text));
                double p = ((v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z));
                PostText("Dot Product] " + v1.ToString() + " . " + v2.ToString() + " = " + "(" + v1.x + " * " + v2.x + ") + " + "(" + v1.y + " * " + v2.y + ") + " + "(" + v1.z + " * " + v2.z + ") = " + p);
            }
        }

        private void Unit_Vector_Click(object sender, RoutedEventArgs e)
        {
            bool valid = CheckIfDouble();
            if (!valid)
            {
                PostText("Error] Invalid input");
            }
            else
            {
                Vector v1 = new Vector(double.Parse(txt1x.Text), double.Parse(txt1y.Text), double.Parse(txt1z.Text));
                Vector v2 = new Vector(double.Parse(txt2x.Text), double.Parse(txt2y.Text), double.Parse(txt2z.Text));
                double m1 = Math.Sqrt(Math.Pow(v1.x, 2) + Math.Pow(v1.y, 2) + Math.Pow(v1.z, 2));
                double m2 = Math.Sqrt(Math.Pow(v2.x, 2) + Math.Pow(v2.y, 2) + Math.Pow(v2.z, 2));
                Vector v3 = new Vector(Math.Round(v1.x / m1, 3), Math.Round(v1.y / m1, 3), Math.Round(v1.z / m1, 3));
                Vector v4 = new Vector(Math.Round(v2.x / m2, 3), Math.Round(v2.y / m2, 3), Math.Round(v2.z / m2, 3));
                PostText("Unit Vector] |v| = " + Math.Round(m1, 3) + "; u = (" + Math.Round(v1.x, 3) + "/" + Math.Round(m1, 3) + ", " + Math.Round(v1.y, 3) + "/" + Math.Round(m1, 3) + ", " + Math.Round(v1.z, 3) + "/" + Math.Round(m1, 3) + ") = " + v3.ToString());
                PostText("Unit Vector] |v| = " + Math.Round(m2, 3) + "; u = (" + Math.Round(v2.x, 3) + "/" + Math.Round(m2, 3) + ", " + Math.Round(v2.y, 3) + "/" + Math.Round(m2, 3) + ", " + Math.Round(v2.z, 3) + "/" + Math.Round(m2, 3) + ") = " + v4.ToString());
            }
        }

        private void Magnitude_Click(object sender, RoutedEventArgs e)
        {
            bool valid = CheckIfDouble();
            if (!valid)
            {
                PostText("Error] Invalid input");
            }
            else
            {
                Vector v1 = new Vector(double.Parse(txt1x.Text), double.Parse(txt1y.Text), double.Parse(txt1z.Text));
                Vector v2 = new Vector(double.Parse(txt2x.Text), double.Parse(txt2y.Text), double.Parse(txt2z.Text));
                double m1 = Math.Round(Math.Sqrt(Math.Pow(v1.x, 2) + Math.Pow(v1.y, 2) + Math.Pow(v1.z, 2)), 3);
                double m2 = Math.Round(Math.Sqrt(Math.Pow(v2.x, 2) + Math.Pow(v2.y, 2) + Math.Pow(v2.z, 2)), 3);
                PostText("Magnitude] √((" + v1.x + ")^2 + (" + v1.y + ")^2 + (" + v1.z + ")^2) = " + m1);
                PostText("Magnitude] √((" + v2.x + ")^2 + (" + v2.y + ")^2 + (" + v2.z + ")^2) = " + m2);
            }
        }

        private void Distance_Click(object sender, RoutedEventArgs e)
        {
            bool valid = CheckIfDouble();
            if (!valid)
            {
                PostText("Error] Invalid input");
            }
            else
            {
                Vector v1 = new Vector(double.Parse(txt1x.Text), double.Parse(txt1y.Text), double.Parse(txt1z.Text));
                Vector v2 = new Vector(double.Parse(txt2x.Text), double.Parse(txt2y.Text), double.Parse(txt2z.Text));
                Vector v3 = new Vector((v1.x - v2.x), (v1.y - v2.y), (v1.z - v2.z));
                double m = Math.Round(Math.Sqrt(Math.Pow(v3.x, 2) + Math.Pow(v3.y, 2) + Math.Pow(v3.z, 2)), 3);
                PostText("Distance] " + v1.ToString() + " - " + v2.ToString() + " = " + v3.ToString() + "; √((" + v3.x + ")^2 + (" + v3.y + ")^2 + (" + v3.z + ")^2) = " + m);
            }
        }

        private void Angle_Click(object sender, RoutedEventArgs e)
        {
            bool valid = CheckIfDouble();
            if (!valid)
            {
                PostText("Error] Invalid input");
            }
            else
            {
                Vector v1 = new Vector(double.Parse(txt1x.Text), double.Parse(txt1y.Text), double.Parse(txt1z.Text));
                Vector v2 = new Vector(double.Parse(txt2x.Text), double.Parse(txt2y.Text), double.Parse(txt2z.Text));
                double p = ((v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z));
                double m1 = Math.Sqrt(Math.Pow(v1.x, 2) + Math.Pow(v1.y, 2) + Math.Pow(v1.z, 2));
                double m2 = Math.Sqrt(Math.Pow(v2.x, 2) + Math.Pow(v2.y, 2) + Math.Pow(v2.z, 2));
                double r = Math.Round(p / (m1 * m2), 3);
                PostText("Angle] Cosϴ = (a.b)/(|a|*|b|) = (" + Math.Round(p, 3) + ")/(" + Math.Round(m1, 3) + "*" + Math.Round(m2, 3) + ") = " + r + "; ϴ = " + Math.Round(Math.Acos(r), 3) + "rad");
            }
        }

        private void Scalar_Proj_Click(object sender, RoutedEventArgs e)
        {
            bool valid = CheckIfDouble();
            if (!valid)
            {
                PostText("Error] Invalid input");
            }
            else
            {
                Vector v1 = new Vector(double.Parse(txt1x.Text), double.Parse(txt1y.Text), double.Parse(txt1z.Text));
                Vector v2 = new Vector(double.Parse(txt2x.Text), double.Parse(txt2y.Text), double.Parse(txt2z.Text));
                double p = ((v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z));
                double m = Math.Sqrt(Math.Pow(v1.x, 2) + Math.Pow(v1.y, 2) + Math.Pow(v1.z, 2));
                double r = Math.Round(p / m, 3);
                PostText("Scalar Projection] SProj(b->a) = (a.b)/|b| = (" + Math.Round(p, 3) + ")/(" + Math.Round(m, 3) + ") = " + r);
            }
        }

        private void Vector_Proj_Click(object sender, RoutedEventArgs e)
        {
            bool valid = CheckIfDouble();
            if (!valid)
            {
                PostText("Error] Invalid input");
            }
            else
            {
                Vector v1 = new Vector(double.Parse(txt1x.Text), double.Parse(txt1y.Text), double.Parse(txt1z.Text));
                Vector v2 = new Vector(double.Parse(txt2x.Text), double.Parse(txt2y.Text), double.Parse(txt2z.Text));
                double p = ((v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z));
                double m = Math.Round(Math.Sqrt(Math.Pow(v1.x, 2) + Math.Pow(v1.y, 2) + Math.Pow(v1.z, 2)), 3);
                double r = Math.Round(p / m, 3);
                Vector v3 = new Vector((v1.x * Math.Round((r/m),3)), (v1.y * Math.Round((r/m), 3)), (v1.z * Math.Round((r/m), 3)));
                PostText("Vector Projection] SProj(b->a) = " + Math.Round(r, 3) + "; VProj(b->a) = (" + Math.Round(r, 3) + "/" + Math.Round(m, 3) + ") * " + v1.ToString() + " = " + v3.ToString());
            }
        }


        private bool CheckIfDouble()
        {
            double temp;
            if (!double.TryParse(txt1x.Text, out temp) || !double.TryParse(txt1y.Text, out temp)
    || !double.TryParse(txt1z.Text, out temp) || !double.TryParse(txt2x.Text, out temp)
    || !double.TryParse(txt2y.Text, out temp) || !double.TryParse(txt2z.Text, out temp))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        void OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var textBox = sender as System.Windows.Controls.TextBox;

            if (textBox != null && !textBox.IsReadOnly && e.KeyboardDevice.IsKeyDown(Key.Tab))
                textBox.SelectAll();
        }

        private void PostText(string text)
        {
            txtMain.Text += "[" + DateTime.Now.ToString("h:mm:ss") + "; " + text + "\n";
            svMain.ScrollToBottom();
        }
    }
}
