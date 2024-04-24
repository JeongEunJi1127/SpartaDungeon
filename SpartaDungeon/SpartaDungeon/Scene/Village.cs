using SpartaDungeon.UI;

namespace SpartaDungeon.Scene
{
    public class Village
    {
        public static void ShowVillage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(@"
██     ██ ███████ ██       ██████  ██████  ███    ███ ███████     ████████  ██████  
██     ██ ██      ██      ██      ██    ██ ████  ████ ██             ██    ██    ██ 
██  █  ██ █████   ██      ██      ██    ██ ██ ████ ██ █████          ██    ██    ██ 
██ ███ ██ ██      ██      ██      ██    ██ ██  ██  ██ ██             ██    ██    ██ 
 ███ ███  ███████ ███████  ██████  ██████  ██      ██ ███████        ██     ██████                                                                      
");
            Console.WriteLine(@"
██████  ██    ██ ███    ██  ██████  ███████  ██████  ███    ██ 
██   ██ ██    ██ ████   ██ ██       ██      ██    ██ ████   ██ 
██   ██ ██    ██ ██ ██  ██ ██   ███ █████   ██    ██ ██ ██  ██ 
██   ██ ██    ██ ██  ██ ██ ██    ██ ██      ██    ██ ██  ██ ██ 
██████   ██████  ██   ████  ██████  ███████  ██████  ██   ████           
");
            Console.ResetColor();

            SetColorToText.SetColorToMagenta("1");
            Console.Write(". 상태창\n");
            SetColorToText.SetColorToMagenta("2");
            Console.Write(". 인벤토리\n");
            SetColorToText.SetColorToMagenta("3");
            Console.Write(". 상점\n");
            SetColorToText.SetColorToMagenta("4");
            Console.Write(". 던전입장\n");
            SetColorToText.SetColorToMagenta("5");
            Console.Write(". 휴식하기\n\n");

            InputText.VillageInput();
        }
    }
}
