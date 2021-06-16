using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}
		//Numbers logic
		private void Number1_Click(object sender, EventArgs e)
		{
			NumericResult.Text = NumericResult.Text + "1";
		}

		private void Number2_Click(object sender, EventArgs e)
		{
			NumericResult.Text = NumericResult.Text + "2";
		}
		private void Number3_Click(object sender, EventArgs e)
		{
			NumericResult.Text = NumericResult.Text + "3";
		}

		private void Number4_Click(object sender, EventArgs e)
		{
			NumericResult.Text = NumericResult.Text + "4";
		}

		private void Number5_Click(object sender, EventArgs e)
		{
			NumericResult.Text = NumericResult.Text + "5";
		}

		private void Number6_Click(object sender, EventArgs e)
		{
			NumericResult.Text = NumericResult.Text + "6";
		}

		private void Number7_Click(object sender, EventArgs e)
		{
			NumericResult.Text = NumericResult.Text + "7";
		}

		private void Number8_Click(object sender, EventArgs e)
		{
			NumericResult.Text = NumericResult.Text + "8";
		}

		private void Number9_Click(object sender, EventArgs e)
		{
			NumericResult.Text = NumericResult.Text + "9";
		}

		

		private void Number0_Click(object sender, EventArgs e)
		{
			NumericResult.Text = NumericResult.Text + "0";
		}

		private void NumericResult_TextChanged(object sender, EventArgs e)
		{

		}
		//signs logic
		private void MultiplicationSign_Click(object sender, EventArgs e)
		{
			NumericResult.Text = NumericResult.Text + "*";
		}

		private void DivideSign_Click(object sender, EventArgs e)
		{
			NumericResult.Text = NumericResult.Text + "/";
		}

		private void MinusSign_Click(object sender, EventArgs e)
		{
			NumericResult.Text = NumericResult.Text + "-";
		}

		private void PlusSign_Click(object sender, EventArgs e)
		{
			NumericResult.Text = NumericResult.Text + "+";
		}

		private void Separator_Click(object sender, EventArgs e)
		{
			NumericResult.Text = NumericResult.Text + ".";
		}

		private void ButtonC_Click(object sender, EventArgs e)
		{
			NumericResult.Text = NumericResult.Text.Remove(NumericResult.Text.Length - 1, 1);
		}

		private void ButtonCE_Click(object sender, EventArgs e)
		{
			NumericResult.Text = "";
		}
		//equal logic
		//using regular expression to validate input of NumericResult textbox.
		private void EqualSign_Click(object sender, EventArgs e)
		{
			//reg ex for validation of NumericResult
			Regex rgx = new Regex(@"([-+]?[0-9]*\.?[0-9]+[\/\+\-\*])+([-+]?[0-9]*\.?[0-9]+)");
			DataTable dt = new DataTable();
		

			if (rgx.IsMatch(NumericResult.Text))
			{
				var v = dt.Compute(NumericResult.Text, "");
				NumericResult.Text = Convert.ToString(v);
			}

			else label1.Text = "wrong input:expression can only contain numbers,brackets and arthimetic operations.\nexample:-X*(Y+Z)-X/Y";
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}
	}
}
