using System;

namespace lr3.Services
{
	public interface ICalcService
	{
		int Add(int a, int b);
		int Subtract(int a, int b);
		int Multiply(int a, int b);
		double Divide(int a, int b);
	}

	public class CalcService : ICalcService
	{
		public int Add(int a, int b) => a + b;

		public int Subtract(int a, int b) => a - b;

		public int Multiply(int a, int b) => a * b;

		public double Divide(int a, int b)
		{
			if (b == 0)
				throw new DivideByZeroException("Cannot divide by zero");
			return (double)a / b;
		}
	}
}