using System;
using System.Linq.Expressions;
using System.Security.AccessControl;

namespace Lessons
{

    class Program
    {
        static void Main(string[] args)
        {

            //Координаты
            int sizeMap = 10;
            int sizeMapChar = sizeMap * sizeMap;
            int HeroDistance = 3;
            int HeroOverview = HeroDistance * 2 + 1;
            int HeroView = HeroOverview - 1;
            int HeroGo = HeroView / 2;
            int d = sizeMap - 1;
            int heroX = 5, heroY = 4;
            int heroMapX = heroX - HeroGo;
            int heroMapY = heroY - HeroGo;
            int heroMapXEnd = heroMapX + HeroOverview;
            int c = 0;

            //Map
            char selectedMenu;// = key.KeyChar;

            int[] valueX = new int[sizeMap];
            for (int x = 0; x < valueX.Length; x++)
            {
                valueX[x] = x;
            }

            int[] valueY = new int[sizeMap];
            for (int x = 0; x < valueX.Length; x++)
            {
                valueY[x] = x;
            }

            int n;
            char[] map = new char[sizeMapChar];
            for(int x=0;x<sizeMapChar;x++)
            {
                map[x] = '0';
            }


            //Battle_Enemies
            int CountMonsters = 1;
            int[] MonsterNumber = new int[CountMonsters];
            for (int x = 0; x < MonsterNumber.Length; x++)
            {
                MonsterNumber[x] = x + 1;
            }
            int[] MonsterLevel = new int[CountMonsters];
            MonsterLevel[0] = 1;
            int[] MonsterDamage = new int[CountMonsters];
            MonsterDamage[0] = 3;
            int[] MonsterHP = new int[CountMonsters];
            MonsterHP[0] = 3;
            string[] monsters = new string[CountMonsters];
            monsters[0] = "gnoll";
            int[] MonsterMap = new int[CountMonsters];
            int e;
            MonsterMap[0] = 77;
            map[77] = 'G';

            int YourEnemy = 50;

            //Char_Battle
            int HeroMaxHP = 10;
            int HeroHP = 10;
            int HeroDamage = 4;


            //Уровень
            String nameHero = "kola132";
            int Level = 1, expUp = 10, exp = 0;
            while (exp > expUp)
            {
                Level++;
                exp = exp - expUp;
                expUp = 10 * Level;
                HeroMaxHP = HeroMaxHP + 5;
            }

            //battle



            c = heroMapY;
            Console.WriteLine("                       " + nameHero + " " + Level + "[" + exp + "/" + expUp + "]");
            for (int x = heroMapX; x < heroMapXEnd; x++)
            {
                for (int z = 0; z < HeroView; z++)
                {
                    n = valueX[x] * 10 + valueY[c] + 1;
                    if (heroX == valueX[x] & heroY == valueY[c])
                    {
                        Console.Write("@ ");
                    }
                    //else if(MonsterX[0] == valueX[x] && MonsterY[0] == valueY[c])
                    //{
                    //    Console.Write("& ");
                    //}
                    else if (map[n]!='0')
                    {
                        Console.Write(map[n]+" ");
                    }
                    else
                    {
                        Console.Write("# ");
                        //Console.Write("[" + valueX[x] + "," + valueY[c] + "]" + " ");
                    }
                    c++;
                }
                n = valueX[x] * 10 + valueY[c] + 1;
                if (heroX == valueX[x] & heroY == valueY[c])
                {
                    Console.WriteLine("@");
                }
                else if (map[n] != '0')
                {
                    Console.Write(map[n] + " ");
                }
                else
                {
                    Console.WriteLine("#");
                    //Console.WriteLine("[" + valueX[x] + "," + valueY[c] + "]" + " ");
                }
                c = heroMapY;
            }
            Console.WriteLine("-----");
            ConsoleKeyInfo key = Console.ReadKey();
            selectedMenu = key.KeyChar;

            /*
            Console.WriteLine("Structure");
            for(int x=0; x<sizeMap; x++) {
                for(int z=0; z<d; z++) {
                    Console.Write("[" + valueX[x] + "," + valueY[c] + "]" + " ");
                    c++;
                }
                Console.WriteLine("[" + valueX[x] + "," + valueY[c] + "]" + " ");
                c=0;
            } */
            bool stop=false;
            bool battle=false;
            

            while (stop == false)
            {
                while (battle == false)
                {
                    
                    
                    switch (selectedMenu)
                    {
                        case 'q':
                            stop = true;
                            break;

                        case 'e':
                            Console.WriteLine( "HeroMap = [" + heroMapX + "." + heroMapY + "]");
                            Console.WriteLine("Hero = [" + heroX + "." + heroY + "]");
                            e = heroX * 10 + heroY + 1;
                            Console.WriteLine("E =" + e);
                            key = Console.ReadKey();
                            selectedMenu = key.KeyChar;
                            break;

                        case 'w':
                            Console.Clear();
                            if (heroX == 0)
                            {
                                Console.WriteLine("Stop");
                            }
                            else
                            {
                                if (heroMapX != 0 && heroMapX == heroX - HeroGo)
                                {
                                    heroMapX--;
                                }
                                heroX--;
                                e = heroX * 10 + heroY + 1;
                                for (int q=0;q<CountMonsters;q++)
                                {
                                    if (MonsterMap[q]==e)
                                    {
                                        YourEnemy = q;
                                        battle = true;
                                        Console.Clear();
                                        break;
                                    }
                                }
                                heroMapXEnd = heroMapX + HeroOverview;
                                for (int x = heroMapX; x < heroMapXEnd; x++)
                                {
                                    for (int z = 0; z < HeroView; z++)
                                    {
                                        n = valueX[x] * 10 + valueY[c] + 1;
                                        if (heroX == valueX[x] & heroY == valueY[c])
                                        {
                                            Console.Write("@ ");
                                        }
                                        else if (map[n] != '0')
                                        {
                                            Console.Write(map[n] + " ");
                                        }
                                        else
                                        {
                                            Console.Write("# ");
                                        }
                                        c++;
                                    }
                                    n = valueX[x] * 10 + valueY[c] + 1;
                                    if (heroX == valueX[x] & heroY == valueY[c])
                                    {
                                        Console.WriteLine("@");
                                    }
                                    else if (map[n] != '0')
                                    {
                                        Console.WriteLine(map[n] + " ");
                                    }
                                    else
                                    {
                                        Console.WriteLine("#");
                                    }
                                    c = heroMapY;
                                }
                                Console.WriteLine("-----");
                            }
                            if(battle==false)
                            {
                                key = Console.ReadKey();
                                selectedMenu = key.KeyChar;
                            }
                            break;

                        case 'a':
                            Console.Clear();
                            if (heroY == 0)
                            {
                                Console.WriteLine("Stop");
                            }
                            else
                            {
                                if (heroMapY != 0 && heroMapY == heroY - HeroGo)
                                {
                                    heroMapY--;
                                }
                                heroY--; 
                                e = heroX * 10 + heroY + 1;
                                for (int q = 0; q < CountMonsters; q++)
                                {
                                    if (MonsterMap[q] == e)
                                    {
                                        YourEnemy = q;
                                        battle = true;
                                        break;
                                    }
                                }
                                for (int x = heroMapX; x < heroMapXEnd; x++)
                                {
                                    for (int z = 0; z < HeroView; z++)
                                    {
                                        n = valueX[x] * 10 + valueY[c] + 1;
                                        if (heroX == valueX[x] & heroY == valueY[c])
                                        {
                                            Console.Write("@ ");
                                        }
                                        else if (map[n] != '0')
                                        {
                                            Console.Write(map[n] + " ");
                                        }
                                        else
                                        {
                                            Console.Write("# ");
                                        }
                                        c++;
                                    }
                                    n = valueX[x] * 10 + valueY[c] + 1;
                                    if (heroX == valueX[x] & heroY == valueY[c])
                                    {
                                        Console.WriteLine("@");
                                    }
                                    else if (map[n] != '0')
                                    {
                                        Console.Write(map[n] + " ");
                                    }
                                    else
                                    {
                                        Console.WriteLine("#");
                                    }
                                    c = heroMapY;
                                }
                                Console.WriteLine("-----");
                            }
                            if (battle == false)
                            {
                                key = Console.ReadKey();
                                selectedMenu = key.KeyChar;
                            }
                            break;

                        case 's':
                            Console.Clear();
                            if (heroX == d)
                            {
                                Console.WriteLine("Stop");
                            }
                            else
                            {
                                if (heroMapX != d - HeroView && heroMapX == heroX - HeroGo)
                                {
                                    heroMapX++;
                                }
                                heroX++;
                                e = heroX * 10 + heroY + 1;
                                for (int q = 0; q < CountMonsters; q++)
                                {
                                    if (MonsterMap[q] == e)
                                    {
                                        YourEnemy = q;
                                        battle = true;
                                        break;
                                    }
                                }
                                heroMapXEnd = heroMapX + HeroOverview;
                                for (int x = heroMapX; x < heroMapXEnd; x++)
                                {
                                    for (int z = 0; z < HeroView; z++)
                                    {
                                        n = valueX[x] * 10 + valueY[c] + 1;
                                        if (heroX == valueX[x] & heroY == valueY[c])
                                        {
                                            Console.Write("@ ");
                                        }
                                        else if (map[n] != '0')
                                        {
                                            Console.Write(map[n] + " ");
                                        }
                                        else
                                        {
                                            Console.Write("# ");
                                        }
                                        c++;
                                    }
                                    n = valueX[x] * 10 + valueY[c] + 1;
                                    if (heroX == valueX[x] & heroY == valueY[c])
                                    {
                                        Console.WriteLine("@");
                                    }
                                    else if (map[n] != '0')
                                    {
                                        Console.Write(map[n] + " ");
                                    }
                                    else
                                    {
                                        Console.WriteLine("#");
                                    }
                                    c = heroMapY;
                                }
                                Console.WriteLine("-----");
                            }
                            if (battle == false)
                            {
                                key = Console.ReadKey();
                                selectedMenu = key.KeyChar;
                            }
                            break;

                        case 'd':
                            Console.Clear();
                            if (heroY == d)
                            {
                                Console.WriteLine("Stop");
                            }
                            else
                            {
                                if (heroMapY != d - HeroView && heroMapY == heroY - HeroGo)
                                {
                                    heroMapY++;
                                }
                                heroY++;
                                e = heroX * 10 + heroY + 1;
                                for (int q = 0; q < CountMonsters; q++)
                                {
                                    if (MonsterMap[q] == e)
                                    {
                                        YourEnemy = q;
                                        battle = true;
                                        break;
                                    }
                                }
                                for (int x = heroMapX; x < heroMapXEnd; x++)
                                {
                                    for (int z = 0; z < HeroView; z++)
                                    {
                                        n = valueX[x] * 10 + valueY[c] + 1;
                                        if (heroX == valueX[x] & heroY == valueY[c])
                                        {
                                            Console.Write("@ ");
                                        }
                                        else if (map[n] != '0')
                                        {
                                            Console.Write(map[n] + " ");
                                        }
                                        else
                                        {
                                            Console.Write("# ");
                                        }
                                        c++;
                                    }
                                    n = valueX[x] * 10 + valueY[c] + 1;
                                    if (heroX == valueX[x] & heroY == valueY[c])
                                    {
                                        Console.WriteLine("@");
                                    }
                                    else if (map[n] != '0')
                                    {
                                        Console.Write(map[n] + " ");
                                    }
                                    else
                                    {
                                        Console.WriteLine("#");
                                    }
                                    c = heroMapY;
                                }
                                Console.WriteLine("-----");

                            }
                            if (battle == false)
                            {
                                key = Console.ReadKey();
                                selectedMenu = key.KeyChar;
                            }
                            break;
                    }
                }

                Console.Clear();
                Console.WriteLine(monsters[YourEnemy] + " attaked you");
                Console.WriteLine("Your HP [" + HeroHP + "/" + HeroMaxHP + "]");
                int EnemyHpM = MonsterLevel[YourEnemy] * 5 + MonsterHP[YourEnemy];
                int EnemyHp = EnemyHpM;
                int EnemyDamage = MonsterLevel[YourEnemy] * 3 + MonsterDamage[YourEnemy];
                key = Console.ReadKey();
                selectedMenu = key.KeyChar;
                while (battle==true) 
                {
                    switch (selectedMenu)
                    {
                        case 'a':
                            Console.Clear();
                            Console.WriteLine("Your HP [" + HeroHP + "/" + HeroMaxHP + "]");
                            EnemyHp = EnemyHp - HeroDamage;
                            Console.WriteLine("You attaked "+ monsters[YourEnemy]+" for "+ HeroDamage+" damage.");
                            if (EnemyHp <= 0)
                            {
                                exp = exp + EnemyHpM;
                                Console.WriteLine("You won! You recevied " + EnemyHpM + " exp.");
                                battle = false;
                                key = Console.ReadKey();
                                //selectedMenu = key.KeyChar;

                                Console.Clear();

                                for (int x = heroMapX; x < heroMapXEnd; x++)
                                {
                                    for (int z = 0; z < HeroView; z++)
                                    {
                                        n = valueX[x] * 10 + valueY[c] + 1;
                                        if (heroX == valueX[x] & heroY == valueY[c])
                                        {
                                            Console.Write("@ ");
                                        }
                                        else if (map[n] != '0')
                                        {
                                            Console.Write(map[n] + " ");
                                        }
                                        else
                                        {
                                            Console.Write("# ");
                                        }
                                        c++;
                                    }
                                    n = valueX[x] * 10 + valueY[c] + 1;
                                    if (heroX == valueX[x] & heroY == valueY[c])
                                    {
                                        Console.WriteLine("@");
                                    }
                                    else if (map[n] != '0')
                                    {
                                        Console.Write(map[n] + " ");
                                    }
                                    else
                                    {
                                        Console.WriteLine("#");
                                    }
                                    c = heroMapY;
                                }
                                Console.WriteLine("-----");

                                key = Console.ReadKey();
                                selectedMenu = key.KeyChar;
                                break;
                            }
                            HeroHP = HeroHP - EnemyDamage;
                            Console.Clear();
                            Console.WriteLine("Your HP [" + HeroHP + "/" + HeroMaxHP + "]");
                            Console.WriteLine("You attaked " + monsters[YourEnemy] + " for " + HeroDamage + " damage.");
                            Console.WriteLine(monsters[YourEnemy]+ " attaked you for " + HeroDamage + " damage.");
                            //Console.WriteLine(EnemyHp);
                            if(HeroHP<=0)
                            {
                                Console.WriteLine("You Died");
                                battle = false;
                                //key = Console.ReadKey();
                                //selectedMenu = key.KeyChar;
                                stop = true;
                                break;
                            }
                            key = Console.ReadKey();
                            selectedMenu = key.KeyChar;
                            break;
                    }
                }
            }

            /*
            for (int x = 0; x < sizeMap; x++)
            {
                for (int z = 0; z < d; z++)
                {
                    Console.WriteLine("[" + valueX[x] + "," + valueY[c] + "]" + " ");
                    c++;
                }
                Console.WriteLine("[" + valueX[x] + "," + valueY[c] + "]" + " ");
                c = 0;
            } */

            /* for(int x=0; x<sizeMap; x++) {
                for(int z=0; z<d; z++) {
                    if (heroX==valueX[x] & heroY==valueY[c]) {
                        Console.WriteLine("@" + " ");
                    } else {
                        Console.WriteLine("#" + " ");
                    }
                    c++;
                }
                if (heroX==valueX[x] & heroY==valueY[c]) {
                    Console.WriteLine("@");
                } else {
                    Console.WriteLine("#");
                }
                c=0;
            } */
            /* switch(go) {
                case "a":
                    Console.WriteLine("success");
                    break;
                default:
                    Console.WriteLine("lose");
                    break;
            } */

        }
    }
}
