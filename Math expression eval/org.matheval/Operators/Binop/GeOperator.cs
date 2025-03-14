﻿/*
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
using static org.matheval.Common.Afe_Common;

namespace org.matheval.Operators.Binop
{
    /// <summary>
    /// Create class Greater or equal operator implements AbstractBinOperator
    /// For Example:
    /// 124 >= 123 -> true
    /// 124 >= 124 -> true
    /// 124 >= 125 -> false
    /// </summary>
    public class GeOperator : AbstractBinOperator
    {
        /// <summary>
        /// Initializes a new instance structure to a specified type string value and type int value and value assoc
        /// </summary>
        /// <param name="op">op</param>
        /// <param name="precedence">precedence</param>
        /// <param name="assoc">assoc</param>
        public GeOperator(string op, int precedence, Assoc assoc) : base(op, precedence, assoc)
        {
        }

        /// <summary>
        /// Calculate result
        /// </summary>
        /// <param name="left">left</param>
        /// <param name="right">right</param>
        /// <param name="dc">dc</param>
        /// <returns>value Calculate</returns>
        public override object Calculate(object left, object right, ExpressionContext dc)
        {
            if (System.Object.ReferenceEquals(left, null) || System.Object.ReferenceEquals(right, null))
            {
                if (System.Object.ReferenceEquals(left, null) && System.Object.ReferenceEquals(right, null))
                {
                    return true;
                }
                return false;
            }
            /*if (left is decimal && right is decimal)
            {
                //return (decimal)left >= (decimal)right;
                return Afe_Common.Round((decimal)left, dc) >= Afe_Common.Round((decimal)right, dc);
            }*/
            if (Common.Afe_Common.IsNumber(left) && Common.Afe_Common.IsNumber(right))
            {
                decimal leftDecimal = Afe_Common.ToDecimal(left, dc.WorkingCulture);
                decimal rightDecimal = Afe_Common.ToDecimal(right, dc.WorkingCulture);
                return Afe_Common.Round(leftDecimal, dc) >= Afe_Common.Round(rightDecimal, dc);
            }
            else if (left is bool && right is bool)
            {
                return (bool)left == true && (bool)right == false;
            }
			else if ((left is string && right is string) ||
				(Common.Afe_Common.IsNumber(left) && right is string) ||
				(left is string && Common.Afe_Common.IsNumber(right)))
			{
				return left.ToString().CompareTo(right.ToString()) >= 0;
            }
            else if (left is TimeSpan && right is TimeSpan)
            {
                return (TimeSpan)left >= (TimeSpan)right;
            }
            else if (left is DateTime && right is DateTime)
            {
                return (DateTime)left >= (DateTime)right;
            }
            throw new Exception(string.Format(MSG_WRONG_OP_PARAM_EX, new string[] { "Comparison", "Integer, Boolean, Datetime" }));
        }

        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="typeLeft">typeLeft</param>
        /// <param name="typeRight">typeRight</param>
        /// <returns>Type</returns>
        public override Type Validate(Type typeLeft, Type typeRight)
        {
            if (
                ((typeLeft.Equals(typeof(decimal)) || typeLeft.Equals(typeof(object)))
                &&
                (typeRight.Equals(typeof(decimal)) || typeRight.Equals(typeof(object))))
                ||
                ((typeLeft.Equals(typeof(bool)) || typeLeft.Equals(typeof(object)))
                &&
                (typeRight.Equals(typeof(bool)) || typeRight.Equals(typeof(object))))
                ||
                ((typeLeft.Equals(typeof(string)) || typeLeft.Equals(typeof(object)))
                &&
                (typeRight.Equals(typeof(string)) || typeRight.Equals(typeof(object))))
                ||
                ((typeLeft.Equals(typeof(TimeSpan)) || typeLeft.Equals(typeof(object)))
                &&
                (typeRight.Equals(typeof(TimeSpan)) || typeRight.Equals(typeof(object))))
                ||
                ((typeLeft.Equals(typeof(DateTime)) || typeLeft.Equals(typeof(object)))
                &&
                (typeRight.Equals(typeof(DateTime)) || typeRight.Equals(typeof(object))))
               )
            {
                return typeof(bool);
            }
            /* if (typeLeft.Equals(typeof(decimal)) && typeRight.Equals(typeof(decimal)) ||
             typeLeft.Equals(typeof(bool)) && typeRight.Equals(typeof(bool)) ||
             typeLeft.Equals(typeof(string)) && typeRight.Equals(typeof(string)) ||
             typeLeft.Equals(typeof(TimeSpan)) && typeRight.Equals(typeof(TimeSpan)) ||
             typeLeft.Equals(typeof(DateTime)) || typeLeft.Equals(typeof(DateTime)) ||
             typeLeft.Equals(typeof(object)) || typeRight.Equals(typeof(object)))
             {
                 return typeof(bool);
             }*/
            return null;
        }
    }
}
