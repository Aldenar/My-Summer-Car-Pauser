using System;
using System.Diagnostics;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        byte suspended = 2;
        int g_id = 0;
        string procname = "mysummercar";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            scanForGameState(procname);
            this.timer1.Enabled = true;
        }

        private void scanForGameState(string procname)
        {
            int id = -1;
            Process[] processes = Process.GetProcessesByName(procname);
            foreach (Process theprocess in processes)
            {
                if (theprocess.ProcessName == procname)
                {
                    id = theprocess.Id;
                    break;
                }
            }
            if (id != -1)
            {
                Process proc = Process.GetProcessById(id);
                switch (proc.Threads[0].ThreadState)
                {
                    case ThreadState.Initialized:
                    case ThreadState.Ready:
                    case ThreadState.Running:
                    case ThreadState.Standby:
                        stateLabel.Text = "Game is running";
                        startPauseButton.Text = "Pause the game";
                        suspended = 0;
                        g_id = proc.Id;
                        break;
                    case ThreadState.Terminated:
                        stateLabel.Text = "Game appears to have just quit - Restart me please? I am confused...";
                        startPauseButton.Visible = false;
                        suspended = 3;
                        break;
                    case ThreadState.Unknown:
                        stateLabel.Text = "Something is happening to the game's process... Uuuum... Help? Please?";
                        MessageBox.Show("I just don't know what went wrong - Please restart the game and this app and try again? If nothing helps, report to Aldar with the following info: ThreadState=" + proc.Threads[0].ThreadState);
                        startPauseButton.Visible = false;
                        suspended = 3;
                        break;
                    case ThreadState.Wait:
                        if (proc.Threads[0].WaitReason == ThreadWaitReason.Suspended)
                        {
                            stateLabel.Text = "Game is paused!";
                            startPauseButton.Text = "Resume the Game";
                            suspended = 1;
                            g_id = proc.Id;
                        }
                        else
                        {
                            if (proc.Threads[0].WaitReason == ThreadWaitReason.UserRequest)
                            {
                                stateLabel.Text = "Game is running";
                                startPauseButton.Text = "Pause the game";
                                suspended = 0;
                                g_id = proc.Id;
                            }
                        }
                        break;
                }
            }
            else
            {
                stateLabel.Text = "Game does not appear to be running!";
                startPauseButton.Text = "Rescan";
                suspended = 2;
            }
            stateLabel.Left = (this.Width / 2) - (stateLabel.Width / 2);
            startPauseButton.Left = this.Width / 2 - startPauseButton.Width / 2;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dbgProcNameBox.Text != "")
            {
                
                int id=-1;
                string procname = dbgProcNameBox.Text;               
                Process[] all = Process.GetProcessesByName(procname);
                foreach (Process theprocess in all)
                {
                    if (theprocess.ProcessName == procname)
                    {
                        id = theprocess.Id;
                        break;
                    }
                }
                
                if (id >= 0)
                {
                    Process proc = Process.GetProcessById(id);
                    if (proc.Threads[0].ThreadState == ThreadState.Wait)
                    {
                        if (proc.Threads[0].WaitReason == ThreadWaitReason.Suspended)
                        {
                            proc.Resume();
                            proc.Refresh();
                            if (proc.Threads[0].ThreadState == ThreadState.Wait)
                            {
                                if (proc.Threads[0].WaitReason == ThreadWaitReason.Suspended)
                                {
                                    stateLabel.Text= "Thread still suspended, click again or report to the dev please!";
                                }
                            }
                            stateLabel.Text = "Game is running again! If not, report it to the dev please!";                            
                        }
                    }
                                        
                    stateLabel.Left = this.Width / 2 - stateLabel.Width / 2;
                }
                else
                {
                    stateLabel.Text = "Process not Found!";
                }
            }
        }

        private void startPauseButton_Click(object sender, EventArgs e)
        {
            int l_suspended = suspended;
            switch (suspended)
            {
                case 0:
                case 1:
                    scanForGameState(procname);
                    if (l_suspended == suspended) changeGameState();
                    break;
                case 2:
                    scanForGameState(procname);
                    break;
                case 3:

                    break;
                default:

                    break;
            }
        }

        private void changeGameState()
        {
            int state_snapshot = suspended;
            Process proc = Process.GetProcessById(g_id);
            if (suspended == 0)
            {
                proc.Suspend();
            }
            else if (suspended == 1)
            {
                proc.Resume();
            }
            proc.Refresh();
            scanForGameState(procname);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            scanForGameState(procname);
        }
    }
}
