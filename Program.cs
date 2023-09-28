using System.Data;

namespace project_mafia_in_console_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] Rolename = new string[12]
           {
               "CommonCitizen",
               "CommonCitizen",
               "CommonCitizen",
               "CommonCitizen",
               "professional",
               "BodyGuard",
               "Detective",
               "GodFather",
               "Terrorist",
               "Consort",
               "Doctor",
               "Ninja",
           };
            var PlayerName = new string[12];

            var Roles = new Role[12];

            Random random = new Random();
            int i;
            int j;
            int MafiaKill;
            int DoctorSave;
            int BodyGuardSave;
            int ProfessionalKill;
            int DetectiveInqury;
            int Ninja = default;


            Console.WriteLine("press any key to start the game");

            Console.ReadKey();
            Console.Clear();


            for (i = 1; i <= 12; i++)
            {

                Console.WriteLine($"player {i} please enter your name");
                PlayerName[i - 1] = Console.ReadLine();



                //first bug
                Role RoleAdder = new Role(string.Empty, string.Empty);

                do
                {
                    j = random.Next(0, 12);

                    if (Rolename[j] != string.Empty)
                    {
                        Roles[i].PlayerName = PlayerName[i - 1];
                        RoleAdder.RoleName = Rolename[j];

                        if (Rolename[j] == "Consort" || Rolename[j] == "Ninja")
                        {
                            RoleAdder.Inqury = true;
                            RoleAdder.RoleValue = true;
                            if (Rolename[j] == "Ninja")
                                Ninja = j;
                        }
                        else if (Rolename[j] == "GodFather")
                        {
                            RoleAdder.Inqury = false;
                            RoleAdder.RoleValue = true;
                        }
                        else if (Rolename[j] == "Terrorist")
                        {
                            RoleAdder.Inqury = true;
                            RoleAdder.RoleValue = false;
                        }
                    }
                } while (Rolename[j] == string.Empty);
                Rolename[j] = string.Empty;
                Roles[i - 1] = RoleAdder;
                Console.Clear();
            }

            int DayNumberator = 0;
            do
            {
                Console.Clear();
                DayNumberator++;
                Console.Write($"day {DayNumberator} is about to begin");
                Thread.Sleep(1000);
                Console.Write(" .");
                Thread.Sleep(1000);
                Console.Write('.');
                Thread.Sleep(1000);
                Console.WriteLine('.');
                Thread.Sleep(1000);
                Console.WriteLine("press any key to continue");
                Console.ReadKey();


                var SpeakPersons = new string[12];
                //second bug
                SpeakPersons = PlayerName;
                for (i = 0; i < 12; i++)
                {
                    do
                    {
                        Console.Clear();
                        j = random.Next(0, 12);
                        if (SpeakPersons[j] != string.Empty)
                        {
                            Console.WriteLine($"{SpeakPersons[j]} if you press any key , your turn begins");
                            Console.ReadKey();

                            for (int f = 40; f >= 0; f--)
                            {
                                Console.Clear();
                                Console.WriteLine($"{SpeakPersons[j]} you have {f} seconds");
                                Thread.Sleep(1000);

                            }
                        }
                    } while (SpeakPersons[j] == string.Empty);
                    SpeakPersons[j] = string.Empty;
                    int DeadPlayerChecker = default;
                    int DeadPlayer;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("please select killed player");

                        for (i = 0; i < 12; i++)
                            Console.WriteLine($"{i + 1}.{PlayerName[i]}");

                        Console.WriteLine("13.we have no dead player");
                        DeadPlayer = int.Parse(Console.ReadLine());

                        if (DeadPlayer >= 12)
                        {
                            Roles[DeadPlayer - 1].InGame = false;
                            PlayerName[DeadPlayer - 1] = string.Empty;
                            Console.Clear();
                            Console.WriteLine("if we have another killed player type 1 and if not type 2");
                            DeadPlayerChecker = int.Parse(Console.ReadLine());
                        }

                    } while (DeadPlayerChecker == 1);

                    Console.Write("night is coming");
                    Thread.Sleep(1000);
                    Console.Write(" .");
                    Thread.Sleep(1000);
                    Console.Write(".");
                    Thread.Sleep(1000);
                    Console.WriteLine('.');
                    Thread.Sleep(1000);
                    Console.WriteLine("press any key to start the night");
                    Console.ReadKey();

                    Console.Clear();
                    Console.WriteLine("Mafia wake up");
                    Thread.Sleep(3500);
                    Console.WriteLine("choose a player to kill");

                    for (i = 0; i < 12; i++)
                        Console.WriteLine($"{i + 1}.{PlayerName[i]}");
                    Console.WriteLine("13. there is no kill");

                    MafiaKill = int.Parse(Console.ReadLine());

                    Console.Clear();

                    Console.WriteLine("doctor , wake up");
                    Thread.Sleep(3500);
                    Console.WriteLine("choose a player to save");

                    for (i = 0; i < 12; i++)
                        Console.WriteLine($"{i + 1}.{PlayerName[i]}");
                    Console.WriteLine("13. there is no save");

                    DoctorSave = int.Parse(Console.ReadLine());

                    Console.Clear();

                    Console.WriteLine("bodyguard , wake up");
                    Thread.Sleep(3500);
                    Console.WriteLine("choose a player to save");

                    for (i = 0; i < 12; i++)
                        Console.WriteLine($"{i + 1}.{PlayerName[i]}");
                    Console.WriteLine("13. there is no save");

                    BodyGuardSave = int.Parse(Console.ReadLine());

                    Console.Clear();

                    Console.WriteLine("Professional , wake up");
                    Thread.Sleep(3500);
                    Console.WriteLine("choose a player to kill");

                    for (i = 0; i < 12; i++)
                        Console.WriteLine($"{i + 1}.{PlayerName[i]}");
                    Console.WriteLine("13. there is no kill");

                    ProfessionalKill = int.Parse(Console.ReadLine());

                    Console.Clear();

                    Console.WriteLine("detective , wake up");
                    Thread.Sleep(3500);
                    Console.WriteLine("choose a player for inqury");

                    for (i = 0; i < 12; i++)
                        Console.WriteLine($"{i + 1}.{PlayerName[i]}");
                    Console.WriteLine("13. there is no inqury");
                    DetectiveInqury = int.Parse(Console.ReadLine());
                    Console.WriteLine($"{Roles[DetectiveInqury - 1].Inqury}");

                    if (MafiaKill != DoctorSave && BodyGuardSave != MafiaKill)
                    {
                        PlayerName[MafiaKill - 1] = string.Empty;
                        Roles[MafiaKill - 1].InGame = false;
                    }
                    if (MafiaKill == BodyGuardSave && Roles[Ninja].InGame == false)
                    {
                        Console.WriteLine("Ninja is dead and BodyGaurd have killed a mafia");
                        Console.WriteLine("select the dead mafia");

                        for (i = 0; i < 12; i++)
                            Console.WriteLine($"{i + 1}.{PlayerName[i]}");
                        int DeadMafia = int.Parse(Console.ReadLine());
                        Roles[DeadMafia - 1].InGame = false;
                        PlayerName[DeadMafia - 1] = string.Empty;

                    }








                }
            } while (true);
        }
    }
}