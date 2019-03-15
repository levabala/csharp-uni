using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwoDimensionalArrayInput
{
    public partial class TwoDimArrayControl : UserControl
    {
        private int[,] dataArray = new int[,] {
            { 1, 2, 3},
            { 3, 5, 6},
            };

        public TwoDimArrayControl()
        {
            InitializeComponent();
        }

        private void TwoDimArrayControl_Load(object sender, EventArgs e)
        {

        }

        [Description("Data Array"), Category("Data")]
        public int[,] DataArray
        {
            get { return dataArray; }
            set { dataArray= value; }
        }

        private updateDataArray(int[,] newData)
        {

        }
    }
}
