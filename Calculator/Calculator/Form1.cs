using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private Dictionary<char, Func<double, double, double>> operandsMap = new Dictionary<char, Func<double, double, double>>
        {
            {'+', (left, right) => left + right},
            {'-', (left, right) => left - right},
            {'/', (left, right) => left / right},
            {'*', (left, right) => left * right},
        };

        public Form1()
        {
            InitializeComponent();           
        }

        private string process(string s) {
            try
            {
                double res = parseAndCalc(s);

                return Math.Round(res, 3).ToString();
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }

        private double parseAndCalc(string s)
        {
            OperatingTuple? tuple = parse(s);

            if (tuple == null)
                throw new Exception("Wrong input");

            return calc(tuple.GetValueOrDefault());
        }

        private double calc(OperatingTuple tuple)
        {
            return operandsMap[tuple.operand](tuple.leftArg, tuple.rightArg);
        }

        private OperatingTuple? parse(string s)
        {
            string[] arr = s.Split(' ');

            if (arr.Length != 3)
                return null;

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
            {
                string val = textBoxMain.Text;
                textBoxMain.Text = process(val);

                textBoxMain.SelectionStart = textBoxMain.Text.Length;
                textBoxMain.SelectionLength = 0;
            }
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
}
