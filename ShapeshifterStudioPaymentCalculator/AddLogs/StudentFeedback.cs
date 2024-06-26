﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ShapeshifterStudioPaymentCalculator
{
    public partial class Feedback : Form
    {
        public Feedback()
        {
            InitializeComponent();
            InstructorNamecomboBox.DataSource = Program.instructors;
            InstructorNamecomboBox.DisplayMember = "Name";
            InstructorNamecomboBox.ValueMember = "DCID";
            //InstructorNamecomboBox.Refresh();
        }

        private void BkFromStdntFdbk_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void SubmitFeedBk_Click(object sender, EventArgs e)
        {
            string StudentName = StudentNameTxtBox.Text;
            string StudentFeedback = StudentFeedBkRTxtBox.Text;
            DateTime FeedbackDate = FeedBkCalendar.SelectionStart;
            string StudentPoints = StudentPointModifier.Text;
            Instructor selectedInstructor = (Instructor) InstructorNamecomboBox.SelectedItem;
            string StudentDiscord = StudentDCIDTxtBox.Text;

            string Pointsfile = "PointsLog.txt";
            string Studentsfile = "Students.txt";
            string formattedDate = FeedbackDate.ToString("MM/dd/yyyy");

            Logbook logbook = new Logbook(Pointsfile);
            string instructorName = selectedInstructor.DCID;

            Program.students.Add(new Student(StudentName, StudentDiscord));

            logbook.Log(Pointsfile, $"{formattedDate}, {instructorName}, {StudentDiscord}, {StudentPoints}, {StudentFeedback}");
            logbook.Log(Studentsfile, $"{formattedDate}, {StudentDiscord}, {StudentFeedback}");
            //InstructorNamecomboBox.Refresh();
            //Interacts with the Pointslog text file, feedback goes on the back ofeach string
        }
    }
}
