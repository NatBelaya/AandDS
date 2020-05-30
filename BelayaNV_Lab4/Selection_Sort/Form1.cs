using System;
using System.IO;
using System.Windows.Forms;

namespace Sort_Form
{
	
	public partial class Form1 : Form
    {
        private int[] values;
		public static System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
		public static string selected_sort = "";

		public Form1()
        {
            InitializeComponent();
            inpSize.SelectedIndex = 0;
        }

        /*TODO: switch to file*/
        private void getUps_Click(object sender, EventArgs e)
        {
            input.Clear();
            int size = int.Parse(inpSize.Text);
            values = new int[size];
            for (int i = 0; i < size; i++)
            {
                values[i] = i;

			}
            input.Text += $"Filled array with {size} increasing elements";
			sortButton.Enabled = true;
		}

		private void getDwns_Click(object sender, EventArgs e)
        {
            input.Clear();
            int size = int.Parse(inpSize.Text);
            values = new int[size];
            int j = 0;
            for (int i = size; i > 0; i--, j++)
            {
                values[j] = i;
            }
			input.Text += $"Filled array with {size} decreasing elements";
			sortButton.Enabled = true;
		}

        private void getRand_Click(object sender, EventArgs e)
        {
            input.Clear();
            Random rand = new Random();
            int size = int.Parse(inpSize.Text);
            values = new int[size];
            int value;
            for(int i = 0; i <size; i++)
            {
                value = rand.Next(0, 2*size);
                //input.Text += value + " ";
                values[i] = value;
            }
			input.Text += $"Filled array with {size} random elements";
			sortButton.Enabled = true;
		}

        private void sortButton_Click(object sender, EventArgs e)
        {
            output.Clear();
			watch.Reset();
			sortButton.Enabled = false;
			Sorter.swap_times = 0;
			Sorter.compare_times = 0;
            //---
            if(selection.Checked)
            {
				selected_sort = "Selection sort";
				watch.Start();
				Sorter.sort_Selection(values);
				watch.Stop();
				fillOutput();

				//output.Text += $"Compared {compare_times} times; Swapped {swap_times} times";
			}

            if(insertion.Checked)
            {
				selected_sort = "Insertion sort";
				watch.Start();
				Sorter.sort_Insertion(values);
				watch.Stop();
				fillOutput();
				//output.Text += $"Compared {compare_times} times; Swapped {swap_times} times";
			}

            if(swap.Checked)
            {
				selected_sort = "Exchange sort";
				watch.Start();
				Sorter.sort_Swap(values);
				watch.Stop();
				fillOutput();
				//output.Text += $"Compared {compare_times} times; Swapped {swap_times} times";
			}
            
            if(quick.Checked)
            {
				selected_sort = "Quick sort";
				watch.Start();
				Sorter.Quick_Sort(values, 0, values.Length - 1);
				watch.Stop();
				fillOutput();
			}
            
            if(custom.Checked)
            {
				selected_sort = "Address sort";
				// swap_times, as well as compare_times (partially), depends on sub-arrays sorting array choice
				string[] string_values = Sorter.CustomPrep(values);
				watch.Start();
				values = Sorter.Custom_Sort(string_values);
				watch.Stop();
				//convert(string_values);
				fillOutput();

			}
		}

		/* redundant */
		/*
		private void convert(string[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				values[i] = int.Parse(array[i]);
			}
		}*/

		private void fillOutput()
		{
			// time logged int excel table was captured without the use of compare_times and swap_times
			#region testing_output
			//foreach (var item in values)
			//{
			//	output.Text += item + " ";
			//}

			//output.Text +=Environment.NewLine + values[0].ToString($"D{8}");

			#endregion
			output.Text += selected_sort + "; " + inpSize.Text + " elements";
			output.Text += Environment.NewLine + $"Compared:{Sorter.compare_times}, Swapped:{Sorter.swap_times}, time (ticks):{watch.ElapsedTicks}";
		}
	}
}
