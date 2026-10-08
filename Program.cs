//using klfg = System.Collections.Generic.List<int>[];

using System.Collections.Immutable;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {
            int Razryd = 9;
            int GlobalCount = 81;
            var Prognozu = new List<int>[Razryd, Razryd];
            for (int i = 0; i < Razryd; i++)
            {
                for (int j = 0; j < Razryd; j++)
                {
                    Prognozu[i, j] = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                }
            }
            LocalVvod();
            /* do
             {
                 VvodSvodki();
                 Console.WriteLine("Для ввода следующих цифр нажмите Y. Для запуска программы нажмите любую клавишу ");
             }
             while (Console.ReadKey(true).Key == ConsoleKey.Y);
            */
            FastPencil();
            VuvodSvodki();
            
            void VvodSvodki() //Проверочки ввода дописать
            {
                Console.Write("Введите номер строки ");
                byte str = byte.Parse(Console.ReadLine());
                Console.Write("Введите номер столбца ");
                byte stolb = byte.Parse(Console.ReadLine());
                Console.Write("Введите цифру в этой ячейке ");
                int cifra = int.Parse(Console.ReadLine());
                Prognozu[str - 1, stolb - 1] = new List<int> { cifra };
                GlobalCount--;
            }

            void LocalVvod()
            {
                Prognozu[0, 0] = new List<int> { 7 };
                Prognozu[0, 1] = new List<int> { 8 };
                Prognozu[0, 3] = new List<int> { 5 };
                Prognozu[0, 4] = new List<int> { 1 };

                Prognozu[1, 2] = new List<int> { 2 };
                Prognozu[1, 7] = new List<int> { 9 };

                Prognozu[2, 8] = new List<int> { 2 };

                Prognozu[3, 1] = new List<int> { 5 };
                Prognozu[3, 2] = new List<int> { 8 };
                Prognozu[3, 4] = new List<int> { 6 };
                Prognozu[3, 5] = new List<int> { 9 };

                Prognozu[4, 0] = new List<int> { 3 };
                Prognozu[4, 4] = new List<int> { 7 };
                Prognozu[4, 6] = new List<int> { 4 };

                Prognozu[6, 5] = new List<int> { 6 };
                Prognozu[6, 6] = new List<int> { 8 };

                Prognozu[7, 2] = new List<int> { 7 };
                Prognozu[7, 7] = new List<int> { 1 };

                Prognozu[8, 0] = new List<int> { 2 };
                Prognozu[8, 1] = new List<int> { 4 };
                Prognozu[8, 7] = new List<int> { 5 };
                Prognozu[8, 8] = new List<int> { 7 };
            }

            void VuvodSvodki()
            {
                Console.WriteLine("Сводка сейчас: ");
                Console.WriteLine("№ стр, №столб, прогнозы ");
                for (int i = 0; i < Razryd; i++)
                {
                    for (int j = 0; j < Razryd; j++)
                    {
                        Console.Write((i + 1) + "\t" + (j + 1) + "\t");
                        for (int k = 0; k < Prognozu[i, j].Count; k++)
                        {
                            Console.Write(Prognozu[i, j][k].ToString() + " ");
                        }
                        Console.WriteLine();
                    }
                }
            }
            void FastPencil()
            {
                for (int i = 0; i < Razryd; i++)
                {
                    for (int j = 0; j < Razryd; j++)
                    {
                        if (Prognozu[i, j].Count == 1)
                        {
                            Udalenie(i, j, Prognozu[i, j][0]);
                        }
                    }
                }
            }
            void Udalenie(int indstr, int indstolb, int chislo)
            {
                for (int i = 0; i < Razryd; i++)
                {
                    //Console.WriteLine("В удалении: " + (indstolb + 1) + " " + (indstolb + 1) + " " + (i + 1) + " " + chislo);
                    if (i != indstolb && Prognozu[indstr, i].Count != 1)
                    {
                        Prognozu[indstr, i].Remove(chislo);  //Удаление в строке
                        //Console.WriteLine("В удалении str: " + (i + 1) + " " + (indstolb + 1));
                    }
                    if (i != indstr && Prognozu[i, indstolb].Count != 1)
                    {
                        Prognozu[i, indstolb].Remove(chislo);  //Удаление в столбце
                        //Console.WriteLine("В удалении stolb: " + (indstolb + 1) + " " + (i + 1));
                    }
                }
                UdalenieVPole();
                void UdalenieVPole()
                {
                    int nachaloindstr = ((indstr) / 3) * 3;
                    int nachaloindstolb = ((indstolb) / 3) * 3;
                    int konecindstr = ((indstr / 3)) * 3 + 2;
                    int konecindstolb = ((indstolb / 3)) * 3 + 2;

                    // Console.WriteLine("Out : " + indstolb + " " + indstolb + " " + nachaloindstr + " " + nachaloindstolb + " " + konecindstr + " "+ konecindstolb);
                    for (int i = nachaloindstr; i <= konecindstr; i++)
                    {
                        if (i != indstr)
                        {
                            for (int j = nachaloindstolb; j <= konecindstolb; j++)
                            {
                                if (j != indstolb)
                                {
                                    // Console.WriteLine("Inside : " + indstolb + " " + indstolb + " " + nachaloindstr + " " + nachaloindstolb + " " + i + " " + j);
                                    Prognozu[i, j].Remove(chislo);
                                }
                            }
                        }
                    }
                }
            }
            //======================
            void VuvodVKonechnoeZnach(int indstr, int indstolb, int chislo)
            {
                Console.WriteLine("Конечное значение: " + (indstr + 1) + " " + (indstolb + 1) + " " + chislo);
                Prognozu[indstr, indstolb] = new List<int> { chislo };
                Udalenie(indstr, indstolb, chislo);

            }
            void EdinReshenStr(int indstr) //ни к селу ни к городу 
            {
                var jkfg = new List<List<int>>[9];
                for (int i = 0; i < Razryd; i++)
                {
                    jkfg[i].Add(Prognozu[indstr, i]);
                }
            }
            void SostoynieStr(int indstr)
            {
                Console.WriteLine("Состояние стр");
                var Vremynka = new int[Razryd, Razryd];
                for (int i = 0; i < Razryd; i++) // i цифра прогноза
                { 
                    if (Prognozu[indstr, i].Count != 1)
                    {
                        for (int j = 0; j < Razryd; j++) //j индекс столбца
                        {
                            if (Prognozu[indstr, i].Any(k => k == j + 1))
                            {
                                Vremynka[i, j] = 1;
                            }
                        }
                    }
                }
                //номер строчки - номер столбца
                //count - кол-во прогнозов в ячейке

                //==================
                //чисто вывод
                {
                    for (int i = 0; i < Razryd; i++)
                    {
                        int count = 0;
                        for (int j = 0; j < Razryd; j++)
                        {
                            count += Vremynka[i, j];
                            Console.Write(Vremynka[i, j] + "\t");
                        }
                        Console.Write("\t" + count);
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    for (int i = 0; i < Razryd; i++)
                    {
                        int count = 0;
                        for (int j = 0; j < Razryd; j++)
                        {
                            count += Vremynka[j, i];
                        }
                        Console.Write(count + "\t");
                    }
                    Console.WriteLine();
                }

                //================
                {
                  /* for (int i = 0; i < Razryd; i++)
                    {
                        int count = 0;
                        for (int j = 0; j < Razryd; j++)
                        {
                            count += Vremynka[i, j];
                            Console.Write(Vremynka[i, j] + "\t");
                        }
                        Console.Write("\t" + count);
                        Console.WriteLine();
                    }
                    Console.WriteLine();*/
                    for (int i = 0; i < Razryd; i++)
                    {
                        int count = 0;
                        for (int j = 0; j < Razryd; j++)
                        {
                            count += Vremynka[j, i];
                        }
                        //Console.Write(count + "\t");
                        if (count == 1)
                        {
                            //Console.WriteLine("djkhfjsahvjashjasghjfba");
                            for (int j = 0; j < Razryd; j++)
                            {
                                if (Vremynka[j, i] == 1)
                                {
                                    //Udalenie(indstr, i, j + 1);
                                    VuvodVKonechnoeZnach(indstr, j, i + 1);
                                }
                            }
                        }
                    }
                    Console.WriteLine();
                }
            }
            void SostoynieStolb(int indstolb)
            {
                Console.WriteLine("Состояние столб");

                var Vremynka = new int[Razryd, Razryd];
                for (int i = 0; i < Razryd; i++)
                {
                    if (Prognozu[i,indstolb].Count != 1)
                    {
                        for (int j = 0; j < Razryd; j++)
                        {
                            if (Prognozu[i, indstolb].Any(k => k == j + 1))
                            {
                                Vremynka[i, j] = 1;
                            }
                        }
                    }
                }
                for (int i = 0; i < Razryd; i++)
                {
                    for (int j = 0; j < Razryd; j++)
                    {
                        Console.Write(Vremynka[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
           // SostoynieStolb(0);
            SostoynieStr(0);
            VuvodSvodki();
            SostoynieStr(0);
            Console.WriteLine("Конец!");
            Console.ReadLine();
        }
    }
}
/*реализовано единственное место в строке
 
 */

