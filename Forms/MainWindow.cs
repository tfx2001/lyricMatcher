using lyric_matcher.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace lyric_matcher
{
    public partial class MainWindow : Form
    {
        /// <summary>
        /// 音乐文件
        /// </summary>
        private Dictionary<string, string> MusicFile = new Dictionary<string, string>();

        /// <summary>
        /// 构造函数
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 搜索按钮被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_search_Click(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += Search_bw_DoWork;
            bw.RunWorkerCompleted += Search_bw_RunWorkerCompleted;
            bw.RunWorkerAsync();
            listView1.Items.Clear();
            listBox_files.Items.Clear();
        }
        private void Search_bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateListBox();
        }
        private void Search_bw_DoWork(object sender, DoWorkEventArgs e)
        {
            MusicFile = Func.RecursiveSearch(textBox_path.Text);
        }

        /// <summary>
        /// 窗口载入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox_path.Text = Environment.CurrentDirectory;
        }

        /// <summary>
        /// 选择路径按钮被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_selectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                Description = "请选择音乐文件所在文件夹",
                SelectedPath = textBox_path.Text
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox_path.Text = dialog.SelectedPath;
            }

        }

        /// <summary>
        /// 更新文件列表
        /// </summary>
        /// <param name="fileInfo">文件信息</param>
        private void UpdateListBox()
        {
            Action action = () =>
            {
                listBox_files.Items.Clear();
                foreach (KeyValuePair<string, string> kv in MusicFile)
                {
                    listBox_files.Items.Add(kv.Key);
                }
            };
            listBox_files.Invoke(action);
        }

        /// <summary>
        /// 更新歌曲信息表格
        /// </summary>
        /// <param name="songInfo">歌曲信息</param>
        private void UpdateListView(List<Dictionary<string, string>> songInfo)
        {
            foreach (Dictionary<string, string> song in songInfo)
            {
                ListViewItem item = new ListViewItem
                {
                    Text = song["name"]
                };
                item.SubItems.Add(song["artist"]);
                item.SubItems.Add(song["id"]);
                listView1.Items.Add(item);
            }
        }

        /// <summary>
        /// 文件列表选定项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_files_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBox_files.SelectedItem == null)
                return;

            listView1.Items.Clear();
            UpdateListView(Func.SearchMusic(listBox_files.SelectedItem.ToString()));

            foreach (ColumnHeader column in listView1.Columns)
            {
                column.Width = -2;
            }
        }

        /// <summary>
        /// 歌曲信息选定项改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 0)
            {
                textBox_lyric.Text = Func.DownloadLyricByID(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text, checkBox_mergeTr.Checked).Replace("\n", "\r\n");
            }
        }

        /// <summary>
        /// 是否合并翻译选中状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_mergeTr_CheckedChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 0)
            {
                textBox_lyric.Text = Func.DownloadLyricByID(listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text, checkBox_mergeTr.Checked).Replace("\n", "\r\n");
            }
        }

        /// <summary>
        /// 批量匹配按钮被点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_match_Click(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += Match_bw_DoWork;
            bw.RunWorkerCompleted += Match_bw_RunWorkerCompleted;
            bw.RunWorkerAsync();
            progressBar1.Maximum = MusicFile.Count;
            progressBar1.Value = 0;
        }
        private void Match_bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("匹配完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Match_bw_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (KeyValuePair<string, string> kv in MusicFile)
            {
                if (!File.Exists($"{kv.Value}.lrc") || checkBox_overWrite.Checked)
                {
                    try
                    {
                        File.WriteAllText($"{kv.Value}.lrc", Func.DownloadLyricByID(Func.SearchMusic(kv.Key)[0]["id"]));
                    }
                    catch (System.NullReferenceException)
                    {

                        continue;
                    }
                }
                Action action = () => progressBar1.Value++;
                progressBar1.Invoke(action);
            }
        }

        /// <summary>
        /// 歌词改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_lyric_TextChanged(object sender, EventArgs e)
        {
            File.WriteAllText($"{MusicFile[listBox_files.SelectedItem.ToString()]}.lrc", textBox_lyric.Text);
        }
    }
}
