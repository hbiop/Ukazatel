using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ukazatel
{
    public static class PredmetniyUkazatel
    {
        private static Dictionary<string, int[]> ukazateli = new Dictionary<string, int[]>();


        public static string DobavitUkazatel(string slovo, int[] stranici)
        {
            if (ukazateli.ContainsKey(slovo))
            {
                return "Вы не можете добавить это слово так как указатель к нему уже существует";
            }
            else
            {
                ukazateli.Add(slovo, stranici);
                return $"Указатель {slovo} был добавлен";
            }
        }

        public static string UdalitUkazatel(string slovo)
        {
            if (ukazateli.ContainsKey(slovo))
            {
                ukazateli.Remove(slovo);
                return $"Указатель {slovo} был удалён";
            }
            else
            {
                return $"Такого указателя не существует";
            }
        }

        public static string PoluchitStraniciDlyaUkazatelia(string slovo)
        {
            if (ukazateli.ContainsKey(slovo))
            {
                return String.Join(", ", ukazateli[slovo]);
            }
            else
            {
                return "Такого указателя не существует";
            }
        }

        public static Dictionary<string, int[]> PoluchitVseUkazateli()
        {
            return ukazateli;
        }
    }
}
