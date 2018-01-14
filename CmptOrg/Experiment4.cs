using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CmptOrg
{
    public partial class Experiment4 : Form
    {
        RadioButton[] radioButton = new RadioButton[48];
        Panel[] panel = new Panel[24];
        Label[] label = new Label[30];
        Button[] button = new Button[20];
        TextBox[] textBox = new TextBox[5];
        string A = "";
        string  W="";
        int num_a=0,num_w=0;
        int time = 0;
        public Experiment4()
        {
            InitializeComponent();
        }

        private void Experiment4_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 24; i++)//创建用来分组的panel控件
            {
                panel[i] = new Panel();
                panel[i].SetBounds(40 + 15 * i, 420, 15, 30);
                this.Controls.Add(panel[i]);
            }

            for (int i = 0; i < 24; i++)//i+1即可表示k(i)
            {
                radioButton[i] = new RadioButton();
                radioButton[i].Size = new Size(14, 13);
                radioButton[i].Location = new Point(0, 0);

                panel[i].Controls.Add(radioButton[i]);

            }
            for (int i = 24; i < 48; i++)//i-23即可表示k(i)
            {
                radioButton[i] = new RadioButton();
                radioButton[i].Size = new Size(14, 13);
                radioButton[i].Location = new Point(0, 15);
                radioButton[i].Checked = true;
                panel[i - 24].Controls.Add(radioButton[i]);
            }
            label[0] = new Label();
            label[0].Location = new Point(20, 420);
            label[0].Size = new Size(15, 14);
            label[0].Text = "1";
            this.Controls.Add(label[0]);
            label[1] = new Label();
            label[1].Location = new Point(20, 435);
            label[1].Size = new Size(15, 14);
            label[1].Text = "0";
            this.Controls.Add(label[1]);
            for (int i = 2; i < 26; i++)//标注开关  从0开始的话23-i
            {
                label[i] = new Label();
                label[i].Location = new Point(40 + (i - 2) * 15, 405);
                label[i].Font = new Font("宋体", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                label[i].Size = new Size(15, 15);
                label[i].Text = (25 - i).ToString();
                this.Controls.Add(label[i]);
            }

            button[0] = new Button();
            button[0].Location = new Point(542, 400);
            button[0].Size = new Size(75, 50);
            button[0].Text = "下一步";
            button[0].Click += delegate { Button0_Click(); };
            this.Controls.Add(button[0]);

            button[1] = new Button();
            button[1].Location = new Point(350, 260);
            button[1].Size = new Size(55, 36);
            button[1].Text = "寄存器A";
            button[1].Click += delegate { Button1_Click(); };
            this.Controls.Add(button[1]);

            button[2] = new Button();
            button[2].Location = new Point(430, 260);
            button[2].Size = new Size(55, 36);
            button[2].Text = "寄存器W";
            button[2].Click += delegate { Button2_Click(); };
            this.Controls.Add(button[2]);

            button[3] = new Button();
            button[3].Location = new Point(350, 310);
            button[3].Size = new Size(50, 36);
            button[3].Text = "Clock";
            this.Controls.Add(button[3]);

            button[4] = new Button();
            button[4].Location = new Point(325, 60);
            button[4].Size = new Size(50, 36);
            button[4].Text = "L";
            this.Controls.Add(button[4]);

            button[5] = new Button();
            button[5].Location = new Point(400, 60);
            button[5].Size = new Size(50, 36);
            button[5].Text = "D";
            this.Controls.Add(button[5]);

            button[6] = new Button();
            button[6].Location = new Point(475, 60);
            button[6].Size = new Size(50, 36);
            button[6].Text = "R";
            this.Controls.Add(button[6]);

            button[7] = new Button();
            button[7].Location = new Point(550, 60);
            button[7].Size = new Size(50, 36);
            button[7].Text = "R0";
            this.Controls.Add(button[7]);

            button[8] = new Button();
            button[8].Location = new Point(550, 135);
            button[8].Size = new Size(50, 36);
            button[8].Text = "R1";
            this.Controls.Add(button[8]);

            button[9] = new Button();
            button[9].Location = new Point(550, 210);
            button[9].Size = new Size(50, 36);
            button[9].Text = "R2";
            this.Controls.Add(button[9]);

            button[10] = new Button();
            button[10].Location = new Point(550, 285);
            button[10].Size = new Size(50, 36);
            button[10].Text = "R3";
            this.Controls.Add(button[10]);

            textBox[0] = new TextBox();
            textBox[0].Location = new Point(40, 60);
            textBox[0].Size = new Size(200, 60);
            textBox[0].Multiline = true;
            textBox[0].Enabled = false;
            textBox[0].ForeColor = Color.FromArgb(0, 0, 0);
            textBox[0].BackColor = Color.FromArgb(255, 255, 255);
            textBox[0].Font = new Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            textBox[0].Text = "请输入要写入寄存器A的数字，要开始实验请点击下一步";
            this.Controls.Add(textBox[0]);

            textBox[1] = new TextBox();
            textBox[1].Location = new Point(40, 200);
            textBox[1].Size = new Size(50, 30);
            textBox[1].Font = new Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Controls.Add(textBox[1]);



        }

        private void Button0_Click()
        {
            switch (time)
            {
                case 0:  //第一步操作
                    {
                        try
                        {
                            string binary = Convert.ToString(int.Parse(textBox[1].Text), 2);
                            A = binary;
                            num_a = int.Parse(textBox[1].Text);
                            binary = DBUS(binary);
                            textBox[0].Text = string.Format("{0}转化为8位二进制数字为{1},设置DBUS好后如下图所示", textBox[1].Text, binary);
                            time++;
                        }
                        catch
                        {
                            MessageBox.Show("请输入正确的数");
                            time--;
                            time++;
                        }
                        break;
                    }
                case 1:
                    {
                        radioButton[19].Checked = true;
                        textBox[0].Text = "置K4为1，K3为0，允许打入A寄存器";
                        time++;
                        break;
                    }
                case 2:
                    {
                        button[1].BackColor = Color.FromArgb(250, 250, 210);
                        textBox[0].Text = "按住Clock脉冲键，Clock由高变低，寄存器A的黄色指示灯变亮，表明选择A寄存器";
                        time++;
                        break;
                    }
                case 3:
                    {
                        button[1].BackColor = SystemColors.Control;
                        textBox[0].Text = string.Format("放开Clock脉冲建，Clock低变高，数据{0}被写入A寄存器", textBox[1].Text);
                        time++;
                        break;
                    }
                case 4:
                    {
                        for (int i = 24; i < 48; i++)//i-23即可表示k(i)
                        {
                            radioButton[i].Checked = true;
                        }
                        textBox[1].Text = "";
                        textBox[0].Text = "请输入要写入寄存器W的数字";
                        time++;
                        break;
                    }
                case 5:
                    {
                        try
                        {
                            string binary = Convert.ToString(int.Parse(textBox[1].Text), 2);
                            W = binary;
                            num_w = int.Parse(textBox[1].Text);
                            binary = DBUS(binary);
                            textBox[0].Text = string.Format("{0}转化为二进制数字为{1},设置DBUS好后如下图所示", textBox[1].Text, binary);
                        }
                        catch
                        {
                            MessageBox.Show("请输入正确的数");
                            time--;
                        }
                        time++;
                        break;
                    }
                case 6:
                    {
                        radioButton[20].Checked = true;
                        textBox[0].Text = "置K4为0，K3为1，允许打入W寄存器";
                        time++;
                        break;
                    }
                case 7:
                    {
                        button[2].BackColor = Color.FromArgb(250, 250, 210);
                        textBox[0].Text = "按住Clock脉冲键，Clock由高变低，寄存器W的黄色指示灯变亮，表明选择W寄存器";
                        time++;
                        break;
                    }
                case 8:
                    {
                        button[2].BackColor = SystemColors.Control;
                        textBox[0].Text = string.Format("放开Clock脉冲建，Clock低变高，数据{0}被写入W寄存器", textBox[1].Text);
                        textBox[1].Text = "";
                        time++;
                        break;
                    }
                case 9:
                    {
                        for (int i = 24; i < 48; i++)//i-23即可表示k(i)
                        {
                            radioButton[i].Checked = true;
                        }
                        
                        textBox[0].Text = string.Format("{0}与{1}相加运算结果为{2}(10进制)", A,W,Convert.ToInt32(Add(A,W),2));
                        time++;
                        break;
                    }
                case 10:
                    {
                        for (int i = 24; i < 48; i++)//i-23即可表示k(i)
                        {
                            radioButton[i].Checked = true;
                        }
                        radioButton[23].Checked = true;
                        string A1 = CalculateTrueForm(num_a);
                        A1 = CalculateComplement(A1);
                        string W1 = CalculateTrueForm(0-num_w);
                        W1 = CalculateRadixMinusOneComplement(W1);
                        W1 = CalculateComplement(W1);
                        string reslut = Add(A1, W1);
                        if (reslut[0] == '1')
                            reslut=reslut.Substring(1);                    
                        textBox[0].Text = string.Format("{0}与{1}相减运算结果为{2}(10进制){3}(二进制)", A, W,Convert.ToInt32(reslut,2),reslut);
                        time++;
                        break;
                    }
                case 11:
                    {
                        for (int i = 24; i < 48; i++)//i-23即可表示k(i)
                        {
                            radioButton[i].Checked = true;
                        }
                        string a, w;
                        a = A;
                        w = W;
                        for (int t = 0; t < 8 - a.Length; t++)//转化位8位二进制
                        {
                            a = "0" + a;
                        }
                        for (int t = 0; t < 8 - w.Length; t++)//转化位8位二进制
                        {
                            w = "0" + w;
                        }
                        radioButton[22].Checked = true;
                        textBox[0].Text = string.Format("{0}与{1}相或运算结果为{2}(二进制))", a, w, OR(A,W));
                        time++;
                        break;
                    }
                case 12:
                    {
                        string a, w;
                        a = A;
                        w = W;
                        for (int t = 0; t < 8 - a.Length; t++)//转化位8位二进制
                        {
                            a = "0" + a;
                        }
                        for (int t = 0; t < 8 - w.Length; t++)//转化位8位二进制
                        {
                            w = "0" + w;
                        }
                        radioButton[23].Checked = true;
                        textBox[0].Text = string.Format("{0}与{1}相与运算结果为{2}(二进制))", a, w, AND(A,W));
                        time++;
                        break;
                    }
                case 13:
                    {
                        for (int i = 24; i < 48; i++)//i-23即可表示k(i)
                        {
                            radioButton[i].Checked = true;
                        }
                        for (int t = 0; t < 8 - A.Length; t++)//转化位8位二进制
                        {
                            A = "0" + A;
                        }
                        radioButton[21].Checked = true;
                        radioButton[22].Checked = true;
                        textBox[0].Text = string.Format("{0}取反运算结果为{1}(二进制))" ,A,  NOT(A));
                        time++;
                        break;
                    }
                case 14:
                    {
                        MessageBox.Show("实验结束");
                        break;
                    }
                


            }

        }
        private void Button1_Click()
        {
            Display display = new Display();
            display.BackgroundImage = Image.FromFile("A寄存器.jpg");
            display.Show();
        }
        private void Button2_Click()
        {
            Display display = new Display();
            display.BackgroundImage = Image.FromFile("W寄存器.jpg");
            display.Show();
        }
        private string DBUS(string binary)  //二进制转化为8位二进制并将DBUS置位
        {
            int t, d = 0;

            int len = binary.Length;
            for (t = 0; t < 8 - len; t++)//转化位8位二进制
            {
                binary = "0" + binary;
            }
            foreach (char bit in binary)
            {
                if (bit == '0')  //如果该位二进制位0
                {
                    radioButton[24 + d].Checked = true;
                    radioButton[d].Checked = false;
                    d++;
                }
                else if (bit == '1')//入果该位二进制为1
                {
                    radioButton[d].Checked = true;
                    radioButton[24 + d].Checked = false;
                    d++;
                }
            }
            return binary;

        }
        public string CalculateComplement(string dataF)//补码
        {
            const char POSITIVE_SIGN = '0';
            const char FIRST_CHAR_B = '0';
            if (dataF[0] == POSITIVE_SIGN)
            {
                return dataF;
            }

            StringBuilder result = new StringBuilder();

            bool carry = dataF.Last() == '1';
            result.Append(carry ? FIRST_CHAR_B : '1');

            for (int i = dataF.Length - 2; i >= 0; i--)
            {
                if (carry)
                {
                    carry = dataF[i] == '1';
                    result.Insert(0, carry ? FIRST_CHAR_B : '1');

                    continue;
                }

                result.Insert(0, dataF[i]);
            }

            return result.ToString();
        }
        static public string Add(string A, string W)//二进制加法
        {
            int m = 0; string str;
            int[] a = new int[A.Length];
            int[] b = new int[W.Length];
            foreach (char ch in A)
            {

                a[m++] = int.Parse(ch.ToString());
            }
            m = 0;
            foreach (char ch in W)
            {
                b[m++] = int.Parse(ch.ToString());
            }



            int reLength = Math.Max(a.Length, b.Length);
            int[] re = new int[reLength + 1];//返回计算结果的数组
            int carry = 0;//进位数
            int temp;
            int i, j, k;
            for (i = a.Length - 1, j = b.Length - 1, k = reLength; i >= 0 && j >= 0; i--, j--, k--)
            {
                temp = a[i] + b[j] + carry;
                if (temp >= 2)
                {
                    carry = 1;
                    re[k] = temp - 2;
                }
                else
                {
                    re[k] = temp;
                    carry = 0;
                }
            }
            /*
             * 分为三种情况
             * 1）两个数位数相同，都被加完，re的最高位加carry就可以；
             * 2）a被加完，b还没有加完；
             * 3）与2）情况相反。
             */
            if (i >= 0)
            {
                while (i >= 0)
                {
                    temp = a[i] + carry;
                    re[k] = (temp == 2) ? 0 : temp;
                    carry = (temp == 2) ? 1 : 0;
                    i--;
                    k--;
                }
            }
            else if (j >= 0)
            {
                while (j >= 0)
                {
                    temp = b[j] + carry;
                    re[k] = (temp == 2) ? 0 : temp;
                    carry = (temp == 2) ? 1 : 0;
                    j--;
                    k--;
                }
            }
            re[0] = re[0] + carry;
            str = String.Join("", re);

            return str;
        }
        static public string AND(string A,string W)
        {
            int t;
            string reslut = "";
            int len = A.Length;
            for (t = 0; t < 8 - len; t++)//转化位8位二进制
            {
                A = "0" + A;
            }
            len = W.Length;
            for (t = 0; t < 8 - len; t++)//转化位8位二进制
            {
                W = "0" + W;
            }
            
            for (int i =0;i<8;i++)
            {
                if (A[i] == '0' || W[i] == '0') reslut = reslut + "0";
                else reslut = reslut + "1";
            }


            return reslut;
        }//二进制与运算
        static public string OR(string A,string W)
        {
            int t;
            string reslut = "";
            int len = A.Length;
            for (t = 0; t < 8 - len; t++)//转化位8位二进制
            {
                A = "0" + A;
            }
            len = W.Length;
            for (t = 0; t < 8 - len; t++)//转化位8位二进制
            {
                W = "0" + W;
            }

            for (int i = 0; i < 8; i++)
            {
                if (A[i] == '1' || W[i] == '1') reslut = reslut + "1";
                else reslut = reslut + "0";
            }


            return reslut;
        }//二进制或运算
        static public string NOT(string A)//二进制取反运算
        {
            int t;
            string reslut = "";
            int len = A.Length;
            for (t = 0; t < 8 - len; t++)//转化位8位二进制
            {
                A = "0" + A;
            }

            for (int i = 0; i < 8; i++)
            {
                if (A[i] == '1') reslut+='0';
                else reslut = reslut + "1";
            }
            return reslut;
        }
        private string CalculateTrueForm(int originalValue)//原码
        {
            const char FIRST_CHAR_B = '0';
            const char SECONT_CHAR_B = '1';
        StringBuilder buffer = new StringBuilder();

            int quotient = 0;
            int remainder = 0;

            int tmp = Math.Abs(originalValue);

            do
            {
                quotient = tmp / 2;
                remainder = tmp % 2;

                buffer.Insert(0, Convert.ToString(remainder));

                tmp = quotient;
            } while (tmp != 0);

            string result = buffer.ToString().TrimStart(FIRST_CHAR_B).PadLeft(7, FIRST_CHAR_B);

            return (Convert.ToString(originalValue < 0 ? SECONT_CHAR_B : FIRST_CHAR_B)) + result;
        }
        public string CalculateRadixMinusOneComplement(string dataY)//反码
        {
            const char POSITIVE_SIGN = '0';
            const char FIRST_CHAR_B = '0';
            const char SECONT_CHAR_B = '1';
            if (dataY[0] == POSITIVE_SIGN)
            {
                return dataY;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(dataY[0]);

            for (int i = 1; i < dataY.Length; i++)
            {
                sb.Append(dataY[i] == FIRST_CHAR_B ? SECONT_CHAR_B : FIRST_CHAR_B);
            }

            return sb.ToString();
        }

    }
}
