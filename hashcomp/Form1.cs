using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace hashcomp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void Text_Changed(object sender, EventArgs e)
        {
            check();
        }
        private void Form1_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //获取拖入的文件路径
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                for (int i = 0; i < files.Length; i++)
                {//将拖放入窗体的文件的文件名加入ListBox
                    textBox2.Text = files[i];
                    check();
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            check();
        }
        private void check()
        {
            ThreadStart threadStart = new ThreadStart(run);
            new Thread(threadStart).Start();
            
        }
        private void run()
        {
            string str = textBox1.Text;
            string str2 = textBox2.Text;
            str = str.ToUpper();
            if (str != null && str != null)
            {
                if (string.Compare(str, string.Format(HashHelper.SHA1File(str2))) == 0)
                {
                    label3.Text = "正确";
                }
                else if (string.Compare(str, string.Format(HashHelper.HashFile(str2, "sha256"))) == 0)
                {
                    label3.Text = "正确";
                }
                else if (string.Compare(str, HashHelper.MD5File(str2)) == 0)
                {
                    label3.Text = "正确";
                }
                else
                {
                    label3.Text = "sha256 sha1 md5 不对 ";
                }
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}