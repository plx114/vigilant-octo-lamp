using System;

namespace GenshinConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GenshinImpact();
        }

        static void GenshinImpact()
        {
            Console.Clear();
            Console.CursorVisible = false;

            // *, D, # - деревья, кусты, стены
            // I - меч
            // Z - монстры
            // U - хиллка

            char[,] map =
            {
                {'=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=',},
                {'|',' ',' ',' ','*','*','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','U',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',},
                {'|',' ',' ',' ','*','*','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','U',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','U',' ',' ',' ','|',},
                {'|',' ',' ',' ','*','*',' ','D',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',},
                {'|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','Z',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','U',' ','|',},
                {'|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',},
                {'|',' ',' ',' ','#','#','#','#','#','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','Z',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',},
                {'|',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','Z',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',},
                {'|',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','Z',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',},
                {'|',' ',' ',' ','#','I',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',},
                {'|','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#',' ',' ',' ',' ',' ','|',},
                {'|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',},
                {'|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',},
                {'|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','Z',' ',' ',' ',' ',' ',' ',' ',' ','|',},
                {'|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|',},
                {'=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=','=',}
            };

            int playerX = 2, playerY = 2;
            char[] inventory = new char[0];

            // Статы игрока

            float health = 100;
            int damage = 10;    // базовый дамаг

            // Статы мобов

            float enemyHealth = 45;
            int enemyDamage = 10;

            bool life = true;

            while(life)
            {
                Console.SetCursorPosition(0, 20);
                Console.Write("Инвентарь: ");

                for(int i = 0; i < inventory.Length; i++)
                {
                    Console.Write(inventory[i] + " ");
                }

                Console.SetCursorPosition(0, 0);
                for(int i = 0; i < map.GetLength(0); i++)
                {
                    for(int j = 0; j < map.GetLength(1); j++)
                    {
                        if(map[i, j] == '*' || map[i, j] == 'D')
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            continue;
                        }
                        else if(map[i, j] == '#')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            continue;
                        }
                        else if(map[i, j] == 'I')
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            continue;
                        }
                        Console.Write(map[i, j]);
                    }
                    Console.WriteLine();
                }

                Console.SetCursorPosition(playerY, playerX);
                Console.Write("@");

                ConsoleKeyInfo charKey = Console.ReadKey();

                switch(charKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if(map[playerX - 1, playerY] != '=' && map[playerX - 1, playerY] != '|' && map[playerX - 1, playerY] != '#')
                        {
                            playerX--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if(map[playerX + 1, playerY] != '=' && map[playerX + 1, playerY] != '|' && map[playerX + 1, playerY] != '#')
                        {
                            playerX++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if(map[playerX, playerY - 1] != '=' && map[playerX, playerY - 1] != '|' && map[playerX, playerY - 1] != '#')
                        {
                            playerY--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if(map[playerX, playerY + 1] != '=' && map[playerX, playerY + 1] != '|' && map[playerX, playerY + 1] != '#')
                        {
                            playerY++;
                        }
                        break;
                }

                if(map[playerX, playerY] == 'I' || map[playerX, playerY] == 'U')
                {
                    Console.SetCursorPosition(20, 0);

                    char[] tempInventory = new char[inventory.Length + 1];

                    for(int i = 0; i < inventory.Length; i++)
                    {
                        tempInventory[i] = inventory[i];
                    }

                    if(map[playerX, playerY] == 'I')
                    {
                        Console.Write("Вы подобрали меч");
                        damage += 25;

                        tempInventory[tempInventory.Length - 1] = 'I';
                    }
                    else if(map[playerX, playerY] == 'U') // TODO: реализовать хилл
                    {
                        Console.Write("Вы подобрали зелье хп");
                        tempInventory[tempInventory.Length - 1] = 'U';   
                    }
                    

                    inventory = tempInventory;

                    map[playerX, playerY] = 'o';
                }

                if(map[playerX, playerY] == 'Z')
                {
                    Console.SetCursorPosition(0, 16);
                    Console.Write("Вы наткнулись на врага... начинается бой!");

                    while(health > 0 && enemyHealth > 0)
                    {
                        health -= enemyDamage;
                        enemyHealth -= damage;
                    }

                    Console.WriteLine();

                    if(health > 0)
                    {
                        Console.Write("\nВы победили врага!");
                        map[playerX, playerY] = 'X';
                    }
                    else if(enemyHealth > 0)
                    {
                        Console.Write("\nВы умерли, конец игры!\a");
                        Console.ReadKey();
                        life = false;
                    }
                }

                Console.ReadKey();
                Console.Clear();
            }

            Console.Clear();
        }
    }
}
