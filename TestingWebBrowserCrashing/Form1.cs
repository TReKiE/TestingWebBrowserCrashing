using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.Reflection;

namespace TestingWebBrowserCrashing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // check for registry key
            bool restart = false;
            
            RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION");
            var m = rk.GetValue(System.AppDomain.CurrentDomain.FriendlyName);

            if (m == null)
            { 
                rk.SetValue(System.AppDomain.CurrentDomain.FriendlyName, 11001);
                restart = true;
            }
            rk.Close();

            if (restart)
            {
                DialogResult dr = MessageBox.Show(@"Added HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION key for executable to run in IE11 mode.  Application will now restart.", "Testing WebBrowser Crashing Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
                p.Start();
                Environment.Exit(0);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.androidpolice.com/2017/07/26/xiaomi-unveils-miui-9-improved-performance-better-resource-allocation-new-smart-assistant/");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.androidpolice.com/2017/07/26/sharp-aquos-s1-s2-bezel-less-phones-leaked-s2-reportedly-glass-fingerprint-reader/");
        }
    }
}
