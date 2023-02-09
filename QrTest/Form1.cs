using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;

/**
 * Источники
 * работа с QR https://vscode.ru/prog-lessons/qr-kod-na-c-sharp.html
 * работа с изображениями https://metanit.com/sharp/windowsforms/4.16.php
 * 
 * lib-а (библеотека) для работы с QR-кодом расположена в проекте, папка libs
 */

namespace QrTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string qr = textBox1.Text;
            QRCodeEncoder encoder = new QRCodeEncoder();
            Bitmap bitmap = encoder.Encode(qr);
            pictureBox1.Image = bitmap as Image;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PNG|*.png|JPEG|*.jpg|GIF|*.gif|BMP|*.bmp";
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image.Save(save.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog load = new OpenFileDialog();
            if (load.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(load.FileName);
                pictureBox1.Refresh();
                pictureBox1.Update();
                textBox1.Text = new QRCodeDecoder().decode(new QRCodeBitmapImage(pictureBox1.Image as Bitmap));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //http запрос на бек со значением qr
        }
    }
}
