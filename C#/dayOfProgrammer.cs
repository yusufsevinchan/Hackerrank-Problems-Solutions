using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'dayOfProgrammer' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER year as parameter.
     */

    public static string dayOfProgrammer(int year)
    {
        int february;
        int sumOtherMonths=215;//first 8 months, except february
        int leapDay;
        if(year<1918)
        {
            if(year%4==0)
            {
                february=29;
                sumOtherMonths+=february;
            }
            else
            {
                february=28;
                sumOtherMonths+=february;
            }
            
            leapDay=256-sumOtherMonths;
            return $"{leapDay}.09.{year}";
        }
        else if(year>1918)
        {
            if(year%400==0)
            {
                february=29;
                sumOtherMonths+=february;
            }
            else if(year%4==0&&year%100!=0)
            {
                february=29;
                sumOtherMonths+=february;
            }
            else
            {
                february=28;
                sumOtherMonths+=february;
            }
            
            leapDay=256-sumOtherMonths;
            return $"{leapDay}.09.{year}";
        }
        else
        {
            sumOtherMonths-=13;
            //for 14 february was the 32nd day of the year in 1918, 
            //so 13 day are missing
            february=28;//1918 is not divisible by 4
            sumOtherMonths+=february;
            
            leapDay=256-sumOtherMonths;
            return $"{leapDay}.09.{year}";
        }
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int year = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.dayOfProgrammer(year);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
