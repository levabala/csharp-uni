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
    public partial class Form1 : Form
    {
        

        private Dictionary<char, Func<double, double, double>> operandsMap = new Dictionary<char, Func<double, double, double>>
        {
            {Operand.Plus, (left, right) => left + right},
            {Operand.Minus, (left, right) => left - right},
            {Operand.Divide, (left, right) => left / right},
            {Operand.Multiply, (left, right) => left * right},
        };

        public Form1()
        {
            InitializeComponent();           
        }

        private string process(string s) {
            try
            {
                double res = parseAndCalc(s);

                return Math.Round(res, 5).ToString();
            }
            catch(Exception e)
            {
                return "Wrong input";
            }
        }

        private double parseAndCalc(string s)
        {
            if (s.Trim().Split(' ').Length <= 1)
                return double.Parse(s);

            OperatingTuple? tuple = parse(s);
            

            return calc(tuple.GetValueOrDefault());
        }

        private double calc(OperatingTuple tuple)
        {
            return operandsMap[tuple.operand](tuple.leftArg, tuple.rightArg);
        }

        private OperatingTuple? parse(string s)
        {
            string[] arr = s.Split(' ').Select(elem => elem.Trim()).ToArray();            

            string leftArgStr = arr[0];
            string operStr = arr[1];
            string rigthArgStr = arr[2];

            double leftArg, rightArg;

            if (!(double.TryParse(leftArgStr, out leftArg) && double.TryParse(rigthArgStr, out rightArg)))
                return null;

            if (!operandsMap.ContainsKey(operStr[0]))
                return null;

            return new OperatingTuple(leftArg, rightArg, operStr[0]);
        }

        private void TextField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)

                textBoxMain.Text = run(true, true);

        }            

        private string run(bool focus = true, bool mainUpdate = false)
        {
            int index = textBoxMain.SelectionStart;
            textBoxMain.Text = Regex.Replace(textBoxMain.Text, @"\s+", " ").TrimStart();
            textBoxMain.SelectionStart = index;

            string val = textBoxMain.Text;
            string res = process(val);
            textBoxResult.Text = res;

            if (focus)
            {
                if (mainUpdate)
                    textBoxMain.Text = res;

                textBoxMain.Focus();
                textBoxMain.SelectionStart = textBoxMain.Text.Length;
                textBoxMain.SelectionLength = 0;
            }

                return res;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            textBoxMain.Text += $" {Operand.Plus} ";
            run();
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            textBoxMain.Text += $" {Operand.Minus} ";
            run();
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            textBoxMain.Text += $" {Operand.Divide} ";
            run();
        }
        
        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            textBoxMain.Text += $" {Operand.Multiply} ";
            run();
        }

        private void textBoxMain_TextChanged(object sender, EventArgs e)
        {
            run(false);
        }
    }

    struct OperatingTuple
    {
        public double leftArg, rightArg;
        public char operand;

        public OperatingTuple(double leftArg, double rightArg, char operand)
        {
            this.leftArg = leftArg;
            this.rightArg = rightArg;
            this.operand = operand;
        }
    }

    static class Operand
    {
        public const char Plus = '+';
        public const char Minus = '-';
        public const char Divide = '/';
        public const char Multiply = '*';
    }
}
