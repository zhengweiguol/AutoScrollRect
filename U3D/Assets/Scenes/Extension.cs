using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

    public static class Extension
    {
        /// <summary>
        /// 获取字符串全角长度，一个汉字算二个
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetFullLength(this string str)
        {
            if (str.Length == 0) return 0;
            ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0; byte[] s = ascii.GetBytes(str);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                    tempLen += 2;
                else
                    tempLen += 1;
            }
            return tempLen;
        }

        /// <summary>
        /// 判断是否有非法字符
        /// </summary>
        /// <returns></returns>
        public static bool CheckIllegalChar(this string str)
        {
            Regex reg = new Regex("[?!@#$%\\^&*()]+");
            Match m = reg.Match(str);
            return m.Success;
        }

        /// <summary>
        /// 保证返回数据为范围内的数值.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val">待测值.</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns>T.</returns>
        public static T Limit<T>(this T val, T min, T max) where T : IComparable
        {
            var maxVal = (val.CompareTo(min) > 0) ? val : min;
            var minVal = (maxVal.CompareTo(max) > 0) ? max : maxVal;
            return minVal;
        }


        public static Vector2 ToVector2(this int[] val)
        {
            return new Vector2(val[0], val[1]);
        }
        public static Vector3 ToVector3(this int[] val)
        {
            return new Vector3(val[0], val[1],val[3]);
        }


        /// <summary>
        /// 万分比值 转成  百分比字符串  1=0.01%
        /// </summary>
        /// <param name="myriadVal"></param>
        /// <returns></returns>
        public static string ToPctString(this int val)
        {
            return val / 100f + "%";
        }
        
        /// <summary>
        /// 货币显示转换
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ToMoney(this int val)
        {
            return ToMoney((long) val);
        }
        /// <summary>
        /// 货币显示转换
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ToMoney(this long val)
        {
            string money = string.Empty;
            if (val < 100000)
                money = val.ToString();
            else if (val < 10000000)
                money = (val / 1000) + "K";
            else
                money = (val / 1000000) + "M";
            return money;
        }

        /// <summary>
        /// Float  按照Step转换成Int
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int StepToInt(this float vals,int Step)
        {
            int index = Mathf.FloorToInt(vals / Step);
            index = index == 0 ? 0 : index++;
            return index;
        }
        /// <summary>
        /// Int  按照Step转换成Int
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int StepToInt(this int vals, int Step)
        {
            int index = Mathf.FloorToInt(vals / Step);
            index = index == 0 ? 0 : index++;
            return index;
    } 
    /// <summary>
       /// Int  按照Step转换成Int
       /// </summary>
       /// <param name="val"></param>
       /// <returns></returns>
    public static int StepToInt(this float vals, float Step)
    {
        //Debug.Log("Step"+Step);
        //Debug.Log("vals" + vals);
        int index = Mathf.FloorToInt(vals / Step);
        index = index == 0 ? 0 : index++;
        //Debug.Log("index" + index);
        return index;
    }
}

