using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Task_2
{
    class StringUtils
    {
        /// <summary>
        /// Данный метод находит слово из текста (text) с минимальной длинной
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string MinStr(string text)
        {
            string[] str = text.Split(new[] { ' ', '\n', '.', ',', ':',';','?', '(',')' }, 
                StringSplitOptions.RemoveEmptyEntries);
            string retstr = str[0];
            for (int i = 0; i < str.GetLength(0); i++)
            {
                if (str[i].Length < retstr.Length) retstr = str[i];
            }

            return retstr;
        }
        /// <summary>
        /// Метод для поиска слов максимльно длинных слов
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string[] MaxStr(string text)
        {
            string[] str = text.Split(new[] { ' ', '\n', '\r', '.', ',', ':', ';', '?', '(', ')','[',']','{','}' },
                StringSplitOptions.RemoveEmptyEntries);
            int Max_len = 0;
            int Max_count = 0;
            
            for (int i = 0; i < str.GetLength(0); i++)
            {
                string max_word = "";
                if (str[i].Length > Max_len)
                {
                    Max_len = str[i].Length;
                    if (str[i] != max_word)
                    {
                        Max_count++;
                        max_word = str[i];
                    }
                    
                } 
                
            }

            int index_word = 0;
            string[] out_words = new string[Max_count];
            for (int i = 0; i < str.GetLength(0); i++)
            {

                if (str[i].Length == Max_len)
                {
                    out_words[index_word] = str[i];
                    if (index_word != str.GetLength(0)) index_word++;
                }
            }
            

            return out_words;
        }
    }
}
