using System;

namespace FlashLib
{
	public class FlashCard
	{
		public string Op { get; set; }
		public int Num1 { get; set; }
		public int Num2 { get; set; }
		public string BuildEquation()
		{
			Random rnd = new Random();
			Num1 = rnd.Next(1, 15);
			Num2 = rnd.Next(1, 15);
			return string.Format("{0} {1} {2} = ", Num1, Op, Num2);
		}
		public double CalcAnswer()
		{
			int answer = Num1 - Num2;
			switch (Op)
			{
				case "+": answer = Num1 + Num2; break;
				case "*": answer = Num1 * Num2; break;
			}
			return answer;
		}

		public bool CheckAnswer(int answer)
		{
			if (answer == CalcAnswer()) return true;
			return false;
		}
	}
}
