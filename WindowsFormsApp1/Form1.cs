using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private const string connectionString = "your_connection_string";
        private List<Student> students; 
        private BindingSource bindingSource;
        private int currentNumber = 1;
        public Form1()
        {
            InitializeComponent();

            students = LoadStudents(); // Hàm LoadStudents() trả về danh sách sinh viên từ cơ sở dữ liệu hoặc từ nguồn dữ liệu khác
            bindingSource = new BindingSource(students, "");
            lblNumber.Text = currentNumber.ToString();

            // Liên kết binding source với các điều khiển TextBox
            txtMasv.DataBindings.Add("Text", bindingSource, "MaSinhVien");
            txtTensv.DataBindings.Add("Text", bindingSource, "HoTen");
            txtDiemsv.DataBindings.Add("Text", bindingSource, "Diem");
            txtMakhoa.DataBindings.Add("Text", bindingSource, "Khoa");

        }
            
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string maSinhVien = txtMasv.Text;
            string hoTen = txtTensv.Text;
            float diem;
            if (float.TryParse(txtDiemsv.Text, out diem))
            {
                // Quá trình chuyển đổi thành công, sử dụng giá trị của "diem" ở đây
            }
            else
            {
                MessageBox.Show("Điểm không hợp lệ! Vui lòng nhập một số thực.");
            }

            string khoa = txtMakhoa.Text;

            string insertQuery = $"INSERT INTO SinhVien (MaSinhVien, HoTen, Diem, Khoa) " +
                $"VALUES ({maSinhVien}, '{hoTen}', {diem}, '{khoa}')";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Dữ liệu đã được lưu trữ thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            bindingSource.MoveNext();
            
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            bindingSource.MovePrevious();
            currentNumber++;
            lblNumber.Text = currentNumber.ToString();
        }

        private List<Student> LoadStudents()
        {

            var students = new List<Student>
            {
                new Student(1, "Nguyen Van A", 8.5f, "Khoa Kinh Te"),
                new Student(2, "Tran Thi B", 7.8f, "Khoa Luat"),
                new Student(3, "Le Van C", 9.2f, "Khoa Ngoai Ngu"),
                new Student(4, "Van LJ", 9 , "Cong Nghe Thong Tin"),
                new Student(5, "huy mabuw", 7, "Ngon Ngu Anh"),
            };

            return students;
        }

        private void ddd(object sender, EventArgs e)
        {

        }
    }


    public class Student
    {
        public int MaSinhVien { get; set; }
        public string HoTen { get; set; }
        public float Diem { get; set; }
        public string Khoa { get; set; }

        public Student(int maSinhVien, string hoTen, float diem, string khoa)
        {
            MaSinhVien = maSinhVien;
            HoTen = hoTen;
            Diem = diem;
            Khoa = khoa;
        }

       
    }
}
    
