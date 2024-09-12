using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace ReadExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Init();

            AddEvent();
        }

        public Form1(string[] args)
        {
            if (args.Length <= 1)
            {
                return;
            }

            string savePath = args[0];
            for (int i = 1; i < args.Length; ++i)
            {
                ReadWrite(args[i], savePath);
            }

            //this.Close();

            System.Environment.Exit(0);
        }

        private void AddEvent()
        {
            this.PathText.DragEnter += PathText_DragEnter;
            this.PathText.DragDrop += PathText_DragDrop;

            this.SavePath.DragEnter += SavePath_DragEnter;
            this.SavePath.DragDrop += SavePath_DragDrop;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.PathText.Text))
            {
                MessageBox.Show("请选择需要导出的文件");
                return;
            }

            if (string.IsNullOrEmpty(this.SavePath.Text))
            {
                MessageBox.Show("请选择保存XML的路径");
                return;
            }

            ReadWrite(this.PathText.Text, this.SavePath.Text);

            ReplacePathFile();
        }

        private void ReadWrite(string readPath, string savePath)
        {
            ReadExcelClass readExcelClass = new ReadExcelClass();
            Dictionary<int, List<List<string>>> dataDic = readExcelClass.Read(readPath);
            readExcelClass.SaveCsToFile(savePath);
            //WriteXmlClass writeXmlClass = new WriteXmlClass();
            //writeXmlClass.CreateXML(dataDic, this.SavePath.Text);
            WriteCSVClass writeCSVClass = new WriteCSVClass();
            writeCSVClass.CreateCSV(dataDic, savePath);
        }

        private void PathText_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void PathText_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void PathText_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            this.PathText.Text = path;
        }

        private void SelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            if (pathList.Count >= 1)
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(pathList[0]);
            }
            else
            {
                openFileDialog.InitialDirectory = "d:\\";//注意这里写路径时要用c:\\而不是c:\
            }

            openFileDialog.Filter = "Excel文件|*.xlsx*"; // "Excel文件|*.xlsx*|Excel文件|*.xls*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.PathText.Text = openFileDialog.FileName;
            }
        }

        private void SelectSavePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择保存XML路径";
            if (pathList.Count >= 2)
            {
                dialog.SelectedPath = pathList[1];
            }

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foldPath = dialog.SelectedPath;
                if (string.IsNullOrEmpty(foldPath))
                {
                    MessageBox.Show("请选择有效的路径");
                    return;
                }

                this.SavePath.Text = foldPath;
            }
        }

        private void SavePath_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void SavePath_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            this.SavePath.Text = Path.GetDirectoryName(path);
        }

        private static readonly string pathFile = "Path.txt";
        private List<string> pathList = new List<string>();
        private void Init()
        {
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

            ReadOpenPathFile readOpenPathFile = new ReadOpenPathFile();
            pathList.Clear();
            pathList = readOpenPathFile.Read(path + pathFile);
        }

        private void ReplacePathFile()
        {
            ReadOpenPathFile readOpenPathFile = new ReadOpenPathFile();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            path = path + pathFile;
            readOpenPathFile.Delete(path);

            List<string> pathList = new List<string>();
            pathList.Add(this.PathText.Text);
            pathList.Add(this.SavePath.Text);

            readOpenPathFile.Write(path, pathList);
        }
    }
}
