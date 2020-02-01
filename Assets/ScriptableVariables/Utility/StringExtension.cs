using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public static class StringExtension
{
    /// <summary>
    /// The regex used for Unity Asset names.
    /// </summary>
    public const string REGEX_ASSET_NAME = @"[^a-zA-Z0-9_-]";

    /// <summary>
    /// Gets a string where all words are separated by a space.
    /// </summary>
    /// <param name="aInstance">The camel case string to split.</param>
    /// <param name="aDoPreserveAcronyms">A flag to enable acronyms recognition (see remarks for details).</param>
    /// <returns>Returns the original string if no words are identified.</returns>
    /// <remarks>
    /// Words are recognized by an upper character followed by an indefinite number of lower characters.
    /// If <paramref name="aDoPreserveAcronyms"/> is active, a word can also be recognized as an indefinite succession of upper characters.
    /// </remarks>
    public static string AddSpacesToWord(this string aInstance, bool aDoPreserveAcronyms)
    {
        if (string.IsNullOrEmpty(aInstance))
            return string.Empty;

        var newText = new StringBuilder(aInstance.Length * 2);
        newText.Append(aInstance[0]);
        for (var i = 1; i < aInstance.Length; i++)
        {
            if (char.IsUpper(aInstance[i]))
                if (aInstance[i - 1] != ' '
                    && !char.IsUpper(aInstance[i - 1])
                    || aDoPreserveAcronyms
                    && char.IsUpper(aInstance[i - 1])
                    && i < aInstance.Length - 1
                    && !char.IsUpper(aInstance[i + 1]))
                    newText.Append(' ');

            newText.Append(aInstance[i]);
        }

        return newText.ToString();
    }

    /// <summary>
    /// Gets a valid asset name from the provided name.
    /// </summary>
    public static string GetValidAssetName(this string aInputName) 
        => Regex.Replace(aInputName, REGEX_ASSET_NAME, "");

    /// <summary>
    /// Returns an unique name among the list prioritizing the given name.
    /// </summary>
    /// <remarks>
    /// Name unicity is case insensitive.
    /// </remarks>
    public static string GetUniqueName(this IEnumerable<string> aNameList, string aName)
    {
        var loweredNameList = aNameList.Select(name => name.ToLower());
        var uniqueChannelName = aName;

        // Check existing keys to avoid duplicate.
        for (var i = 1; loweredNameList.Any(name => name == uniqueChannelName.ToLower()); ++i)

            // Append i at the end of the channel name.
            uniqueChannelName = aName + i.ToString();

        return uniqueChannelName;
    }
}
