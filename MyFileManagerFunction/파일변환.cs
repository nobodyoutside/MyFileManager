using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFileManagerFunction
{
    public class 파일변환
    {

        public static void Mp4를wav로변환함(FileInfo mp4파일경로)
        {
            파일변환 mp4를wav로 = new();
            //if (".ml4".Equals(mp4파일경로.Extension, StringComparison.OrdinalIgnoreCase))
            //{
            //   return;
            //}
            mp4를wav로.Mp4를wav로변환함(mp4파일경로.FullName);
        }
        void Mp4를wav로변환함(string mp4파일경로)
        {
            ProcessStartInfo psiProcInfo = new ProcessStartInfo();
            Process prcFFMPEG = new();

            //string strFFMPEGCmd = " -i \"" + mp4파일경로 + " out.wav";
            string strFFMPEGCmd = $" -i \"{mp4파일경로}\" \"{Path.ChangeExtension(mp4파일경로, ".wav")}\"";

            // psiProcInfo.FileName = Application.StartupPath + ((IntPtr.Size == 8) ? "\\x64" : "\\x86") + "\\ffmpeg.exe";
            psiProcInfo.FileName = Application.StartupPath + "\\ffmpeg.exe";
            psiProcInfo.Arguments = strFFMPEGCmd;
            psiProcInfo.UseShellExecute = false;
            psiProcInfo.WindowStyle = ProcessWindowStyle.Hidden;
            psiProcInfo.RedirectStandardError = true;
            psiProcInfo.RedirectStandardOutput = true;

            prcFFMPEG.StartInfo = psiProcInfo;
            prcFFMPEG.Start();
        }
    }
}
