using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Windows;
using System.Drawing;
using Microsoft.VisualBasic.PowerPacks;
using System.Windows.Forms.DataVisualization;

namespace CrossThreadLib
{
    /// <summary>
    /// ThreadSafe Class. This class allows the access to different properties of controls from a thread other than the UI thread.    /// 
    /// </summary>
    public static class CrossThread
    {
        /// <summary>
        /// Set text property of a control to given string value.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="propertyValue"></param>
        public static void SetControlText(Control control, string propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke((System.Action)(() =>
                {
                    control.Text = propertyValue;
                }));
            }
            else
            {
                control.Text = propertyValue;
            }   
        }
        /// <summary>
        /// Returns the value of the text property of the control
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static string GetControlText(Control control)
        {
            string controlText = "";

            if (control.InvokeRequired)
            {
                control.Invoke((System.Action)(() =>
                {
                    controlText = control.Text;
                }));
            }
            else
            {
                controlText = control.Text;
            }
            return controlText;
        }

        /// <summary>
        /// Append x, y data to a series of a System.Windows.Forms.DataVisualization.Charting.Chart
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="series"></param>
        /// <param name="xValue"></param>
        /// <param name="yValue"></param>
        public static void PlotAppendXY(System.Windows.Forms.DataVisualization.Charting.Chart chart, string series, double xValue, double yValue)
        {
            if (chart.InvokeRequired)
            {
                chart.Invoke((System.Action)(() =>
                {
                    chart.Series[series].Points.AddXY(xValue, yValue);                    

                }));
            }
            else
            {
                chart.Series[series].Points.AddXY(xValue, yValue);
            }
        }


        /// <summary>
        /// Change back color of the contro to given value.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="propertyValue"></param>
        public static void ChangeRectangleBackColor(RectangleShape control, Color propertyValue)
        {
            if (control.Parent.InvokeRequired)
            {
                control.Parent.Invoke((System.Action)(() =>
                {
                    control.BackColor = propertyValue;
                }));
            }
            else
            {
               control.BackColor = propertyValue;
            }
        }

        /// <summary>
        /// Enable or Disable control. If true, enable; if false, disable.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="enableOrDisable"></param>
        public static void EnableControl(Control control, bool enableOrDisable)
        {
            if (control.InvokeRequired)
            {
                control.Invoke((System.Action)(() =>
                {
                    control.Enabled = enableOrDisable;
                }));
            }
            else
            {
                control.Enabled = enableOrDisable;
            }
        }
       
        /// <summary>
        /// Set progress bar properties.
        /// </summary>
        /// <param name="toolStripName"></param>
        /// <param name="controlName"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="stepSize"></param>
        public static void SetProgressBarProperties(ToolStrip toolStripName, ToolStripProgressBar controlName, int minValue, int maxValue, int stepSize)
        {
            if (toolStripName.InvokeRequired)
            {
                toolStripName.Invoke((System.Action)(() =>
                {
                    controlName.Value = minValue;
                    controlName.Minimum = minValue;
                    controlName.Maximum = maxValue;
                    controlName.Step = stepSize;
                }));
            }
            else
            {
                controlName.Value = minValue;
                controlName.Minimum = minValue;
                controlName.Maximum = maxValue;
                controlName.Step = stepSize;
            }
        }

        /// <summary>
        /// Increment progress bar.
        /// </summary>
        /// <param name="toolStripName"></param>
        /// <param name="controlName"></param>
        public static void IncrementProgressBar(ToolStrip toolStripName, ToolStripProgressBar controlName)
        {
            if (toolStripName.InvokeRequired)
            {
                toolStripName.Invoke((System.Action)(() =>
                {
                    controlName.PerformStep();
                }));
            }
            else
            {
                controlName.PerformStep();
            }
        }


        /// <summary>
        /// Set text value of a tool strip label.
        /// </summary>
        /// <param name="toolStripName"></param>
        /// <param name="labelName"></param>
        /// <param name="text"></param>
        public static void SetTextToolStripLabel(ToolStrip toolStripName, ToolStripLabel labelName, string text)
        {
            if (toolStripName.InvokeRequired)
            {
                toolStripName.Invoke((System.Action)(() =>
                {
                    labelName.Text = text;
                }));
            }
            else
            {
                labelName.Text = text;
            }
        }


        /// <summary>
        /// Set text value of a tool strip text box.
        /// </summary>
        /// <param name="toolStripName"></param>
        /// <param name="textBoxName"></param>
        /// <param name="text"></param>
        public static void SetTextToolStripTextBox(ToolStrip toolStripName, ToolStripTextBox textBoxName, string text)
        {
            if (toolStripName.InvokeRequired)
            {
                toolStripName.Invoke((System.Action)(() =>
                {
                    textBoxName.Text = text;
                }));
            }
            else
            {
                textBoxName.Text = text;
            }
        }      


        /// <summary>
        /// Reset progress bar.
        /// </summary>
        /// <param name="control"></param>
        public static void ResetProgressBar(ProgressBar control)
        {
            if (control.InvokeRequired)
            {
                control.Invoke((System.Action)(() =>
                {
                    control.PerformStep();
                }));
            }
            else
            {
                control.PerformStep();
            }
        }
    }

}
