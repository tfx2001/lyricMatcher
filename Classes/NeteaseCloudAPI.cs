using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.OpenSsl;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json.Linq;

namespace lyric_matcher.Classes
{
    /// <summary>
    /// 该类封装了网易云音乐的API
    /// </summary>
    class NeteaseCloudAPI
    {
        public static void Test()
        {
            Console.WriteLine(Search("lemon"));
            Console.WriteLine(Lyric("443875380"));
        }

        /// <summary>
        /// 搜索音乐
        /// </summary>
        /// <param name="keyWord">关键词</param>
        /// <returns></returns>
        public static JObject Search(string keyWord)
        {
            string data = $"{{\"s\":\"{keyWord}\",\"type\":1,\"limit\":30,\"offset\":0,\"csrf_token\":\"\"}}";
            string encodedContent = NeteaseCloudCrypt.WeApi(data);
            return JObject.Parse(Request((HttpWebRequest)WebRequest.Create("https://music.163.com/weapi/search/get"), encodedContent));
        }

        /// <summary>
        /// 获取歌词
        /// </summary>
        /// <param name="id">歌曲ID</param>
        /// <returns></returns>
        public static JObject Lyric(string id)
        {
            string data = $"{{ \"method\":\"POST\",\"url\":\"https://music.163.com/api/song/lyric?lv=-1&kv=-1&tv=-1\",\"params\":{{ \"id\":\"{id}\"}} }}";
            string encodedContent = NeteaseCloudCrypt.LinuxApi(data);
            return JObject.Parse(Request((HttpWebRequest)WebRequest.Create("https://music.163.com/api/linux/forward"), encodedContent));
        }

        /// <summary>
        /// 发送请求
        /// </summary>
        /// <param name="req">要发送的HTTP请求</param>
        /// <param name="content">要发送的内容</param>
        /// <returns></returns>
        private static string Request(HttpWebRequest req, string content)
        {
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/75.0.3770.80 Safari/537.36";
            req.Referer = "https://music.163.com";
            byte[] ContentByte = Encoding.UTF8.GetBytes(content);
            req.ContentLength = ContentByte.Length;

            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(ContentByte, 0, ContentByte.Length);
                reqStream.Close();
            }

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();

            string result;

            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
    }

    /// <summary>
    /// 该类封装了与网易云音乐API相关的加密算法
    /// </summary>
    class NeteaseCloudCrypt
    {
        private const string base62 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const string publicKey = "-----BEGIN PUBLIC KEY-----\nMIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDgtQn2JZ34ZC28NWYpAUd98iZ37BUrX/aKzmFbt7clFSs6sXqHauqKWqdtLkF2KexO40H1YTX8z2lSgBBOAxLsvaklV8k4cBFK9snQXE9/DDaFt6Rr7iVZMldczhC0JNgTz+SHXT6CBHuX3e9SdB1Ua44oncaTWz7OBGLbCiK45wIDAQAB\n-----END PUBLIC KEY-----";
        private const string iv = "0102030405060708";
        private const string presetKey = "0CoJUm6Qyw8W8jud";
        private const string linuxapiKey = "rFgB&h#%2?^eDg:Q";

        public static string WeApi(string text)
        {
            Random random = new Random();
            byte[] secretKey = new byte[16];
            random.NextBytes(secretKey);
            secretKey = secretKey.Select(n => (byte)base62[n % 62]).ToArray();
            string param = Convert.ToBase64String(AesEncrypt(Convert.ToBase64String(AesEncrypt(text, CipherMode.CBC, Encoding.UTF8.GetBytes(presetKey), iv)), CipherMode.CBC, secretKey, iv));
            string encSecKey = BitConverter.ToString(RsaEncrypt(secretKey.Reverse().ToArray())).Replace("-", "").ToUpper();
            param = WebUtility.UrlEncode(param);
            return $"params={param}&encSecKey={encSecKey}";
        }

        public static string LinuxApi(string text)
        {
            return $"eparams={BitConverter.ToString(AesEncrypt(text, CipherMode.ECB, Encoding.UTF8.GetBytes(linuxapiKey), "")).Replace("-", "").ToUpper()}";
        }

        public static byte[] AesEncrypt(string s, CipherMode cipherMode, byte[] keyArray, string iv)
        {
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider
            {
                BlockSize = 128,
                KeySize = 128,
                Mode = cipherMode,
                Padding = PaddingMode.PKCS7,
                Key = keyArray
            };

            byte[] src = Encoding.UTF8.GetBytes(s);
            ICryptoTransform encrypt;

            if (iv != "")
            {
                encrypt = aes.CreateEncryptor(keyArray, Encoding.UTF8.GetBytes(iv));
            }
            else
            {

                encrypt = aes.CreateEncryptor();
            }
            byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);
            encrypt.Dispose();
            return dest;
        }

        public static byte[] RsaEncrypt(byte[] bytesToEncrypt)
        {
            bytesToEncrypt = new byte[128 - bytesToEncrypt.Length].Concat(bytesToEncrypt).ToArray();

            try
            {
                var encryptEngine = new RsaEngine(); // new Pkcs1Encoding (new RsaEngine());


                using (var txtreader = new StringReader(publicKey))
                {
                    var keyParameter = (AsymmetricKeyParameter)new PemReader(txtreader).ReadObject();

                    encryptEngine.Init(true, keyParameter);
                }

                byte[] encrypted = encryptEngine.ProcessBlock(bytesToEncrypt, 0, bytesToEncrypt.Length);
                return encrypted;
            }
            catch
            {

                return new byte[0] { };
            }
        }
    }
}
