using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Utility
{
	 class NumberRepresentation
	{
		private static string transform_ones(string Number)
		{
			int _Number = Convert.ToInt32(Number);
			string name = "";
			switch (_Number)
			{

				case 1:
					name = "Jedan";
					break;
				case 2:
					name = "Dva";
					break;
				case 3:
					name = "Tri";
					break;
				case 4:
					name = "Cetiri";
					break;
				case 5:
					name = "Pet";
					break;
				case 6:
					name = "Sest";
					break;
				case 7:
					name = "Sedam";
					break;
				case 8:
					name = "Osam";
					break;
				case 9:
					name = "Devet";
					break;
			}
			return name;
		}

		private static string transform_tens(string Number)
		{
			int _Number = Convert.ToInt32(Number);
			string name = null;

			switch (_Number)
			{
				case 10:
					name = "Deset";
					break;
				case 11:
					name = "Jedanaest";
					break;
				case 12:
					name = "Dvanaest";
					break;
				case 13:
					name = "Trinaest";
					break;
				case 14:
					name = "Cetrnaest";
					break;
				case 15:
					name = "Petnaest";
					break;
				case 16:
					name = "Sestnaest";
					break;
				case 17:
					name = "Sedamnaest";
					break;
				case 18:
					name = "Osamnaest";
					break;
				case 19:
					name = "Devetnaest";
					break;
				case 20:
					name = "Dvadeset";
					break;
				case 30:
					name = "Trideset";
					break;
				case 40:
					name = "Cetrdeset";
					break;
				case 50:
					name = "Pedeset";
					break;
				case 60:
					name = "Sezdeset";
					break;
				case 70:
					name = "Sedamdeset";
					break;
				case 80:
					name = "Osamdeset";
					break;
				case 90:
					name = "Devedeset";
					break;
				default:
					if (_Number > 0)
					{
						name = transform_tens(Number.Substring(0, 1) + "0") + " " + transform_ones(Number.Substring(1));
					}
					break;

			}
			return name;
		}
		private static string transform_hundreds(string Number)
		{
			int _Number = Convert.ToInt32(Number);
			string name = "";

			switch (_Number)
			{
				case 100:
					name = "Sto";
					break;
				case 200:
					name = "Dvesta";
					break;
				case 300:
					name = "Trista";
					break;
				case 400:
					name = "Cetiristo";
					break;
				case 500:
					name = "Petsto";
					break;
				case 600:
					name = "Sesto";
					break;
				case 700:
					name = "Sedamsto";
					break;
				case 800:
					name = "Osamsto";
					break;
				case 900:
					name = "Devetsto";
					break;

				default:

					if (_Number > 0)
					{

						name = transform_hundreds(Number.Substring(0, 1) + "00") + " " + transform_tens(Number.Substring(1));
					}
					break;

			}
			return name;

		}
		// 12 digits left from decimal
		private static string transform_whole_number(string Number)
		{
			
			string word = "";
		
			try
			{
				bool beginsZero = false;
				bool isDone = false;

				double doubleNumber = Convert.ToDouble(Number);
				if (doubleNumber > 0)
				{
					beginsZero = Number.StartsWith("0");

					int numberOfDigits = Number.Length;
					int position = 0;
					string place = "";

					switch (numberOfDigits)
					{
						case 1:
							word = transform_ones(Number);
							isDone = true;
							break;
						case 2:
							word = transform_tens(Number);
							isDone = true;
							break;
						case 3:
							word = transform_hundreds(Number);
							isDone = true;
							break;
						case 4:
						case 5:
						case 6:
							position = (numberOfDigits % 4) + 1;
							Console.WriteLine(doubleNumber);
							place = "Hiljada";
							break;
						case 7:
						case 8:
						case 9:
							position = (numberOfDigits % 7) + 1;
							place = "Miliona";
							break;
						case 10:
						case 11:
						case 12:
							position = (numberOfDigits % 10) + 1;
							place = "Milijarda";
							break;

						default:
							isDone = true;
							break;


					}
					//if it is not done, then we do it again, recursion 
					if (!isDone)
					{
						if (Number.Substring(0, position) != "0" && Number.Substring(position) != "0")
						{
							try
							{
								word = transform_whole_number(Number.Substring(0, position)) + " " + place + " " + transform_whole_number(Number.Substring(position));
							}
							catch (Exception e)
							{

							}
						}
						else
						{
							word = transform_whole_number(Number.Substring(0, position)) + " " + transform_whole_number(Number.Substring(position));
						}
					}
					if (word.Trim().Equals(place.Trim())) word = "";
				}

			}
			catch (Exception e)
			{

			}
			return word.Trim();
		}
		private static string transform_decimals(string Number)
		{
			string digit = "";
			string decimal_word = "";
			string digit_word = "";

			for (int i = 0; i < Number.Length; i++)
			{
				digit = Number[i].ToString();
				if (digit == "0")
					digit_word = "Nula";
				else
					digit_word = transform_ones(digit);
				decimal_word = decimal_word + " " + digit_word;
			}

			return decimal_word;

		}

		public static string transform_number_toString(string Number)
		{
			string value = "";
			string wholeNumber = Number;
			string andStr = "";
			string decimalNumber = "";
			string decimalString = "";
			string isNegative = "";

			try
			{
				if (Number == "0") return "Nula";

				if (Number.Contains("-"))
				{
					isNegative = "minus";
					Number = Number.Substring(1, Number.Length - 1);
				}

				int decimalPlace = Number.IndexOf(".");
				if (decimalPlace > 0)
				{
					wholeNumber = Number.Substring(0, decimalPlace);
					decimalNumber = Number.Substring(decimalPlace + 1);

					if (Convert.ToInt64(decimalNumber) > 0)
					{
						andStr = "zapeta";
						decimalString = transform_decimals(decimalNumber);
					}

				}
				if (wholeNumber.Length > 12) return "Number too big to give string representation!!!";

				value = String.Format("{0} {1} {2} {3} ", isNegative, transform_whole_number(wholeNumber).Trim(), andStr, decimalString);

			}
			catch (Exception e) { }

			return value;
		}
	}
}
