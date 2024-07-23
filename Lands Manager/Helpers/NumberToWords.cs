using System;

public class ArabicFigures
{
    public const int COUNTED_NUM = 5;
    public static string[] Con = { "F", "ريال", "ريالي", "ريالين", "ريالات" };
    public static string[] Figures = { "واحد", "أحد", "اثني", "ثلاثة", "أربعة", "خمسة", "ستة", "سبعة", "ثمانية", "تسعة", "اثنين", "واحد", "إحدى", "اثنتي", "ثلاث", "أربع", "خمس", "ست", "سبع", "ثمان", "تسع", "اثنتين", "عشرة", "عشر", "عشرين", "ثلاثين", "أربعين", "خمسين", "ستين", "سبعين", "ثمانين", "تسعين", "مائة", "مائتان", "مئتي", "مئات", "لاشئ", " ", " و " };
    public static string[] CountedFigures = { "M", "ألف", "ألفين", "ألفي", "آلاف", "M", "مليون", "مليونين", "مليونا", "ملايين", "M", "مليار", "مليارين", "مليارا", "مليارات", "M", "بليون", "بليونين", "بليونا", "بلايين", "M", "بليار", "بليارين", "بليارا", "بليارات", "M", "تريليون", "تريليونين", "تريليونا", "تريلايين" };

    public static string GetArabicFigurePart(long Number, string[] Counted, bool HasOther, bool LastCount)
    {
        string result;
        int I;
        long a1;
        long a2;
        long a3;
        long f1;
        long f2;
        long f3;
        long fa;
        long fm;
        int Mas;
        int Mas11;
        long[] Phrase = new long[8 + 1];
        string PhraseStr;
        int j;
        result = "";
        if (Counted[0] == "M")
        {
            Mas = 1;
        }
        else
        {
            Mas = 0;
        }
        Mas11 = Mas * 11;
        a3 = (Number / 100);
        a2 = (Number / 10) % 10;
        a1 = Number - a2 * 10 - a3 * 100;
        if ((a1 > 2))
        {
            f1 = 3;
        }
        else
        {
            f1 = a1;
        }
        if ((a2 > 1))
        {
            f2 = 2;
        }
        else
        {
            f2 = a2;
        }
        if ((a3 > 2))
        {
            f3 = 3;
        }
        else
        {
            f3 = a3;
        }
        fa = (f2 * 4) + f1;
        if (fa > 0)
        {
            fm = 1 * 4 + f3;
        }
        else
        {
            fm = 0 * 4 + f3;
        }
        for (j = 0; j < Phrase.Length; j++)
        {
            Phrase[j] = -1;
        }
        Phrase[0] = 1;
        switch (fa)
        {
            case 0:
                if ((a3 == 0))
                {
                    if (LastCount)
                    {
                        Phrase[1] = 37;
                    }
                    else
                    {
                        Phrase[0] = -1;
                    }
                }
                break;
            case 1:
                if (!LastCount && (!(a3 == 0)))
                {
                    Phrase[1] = 37;
                    Phrase[2] = Mas11;
                }
                break;
            case 2:
                if (LastCount || (a3 == 0))
                {
                    if (HasOther)
                    {
                        Phrase[0] = 3 - 1;
                    }
                    else
                    {
                        Phrase[0] = 3 - 0;
                    }
                    Phrase[1] = -1;
                    Phrase[2] = -1;
                }
                else
                {
                    Phrase[1] = 37;
                    Phrase[2] = Mas11 + a1;
                }
                break;
            case 3:
                Phrase[0] = 4;
                Phrase[1] = 37;
                Phrase[2] = Mas11 + a1;
                break;
            case 4:
                Phrase[0] = 4;
                Phrase[1] = 37;
                Phrase[2] = 22 + Mas;
                break;
            case 5:
            case 6:
            case 7:
                Phrase[1] = 37;
                Phrase[2] = 22 + Mas;
                Phrase[3] = 37;
                Phrase[4] = Mas11 + a1;
                break;
            case 8:
                Phrase[1] = 37;
                Phrase[2] = 22 + a2;
                break;
            case 9:
                Phrase[1] = 37;
                Phrase[2] = 22 + a2;
                Phrase[3] = 38;
                Phrase[4] = Mas11 + Mas;
                break;
            case 10:
                Phrase[1] = 37;
                Phrase[2] = 22 + a2;
                Phrase[3] = 38;
                Phrase[4] = Mas11 + 10;
                break;
            case 11:
                Phrase[1] = 37;
                Phrase[2] = 22 + a2;
                Phrase[3] = 38;
                Phrase[4] = Mas11 + a1;
                break;
        }
        switch (fm)
        {
            case 1:
                Phrase[5] = 37;
                Phrase[6] = 32;
                break;
            case 2:
                Phrase[5] = 37;
                Phrase[6] = 34;
                break;
            case 3:
                Phrase[5] = 37;
                Phrase[6] = 32;
                Phrase[7] = 11 + a3;
                break;
            case 5:
                Phrase[5] = 38;
                Phrase[6] = 32;
                break;
            case 6:
                Phrase[5] = 38;
                Phrase[6] = 33;
                break;
            case 7:
                Phrase[5] = 38;
                Phrase[6] = 32;
                Phrase[7] = 11 + a3;
                break;
        }
        for (I = 7; I >= 1; I--)
        {
            if ((Phrase[I] >= 0))
            {
                PhraseStr = Figures[Phrase[I]];
                result = result + PhraseStr;
            }
        }
        if ((Phrase[0] >= 0))
        {
            result = result + Counted[Phrase[0]];
        }
        if (HasOther)
        {
            result = result + " و ";
        }
        return result;
    }

    public static string GetArabicFigure(long Number, string[] CurrencyNames)
    {
        string result;
        int I;
        int X;
        long CurValue;
        long ModValue;
        bool HasOther;
        bool LastCount;
        string[] Counted = new string[5];
        string BufStr;
        string StrRes;
        int j;
        if (Number == 0)
        {
            result = Figures[36];
        }
        else
        {
            for (j = 0; j <= 4; j++)
            {
                Counted[j] = CurrencyNames[j];
            }
            LastCount = true;
            StrRes = "";
            ModValue = Number;
            HasOther = false;
            CurValue = ModValue % 1000;
            ModValue = (ModValue - CurValue) / 1000;
            StrRes = GetArabicFigurePart(CurValue, Counted, HasOther, LastCount);
            BufStr = StrRes;
            LastCount = false;
            I = 0;
            while ((ModValue != 0))
            {
                HasOther = (CurValue != 0);
                CurValue = ModValue % 1000;
                ModValue = (ModValue - CurValue) / 1000;
                X = 0;
                while (X < COUNTED_NUM)
                {
                    Counted[X] = CountedFigures[I];
                    X = X + 1;
                    I = I + 1;
                }
                StrRes = GetArabicFigurePart(CurValue, Counted, HasOther, LastCount);
                StrRes = StrRes + BufStr;
                BufStr = StrRes;
            }
            result = StrRes;
        }
        return result;
    }

}



