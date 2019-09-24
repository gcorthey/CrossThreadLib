# CrossThreadLib
.NET Library written in C# to access objects created in the GUI thread from another thread. This is used in order to avoid freezing of the GUI while running some processes, i. e. the GUI continues to be responsive to the user actions.

Example of the implementation to get the text property of any object of the GUI.

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


