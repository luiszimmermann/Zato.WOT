using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zato.WOT.Utils
{
	public static class RomanNumeral
	{
		public static string ToRoman(this long number)
		{
			var romanNumerals = new string[][]
			{
			new string[]{"", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"},
			new string[]{"", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC"},
			new string[]{"", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"},
			new string[]{"", "M", "MM", "MMM"}
			};

			var intArr = number.ToString().Reverse().ToArray();
			var len = intArr.Length;
			var romanNumeral = "";
			var i = len;
			while (i-- > 0)
			{
				romanNumeral += romanNumerals[i][Int32.Parse(intArr[i].ToString())];
			}

			return romanNumeral;
		}

		public static string ToRoman(this int number)
		{
			return Convert.ToInt64(number).ToRoman();
		}
	}
}
