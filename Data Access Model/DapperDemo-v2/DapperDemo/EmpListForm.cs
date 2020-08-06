using System;
using System.Windows.Forms;

namespace DapperDemo
{
    public partial class EmpListForm : Form
    {
        public EmpListForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // list all employees
            var empService = new EmpService();
            var employees = empService.ListAll();

            bindingSource1.DataSource = employees;
            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Open EmpSingleForm            
            var singleForm = new EmpSingleForm(bindingSource1);
            singleForm.ShowDialog();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            bindingSource1.AddNew();
            var SingleForm = new EmpSingleForm(bindingSource1, true);
            SingleForm.ShowDialog();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Current == null) return;

            var result = MessageBox.Show("确定删除此笔记录吗?",
                                         "删除确认",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes) {
                var emp = bindingSource1.Current as Employee;
                var empService = new EmpService();
                int count = empService.Delete(emp.Emp_Id);

                if (count > 0) {
                    bindingSource1.RemoveCurrent();
                }
            }
        }
    }
}
