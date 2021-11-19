using EmployeeMgr.Domain;
using EmployeeMgr.Repository;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SqlSugarTest {
    public partial class EmpListForm : Form {
        private EmployeeRepository empRepo;

        public EmpListForm() {
            InitializeComponent();
            empRepo = new EmployeeRepository();
        }

        private void EmpListForm_Load(object sender, EventArgs e) {
            this.Text = "Employee Master";

            // Get employee list 
            List<Employee> emps = empRepo.ListAll();

            // Data binding
            bindingSource1.DataSource = emps;
            dataGridView1.DataSource = bindingSource1;
            bindingNavigator1.BindingSource = bindingSource1;
        }       

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e) {
            // Execute deletion
            if (bindingSource1.Current == null) return;


            if (MessageBox.Show("确定删除此笔记录吗?", "删除确认",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {

                int empid = (bindingSource1.Current as Employee).EMP_ID;
                int count = empRepo.Delete(empid);
                if (count > 0) {
                    bindingSource1.RemoveCurrent(); // 从数据库删除后保持界面同步
                }
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            // Open sinle form
            var singleForm = new EmpSingleForm(this.bindingSource1, 2);
            singleForm.Show();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e) {
            bindingSource1.AddNew();
            var singleForm = new EmpSingleForm(this.bindingSource1, 1);
            singleForm.Show();
        }
    }
}
