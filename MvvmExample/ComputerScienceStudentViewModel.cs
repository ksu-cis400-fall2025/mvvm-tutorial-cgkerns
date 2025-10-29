using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmExample
{
    public class ComputerScienceStudentViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Notifies when a property changes
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// The student being represented 
        /// </summary>
        private Student _student;

        /// <summary>
        /// Student's first name
        /// </summary>
        public string FirstName => _student.FirstName;

        /// <summary>
        /// Student's last name
        /// </summary>
        public string LastName => _student.LastName;

        public IEnumerable<CourseRecord> CourseRecords => _student.CourseRecords;

        /// <summary>
        /// Student's GPA
        /// </summary>
        public double GPA => _student.GPA;

        public double ComputerScienceGPA
        {
            get
            {
                var points = 0.0;
                var hours = 0.0;
                foreach (var cr in _student.CourseRecords)
                {
                    if (cr.CourseName.Contains("CIS"))
                    {
                        points += (double)cr.Grade * cr.CreditHours;
                        hours += cr.CreditHours;
                    }
                }
                return points / hours;
            }
        }

        /// <summary>
        /// Event handler for handling pass-forward events from the studlent
        /// </summary>
        /// <param name="sender">The student that is changing</param>
        /// <param name="e">The Event Args</param>
        private void HandleStudentPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_student.GPA))
            {
                PropertyChanged?.Invoke(this, e);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ComputerScienceGPA)));
            }
        }

        /// <summary>
        /// Constructs the ComputerScienceStudentViewModel
        /// </summary>
        /// <param name="student">The student wrapped in this viewmodel</param>
        public ComputerScienceStudentViewModel(Student student)
        {
            _student = student;
            _student.PropertyChanged += HandleStudentPropertyChanged;
        }
    }
}
