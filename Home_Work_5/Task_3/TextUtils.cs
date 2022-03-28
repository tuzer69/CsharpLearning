using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class TextUtils
    {
        public static string ClearString(string text)
        {
            
            string lowText = text.ToLower(); //Вecь текст в нижний реестр
            char prevSym = lowText[0];
            string outStr = prevSym.ToString();
            for (int i = 0; i < lowText.Length; i++)
            {
                
                if (i  < lowText.Length)
                {
                    if (lowText[i] != prevSym) //Если текущий не равен предидущему символу
                    {
                        outStr += lowText[i];
                    }

                    prevSym = lowText[i];
                }
            }

            return outStr;
        }

    }
}
