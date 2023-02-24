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
                //��ȡ������ļ�·��
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                for (int i = 0; i < files.Length; i++)
                {//���Ϸ��봰����ļ����ļ�������ListBox
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
                    label3.Text = "��ȷ";
                }
                else if (string.Compare(str, string.Format(HashHelper.HashFile(str2, "sha256"))) == 0)
                {
                    label3.Text = "��ȷ";
                }
                else if (string.Compare(str, HashHelper.MD5File(str2)) == 0)
                {
                    label3.Text = "��ȷ";
                }
                else
                {
                    label3.Text = "sha256 sha1 md5 ���� ";
                }
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}