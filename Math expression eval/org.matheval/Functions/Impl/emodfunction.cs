/*
    The MIT License

    Copyright (c) 2021 MathEval.org

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
*/
using org.matheval.Common;
using System;
using System.Collections.Generic;

namespace org.matheval.Functions
{
	/// <summary>
	/// EMOD(11,2) -> 1
	/// EMOD(6.25,1) -> 0.25
	/// EMOD(100,33) -> 1
	/// </summary>
	public class emodFunction : IFunction
	{
		/// <summary>
		/// Get Information
		/// </summary>
		/// <returns>FunctionDefs</returns>
		public List<FunctionDef> GetInfo()
		{
			return new List<FunctionDef>{
					new FunctionDef(Afe_Common.Const_Emod, new System.Type[]{ typeof(decimal), typeof(decimal) }, typeof(decimal), 2)};
		}

		/// <summary>
		/// Execute
		/// </summary>
		/// <param name="args">args</param>
		/// <param name="dc">dc</param>
		/// <returns>Value</returns>
		public Object Execute(Dictionary<string, Object> args, ExpressionContext dc)
		{
			return this.Emod(args, dc);
		}

		/// <summary>
		/// Mod
		/// </summary>
		/// <param name="left">left</param>
		/// <param name="right">right</param>
		/// <returns>Value Emod</returns>
		public decimal Emod(Dictionary<string, Object> args, ExpressionContext dc)
		{
			Object left = Afe_Common.ToDecimal(args[Afe_Common.Const_Key_One], dc.WorkingCulture);
			Object right = Afe_Common.ToDecimal(args[Afe_Common.Const_Key_Two], dc.WorkingCulture);
			if (left is decimal leftDecimal && right is decimal rightDecimal)
			{
				decimal quotient = Math.Floor(leftDecimal / rightDecimal);
				return leftDecimal - (rightDecimal * quotient);
			}
			throw new Exception("Remainder operator can be only apply for integer/long");
		}
	}
}
