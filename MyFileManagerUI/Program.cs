// See https://aka.ms/new-console-template for more information
using MyFileManagerFunction;

// Console.WriteLine("Hello, World!");


public static class MyFileManger
{
    [STAThread]
    static void Main(string[] args)
    {
        Menu 선택한항목;
        const ConsoleKey 키0번 = ConsoleKey.D0;
        const ConsoleKey 키1번 = ConsoleKey.D1;
        const ConsoleKey 키2번 = ConsoleKey.D2;
        const ConsoleKey 키3번 = ConsoleKey.D3;
        const ConsoleKey 키4번 = ConsoleKey.D4;
        const ConsoleKey 키5번 = ConsoleKey.D5;
        const ConsoleKey 키6번 = ConsoleKey.D6;

        ConsoleKeyInfo 누른키;
        메뉴표시하기();
        누른키 = Console.ReadKey(true);
        switch(누른키.Key) {
				case 키0번 :
                    선택한항목 = Menu.취소;
					break;
				case 키1번:
                    선택한항목 = Menu.이름에_날짜추가;
					break;
				case 키2번:
                    선택한항목 = Menu.이름에_주석삭제;
					break;
				case 키3번:
                    선택한항목 = Menu.폴더에서_FBX파일만_복사;
					break;
				case 키4번:
                    선택한항목 = Menu.택스트파일내용으로_폴더생성;
					break;
                case 키5번:
                    선택한항목 = Menu.원노트바로가기생성;
                    break;
                case 키6번:
                    선택한항목 = Menu.mp4를wav로_파일변환;
                    break;
				default:
                    선택한항목 = Menu.취소;
					break;
        }
        Console.WriteLine("{0}", 선택한항목.ToString());
        foreach (var path in args)
        {
            //파일명구분
            FileAttributes attr = File.GetAttributes(path);
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                Console.WriteLine(path + "폴더네");
                // this.MakeFolder();
                DirectoryInfo 폴더클래스 = new DirectoryInfo(path);
                switch(선택한항목) {
                    case Menu.취소 :
                        break;
                    case Menu.이름에_날짜추가:
                        이름관리.AddDate(폴더클래스);
                        break;
                    case Menu.이름에_주석삭제:
                        이름관리.주석삭제(폴더클래스);
                        break;
                    case Menu.폴더에서_FBX파일만_복사:
                        이름관리.폴더에서FXB파일만_복사하기(폴더클래스);
                        break;
                    case Menu.택스트파일내용으로_폴더생성:
                        break;
                    case Menu.원노트바로가기생성:
                        새파일만들기.원노트_바로가기_만들기(폴더클래스);
                        break;
                    case Menu.mp4를wav로_파일변환:
                        // 차후에 폴더안의 파일 일관 변환
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine(path + "파일이네");
                // ReName.AddData.ChangeFileName(path);
                FileInfo 파일클래스 = new FileInfo(path);
                switch(선택한항목) {
                    case Menu.취소 :
                        break;
                    case Menu.이름에_날짜추가:
                        이름관리.AddDate(파일클래스);
                        break;
                    case Menu.이름에_주석삭제:
                        이름관리.주석삭제(파일클래스);
                        break;
                    case Menu.폴더에서_FBX파일만_복사:
                        break;
                    case Menu.택스트파일내용으로_폴더생성:
                        break;
                    case Menu.원노트바로가기생성:
                        // 새파일만들기.원노트_바로가기_만들기(파일클래스);
                        break;
                    case Menu.mp4를wav로_파일변환:
                        파일변환.Mp4를wav로변환함(파일클래스);
                        break;
                    default:
                        break;
                }
            }

        }

        Console.WriteLine("선택한 기능은 :{0}", 선택한항목.ToString());
        // Console.ReadKey();
        // return;
    }
    static void 메뉴표시하기()
    {
        var 항목번호 = Enum.GetValues(typeof(Menu));
        foreach (Menu 항목 in 항목번호) {
            Console.WriteLine("({0:D}). {0} ", 항목);
        }
    }
}
enum Menu
{
    취소 = 0,
    이름에_날짜추가 = 1,
    이름에_주석삭제 = 2,
    폴더에서_FBX파일만_복사 = 3,
    택스트파일내용으로_폴더생성 = 4,
    원노트바로가기생성 = 5,
    mp4를wav로_파일변환 = 6
}
