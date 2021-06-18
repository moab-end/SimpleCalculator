using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator.Utility
{
	class CustomValidation
	{
		//checks if expression is correct
		public static bool IsRegExValid(string sample) {

			Regex rgx = new Regex(@"([-+]?[0-9]*\.?[0-9]+[\/\+\-\*])+([-+]?[0-9]*\.?[0-9]+)|(?:[0-9-+*/^()x]|abs|e\^x|ln|log|a?(?:Sin|Sqrt)h?)+");

			if (rgx.IsMatch(sample)) return true;
			else return false;
		}
		//checks if number of brackets is even
		public static bool IsEven(string sample) {

			int evenNumb = 0;
		foreach(char c in sample)
			{
				if (c == '(') evenNumb++;

				if (c == ')') evenNumb--;
			}

			if (evenNumb == 0) return true;

			return false;
		}
	}
}
