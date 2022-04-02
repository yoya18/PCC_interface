using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MLApp;
using System.IO;
using MathWorks;
using MathWorks.MATLAB;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;


namespace PCC_Calibration_interface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Width = 1060;
            this.Height = 590;
            chart1.ChartAreas[0].AxisX.Minimum = -40;
            chart1.ChartAreas[0].AxisX.Maximum = 5;
            chart1.ChartAreas[0].AxisX.Title = "相对速度"; //设置X轴名称
            chart1.ChartAreas[0].AxisY.Title = "归一化后相对时距"; //设置Y轴名称
            chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            double bon = 0.3;
            //Series[0]是L1
            chart1.Series[0].Points.AddXY(-40, 1);
            chart1.Series[0].Points.AddXY(-35, 0.999);
            chart1.Series[0].Points.AddXY(-20, 0.998);
            chart1.Series[0].Points.AddXY(-4, bon);
            chart1.Series[0].Points.AddXY(-3, 0.9 * bon);
            chart1.Series[0].Points.AddXY(0, 0.8 * bon);
            chart1.Series[0].Points.AddXY(0.5, 0);
            //Series[1]是L2
            chart1.Series[1].Points.AddXY(-40, 1);
            chart1.Series[1].Points.AddXY(-4, 1);
            chart1.Series[1].Points.AddXY(-4, 0.8);
            chart1.Series[1].Points.AddXY(-2, (0.8 - bon) / 4 + bon);
            chart1.Series[1].Points.AddXY(0, 0.3);
            chart1.Series[1].Points.AddXY(2, 0);
            //Series[2]是L3
            chart1.Series[2].Points.AddXY(-40, 1);
            chart1.Series[2].Points.AddXY(-4, 1);
            chart1.Series[2].Points.AddXY(0, 0.5 * (bon + 1));
            chart1.Series[2].Points.AddXY(3, 0.5 * bon);
            chart1.Series[2].Points.AddXY(5, 0);


        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            OpenFileDialog file1 = new OpenFileDialog(); //定义新的文件打开位置控件
            file1.Filter = "文本文件|*.txt"; //设置文件后缀的过滤
            if (file1.ShowDialog() == DialogResult.OK) //如果有选择打开文件
            {
                textBox39.Text = file1.SafeFileName;
            }
        }

        private void textBox39_TextChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ControlPointString1 = textBox9.Text;
            Single ControlPointFloat1;
            if (ControlPointString1 == "")
            {
                ControlPointFloat1 = 0;
            }
            else
            {
                ControlPointFloat1 = Single.Parse(ControlPointString1);
            }
            string ControlPointString2 = textBox10.Text;
            Single ControlPointFloat2;
            if (ControlPointString2 == "")
            {
                ControlPointFloat2 = 0;
            }
            else
            {
                ControlPointFloat2 = Single.Parse(ControlPointString2);
            }
            string ControlPointString3 = textBox11.Text;
            Single ControlPointFloat3;
            if (ControlPointString3 == "")
            {
                ControlPointFloat3 = 0;
            }
            else
            {
                ControlPointFloat3 = Single.Parse(ControlPointString3);
            }
            if ((ControlPointFloat1 <= 0.2 && ControlPointFloat1 >= 0) && (ControlPointFloat2 <= 0.2 && ControlPointFloat2 >= 0) && (ControlPointFloat3 <= 0.2 && ControlPointFloat3 >= 0))
            {
                foreach(var series in chart1.Series)
               {
                    series.Points.Clear();
                }
                double bon = 0.3;
                //Series[0]是L1
                chart1.Series[0].Points.AddXY(-40, 1);
                chart1.Series[0].Points.AddXY(-35, 0.999);
                chart1.Series[0].Points.AddXY(-20, 0.998 - ControlPointFloat1);
                chart1.Series[0].Points.AddXY(-4, bon);
                chart1.Series[0].Points.AddXY(-3, 0.9 * bon);
                chart1.Series[0].Points.AddXY(0, 0.8 * bon);
                chart1.Series[0].Points.AddXY(0.5, 0);
                //Series[1]是L2
                chart1.Series[1].Points.AddXY(-40, 1);
                chart1.Series[1].Points.AddXY(-4, 1);
                chart1.Series[1].Points.AddXY(-4, 0.8 - ControlPointFloat2);
                chart1.Series[1].Points.AddXY(-2, (0.8 - bon) / 4 + bon);
                chart1.Series[1].Points.AddXY(0, 0.3);
                chart1.Series[1].Points.AddXY(2, 0);
                //Series[2]是L3
                chart1.Series[2].Points.AddXY(-40, 1);
                chart1.Series[2].Points.AddXY(-4, 1);
                chart1.Series[2].Points.AddXY(0, 0.5 * (bon + 1) - ControlPointFloat3);
                chart1.Series[2].Points.AddXY(3, 0.5 * bon);
                chart1.Series[2].Points.AddXY(5, 0);
            }
            else
            {
                MessageBox.Show("超出范围！");
            }

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboBox7.SelectedIndex == 1) && (comboBox8.SelectedIndex == 0))
            {
                textBox12.Text = "1658";
                comboBox4.SelectedIndex = 0;
                textBox15.Text = "2710";
                textBox21.Text = "2.58";
                textBox14.Text = "0.373";
                textBox13.Text = "364";
                textBox23.Text = "395";
                comboBox6.SelectedIndex = 5;
                textBox29.Text = "4.044";
                textBox31.Text = "2.371";
                textBox32.Text = "1.556";
                textBox34.Text = "1.159";
                textBox33.Text = "0.852";
                textBox30.Text = "0.672";
                textBox28.Text = "3.193";
                textBox22.Text = "4.103";
                textBox35.Text = "1997";
                textBox37.Text = "6500";
                textBox38.Text = "200";
                textBox36.Text = "720";
                textBox9.Text = "0";
                textBox10.Text = "0";
                textBox11.Text = "0";
                // 标定区参数默认值 跟车
                trackBar10.Value = 7;
                textBox5.Text = "7";
                comboBox2.SelectedIndex = 1;
                trackBar7.Value = 18;
                textBox18.Text = "1.8";
                trackBar8.Value = 50;
                textBox19.Text = "0.05";
                trackBar9.Value = 18;
                textBox20.Text = "0.18";
                // 标定区参数默认值 非跟车
                trackBar1.Value = 15;
                textBox16.Text = "15";
                comboBox1.SelectedIndex = 1;
                trackBar4.Value = 5;
                textBox3.Text = "0.05";
                trackBar5.Value = 18;
                textBox4.Text = "0.18";
                // 标定区参数默认值 算法
                textBox2.Text = "20";
                trackBar2.Value = 20;
                textBox24.Text = "0.2";
                trackBar6.Value = 20;
                textBox17.Text = "500";
                trackBar3.Value = 50;
                // 仿真设置区
                comboBox3.SelectedIndex = 0;
                comboBox5.SelectedIndex = 0;
            } 
            else
            {
                textBox12.Text = "";
                comboBox4.SelectedIndex = 0;
                textBox15.Text = "";
                textBox21.Text = "";
                textBox14.Text = "";
                textBox13.Text = "";
                textBox23.Text = "";
                comboBox6.SelectedIndex = 0;
                textBox29.Text = "";
                textBox31.Text = "";
                textBox32.Text = "";
                textBox34.Text = "";
                textBox33.Text = "";
                textBox30.Text = "";
                textBox28.Text = "";
                textBox22.Text = "";
                textBox35.Text = "";
                textBox37.Text = "";
                textBox38.Text = "";
                textBox36.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                // 标定区参数默认值 跟车
                trackBar10.Value = 3;
                textBox5.Text = "";
                comboBox2.SelectedIndex = 0;
                trackBar7.Value = 10;
                textBox18.Text = "";
                trackBar8.Value = 1;
                textBox19.Text = "";
                trackBar9.Value = 12;
                textBox20.Text = "";
                // 标定区参数默认值 非跟车
                trackBar1.Value = 10;
                textBox16.Text = "";
                comboBox1.SelectedIndex = 0;
                trackBar4.Value = 1;
                textBox3.Text = "";
                trackBar5.Value = 4;
                textBox4.Text = "";
                // 标定区参数默认值 算法
                textBox2.Text = "";
                trackBar2.Value = 0;
                textBox24.Text = "";
                trackBar6.Value = 5;
                textBox17.Text = "";
                trackBar3.Value = 5;
                // 仿真设置区
                comboBox3.SelectedIndex = 0;
                comboBox5.SelectedIndex = 0;
            }

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboBox7.SelectedIndex == 1) && (comboBox8.SelectedIndex == 0))
            {
                // 参数区参数默认值
                textBox12.Text = "1658";
                comboBox4.SelectedIndex = 0;
                textBox15.Text = "2710";
                textBox21.Text = "2.58";
                textBox14.Text = "0.373";
                textBox13.Text = "364";
                textBox23.Text = "395";
                comboBox6.SelectedIndex = 5;
                textBox29.Text = "4.044";
                textBox31.Text = "2.371";
                textBox32.Text = "1.556";
                textBox34.Text = "1.159";
                textBox33.Text = "0.852";
                textBox30.Text = "0.672";
                textBox28.Text = "3.193";
                textBox22.Text = "4.103";
                textBox35.Text = "1997";
                textBox37.Text = "6500";
                textBox38.Text = "200";
                textBox36.Text = "720";
                textBox9.Text = "0";
                textBox10.Text = "0";
                textBox11.Text = "0";
                // 标定区参数默认值 跟车
                trackBar10.Value = 7;
                textBox5.Text = "7";
                comboBox2.SelectedIndex = 1;
                trackBar7.Value = 18;
                textBox18.Text = "1.8";
                trackBar8.Value = 50;
                textBox19.Text = "0.05";
                trackBar9.Value = 18;
                textBox20.Text = "0.18";
                // 标定区参数默认值 非跟车
                trackBar1.Value = 15;
                textBox16.Text = "15";
                comboBox1.SelectedIndex = 1;
                trackBar4.Value = 5;
                textBox3.Text = "0.05";
                trackBar5.Value = 18;
                textBox4.Text = "0.18";
                // 标定区参数默认值 算法
                textBox2.Text = "20";
                trackBar2.Value = 20;
                textBox24.Text = "0.2";
                trackBar6.Value = 20;
                textBox17.Text = "500";
                trackBar3.Value = 50;
                // 仿真设置区
                comboBox3.SelectedIndex = 0;
                comboBox5.SelectedIndex = 0;
            }
            else
            {
                textBox12.Text = "";
                comboBox4.SelectedIndex = 0;
                textBox15.Text = "";
                textBox21.Text = "";
                textBox14.Text = "";
                textBox13.Text = "";
                textBox23.Text = "";
                comboBox6.SelectedIndex = 0;
                textBox29.Text = "";
                textBox31.Text = "";
                textBox32.Text = "";
                textBox34.Text = "";
                textBox33.Text = "";
                textBox30.Text = "";
                textBox28.Text = "";
                textBox22.Text = "";
                textBox35.Text = "";
                textBox37.Text = "";
                textBox38.Text = "";
                textBox36.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                // 标定区参数默认值 跟车
                trackBar10.Value = 3;
                textBox5.Text = "";
                comboBox2.SelectedIndex = 0;
                trackBar7.Value = 10;
                textBox18.Text = "";
                trackBar8.Value = 1;
                textBox19.Text = "";
                trackBar9.Value = 12;
                textBox20.Text = "";
                // 标定区参数默认值 非跟车
                trackBar1.Value = 10;
                textBox16.Text = "";
                comboBox1.SelectedIndex = 0;
                trackBar4.Value = 1;
                textBox3.Text = "";
                trackBar5.Value = 4;
                textBox4.Text = "";
                // 标定区参数默认值 算法
                textBox2.Text = "";
                trackBar2.Value = 0;
                textBox24.Text = "";
                trackBar6.Value = 5;
                textBox17.Text = "";
                trackBar3.Value = 5;
                // 仿真设置区
                comboBox3.SelectedIndex = 0;
                comboBox5.SelectedIndex = 0;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("http://ieeexplore.ieee.org/stamp/stamp.jsp?arnumber=8468109");
        }

        private void trackBar10_Scroll(object sender, EventArgs e)
        {
            textBox5.Text = trackBar10.Value.ToString();
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            double aa = trackBar7.Value;
            double bb = aa / 10;
            textBox18.Text = bb.ToString();
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            double aa = trackBar8.Value;
            double bb = aa / 100;
            textBox19.Text = bb.ToString();
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            double aa = trackBar9.Value;
            double bb = aa / 10;
            textBox20.Text = bb.ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double aa = trackBar1.Value;
            double bb = aa;
            textBox16.Text = bb.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            double aa = trackBar4.Value;
            double bb = aa / 100;
            textBox3.Text = bb.ToString();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            double aa = trackBar5.Value;
            double bb = aa / 10;
            textBox4.Text = bb.ToString();
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            MLApp.MLApp matlab = null;
            Type matlabAppType = System.Type.GetTypeFromProgID("Matlab.Application");
            matlab = System.Activator.CreateInstance(matlabAppType) as MLApp.MLApp;
            string path_project = Directory.GetCurrentDirectory();
            string path_matlab = "cd('" + path_project + "')";
            matlab.Visible = 0;
            //matlab.Execute("desktop");
            matlab.Execute(path_matlab);
            matlab.Execute("clear all");
            matlab.Execute("open_system('PCC_Calibration_Simu')");

            // 获取界面参数
            double massVeh;//整备质量
            double.TryParse(textBox12.Text, out massVeh);
            double dd_m = massVeh;
            object outArray_m = (object)dd_m;
            matlab.PutWorkspaceData("massVeh", "base", outArray_m);
            double frontArea;//迎风面积
            double.TryParse(textBox21.Text, out frontArea);
            double dd_fa = frontArea;
            object outArray_fa = (object)dd_fa;
            matlab.PutWorkspaceData("frontArea", "base", outArray_fa);
            double aeroDragCoeff;//风阻系数
            double.TryParse(textBox14.Text, out aeroDragCoeff);
            double dd_adc = aeroDragCoeff;
            object outArray_adc = (object)dd_adc;
            matlab.PutWorkspaceData("aeroDragCoeff", "base", outArray_adc);
            double wheelRadius;//迎风面积
            double.TryParse(textBox13.Text, out wheelRadius);
            double dd_wr = wheelRadius;
            object outArray_wr = (object)dd_wr;
            matlab.PutWorkspaceData("wheelRadius", "base", outArray_wr);
            double G1;//一档速比
            double.TryParse(textBox29.Text, out G1);
            double dd_g1 = G1;
            object outArray_g1 = (object)dd_g1;
            matlab.PutWorkspaceData("G1", "base", outArray_g1);
            double G2;//二档速比
            double.TryParse(textBox31.Text, out G2);
            double dd_g2 = G2;
            object outArray_g2 = (object)dd_g2;
            matlab.PutWorkspaceData("G2", "base", outArray_g2);
            double G3;//三档速比
            double.TryParse(textBox32.Text, out G3);
            double dd_g3 = G3;
            object outArray_g3 = (object)dd_g3;
            matlab.PutWorkspaceData("G3", "base", outArray_g3);
            double G4;//四档速比
            double.TryParse(textBox34.Text, out G4);
            double dd_g4 = G4;
            object outArray_g4 = (object)dd_g4;
            matlab.PutWorkspaceData("G4", "base", outArray_g4);
            double G5;//五档速比
            double.TryParse(textBox33.Text, out G5);
            double dd_g5 = G5;
            object outArray_g5 = (object)dd_g5;
            matlab.PutWorkspaceData("G5", "base", outArray_g5);
            double G6;//六档速比
            double.TryParse(textBox30.Text, out G6);
            double dd_g6 = G6;
            object outArray_g6 = (object)dd_g6;
            matlab.PutWorkspaceData("G6", "base", outArray_g6);
            double FD;//主减速比
            double.TryParse(textBox22.Text, out FD);
            double dd_fd = FD;
            object outArray_fd = (object)dd_fd;
            matlab.PutWorkspaceData("FD", "base", outArray_fd);
            double keyPoint1;// 调度图控制点1
            double.TryParse(textBox9.Text, out keyPoint1);
            double dd_kp1 = keyPoint1;
            object outArray_kp1 = (object)dd_kp1;
            matlab.PutWorkspaceData("keyPoint1", "base", outArray_kp1);
            double keyPoint2;// 调度图控制点2
            double.TryParse(textBox10.Text, out keyPoint2);
            double dd_kp2 = keyPoint2;
            object outArray_kp2 = (object)dd_kp2;
            matlab.PutWorkspaceData("keyPoint2", "base", outArray_kp2);
            double keyPoint3;// 调度图控制点3
            double.TryParse(textBox11.Text, out keyPoint3);
            double dd_kp3 = keyPoint3;
            object outArray_kp3 = (object)dd_kp3;
            matlab.PutWorkspaceData("keyPoint3", "base", outArray_kp3);
            double predPeriodf;// 跟车模式下预测时域
            double.TryParse(textBox5.Text, out predPeriodf);
            double dd_ppf = predPeriodf;
            object outArray_ppf = (object)dd_ppf;
            matlab.PutWorkspaceData("predPeriodf", "base", outArray_ppf);
            double predPeriods;// 非跟车模式下预测时域
            double.TryParse(textBox16.Text, out predPeriods);
            double dd_pps = predPeriods;
            object outArray_pps = (object)dd_pps;
            matlab.PutWorkspaceData("predPeriods", "base", outArray_pps);
            double discIntervalf;// 跟车模式下离散时间
            double.TryParse(comboBox2.Text, out discIntervalf);
            double dd_dif = discIntervalf;
            object outArray_dif = (object)dd_dif;
            matlab.PutWorkspaceData("discIntervalf", "base", outArray_dif);
            double discIntervals;// 非跟车模式下离散时间
            double.TryParse(comboBox1.Text, out discIntervals);
            double dd_dis = discIntervals;
            object outArray_dis = (object)dd_dis;
            matlab.PutWorkspaceData("discIntervals", "base", outArray_dis);
            double terminTimedis;// 跟车模式下终端时距
            double.TryParse(textBox18.Text, out terminTimedis);
            double dd_tts = terminTimedis;
            object outArray_tts = (object)dd_tts;
            matlab.PutWorkspaceData("terminTimedis", "base", outArray_tts);
            double terminVeloweif;// 跟车模式下终端速度权重
            double.TryParse(textBox19.Text, out terminVeloweif);
            double dd_tvwf = terminVeloweif;
            object outArray_tvwf = (object)dd_tvwf;
            matlab.PutWorkspaceData("terminVeloweif", "base", outArray_tvwf);
            double terminVeloweis;// 非跟车模式下终端速度权重
            double.TryParse(textBox3.Text, out terminVeloweis);
            double dd_tvws = terminVeloweis;
            object outArray_tvws = (object)dd_tvws;
            matlab.PutWorkspaceData("terminVeloweis", "base", outArray_tvws);
            double powerWeif;// 跟车模式下动力性权重
            double.TryParse(textBox20.Text, out powerWeif);
            double dd_pwf = powerWeif;
            object outArray_pwf = (object)dd_pwf;
            matlab.PutWorkspaceData("powerWeif", "base", outArray_pwf);
            double powerWeis;// 非跟车模式下动力性权重
            double.TryParse(textBox4.Text, out powerWeis);
            double dd_pws = powerWeis;
            object outArray_pws = (object)dd_pws;
            matlab.PutWorkspaceData("powerWeis", "base", outArray_pws);
            double iterNum;// 迭代次数
            double.TryParse(textBox2.Text, out iterNum);
            double dd_in = iterNum;
            object outArray_in = (object)dd_in;
            matlab.PutWorkspaceData("iterNum", "base", outArray_in);
            double terminThreshold;// 迭代次数
            double.TryParse(textBox24.Text, out terminThreshold);
            double dd_tt = terminThreshold;
            object outArray_tt = (object)dd_tt;
            matlab.PutWorkspaceData("terminThreshold", "base", outArray_tt);
            double lambdaRange;// 初始Lambda范围
            double.TryParse(textBox17.Text, out lambdaRange);
            double dd_lr = lambdaRange;
            object outArray_lr = (object)dd_lr;
            matlab.PutWorkspaceData("lambdaRange", "base", outArray_lr);

            // 运行
            matlab.Execute("sim('PCC_Calibration_Simu');");

            // 结果
            object fuel;//油耗性能分析
            matlab.GetWorkspaceData("fuel", "base", out fuel);
            double[,] d_fuel = (double[,])fuel;
            textBox7.Text = (d_fuel[137300, 0]*100).ToString();
            matlab.Execute("single delta_dis_std");//跟车性能分析
            matlab.Execute("delta_dis_std = std(delta_dis)");
            object result_dis;
            matlab.GetWorkspaceData("delta_dis_std", "base", out result_dis);
            textBox6.Text = result_dis.ToString();
            string d_dis = result_dis.ToString();
            double d_dis_d = Convert.ToDouble(d_dis);
            matlab.Execute("acc_std = std(acc)");//加速性能分析
            object acc;
            matlab.GetWorkspaceData("acc_std", "base", out acc);
            textBox8.Text = acc.ToString();
            string d_acc = acc.ToString();
            double d_acc_d = Convert.ToDouble(d_acc);
            object computation;//计算负载分析
            matlab.GetWorkspaceData("computation", "base", out computation);
            double[,] d_com = (double[,])computation;
            textBox1.Text = d_com[137300, 0].ToString();
            //画四边形图
            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }
            chart2.Series[0].Points.AddXY("节油效果", (d_fuel[137300,0]-0.08)/0.04*100);
            chart2.Series[0].Points.AddXY("跟车距离效果", (d_dis_d-80.0)/15*100);
            chart2.Series[0].Points.AddXY("动力性效果", (d_acc_d-0.3)/0.2*100);
            chart2.Series[0].Points.AddXY("计算负载", (d_com[137300,0]-10)/40*100);
            chart2.ChartAreas[0].AxisX.LabelStyle.Font = new Font("仿宋", 8, FontStyle.Regular);
            chart2.ChartAreas[0].AxisY.LabelStyle.Font = new Font("仿宋", 8, FontStyle.Regular);

        }

        private void button13_Click(object sender, EventArgs e)
        {
            MLApp.MLApp matlab = null;
            Type matlabAppType = System.Type.GetTypeFromProgID("Matlab.Application");
            matlab = System.Activator.CreateInstance(matlabAppType) as MLApp.MLApp;
            string command = string.Empty;
            string path_project = Directory.GetCurrentDirectory();
            string path_matlab = "cd('" + path_project + "')";
            matlab.Visible = 0;
            matlab.Execute(path_matlab);
            matlab.Execute("clear all");
            command = @"[a] = open(1)";
            matlab.Execute(command);
            //double[,] dd = new double[1, 5];
            //for (int i = 5; i > 0; i--)
            //{
            // dd[0, 5 - i] = i;
            // }
            //object outArray = (object)dd;
            //matlab.PutWorkspaceData("b", "base", outArray);
            //double massVeh;
            //double.TryParse(textBox12.Text, out massVeh);
            //matlab.Execute("hws = get_param(bdroot, 'modelworkspace')");
            //matlab.Execute("hws.assignin('massVeh', massVeh);");
            System.Array pr = new double[4];
            pr.SetValue(11, 0);
            pr.SetValue(12, 1);
            pr.SetValue(13, 2);
            pr.SetValue(14, 3);

            System.Array pi = new double[4];
            pi.SetValue(1, 0);
            pi.SetValue(2, 1);
            pi.SetValue(3, 2);
            pi.SetValue(4, 3);

            matlab.PutFullMatrix("a", "base", pr, pi);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            double aa = trackBar2.Value;
            double bb = aa;
            textBox2.Text = bb.ToString();
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            double aa = trackBar6.Value;
            double bb = aa / 100;
            textBox24.Text = bb.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            double aa = trackBar3.Value;
            double bb = aa * 10;
            textBox17.Text = bb.ToString();
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
