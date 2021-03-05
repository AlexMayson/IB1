using System;
using System.Collections.Generic;

namespace Shifrovalshik
{
    class Cypher
    {
        static string[,] Rus = {{"Аа", "Бб", "Вв", "Гг", "Дд"},
                                  {"Ее", "Жж", "Зз", "Ии", "Йй"},
                                  {"Кк", "Лл", "Мм", "Нн", "Оо"},
                                  {"Пп", "Рр", "Сс", "Тт", "Уу"},
                                  {"Фф", "Хх", "Цц", "Чч", "Шш"},
                                  {"Щщ", "Ъъ", "Ыы", "Ьь", "Ээ"},
                                  {"Юю", "Яя", "!!", ",,", ".."}};

        static string[,] Lat = {{"Aa", "Bb", "Cc", "Dd", "Ee"},
                                  {"Ff", "Gg", "Hh", "Ii", "Jj"},
                                  {"Kk", "Ll", "Mm", "Nn", "Oo"},
                                  {"Pp", "Qq", "Rr", "Ss", "Tt"},
                                  {"Uu", "Vv", "Ww", "Xx", "Yy"},
                                  {"Zz", "..", ",,", "!!", "??"}};

        static Dictionary<string, string[,]> alphabets = new Dictionary<string, string[,]>() {
            {"Russian", Rus},
            {"Latin", Lat }
        };

        //Проверка принадлежности текста к определенному алфавиту
        static bool isValid(string text, string[,] alphabet)
        {
            bool[] temp = new bool[text.Length];

            for (int a = 0; a < text.Length; a++)
            {
                for (int i = 0; i < alphabet.GetLength(0); i++)
                {
                    for (int j = 0; j < alphabet.GetLength(1); j++)
                    {
                        if (text[a] == alphabet[i, j][0] || text[a] == alphabet[i, j][1])
                        {
                            temp[a] = true;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == false)
                {
                    return false;
                }
            }

            return true;
        }

        //Получение названия алфавита введенного текста
        static string GetAlphabetName(string text)
        {
            foreach (KeyValuePair<string, string[,]> kvp in alphabets)
            {
                string key = kvp.Key;
                if (isValid(text, kvp.Value))
                {
                    return key;
                }
            }

            return null;
        }

        //Кодирование текста на основе определенного алфавита
        static string Encode(string text, string[,] alphabet)
        {
            string buffer = "";

            for (int a = 0; a < text.Length; a++)
            {
                for (int i = 0; i < alphabet.GetLength(0); i++)
                {
                    for (int j = 0; j < alphabet.GetLength(1); j++)
                    {
                        if (text[a] == alphabet[i, j][0])
                        {
                            if (i + 1 < alphabet.GetLength(0))
                                buffer += alphabet[i + 1, j][0];
                            else
                                buffer += alphabet[0, j][0];
                        }
                        else if (text[a] == alphabet[i, j][1])
                        {
                            if (i + 1 < alphabet.GetLength(0))
                                buffer += alphabet[i + 1, j][1];
                            else
                                buffer += alphabet[0, j][1];
                        }
                    }
                }
            }

            return buffer;
        }


        //Декодирование текста
        static string Decode(string text, string[,] alphabet)
        {
            string buffer = "";

            for (int a = 0; a < text.Length; a++)
            {
                for (int i = 0; i < alphabet.GetLength(0); i++)
                {
                    for (int j = 0; j < alphabet.GetLength(1); j++)
                    {
                        if (text[a] == alphabet[i, j][0])
                        {
                            if (i - 1 >= 0)
                                buffer += alphabet[i - 1, j][0];
                            else
                                buffer += alphabet[alphabet.GetLength(0) - 1, j][0];
                        }
                        else if (text[a] == alphabet[i, j][1])
                        {
                            if (i - 1 >= 0)
                                buffer += alphabet[i - 1, j][1];
                            else
                                buffer += alphabet[alphabet.GetLength(0) - 1 , j][1];
                        }
                    }
                }
            }

            return buffer;
        }

        //Кодирование шифром Полибия
        public static string EncodePolibiy(string slovo)
        {
            string alphabetName = GetAlphabetName(slovo);
            if (alphabetName != null)
            {
                return Encode(slovo, alphabets[alphabetName]);
            }

            return null;
        }

        //Декодирование шифром Полибия
        public static string DecodePolibiy(string slovo)
        {
            string alphabetName = GetAlphabetName(slovo);
            if (alphabetName != null)
            {
                return Decode(slovo, alphabets[alphabetName]);
            }

            return null;
        }
    }
}