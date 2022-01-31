using System.Windows.Forms;
namespace MyFileManagerFunction;

public class 새파일만들기
{
    public static void 원노트_바로가기_만들기(string 생성될경로)
    {
        새파일만들기 파일만들기 = new 새파일만들기();
        파일만들기.원노트바로가기생성(생성될경로);
    }
    public static void 원노트_바로가기_만들기(FileInfo 생성될경로)
    {
        새파일만들기 파일만들기 = new 새파일만들기();
        파일만들기.원노트바로가기생성(생성될경로.FullName);
    }
    public static void 원노트_바로가기_만들기(DirectoryInfo 생성될경로)
    {
        새파일만들기 파일만들기 = new 새파일만들기();
        파일만들기.원노트바로가기생성(생성될경로.FullName);
    }
    public void 원노트바로가기생성(string 생성할경로)
    {
        string 바로가기경로 = string.Empty;
        string 파일명 = string.Empty;
        string 클립보드문자 = Clipboard.GetText();
        if (string.IsNullOrEmpty(클립보드문자)) return;
        원노트_로컬링크_만들기(out 바로가기경로, 클립보드문자);
        바로가기_파일명_만들기(out 파일명, 바로가기경로);
        바로가기_생성하기(생성할경로, 파일명, 바로가기경로);
    }
    void 원노트_로컬링크_만들기(out string 로컬링크경로, string 클립보드문자)
    {
        int 링크시작위치 = 클립보드문자.IndexOf("onenote:https://");
        // Console.WriteLine("링크시작위치 : {0}", 링크시작위치);
        int 링크길이 = 클립보드문자.Length - 링크시작위치;
        // Console.WriteLine("링크길이 : {0}", 링크길이);
        로컬링크경로 = 클립보드문자.Remove(0, 링크시작위치);
        // Console.WriteLine("바로가기경로 : {0}", 로컬링크경로);
    }
    /// <summary> 확장자 제외 </summary>
    void 바로가기_파일명_만들기(out string 파일명, string 바로가기경로)
    {
        int 파일명시작위치 = 바로가기경로.IndexOf(".one#") + 5;
        int 파일명끝부분 = 바로가기경로.IndexOf("&section-id");
        파일명 = 바로가기경로.Substring(파일명시작위치, 파일명끝부분 - 파일명시작위치);
    }
    bool 바로가기_생성하기(string 생성할경로, string 파일명, string 바로가기경로)
    {
        string 확장자 = ".lnk";
        FileInfo 생성될_바로가기파일 = new FileInfo(Path.Combine(생성할경로,$"{파일명}{확장자}"));
        Type? shellType = Type.GetTypeFromProgID("WScript.Shell");
        if (shellType == null)
        {
            return false;
        }
        dynamic? shell = Activator.CreateInstance(shellType);
        if (shell == null)
        {
            return false;
        }
        // string 파일명확장자 = $"{파일명}{확장자}";
        // Console.WriteLine("파일명확장자 : {0}", 파일명확장자);
        // Console.WriteLine("생성할경로 : {0}", 생성할경로);
        dynamic shortcut = shell.CreateShortcut(생성될_바로가기파일.FullName);
        shortcut.TargetPath = 바로가기경로;
        shortcut.WorkingDirectory = 생성될_바로가기파일.DirectoryName;
        shortcut.IconLocation = @"%ProgramFiles%\Microsoft Office\Root\VFS\Windows\Installer\{90160000-000F-0000-1000-0000000FF1CE}\joticon.exe";
        shortcut.Save();
        return true;
    }
}