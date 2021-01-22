using System;
namespace ex2_8_boss_fight
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в пошаговый батл мага против Босса! \n\nТебе предстоит играть за мага. \nБосс сражается " +
                "сам, каждый ход он будут наносить тебе урон.\n\nМаг может кастовать 3 заклинания или ударить посохом, от " +
                "тактики и удачи кастования будет зависеть урон мага.\nПобедит тот, кто отправит противника к праотцам. Удачи!");
            Console.ReadKey();
            int spellHealthRegenerationCount = 2;
            int spellFireBall;
            int fireBallRoundsBeforeUse = 7;
            int spellFireBallCount = 3;
            int staffDamage;
            bool isSpiderwebSpellsCasted = false;
            int spellSpiderwebSpellsCount = 1;
            int spiderwebRoundsPassed = 0;
            int spiderwebRoundsTotal = 3;
            int spellSelection;
            int healthMage = 100;
            int healthBoss = 150;
            int damageBoss;
            int roundIterationCount = 0;
            Random rand = new Random();

            while (healthMage > 0 && healthBoss > 0)
            {
                Console.Clear();
                roundIterationCount++;
                Console.WriteLine($"\t\t\tНачался раунд {roundIterationCount}\n");
                Console.WriteLine("МАГ\t\t\t\t\t БОСС");
                Console.WriteLine();
                for (int i = 0; i < healthMage / 10; i++)
                {
                    Console.Write('*');
                }
                Console.Write("\t\t\t\t");
                for (int j = 0; j < healthBoss / 10; j++)
                {
                    Console.Write('#');
                }
                Console.WriteLine();
                Console.WriteLine($"1. Кастовать: Хилка, осталось {spellHealthRegenerationCount} шт." +
                    $"\n2. Кастовать: Файрбол (доступно c 7 раунда), осталось {spellFireBallCount} шт.\n3. Ударить посохом" +
                    $"\n4. Кастовать: Обездвиживание нежити на 2 раунда, осталось {spellSpiderwebSpellsCount} шт." +
                    $"\n5. Кастовать: Последний шанс. Если закончились все др.заклинания, это может тебя спасти, но отнимет 25 хп и у тебя");
                spellSelection = Convert.ToInt32(Console.ReadLine());

                switch (spellSelection)
                {
                    case 1:
                        Console.WriteLine("Ты делаешь хилку");
                        if (spellHealthRegenerationCount == 0)
                        {
                            Console.WriteLine("Ты уже потратил это заклинание, ты потерял свой ход");
                        }
                        else
                        {
                            healthMage += 50;
                            spellHealthRegenerationCount--;
                            Console.WriteLine($"Ты успеваешь вовремя подлечиться, сейчас у тебя {healthMage} единиц здоровья");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Ты кастуешь заклинание 'Файрбол'");
                        if (spellFireBallCount == 0)
                        {
                            Console.WriteLine("Ты забыл, что заклинаний больше нет, выбора нет, Босс уже начал свою атаку...");
                        }
                        else if (roundIterationCount < fireBallRoundsBeforeUse)
                        {
                            Console.WriteLine($"Пока не выйдет, манна накопится только через {fireBallRoundsBeforeUse - roundIterationCount} раундов." +
                                              $" Босс пользуется моментом и...");
                        }
                        else
                        {
                            Console.WriteLine("Огненный шар устремляется в Босса:");
                            spellFireBallCount--;
                            spellFireBall = rand.Next(0, 3);
                            if (spellFireBall == 0)
                            {
                                Console.WriteLine($"Надо было чаще тренироваться, огненный шар взрывается у тебя в руках, ранив тебя на 10 жизней");
                                healthMage -= 10;
                            }
                            else if (spellFireBall == 1)
                            {
                                Console.WriteLine("Шар с ревом улетает в противника, но тот ставит блок, частично блокируя удар.");
                                healthBoss -= 30;
                            }
                            else if (spellFireBall == 2)
                            {
                                Console.WriteLine("Огненный шар досинает цели. Пахнет жареной плотью");
                                healthBoss -= 50;
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Ты бьешь посохом");
                        staffDamage = rand.Next(0, 25);
                        healthBoss -= staffDamage;
                        if (staffDamage < 10)
                        {
                            Console.WriteLine($"Ты хорошенько замахнулся, но зацепился за подол своей мантии. Урон нанесен" +
                                $" на {staffDamage} жизней");
                        }
                        else if (staffDamage >= 10 && staffDamage < 20)
                        {
                            Console.WriteLine($"Хороший сильный удар попадает в челюсть Босса, нанеся урон на {staffDamage} жизней");
                        }
                        else if (staffDamage >= 20)
                        {
                            Console.WriteLine($"Крит прямо в темячко, урон {staffDamage} жизней");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Магическая паутина начинает всплывать в твоих мыслях");
                        if (spellSpiderwebSpellsCount == 0)
                        {
                            Console.WriteLine("Этот ход ты потратил, пытаясь вспомнить заклинание, которое уже потрачено, лови атаку Босса...");
                        }
                        else
                        {
                            Console.WriteLine($"Магическая паутина окутывает Босса, обездвижив его на 2 раунда");
                            spellSpiderwebSpellsCount--;
                            isSpiderwebSpellsCasted = true;
                        }
                        break;
                    case 5:
                        Console.WriteLine("Ты читаешь заклинание: последний шанс:");
                        if (spellHealthRegenerationCount == 0 && spellFireBallCount == 0 && spellSpiderwebSpellsCount == 0)
                        {
                            Console.WriteLine("На творение этой магии ты тратишь 25 своего хп, высасывая у Босса 50 хп");
                            healthMage -= 25;
                            healthBoss -= 50;
                        }
                        else
                        {
                            Console.WriteLine($"Конечно, это не твой последний шанс, ведь у тебя еще осталось: Хилка: {spellHealthRegenerationCount} шт.," +
                                $" Файрболов: {spellFireBallCount} шт., Обездвиживание нежити: {spellSpiderwebSpellsCount} шт.");
                        }

                        break;
                    default:
                        Console.WriteLine("Ты растерялся и ничего не сделал в этом раунде");
                        break;
                }
                Console.ReadKey();

                damageBoss = rand.Next(0, 40);
                if (isSpiderwebSpellsCasted == true)
                {
                    spiderwebRoundsPassed++;
                    if (spiderwebRoundsPassed >= spiderwebRoundsTotal)
                    {
                        isSpiderwebSpellsCasted = false;
                    }
                    Console.WriteLine($"Босс окутан паутиной еще {spiderwebRoundsTotal - spiderwebRoundsPassed} раунда. Действуй!");
                    damageBoss = 0;
                }
                else if (damageBoss == 0)
                {
                    Console.WriteLine("Босс промахивается, спотыкается о собственную дубину, нанося себе урон на 10 жизней");
                    healthBoss -= 10;
                }
                else if (damageBoss > 0 && damageBoss <= 15)
                {
                    Console.WriteLine($"Босс едва задевает тебя, нанося царапину на {damageBoss} жизней");
                }
                else if (damageBoss > 15 && damageBoss <= 25)
                {
                    Console.WriteLine($"Босс наносит удар огромной дубиной по твоему хребту, нанося урон в {damageBoss} жизней");
                }
                else if (damageBoss >= 25)
                {
                    Console.WriteLine($"Босс наносит сокрушительный удар на {damageBoss} жизней, в твоих ушах слышен хруст костей");
                }
                healthMage -= damageBoss;

                if (healthBoss < 0) healthBoss = 0;
                if (healthMage < 0) healthMage = 0;
                Console.Write($"\nЗдоровья у Мага : {healthMage}\n");
                Console.WriteLine($"Здоровья у Босса : {healthBoss}");
                Console.ReadKey();
            }
            if (healthMage == 0 && healthBoss == 0)
            {
                Console.WriteLine("\nНевероятно, но отражая смертельный удар Босса, ты успеваешь скастовать заклинание. 2 трупа падают на землю навзничь");
            }
            else if (healthMage == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nПосле такого удара, ты отправляешься к праотцам, Победил Босс, попробуй его уделать в следующей катке...");
            }
            else if (healthBoss == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nВ этом бою удача была на твоей стороне, поздравляю с победой!");
            }
            Console.ReadKey();
        }
    }
}