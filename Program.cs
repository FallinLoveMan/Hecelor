using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Bir cümle girin: ");
        string cumle = Console.ReadLine();
        string[] kelimeler = cumle.Split(' ');

        List<string> heceler = new List<string>();
        foreach (var kelime in kelimeler)
        {
            heceler.AddRange(Hecele(kelime));
        }

        Console.WriteLine($"Heceler: {string.Join("-", heceler)}\n");
    }

    static List<string> Hecele(string kelime)
    {
        int uzunluk = kelime.Length;
        string sesliler = "aeıioöuüAEIİOÖUÜ";
        string noktalamalar = ".,!?;:'\"";
        List<string> heceler = new List<string>();
        string hece = "";
        int i = 0;
        int j = 0;

        while (i < uzunluk)
        {
            if (sesliler.Contains(kelime[i]))
            {
                hece += kelime[i];
                j = 1;

                if ((i + 1) < uzunluk && !sesliler.Contains(kelime[i + 1]))
                {
                    if (!noktalamalar.Contains(kelime[i + 1]))
                    {
                        if ((i + 2) < uzunluk)
                        {
                            if (!sesliler.Contains(kelime[i + 2]))
                            {
                                hece += kelime[i + 1];
                                j = 2;

                                if (!noktalamalar.Contains(kelime[i + 2]))
                                {
                                    if ((i + 3) < uzunluk)
                                    {
                                        if (!sesliler.Contains(kelime[i + 3]))
                                        {
                                            hece += kelime[i + 2];
                                            j = 3;
                                        }
                                    }
                                    else
                                    {
                                        if (!noktalamalar.Contains(kelime[i + 2]))
                                        {
                                            hece += kelime[i + 2];
                                            j = 4;
                                        }
                                        else
                                        {
                                            j = 2;
                                        }
                                    }
                                }
                                else
                                {
                                    j = 1;
                                }
                            }
                        }
                        else
                        {
                            if (!noktalamalar.Contains(kelime[i + 1]))
                            {
                                hece += kelime[i + 1];
                                j = 3;
                            }
                            else
                            {
                                j = 1;
                            }
                        }
                    }
                }

                heceler.Add(hece);
                i += j;
                j = 0;
                hece = "";
            }
            else
            {
                if (!noktalamalar.Contains(kelime[i]))
                {
                    hece += kelime[i];
                }
                else
                {
                    heceler.Add(kelime[i].ToString());
                    hece = "";
                }
                i++;
            }
        }

        return heceler;
    }
}
