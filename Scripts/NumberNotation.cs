using System;
using System.Collections.Generic;

public static class NumberNotation {
    public enum RoundRule {
        Round,
        Floor,
        Ceil
    }

    private static Dictionary<int, string> exponentLetters = new Dictionary<int, string> {
        {3, "K"},
        {6, "M"},
        {9, "B"},
        {12, "T"},
        {15, "aa"},
        {18, "ab"},
        {21, "ac"},
        {24, "ad"},
        {27, "ae"}
    };

    public static string Format(double number, RoundRule roundRule = RoundRule.Floor) {
        if (number <= 1) {
            return number.ToString();
        }
        
        var exponent = Math.Floor(Math.Log10(number));
        var roundedExponent = (int)(exponent / 3) * 3;
        var letter = exponentLetters.GetValueOrDefault(roundedExponent, "");
        var shortNumber = number / Math.Pow(10, roundedExponent);
        var formattedShortNumber = Round(shortNumber, roundRule, 1);

        return $"{formattedShortNumber:0.#}{letter}";
    }

    private static double Round(double number, RoundRule rule, int digits) {
        var magnitude = Math.Pow(10, digits);
        
        switch (rule) {
            case RoundRule.Round:
                return Math.Round(number, digits);
            case RoundRule.Floor:
                return Math.Floor(number * magnitude) / magnitude;
            default:
                return Math.Ceiling(number * magnitude) / magnitude;
        }
    }
}