using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
namespace ftp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnup_Click(object sender, EventArgs e)
        {
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create("ftp://files.000webhost.com/public_html/" + "/" + Path.GetFileName("C:\\Users\\erend\\Desktop\\a20177946.txt"));
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential("test1pweb", "computadora321");
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;

            FileStream stream = File.OpenRead("C:\\Users\\erend\\Desktop\\a20177946.txt");
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            stream.Close();

            Stream reqStream = request.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Close();
        }
    }
}
