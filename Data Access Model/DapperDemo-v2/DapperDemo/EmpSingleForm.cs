using System;
using System.Windows.Forms;

namespace DapperDemo
{
    public partial class EmpSingleForm : Form
    {
        private bool isAddNew;

        public EmpSingleForm()
        {
            InitializeComponent();
        }

        public EmpSingleForm(BindingSource bs) : this()
        {
            this.bindingSource1 = bs;
            SetBinding();
        }

        public EmpSingleForm(BindingSource bs, bool addNew) : this(bs)
        {
            isAddNew = addNew;
        }

        public void SetBinding()
        {
            txtEmpId.DataBindings.Add("Text", bindingSource1, "emp_id");
            txtName.DataBindings.Add("Text", bindingSource1, "name");
            txtGender.DataBindings.Add("Text", bindingSource1, "gender");
            txtEmail.DataBindings.Add("Text", bindingSource1, "email");
            txtPhone.DataBindings.Add("Text", bindingSource1, "phone_number");
            txtCity.DataBindings.Add("Text", bindingSource1, "city");
        }

        public void SaveEntity()
        {
            bindingSource1.EndEdit();
            var emp = this.bindingSource1.Current as Employee;
            var empService = new EmpService();

            if (isAddNew) {
                empService.Insert(emp);
            }
            else {
                empService.Update(emp);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveEntity();
            this.Close();
        }

        private void EmpSingleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            bindingSource1.CancelEdit();
        }
    }
}
