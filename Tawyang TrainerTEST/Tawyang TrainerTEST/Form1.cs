using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Tawyang_TrainerTEST
{
    public partial class Form1 : Form
    {
        int ProcessID = 0;
        Process kogProc;
        // Cheats
        Cheat CheatBazooka = new Cheat();
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadAllCheats()
        {
            // CheatName
            CheatBazooka.ScanCode = "49 8D 45 B0 83 EC 08 51 50 E8";
            CheatBazooka.ChangeToCode = "90 8D 45 B0 83 EC 08 51 50 E8";
            CheatBazooka.AddressAlign = 0x17E97BD5;
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAllCheats();
        }

        private void timerProcess_Tick(object sender, EventArgs e)
        {
            Process[] kogProcs = Process.GetProcessesByName("kogama");
            if (kogProcs.Length == 0)
            {
                if (ProcessID != 0)
                {
                    // Reset Cheats - KoGaMa Offline
                }
                ProcessID = 0;
            }
            else
            {
                kogProc = kogProcs[0];
                if (ProcessID != kogProc.Id)
                {
                    // Process Found - KoGaMa Online
                    ProcessID = kogProc.Id;
                }
                ProcessID = kogProc.Id;

            }
        }



        private void checkBazooka_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBazooka.Checked)
            {
                CheatBazooka.ScanCheat(kogProc);
                if (CheatBazooka.Found)
                {
                    CheatBazooka.ActivateCheat(kogProc);
                }
                else
                {
                    checkBazooka.CheckState = System.Windows.Forms.CheckState.Unchecked;
                }
            }
            else
            {
                if (CheatBazooka.Found)
                {
                    CheatBazooka.DeactivateCheat(kogProc);
                }
            }

        }
    }
}

