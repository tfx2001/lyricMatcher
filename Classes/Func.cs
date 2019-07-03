using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace lyric_matcher.Classes
{
    class Func
    {
        /// <summary>
        /// 递归搜索
        /// </summary>
        /// <param name="currentPath">递归起始路径</param>
        /// <returns></returns>
        public static Dictionary<string, string> RecursiveSearch(string currentPath)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                foreach (string file in Directory.GetFileSystemEntries(currentPath))
                {
                    try
                    {
                        if (!File.Exists(file))
                            result = result.Concat(RecursiveSearch(file)).ToDictionary(k => k.Key, v => v.Value);
                        else
                        {
                            if (new string[] { ".mp3", ".flac", ".ape" }.Contains(Path.GetExtension(file).ToLower()))
                                result[Path.GetFileNameWithoutExtension(file)] = $"{Path.GetDirectoryName(file)}\\{Path.GetFileNameWithoutExtension(file)}";
                        }
                    }
                    catch(System.ArgumentException)
                    {
                        continue;
                    }

                }
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("路径不存在!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        /// <summary>
        /// 搜索音乐
        /// </summary>
        /// <param name="keyWord">关键词</param>
        /// <returns></returns>
        public static List<Dictionary<string, string>> SearchMusic(string keyWord)
        {
            JObject jsonResult = NeteaseCloudAPI.Search(keyWord);
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            foreach (JObject song in jsonResult["result"]["songs"])
            {
                Dictionary<string, string> tempSong = new Dictionary<string, string>
                {
                    ["name"] = song["name"].ToString(),
                    ["id"] = song["id"].ToString(),
                    ["artist"] = song["artists"].ToList()[0]["name"].ToString()
                };
                result.Add(tempSong);
            }
            return result;
        }

        /// <summary>
        /// 合并翻译
        /// </summary>
        /// <param name="lyric">原歌词</param>
        /// <param name="tlyric">翻译歌词</param>
        /// <returns></returns>
        public static List<string> MergeTranslation(string lyric, string tlyric)
        {
            List<string> lyricList = lyric.Split('\n').ToList();
            List<string> tlyricList = tlyric.Split('\n').ToList();
            if (lyricList[0].Contains("[by:"))
            {
                lyricList.RemoveAt(0);
            }
            if (tlyricList[0].Contains("[by:"))
                tlyricList.RemoveAt(0);
            int j = 0;
            for (int i = 0; i < lyricList.Count; i++)
            {
                try
                {
                    int pos = lyricList[i].IndexOf("]");
                    if (lyricList[i].Substring(0, pos) == tlyricList[j].Substring(0, pos))
                    {
                        lyricList[i] += $" {tlyricList[j].Substring(pos + 1)}";
                        j++;
                    }
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    break;
                }
            }
            return lyricList;
        }

        /// <summary>
        /// 根据ID下载歌词
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string DownloadLyricByID(string id, bool isMergeTranslation = true)
        {
            string lyric = null;
            JObject lyricJson = NeteaseCloudAPI.Lyric(id);
            try
            {
                lyric = lyricJson["lrc"]["lyric"].ToString();
                string tlyric = lyricJson["tlyric"]["lyric"].ToString();
                if (tlyric != "" && isMergeTranslation)
                    lyric = string.Join("\n", MergeTranslation(lyric, tlyric));
                string p = @"(\[\d*:\d*.)(\d{2})\d\]";
                lyric = Regex.Replace(lyric, p, @"$1$2]");
            }
            catch (System.NullReferenceException)
            {

            }
            return lyric == null ? "[00:00.00]轻音乐，请欣赏" : lyric;
        }
    }
}
