using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
//Dictionary序列化和反序列化类
using System.Windows.Forms;
using SevenZip;

namespace CommonProj
{
    public class PermissionModel
    {
        //存放心电数据的字典 按照 每导联顺序进行存储
        public Dictionary<int, List<float>> Dict = new Dictionary<int, List<float>>();
        SevenZipCompressor cmp = null;

        public PermissionModel()
        {
            cmp = new SevenZipCompressor();
            if (IntPtr.Size == 8)
            {
                //64 bit
                SevenZipBase.SetLibraryPath(AppDomain.CurrentDomain.BaseDirectory + "\\7z64.dll");
            }
            else if (IntPtr.Size == 4)
            {
                //32 bit
                SevenZipBase.SetLibraryPath(AppDomain.CurrentDomain.BaseDirectory + "\\7z.dll");
            }
        }

        public void Add(int key, List<float> value)
        {
            Dict.Add(key, value);
        }
        public void Clear()
        {
            Dict.Clear();
        }
        public void Remove(int key)
        {
            Dict.Remove(key);
        }

        /// <summary>
        /// 压缩数据
        /// </summary>
        /// <returns></returns>
        public byte[] Compress(Dictionary<int, List<float>> dict)
        {
            string path = Application.StartupPath + "\\YJL_ECG_MID.DAT";
            var fs = new FileStream(path, FileMode.Create);
            var bw = new BinaryWriter(fs);

            for (int i = 0; i < dict.Count; i++)
            {
                List<float> lf = dict[i];
                int len = dict[i].Count;
                for (int j = 0; j < len; j++)
                {
                    bw.Write(lf[j]);
                }
            }

            bw.Close();
            //fs.Close();

            fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            var br = new BinaryReader(fs);
            var bs = new byte[fs.Length];
            br.Read(bs, 0, bs.Length);
            br.Close();
            //fs.Close();

            var msOut = new MemoryStream();
            var msin = new MemoryStream(bs);
            cmp.CompressStream(msin, msOut, "%yjl2015*^zw$");
            byte[] bytes = msOut.ToArray();
            msin.Close();
            msOut.Close();
            return bytes;
        }

        /// <summary>
        /// 解压数据
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, List<float>> Decompress(byte[] sourceEcgData, int leadCount)
        {
            Dictionary<int, List<float>> result;
            var msin = new MemoryStream(sourceEcgData);
            var s = new MemoryStream();
            try
            {
                using (var sze = new SevenZipExtractor(msin, "%yjl2015*^zw$"))
                {
                    if (sze.Check())
                    {
                        sze.ExtractFile(0, s);
                        //sze.Dispose();
                    }
                }
                //msin.Close();

                result = new Dictionary<int, List<float>>();
                long len = s.Length / 4;
                int leadLeng = (int)(len / leadCount);

                //再写入文件
                string path2 = Application.StartupPath + "\\YJL_DECG_MID.DAT";
                var fs = new FileStream(path2, FileMode.Create);
                var bw = new BinaryWriter(fs);
                byte[] bs = s.ToArray();
                bw.Write(bs, 0, bs.Length);
                bw.Close();
                //fs.Close();
                //结束写入文件

                using (var reader = new BinaryReader(File.Open(path2, FileMode.Open)))
                {
                    for (int i = 0; i < leadCount; i++)
                    {
                        result.Add(i, new List<float>(leadLeng));
                        for (int j = i * leadLeng; j < i * leadLeng + leadLeng; j++)
                        {
                            result[i].Add(reader.ReadSingle());
                        }
                    }
                }
                s.Close();
            }
            catch (Exception ex)
            {
                //msin.Close();
                s.Close();
                result = null;
            }
            return result;
        }
    }
}
