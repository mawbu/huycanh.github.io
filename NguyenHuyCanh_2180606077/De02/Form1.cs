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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace De02
{
    public partial class frmSanpam : Form
    {
        public frmSanpam()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmSanpam_Load(object sender, EventArgs e)
        {
            try
            {
                Model1 context = new Model1();
                List<LoaiSP> listFalcultys = context.LoaiSPs.ToList(); 
                List<SanPham> listStudent = context.SanPhams.ToList(); 
                FillFalcultyCombobox(listFalcultys);
                BindGrid(listStudent);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void FillFalcultyCombobox(List<LoaiSP> listFalcultys)
        {
            this.cmbLoai.DataSource = listFalcultys;
            this.cmbLoai.DisplayMember = "TenLoai";
            this.cmbLoai.ValueMember = "MaLoai";
        }
       

        
        private void BindGrid(List<SanPham> listStudent)
        {
            dgvSP.Rows.Clear();
            foreach (var item in listStudent)
            {
                int index = dgvSP.Rows.Add();
                dgvSP.Rows[index].Cells[0].Value = item.MaSP;
                dgvSP.Rows[index].Cells[1].Value = item.TenSP;
                dgvSP.Rows[index].Cells[2].Value = item.NgayNhap;
                dgvSP.Rows[index].Cells[3].Value = item.LoaiSP.MaLoai;
                
            }
        }

        private void dgvSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
    }
    

        
