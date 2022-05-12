using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ApplicationEntities dbcontext = new ApplicationEntities();


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                Employee emp = new Employee();
                emp.Name = txtName.Text;
                emp.Salary = Convert.ToInt32(txtSalary.Text);
                dbcontext.Employees.Add(emp);
                dbcontext.SaveChanges();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                Employee emp = dbcontext.Employees.Find(Convert.ToInt32(txtId.Text));
                if (emp != null)
                {
                    txtName.Text = emp.Name;
                    txtSalary.Text = emp.Salary.ToString();

                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                Employee emp = dbcontext.Employees.Find(Convert.ToInt32(txtId.Text));
                if (emp != null)
                {
                    emp.Name = txtName.Text;
                    emp.Salary = Convert.ToInt32(txtSalary.Text);
                    dbcontext.SaveChanges();
                    MessageBox.Show("Updated");

                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                Employee emp = dbcontext.Employees.Find(Convert.ToInt32(txtId.Text));
                if (emp != null)
                {
                    dbcontext.Employees.Remove(emp);
                    dbcontext.SaveChanges();
                    MessageBox.Show("Deleted");

                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dbcontext.Employees.ToList();
        }
    }
}

