using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArraysTraining
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Processor> processors;
        private int[] input;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            processors = new Dictionary<string, Processor>()
            {
                {"task1", new Processor(firstTaskProcessor) },
            };

            textBoxInput.TextChanged += (s, ev) => updateInput();
            textBoxTask1Amount.TextChanged += (s, ev) => calcOutput();
            radioButtonTask1Directon.CheckedChanged += (s, ev) => calcOutput();

            updateInput();
            calcOutput();
        }

        private int[] firstTaskProcessor(int[] input)
        {
            bool rightDirection = radioButtonTask1Directon.Checked;

            int delta = rightDirection ? 1 : -1;
            int amount = Math.Abs(int.Parse(textBoxTask1Amount.Text.Trim()));

            amount -= (input.Length / amount) * amount;

            int offset = amount * delta;

            return input.Select((item, index) =>
            {
                int newIndex = index + offset;
                if (newIndex >= input.Length)
                    newIndex -= input.Length;
                else
                    if (newIndex < 0)
                    newIndex += input.Length;

                return new Tuple<int, int>(item, index);

            }).Aggregate(new int[input.Length], (acc, item) => {
                acc[item.Item1] = item.Item2;
                return acc;
                });
        }

        private void updateInput()
        {
            int[] arr = parseArrayInput(textBoxInput.Text);

            string newValue = String.Join(" ", arr);
            textBoxArrayView.Text = newValue;

            input = arr;
        }

        private void calcOutput()
        {
            int[] result = new int[0];
            try
            {
                result = doProcessing(input);
            }
            catch (Exception)
            {
            }

            string resultValue = String.Join(" ", result);
            textBoxOutput.Text = resultValue;
        }


        private int[] doProcessing(int[] arr)
        {            
            RadioButton checkedRadioButton = groupBoxTasks.Controls.OfType<RadioButton>()
                           .FirstOrDefault(n => n.Checked);
            Processor processor = processors[checkedRadioButton.Text];

            int[] result = processor.process(arr);

            return result;
        }

        private int[] parseArrayInput(string input)
        {
            try
            {
                string[] parts = input.Split('/');

                int length = int.Parse(parts[0]);
                int from = int.Parse(parts[1]);
                int to = int.Parse(parts[2]);

                Random rnd = new Random();

                int[] array = new int[length].Select((int elem) => rnd.Next(from, to)).ToArray();
                return array;
            }
            catch (Exception)
            {
                return new int[0];
            }
        }
    }
}
