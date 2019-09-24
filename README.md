# CrossThreadLib
.NET Library written in C# to access objects created in the UI thread from another thread.

Example of the implementation:

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


