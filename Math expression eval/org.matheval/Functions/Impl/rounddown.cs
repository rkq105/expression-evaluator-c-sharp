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
	/// Returns the largest integral value less than or equal to the specified number.
	/// ROUNDDOWN(3.7) -> 3
	/// ROUNDDOWN(3.7,2) -> 2
	/// ROUNDDOWN(1.58,0.1) -> 1.5
	/// ROUNDDOWN(0.234,0.01) -> 0.23
	/// ROUNDDOWN(-2.5,-2) -> -2
	/// </summary>
	public class rounddownFunction : IFunction
	{
		/// <summary>
		/// Get Information
		/// </summary>
		/// <returns>FunctionDefs</returns>
		public List<FunctionDef> GetInfo()
		{
			return new List<FunctionDef>{
					   new FunctionDef(Afe_Common.Const_Rounddown, new System.Type[]{ typeof(decimal) }, typeof(decimal), 1),
					   new FunctionDef(Afe_Common.Const_Rounddown, new System.Type[] { typeof(decimal), typeof(decimal) }, typeof(decimal), 2)};
		}

		/// <summary>
		/// Execute
		/// </summary>
		/// <param name="args">args</param>
		/// <param name="dc">dc</param>
		/// <returns>Value</returns>
		public Object Execute(Dictionary<string, Object> args, ExpressionContext dc)
		{
			return this.RoundDown(args, dc);
		}

		/// <summary>
		/// Floor
		/// </summary>
		/// <param name="args">args</param>
		/// <returns>Value RoundDown</returns>
		public decimal RoundDown(Dictionary<string, Object> args, ExpressionContext dc)
		{
			if (args.Count == 1)
			{
				return Math.Floor(Afe_Common.ToDecimal(args[Afe_Common.Const_Key_One], dc.WorkingCulture));
			}
			else
			{
				return Math.Floor(Afe_Common.ToDecimal(args[Afe_Common.Const_Key_One], dc.WorkingCulture) / Afe_Common.ToDecimal(args[Afe_Common.Const_Key_Two], dc.WorkingCulture)) * Afe_Common.ToDecimal(args[Afe_Common.Const_Key_Two], dc.WorkingCulture);
			}
		}
	}
}
