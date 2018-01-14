using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CmptOrg
{
    public partial class Form1 : Form
    {
        Control[] controls = new Control[20];//控件数组

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            controls[0] = new Label();
            controls[0].Name = "labe2";
            controls[0].Location = new Point(140, 44);
            controls[0].Size=new Size(400, 40);
            controls[0].Font = new Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            controls[0].Text = " 模拟计算机原理组成实验 ";
            this.Controls.Add(controls[0]);

            for(int i=1;i<4;i++)
            {
                controls[i] = new Button();
                controls[i].Name = "button" + i.ToString();
                controls[i].Location = new Point(217,130+(i-1)*100);
                controls[i].Size = new Size(166, 55);
                this.Controls.Add(controls[i]);
            }
            
            controls[1].Text = "A,W寄存器实验";
            controls[1].Click += delegate { Button1_Click(); };
            controls[2].Text = "R0,R1,R2,R3寄存器实验";
            controls[2].Click += delegate { Button2_Click(); };
            controls[3].Text = "运算器实验";
            controls[3].Click += delegate { Button4_Click(); };




        }
        private void Button1_Click()
        {
            Thread t = new Thread(new ThreadStart(delegate { Application.Run(new Experiment1()); }));
            t.Start();
            this.Dispose(true);
        }
        private void Button2_Click()
        {
            Thread t = new Thread(new ThreadStart(delegate { Application.Run(new Experiment2()); }));
            t.Start();
            this.Dispose(true);
        }

        private void Button4_Click()
        {
            Thread t = new Thread(new ThreadStart(delegate { Application.Run(new Experiment4()); }));
            t.Start();
            this.Dispose(true);
        }


    }
}
