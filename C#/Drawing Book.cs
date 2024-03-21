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
     * Complete the 'pageCount' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER p
     */

    public static int pageCount(int n, int p)
    {
        int firstWay=0,lastWay=0;
        
        //book left to right
        for(int i=0; i<=n; i+=2)
        {
            if(p==i || p==i+1)
            {
                break;
            }
            firstWay++;
        }          
        
        //book right to left
        if(n%2==0)
        {
            if(n!=p)
            {
                lastWay=1;//because both n is even number and n equals p, skipped last page
                for(int i=n-1; i>0; i-=2)//that's why i=n-1
                {
                    if(p==i || p==i-1)
                    {
                        break;
                    }
                    lastWay++;
                }
            }
        }
        else
        {
            for(int i=n; i>0; i-=2)
            {
                if(p==i || p==i-1)
                {
                    break;
                }
                lastWay++;
            }
        }
        
        return firstWay>lastWay? lastWay : firstWay;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        int p = Convert.ToInt32(Console.ReadLine().Trim());

        int result = Result.pageCount(n, p);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
