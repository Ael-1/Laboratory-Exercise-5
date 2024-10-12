using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Week_9_PracExer.Models;
using Week_9_PracExer.Repositories;

namespace Week_9_PracExer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            Student student = new Student();

            student.id = 0;
            student.first_name = txtFirstName.Text;
            student.last_name = txtLastName.Text;
            student.address = txtAddress.Text;
            student.phone = txtPhone.Text;

            var repo = new StudentRepository();
            repo.createStudent(student);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
