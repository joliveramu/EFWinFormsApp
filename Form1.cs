using EFWinFormsApp.Data;
using EFWinFormsApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFWinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        EFWinFormsAppContext context = new EFWinFormsAppContext();
        private void Form1_Load(object sender, EventArgs e)
        {

            loadData();
        }

        public void loadData()
        {
            try
            {
                dgvData.DataSource = context.Students.ToList();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                context.Students.Add(new Student()
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text
                });
                context.SaveChanges();
                txtFirstName.Clear();
                txtLastName.Clear();
                MessageBox.Show("Added");
                loadData();
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
                Student student = context.Students.Find(int.Parse(txtID.Text));
                student.FirstName = txtFirstName.Text;
                student.LastName = txtLastName.Text;
                context.Entry(student).State = EntityState.Modified;
                context.SaveChanges();
                MessageBox.Show($"Student {txtFirstName.Text} is updated!");
                txtFirstName.Clear();
                txtLastName.Clear();
                txtID.Clear();
                loadData();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Student student = context.Students.Find(int.Parse(txtID.Text));
                context.Students.Remove(student);
                context.SaveChanges();
                MessageBox.Show($"Student ID # {txtID.Text} is removed");
                txtID.Clear();
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
