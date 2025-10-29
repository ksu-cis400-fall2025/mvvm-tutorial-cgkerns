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

namespace MvvmExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Student willie = new Student("Willie", "Wildcat");
            willie.AddCourseRecord(new CourseRecord("CIS115", Grade.A, 3));
            willie.AddCourseRecord(new CourseRecord("MATH210", Grade.B, 4));
            willie.AddCourseRecord(new CourseRecord("CIS200", Grade.B, 4));
            willie.AddCourseRecord(new CourseRecord("MATH220", Grade.C, 4));
            DataContext = new ComputerScienceStudentViewModel(willie);
        }
    }
}
