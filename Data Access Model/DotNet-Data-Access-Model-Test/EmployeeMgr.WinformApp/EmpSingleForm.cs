using EmployeeMgr.Domain;
using EmployeeMgr.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace SqlSugarTest {
    public partial class EmpSingleForm : Form {
        private EmployeeRepository empRepo;
        private int actionType;         // 1: insert, 2: update
        private Employee empForRestore; // 用于用户点击取消的时候恢复到之前状态

        public EmpSingleForm() {
            InitializeComponent();

            empRepo = new EmployeeRepository();            
        }

        public EmpSingleForm(BindingSource bs, int actionType) : this() {
            this.bindingSource1 = bs;
            this.actionType = actionType;
        }

        private void SetBinding() {
            // data binding
            txtEmpID.DataBindings.Add("Text", bindingSource1, "EMP_ID", true);
            cboSex.DataBindings.Add("Text", bindingSource1, "GENDER", true);
            txtAge.DataBindings.Add("Text", bindingSource1, "AGE", true);
            txtEMail.DataBindings.Add("Text", bindingSource1, "EMAIL", true);
            txtPhone.DataBindings.Add("Text", bindingSource1, "PHONE_NR", true);
            txtEducation.DataBindings.Add("Text", bindingSource1, "EDUCATION", true);
            txtMaritalStat.DataBindings.Add("Text", bindingSource1, "MARITAL_STAT", true);
            txtNumOfChildren.DataBindings.Add("Text", bindingSource1, "NR_OF_CHILDREN", true);
        }

        private void Backup() {
            var old = empForRestore = this.bindingSource1.Current as Employee;
            empForRestore = old.ShallowCopy();
        }

        private void CancelUpdate()
        {
            if (empForRestore == null) return;
            var current = bindingSource1.Current as Employee;
            current.EMP_ID = empForRestore.EMP_ID;
            current.AGE = empForRestore.AGE;
            current.EDUCATION = empForRestore.EDUCATION;
            current.EMAIL = empForRestore.EMAIL;
            current.GENDER = empForRestore.GENDER;
            current.MARITAL_STAT = empForRestore.MARITAL_STAT;
            current.NR_OF_CHILDREN = empForRestore.NR_OF_CHILDREN;
            current.PHONE_NR = empForRestore.PHONE_NR;

            bindingSource1.ResetBindings(false);
        }

        private void SaveUpdate()
        {
            var employee = bindingSource1.Current as Employee;
            empRepo.Update(employee);
        }

        private void SaveInsert()
        {
            var employee = bindingSource1.Current as Employee;
            empRepo.Insert(employee);
        }


        private void btnSave_Click(object sender, EventArgs e) {
            try {
                if (actionType == 1) {
                    SaveInsert();
                }else if(actionType == 2) {
                    SaveUpdate();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            this.Close();
        }
               
        private void btnCancel_Click(object sender, EventArgs e) {
            CancelUpdate();
            this.Close();
        }

        private void EmpSingleForm_Load(object sender, EventArgs e)
        {
            this.SetBinding();
            this.Backup();
        }
    }
}
