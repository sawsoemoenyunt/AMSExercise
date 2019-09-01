using System;

class Sequence
{
    public static void Main()
    {
        // string dna = "GTAGAGCTGT";
        // int k = 3;
        // System.Console.WriteLine(dna);
        // string[] res = Kmers(k, ref dna);
        // for (int i = 0; i < res.Length; i++)
        // {
        //     System.Console.WriteLine(res[i]);
        // }
        // System.Console.WriteLine(dna);
        // bool resBool = Dyad("TTACGnnnnnnCGTAA", 5);
        // System.Console.WriteLine(resBool);
    }

    //Dyad
    public static bool Dyad(string dna, int dyadMinimum = 5)
    {
        bool result = false;

        if (dna.Length > 0)
        {

            string dnaSequence = dna.Replace("n", "");
            if (dnaSequence.Length > 0)
            {
                string upstream = dnaSequence.Substring(0, dnaSequence.Length / 2);
                string downstream = dnaSequence.Substring(dnaSequence.Length / 2, dnaSequence.Length / 2);

                ReverseComplement(ref downstream);

                if (upstream.Length > 0 && upstream.Length <= 5 && downstream.Length > 0 && downstream.Length <= 5)
                {
                    if (upstream.Equals(downstream))
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else
                {
                    result = false;
                }

            }
        }
        else
        {
            result = false;
        }
        return result;
    }

    //ReverseComplement
    public static void ReverseComplement(ref string dna)
    {
        char[] dnaStrings = dna.ToCharArray();
        string reversedDNA = "";
        for (int i = 0; i < dnaStrings.Length; i++)
        {
            string text = "";
            switch (dnaStrings[i])
            {
                case 'A':
                    text = "T";
                    break;
                case 'T':
                    text = "A";
                    break;
                case 'G':
                    text = "C";
                    break;
                case 'C':
                    text = "G";
                    break;
                default:
                    break;
            }

            reversedDNA = text + reversedDNA;
        }
        dna = reversedDNA;
    }

    public static int CheckNum(int k)
    {
        int totalNum = 0;
        switch (k)
        {
            case 1:
                totalNum = 10;
                break;
            case 2:
                totalNum = 9;
                break;
            case 3:
                totalNum = 8;
                break;
            case 4:
                totalNum = 7;
                break;
            case 5:
                totalNum = 6;
                break;
            case 6:
                totalNum = 5;
                break;
            case 7:
                totalNum = 4;
                break;
            case 8:
                totalNum = 3;
                break;
            case 9:
                totalNum = 2;
                break;
            case 10:
                totalNum = 1;
                break;
            default:
                break;
        }
        return totalNum;
    }

    public static void Kmers(int k, ref string dna)
    {
        string[] kmersArr = new string[0];
        char[] argChars1 = dna.ToCharArray();

        var totalNum = CheckNum(k);

        string[] res1 = new string[totalNum];
        for (int i = 0; i < res1.Length; i++)
        {
            for (int j = 0 + i; j < k + i; j++)
            {
                res1[i] += argChars1[j].ToString();
            }
        }
        kmersArr = res1;

        string newDNA = "";
        foreach (string kmer in kmersArr)
        {
            newDNA = newDNA + " " + kmer;
        }
        dna = newDNA.Remove(0, 1);
    }
}