namespace MyFileManagerFunction;
public static class 이름관리
{
    static DateTime today = DateTime.Today;
    public static bool ChangeFileName(string? filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            return false;
        // string newFile = Path.GetExtension(filePath);
        // string date = today.ToShortDateString();
        string newFile = today.ToShortDateString() + "__" + filePath;
        Console.WriteLine(newFile);
        // System.IO.File.Move(filePath, newFile);
        File.Move(filePath, newFile);
        return true;
    }
    public static bool AddDate(FileInfo fileInfo)
    {
        string newFileName = today.ToShortDateString() + "__" + fileInfo.Name;
        string? 기존폴더_경로 = fileInfo.DirectoryName;
        if (기존폴더_경로 == null) return false;
        string newFileFullPathName = Path.Combine(기존폴더_경로, newFileName);
        // Console.WriteLine(newFileFullPathName);
        File.Move(fileInfo.FullName, newFileFullPathName);
        return true;
    }
    public static bool AddDate(DirectoryInfo dirInfo)
    {
        DirectoryInfo? 디렉토리_부모_정보 = dirInfo.Parent;
        if (디렉토리_부모_정보 == null) 디렉토리_부모_정보 = dirInfo;
        DateTime 추가할_시간정보 = dirInfo.LastWriteTime;
        string 새이름 = 추가할_시간정보.ToShortDateString() + "__" + dirInfo.Name;
        string 새경로 = Path.Combine(디렉토리_부모_정보.FullName, 새이름);
        Directory.Move(dirInfo.FullName, 새경로);
        return true;
    }
    public static bool 주석삭제(FileInfo 해당파일)
    {
        string 파일만 = 해당파일.Name.Split('.')[0];
        string 새파일명 = 파일만.Split(',')[0];
        string? 폴더명 = 해당파일.DirectoryName;
        if (폴더명 == null) 폴더명 = 해당파일.Name;
        string newFileFullPathName = Path.Combine(폴더명, 새파일명 + 해당파일.Extension);
        File.Move(해당파일.FullName, newFileFullPathName);
        return true;
    }
    public static bool 주석삭제(DirectoryInfo 해당폴더)
    {
        string 새이름 = 해당폴더.Name.Split(',')[0];
        string newFileFullPathName = Path.Combine(해당폴더.FullName, 새이름);
        Directory.Move(해당폴더.FullName, newFileFullPathName);
        return true;
    }
    public static bool 폴더에서FXB파일만_복사하기(DirectoryInfo 해당폴더)
    {
        DirectoryInfo? 복사할대상폴더 = 해당폴더.Parent;
        if (복사할대상폴더 == null) 복사할대상폴더 = 해당폴더;
        foreach (FileInfo fix파일 in 해당폴더.GetFiles("*.fbx", SearchOption.AllDirectories))
        {
            fix파일.CopyTo(Path.Combine(복사할대상폴더.FullName, fix파일.Name));
        }
        return true;
    }
}
