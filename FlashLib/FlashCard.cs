using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashLib
{
	public class FlashCard
	{
		public string Op { get; set; }
		public double Num1 { get; set; }
		public double Num2 { get; set; }
		public string BuildEquation()
		{
			Random rnd = new Random();
			Num1 = rnd.Next(2, 100);
			Num2 = rnd.Next(2, 100);
			return string.Format("{0} {1} {2} = ", Num1, Op, Num2);
		}
		public double CalcAnswer()
		{
			double answer = Num1 - Num2;
			switch (Op)
			{
				case "+": answer = Num1 + Num2; break;
				case "*": answer = Num1 * Num2; break;
				case "/": answer = Num1 / Num2; break;
			}
			return answer;
		}

		public bool CheckAnswer(double answer)
		{
			if (answer == CalcAnswer()) return true;
			return false;
		}
	}
}
