using System.Data;
using Week_9_PracExer.Repositories;

namespace Week_9_PracExer
{
    public partial class frmStudent : Form
    {
        public frmStudent()
        {
            InitializeComponent();
            ReadStudents();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void ReadStudents()
        {
            DataTable datatable = new DataTable();

            datatable.Columns.Add("Student ID");
            datatable.Columns.Add("First Name");
            datatable.Columns.Add("Last Name");
            datatable.Columns.Add("Address");
            datatable.Columns.Add("Phone");

            var repo = new StudentRepository();
            var students = repo.ReadStudents();

            foreach (var student in students)
            {
                var row = datatable.NewRow();

                row["Student ID"] = student.id;
                row["First Name"] = student.first_name;
                row["Last Name"] = student.last_name;
                row["Address"] = student.address;
                row["Phone"] = student.phone;

                datatable.Rows.Add(row);
            }

            this.dgvStudent.DataSource = datatable;
        }

        private void bttnAdd_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            if (form2.ShowDialog() == DialogResult.Cancel) return;

            ReadStudents();
        }
    }
}
