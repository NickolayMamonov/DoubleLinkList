using System;
using System.Text;
using DoubleLinkList;

namespace List
{
    class Program
    {
        static List<Minion> minions = new();

        static void Main(string[] args)
        {
            
            
            while (true)
            {
                switch (Menu2())
                {
                    case 1:
                    {
                        Stacks.Works();
                        break;
                    }
                    case 2:
                    {
                        Work();
                        break;
                    }
                    default: return;
                }
            }
            Stacks.Works();
            //Work();
        }

        private static void Work()
        {
            while (true)
            {
                switch (Menu())
                {
                    case 1:
                    {
                        Console.Write("Укажите имя миньона: ");
                        string name = Console.ReadLine();
                        Console.Write("Укажите возраст миньона: ");
                        int age = Int32.Parse(Console.ReadLine() ?? string.Empty);
                        Minion minion = new Minion(name, age);
                        minions.Add(minion);
                        Console.WriteLine();
                        
                        break;
                    }
                    case 2:
                    {
                        if (!minions.IsEmpty())
                        {
                            ViewList();
                            Console.Write($"Укажите индекс миньона, которого хотите удалить (1..{minions.Count}): ");
                            int index = Int32.Parse(Console.ReadLine() ?? string.Empty) - 1;
                            minions.Delete(index);
                        }
                        else
                        {
                            Console.WriteLine("Список пуст!");
                        }
                        break;
                    }
                    case 3:
                    {
                        if (!minions.IsEmpty())
                        {
                            ViewList();
                        }
                        else
                        {
                            Console.WriteLine("Список пуст!");
                        }
                        break;
                    }
                    case 4:
                    {
                        if (!minions.IsEmpty())
                        {
                            Console.Write($"Укажите индекс миньона, которого хотите увидеть (1..{minions.Count}): ");
                            int index = Int32.Parse(Console.ReadLine() ?? string.Empty) - 1;
                            Console.WriteLine($"\nМиньон {minions[index].Name} - возраст {minions[index].Age}\n");
                        }
                        else
                        {
                            Console.WriteLine("Список пуст!");
                        }
                        
                        break;
                    }
                    case 5:
                    {
                        if (!minions.IsEmpty())
                        {
                            ViewList();
                            Console.Write($"Укажите индекс миньона, у которого хотите изменить имя (1..{minions.Count}): ");
                            int index = Int32.Parse(Console.ReadLine() ?? string.Empty) - 1;
                            Console.Write($"Укажите новое имя миньона: ");
                            string newname = Console.ReadLine();

                            minions[index].Name = newname;
                            ViewList();
                        }
                        else
                        {
                            Console.WriteLine("Список пуст!");
                        }
                       
                        break;
                    }
                    case 6:
                    {
                        if (!minions.IsEmpty())
                        {
                            Console.WriteLine("Создайте нового миньона для сравнения с миньоном из списка.");
                            Console.Write("Имя: ");
                            string name = Console.ReadLine();
                            Console.Write("Возраст: ");
                            int age = Int32.Parse(Console.ReadLine() ?? string.Empty);
                            Minion minion = new Minion(name, age);
                            
                            Console.Write($"\nС каким мьоном хотите сравнить? Укажите индекс (1..{minions.Count}): ");
                            ViewList();
                            int index = Int32.Parse(Console.ReadLine() ?? string.Empty) - 1;

                            int result = minions[index].CompareTo(minion);
                            if (result == 0)
                            {
                                Console.WriteLine("Эти миньоны одинаковы.");
                            }
                            if (result < 0)
                            {
                                Console.WriteLine("Ваш миньон младше.");
                            }
                            if (result > 0)
                            {
                                Console.WriteLine("Ваш миньон старше."); 
                            }
                        }
                        else
                        {
                            Console.WriteLine("Список пуст! Сравнивать не с кем.");
                        }

                        break;
                    }
                    case 0:
                    {
                        return;
                    }
                }
            }
        }

        private static int Menu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("0.ВЫХОД");
            sb.AppendLine("1.Добавить миньона в конец");
            sb.AppendLine("2.Удалить миньона");
            sb.AppendLine("3.Посмотреть список миньонов");
            sb.AppendLine("4.Посмотреть конкретного миньона");
            sb.AppendLine("5.Изменить имя конкретного миньона");
            sb.AppendLine("6.Сравнить миньонов по возрасту");
            Console.WriteLine(sb);
            int v = Int32.Parse(Console.ReadLine() ?? string.Empty);
            return v;
        }

        private static int Menu2()
        {
            StringBuilder sd = new StringBuilder();
            sd.AppendLine("1.Стек");
            sd.AppendLine("2.Список");  
            Console.WriteLine(sd);
            int v = Int32.Parse(Console.ReadLine() ?? string.Empty);
            return v;
        }

        private static void ViewList()
        {
            Console.WriteLine();
            int i = 1;
            foreach (var minion in minions)
            {
                Console.WriteLine(i++ + ". " + minion);
            }

            Console.WriteLine();
        }
    }
}