using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BM_profile
{
    public partial class Form1 : Form
    {

        string ProfileFolderPath = "Profile";
        ChromeDriver driver;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (driver != null)
            {
                try
                {
                    driver.Close();
                    driver.Quit();
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < txtLinkBM.Lines.Length; i++)
            {
                driver.Url = txtLinkBM.Lines[i];
                driver.Navigate();
                Thread.Sleep(3000);
                try
                {
                    var name = driver.FindElementByXPath("//*[@id=\"js_0\"]");
                    name.SendKeys("Khanh Tran");
                    Thread.Sleep(3000);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không tìm thấy ô để nhập tên " + txtLinkBM.Lines[i]);
                }


                try
                {
                    var continues = driver.FindElementByXPath("/html/body/div/div/div[3]/div/div/form/div[2]/div[2]/button");
                    continues.Click();
                    Thread.Sleep(3000);
                }
                catch
                {
                    MessageBox.Show("Không tìm thấy nut bam de tiep tuc " + txtLinkBM.Lines[i]);
                }

                try
                {
                    var password = driver.FindElementByXPath("/html/body/div[1]/div/div[3]/div/div/form/div[3]/div[1]/div/div[2]/div[3]/div/div/span/input");
                    password.SendKeys(txtpassword.Text);
                    Thread.Sleep(3000);
                }
                catch
                {
                    MessageBox.Show("Không tìm thấy o để nhập mật khẩu " + txtLinkBM.Lines[i]);
                }

                try
                {
                    var verification = driver.FindElementByXPath("/html/body/div[1]/div/div[3]/div/div/form/div[3]/div[2]/button");
                    verification.Click();
                    Thread.Sleep(10000);
                }
                catch
                {
                    MessageBox.Show("Không tìm thấy nút xác thực " + txtLinkBM.Lines[i]);
                }
                Console.WriteLine("Đã xong:  " + txtLinkBM.Lines[i]);
            }
            MessageBox.Show("Đã hoàn thành chuyển giao tài khoản");
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            ChromeOptions options = new ChromeOptions();

            if (!Directory.Exists(ProfileFolderPath))
            {
                Directory.CreateDirectory(ProfileFolderPath);
            }

            if (Directory.Exists(ProfileFolderPath))
            {
                int nameCount = 0;

                options.AddArguments("user-data-dir=" + ProfileFolderPath + "\\" + nameCount);
            }
            driver = new ChromeDriver(options);
            driver.Url = "https://www.facebook.com/";
            driver.Navigate();
        }
    }
}
