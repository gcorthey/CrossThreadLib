# CrossThreadLib
.NET Library written in C# to access objects created in the GUI thread from another thread. This is used in order to avoid freezing of the GUI while running some processes, i. e. the GUI continues to be responsive to the user actions.

Example of a method to get the text property of any object of the GUI.

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
        
        

To use this library, you need to use the using [`System.Threading Namespace`](https://docs.microsoft.com/en-us/dotnet/api/system.threading?view=netframework-4.8). Here there is an example of how to use the `CrossThreadLib`in your code:


        using System.Threading;
        using CrossThreadLib;
        
        private System.Threading.Tasks.Task myTask;
        cancellationTokenSource = new CancellationTokenSource();
        
        myTask = System.Threading.Tasks.Task.Factory.StartNew(() => ThreadFunction(cancellationTokenSource.Token));
        
        continueThread = True
        myThread.Start();
        private void ThreadFunction()
        {
                while (continueThread)
                {
                        //methods executed in inside myThread
                        CrossThreadsafe.SetControlText(textBox1, "This was written from myThread");
                        thread.sleep(1)
                }
                
        }
