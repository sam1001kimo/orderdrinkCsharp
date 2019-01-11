using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        //類別變數,class variables
        int 杯數1 = 0, 杯數2 = 0, 杯數3 = 0, 杯數4 = 0, 杯數5 = 0;
        double 售價1 = 0.0, 售價2 = 0.0, 售價3 = 0.0, 售價4 = 0.0, 售價5 = 0.0;
        double 品項1總價 = 0.0, 品項2總價 = 0.0, 品項3總價 = 0.0, 品項4總價 = 0.0, 品項5總價 = 0.0;
        double 折數 = 0.0;
        double 總價 = 0.0;
        double 折扣後總價 = 0.0;
        double 活動1品項1總價 = 0.0, 活動1品項2總價 = 0.0, 活動1品項3總價 = 0.0, 活動1品項4總價 = 0.0, 活動1品項5總價 = 0.0;
        double[] array各品項總價 = new double[5];
        double[] array活動1各項價錢 = new double[5];
        int[] array杯數 = new int[5];
        int[] array活動杯數 = new int[5];
        int[] arraytemp杯數 = new int[5];
        string[] array品名 = new string[5];
        string[] arraytemp品名 = new string[5];
        double[] array售價 = new double[5];
        double[] arraytemp售價 = new double[5];
        bool if同商品第二件6折 = false;
        bool if不同品項買三送一 = false;
        int 不同品項送的杯數 = 0;
        int 不同品項送的杯數temp = 0;
        string 送的品項 = "";
        int 杯數加總 = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbl品名1.Text = "麥香紅茶";
            lbl品名2.Text = "茉莉綠茶";
            lbl品名3.Text = "珍珠奶茶";
            lbl品名4.Text = "玫瑰花茶";
            lbl品名5.Text = "現打西瓜汁";
            array品名 = new string[] { lbl品名1.Text, lbl品名2.Text, lbl品名3.Text, lbl品名4.Text, lbl品名5.Text };

            售價1 = 35.0;
            售價2 = 40.0;
            售價3 = 45.0;
            售價4 = 50.0;
            售價5 = 55.0;
            array售價 = new double[] { 售價1, 售價2, 售價3, 售價4, 售價5 };

            lbl售價1.Text = 售價1.ToString();
            lbl售價2.Text = 售價2.ToString();
            lbl售價3.Text = 售價3.ToString();
            lbl售價4.Text = 售價4.ToString();
            lbl售價5.Text = 售價5.ToString();

            折數 = 10.0;

        }
        #region 杯數加減
        private void btn杯數1減_Click(object sender, EventArgs e)
        {
            杯數1 -= 1;
            if (杯數1 <= 0)
            {
                杯數1 = 0;
                btn杯數1減.Enabled = false;
            }
            tb杯數1.Text = 杯數1.ToString();
        }

        private void btn杯數1加_Click(object sender, EventArgs e)
        {
            杯數1 += 1;
            btn杯數1減.Enabled = true;
            tb杯數1.Text = 杯數1.ToString();
        }

        private void tb杯數1_TextChanged(object sender, EventArgs e)
        {
            if (tb杯數1.Text != "")
            {
                bool ifNum = System.Int32.TryParse(tb杯數1.Text, out 杯數1);
                if ((ifNum == true) && (杯數1 >= 0))
                {
                    //輸入正確
                    btn杯數1減.Enabled = true;
                }
                else
                {
                    MessageBox.Show("杯數輸入錯誤", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    杯數1 = 0;
                    tb杯數1.Text = "0";
                }
            }
            else
            {
                杯數1 = 0;
            }
            計算總價();
        }

        private void btn杯數2減_Click(object sender, EventArgs e)
        {
            杯數2 -= 1;
            if (杯數2 <= 0)
            {
                杯數2 = 0;
                btn杯數2減.Enabled = false;
            }
            tb杯數2.Text = 杯數2.ToString();
        }

        private void btn杯數2加_Click(object sender, EventArgs e)
        {
            杯數2 += 1;
            btn杯數2減.Enabled = true;
            tb杯數2.Text = 杯數2.ToString();
        }

        private void tb杯數2_TextChanged(object sender, EventArgs e)
        {
            if (tb杯數2.Text != "")
            {
                bool ifNum = System.Int32.TryParse(tb杯數2.Text, out 杯數2);
                if ((ifNum == true) && (杯數2 >= 0))
                {
                    btn杯數2減.Enabled = true;
                }
                else
                {
                    MessageBox.Show("杯數輸入錯誤", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    杯數2 = 0;
                    tb杯數2.Text = "0";
                }
            }
            else
            {
                杯數2 = 0;
            }
            計算總價();
        }

        private void btn杯數3減_Click(object sender, EventArgs e)
        {
            杯數3 -= 1;
            if (杯數3 <= 0)
            {
                杯數3 = 0;
                btn杯數3減.Enabled = false;
            }
            tb杯數3.Text = 杯數3.ToString();
        }

        private void btn杯數3加_Click(object sender, EventArgs e)
        {
            杯數3 += 1;
            btn杯數3減.Enabled = true;
            tb杯數3.Text = 杯數3.ToString();
        }

        private void tb杯數3_TextChanged(object sender, EventArgs e)
        {
            if (tb杯數3.Text != "")
            {
                bool ifNum = System.Int32.TryParse(tb杯數3.Text, out 杯數3);
                if ((ifNum == true) && (杯數3 >= 0))
                {
                    btn杯數3減.Enabled = true;
                }
                else
                {
                    MessageBox.Show("杯數輸入錯誤", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    杯數3 = 0;
                    tb杯數3.Text = "0";
                }
            }
            else
            {
                杯數3 = 0;
            }
            計算總價();
        }

        private void btn杯數4減_Click(object sender, EventArgs e)
        {
            杯數4 -= 1;
            if (杯數4 <= 0)
            {
                杯數4 = 0;
                btn杯數4減.Enabled = false;
            }
            tb杯數4.Text = 杯數4.ToString();
        }

        private void btn杯數4加_Click(object sender, EventArgs e)
        {
            杯數4 += 1;
            btn杯數4減.Enabled = true;
            tb杯數4.Text = 杯數4.ToString();
        }

        private void tb杯數4_TextChanged(object sender, EventArgs e)
        {
            if (tb杯數4.Text != "")
            {
                bool ifNum = System.Int32.TryParse(tb杯數4.Text, out 杯數4);
                if ((ifNum == true) && (杯數4 >= 0))
                {
                    btn杯數4減.Enabled = true;
                }
                else
                {
                    MessageBox.Show("杯數輸入錯誤", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    杯數4 = 0;
                    tb杯數4.Text = "0";
                }
            }
            else
            {
                杯數4 = 0;
            }
            計算總價();
        }

        private void btn杯數5減_Click(object sender, EventArgs e)
        {
            杯數5 -= 1;
            if (杯數5 <= 0)
            {
                杯數5 = 0;
                btn杯數5減.Enabled = false;
            }
            tb杯數5.Text = 杯數5.ToString();
        }

        private void btn杯數5加_Click(object sender, EventArgs e)
        {
            杯數5 += 1;
            btn杯數5減.Enabled = true;
            tb杯數5.Text = 杯數5.ToString();
        }

        private void tb杯數5_TextChanged(object sender, EventArgs e)
        {
            if (tb杯數5.Text != "")
            {
                bool ifNum = System.Int32.TryParse(tb杯數5.Text, out 杯數5);
                if ((ifNum == true) && (杯數2 >= 0))
                {
                    btn杯數5減.Enabled = true;
                }
                else
                {
                    MessageBox.Show("杯數輸入錯誤", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    杯數5 = 0;
                    tb杯數5.Text = "0";
                }
            }
            else
            {
                杯數5 = 0;
            }
            計算總價();
        }
        #endregion
        #region 折數
        private void tb折數_TextChanged(object sender, EventArgs e)
        {
            if (tb折數.Text != "")
            {
                bool ifNum = System.Double.TryParse(tb折數.Text, out 折數);
                if (ifNum == true)
                {
                    if ((折數 >= 0.0) && (折數 <= 10.0))
                    {
                        //合理折數

                    }
                    else
                    {
                        MessageBox.Show("折數輸入錯誤 (0.0-10.0)");
                        tb折數.Text = "";
                        折數 = 10.0;
                    }
                }
                else
                {
                    MessageBox.Show("折數輸入錯誤 (0.0-10.0)");
                    tb折數.Text = "";
                    折數 = 10.0;
                }
            }
            else
            {
                折數 = 10.0;
            }
            計算總價();
        }
        #endregion
        #region 列印
        private void btn列印訂購單_Click(object sender, EventArgs e)
        {
            DialogResult drResult;
            drResult = MessageBox.Show("您確認送出訂購單?", "訂單確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (drResult == DialogResult.No)
            {
                //取消送出
            }
            else
            {
                //確認訂單
                string strOrder = "******III冷飲店訂購單******\n";
                strOrder += "-------------------------------------\n";
                array杯數 = new int[] { 杯數1, 杯數2, 杯數3, 杯數4, 杯數5 };
                array各品項總價 = new double[] { 品項1總價, 品項2總價, 品項3總價, 品項4總價, 品項5總價 };

                for (int i = 0; i < array杯數.Length; i += 1)
                {
                    if (array杯數[i] > 0)
                    {
                        strOrder += array品名[i] + ":" + array售價[i].ToString() + "x" + array杯數[i].ToString() + "=" + array各品項總價[i].ToString() + "\n";
                    }
                    if (if同商品第二件6折 == true)
                    {
                        if (array杯數[i] >= 2)
                        {
                            strOrder += $"活動:{array品名[i].ToString()}:-{array售價[i].ToString()}x0.4x{(array杯數[i] / 2).ToString()}= {(array活動1各項價錢[i] - array杯數[i] * array售價[i]).ToString()}\n";
                        }
                    }
                }

                if (if不同品項買三送一 == true)
                {
                    if (杯數加總 >= 4)
                    {
                        strOrder += 送的品項;
                    }
                }
                strOrder += "-------------------------------------\n";
                if (折數 < 10.0)
                {
                    strOrder += "折數" + string.Format("{0:F2}", 折數) + "\n";
                }
                strOrder += "訂單總價" + string.Format("{0:C}", 總價) + "\n";
                strOrder += "折扣後總價" + string.Format("{0:C}", 折扣後總價) + "\n";
                strOrder += string.Format("{0:D}", DateTime.Now) + "\n";
                strOrder += string.Format("{0:T}", DateTime.Now) + "\n";
                MessageBox.Show(strOrder, "訂單明細", MessageBoxButtons.OK);
                杯數1 = 0;
                杯數2 = 0;
                杯數3 = 0;
                杯數4 = 0;
                杯數5 = 0;
                tb杯數1.Text = "";
                tb杯數2.Text = "";
                tb杯數3.Text = "";
                tb杯數4.Text = "";
                tb杯數5.Text = "";
            }
        }
        #endregion
        #region 計算總價
        void 計算總價()
        {
            品項1總價 = 售價1 * 杯數1;
            品項2總價 = 售價2 * 杯數2;
            品項3總價 = 售價3 * 杯數3;
            品項4總價 = 售價4 * 杯數4;
            品項5總價 = 售價5 * 杯數5;

            總價 = 品項1總價 + 品項2總價 + 品項3總價 + 品項4總價 + 品項5總價;

            if (if同商品第二件6折 == true)
            {
                同商品第二件6折總價();
            }
            else if (if不同品項買三送一 == true)
            {
                不同品項買三送一總價();
            }
            else
            {
                折扣後總價 = 總價 * 折數 / 10.0;
            }
            lbl訂單總價.Text = string.Format("{0:C}", 總價);
            lbl訂單折扣後總價.Text = string.Format("{0:C}", 折扣後總價);
        }
        #endregion
        #region 活動void
        void 同商品第二件6折總價()
        {
            活動1品項1總價 = 售價1 * (杯數1 - 0.4 * (杯數1 / 2));
            活動1品項2總價 = 售價2 * (杯數2 - 0.4 * (杯數2 / 2));
            活動1品項3總價 = 售價3 * (杯數3 - 0.4 * (杯數3 / 2));
            活動1品項4總價 = 售價4 * (杯數4 - 0.4 * (杯數4 / 2));
            活動1品項5總價 = 售價5 * (杯數5 - 0.4 * (杯數5 / 2));
            array活動1各項價錢 = new double[] { 活動1品項1總價, 活動1品項2總價, 活動1品項3總價, 活動1品項4總價, 活動1品項5總價 };
            折扣後總價 = 活動1品項1總價 + 活動1品項2總價 + 活動1品項3總價 + 活動1品項4總價 + 活動1品項5總價;
        }

        void 不同品項買三送一總價()
        {
            array杯數 = new int[] { 杯數1, 杯數2, 杯數3, 杯數4, 杯數5 };
            Array.Copy(array杯數, arraytemp杯數, array杯數.Length);
            Array.Sort(arraytemp杯數);
            杯數加總 = 杯數1 + 杯數2 + 杯數3 + 杯數4 + 杯數5;
            不同品項送的杯數 = 0;
            送的品項 = "";
            if (杯數加總 >= 4)
            {
                //計算有沒有不同品項
                int count = 0;
                for (int i = 0; i < arraytemp杯數.Length; i += 1)
                {
                    if (arraytemp杯數[i] == 0)
                    {
                        count += 1;
                    }
                    else
                    {
                        break;
                    }
                }
                //2個以上不同品項
                int 排除最多那杯的加總 = 0;
                if (count <= arraytemp杯數.Length - 2)
                {
                    //送的杯數若大於排除最多杯數後的加總，則送的杯數只能等於排除最多杯數後的加總，不然超出的會無法搭配成不同品項
                    for (int i = 0; i < arraytemp杯數.Length - 1; i += 1)
                    {
                        排除最多那杯的加總 += arraytemp杯數[i];
                    }
                    if (杯數加總 / 4 > 排除最多那杯的加總)
                    {
                        不同品項送的杯數temp = 排除最多那杯的加總;
                    }
                    else
                    {
                        不同品項送的杯數temp = 杯數加總 / 4;
                    }

                    不同品項送的杯數 = 不同品項送的杯數temp;
                    不同品項送的杯數temp = 0;

                    Array.Copy(array品名, arraytemp品名, array品名.Length);
                    Array.Copy(array售價, arraytemp售價, array售價.Length);
                    Array.Copy(array杯數, arraytemp杯數, array杯數.Length);
                    Array.Sort(arraytemp售價, arraytemp品名);
                    Array.Copy(array售價, arraytemp售價, array售價.Length);
                    Array.Sort(arraytemp售價, arraytemp杯數);
                    折扣後總價 = 總價;

                    for (int i = 0; i < arraytemp杯數.Length - 1; i += 1)
                    {
                        //一步一步加總杯數，取得要送的杯數的落點
                        int 落點 = 0;
                        落點 += arraytemp杯數[i];
                        if (不同品項送的杯數 > 0)
                        {
                            if ((arraytemp杯數[i] > 0) && (不同品項送的杯數 > 落點))
                            {
                                不同品項送的杯數 -= arraytemp杯數[i];
                                送的品項 += $"活動:不同品項買三送一:{arraytemp品名[i]}:-{arraytemp售價[i].ToString()}x{arraytemp杯數[i].ToString()}= -{(arraytemp售價[i] * arraytemp杯數[i]).ToString()}\n";
                                折扣後總價 -= (arraytemp售價[i] * arraytemp杯數[i]);
                            }
                            else if ((arraytemp杯數[i] > 0) && (不同品項送的杯數 <= 落點))
                            {
                                送的品項 += $"活動:不同品項買三送一:{arraytemp品名[i]}:-{arraytemp售價[i].ToString()}x{不同品項送的杯數.ToString()}= -{(arraytemp售價[i] * 不同品項送的杯數).ToString()}\n";
                                折扣後總價 -= (arraytemp售價[i] * 不同品項送的杯數);
                                不同品項送的杯數 -= arraytemp杯數[i];
                            }
                        }
                    }
                }
                else
                {
                    折扣後總價 = 總價;
                }

            }
            else
            {
                折扣後總價 = 總價;
            }
            lbl訂單折扣後總價.Text = string.Format("{0:C}", 折扣後總價);
        }
        #endregion
        #region 活動btn
        private void btn第二件6折_Click(object sender, EventArgs e)
        {
            if (if同商品第二件6折 == false)
            {
                btn第二件6折.BackColor = Color.Red;
                btn不同品項買三送一.BackColor = default(Color);
                if不同品項買三送一 = false;
                if同商品第二件6折 = true;
                折數 = 10.0;
                tb折數.Text = "";
                tb折數.Enabled = false;
                計算總價();
                MessageBox.Show("同商品第二件6折活動開啟");
            }
            else
            {
                if同商品第二件6折 = false;
                btn第二件6折.BackColor = default(Color);
                計算總價();
                tb折數.Enabled = true;
                MessageBox.Show("活動關閉");
            }
        }

        private void btn不同品項買三送一_Click(object sender, EventArgs e)
        {
            if (if不同品項買三送一 == false)
            {
                btn不同品項買三送一.BackColor = Color.Red;
                btn第二件6折.BackColor = default(Color);
                if同商品第二件6折 = false;
                if不同品項買三送一 = true;
                折數 = 10.0;
                tb折數.Text = "";
                tb折數.Enabled = false;
                計算總價();
                MessageBox.Show("不同品項買三送一活動開啟");
            }
            else
            {
                if不同品項買三送一 = false;
                btn不同品項買三送一.BackColor = default(Color);
                計算總價();
                tb折數.Enabled = true;
                MessageBox.Show("活動關閉");
            }

        }
        #endregion
    }
}
