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
        private string checkedTaskKey = "task1";
        private Dictionary<string, string> taskInfo = new Dictionary<string, string>()
        {
            {"task1", "Сдвинуть массив на х" },
            {"task2", "Среднее арифметическое наибольшего промежутка монотонности" },
            {"task3", "Проверка чередования положительных/отрицательных чисел" },
            {"task4", "Максимальное кол-во одинаковых чисел" },
            {"task5", "Определить кол-во простых чисел" },
            {"task6", "Бинарный поиск" },
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            processors = new Dictionary<string, Processor>()
            {
                {"task1", new Processor(firstTaskProcessor) },
                {"task2", new Processor(secondTaskProcessor) },
                {"task3", new Processor(thirdTaskProcessor) },
                {"task4", new Processor(fourthTaskProcessor) },
                {"task5", new Processor(fifthTaskProcessor) },
                {"task6", new Processor(sixthTaskProcessor) },
            };

            textBoxInput.TextChanged += (s, ev) => reGenerateInput();
            textBoxTask1Amount.TextChanged += (s, ev) => calcOutput();
            radioButtonTask1Directon.CheckedChanged += (s, ev) => calcOutput();

            reGenerateInput();
            updateInput();
            calcOutput();

            groupBoxTasks.Controls.OfType<RadioButton>().ToList().ForEach(radioButton => radioButton.CheckedChanged += RadioButton_CheckedChanged);

            updateTasksLayout();
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            updateChoosenTask();
            updateTasksLayout();
            calcOutput();
        }

        private void updateTasksLayout()
        {
            textBoxTaskInfo.Text = taskInfo[checkedTaskKey];
        }

        private void updateChoosenTask()
        {
            RadioButton checkedRadioButton = groupBoxTasks.Controls.OfType<RadioButton>()
                           .FirstOrDefault(n => n.Checked);

            checkedTaskKey = checkedRadioButton.Text;
        }            

        private void reGenerateInput()
        {
            int[] arr = parseArrayInput(textBoxInput.Text);

            string newValue = string.Join(" ", arr);
            textBoxArrayView.Text = newValue;

            input = arr;
        }

        private void updateInput()
        {
            try
            {
                int[] arr = textBoxArrayView.Text.Trim().Split(' ').Where(val => val.Length != 0).Aggregate(new List<int>(), (acc, value) =>
                {
                    acc.Add(int.Parse(value));
                    return acc;
                }).ToArray();

                input = arr;
            }
            catch (Exception)
            {
            }
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
            Processor processor = processors[checkedTaskKey];

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

        private void textBoxArrayView_TextChanged(object sender, EventArgs e)
        {
            updateInput();
            calcOutput();
        }

        // --------- tasks part ---------
        private int[] firstTaskProcessor(int[] input)
        {
            bool rightDirection = radioButtonTask1Directon.Checked;

            int delta = rightDirection ? 1 : -1;
            int amount = Math.Abs(int.Parse(textBoxTask1Amount.Text.Trim()));

            amount -= (amount / input.Length) * input.Length;

            int offset = amount * delta;

            return input.Select((item, index) =>
            {
                int newIndex = index + offset;
                if (newIndex >= input.Length)
                    newIndex -= input.Length;
                else
                    if (newIndex < 0)
                    newIndex += input.Length;

                return new Tuple<int, int>(item, newIndex);

            }).Aggregate(new int[input.Length], (acc, item) => {
                acc[item.Item2] = item.Item1;
                return acc;
            });
        }

        private int[] secondTaskProcessor(int[] input)
        {
            List<List<int>> sequencies = new List<List<int>>() { new List<int>() };
            int previousDelta = 1;
            for (int i = 0; i < input.Length - 1; i++)
            {
                int delta = input[i + 1] - input[i];
                if (Math.Sign(delta) != previousDelta)
                    sequencies.Add(new List<int>());

                sequencies.Last().Add(input[i]);
            }

            List<int> longest = sequencies.Aggregate(sequencies[0], (acc, seq) => seq.Count > acc.Count ? seq : acc);
            int average = (int)Math.Round(longest.Sum() / (double)longest.Count);

            return new int[] { average };
        }

        private int[] thirdTaskProcessor(int[] input)
        {
            int index = -1;
            bool valid = input.All((val) =>
            {
                index++;
                return index == 0 || Math.Sign(input[index - 1]) != Math.Sign(val);
            });

            if (!valid)
                return new int[] { index };

            return input;
        }

        private int[] fourthTaskProcessor(int[] input)
        {
            int[] repeats = input.Select((val) => input.Count((otherVal) => val == otherVal)).ToArray();

            return new int[] { repeats.Max() };
        }

        private int[] fifthTaskProcessor(int[] input)
        {
            int[] createEratosfen(int from, int to)
            {
                from = Math.Max(from, 2);

                int[] range = Enumerable.Range(from, to - from + 1).ToArray();
                List<int> removed = new List<int>();

                int p = from;
                while (p < to)
                {                    
                    for (int i = 0; i < range.Length; i++)
                    {
                        int val = range[i];
                        if (val < p * 2 || removed.Contains(val))
                            continue;

                        if (val % p == 0)                        
                            removed.Add(val);                                                    
                    }

                    try
                    { 
                        p = range.First((val) => val > p && !removed.Contains(val));
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }

                int[] simpleNumbers = range.Where((val) => !removed.Contains(val)).ToArray();
                return new int[] { input.Count(val => simpleNumbers.Contains(val)) };
            }


            int[] simple = createEratosfen(input.Min(), input.Max());
            return simple;
        }

        private int[] sixthTaskProcessor(int[] input)
        {
            int? binarySearch(int target, int[] array, (int, int)? lastRange = null)
            {
                if (lastRange == null)
                    lastRange = (0, array.Length - 1);

                (int, int) range = (ValueTuple<int, int>)lastRange;
                int newIndex = range.Item1 + (range.Item2 - range.Item1) / 2;
                int nextValue = array[newIndex];

                if (nextValue == target)
                    return newIndex;                

                (int, int) newRange = target < nextValue ? (range.Item1, newIndex) : (newIndex, range.Item2);

                if (array[newRange.Item1] == target)
                    return newRange.Item1;

                if (array[newRange.Item2] == target)
                    return newRange.Item2;

                if (newRange.Item2 - newRange.Item1 < 2)
                    return null;

                return binarySearch(target, array, newRange);
            }

            int searchTarget = int.Parse(textBoxSearchTarget.Text.Trim());
            Dictionary<int, int> indexesMap = input.Aggregate(new Dictionary<int, int>(), (acc, val) => {
                acc[val] = Array.FindIndex(input, (element) => element == val);
                return acc;
                }
            );
            int[] sorted = input.OrderBy(val => val).ToArray();
            int? index = binarySearch(searchTarget, sorted);

            return new int[] { index == null ? -1 : indexesMap[sorted[(int)index]] };
        }

        private void textBoxSearchTarget_TextChanged(object sender, EventArgs e)
        {
            calcOutput();
        }
    }
}
