using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string folder = txtAccessFileName.Text;
            if (dataSetDesigner.Tables[0].Rows.Count > 0)
            {
                dataSetDesigner.Clear();
            }
            if (txtAccessFileName.Text != null)
            {
                resultLog.Text = "";
                FileInfo direc = new FileInfo(folder);
                DirectoryInfo dir = new DirectoryInfo(folder);
                fileRecursion(dir);
            }
        }

        private void txtAccessFileName_TextChanged(object sender, EventArgs e)
        {

        }

        private void resultLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOpenAccessFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = false;
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                txtAccessFileName.Text = folderDialog.SelectedPath;
            };

        }

        private bool fileCheck(DataSet1.fileNamesRow frow)
        {
            bool fileChanged = false;
            if (File.Exists(frow.file_path))
            {
                FileInfo file = new FileInfo(frow.file_path);
                if (frow.file_length != file.Length)
                {
                    fileChanged = true;
                    fileLengthWrite(frow);
                    frow.file_hashCode = hashCodeWrite(frow);
                }
                else if (frow.file_hashCode != hashCodeWrite(frow))
                {
                    fileChanged = true;
                    frow.file_hashCode = hashCodeWrite(frow);
                }
            }
            return fileChanged;
        }

        private void fileLengthWrite(DataSet1.fileNamesRow row)
        {
            FileInfo file = new FileInfo(row.file_path);
            row.file_length = file.Length;
        }

        private string hashCodeWrite(DataSet1.fileNamesRow row)
        {
            FileInfo file = new FileInfo(row.file_path);
            HashAlgorithm fileHash = HashAlgorithm.Create();
            FileStream fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read);
            return row.file_hashCode = ByteArrayToString(fileHash.ComputeHash(fs));
        }

        public static string ByteArrayToString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }



        private void fileRecursion(DirectoryInfo dir)
        {

            foreach (FileInfo file in dir.GetFiles())
            {
                DataSet1.fileNamesRow row = dataSetDesigner.fileNames.NewfileNamesRow();
                row.file_length = file.Length;
                row.file_name = file.Name;
                row.file_path = file.FullName;
                row.file_hashCode = hashCodeWrite(row);

                resultLog.Text += file.FullName + System.Environment.NewLine;
                dataSetDesigner.fileNames.AddfileNamesRow(row);
            }
            foreach (DirectoryInfo folder in dir.GetDirectories())
            {
                fileRecursion(folder);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveXml = new SaveFileDialog();
            saveXml.Filter = "XML files|*.xml";
            saveXml.Title = "Save XML File";
            saveXml.ShowDialog();
            string path = saveXml.FileName;

            // dataSetDesigner.WriteXml(path);
            dataDuplicates.WriteXml(path);
        }
        private int getResultNumber(string file_path) {
            for (int e = 0; e < dataDuplicates.Files.Count; e++)
            {
                if (file_path == dataDuplicates.Files[e].file_path)
                {
                    return dataDuplicates.Files[e].result_number;
                }
            }
            return -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool compare = false;
            bool exists = false;
            bool dataSetChanged = true;
            int resultNumber = 0;
            while (dataSetChanged)
            {
                dataSetChanged = false;
                DataSet1.fileNamesRow[] frows = (DataSet1.fileNamesRow[])dataSetDesigner.fileNames.Select("", "file_length, file_hashCode");
                for (int i = 0; i < frows.Length; i++)
                {
                    exists = false;
                    DataSet2.ResultRow resultRow = dataDuplicates.Result.NewResultRow();
                    DataSet1.fileNamesRow row = frows[i];
                    for (int j = i + 1; j < frows.Length && frows[j].file_length == frows[i].file_length &&
                                       frows[j].file_hashCode == frows[i].file_hashCode; j++)
                    {
                        int resulti = getResultNumber(frows[i].file_path);
                        if (resulti != -1) {
                            int resultj = getResultNumber(frows[j].file_path);
                            if (resulti == resultj) {
                                continue;
                            }
                        }
                        
                        exists = false;
                        if (frows[j].file_length > 0)
                        {

                            if (fileCheck(frows[i]) || fileCheck(frows[j]))
                            {
                                dataSetChanged = true;
                            }
                            else
                            {
                                compare = true;
                                FileStream fi = new FileStream(frows[i].file_path, FileMode.Open, FileAccess.Read);
                                FileStream fj = new FileStream(frows[j].file_path, FileMode.Open, FileAccess.Read);
                                for (int p = 0; p < fi.Length; p++)
                                {
                                    if (fi.ReadByte() != fj.ReadByte())
                                    {
                                        compare = false;
                                        break;
                                    }
                                }
                                if (compare)
                                {
                                    if (getResultNumber(frows[i].file_path) == -1)
                                    {
                                        DataSet2.FilesRow fileRowi = dataDuplicates.Files.NewFilesRow();
                                        fileRowi.result_number = resultNumber;
                                        fileRowi.file_path = frows[i].file_path;
                                        dataDuplicates.Files.AddFilesRow(fileRowi);
                                    }
                                    exists = true;
                                    DataSet2.FilesRow fileRow = dataDuplicates.Files.NewFilesRow();   
                                    fileRow.result_number = resultNumber;
                                    fileRow.file_path = frows[j].file_path;
                                    dataDuplicates.Files.AddFilesRow(fileRow);
                                }
                            }
                        }                        
                    }
                    if (exists)
                    {
                        resultRow.file_hashCode = frows[i].file_hashCode;
                        resultRow.file_length = frows[i].file_length;
                        resultRow.result_number = resultNumber;
                        dataDuplicates.Result.AddResultRow(resultRow);
                        resultNumber++;
                    }
                    
                }

            }
            MessageBox.Show("დუბლიკატების ძებნის პროცესი დაკანეცდა!!!");

        }
    }
}
