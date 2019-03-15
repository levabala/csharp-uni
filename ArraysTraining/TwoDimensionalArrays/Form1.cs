using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwoDimensionalArrays
{
    public partial class Form1 : Form
    {
        Dictionary<string, Entity> entities = new Dictionary<string, Entity>()
        {
          
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxMain.SelectionStart = textBoxMain.Text.Length;
        }

        private void updateEntity(string name, Entity value)
        {
            entities[name] = value;
        }

        private void sendCurrentLine()
        {
            string[] lines = textBoxMain.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            string res = run(lines.Last());

            println(res);
            waitForCommand();
        }

        private string run(string input)
        {
            try
            {
                Entity result = process(input.Remove(input.IndexOf('>'), 1));
                return result.getValue();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        private Entity process(string input)
        {
            string[] seq = input.Trim().Split(' ');

            string operatorKey = seq.First();

            if (!entities.ContainsKey(operatorKey))
                if (seq.Length == 2)
                {
                    Entity newEntity = new Entity(operatorKey, seq[1]);
                    updateEntity(operatorKey, newEntity);
                    return newEntity;
                }
                else
                    throw new Exception("Invalid assignment to new variable");

            Entity[] args = seq.Skip(1).Select(s => new Entity(s, s)).ToArray();
            Entity processor = entities[operatorKey];
            Entity result = processor.execute(args);

            return result;
        }

        private void textBoxMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                sendCurrentLine();
        }

        private void srcllend()
        {
            textBoxMain.SelectionStart = textBoxMain.Text.Length;
            textBoxMain.ScrollToCaret();
        }

        private void print(string s)
        {
            textBoxMain.Text += s;

            srcllend();
        }

        private void println(string s)
        {
            textBoxMain.Text += s + "\r\n";

            srcllend();
        }

        private void waitForCommand()
        {
            textBoxMain.Text += "\r\n> ";

            srcllend();
        }
    }
}
